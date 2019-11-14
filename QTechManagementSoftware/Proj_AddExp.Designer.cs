namespace QTechManagementSoftware
{
    partial class Proj_AddExp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proj_AddExp));
            this.btn_PAE_RemoveLine = new System.Windows.Forms.Button();
            this.dtp_PAE_From = new Bunifu.Framework.UI.BunifuDatepicker();
            this.dgv_ProjAddExp = new ADGV.AdvancedDataGridView();
            this.btn_PAE_Close = new System.Windows.Forms.Button();
            this.btn_PAE_AddExp = new System.Windows.Forms.Button();
            this.btn_PAE_ClearFilter = new System.Windows.Forms.Button();
            this.btn_PAE_Filter = new System.Windows.Forms.Button();
            this.dtp_PAE_To = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lblTo = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblFrom = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblProjExp = new System.Windows.Forms.Label();
            this.btn_PAE_Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjAddExp)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_PAE_RemoveLine
            // 
            this.btn_PAE_RemoveLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PAE_RemoveLine.FlatAppearance.BorderSize = 0;
            this.btn_PAE_RemoveLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_PAE_RemoveLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_PAE_RemoveLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PAE_RemoveLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PAE_RemoveLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_PAE_RemoveLine.Location = new System.Drawing.Point(12, 566);
            this.btn_PAE_RemoveLine.Name = "btn_PAE_RemoveLine";
            this.btn_PAE_RemoveLine.Size = new System.Drawing.Size(114, 40);
            this.btn_PAE_RemoveLine.TabIndex = 0;
            this.btn_PAE_RemoveLine.Text = "Remove Line";
            this.btn_PAE_RemoveLine.UseVisualStyleBackColor = true;
            this.btn_PAE_RemoveLine.Click += new System.EventHandler(this.Btn_PAE_RemoveExp_Click);
            this.btn_PAE_RemoveLine.MouseEnter += new System.EventHandler(this.Btn_PAE_RemoveLine_MouseEnter);
            this.btn_PAE_RemoveLine.MouseLeave += new System.EventHandler(this.Btn_PAE_RemoveLine_MouseLeave);
            // 
            // dtp_PAE_From
            // 
            this.dtp_PAE_From.BackColor = System.Drawing.Color.LightGray;
            this.dtp_PAE_From.BorderRadius = 0;
            this.dtp_PAE_From.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.dtp_PAE_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_PAE_From.FormatCustom = null;
            this.dtp_PAE_From.Location = new System.Drawing.Point(228, 52);
            this.dtp_PAE_From.Name = "dtp_PAE_From";
            this.dtp_PAE_From.Size = new System.Drawing.Size(187, 36);
            this.dtp_PAE_From.TabIndex = 8;
            this.dtp_PAE_From.Value = new System.DateTime(2019, 9, 15, 12, 52, 19, 348);
            // 
            // dgv_ProjAddExp
            // 
            this.dgv_ProjAddExp.AllowUserToAddRows = false;
            this.dgv_ProjAddExp.AllowUserToDeleteRows = false;
            this.dgv_ProjAddExp.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_ProjAddExp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ProjAddExp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ProjAddExp.AutoGenerateContextFilters = true;
            this.dgv_ProjAddExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ProjAddExp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ProjAddExp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgv_ProjAddExp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(77)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ProjAddExp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ProjAddExp.ColumnHeadersHeight = 25;
            this.dgv_ProjAddExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ProjAddExp.DateWithTime = false;
            this.dgv_ProjAddExp.EnableHeadersVisualStyles = false;
            this.dgv_ProjAddExp.Location = new System.Drawing.Point(0, 94);
            this.dgv_ProjAddExp.Name = "dgv_ProjAddExp";
            this.dgv_ProjAddExp.ReadOnly = true;
            this.dgv_ProjAddExp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_ProjAddExp.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.dgv_ProjAddExp.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ProjAddExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ProjAddExp.Size = new System.Drawing.Size(963, 466);
            this.dgv_ProjAddExp.TabIndex = 9;
            this.dgv_ProjAddExp.TimeFilter = false;
            this.dgv_ProjAddExp.SortStringChanged += new System.EventHandler(this.dgv_ProjAddExp_SortStringChanged);
            this.dgv_ProjAddExp.FilterStringChanged += new System.EventHandler(this.dgv_ProjAddExp_FilterStringChanged);
            // 
            // btn_PAE_Close
            // 
            this.btn_PAE_Close.FlatAppearance.BorderSize = 0;
            this.btn_PAE_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_PAE_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_PAE_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PAE_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PAE_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_PAE_Close.Location = new System.Drawing.Point(12, 48);
            this.btn_PAE_Close.Name = "btn_PAE_Close";
            this.btn_PAE_Close.Size = new System.Drawing.Size(122, 40);
            this.btn_PAE_Close.TabIndex = 14;
            this.btn_PAE_Close.Text = "Close";
            this.btn_PAE_Close.UseVisualStyleBackColor = true;
            this.btn_PAE_Close.Click += new System.EventHandler(this.Btn_PAE_Close_Click);
            this.btn_PAE_Close.MouseEnter += new System.EventHandler(this.Btn_PAE_Close_MouseEnter);
            this.btn_PAE_Close.MouseLeave += new System.EventHandler(this.Btn_PAE_Close_MouseLeave);
            // 
            // btn_PAE_AddExp
            // 
            this.btn_PAE_AddExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PAE_AddExp.FlatAppearance.BorderSize = 0;
            this.btn_PAE_AddExp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_PAE_AddExp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_PAE_AddExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PAE_AddExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PAE_AddExp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_PAE_AddExp.Image = global::QTechManagementSoftware.Properties.Resources.add_grey;
            this.btn_PAE_AddExp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PAE_AddExp.Location = new System.Drawing.Point(815, 48);
            this.btn_PAE_AddExp.Name = "btn_PAE_AddExp";
            this.btn_PAE_AddExp.Size = new System.Drawing.Size(136, 40);
            this.btn_PAE_AddExp.TabIndex = 19;
            this.btn_PAE_AddExp.Text = "Add Expense";
            this.btn_PAE_AddExp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_PAE_AddExp.UseVisualStyleBackColor = true;
            this.btn_PAE_AddExp.Click += new System.EventHandler(this.Btn_PAE_AddExp_Click);
            this.btn_PAE_AddExp.MouseEnter += new System.EventHandler(this.Btn_PAE_AddExp_MouseEnter);
            this.btn_PAE_AddExp.MouseLeave += new System.EventHandler(this.Btn_PAE_AddExp_MouseLeave);
            // 
            // btn_PAE_ClearFilter
            // 
            this.btn_PAE_ClearFilter.FlatAppearance.BorderSize = 0;
            this.btn_PAE_ClearFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_PAE_ClearFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_PAE_ClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PAE_ClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PAE_ClearFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_PAE_ClearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PAE_ClearFilter.Location = new System.Drawing.Point(664, 48);
            this.btn_PAE_ClearFilter.Name = "btn_PAE_ClearFilter";
            this.btn_PAE_ClearFilter.Size = new System.Drawing.Size(114, 40);
            this.btn_PAE_ClearFilter.TabIndex = 20;
            this.btn_PAE_ClearFilter.Text = "Clear Filter";
            this.btn_PAE_ClearFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_PAE_ClearFilter.UseVisualStyleBackColor = true;
            this.btn_PAE_ClearFilter.Click += new System.EventHandler(this.Btn_PAE_ClearFilter_Click);
            this.btn_PAE_ClearFilter.MouseEnter += new System.EventHandler(this.Btn_PAE_ClearFilter_MouseEnter);
            this.btn_PAE_ClearFilter.MouseLeave += new System.EventHandler(this.Btn_PAE_ClearFilter_MouseLeave);
            // 
            // btn_PAE_Filter
            // 
            this.btn_PAE_Filter.FlatAppearance.BorderSize = 0;
            this.btn_PAE_Filter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_PAE_Filter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_PAE_Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PAE_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PAE_Filter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_PAE_Filter.Image = global::QTechManagementSoftware.Properties.Resources.filter_grey;
            this.btn_PAE_Filter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PAE_Filter.Location = new System.Drawing.Point(664, 48);
            this.btn_PAE_Filter.Name = "btn_PAE_Filter";
            this.btn_PAE_Filter.Size = new System.Drawing.Size(114, 40);
            this.btn_PAE_Filter.TabIndex = 21;
            this.btn_PAE_Filter.Text = "Filter";
            this.btn_PAE_Filter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_PAE_Filter.UseVisualStyleBackColor = true;
            this.btn_PAE_Filter.Click += new System.EventHandler(this.Btn_PAE_Filter_Click);
            this.btn_PAE_Filter.MouseEnter += new System.EventHandler(this.Btn_PAE_Filter_MouseEnter);
            this.btn_PAE_Filter.MouseLeave += new System.EventHandler(this.Btn_PAE_Filter_MouseLeave);
            // 
            // dtp_PAE_To
            // 
            this.dtp_PAE_To.BackColor = System.Drawing.Color.LightGray;
            this.dtp_PAE_To.BorderRadius = 0;
            this.dtp_PAE_To.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.dtp_PAE_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_PAE_To.FormatCustom = null;
            this.dtp_PAE_To.Location = new System.Drawing.Point(458, 52);
            this.dtp_PAE_To.Name = "dtp_PAE_To";
            this.dtp_PAE_To.Size = new System.Drawing.Size(187, 36);
            this.dtp_PAE_To.TabIndex = 22;
            this.dtp_PAE_To.Value = new System.DateTime(2019, 9, 15, 12, 52, 19, 348);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTo.Location = new System.Drawing.Point(421, 58);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 20);
            this.lblTo.TabIndex = 23;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFrom.Location = new System.Drawing.Point(172, 58);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(50, 20);
            this.lblFrom.TabIndex = 24;
            this.lblFrom.Text = "From:";
            // 
            // lblProjExp
            // 
            this.lblProjExp.AutoSize = true;
            this.lblProjExp.BackColor = System.Drawing.Color.LightGray;
            this.lblProjExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjExp.Location = new System.Drawing.Point(13, 13);
            this.lblProjExp.Name = "lblProjExp";
            this.lblProjExp.Size = new System.Drawing.Size(181, 22);
            this.lblProjExp.TabIndex = 25;
            this.lblProjExp.Text = "Expenses for Project:";
            // 
            // btn_PAE_Export
            // 
            this.btn_PAE_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PAE_Export.FlatAppearance.BorderSize = 0;
            this.btn_PAE_Export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.btn_PAE_Export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            this.btn_PAE_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PAE_Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PAE_Export.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_PAE_Export.Image = global::QTechManagementSoftware.Properties.Resources.doc_grey;
            this.btn_PAE_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PAE_Export.Location = new System.Drawing.Point(833, 566);
            this.btn_PAE_Export.Name = "btn_PAE_Export";
            this.btn_PAE_Export.Size = new System.Drawing.Size(118, 40);
            this.btn_PAE_Export.TabIndex = 0;
            this.btn_PAE_Export.Text = "Export";
            this.btn_PAE_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PAE_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_PAE_Export.UseVisualStyleBackColor = true;
            this.btn_PAE_Export.Click += new System.EventHandler(this.Btn_PAE_Export_Click);
            this.btn_PAE_Export.MouseEnter += new System.EventHandler(this.Btn_PAE_Export_MouseEnter);
            this.btn_PAE_Export.MouseLeave += new System.EventHandler(this.Btn_PAE_Export_MouseLeave);
            // 
            // Proj_AddExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(963, 618);
            this.Controls.Add(this.lblProjExp);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtp_PAE_To);
            this.Controls.Add(this.btn_PAE_Filter);
            this.Controls.Add(this.btn_PAE_ClearFilter);
            this.Controls.Add(this.btn_PAE_AddExp);
            this.Controls.Add(this.btn_PAE_Close);
            this.Controls.Add(this.dgv_ProjAddExp);
            this.Controls.Add(this.dtp_PAE_From);
            this.Controls.Add(this.btn_PAE_Export);
            this.Controls.Add(this.btn_PAE_RemoveLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Proj_AddExp";
            this.Text = "Proj_AddExp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Proj_AddExp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProjAddExp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PAE_RemoveLine;
        private Bunifu.Framework.UI.BunifuDatepicker dtp_PAE_From;
        private ADGV.AdvancedDataGridView dgv_ProjAddExp;
        private System.Windows.Forms.Button btn_PAE_Close;
        private System.Windows.Forms.Button btn_PAE_AddExp;
        private System.Windows.Forms.Button btn_PAE_ClearFilter;
        private System.Windows.Forms.Button btn_PAE_Filter;
        private Bunifu.Framework.UI.BunifuDatepicker dtp_PAE_To;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTo;
        private Bunifu.Framework.UI.BunifuCustomLabel lblFrom;
        private System.Windows.Forms.Label lblProjExp;
        private System.Windows.Forms.Button btn_PAE_Export;
    }
}