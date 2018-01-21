namespace Deacon_Database_Manager.GUI
{
    partial class HomePanel
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SearchResults = new System.Windows.Forms.Panel();
            this.UpcomingBirthdays = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridUpcomingAnniversaries = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridUpcomingContacts = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastContactDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNextContactDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UpcomingBirthdays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpcomingAnniversaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpcomingContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.Color.LightGray;
            this.txtSearch.Location = new System.Drawing.Point(637, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(161, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search For Members";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // SearchResults
            // 
            this.SearchResults.AutoScroll = true;
            this.SearchResults.Location = new System.Drawing.Point(637, 56);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(161, 516);
            this.SearchResults.TabIndex = 1;
            this.SearchResults.Paint += new System.Windows.Forms.PaintEventHandler(this.SearchResults_Paint);
            // 
            // UpcomingBirthdays
            // 
            this.UpcomingBirthdays.AllowUserToAddRows = false;
            this.UpcomingBirthdays.AllowUserToDeleteRows = false;
            this.UpcomingBirthdays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UpcomingBirthdays.BackgroundColor = System.Drawing.Color.White;
            this.UpcomingBirthdays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UpcomingBirthdays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.colMemberName,
            this.colBirthDay});
            this.UpcomingBirthdays.Location = new System.Drawing.Point(36, 386);
            this.UpcomingBirthdays.Name = "UpcomingBirthdays";
            this.UpcomingBirthdays.ReadOnly = true;
            this.UpcomingBirthdays.Size = new System.Drawing.Size(270, 172);
            this.UpcomingBirthdays.TabIndex = 2;
            this.UpcomingBirthdays.DoubleClick += new System.EventHandler(this.UpcomingBirthdays_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Upcoming Birthdays";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Upcoming Anniversaries";
            // 
            // dataGridUpcomingAnniversaries
            // 
            this.dataGridUpcomingAnniversaries.AllowUserToAddRows = false;
            this.dataGridUpcomingAnniversaries.AllowUserToDeleteRows = false;
            this.dataGridUpcomingAnniversaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUpcomingAnniversaries.BackgroundColor = System.Drawing.Color.White;
            this.dataGridUpcomingAnniversaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUpcomingAnniversaries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2});
            this.dataGridUpcomingAnniversaries.Location = new System.Drawing.Point(340, 386);
            this.dataGridUpcomingAnniversaries.Name = "dataGridUpcomingAnniversaries";
            this.dataGridUpcomingAnniversaries.ReadOnly = true;
            this.dataGridUpcomingAnniversaries.Size = new System.Drawing.Size(270, 172);
            this.dataGridUpcomingAnniversaries.TabIndex = 4;
            this.dataGridUpcomingAnniversaries.DoubleClick += new System.EventHandler(this.dataGridUpcomingAnniversaries_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Upcoming Contact  Dates";
            // 
            // dataGridUpcomingContacts
            // 
            this.dataGridUpcomingContacts.AllowUserToAddRows = false;
            this.dataGridUpcomingContacts.AllowUserToDeleteRows = false;
            this.dataGridUpcomingContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUpcomingContacts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridUpcomingContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUpcomingContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.colName,
            this.colLastContactDate,
            this.colNextContactDate});
            this.dataGridUpcomingContacts.Location = new System.Drawing.Point(36, 163);
            this.dataGridUpcomingContacts.Name = "dataGridUpcomingContacts";
            this.dataGridUpcomingContacts.ReadOnly = true;
            this.dataGridUpcomingContacts.Size = new System.Drawing.Size(388, 172);
            this.dataGridUpcomingContacts.TabIndex = 6;
            this.dataGridUpcomingContacts.DoubleClick += new System.EventHandler(this.dataGridUpcomingContacts_DoubleClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Member ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Member Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colLastContactDate
            // 
            this.colLastContactDate.HeaderText = "Last Contact Date";
            this.colLastContactDate.Name = "colLastContactDate";
            this.colLastContactDate.ReadOnly = true;
            // 
            // colNextContactDate
            // 
            this.colNextContactDate.HeaderText = "Next Contat Date";
            this.colNextContactDate.Name = "colNextContactDate";
            this.colNextContactDate.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Member ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // colMemberName
            // 
            this.colMemberName.HeaderText = "Member Name";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            // 
            // colBirthDay
            // 
            this.colBirthDay.HeaderText = "Birth Day";
            this.colBirthDay.Name = "colBirthDay";
            this.colBirthDay.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Member ID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Member Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Anniversary Date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // HomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 584);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridUpcomingContacts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridUpcomingAnniversaries);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpcomingBirthdays);
            this.Controls.Add(this.SearchResults);
            this.Controls.Add(this.txtSearch);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomePanel";
            this.Text = "HomePanel";
            this.Load += new System.EventHandler(this.HomePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpcomingBirthdays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpcomingAnniversaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpcomingContacts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel SearchResults;
        private System.Windows.Forms.DataGridView UpcomingBirthdays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridUpcomingAnniversaries;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridUpcomingContacts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastContactDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNextContactDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}