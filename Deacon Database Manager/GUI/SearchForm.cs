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
        private List<Member> AllMembers;
        private List<Member> SearchResults;
        private UserFilter FilterSettings = new UserFilter();
        private bool FilterMenuVisible = false;

        private int DrawerMaxWidth;
        private int DrawerMinWidth;
        private int ResultsPanelMinWidth;
        private int ResultsPanelMaxWidth;
        private int ResultsPanelMinLeft;
        private int ShrinkAmount;

        private PictureBox CurrentPicBox;

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
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressedChanged);
            
            if(!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
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
            if (cmboDeacon.SelectedIndex != -1 && !string.IsNullOrEmpty(cmboDeacon.ValueMember))
            {
                FilterSettings.DeaconId = (int)cmboDeacon.SelectedValue;
            }
            else
            {
                FilterSettings.DeaconId = -1;
            }
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
            if(radioListView.Checked)
            {
                LoadTable();
            }
            if(radioPictureView.Checked)
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
            //Grid.Size = panelResults.Size;
            Grid.Dock = DockStyle.Fill;
            Grid.ColumnCount = 6;
            Grid.ReadOnly = true;
            Grid.AllowUserToDeleteRows = false;
            Grid.AllowUserToAddRows = false;

            Grid.Columns[1].HeaderText = "Member Name";
            Grid.Columns[2].HeaderText = "Deacon Name";
            Grid.Columns[3].HeaderText = "Birth Date";
            Grid.Columns[4].HeaderText = "Home Address";
            Grid.Columns[5].HeaderText = "Anniversary Date";

            //int ColumnWidth = panelResults.Width  / Grid.ColumnCount;
            //for(int i = 0; i < Grid.ColumnCount; i++)
            //{
            //    Grid.Columns[i].Width = ColumnWidth;
            //}
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
                string DeaconName = Regex.Replace(SearchResult.DeaconInfo.FirstName + ' ' + SearchResult.DeaconInfo.LastName, "[ ]{2,}"," ");
                Grid.Rows.Add(SearchResult.Id, Regex.Replace(SearchResult.FirstName + ' ' +
                    SearchResult.MiddleName + ' ' + SearchResult.LastName, "[ ]{2,}", " "),
                    DeaconName, BirthDate, HomeAddress, AnniversaryDate);
            }
            this.Invoke(new MethodInvoker(delegate { panelResults.Controls.Add(Grid); }));
            
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
                homeScreen.LoadPanel(new MemberView(homeScreen, Result, false, AllMembers));
                homeScreen.RemovePanel(this);
            }
        }

        private void LoadPictures()
        {

            this.Invoke(new MethodInvoker(delegate
            {

                panelResults.Controls.Clear();

                int ColumnSpacing = 10;
                int RowSpacing = 10;
                int LabelHeight = 10;

                int PicWidth = 102;
                int PicHeight = 127;

                int MaxColumns = panelResults.Width / (PicWidth + ColumnSpacing);
                int x = 10;
                int y = 0;

                int ColumnCount = 0;
                int LoadCount = 0;
                int MaxLoadCount;
                if(!int.TryParse(cmboMaxResults.Text, out MaxLoadCount))
                {
                    MaxLoadCount = 50;
                }
                foreach (Member SearchResult in SearchResults)
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
                        ' ' + SearchResult.LastName, "[ ], {2,}", " ");
                    MemberLabel.Width = PicBox.Width;
                    MemberLabel.Height = LabelHeight;
                    MemberLabel.AutoSize = true;

                    PicBox.Location = new Point(x, y);
                    MemberLabel.Location = new Point(x, y + PicBox.Height);

                    panelResults.Controls.Add(PicBox);
                    panelResults.Controls.Add(MemberLabel);
                    x += PicBox.Width + ColumnSpacing;
                    ColumnCount++;
                    if (ColumnCount == MaxColumns)
                    {
                        x = 10;
                        y += PicBox.Height + RowSpacing + LabelHeight;
                        ColumnCount = 0;
                    }
                    LoadCount++;
                    if (LoadCount >= MaxLoadCount)
                    {
                        break;
                    }
                }
            }));
        }

        private void SetFilter()
        {
            DataManager DM = new DataManager();
            SearchResults = DM.GetFilterResults(FilterSettings, AllMembers);
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
           
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if(worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                DataManager DM = new DataManager();
                List<Deacon> Deacons = DM.GetAllDeacons();
                Deacons.Sort();
                this.Invoke(new MethodInvoker(delegate
                {
                    cmboDeacon.DataSource = Deacons.Select(x => new
                    {
                        Text = (x.FirstName + ' ' + x.LastName).Trim(),
                        Value = x.Id
                    }).ToList();
                    cmboDeacon.DisplayMember = "Text";
                    cmboDeacon.ValueMember = "Value";
                    cmboDeacon.SelectedIndex = -1;
                }));

                AllMembers = DM.GetAllMembers();
                AllMembers.Sort();

                this.Invoke(new MethodInvoker(delegate 
                { 
                    comboRelatives.DataSource = AllMembers.Select(x => new
                    {
                        Text = Regex.Replace(x.FirstName + ' ' + x.LastName, "[ ]{2,}", " ").Trim(),
                        Value = x.Id
                    }).ToList();
                    comboRelatives.DisplayMember = "Text";
                    comboRelatives.ValueMember = "Value";
                    comboRelatives.SelectedIndex = -1;
                    cmboMaxResults.SelectedIndex = 4;
                }));
           
                SetFilter();
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
            if(FilterSettings.DeaconId != -1)
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

        private void ckRegionFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelRegion.Enabled = ckRegionFilter.Checked;
            if (!panelRegion.Enabled)
            {
                comboRegion.SelectedIndex = -1;
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ckRelatives_CheckedChanged(object sender, EventArgs e)
        {
            panelRelatives.Enabled = ckRelatives.Checked;
            if(!ckRelatives.Checked)
            {
                comboRelatives.SelectedIndex = -1;
            }
        }

        private void cmboMaxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilter();
        }
    }
}
