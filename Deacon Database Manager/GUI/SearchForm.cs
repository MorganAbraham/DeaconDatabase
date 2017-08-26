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
        private bool FilterMenuVisible = false;

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

        private void SearchForm_Load(object sender, EventArgs e)
        {
            DrawerMaxWidth = 281;
            DrawerMinWidth = 0;
            ResultsPanelMinWidth = 536;
            ResultsPanelMaxWidth = DrawerMaxWidth + ResultsPanelMinWidth;
            ShrinkAmount = DrawerMaxWidth;
            ResultsPanelMinLeft = 299;

            panelFilterDisplay.Width = 639;
            panelFilterDisplay.Left = panelFilter.Left;

            panelFilter.Width = DrawerMinWidth;
            panelResults.Width = ResultsPanelMaxWidth;
            panelResults.Left = panelFilter.Left;

            SetFilter();
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
            Grid.MultiSelect = false;
            Grid.DoubleClick += new EventHandler(Grid_DoubleClick);
            Grid.Visible = true;
            Grid.Size = panelResults.Size;
            Grid.ColumnCount = 6;
            Grid.ReadOnly = true;

            Grid.Columns[1].HeaderText = "Member Name";
            Grid.Columns[2].HeaderText = "Deacon Name";
            Grid.Columns[3].HeaderText = "Birth Date";
            Grid.Columns[4].HeaderText = "Home Address";
            Grid.Columns[5].HeaderText = "Anniversary Date";

            int ColumnWidth = Grid.Width / Grid.ColumnCount;
            for(int i = 0; i < Grid.ColumnCount; i++)
            {
                Grid.Columns[i].Width = ColumnWidth;
            }

            Grid.Columns[0].Visible = false;
            Grid.Columns[0].Width = 0;

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
                Grid.Rows.Add(SearchResult.Id, Regex.Replace(SearchResult.FirstName + ' ' +
                    SearchResult.MiddleName + ' ' + SearchResult.LastName, "[ ]{2,}", " "),
                    SearchResult.DeaconName, BirthDate, HomeAddress, AnniversaryDate);
            }
            panelResults.Controls.Add(Grid);
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            DataGridView Grid = sender as DataGridView;
            if(Grid.SelectedCells.Count == 1 || Grid.SelectedRows.Count == 1)
            {
                DataManager DM = new DataManager();
                Member Result;
                if (Grid.SelectedCells.Count == 1)
                {
                    Result = DM.GetMember((int)Grid.SelectedCells[0].OwningRow.Cells[0].Value);
                }
                else
                {
                    Result = DM.GetMember((int)Grid.SelectedRows[0].Cells[0].Value);
                }
                homeScreen.LoadPanel(new MemberView(homeScreen, Result, false));
                homeScreen.RemovePanel(this);
            }
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
                PicBox.Image = SearchResult.ProfilePicture;
                PicBox.BorderStyle = BorderStyle.FixedSingle;

                PicBox.Name = SearchResult.Id.ToString();
                PicBox.Click += new EventHandler(PicBox_OnClick);

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
            //LoadFilterDisplay();
        }


        private void SlideDrawer()
        {
            //BackgroundWorker bw = new BackgroundWorker();
            //bw.WorkerReportsProgress = true;
            //bw.WorkerReportsProgress = true;

            //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressedChanged);
            //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            //if(!bw.IsBusy)
            //{
            //    bw.RunWorkerAsync();
            //} 
            
            if(FilterMenuVisible)
            {
                //Hide
                panelFilter.Visible = false;
                panelResults.Width = ResultsPanelMaxWidth;
                panelResults.Left = panelFilter.Left;
                btnSlideDrawer.Text = "Show Filter Menu";
                panelFilterDisplay.Visible = true;
                LoadFilterDisplay();
            } 
            else
            {
                //Show
                panelFilter.Visible = true;
                panelFilter.Width = DrawerMaxWidth;
                panelResults.Width = ResultsPanelMinWidth;
                panelResults.Left = ResultsPanelMinLeft;
                btnSlideDrawer.Text = "Hide Filter  Menu";
                panelFilterDisplay.Visible = false;

            }
            FilterMenuVisible = !FilterMenuVisible;
            LoadResults();
        }

        private void bw_ProgressedChanged(object sender, ProgressChangedEventArgs e)
        {
            int MoveAmount = ResultsPanelMinLeft - panelFilter.Left;
            if (!FilterMenuVisible)
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
                FilterMenuVisible = !FilterMenuVisible;
                if(FilterMenuVisible)
                {
                    btnSlideDrawer.Text = "Hide Filter  Menu";
                    panelFilterDisplay.Visible = false;
                }
                else
                {
                    btnSlideDrawer.Text = "Show Filter Menu";
                    panelFilterDisplay.Visible = true;
                }
                LoadResults();
            }
        }

        private void btnSlideDrawer_Click(object sender, EventArgs e)
        {
            SlideDrawer();
        }

        private void FilterClear_Click(object sender, EventArgs e)
        {
            Button ClearButton = sender as Button;
            switch(ClearButton.Text)
            {
                case "Member Name":
                    ckNameFilter.Checked = false;
                    break;
                case "Deacon":
                    ckDeaconFilter.Checked = false;
                    break;
                case "Birth Month":
                    ckBirthdateFilter.Checked = false;
                    break;
                case "Address":
                    ckAddressFilter.Checked = false;
                    break;
                case "Age":
                    ckAgeFilter.Checked = false;
                    break;
                case "Membership Length":
                    ckMembershipFilter.Checked = false;
                    break;
                default:
                    return;
            }

            SetFilter();
            LoadFilterDisplay();
        }

        private void LoadFilterDisplay()
        {
            panelFilterDisplay.Controls.Clear();
            if(!string.IsNullOrEmpty(FilterSettings.MemberName))
            {
                AddFilterDisplay("Member Name");
            }
            if(!string.IsNullOrEmpty(FilterSettings.DeaconName))
            {
                AddFilterDisplay("Deacon");
            }
            if(!string.IsNullOrEmpty(FilterSettings.BirthMonth))
            {
                AddFilterDisplay("Birth Month");
            }
            if(!string.IsNullOrEmpty(FilterSettings.MemberAddress))
            {
                AddFilterDisplay("Address");
            }
            if(!(FilterSettings.MinimumAge == 0 && FilterSettings.MaximumAge == 150))
            {
                AddFilterDisplay("Age");
            }
            if(FilterSettings.MinimumMembership > 0)
            {
                AddFilterDisplay("Membership Length");
            }

            panelFilterDisplay.Visible = panelFilterDisplay.Controls.Count > 0;
            if(panelFilterDisplay.Visible)
            {
                Label QuickFilterLabel = new Label();
                QuickFilterLabel.Text = "Current Filters (Click To Remove)";
                QuickFilterLabel.AutoSize = true;
                QuickFilterLabel.Location = new Point(0, 0);
                QuickFilterLabel.Visible = true;
                QuickFilterLabel.Font = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Underline);
                panelFilterDisplay.Controls.Add(QuickFilterLabel);

            }
        }

        private void AddFilterDisplay(string FilterName)
        {
            int x;
            int y;

            if (panelFilterDisplay.Controls.Count > 0)
            {
                Control LastControl = panelFilterDisplay.Controls[panelFilterDisplay.Controls.Count - 1];
                x = LastControl.Location.X + LastControl.Width;
                y = LastControl.Location.Y;
            }
            else
            {
                x = 0;
                y = 20;
            }

            Button FilterClear = new Button();

            FilterClear.AutoSize = true;
            FilterClear.Location = new Point(x, y);
            FilterClear.Visible = true;
            FilterClear.Text = FilterName ;
            FilterClear.BackColor = Color.Green;
            FilterClear.Click += new EventHandler(FilterClear_Click);

            panelFilterDisplay.Controls.Add(FilterClear);

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
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
    }
}
