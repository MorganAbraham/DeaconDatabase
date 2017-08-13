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
        private readonly string ConnecionString = global::Deacon_Database_Manager.Properties.Settings.Default.MemberDatabaseConnectionString;
        //private List<Member> QuickResults;
        private Dictionary<PictureBox, Member> QuickResults = new Dictionary<PictureBox, Member>();
        private Label LastResultLabel;
        private HomeScreen homeScreen;

        public HomePanel(HomeScreen homeScreen)
        {
            InitializeComponent();
            this.homeScreen = homeScreen;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                //txtSearch.Text = "Search For Members";
                //txtSearch.ForeColor = Color.LightGray;
                SearchResults.Controls.Clear();
            }
            else
            {
                txtSearch.ForeColor = Color.Black;
                using (SqlConnection Conn = new SqlConnection(ConnecionString))
                {
                    UserFilter FilterSettings = new UserFilter();
                    FilterSettings.MemberName = txtSearch.Text;
                    DataManager DM = new DataManager();
                    List<Member> FilterResults = DM.GetFilterResults(FilterSettings);

                    QuickResults.Clear();

                    foreach(Member FilterResult in FilterResults)
                    {
                        QuickResults.Add(new PictureBox(), FilterResult);
                    }

                    for (int i = 0; i < SearchResults.Controls.Count; i++)
                    {
                        SearchResults.Controls.RemoveAt(i);
                        i--;
                    }

                    LastResultLabel = null;
                    foreach(KeyValuePair<PictureBox, Member> QuickResult in QuickResults)
                    {
                        LoadQuickResult(QuickResult);
                    }
                }
            }
        }

        private void HomePanel_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection Conn = new SqlConnection(ConnecionString))
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

        private void LoadQuickResult(KeyValuePair<PictureBox, Member> QuickResult)
        {
            PictureBox PicBox = QuickResult.Key;
            Member member = QuickResult.Value;
            Label ResultLabel = new Label();
            ResultLabel.AutoSize = true;
            ResultLabel.Text = Regex.Replace(member.FirstName + ' ' + member.MiddleName + ' ' + member.LastName, "[ ]{2,}", " ");
            //PictureBox PicBox = new PictureBox();
            PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox.Height = 127;
            PicBox.Width = 102;
            ResourceManager Rm = Properties.Resources.ResourceManager;
            PicBox.Image = (Image)Rm.GetObject(member.PhotoPath);
            if(LastResultLabel == null)
            {
                PicBox.Top = 0;
                //PicBox.Left = 10;
            }
            else
            {
                PicBox.Top = LastResultLabel.Top + LastResultLabel.Height + 10;
            }

            ResultLabel.Left = PicBox.Left;
            ResultLabel.Top = PicBox.Top + PicBox.Height + 10;
            LastResultLabel = ResultLabel;
            ResultLabel.Visible = true;
            PicBox.Visible = true;
            SearchResults.Controls.Add(PicBox);
            SearchResults.Controls.Add(LastResultLabel);
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
            PictureBox PicBox = (PictureBox)sender;
            Member Result;
            if (QuickResults.TryGetValue(PicBox, out Result))
            {
                DataManager DM = new DataManager();
                Result = DM.GetMember(Result.Id);
                homeScreen.LoadPanel(new MemberView(homeScreen, Result, false));
                homeScreen.RemovePanel(this);
            }
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
