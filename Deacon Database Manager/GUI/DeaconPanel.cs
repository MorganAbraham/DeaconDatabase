using Deacon_Database_Manager.DbTools;
using Deacon_Database_Manager.MemberData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Deacon_Database_Manager.GUI
{
    public partial class DeaconPanel : Form
    {
        private HomeScreen homeScreen;
        public DeaconPanel(HomeScreen homeScreen)
        {
            InitializeComponent();
            this.homeScreen = homeScreen;
        }

        private void DeaconPanel_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            DataManager DM = new DataManager();
            List<Deacon> Deacons = DM.GetAllDeacons();
            foreach(Deacon deacon in  Deacons)
            {
                deaconGrid.Rows.Add(deacon.Id, deacon.FirstName, deacon.LastName, 
                    deacon.Region, deacon.MemberCount);
            }
        }

        private void deaconGrid_SelectionChanged(object sender, EventArgs e)
        {
            if(deaconGrid.SelectedRows.Count == 1 || deaconGrid.SelectedCells.Count == 1)
            {
                DataManager DM = new DataManager();
                UserFilter FilterSettings = new UserFilter();
                object IdValue;
                if (deaconGrid.SelectedRows.Count == 1)
                {
                    IdValue = deaconGrid.SelectedRows[0].Cells["colId"].Value;
                }
                else
                {
                    IdValue = deaconGrid.SelectedCells[0].OwningRow.Cells["colId"].Value;
                }
                FilterSettings.DeaconId = IdValue == null ? int.MaxValue : (int)IdValue;
                List<Member> Members = DM.GetFilterResults(FilterSettings);
                LoadPictures(Members);
            }
        }

        private void LoadPictures(List<Member> SearchResults)
        {
            panelMembers.Controls.Clear();

            int ColumnSpacing = 20;
            int RowSpacing = 10;
            int LabelHeight = 10;

            int PicWidth = 102;
            int PicHeight = 127;

            int MaxColumns = panelMembers.Width / (PicWidth + ColumnSpacing);
            int x = 10;
            int y = 10;

            int ColumnCount = 0;
            foreach (Member SearchResult in SearchResults)
            {
                PictureBox PicBox = new PictureBox()
                {
                    Visible = true,
                    Height = PicHeight,
                    Width = PicWidth,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = SearchResult.ProfilePicture,
                    BorderStyle = BorderStyle.FixedSingle
                };


                PicBox.Name = SearchResult.Id.ToString();
                PicBox.Click += new EventHandler(PicBox_OnClick);

                Label MemberLabel = new Label()
                {
                    Visible = true,
                    Text = Regex.Replace(SearchResult.FirstName +
                        ' ' + SearchResult.LastName, "[ ], {2,}", " "),
                    Width = PicBox.Width,
                    Height = LabelHeight,
                    AutoSize = true
                };

                PicBox.Location = new Point(x, y);
                MemberLabel.Location = new Point(x, y + PicBox.Height);

                panelMembers.Controls.Add(PicBox);
                panelMembers.Controls.Add(MemberLabel);
                x += PicBox.Width + ColumnSpacing;
                ColumnCount++;
                if (ColumnCount == MaxColumns)
                {
                    x = 10;
                    y += PicBox.Height + RowSpacing + LabelHeight;
                    ColumnCount = 0;
                }
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

        private void deaconGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.homeScreen.LoadPanel(new HomePanel(this.homeScreen));
            this.homeScreen.RemovePanel(this);
        }
    }
}
