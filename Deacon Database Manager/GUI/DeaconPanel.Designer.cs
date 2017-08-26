namespace Deacon_Database_Manager.GUI
{
    partial class DeaconPanel
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
            this.deaconGrid = new System.Windows.Forms.DataGridView();
            this.panelMembers = new System.Windows.Forms.Panel();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.deaconGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // deaconGrid
            // 
            this.deaconGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deaconGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFirstName,
            this.colLastName,
            this.colRegion,
            this.colMembers});
            this.deaconGrid.Location = new System.Drawing.Point(3, 37);
            this.deaconGrid.MultiSelect = false;
            this.deaconGrid.Name = "deaconGrid";
            this.deaconGrid.Size = new System.Drawing.Size(444, 479);
            this.deaconGrid.TabIndex = 0;
            this.deaconGrid.SelectionChanged += new System.EventHandler(this.deaconGrid_SelectionChanged);
            // 
            // panelMembers
            // 
            this.panelMembers.AutoScroll = true;
            this.panelMembers.Location = new System.Drawing.Point(453, 37);
            this.panelMembers.Name = "panelMembers";
            this.panelMembers.Size = new System.Drawing.Size(318, 479);
            this.panelMembers.TabIndex = 1;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colFirstName
            // 
            this.colFirstName.HeaderText = "First Name";
            this.colFirstName.Name = "colFirstName";
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "Last Name";
            this.colLastName.Name = "colLastName";
            // 
            // colRegion
            // 
            this.colRegion.HeaderText = "Region";
            this.colRegion.Name = "colRegion";
            // 
            // colMembers
            // 
            this.colMembers.HeaderText = "MemberCount";
            this.colMembers.Name = "colMembers";
            this.colMembers.ReadOnly = true;
            // 
            // DeaconPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 545);
            this.Controls.Add(this.panelMembers);
            this.Controls.Add(this.deaconGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeaconPanel";
            this.Text = "DeaconPanel";
            this.Load += new System.EventHandler(this.DeaconPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deaconGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView deaconGrid;
        private System.Windows.Forms.Panel panelMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMembers;
    }
}