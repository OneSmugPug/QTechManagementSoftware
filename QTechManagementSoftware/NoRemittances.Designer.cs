namespace QTechManagementSoftware
{
    partial class NoRemittances
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
            this.dgv_NoRem = new ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoRem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_NoRem
            // 
            this.dgv_NoRem.AllowUserToAddRows = false;
            this.dgv_NoRem.AllowUserToDeleteRows = false;
            this.dgv_NoRem.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv_NoRem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_NoRem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_NoRem.AutoGenerateContextFilters = true;
            this.dgv_NoRem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_NoRem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_NoRem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgv_NoRem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(118)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(77)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_NoRem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_NoRem.ColumnHeadersHeight = 25;
            this.dgv_NoRem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_NoRem.DateWithTime = false;
            this.dgv_NoRem.EnableHeadersVisualStyles = false;
            this.dgv_NoRem.Location = new System.Drawing.Point(12, 12);
            this.dgv_NoRem.Name = "dgv_NoRem";
            this.dgv_NoRem.ReadOnly = true;
            this.dgv_NoRem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_NoRem.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(91)))), ((int)(((byte)(142)))));
            this.dgv_NoRem.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_NoRem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_NoRem.Size = new System.Drawing.Size(939, 594);
            this.dgv_NoRem.TabIndex = 0;
            this.dgv_NoRem.TimeFilter = false;
            // 
            // NoRemittances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(963, 618);
            this.Controls.Add(this.dgv_NoRem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoRemittances";
            this.Text = "NoRemittances";
            this.Load += new System.EventHandler(this.NoRemittances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NoRem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView dgv_NoRem;
    }
}