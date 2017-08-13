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

        public SearchForm(HomeScreen homeScreen)
        {
            InitializeComponent();
            this.homeScreen = homeScreen;
        }

        private void ckPicView_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
        }

        private void ChangeView()
        {
            if(radioPictureView.Checked)
            {
                //TODO
            }
            else if(radioListView.Checked)
            {
                //TODO
            }
        }

        private void radioPictureView_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
        }

        private void radioListView_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
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
            panelResults.Controls.Clear();
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
            //TODO
        }

        private void LoadPictures()
        {
            //TODO
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
            SetFilter();
        }
    }
}
