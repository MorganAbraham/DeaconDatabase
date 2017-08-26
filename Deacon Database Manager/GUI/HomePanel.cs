using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Deacon_Database_Manager.MemberData;
using System.Text.RegularExpressions;
using System.Resources;
using Deacon_Database_Manager.DbTools;

namespace Deacon_Database_Manager.GUI
{
    public partial class HomePanel : Form
    {
        private HomeScreen homeScreen;

        public HomePanel(HomeScreen homeScreen)
        {
            InitializeComponent();
            this.homeScreen = homeScreen;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchResults.Controls.Clear();
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                //txtSearch.Text = "Search For Members";
                //txtSearch.ForeColor = Color.LightGray;   
            }
            else
            {
                txtSearch.ForeColor = Color.Black;
                UserFilter FilterSettings = new UserFilter();
                FilterSettings.MemberName = txtSearch.Text;
                DataManager DM = new DataManager();
                List<Member> FilterResults = DM.GetFilterResults(FilterSettings);

                SearchResults.Controls.Clear();

                foreach(Member FilterResult in FilterResults)
                {
                    LoadQuickResult(FilterResult);
                }
            }
        }

        private void HomePanel_Load(object sender, EventArgs e)
        {
            string ConnectionString = Properties.Settings.Default.MemberDatabaseConnectionString;
            using (SqlConnection Conn = new SqlConnection(ConnectionString))
            {
                SqlCommand Cmd = new SqlCommand("GetUpcomingBirthDays");
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Connection = Conn;
                DateTime StartDate = DateTime.Today;
                DateTime EndDate = StartDate.AddDays(31);
                //list the parameters required and what they should be
                Cmd.Parameters.AddWithValue("@StartDate", StartDate);
                Cmd.Parameters.AddWithValue("@EndDate", EndDate);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                using (SqlDataAdapter adap = new SqlDataAdapter(Cmd))
                {
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    UpcomingBirthdays.DataSource = dt;
                }
            }

            

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search For Members")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void SearchResults_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadQuickResult(Member FilterResult)
        {
            Label ResultLabel = new Label();
            ResultLabel.AutoSize = true;
            ResultLabel.Text = Regex.Replace(FilterResult.FirstName + ' ' + 
                FilterResult.MiddleName + ' ' + FilterResult.LastName, "[ ]{2,}", " ");

            PictureBox PicBox = new PictureBox();
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Height = 127;
            PicBox.Width = 102;
            PicBox.Name = FilterResult.Id.ToString();

            ResourceManager Rm = Properties.Resources.ResourceManager;
            PicBox.Image = (Image)Rm.GetObject(FilterResult.PhotoPath);

            Control LastControl = null;
            if (SearchResults.Controls.Count == 0)
            {
                PicBox.Top = 0;
                //PicBox.Left = 10;
            }
            else
            {
                LastControl = SearchResults.Controls[SearchResults.Controls.Count - 1];
                PicBox.Top = LastControl.Top + LastControl.Height + 10;
            }

            ResultLabel.Left = PicBox.Left;
            ResultLabel.Top = PicBox.Top + PicBox.Height + 10;

            ResultLabel.Visible = true;
            PicBox.Visible = true;
            SearchResults.Controls.Add(PicBox);
            SearchResults.Controls.Add(ResultLabel);
            PicBox.Click += new EventHandler(PicBox_OnClick);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Search For Members";
                txtSearch.ForeColor = Color.LightGray;
            }
        }

        private void PicBox_OnClick(object sender, EventArgs e)
        {
            PictureBox PicBox = sender as PictureBox;
            DataManager DM = new DataManager();
            Member Result = DM.GetMember(Convert.ToInt32(PicBox.Name));
            homeScreen.LoadPanel(new MemberView(homeScreen, Result, false));
            homeScreen.RemovePanel(this);
        }

        private void btnCreateMember_Click(object sender, EventArgs e)
        {
            DataManager DM = new DataManager();
            int MemberId = DM.GetNextId();
            if(MemberId != -1)
            {
                Member member = new Member();
                member.Id = MemberId;
                homeScreen.LoadPanel(new MemberView(homeScreen, member, true));
                homeScreen.RemovePanel(this);
            }
            else
            {
                MessageBox.Show("There was an error generating Member ID. New Member cannot be created.", "ID Creation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
