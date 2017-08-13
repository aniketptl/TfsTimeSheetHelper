using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Net;
using System;

namespace TfsTimeSheetHelper
{
    public partial class TfsTimeSheetForm : Form
    {
        public TfsTimeSheetForm()
        {
            InitializeComponent();
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
        }
    }
}
