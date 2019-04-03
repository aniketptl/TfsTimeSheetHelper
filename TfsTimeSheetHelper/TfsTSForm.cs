using System;
using System.Net;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using DocumentFormat.OpenXml;
using TopSoft.ExcelExport;
using DocumentFormat.OpenXml.Packaging;
using TopSoft.ExcelExport.Styles;

namespace TfsTimeSheetHelper
{
    public partial class TfsTimeSheetForm : Form
    {
        public static int                               progressPercentage;
        Dictionary<String, Dictionary<WorkItem, float>> dayDefectTemplate = new Dictionary<String, Dictionary<WorkItem, float>>();
        Dictionary<WorkItem, float>                     defectHour        = new Dictionary<WorkItem, float>();
        DateTime                                        date;
        WorkItemCollection                              queryResults;
        List<String>                                    daysList      = new List<String>();
        List<TimesheetExcel>                            timesheetList = new List<TimesheetExcel>();
        int                                             numTillStartWeek;

        public TfsTimeSheetForm()
        {
            InitializeComponent();
            initSettings();
        }

        public void buildEmptyCollection()
        {
            dayDefectTemplate.Clear();
            timesheetList.Clear();

            dayDefectTemplate.Add("Monday", null);
            dayDefectTemplate.Add("Tuesday", null);
            dayDefectTemplate.Add("Wednesday", null);
            dayDefectTemplate.Add("Thursday", null);
            dayDefectTemplate.Add("Friday", null);

            daysList.Add("Monday");
            daysList.Add("Tuesday");
            daysList.Add("Wednesday");
            daysList.Add("Thursday");
            daysList.Add("Friday");

            processText.Text = "";

            this.buildExcelTitle();
        }

