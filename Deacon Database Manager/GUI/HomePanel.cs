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
                for (int i = 0; i < SearchResults.Controls.Count; i++)
                {
                    SearchResults.Controls.RemoveAt(i);
                    i--;
                }
            }
            else
            {
                txtSearch.ForeColor = Color.Black;
                using (SqlConnection Conn = new SqlConnection(ConnecionString))
                {
                    string Stmt = "SELECT [Id], [First Name], [Middle Name], [Last Name], [ImagePath] " + 
                        "FROM Demographics " + 
                        "INNER JOIN Images ON Demographics.Id = Images.Member_Id " +
                        "WHERE Demographics.[First Name] + ' ' + " + 
                        "Demographics.[Last Name] LIKE '%" + txtSearch.Text + 
                        "%' OR Demographics.[First Name] + ' '+ Demographics.[Middle Name] + ' ' + " +
                        "Demographics.[Last Name] LIKE '%" + txtSearch.Text + "%' " +  
                        "ORDER BY Demographics.[First Name], Demographics.[Middle Name], Demographics.[Last Name]";
                    SqlCommand Cmd = new SqlCommand(Stmt, Conn);
                    Cmd.CommandType = CommandType.Text;
                   
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    //QuickResults = new List<Member>();
                    QuickResults.Clear();

                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while(Reader.Read())
                        {
                            Member member = new Member();
                            member.Id = Reader.GetInt32(0);
                            member.FirstName = Reader.IsDBNull(1) ? "" : Reader.GetString(1);
                            member.MiddleName = Reader.IsDBNull(2) ? "" : Reader.GetString(2);
                            member.LastName = Reader.IsDBNull(3) ? "" : Reader.GetString(3);
                            member.PhotoPath = Reader.IsDBNull(3) ? null : Reader.GetString(4);
                            QuickResults.Add(new PictureBox(), member);
                        }
                    }

                    for (int i = 0; i < SearchResults.Controls.Count; i++)
                    {
                        SearchResults.Controls.RemoveAt(i);
                        i--;
                    }

                    LastResultLabel = null;
                    //for (int i = 0; i < QuickResults.Count; i++)
                    //{
                    //    LoadQuickResult(QuickResults[i]);
                    //}
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
