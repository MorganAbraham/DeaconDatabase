using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Deacon_Database_Manager.MemberData;
using System.Resources;
using Deacon_Database_Manager.DbTools;
using Deacon_Database_Manager.Geographical;

namespace Deacon_Database_Manager.GUI
{
    public partial class MemberView : Form
    {
        private Member ChurchMember;
        private HomeScreen homeScreen;
        private DataManager DM = new DataManager();

        public MemberView(HomeScreen homeScreen, Member ChurchMember)
        {
            InitializeComponent();
            this.ChurchMember = ChurchMember;
            this.homeScreen = homeScreen;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MemberView_Load(object sender, EventArgs e)
        { 
            DisplayData();
        }

        private void DisplayData()
        {
            txtFirstName.Text = ChurchMember.FirstName;
            txtMiddleName.Text = ChurchMember.MiddleName;
            txtLastName.Text = ChurchMember.LastName;
            txtSuffix.Text = ChurchMember.Suffix;

            if(ChurchMember.BirthDate != null)
            {
                txtBirthDate.Text = ChurchMember.BirthDate.ToString("MM/dd/yyyy");
            }

            comboGender.Text = ChurchMember.Gender;
            comboEthnicity.Text = ChurchMember.Ethnicity;

            txtAddress1.Text = ChurchMember.Address.Street;
            txtAddress2.Text = ChurchMember.Address.Street2;
            txtCity.Text = ChurchMember.Address.City;
            comboState.Text = StateInformation.GetStateName(ChurchMember.Address.State);
            txtZip.Text = ChurchMember.Address.Zip;

            txtHomeEmail.Text = ChurchMember.HomeEmail;
            txtHomePhone.Text = ChurchMember.HomePhone;
            txtEmergencyContact.Text = ChurchMember.EmergencyContact;
            txtEmergencyPhone.Text = ChurchMember.EmergencyNumber;

            ResourceManager Rm = Properties.Resources.ResourceManager;
            picboxProfile.Image = (Image)Rm.GetObject(ChurchMember.PhotoPath);
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.FirstName = txtFirstName.Text;
        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.MiddleName = txtMiddleName.Text;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.LastName = txtLastName.Text;
        }

        private void txtSuffix_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.Suffix = txtSuffix.Text;
        }

        private void txtBirthDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChurchMember.Ethnicity = comboEthnicity.Text;
        }

        private void comboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChurchMember.Gender = comboGender.Text;
        }

        private void txtAddress1_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.Address.Street = txtAddress1.Text;
        }

        private void txtAddress2_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.Address.Street2 = txtAddress2.Text;
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.Address.City = txtCity.Text;
        }

        private void comboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChurchMember.Address.State = StateInformation.GetStateAbbreviation(comboState.Text);
        }

        private void txtZip_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.Address.Zip = txtZip.Text;
        }

        private void txtHomeEmail_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.HomeEmail = txtHomeEmail.Text;
        }

        private void txtHomePhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ChurchMember.HomePhone = txtHomePhone.Text;
        }

        private void txtEmergencyContact_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.EmergencyContact = txtEmergencyContact.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(DM.TryUpdateMember(ChurchMember))
            {
                MessageBox.Show("Member Data Saved");
            }
            else
            {
                MessageBox.Show("There was an error while saving your member data. Your changes have not been saved", 
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.homeScreen.LoadPanel(new HomePanel(this.homeScreen));
            this.homeScreen.RemovePanel(this);
        }

        private void txtBirthDate_TextChanged(object sender, EventArgs e)
        {
            DateTime dt;
            if(DateTime.TryParse(txtBirthDate.Text, out dt))
            {
                ChurchMember.BirthDate = dt;
            }

        }


        private void txtEmergencyPhone_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.EmergencyNumber = txtEmergencyPhone.Text;
        }

        private void txtHomePhone_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.HomePhone = txtHomePhone.Text;
        }
    }
}
