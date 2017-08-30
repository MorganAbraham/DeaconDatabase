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
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMembers = new System.Windows.Forms.Panel();
            this.btnSaveAndExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.deaconGrid.Location = new System.Drawing.Point(3, 125);
            this.deaconGrid.MultiSelect = false;
            this.deaconGrid.Name = "deaconGrid";
            this.deaconGrid.Size = new System.Drawing.Size(444, 391);
            this.deaconGrid.TabIndex = 0;
            this.deaconGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.deaconGrid_RowsAdded);
            this.deaconGrid.SelectionChanged += new System.EventHandler(this.deaconGrid_SelectionChanged);
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
            // panelMembers
            // 
            this.panelMembers.AutoScroll = true;
            this.panelMembers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMembers.Location = new System.Drawing.Point(453, 144);
            this.panelMembers.Name = "panelMembers";
            this.panelMembers.Size = new System.Drawing.Size(318, 372);
            this.panelMembers.TabIndex = 1;
            // 
            // btnSaveAndExit
            // 
            this.btnSaveAndExit.Location = new System.Drawing.Point(628, 51);
            this.btnSaveAndExit.Name = "btnSaveAndExit";
            this.btnSaveAndExit.Size = new System.Drawing.Size(143, 23);
            this.btnSaveAndExit.TabIndex = 12;
            this.btnSaveAndExit.Text = "Save && Exit";
            this.btnSaveAndExit.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(628, 90);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(143, 23);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Return Home";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(628, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(453, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Deacon\'s Members";
            // 
            // DeaconPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 545);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveAndExit);
            this.Controls.Add(this.panelMembers);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.deaconGrid);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeaconPanel";
            this.Text = "DeaconPanel";
            this.Load += new System.EventHandler(this.DeaconPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deaconGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView deaconGrid;
        private System.Windows.Forms.Panel panelMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMembers;
        private System.Windows.Forms.Button btnSaveAndExit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
    }
}