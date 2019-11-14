namespace QTechManagementSoftware
{
    partial class Con_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Con_List));
            this.header = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_SelCon = new ADGV.AdvancedDataGridView();
            this.btn_SelCon_Close = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelCon)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.header.Location = new System.Drawing.Point(12, 12);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(133, 20);
            this.header.TabIndex = 37;
            this.header.Text = "Select Contractor";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgv_SelCon);
            this.panel2.Location = new System.Drawing.Point(12, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 507);
            this.panel2.TabIndex = 0;
            // 
            // dgv_SelCon
            // 
            this.dgv_SelCon.AllowUserToAddRows = false;
            this.dgv_SelCon.AllowUserToDeleteRows = false;
            this.dgv_SelCon.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_SelCon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_SelCon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_SelCon.AutoGenerateContextFilters = true;
            this.dgv_SelCon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_SelCon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_SelCon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgv_SelCon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(77)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SelCon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_SelCon.ColumnHeadersHeight = 25;
            this.dgv_SelCon.DateWithTime = false;
            this.dgv_SelCon.EnableHeadersVisualStyles = false;
            this.dgv_SelCon.Location = new System.Drawing.Point(0, 0);
            this.dgv_SelCon.Name = "dgv_SelCon";
            this.dgv_SelCon.ReadOnly = true;
            this.dgv_SelCon.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_SelCon.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.dgv_SelCon.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_SelCon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SelCon.Size = new System.Drawing.Size(626, 507);
            this.dgv_SelCon.TabIndex = 1;
            this.dgv_SelCon.TimeFilter = false;
            this.dgv_SelCon.SortStringChanged += new System.EventHandler(this.Dgv_SelCon_SortStringChanged);
            this.dgv_SelCon.FilterStringChanged += new System.EventHandler(this.Dgv_SelCon_FilterStringChanged);
            this.dgv_SelCon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_SelCon_CellDoubleClick);
            // 
            // btn_SelCon_Close
            // 
            this.btn_SelCon_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelCon_Close.FlatAppearance.BorderSize = 0;
            this.btn_SelCon_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_SelCon_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_SelCon_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelCon_Close.Image = global::QTechManagementSoftware.Properties.Resources.close_black;
            this.btn_SelCon_Close.Location = new System.Drawing.Point(615, 4);
            this.btn_SelCon_Close.Name = "btn_SelCon_Close";
            this.btn_SelCon_Close.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btn_SelCon_Close.Size = new System.Drawing.Size(31, 29);
            this.btn_SelCon_Close.TabIndex = 38;
            this.btn_SelCon_Close.UseVisualStyleBackColor = false;
            this.btn_SelCon_Close.Click += new System.EventHandler(this.Btn_SelCon_Close_Click);
            this.btn_SelCon_Close.MouseEnter += new System.EventHandler(this.Btn_CL_Close_MouseEnter);
            this.btn_SelCon_Close.MouseLeave += new System.EventHandler(this.Btn_CL_Close_MouseLeave);
            // 
            // Con_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(650, 570);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.header);
            this.Controls.Add(this.btn_SelCon_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 570);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 570);
            this.Name = "Con_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contractor List";
            this.Load += new System.EventHandler(this.Con_List_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CL_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CL_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CL_MouseUp);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelCon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelCon_Close;
        private Bunifu.Framework.UI.BunifuCustomLabel header;
        private System.Windows.Forms.Panel panel2;
        private ADGV.AdvancedDataGridView dgv_SelCon;
    }
}