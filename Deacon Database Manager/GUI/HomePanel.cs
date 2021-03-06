﻿using System;
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
        private List<Member> Members;

        public HomePanel(HomeScreen homeScreen)
        {
            InitializeComponent();
            this.homeScreen = homeScreen;
        }

        

        private void HomePanel_Load(object sender, EventArgs e)
        {

            ///Get All Members
            DataManager DM = new DataManager();
            Members = DM.GetAllMembers();

            //Load Data Grids
            foreach(Member member in Members)
            {
                string MemberName = member.FirstName + ' ' + member.LastName;
                //Load Upcoming Birthdays
                if (member.BirthDate != DateTime.MinValue)
                {
                    DateTime NextBirthDay = new DateTime(DateTime.Now.Year,
                        member.BirthDate.Month, member.BirthDate.Day);
                    if (NextBirthDay < DateTime.Now)
                    {
                        NextBirthDay = NextBirthDay.AddYears(1);
                    }

                    if ((NextBirthDay - DateTime.Now).TotalDays <= 31)
                    {
                        UpcomingBirthdays.Rows.Add(member.Id, MemberName,
                            NextBirthDay.ToShortDateString());
                    }
                }

                //Load Upcoming Contact Dates
                if((member.NextContactDate - DateTime.Now).TotalDays <= 31)
                {
                    dataGridUpcomingContacts.Rows.Add(member.Id, MemberName,
                        member.LastContactDate == DateTime.MinValue ? "N/A" : 
                        member.LastContactDate.ToShortDateString()
                        , member.NextContactDate == DateTime.MinValue ? "Not Set" : member.NextContactDate.ToShortDateString());
                }

                //Load Upcoming anniversarys
                if (member.MembershipStart != DateTime.MinValue && 
                    member.MembershipEnd == DateTime.MinValue)
                {
                    DateTime NextAnniversaryDate = new DateTime(DateTime.Now.Year,
                        member.MembershipStart.Month, member.MembershipEnd.Day);
                    if (NextAnniversaryDate < DateTime.Now)
                    {
                        NextAnniversaryDate = NextAnniversaryDate.AddYears(1);
                    }

                    if ((NextAnniversaryDate - DateTime.Now).TotalDays <= 31)
                    {
                        dataGridUpcomingAnniversaries.Rows.Add(member.Id, MemberName,
                            NextAnniversaryDate.ToShortDateString());
                    }
                }
            }
        }

        private void SearchResults_Paint(object sender, PaintEventArgs e)
        {

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

        private void LoadMemberView(DataGridView Grid)
        {
            if (Grid.SelectedCells.Count == 1 || Grid.SelectedRows.Count == 1)
            {
                DataManager DM = new DataManager();
                
                int MemberId;
                if (Grid.SelectedCells.Count == 1)
                {
                    MemberId  = (int)Grid.SelectedCells[0].OwningRow.Cells[0].Value;
                }
                else
                {
                  MemberId = (int)Grid.SelectedRows[0].Cells[0].Value;
                }
                Member member = Members.Find(x => x.Id == MemberId);
                homeScreen.LoadPanel(new MemberView(homeScreen, member, false, Members));
                homeScreen.RemovePanel(this);
            }
        }

        private void dataGridUpcomingContacts_DoubleClick(object sender, EventArgs e)
        {
            LoadMemberView(dataGridUpcomingContacts);
        }

        private void UpcomingBirthdays_DoubleClick(object sender, EventArgs e)
        {
            LoadMemberView(UpcomingBirthdays);
        }

        private void dataGridUpcomingAnniversaries_DoubleClick(object sender, EventArgs e)
        {
            LoadMemberView(dataGridUpcomingAnniversaries);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridUpcomingContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
