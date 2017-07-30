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
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SearchResults = new System.Windows.Forms.Panel();
            this.UpcomingBirthdays = new System.Windows.Forms.DataGridView();
            this.memberDatabaseDataSet = new Deacon_Database_Manager.MemberDatabaseDataSet();
            this.getUpcomingBirthDaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getUpcomingBirthDaysTableAdapter = new Deacon_Database_Manager.MemberDatabaseDataSetTableAdapters.GetUpcomingBirthDaysTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateMember = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UpcomingBirthdays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getUpcomingBirthDaysBindingSource)).BeginInit();
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
            this.UpcomingBirthdays.BackgroundColor = System.Drawing.Color.White;
            this.UpcomingBirthdays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UpcomingBirthdays.Location = new System.Drawing.Point(27, 78);
            this.UpcomingBirthdays.Name = "UpcomingBirthdays";
            this.UpcomingBirthdays.ReadOnly = true;
            this.UpcomingBirthdays.Size = new System.Drawing.Size(270, 172);
            this.UpcomingBirthdays.TabIndex = 2;
            // 
            // memberDatabaseDataSet
            // 
            this.memberDatabaseDataSet.DataSetName = "MemberDatabaseDataSet";
            this.memberDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getUpcomingBirthDaysBindingSource
            // 
            this.getUpcomingBirthDaysBindingSource.DataMember = "GetUpcomingBirthDays";
            this.getUpcomingBirthDaysBindingSource.DataSource = this.memberDatabaseDataSet;
            // 
            // getUpcomingBirthDaysTableAdapter
            // 
            this.getUpcomingBirthDaysTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Upcoming Birthdays";
            // 
            // btnCreateMember
            // 
            this.btnCreateMember.Location = new System.Drawing.Point(27, 13);
            this.btnCreateMember.Name = "btnCreateMember";
            this.btnCreateMember.Size = new System.Drawing.Size(159, 23);
            this.btnCreateMember.TabIndex = 4;
            this.btnCreateMember.Text = "Add New Member";
            this.btnCreateMember.UseVisualStyleBackColor = true;
            this.btnCreateMember.Click += new System.EventHandler(this.btnCreateMember_Click);
            // 
            // HomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 584);
            this.Controls.Add(this.btnCreateMember);
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
            ((System.ComponentModel.ISupportInitialize)(this.memberDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getUpcomingBirthDaysBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel SearchResults;
        private System.Windows.Forms.DataGridView UpcomingBirthdays;
        private MemberDatabaseDataSet memberDatabaseDataSet;
        private System.Windows.Forms.BindingSource getUpcomingBirthDaysBindingSource;
        private MemberDatabaseDataSetTableAdapters.GetUpcomingBirthDaysTableAdapter getUpcomingBirthDaysTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateMember;
    }
}