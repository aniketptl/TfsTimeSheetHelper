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
        StringBuilder csvExport = new StringBuilder();

        public TfsTimeSheetForm()
        {
            InitializeComponent();
            buildEmptyCollection();
            initSettings();
        }

        private void btnGenCSV_Click(object sender, EventArgs e)
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

            //Logic Goes Here

            addCSVPost();

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
                TfsURIBox.Text = "http://sefoxdev136:8080/tfs/SE_FOX/SD";
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
