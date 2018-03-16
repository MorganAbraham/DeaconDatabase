namespace Deacon_Database_Manager.GUI
{
    partial class HomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.WorkPanel = new System.Windows.Forms.Panel();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDeacons = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkPanel
            // 
            this.WorkPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkPanel.Location = new System.Drawing.Point(100, 26);
            this.WorkPanel.Name = "WorkPanel";
            this.WorkPanel.Size = new System.Drawing.Size(883, 662);
            this.WorkPanel.TabIndex = 0;
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(2, 32);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(92, 61);
            this.btnAddMember.TabIndex = 1;
            this.btnAddMember.Text = "Add New Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(2, 99);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 61);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search For Member";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDeacons
            // 
            this.btnDeacons.Location = new System.Drawing.Point(2, 166);
            this.btnDeacons.Name = "btnDeacons";
            this.btnDeacons.Size = new System.Drawing.Size(92, 61);
            this.btnDeacons.TabIndex = 3;
            this.btnDeacons.Text = "View/Edit Deacons";
            this.btnDeacons.UseVisualStyleBackColor = true;
            this.btnDeacons.Click += new System.EventHandler(this.btnDeacons_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(100, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(883, 26);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox2.Location = new System.Drawing.Point(100, 688);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(893, 26);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 712);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDeacons);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.WorkPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomeScreen";
            this.Text = "Deacon Database";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorkPanel;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDeacons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

