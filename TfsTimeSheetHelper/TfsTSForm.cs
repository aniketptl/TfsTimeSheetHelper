using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System;

namespace TfsTimeSheetHelper
{
    public partial class TfsTimeSheetForm : Form
    {
        Dictionary<String, Dictionary<String, float>> dayDefectTemplate = new Dictionary<String, Dictionary<String, float>>();
        Dictionary<String, float> defectHour = new Dictionary<string, float>();

        String day, emptyPattern = ",,", emptylast = ",";
        StringBuilder csvExport  = new StringBuilder();

        DateTime date;
        int progressPercentage;

        String defectQuery      = "Select[State], [Title] " +
                                  "From WorkItems " +
                                  "Where [Resolved by] = @Me AND [Resolved Date]> @Today-6 " +
                                  "Order By [Resolved Date] Asc";

        String changedDateQuery = "Select[State], [Title] " +
                                  "From WorkItems " +
                                  "Where [Changed by] = @Me AND [Changed Date]> @Today-6 " +
                                  "Order By [Changed Date] Asc";

        public TfsTimeSheetForm()
        {
            InitializeComponent();
            initSettings();
        }

        private void btnGenCSV_Click(object sender, EventArgs e)
        {
            buildEmptyCollection();

            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Process is working in background , Please wait", "Fox TimeSheet Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void addPrefix(int intDayWeek)
        {
            for (int i = 1; i < intDayWeek; i++)
            {
                csvExport.Append(emptyPattern);
            }
        }

        public void addSuffix(int intDayWeek)
        {
            for (int i = intDayWeek; i < 5; i++)
            {
                if (i == 4)
                {
                    csvExport.Append(emptylast);
                }
                else
                {
                    csvExport.Append(emptyPattern);
                }
            }
        }

        public void exportFile()
        {
            String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TfsTimeSheet.csv";

            File.Delete(desktopPath);

            File.AppendAllText(desktopPath, csvExport.ToString());

            MessageBox.Show("File Written to Desktop", "TFS TimeSheet Helper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void buildEmptyCollection()
        {
            dayDefectTemplate.Clear();

            dayDefectTemplate.Add("Monday", null);
            dayDefectTemplate.Add("Tuesday", null);
            dayDefectTemplate.Add("Wednesday", null);
            dayDefectTemplate.Add("Thursday", null);
            dayDefectTemplate.Add("Friay", null);

            csvExport.Clear();
        }

        public void addCSVPre()
        {
            csvExport.AppendLine("START_HEADER");
            csvExport.AppendLine("Overriding Approver,,,,,,,,,,,,,,,,,");
            csvExport.AppendLine("Comments,,,,,,,,,,,,,,,,,");
            csvExport.AppendLine("STOP_HEADER");
            csvExport.AppendLine(",,,,,,,,,,,,,,,,,");

            csvExport.AppendLine("START_TEMPLATE");
            csvExport.AppendLine("Project,Task,Type,Mon,CommentText,Tue,CommentText,Wed,CommentText,Thu,CommentText,Fri,CommentText,Sat,CommentText,Sun,CommentText,END_COLUMN");
        }

        public void addCSVPost()
        {
            csvExport.AppendLine("STOP_TEMPLATE");
            csvExport.AppendLine("ORACLE RESERVED SECTION");
            csvExport.AppendLine(",,,,,,,,,,,,,,,,,");
            csvExport.AppendLine("START_ORACLE");

            csvExport.AppendLine("A|PROJECTS|Attribute1|A|PROJECTS|Attribute2|AE|PROJECTS|Attribute3|PROJECTS|Attribute5|D|DI|CommentText|D|DI|CommentText|D|DI|CommentText|D|DI|Comm");
            csvExport.AppendLine("entText|D|DI|CommentText|D|DI|CommentText|D|DI|CommentText|,,,,,,,,,,,,,,,,,");

            csvExport.AppendLine("2121472,,,,,,,,,,,,,,,,,");
            csvExport.AppendLine("A|APPROVAL|Attribute10|DI|CommentText|,,,,,,,,,,,,,,,,,");
            csvExport.AppendLine("STOP_ORACLE,END");
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                NetworkCredential credential = new NetworkCredential(UserNameBox.Text, PasswordBox.Text);
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(TfsURIBox.Text), credential);

                tpc.EnsureAuthenticated();

                setProgress(10);

                WorkItemStore workItemStore = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));
                WorkItemCollection queryResults;

                setProgress(20);

                if (changedByRd.Checked)
                {
                    queryResults = workItemStore.Query(changedDateQuery);
                }
                else
                {
                    queryResults = workItemStore.Query(defectQuery);
                }

                addCSVPre();

                int loopItr = 1;

                foreach (WorkItem item in queryResults)
                {                    
                    if (progressPercentage <= 70)
                    {
                        setProgress((loopItr / queryResults.Count)*40);
                    }

                    date = Convert.ToDateTime(item["Resolved Date"]);
                    day = date.DayOfWeek.ToString();

                    int intDayWeek = (int)date.DayOfWeek;
                    float estimated = 0;

                    if (item["Development Estimate"] != null)
                    {
                        estimated = (float)Convert.ToDecimal(item["Development Estimate"]);
                    }

                    if (dayDefectTemplate.ContainsKey(date.DayOfWeek.ToString()) && dayDefectTemplate[day] != null)
                    {
                        defectHour = dayDefectTemplate[day];
                        defectHour.Add(item.Id.ToString(), estimated);

                        dayDefectTemplate[day] = defectHour;
                    }
                    else
                    {
                        defectHour = new Dictionary<string, float>();
                        defectHour.Add(item.Id.ToString(), estimated);
                        dayDefectTemplate[day] = defectHour;
                    }

                    loopItr++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please makesure URL/Username/Password is correct", "Fox TimeSheet Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(), "Fox TimeSheet Exception Handling for Dev", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int loopItr2 = 1;

            foreach (KeyValuePair<String, Dictionary<string, float>> resItem in dayDefectTemplate)
            {
                defectHour = resItem.Value;
                
                if (progressPercentage <= 100)
                {
                    setProgress((loopItr2 / dayDefectTemplate.Count)*100);
                }

                if (defectHour != null)
                {
                    foreach (KeyValuePair<String, float> defectHourList in defectHour)
                    {
                        csvExport.Append(projectNumBox.Text.Trim() + "," + taskBox.Text.Trim() + "," + typeBox.Text.Trim() + ",");

                        String defectNumber = defectHourList.Key.ToString();
                        float hour = 8;

                        if (developerEstimateRd.Checked)
                        {
                            if (defectHourList.Value == 0)
                            {
                                hour = hour / defectHour.Count;

                                addPrefix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));
                                csvExport.Append(hour.ToString() + "," + defectNumber + ",");
                                addSuffix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));
                                csvExport.Append(Environment.NewLine);
                            }
                            else
                            {
                                hour = (float)defectHourList.Value;

                                int daysDivide = (int)(hour / 8);

                                hour = hour / daysDivide;

                                addPrefix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));

                                for (int i = 0; i < daysDivide; i++)
                                {
                                    csvExport.Append(hour.ToString() + "," + defectNumber + ",");
                                }

                                addSuffix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));
                                csvExport.Append(Environment.NewLine);
                            }
                        }
                        else
                        {
                            hour = hour / defectHour.Count;

                            addPrefix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));
                            csvExport.Append(hour.ToString() + "," + defectNumber + ",");
                            addSuffix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));
                            csvExport.Append(Environment.NewLine);
                        }
                    }
                }

                loopItr2++;
            }

            addCSVPost();
            exportFile();
        }

        private void setProgress(int i)
        {
            progressPercentage = i;
            backgroundWorker.ReportProgress(progressPercentage);
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        public void initSettings()
        {
            try
            {
                TfsURIBox.Text     = Properties.Settings.Default.tfsURL;
                UserNameBox.Text   = Properties.Settings.Default.userName;
                projectNumBox.Text = Properties.Settings.Default.projectNumber;
                taskBox.Text       = Properties.Settings.Default.taskId;
                typeBox.Text       = Properties.Settings.Default.type;
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                TfsURIBox.Text = "http://sefoxdev136:8080/tfs/SE_FOX/";
            }
        }

        public void saveSettings()
        {
            //User
            Properties.Settings.Default.userName = UserNameBox.Text;
            Properties.Settings.Default.tfsURL = TfsURIBox.Text;

            //Project/Task/Type
            Properties.Settings.Default.projectNumber = projectNumBox.Text;
            Properties.Settings.Default.taskId = taskBox.Text;
            Properties.Settings.Default.type = typeBox.Text;

            Properties.Settings.Default.Save();
        }
    }
}
