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
            this.panelFilter = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ckRelatives = new System.Windows.Forms.CheckBox();
            this.panelRelatives = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.comboRelatives = new System.Windows.Forms.ComboBox();
            this.ckRegionFilter = new System.Windows.Forms.CheckBox();
            this.panelRegion = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.comboRegion = new System.Windows.Forms.ComboBox();
            this.panelMembershipFilter = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.trackMembership = new System.Windows.Forms.TrackBar();
            this.ckMembershipFilter = new System.Windows.Forms.CheckBox();
            this.ckNameFilter = new System.Windows.Forms.CheckBox();
            this.ckAgeFilter = new System.Windows.Forms.CheckBox();
            this.panelMemberName = new System.Windows.Forms.Panel();
            this.panelAge = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxAge = new System.Windows.Forms.NumericUpDown();
            this.txtMinAge = new System.Windows.Forms.NumericUpDown();
            this.ckAddressFilter = new System.Windows.Forms.CheckBox();
            this.ckDeaconFilter = new System.Windows.Forms.CheckBox();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trackDistance = new System.Windows.Forms.TrackBar();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelBirthMonth = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmboBirthMonth = new System.Windows.Forms.ComboBox();
            this.ckBirthdateFilter = new System.Windows.Forms.CheckBox();
            this.panelDeacon = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmboDeacon = new System.Windows.Forms.ComboBox();
            this.btnSetFilter = new System.Windows.Forms.Button();
            this.btnSlideDrawer = new System.Windows.Forms.Button();
            this.panelFilterDisplay = new System.Windows.Forms.Panel();
            this.cmboMaxResults = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelRelatives.SuspendLayout();
            this.panelRegion.SuspendLayout();
            this.panelMembershipFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMembership)).BeginInit();
            this.panelMemberName.SuspendLayout();
            this.panelAge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinAge)).BeginInit();
            this.panelAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDistance)).BeginInit();
            this.panelBirthMonth.SuspendLayout();
            this.panelDeacon.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelResults
            // 
            this.panelResults.AutoScroll = true;
            this.panelResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelResults.Location = new System.Drawing.Point(299, 119);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(536, 472);
            this.panelResults.TabIndex = 0;
            this.panelResults.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioListView);
            this.groupBox1.Controls.Add(this.radioPictureView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(660, 67);
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
            this.radioListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioListView.Location = new System.Drawing.Point(92, 18);
            this.radioListView.Name = "radioListView";
            this.radioListView.Size = new System.Drawing.Size(59, 23);
            this.radioListView.TabIndex = 5;
            this.radioListView.Text = "List View";
            this.radioListView.UseVisualStyleBackColor = true;
            this.radioListView.CheckedChanged += new System.EventHandler(this.radioListView_CheckedChanged);
            // 
            // radioPictureView
            // 
            this.radioPictureView.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPictureView.AutoSize = true;
            this.radioPictureView.Checked = true;
            this.radioPictureView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Minimum Age";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemberName.Location = new System.Drawing.Point(16, 21);
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
            this.label5.Location = new System.Drawing.Point(15, 13);
            this.label5.MaximumSize = new System.Drawing.Size(100, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Minimum Membership Length";
            // 
            // panelFilter
            // 
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.tableLayoutPanel1);
            this.panelFilter.Controls.Add(this.btnSetFilter);
            this.panelFilter.Location = new System.Drawing.Point(12, 21);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(281, 1000);
            this.panelFilter.TabIndex = 14;
            this.panelFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.ckRelatives, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.panelRelatives, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.ckRegionFilter, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelRegion, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelMembershipFilter, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.ckMembershipFilter, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.ckNameFilter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckAgeFilter, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panelMemberName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelAge, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ckAddressFilter, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ckDeaconFilter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelAddress, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panelBirthMonth, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ckBirthdateFilter, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelDeacon, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 528);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ckRelatives
            // 
            this.ckRelatives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckRelatives.AutoSize = true;
            this.ckRelatives.Location = new System.Drawing.Point(248, 497);
            this.ckRelatives.Name = "ckRelatives";
            this.ckRelatives.Size = new System.Drawing.Size(22, 47);
            this.ckRelatives.TabIndex = 30;
            this.ckRelatives.UseVisualStyleBackColor = true;
            this.ckRelatives.CheckedChanged += new System.EventHandler(this.ckRelatives_CheckedChanged);
            // 
            // panelRelatives
            // 
            this.panelRelatives.AutoSize = true;
            this.panelRelatives.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRelatives.Controls.Add(this.label16);
            this.panelRelatives.Controls.Add(this.comboRelatives);
            this.panelRelatives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRelatives.Enabled = false;
            this.panelRelatives.Location = new System.Drawing.Point(3, 497);
            this.panelRelatives.Name = "panelRelatives";
            this.panelRelatives.Size = new System.Drawing.Size(239, 47);
            this.panelRelatives.TabIndex = 31;
            this.panelRelatives.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Related To:";
            // 
            // comboRelatives
            // 
            this.comboRelatives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRelatives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRelatives.FormattingEnabled = true;
            this.comboRelatives.Location = new System.Drawing.Point(15, 23);
            this.comboRelatives.Name = "comboRelatives";
            this.comboRelatives.Size = new System.Drawing.Size(185, 21);
            this.comboRelatives.TabIndex = 21;
            // 
            // ckRegionFilter
            // 
            this.ckRegionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckRegionFilter.AutoSize = true;
            this.ckRegionFilter.Location = new System.Drawing.Point(248, 106);
            this.ckRegionFilter.Name = "ckRegionFilter";
            this.ckRegionFilter.Size = new System.Drawing.Size(22, 47);
            this.ckRegionFilter.TabIndex = 30;
            this.ckRegionFilter.UseVisualStyleBackColor = true;
            this.ckRegionFilter.CheckedChanged += new System.EventHandler(this.ckRegionFilter_CheckedChanged);
            // 
            // panelRegion
            // 
            this.panelRegion.AutoSize = true;
            this.panelRegion.Controls.Add(this.label15);
            this.panelRegion.Controls.Add(this.comboRegion);
            this.panelRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegion.Enabled = false;
            this.panelRegion.Location = new System.Drawing.Point(3, 106);
            this.panelRegion.Name = "panelRegion";
            this.panelRegion.Size = new System.Drawing.Size(239, 47);
            this.panelRegion.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Region";
            // 
            // comboRegion
            // 
            this.comboRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRegion.FormattingEnabled = true;
            this.comboRegion.Location = new System.Drawing.Point(15, 23);
            this.comboRegion.Name = "comboRegion";
            this.comboRegion.Size = new System.Drawing.Size(185, 21);
            this.comboRegion.TabIndex = 21;
            // 
            // panelMembershipFilter
            // 
            this.panelMembershipFilter.AutoSize = true;
            this.panelMembershipFilter.Controls.Add(this.label4);
            this.panelMembershipFilter.Controls.Add(this.label13);
            this.panelMembershipFilter.Controls.Add(this.label14);
            this.panelMembershipFilter.Controls.Add(this.trackMembership);
            this.panelMembershipFilter.Controls.Add(this.label5);
            this.panelMembershipFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMembershipFilter.Enabled = false;
            this.panelMembershipFilter.Location = new System.Drawing.Point(3, 401);
            this.panelMembershipFilter.Name = "panelMembershipFilter";
            this.panelMembershipFilter.Size = new System.Drawing.Size(239, 90);
            this.panelMembershipFilter.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(98, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "50";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(173, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "100";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "0 ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // trackMembership
            // 
            this.trackMembership.Location = new System.Drawing.Point(16, 42);
            this.trackMembership.Maximum = 100;
            this.trackMembership.Name = "trackMembership";
            this.trackMembership.Size = new System.Drawing.Size(183, 45);
            this.trackMembership.TabIndex = 18;
            this.trackMembership.TickFrequency = 10;
            this.trackMembership.Scroll += new System.EventHandler(this.trackMembership_Scroll);
            // 
            // ckMembershipFilter
            // 
            this.ckMembershipFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckMembershipFilter.AutoSize = true;
            this.ckMembershipFilter.Location = new System.Drawing.Point(248, 401);
            this.ckMembershipFilter.Name = "ckMembershipFilter";
            this.ckMembershipFilter.Size = new System.Drawing.Size(22, 90);
            this.ckMembershipFilter.TabIndex = 29;
            this.ckMembershipFilter.UseVisualStyleBackColor = true;
            this.ckMembershipFilter.CheckedChanged += new System.EventHandler(this.ckMembershipFilter_CheckedChanged);
            // 
            // ckNameFilter
            // 
            this.ckNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckNameFilter.AutoSize = true;
            this.ckNameFilter.Location = new System.Drawing.Point(248, 3);
            this.ckNameFilter.Name = "ckNameFilter";
            this.ckNameFilter.Size = new System.Drawing.Size(22, 44);
            this.ckNameFilter.TabIndex = 24;
            this.ckNameFilter.UseVisualStyleBackColor = true;
            this.ckNameFilter.CheckedChanged += new System.EventHandler(this.ckNameFilter_CheckedChanged);
            // 
            // ckAgeFilter
            // 
            this.ckAgeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAgeFilter.AutoSize = true;
            this.ckAgeFilter.Location = new System.Drawing.Point(248, 340);
            this.ckAgeFilter.Name = "ckAgeFilter";
            this.ckAgeFilter.Size = new System.Drawing.Size(22, 55);
            this.ckAgeFilter.TabIndex = 28;
            this.ckAgeFilter.UseVisualStyleBackColor = true;
            this.ckAgeFilter.CheckedChanged += new System.EventHandler(this.ckAgeFilter_CheckedChanged);
            // 
            // panelMemberName
            // 
            this.panelMemberName.AutoSize = true;
            this.panelMemberName.Controls.Add(this.label3);
            this.panelMemberName.Controls.Add(this.txtMemberName);
            this.panelMemberName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMemberName.Enabled = false;
            this.panelMemberName.Location = new System.Drawing.Point(3, 3);
            this.panelMemberName.Name = "panelMemberName";
            this.panelMemberName.Size = new System.Drawing.Size(239, 44);
            this.panelMemberName.TabIndex = 0;
            // 
            // panelAge
            // 
            this.panelAge.AutoSize = true;
            this.panelAge.Controls.Add(this.label1);
            this.panelAge.Controls.Add(this.label2);
            this.panelAge.Controls.Add(this.txtMaxAge);
            this.panelAge.Controls.Add(this.txtMinAge);
            this.panelAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAge.Enabled = false;
            this.panelAge.Location = new System.Drawing.Point(3, 340);
            this.panelAge.Name = "panelAge";
            this.panelAge.Size = new System.Drawing.Size(239, 55);
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
            this.txtMaxAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.txtMinAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinAge.Location = new System.Drawing.Point(16, 32);
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
            // ckAddressFilter
            // 
            this.ckAddressFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAddressFilter.AutoSize = true;
            this.ckAddressFilter.Location = new System.Drawing.Point(248, 214);
            this.ckAddressFilter.Name = "ckAddressFilter";
            this.ckAddressFilter.Size = new System.Drawing.Size(22, 120);
            this.ckAddressFilter.TabIndex = 27;
            this.ckAddressFilter.UseVisualStyleBackColor = true;
            this.ckAddressFilter.CheckedChanged += new System.EventHandler(this.ckAddressFilter_CheckedChanged);
            // 
            // ckDeaconFilter
            // 
            this.ckDeaconFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckDeaconFilter.AutoSize = true;
            this.ckDeaconFilter.Location = new System.Drawing.Point(248, 53);
            this.ckDeaconFilter.Name = "ckDeaconFilter";
            this.ckDeaconFilter.Size = new System.Drawing.Size(22, 47);
            this.ckDeaconFilter.TabIndex = 25;
            this.ckDeaconFilter.UseVisualStyleBackColor = true;
            this.ckDeaconFilter.CheckedChanged += new System.EventHandler(this.ckDeaconFilter_CheckedChanged);
            // 
            // panelAddress
            // 
            this.panelAddress.AutoSize = true;
            this.panelAddress.Controls.Add(this.label12);
            this.panelAddress.Controls.Add(this.label11);
            this.panelAddress.Controls.Add(this.label10);
            this.panelAddress.Controls.Add(this.label7);
            this.panelAddress.Controls.Add(this.trackDistance);
            this.panelAddress.Controls.Add(this.txtAddress);
            this.panelAddress.Controls.Add(this.label8);
            this.panelAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddress.Enabled = false;
            this.panelAddress.Location = new System.Drawing.Point(3, 214);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(239, 120);
            this.panelAddress.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(97, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "50";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(172, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "100";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "0 ";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 8);
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
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // panelBirthMonth
            // 
            this.panelBirthMonth.AutoSize = true;
            this.panelBirthMonth.Controls.Add(this.label6);
            this.panelBirthMonth.Controls.Add(this.cmboBirthMonth);
            this.panelBirthMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBirthMonth.Enabled = false;
            this.panelBirthMonth.Location = new System.Drawing.Point(3, 159);
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
            this.cmboBirthMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cmboBirthMonth.Location = new System.Drawing.Point(15, 25);
            this.cmboBirthMonth.Name = "cmboBirthMonth";
            this.cmboBirthMonth.Size = new System.Drawing.Size(183, 21);
            this.cmboBirthMonth.TabIndex = 15;
            this.cmboBirthMonth.SelectedIndexChanged += new System.EventHandler(this.cmboBirthMonth_SelectedIndexChanged);
            // 
            // ckBirthdateFilter
            // 
            this.ckBirthdateFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckBirthdateFilter.AutoSize = true;
            this.ckBirthdateFilter.Location = new System.Drawing.Point(248, 159);
            this.ckBirthdateFilter.Name = "ckBirthdateFilter";
            this.ckBirthdateFilter.Size = new System.Drawing.Size(22, 49);
            this.ckBirthdateFilter.TabIndex = 26;
            this.ckBirthdateFilter.UseVisualStyleBackColor = true;
            this.ckBirthdateFilter.CheckedChanged += new System.EventHandler(this.ckBirthdateFilter_CheckedChanged);
            // 
            // panelDeacon
            // 
            this.panelDeacon.AutoSize = true;
            this.panelDeacon.Controls.Add(this.label9);
            this.panelDeacon.Controls.Add(this.cmboDeacon);
            this.panelDeacon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDeacon.Enabled = false;
            this.panelDeacon.Location = new System.Drawing.Point(3, 53);
            this.panelDeacon.Name = "panelDeacon";
            this.panelDeacon.Size = new System.Drawing.Size(239, 47);
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
            this.cmboDeacon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboDeacon.FormattingEnabled = true;
            this.cmboDeacon.Location = new System.Drawing.Point(15, 23);
            this.cmboDeacon.Name = "cmboDeacon";
            this.cmboDeacon.Size = new System.Drawing.Size(185, 21);
            this.cmboDeacon.TabIndex = 21;
            this.cmboDeacon.SelectedIndexChanged += new System.EventHandler(this.cmboDeacon_SelectedIndexChanged);
            // 
            // btnSetFilter
            // 
            this.btnSetFilter.Location = new System.Drawing.Point(53, 537);
            this.btnSetFilter.Name = "btnSetFilter";
            this.btnSetFilter.Size = new System.Drawing.Size(164, 28);
            this.btnSetFilter.TabIndex = 14;
            this.btnSetFilter.Text = "Set Filter";
            this.btnSetFilter.UseVisualStyleBackColor = true;
            this.btnSetFilter.Click += new System.EventHandler(this.btnSetFilter_Click);
            // 
            // btnSlideDrawer
            // 
            this.btnSlideDrawer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlideDrawer.Location = new System.Drawing.Point(660, 21);
            this.btnSlideDrawer.Name = "btnSlideDrawer";
            this.btnSlideDrawer.Size = new System.Drawing.Size(175, 23);
            this.btnSlideDrawer.TabIndex = 15;
            this.btnSlideDrawer.Text = "Show Filter Menu";
            this.btnSlideDrawer.UseVisualStyleBackColor = true;
            this.btnSlideDrawer.Click += new System.EventHandler(this.btnSlideDrawer_Click);
            // 
            // panelFilterDisplay
            // 
            this.panelFilterDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFilterDisplay.Location = new System.Drawing.Point(299, 21);
            this.panelFilterDisplay.Name = "panelFilterDisplay";
            this.panelFilterDisplay.Size = new System.Drawing.Size(166, 92);
            this.panelFilterDisplay.TabIndex = 16;
            // 
            // cmboMaxResults
            // 
            this.cmboMaxResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboMaxResults.FormattingEnabled = true;
            this.cmboMaxResults.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "100"});
            this.cmboMaxResults.Location = new System.Drawing.Point(471, 86);
            this.cmboMaxResults.Name = "cmboMaxResults";
            this.cmboMaxResults.Size = new System.Drawing.Size(174, 21);
            this.cmboMaxResults.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(471, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(166, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Maximum # Of Results To Display";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 623);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmboMaxResults);
            this.Controls.Add(this.panelFilterDisplay);
            this.Controls.Add(this.btnSlideDrawer);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelResults);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelRelatives.ResumeLayout(false);
            this.panelRelatives.PerformLayout();
            this.panelRegion.ResumeLayout(false);
            this.panelRegion.PerformLayout();
            this.panelMembershipFilter.ResumeLayout(false);
            this.panelMembershipFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMembership)).EndInit();
            this.panelMemberName.ResumeLayout(false);
            this.panelMemberName.PerformLayout();
            this.panelAge.ResumeLayout(false);
            this.panelAge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinAge)).EndInit();
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDistance)).EndInit();
            this.panelBirthMonth.ResumeLayout(false);
            this.panelBirthMonth.PerformLayout();
            this.panelDeacon.ResumeLayout(false);
            this.panelDeacon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panelFilter;
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
        private System.Windows.Forms.Button btnSlideDrawer;
        private System.Windows.Forms.Panel panelFilterDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox ckRegionFilter;
        private System.Windows.Forms.Panel panelRegion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboRegion;
        private System.Windows.Forms.Panel panelRelatives;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboRelatives;
        private System.Windows.Forms.CheckBox ckRelatives;
        private System.Windows.Forms.ComboBox cmboMaxResults;
        private System.Windows.Forms.Label label17;
    }
}