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
using DeaconBaseLib.Geographical;
using System.Text.RegularExpressions;

namespace Deacon_Database_Manager.GUI
{
    public partial class MemberView : Form
    {
        private Member ChurchMember;
        private HomeScreen homeScreen;
        private DataManager DM = new DataManager();
        private bool CreateNewMember;
        private bool MemberCreated = false;
        Dictionary<Member, string> Relatives;
        private List<Member> AllMembers;

        public MemberView(HomeScreen homeScreen, Member ChurchMember, 
            bool CreateNewMember, List<Member> AllMembers = null)
        {
            InitializeComponent();
            this.ChurchMember = ChurchMember;
            this.homeScreen = homeScreen;
            this.CreateNewMember = CreateNewMember;
            RelationshipCalculator RelCalc = new RelationshipCalculator();
            Relatives = RelCalc.GetAllRelationships(ChurchMember);
            this.AllMembers = AllMembers;
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

            if (ChurchMember.BirthDate != null)
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

            picboxProfile.Image = ChurchMember.ProfilePicture;

            foreach (KeyValuePair<Member, string> Relation in Relatives)
            {
                dataGridRelatives.Rows.Add(Relation.Key.Id, Regex.Replace(Relation.Key.FirstName + ' ' +
                    Relation.Key.LastName, "[ ]{2,}", " "), Relation.Value, "Stored");
            }

            dtLastContactDate.Value = ChurchMember.LastContactDate == DateTime.MinValue ? 
                dtLastContactDate.MinDate : ChurchMember.LastContactDate;
            dtNextContactDate.Value = ChurchMember.NextContactDate == DateTime.MinValue ?
                dtNextContactDate.MinDate : ChurchMember.NextContactDate;

            txtComments.Text = ChurchMember.Comments;

            if (AllMembers == null)
            {
                AllMembers = DM.GetAllMembers();
            }
            AllMembers.Sort();

            comboMembers.DataSource = AllMembers.Select(x => new
            {
                Text = Regex.Replace(x.FirstName + ' ' + x.LastName, "[ ]{2,}", " ").Trim(),
                Value = x.Id
            }).ToList();
            comboMembers.DisplayMember = "Text";
            comboMembers.ValueMember = "Value";
            comboMembers.SelectedIndex = -1;
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
            if(TrySaveMember())
            {
                MessageBox.Show("Member Saved", "Sucessful Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Member data could not be saved", "Saved Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (TrySaveMember())
            {
                MessageBox.Show("Member Data Saved");
                this.homeScreen.LoadPanel(new HomePanel(this.homeScreen));
                this.homeScreen.RemovePanel(this);
            }
            else
            {
                MessageBox.Show("There was an error while saving your member data. Your changes have not been saved",
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TrySaveMember()
        {
            string[,] RelativeUpdates = new string[dataGridRelatives.Rows.Count - 1, 3];
            for (int i = 0; i < RelativeUpdates.GetLength(0); i++)
            {
                RelativeUpdates[i, 0] = this.dataGridRelatives.Rows[i].Cells[0].Value.ToString();
                RelativeUpdates[i, 1] = this.dataGridRelatives.Rows[i].Cells[2].Value.ToString();
                RelativeUpdates[i, 2] = this.dataGridRelatives.Rows[i].Cells[3].Value.ToString();
            }
            if (CreateNewMember && !MemberCreated)
            {
                return DM.TryCreateMember(ChurchMember, RelativeUpdates);
            }
            else
            {
                return DM.TryUpdateMember(ChurchMember, RelativeUpdates);
            }
        }

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "Image Files (*.bmp,*.dib,*.jpg,*.jpeg,*.jpe,*.jfif,*,gif, *.tif," +
                "*.tiff,*.png,*.ico) | *.bmp;*.dib;*.jpg;*.jpeg;*.jpe;*.jfif;*,gif; *.tif;" +
                "*.tiff;*.png;*.ico";
            fDialog.Multiselect = false;
            if(fDialog.ShowDialog() == DialogResult.OK)
            {
                picboxProfile.Image = Image.FromFile(fDialog.FileName);
                ChurchMember.ProfilePicture = picboxProfile.Image;
            }
        }

        private void btnDeletePic_Click(object sender, EventArgs e)
        {
            Image NoImage = Properties.Resources.NoPhoto;
            picboxProfile.Image = NoImage;
            ChurchMember.ProfilePicture = NoImage;
        }

        private void btnAddRelative_Click(object sender, EventArgs e)
        {
            if(comboMembers.SelectedIndex != -1 && comboRelationshipTypes.SelectedIndex != -1)
            {
                object ID = comboMembers.SelectedValue;
                foreach(DataGridViewRow row in dataGridRelatives.Rows)
                {
                    if(row.Cells[0].Value != null && 
                        Convert.ToInt32(row.Cells[0].Value) == Convert.ToInt32(ID) && 
                        row.Cells[3].Value.ToString() != "Pending Deletion")
                    {
                        return;
                    }
                }
                dataGridRelatives.Rows.Add(ID, comboMembers.Text, comboRelationshipTypes.SelectedItem, 
                    "Pending Addition");
            }
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            ChurchMember.Comments = txtComments.Text;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dataGridRelatives.SelectedCells.Count == 1 ||  dataGridRelatives.SelectedRows.Count == 1)
            {
                DataGridViewRow Row;
                if(dataGridRelatives.SelectedCells.Count == 1)
                {
                    Row = dataGridRelatives.SelectedCells[0].OwningRow;
                }
                else
                {
                    Row = dataGridRelatives.SelectedRows[0];
                }
                if (Row.Cells[3].Value.ToString() == "Stored")
                {
                    Row.Cells[3].Value = "Pending Deletion";
                    Row.Visible = false;
                }
                else
                {
                    dataGridRelatives.Rows.Remove(Row);
                }
            }
        }

        private void dtLastContactDate_ValueChanged(object sender, EventArgs e)
        {
            ChurchMember.LastContactDate = dtLastContactDate.Value;
        }

        private void dtNextContactDate_ValueChanged(object sender, EventArgs e)
        {
            ChurchMember.NextContactDate = dtNextContactDate.Value;
        }
    }
}
