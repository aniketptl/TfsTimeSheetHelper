using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System;

namespace TfsTimeSheetHelper
{
    public partial class TfsTimeSheetForm : Form
    {
        Dictionary<String, List<String>> dayDefectTemplate = new Dictionary<String, List<String>>();
        List<String> defectList = new List<string>();

        String day, emptyPattern = ",,", emptylast = ",";
        StringBuilder csvExport = new StringBuilder();

        DateTime date;
        int hour;

        public TfsTimeSheetForm()
        {
            InitializeComponent();
            buildEmptyCollection();
            initSettings();
        }

        private void btnGenCSV_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential credential = new NetworkCredential(UserNameBox.Text, PasswordBox.Text);
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(TfsURIBox.Text), credential);
                tpc.EnsureAuthenticated();

                WorkItemStore workItemStore = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));

                WorkItemCollection queryResults = workItemStore.Query("Select [State], [Title] " +
                                                                        "From WorkItems " +
                                                                        "Where [Resolved by] = @Me AND [Resolved Date]> @Today-6 " +
                                                                        "Order By [Resolved Date] Asc");

                addCSVPre();

                foreach (WorkItem item in queryResults)
                {
                    date = Convert.ToDateTime(item["Resolved Date"]);
                    day = date.DayOfWeek.ToString();

                    int intDayWeek = (int)date.DayOfWeek;

                    if (dayDefectTemplate.ContainsKey(date.DayOfWeek.ToString()) && dayDefectTemplate[day] != null)
                    {
                        defectList = dayDefectTemplate[day];
                        defectList.Add(item.Id.ToString());

                        dayDefectTemplate[day] = defectList;

                    }
                    else
                    {
                        defectList = new List<string>();
                        defectList.Add(item.Id.ToString());

                        dayDefectTemplate[day] = defectList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please makesure URL/Username/Password is correct", "FoxTimeSheet Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(), "FoxTimeSheet Exception Handling for Dev", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (KeyValuePair<String, List<String>> resItem in dayDefectTemplate)
            {
                defectList = resItem.Value;

                if (defectList != null)
                {
                    foreach (String defectNumber in defectList)
                    {
                        csvExport.Append("187117,01.10,Normal -IN,");

                        hour = 8;
                        hour = hour / defectList.Count;

                        addPrefix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));
                        csvExport.Append(hour.ToString() + "," + defectNumber + ",");
                        addSuffix((int)Enum.Parse(typeof(DayOfWeek), resItem.Key, true));
                        csvExport.Append(Environment.NewLine);
                    }
                }
            }

            addCSVPost();

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


        public void buildEmptyCollection()
        {
            dayDefectTemplate.Add("Monday", null);
            dayDefectTemplate.Add("Tuesday", null);
            dayDefectTemplate.Add("Wednesday", null);
            dayDefectTemplate.Add("Thursday", null);
            dayDefectTemplate.Add("Friay", null);

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

        public void initSettings()
        {
            try
            {
                TfsURIBox.Text = Properties.Settings.Default.tfsURL;
                UserNameBox.Text = Properties.Settings.Default.userName;
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                TfsURIBox.Text = "http://sefoxdev136:8080/tfs/SE_FOX/";
            }
        }

        public void saveSettings()
        {
            Properties.Settings.Default.userName = UserNameBox.Text;
            Properties.Settings.Default.tfsURL = TfsURIBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
