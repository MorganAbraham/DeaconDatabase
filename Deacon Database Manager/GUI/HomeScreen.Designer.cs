﻿namespace Deacon_Database_Manager.GUI
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
            this.SuspendLayout();
            // 
            // WorkPanel
            // 
            this.WorkPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkPanel.Location = new System.Drawing.Point(100, 0);
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
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btnDeacons);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.WorkPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomeScreen";
            this.Text = "Deacon Database";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorkPanel;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDeacons;
    }
}