        public void buildExcelTitle()
        {
            timesheetList.Add(new TimesheetExcel() {Project = "Project",
                                                    ProjectName = "Project name",
                                                    TaskNumber = "Task number",
                                                    TaskName = "Task name",
                                                    Type = "Type",
                                                    Monday = "Monday",
                                                    Comment1 = "Comment1",
                                                    Timefrom1 = "Time from1",
                                                    Timeto1 = "Time to1",
                                                    Tuesday = "Tuesday",
                                                    Comment2 = "Comment2",
                                                    Timefrom2 = "Time from2",
                                                    Timeto2 = "Time to2",
                                                    Wednesday = "Wednesday",
                                                    Comment3 = "Comment3",
                                                    Timefrom3 = "Time from3",
                                                    Timeto3 = "Time to3",
                                                    Thursday = "Thursday",
                                                    Comment4 = "Comment4",
                                                    Timefrom4 = "Time from4",
                                                    Timeto4 = "Time to4",
                                                    Friday = "Friday",
                                                    Comment5 = "Comment5",
                                                    Timefrom5 = "Time from5",
                                                    Timeto5 = "Time to5",
                                                    Saturday = "Saturday",
                                                    Comment6 = "Comment6",
                                                    Timefrom6 = "Time from6",
                                                    Timeto6 = "Time to6",
                                                    Sunday = "Sunday",
                                                    Comment7 = "Comment7",
                                                    Timefrom7 = "Time from7",
                                                    Timeto7 = "Time to7"
                                                    });
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

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                NetworkCredential        credential     = new NetworkCredential(UserNameBox.Text, PasswordBox.Text);
                TfsTeamProjectCollection tpc            = new TfsTeamProjectCollection(new Uri(TfsURIBox.Text), credential);
                var                      versionControl = tpc.GetService<Microsoft.TeamFoundation.VersionControl.Client.VersionControlServer>();
                var                      name           = versionControl.AuthenticatedUser;

                numTillStartWeek        = (DateTime.Now.Date - DateTime.Now.FirstDayOfWeek().Date).Days;

                String defectQuery      = "Select * " +
                                          "From WorkItems " +
                                          "Where [Resolved by] = @Me AND [Resolved Date]> @Today-" + numTillStartWeek + " " +
                                          "Order By [Resolved Date] asc";

                String changedDateQuery = "Select * " +
                                          "From WorkItems " +
                                          "Where [Changed by] Ever @Me AND [Changed Date]> @Today-" + numTillStartWeek + " " +
                                          "Order By [Changed Date] asc";

                tpc.EnsureAuthenticated();

                setProgress(10);
                this.setProcessText("Authenticated with TFS");

                WorkItemStore   workItemStore = (WorkItemStore) tpc.GetService(typeof(WorkItemStore));

                setProgress(20);
                this.setProcessText("Querying result with TFS");

                if (changedByRd.Checked)
                {
                    queryResults = workItemStore.Query(changedDateQuery);
                }
                else
                {
                    queryResults = workItemStore.Query(defectQuery);
                }

                int loopItr = 1;

                this.setProcessText("Processing Data");

                //Put All items
                foreach (WorkItem item in queryResults)
                {
                    if (progressPercentage <= 70)
                    {
                        setProgress((loopItr / queryResults.Count) * 40, true);
                    }

                    this.setProcessText("Processing : "+item.Type.Name+" "+item.Title);

                    if (changedByRd.Checked)
                    {
                        if(checkRevisions(item,name) == null)
                        {
                            continue;
                        }
                        else
                        {
                            date = checkRevisions(item,name) ?? DateTime.MinValue;
                        }
                    }
                    else
                    {
                        date = Convert.ToDateTime(item["Resolved Date"]);
                    }
                    
                    String  day        = date.DayOfWeek.ToString();
                    int     intDayWeek = (int)date.DayOfWeek;
                    float   estimated  = 0;

                    if (dayDefectTemplate.ContainsKey(date.DayOfWeek.ToString()) && dayDefectTemplate[day] != null)
                    {
                        defectHour = dayDefectTemplate[day];
                        defectHour.Add(item, estimated);
                        dayDefectTemplate[day] = defectHour;
                    }
                    else
                    {
                        defectHour = new Dictionary<WorkItem, float>();
                        defectHour.Add(item, estimated);
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

            this.setProcessText("Parsing Data");
            // Loop Day Wise
            foreach (KeyValuePair<String, Dictionary<WorkItem, float>> resItem in dayDefectTemplate)
            {
                defectHour = resItem.Value;

                if (defectHour != null)
                {
                    // Loop Defect Wise
                    foreach (KeyValuePair<WorkItem, float> defectHourList in defectHour)
                    {
                        if (progressPercentage <= 90)
                        {
                            setProgress((loopItr2 / queryResults.Count) * 20, true);
                        }

                        WorkItem    workItem      = defectHourList.Key;
                        String      defectNumber  = workItem.Type.Name + " " + workItem.Id + " : " + workItem.Title + " [" + workItem.CreatedBy + "] ";
                        String      projectNumber = this.getCode(workItem.Type, "project");
                        String      task          = this.getCode(workItem.Type, "task");
                        String      type          = this.getCode(workItem.Type, "type");
                        float       hour          = 8;

                        if (developerEstimateChk.Checked)
                        {
                            if (defectHourList.Value == 0)
                            {
                                hour = hour / defectHour.Count;

                                timesheetList.Add(this.createRow(resItem.Key, defectNumber, hour.ToString(), projectNumber, task, type));
                            }
                            else
                            {
                                hour = (float) defectHourList.Value;

                                int daysDivide, indexDay = 0;

                                if (hour % 8 == 0)
                                {
                                    daysDivide = (int)(hour / 8);
                                }
                                else
                                {
                                    daysDivide = 1;
                                }

                                hour = hour / daysDivide;

                                if (daysList.Contains(resItem.Key))
                                {
                                    indexDay = daysList.IndexOf(resItem.Key);
                                }
                                
                                for (int i = 0; i < daysDivide; i++)
                                {
                                   timesheetList.Add(this.createRow(daysList[indexDay], defectNumber, hour.ToString(), projectNumber, task, type));

                                   indexDay++;
                                }
                            }
                        }
                        else
                        {
                            hour = hour / defectHour.Count;

                            timesheetList.Add(this.createRow(resItem.Key, defectNumber, hour.ToString(), projectNumber, task, type));
                        }

                        loopItr2++;
                    }
                }

            }

            this.exportExcel();
        }

        private Nullable<DateTime> checkRevisions(WorkItem item,String userDisplayName)
        {
            foreach (Revision rev in item.Revisions)
            {
                string changedBy = (string) rev.Fields["Changed By"].Value;

                if (changedBy == userDisplayName)
                {
                    DateTime changedDate = (DateTime)rev.Fields["Changed Date"].Value;

                    if ((DateTime.Today.AddDays(-numTillStartWeek) <= changedDate.Date && changedDate.Date <= DateTime.Today))
                    {
                        return changedDate;
                    }
                }
            }

            return null;
        }

        private void setProgress(int i,Boolean add=false)
        {
            if(add)
            {
                progressPercentage = progressPercentage+i;
            }
            else
            {
                progressPercentage = i;
            }

            backgroundWorker.ReportProgress(progressPercentage);
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        public  void exportExcel()
        {
            this.setProcessText("Exporting to Excel");

            String fileName = string.Format("Timesheet-{0:yyyy-MM-dd_hh-mm-ss-tt}.xlsx", DateTime.Now);
            string path     = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\";

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(@path + fileName, SpreadsheetDocumentType.Workbook))
            {
                var  excelExportContext = new ExportContext(spreadsheetDocument);
                uint rowNo = 0;

                foreach (var timesheetExcel in timesheetList)
                {
                    rowNo++;

                    if(rowNo == 1)
                    {
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Project, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.ProjectName, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.TaskNumber, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.TaskName, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Type, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timefrom1, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timefrom2, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timefrom3, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timefrom4, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timefrom5, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timefrom6, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timefrom7, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timeto1, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timeto2, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timeto3, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timeto4, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timeto5, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timeto6, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Timeto7, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Saturday, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Friday, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Thursday, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Wednesday, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Tuesday, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Monday, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Sunday, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Comment1, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Comment2, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Comment3, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Comment4, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Comment5, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Comment6, new CellFill(hexColor: "FCFCAE"));
                        timesheetExcel.MapStyle<TimesheetExcel>(x => x.Comment7, new CellFill(hexColor: "FCFCAE"));
                    }

                    excelExportContext.RenderEntity(timesheetExcel, rowNo);
                }

                excelExportContext.SaveChanges();
            }

            setProgress(100);

            this.setProcessText("Finished Exporting File . Find it on Desktop "+ fileName);
        }

        public TimesheetExcel  createRow(string _day,                                     
                                         string _comment,
                                         string _hours,
                                         string _project,
                                         string _task,
                                         string _type,
                                         string _projectName = "",
                                         string _taskName = ""
                                        )
        {
            TimesheetExcel timesheetExcel = new TimesheetExcel();

            switch (_day)
            {
                case "Monday":

                    timesheetExcel.Monday      = _hours;
                    timesheetExcel.Project     = _project;
                    timesheetExcel.ProjectName = _projectName;
                    timesheetExcel.TaskNumber  = _task;
                    timesheetExcel.TaskName    = _taskName;
                    timesheetExcel.Type        = _type;
                    timesheetExcel.Comment1    = _comment;
                    break;

                case "Tuesday":

                    timesheetExcel.Tuesday     = _hours;
                    timesheetExcel.Project     = _project;
                    timesheetExcel.ProjectName = _projectName;
                    timesheetExcel.TaskNumber  = _task;
                    timesheetExcel.TaskName    = _taskName;
                    timesheetExcel.Type        = _type;
                    timesheetExcel.Comment2    = _comment;
                    break;

                case "Wednesday":

                    timesheetExcel.Wednesday   = _hours;
                    timesheetExcel.Project     = _project;
                    timesheetExcel.ProjectName = _projectName;
                    timesheetExcel.TaskNumber  = _task;
                    timesheetExcel.TaskName    = _taskName;
                    timesheetExcel.Type        = _type;
                    timesheetExcel.Comment3    = _comment;
                    break;

                case "Thursday":

                    timesheetExcel.Thursday    = _hours;
                    timesheetExcel.Project     = _project;
                    timesheetExcel.ProjectName = _projectName;
                    timesheetExcel.TaskNumber  = _task;
                    timesheetExcel.TaskName    = _taskName;
                    timesheetExcel.Type        = _type;
                    timesheetExcel.Comment4    = _comment;
                    break;

                case "Friday":

                    timesheetExcel.Friday      = _hours;
                    timesheetExcel.Project     = _project;
                    timesheetExcel.ProjectName = _projectName;
                    timesheetExcel.TaskNumber  = _task;
                    timesheetExcel.TaskName    = _taskName;
                    timesheetExcel.Type        = _type;
                    timesheetExcel.Comment5    = _comment;
                    break;
            }

            return timesheetExcel;
        }

        public string  getCode(WorkItemType _type, string _fieldName)
        {
            switch (_type.Name)
            {
                case "Defect":

                    switch (_fieldName)
                    {
                        case "project":
                            return projectDefectNumBox.Text;

                        case "task":
                            return defectTaskBox.Text;

                        case "type":
                            return defectTypeBox.Text;
                    }

                    break;

                case "Change Request":
                case "Task":

                    switch (_fieldName)
                    {
                        case "project":
                            return crProjectNumBox.Text;

                        case "task":
                            return crTaskIdBox.Text;

                        case "type":
                            return crTypeBox.Text;
                    }

                    break;
            }

            return "";
        }

        public void setProcessText(string _txt)
        {
            processText.BeginInvoke(new MethodInvoker(() =>
            {
                processText.Text = _txt;
            }));
        }

        public  void initSettings()
        {
            try
            {
                // TFS
                TfsURIBox.Text           = Properties.Settings.Default.tfsURL;
                UserNameBox.Text         = Properties.Settings.Default.userName;

                // Defect
                projectDefectNumBox.Text = Properties.Settings.Default.projectNumber;
                defectTaskBox.Text       = Properties.Settings.Default.taskId;
                defectTypeBox.Text       = Properties.Settings.Default.type;

                // CR
                crProjectNumBox.Text = Properties.Settings.Default.crProjectNumber;
                crTaskIdBox.Text     = Properties.Settings.Default.crTaskId;
                crTypeBox.Text       = Properties.Settings.Default.crType;
            }
            catch (System.Configuration.SettingsPropertyNotFoundException)
            {
                // If no property found set default link
                TfsURIBox.Text = "http://sefoxdev136:8080/tfs/SE_FOX/";
            }

            noneRd.Checked = true;
        }

        public  void saveSettings()
        {
            // TFS
            Properties.Settings.Default.userName      = UserNameBox.Text;
            Properties.Settings.Default.tfsURL        = TfsURIBox.Text;

            // Defect
            Properties.Settings.Default.projectNumber = projectDefectNumBox.Text;
            Properties.Settings.Default.taskId        = defectTaskBox.Text;
            Properties.Settings.Default.type          = defectTypeBox.Text;

            // CR
            Properties.Settings.Default.crProjectNumber = crProjectNumBox.Text;
            Properties.Settings.Default.crTaskId        = crTaskIdBox.Text;
            Properties.Settings.Default.crType          = crTypeBox.Text;

            Properties.Settings.Default.Save();

            processText.Text = "Settings Saved";
        }
    }
}
