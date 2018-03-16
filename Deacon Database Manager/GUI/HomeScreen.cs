using Deacon_Database_Manager.DbTools;
using Deacon_Database_Manager.MemberData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Deacon_Database_Manager.GUI
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
            LoadPanel(new HomePanel(this));
        }

        public void LoadPanel(Form panel)
        {
            panel.TopLevel = false;
            panel.Visible = true;
            WorkPanel.Controls.Add(panel);
            panel.WindowState = FormWindowState.Maximized;
        }

        public void RemovePanel(Form panel)
        {
            WorkPanel.Controls.Remove(panel);
            panel.Dispose();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            DataManager DM = new DataManager();
            int MemberId = DM.GetNextId();
            if (MemberId != -1)
            {
                Member member = new Member();
                member.Id = MemberId;
                LoadPanel(new MemberView(this, member, true));
            }
            else
            {
                MessageBox.Show("There was an error generating Member ID. New Member cannot be created.", "ID Creation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPanel(new SearchForm(this));
        }

        private void btnDeacons_Click(object sender, EventArgs e)
        {
            LoadPanel(new DeaconPanel(this));
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
