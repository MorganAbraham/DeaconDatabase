namespace Deacon_Database_Manager.GUI
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelResults = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioListView = new System.Windows.Forms.RadioButton();
            this.radioPictureView = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckMembershipFilter = new System.Windows.Forms.CheckBox();
            this.ckAgeFilter = new System.Windows.Forms.CheckBox();
            this.ckAddressFilter = new System.Windows.Forms.CheckBox();
            this.ckBirthdateFilter = new System.Windows.Forms.CheckBox();
            this.ckDeaconFilter = new System.Windows.Forms.CheckBox();
            this.ckNameFilter = new System.Windows.Forms.CheckBox();
            this.panelMemberName = new System.Windows.Forms.Panel();
            this.panelDeacon = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmboDeacon = new System.Windows.Forms.ComboBox();
            this.panelBirthMonth = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmboBirthMonth = new System.Windows.Forms.ComboBox();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trackDistance = new System.Windows.Forms.TrackBar();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelAge = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxAge = new System.Windows.Forms.NumericUpDown();
            this.txtMinAge = new System.Windows.Forms.NumericUpDown();
            this.panelMembershipFilter = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.trackMembership = new System.Windows.Forms.TrackBar();
            this.btnSetFilter = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMemberName.SuspendLayout();
            this.panelDeacon.SuspendLayout();
            this.panelBirthMonth.SuspendLayout();
            this.panelAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDistance)).BeginInit();
            this.panelAge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinAge)).BeginInit();
            this.panelMembershipFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMembership)).BeginInit();
            this.SuspendLayout();
            // 
            // panelResults
            // 
            this.panelResults.Location = new System.Drawing.Point(299, 82);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(536, 509);
            this.panelResults.TabIndex = 0;
            this.panelResults.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioListView);
            this.groupBox1.Controls.Add(this.radioPictureView);
            this.groupBox1.Location = new System.Drawing.Point(660, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 46);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results View";
            // 
            // radioListView
            // 
            this.radioListView.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioListView.AutoSize = true;
            this.radioListView.Location = new System.Drawing.Point(92, 18);
            this.radioListView.Name = "radioListView";
            this.radioListView.Size = new System.Drawing.Size(59, 23);
            this.radioListView.TabIndex = 5;
            this.radioListView.TabStop = true;
            this.radioListView.Text = "List View";
            this.radioListView.UseVisualStyleBackColor = true;
            this.radioListView.CheckedChanged += new System.EventHandler(this.radioListView_CheckedChanged);
            // 
            // radioPictureView
            // 
            this.radioPictureView.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPictureView.AutoSize = true;
            this.radioPictureView.Checked = true;
            this.radioPictureView.Location = new System.Drawing.Point(6, 18);
            this.radioPictureView.Name = "radioPictureView";
            this.radioPictureView.Size = new System.Drawing.Size(76, 23);
            this.radioPictureView.TabIndex = 4;
            this.radioPictureView.TabStop = true;
            this.radioPictureView.Text = "Picture View";
            this.radioPictureView.UseVisualStyleBackColor = true;
            this.radioPictureView.CheckedChanged += new System.EventHandler(this.radioPictureView_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Minimum Age";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(9, 24);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(180, 20);
            this.txtMemberName.TabIndex = 8;
            this.txtMemberName.TextChanged += new System.EventHandler(this.txtMemberName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Church Member Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 13);
            this.label5.MaximumSize = new System.Drawing.Size(100, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Minimum Membership Length";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckMembershipFilter);
            this.panel2.Controls.Add(this.ckAgeFilter);
            this.panel2.Controls.Add(this.ckAddressFilter);
            this.panel2.Controls.Add(this.ckBirthdateFilter);
            this.panel2.Controls.Add(this.ckDeaconFilter);
            this.panel2.Controls.Add(this.ckNameFilter);
            this.panel2.Controls.Add(this.panelMemberName);
            this.panel2.Controls.Add(this.panelDeacon);
            this.panel2.Controls.Add(this.panelBirthMonth);
            this.panel2.Controls.Add(this.panelAddress);
            this.panel2.Controls.Add(this.panelAge);
            this.panel2.Controls.Add(this.panelMembershipFilter);
            this.panel2.Controls.Add(this.btnSetFilter);
            this.panel2.Location = new System.Drawing.Point(12, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 570);
            this.panel2.TabIndex = 14;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ckMembershipFilter
            // 
            this.ckMembershipFilter.AutoSize = true;
            this.ckMembershipFilter.Location = new System.Drawing.Point(248, 429);
            this.ckMembershipFilter.Name = "ckMembershipFilter";
            this.ckMembershipFilter.Size = new System.Drawing.Size(15, 14);
            this.ckMembershipFilter.TabIndex = 29;
            this.ckMembershipFilter.UseVisualStyleBackColor = true;
            this.ckMembershipFilter.CheckedChanged += new System.EventHandler(this.ckMembershipFilter_CheckedChanged);
            // 
            // ckAgeFilter
            // 
            this.ckAgeFilter.AutoSize = true;
            this.ckAgeFilter.Location = new System.Drawing.Point(248, 351);
            this.ckAgeFilter.Name = "ckAgeFilter";
            this.ckAgeFilter.Size = new System.Drawing.Size(15, 14);
            this.ckAgeFilter.TabIndex = 28;
            this.ckAgeFilter.UseVisualStyleBackColor = true;
            this.ckAgeFilter.CheckedChanged += new System.EventHandler(this.ckAgeFilter_CheckedChanged);
            // 
            // ckAddressFilter
            // 
            this.ckAddressFilter.AutoSize = true;
            this.ckAddressFilter.Location = new System.Drawing.Point(248, 237);
            this.ckAddressFilter.Name = "ckAddressFilter";
            this.ckAddressFilter.Size = new System.Drawing.Size(15, 14);
            this.ckAddressFilter.TabIndex = 27;
            this.ckAddressFilter.UseVisualStyleBackColor = true;
            this.ckAddressFilter.CheckedChanged += new System.EventHandler(this.ckAddressFilter_CheckedChanged);
            // 
            // ckBirthdateFilter
            // 
            this.ckBirthdateFilter.AutoSize = true;
            this.ckBirthdateFilter.Location = new System.Drawing.Point(248, 166);
            this.ckBirthdateFilter.Name = "ckBirthdateFilter";
            this.ckBirthdateFilter.Size = new System.Drawing.Size(15, 14);
            this.ckBirthdateFilter.TabIndex = 26;
            this.ckBirthdateFilter.UseVisualStyleBackColor = true;
            this.ckBirthdateFilter.CheckedChanged += new System.EventHandler(this.ckBirthdateFilter_CheckedChanged);
            // 
            // ckDeaconFilter
            // 
            this.ckDeaconFilter.AutoSize = true;
            this.ckDeaconFilter.Location = new System.Drawing.Point(248, 97);
            this.ckDeaconFilter.Name = "ckDeaconFilter";
            this.ckDeaconFilter.Size = new System.Drawing.Size(15, 14);
            this.ckDeaconFilter.TabIndex = 25;
            this.ckDeaconFilter.UseVisualStyleBackColor = true;
            this.ckDeaconFilter.CheckedChanged += new System.EventHandler(this.ckDeaconFilter_CheckedChanged);
            // 
            // ckNameFilter
            // 
            this.ckNameFilter.AutoSize = true;
            this.ckNameFilter.Location = new System.Drawing.Point(248, 32);
            this.ckNameFilter.Name = "ckNameFilter";
            this.ckNameFilter.Size = new System.Drawing.Size(15, 14);
            this.ckNameFilter.TabIndex = 24;
            this.ckNameFilter.UseVisualStyleBackColor = true;
            this.ckNameFilter.CheckedChanged += new System.EventHandler(this.ckNameFilter_CheckedChanged);
            // 
            // panelMemberName
            // 
            this.panelMemberName.Controls.Add(this.label3);
            this.panelMemberName.Controls.Add(this.txtMemberName);
            this.panelMemberName.Enabled = false;
            this.panelMemberName.Location = new System.Drawing.Point(3, 18);
            this.panelMemberName.Name = "panelMemberName";
            this.panelMemberName.Size = new System.Drawing.Size(239, 50);
            this.panelMemberName.TabIndex = 0;
            // 
            // panelDeacon
            // 
            this.panelDeacon.Controls.Add(this.label9);
            this.panelDeacon.Controls.Add(this.cmboDeacon);
            this.panelDeacon.Enabled = false;
            this.panelDeacon.Location = new System.Drawing.Point(2, 74);
            this.panelDeacon.Name = "panelDeacon";
            this.panelDeacon.Size = new System.Drawing.Size(240, 57);
            this.panelDeacon.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Deacon";
            // 
            // cmboDeacon
            // 
            this.cmboDeacon.FormattingEnabled = true;
            this.cmboDeacon.Location = new System.Drawing.Point(15, 23);
            this.cmboDeacon.Name = "cmboDeacon";
            this.cmboDeacon.Size = new System.Drawing.Size(185, 21);
            this.cmboDeacon.TabIndex = 21;
            this.cmboDeacon.SelectedIndexChanged += new System.EventHandler(this.cmboDeacon_SelectedIndexChanged);
            // 
            // panelBirthMonth
            // 
            this.panelBirthMonth.Controls.Add(this.label6);
            this.panelBirthMonth.Controls.Add(this.cmboBirthMonth);
            this.panelBirthMonth.Enabled = false;
            this.panelBirthMonth.Location = new System.Drawing.Point(3, 142);
            this.panelBirthMonth.Name = "panelBirthMonth";
            this.panelBirthMonth.Size = new System.Drawing.Size(239, 49);
            this.panelBirthMonth.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Birth Month";
            // 
            // cmboBirthMonth
            // 
            this.cmboBirthMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboBirthMonth.FormattingEnabled = true;
            this.cmboBirthMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmboBirthMonth.Location = new System.Drawing.Point(12, 24);
            this.cmboBirthMonth.Name = "cmboBirthMonth";
            this.cmboBirthMonth.Size = new System.Drawing.Size(183, 21);
            this.cmboBirthMonth.TabIndex = 15;
            this.cmboBirthMonth.SelectedIndexChanged += new System.EventHandler(this.cmboBirthMonth_SelectedIndexChanged);
            // 
            // panelAddress
            // 
            this.panelAddress.Controls.Add(this.label12);
            this.panelAddress.Controls.Add(this.label11);
            this.panelAddress.Controls.Add(this.label10);
            this.panelAddress.Controls.Add(this.label7);
            this.panelAddress.Controls.Add(this.trackDistance);
            this.panelAddress.Controls.Add(this.txtAddress);
            this.panelAddress.Controls.Add(this.label8);
            this.panelAddress.Enabled = false;
            this.panelAddress.Location = new System.Drawing.Point(2, 193);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(240, 121);
            this.panelAddress.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(97, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(172, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "0 ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Member Address";
            // 
            // trackDistance
            // 
            this.trackDistance.Location = new System.Drawing.Point(15, 72);
            this.trackDistance.Maximum = 100;
            this.trackDistance.Name = "trackDistance";
            this.trackDistance.Size = new System.Drawing.Size(183, 45);
            this.trackDistance.TabIndex = 17;
            this.trackDistance.TickFrequency = 10;
            this.trackDistance.Scroll += new System.EventHandler(this.trackDistance_Scroll);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(15, 24);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(183, 20);
            this.txtAddress.TabIndex = 18;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Distance From Address (In Miles)";
            // 
            // panelAge
            // 
            this.panelAge.Controls.Add(this.label1);
            this.panelAge.Controls.Add(this.label2);
            this.panelAge.Controls.Add(this.txtMaxAge);
            this.panelAge.Controls.Add(this.txtMinAge);
            this.panelAge.Enabled = false;
            this.panelAge.Location = new System.Drawing.Point(3, 319);
            this.panelAge.Name = "panelAge";
            this.panelAge.Size = new System.Drawing.Size(239, 62);
            this.panelAge.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Maximum Age";
            // 
            // txtMaxAge
            // 
            this.txtMaxAge.Location = new System.Drawing.Point(115, 32);
            this.txtMaxAge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.txtMaxAge.Name = "txtMaxAge";
            this.txtMaxAge.Size = new System.Drawing.Size(77, 20);
            this.txtMaxAge.TabIndex = 5;
            this.txtMaxAge.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.txtMaxAge.ValueChanged += new System.EventHandler(this.txtMaxAge_ValueChanged);
            // 
            // txtMinAge
            // 
            this.txtMinAge.Location = new System.Drawing.Point(12, 32);
            this.txtMinAge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.txtMinAge.Name = "txtMinAge";
            this.txtMinAge.Size = new System.Drawing.Size(77, 20);
            this.txtMinAge.TabIndex = 4;
            this.txtMinAge.ValueChanged += new System.EventHandler(this.txtMinAge_ValueChanged);
            // 
            // panelMembershipFilter
            // 
            this.panelMembershipFilter.Controls.Add(this.label4);
            this.panelMembershipFilter.Controls.Add(this.label13);
            this.panelMembershipFilter.Controls.Add(this.label14);
            this.panelMembershipFilter.Controls.Add(this.trackMembership);
            this.panelMembershipFilter.Controls.Add(this.label5);
            this.panelMembershipFilter.Enabled = false;
            this.panelMembershipFilter.Location = new System.Drawing.Point(3, 387);
            this.panelMembershipFilter.Name = "panelMembershipFilter";
            this.panelMembershipFilter.Size = new System.Drawing.Size(239, 107);
            this.panelMembershipFilter.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "50";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(179, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "100";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "0 ";
            // 
            // trackMembership
            // 
            this.trackMembership.Location = new System.Drawing.Point(22, 42);
            this.trackMembership.Maximum = 100;
            this.trackMembership.Name = "trackMembership";
            this.trackMembership.Size = new System.Drawing.Size(183, 45);
            this.trackMembership.TabIndex = 18;
            this.trackMembership.TickFrequency = 10;
            this.trackMembership.Scroll += new System.EventHandler(this.trackMembership_Scroll);
            // 
            // btnSetFilter
            // 
            this.btnSetFilter.Location = new System.Drawing.Point(36, 530);
            this.btnSetFilter.Name = "btnSetFilter";
            this.btnSetFilter.Size = new System.Drawing.Size(164, 28);
            this.btnSetFilter.TabIndex = 14;
            this.btnSetFilter.Text = "Set Filter";
            this.btnSetFilter.UseVisualStyleBackColor = true;
            this.btnSetFilter.Click += new System.EventHandler(this.btnSetFilter_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 623);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMemberName.ResumeLayout(false);
            this.panelMemberName.PerformLayout();
            this.panelDeacon.ResumeLayout(false);
            this.panelDeacon.PerformLayout();
            this.panelBirthMonth.ResumeLayout(false);
            this.panelBirthMonth.PerformLayout();
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDistance)).EndInit();
            this.panelAge.ResumeLayout(false);
            this.panelAge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinAge)).EndInit();
            this.panelMembershipFilter.ResumeLayout(false);
            this.panelMembershipFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMembership)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioListView;
        private System.Windows.Forms.RadioButton radioPictureView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSetFilter;
        private System.Windows.Forms.ComboBox cmboBirthMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackDistance;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmboDeacon;
        private System.Windows.Forms.Panel panelAddress;
        private System.Windows.Forms.Panel panelAge;
        private System.Windows.Forms.Panel panelMembershipFilter;
        private System.Windows.Forms.Panel panelBirthMonth;
        private System.Windows.Forms.Panel panelDeacon;
        private System.Windows.Forms.Panel panelMemberName;
        private System.Windows.Forms.CheckBox ckAddressFilter;
        private System.Windows.Forms.CheckBox ckBirthdateFilter;
        private System.Windows.Forms.CheckBox ckDeaconFilter;
        private System.Windows.Forms.CheckBox ckNameFilter;
        private System.Windows.Forms.CheckBox ckMembershipFilter;
        private System.Windows.Forms.CheckBox ckAgeFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtMaxAge;
        private System.Windows.Forms.NumericUpDown txtMinAge;
        private System.Windows.Forms.TrackBar trackMembership;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}