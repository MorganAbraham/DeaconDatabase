using Deacon_Database_Manager.DbTools;
using Deacon_Database_Manager.MemberData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Deacon_Database_Manager.GUI
{
    public partial class SearchForm : Form
    {

        private HomeScreen homeScreen;
        private List<Member> SearchResults;
        private UserFilter FilterSettings = new UserFilter();
        private bool FilterVisible = false;

        private int DrawerMaxWidth;
        private int DrawerMinWidth;
        private int ResultsPanelMinWidth;
        private int ResultsPanelMaxWidth;
        private int ResultsPanelMinLeft;
        private int ShrinkAmount;

        public SearchForm(HomeScreen homeScreen)
        {
            InitializeComponent();
            this.homeScreen = homeScreen;
        }

        private void radioPictureView_CheckedChanged(object sender, EventArgs e)
        {
            LoadPictures();
        }

        private void radioListView_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnSetFilter_Click(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ckNameFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelMemberName.Enabled = ckNameFilter.Checked;
            if(!panelMemberName.Enabled)
            {
                txtMemberName.Text = "";
            }
        }

        private void ckDeaconFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelDeacon.Enabled = ckDeaconFilter.Checked;
            if(!panelDeacon.Enabled)
            {
                cmboDeacon.SelectedIndex = -1;
            }
        }

        private void ckBirthdateFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelBirthMonth.Enabled = ckBirthdateFilter.Checked;
            if(!panelBirthMonth.Enabled)
            {
                cmboBirthMonth.SelectedIndex = -1;
            }
        }

        private void ckAddressFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelAddress.Enabled = ckAddressFilter.Checked;
            if(!panelAddress.Enabled)
            {
                txtAddress.Text = "";
                trackDistance.Value = 0;
            }
        }

        private void ckAgeFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelAge.Enabled = ckAgeFilter.Checked;
            if(!panelAge.Enabled)
            {
                txtMinAge.Value = 0;
                txtMaxAge.Value = 150;
            }
        }

        private void ckMembershipFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelMembershipFilter.Enabled = ckMembershipFilter.Checked;
            if(!panelMembershipFilter.Enabled)
            {
                trackMembership.Value = 0;
            }
        }

        private void txtMemberName_TextChanged(object sender, EventArgs e)
        {
            FilterSettings.MemberName = txtMemberName.Text;
        }

        private void cmboDeacon_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSettings.DeaconName = cmboDeacon.Text;
        }

        private void cmboBirthMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSettings.BirthMonth = cmboBirthMonth.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            FilterSettings.MemberAddress = txtAddress.Text;
        }

        private void trackDistance_Scroll(object sender, EventArgs e)
        {
            FilterSettings.MilesFromAddress = trackDistance.Value;
        }

        private void txtMinAge_ValueChanged(object sender, EventArgs e)
        {
            FilterSettings.MinimumAge = Convert.ToInt32(txtMinAge.Value);
            if(txtMinAge.Value > txtMaxAge.Value)
            {
                txtMaxAge.Value = txtMinAge.Value;
            }
        }

        private void txtMaxAge_ValueChanged(object sender, EventArgs e)
        {
            if(txtMinAge.Value > txtMaxAge.Value)
            {
                txtMaxAge.Value = txtMinAge.Value;
            }
            FilterSettings.MaximumAge = Convert.ToInt32(txtMaxAge.Value);
        }

        private void trackMembership_Scroll(object sender, EventArgs e)
        {
            FilterSettings.MinimumMembership = trackMembership.Value;
        }

        private void LoadResults()
        {
            //foreach(Control Ctrl in panelResults.Controls)
            //{
            //    panelResults.Controls.Remove(Ctrl);
            //}
            
            if(radioListView.Checked)
            {
                LoadTable();
            }
            else if(radioPictureView.Checked)
            {
                LoadPictures();
            }
        }

        private void LoadTable()
        {
            panelResults.Controls.Clear();
            DataGridView Grid = new DataGridView();
            Grid.Visible = true;
            Grid.Size = panelResults.Size;
            Grid.ColumnCount = 5;
            Grid.ReadOnly = true;

            Grid.Columns[0].HeaderText = "Member Name";
            Grid.Columns[1].HeaderText = "Deacon Name";
            Grid.Columns[2].HeaderText = "Birth Date";
            Grid.Columns[3].HeaderText = "Home Address";
            Grid.Columns[4].HeaderText = "Anniversary Date";

            int ColumnWidth = Grid.Width / Grid.ColumnCount;
            for(int i = 0; i < Grid.ColumnCount; i++)
            {
                Grid.Columns[i].Width = ColumnWidth;
            }

            
            foreach(Member SearchResult in SearchResults)
            {
                string BirthDate = SearchResult.BirthDate == 
                    DateTime.MinValue ? "" : SearchResult.BirthDate.ToShortDateString();
                string HomeAddress = Regex.Replace(SearchResult.Address.Street + ' ' + 
                    SearchResult.Address.Street2 +
                    ", " + SearchResult.Address.City + ", " + 
                    SearchResult.Address.State + ' ' + SearchResult.Address.Zip, "[ ]{2,}", " ");
                string AnniversaryDate = SearchResult.MembershipStart ==
                    DateTime.MinValue ? "" : SearchResult.MembershipStart.ToShortDateString();
                Grid.Rows.Add(Regex.Replace(SearchResult.FirstName + ' ' +
                    SearchResult.MiddleName + ' ' + SearchResult.LastName, "[ ]{2,}", " "),
                    SearchResult.DeaconName, BirthDate, HomeAddress, AnniversaryDate);
            }
            panelResults.Controls.Add(Grid);
        }

        private void LoadPictures()
        {
            panelResults.Controls.Clear();
            
            int ColumnSpacing = 10;
            int RowSpacing = 10;
            int LabelHeight = 10;

            int PicWidth = 102;
            int PicHeight = 127;

            int MaxColumns = panelResults.Width / (PicWidth + ColumnSpacing);
            int x = 0;
            int y = 0;

            int ColumnCount = 0;
            foreach(Member SearchResult in SearchResults)
            {
                PictureBox PicBox = new PictureBox();
                PicBox.Visible = true;
                PicBox.Height = PicHeight;
                PicBox.Width = PicWidth;

                PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                ResourceManager Rm = Properties.Resources.ResourceManager;
                PicBox.Image = (Image)Rm.GetObject(SearchResult.PhotoPath);
                PicBox.BorderStyle = BorderStyle.FixedSingle;

                Label MemberLabel = new Label();
                MemberLabel.Visible = true;
                MemberLabel.Text = Regex.Replace(SearchResult.FirstName + 
                    ' ' +  SearchResult.LastName, "[ ], {2,}", " ");
                MemberLabel.Width = PicBox.Width;
                MemberLabel.Height = LabelHeight;
                MemberLabel.AutoSize = true;

                PicBox.Location = new Point(x, y);
                MemberLabel.Location = new Point(x, y + PicBox.Height);

                panelResults.Controls.Add(PicBox);
                panelResults.Controls.Add(MemberLabel);
                x += PicBox.Width + ColumnSpacing;
                ColumnCount++;
                if(ColumnCount == MaxColumns)
                {
                    x = 0;
                    y += PicBox.Height + RowSpacing + LabelHeight;
                }
            } 
        }

        private void SetFilter()
        {
            DataManager DM = new DataManager();
            SearchResults = DM.GetFilterResults(FilterSettings);
            SearchResults.Sort();
            LoadResults();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            DrawerMaxWidth = 281;
            DrawerMinWidth = 0;
            ResultsPanelMinWidth = 536;
            ResultsPanelMaxWidth = DrawerMaxWidth + ResultsPanelMinWidth;
            ShrinkAmount = DrawerMaxWidth;
            ResultsPanelMinLeft = 299;

            panelFilter.Width = DrawerMinWidth;
            panelResults.Width = ResultsPanelMaxWidth;
            panelResults.Left = panelFilter.Left;

            SetFilter();
        }

        private void SlideDrawer()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressedChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            if(!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }   
        }

        private void bw_ProgressedChanged(object sender, ProgressChangedEventArgs e)
        {
            int MoveAmount = ResultsPanelMinLeft - panelFilter.Left;
            if (!FilterVisible)
            {
                //Show Filter Panel
                panelFilter.Width = Convert.ToInt32(DrawerMaxWidth * 
                    ((double)e.ProgressPercentage / 100));
                panelResults.Width = ResultsPanelMaxWidth - Convert.ToInt32(ShrinkAmount * 
                    ((double)e.ProgressPercentage / 100));
                panelResults.Left = panelFilter.Left +
                    Convert.ToInt32(MoveAmount * ((double)e.ProgressPercentage / 100));
            }
            else
            {
                //Hide Filter Panel
                panelFilter.Width = DrawerMaxWidth - Convert.ToInt32((DrawerMaxWidth - DrawerMinWidth) *
                    ((double)e.ProgressPercentage / 100));
                panelResults.Width = ResultsPanelMinWidth + 
                    Convert.ToInt32(ShrinkAmount * ((double)e.ProgressPercentage / 100));
                panelResults.Left = ResultsPanelMinLeft - 
                    Convert.ToInt32(MoveAmount * ((double)e.ProgressPercentage / 100));
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            for (int i = 1; i <= 100; i++)
            {
                if(worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //System.Threading.Thread.Sleep(5);
                    worker.ReportProgress(i);
                }
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if((e.Cancelled))
            {
                //TODO - Report Canceled
            }
            else if(!(e.Error == null))
            {
                //TODO - Report Error
            }
            else
            {
                FilterVisible = !FilterVisible;
                if(FilterVisible)
                {
                    btnSlideDrawer.Text = "Hide Filter";
                }
                else
                {
                    btnSlideDrawer.Text = "Show Filter";
                }
                LoadResults();
            }
        }

        private void btnSlideDrawer_Click(object sender, EventArgs e)
        {
            SlideDrawer();
        }
    }
}
