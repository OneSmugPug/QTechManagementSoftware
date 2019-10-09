﻿namespace QTechManagementSoftware
{
    partial class TabControlX
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackTopPanel = new System.Windows.Forms.Panel();
            this.TabButtonPanel = new System.Windows.Forms.Panel();
            this.RibbonPanel = new System.Windows.Forms.Panel();
            this.TabPanel = new System.Windows.Forms.Panel();
            this.BackTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackTopPanel
            // 
            this.BackTopPanel.BackColor = System.Drawing.Color.LightGray;
            this.BackTopPanel.Controls.Add(this.TabButtonPanel);
            this.BackTopPanel.Controls.Add(this.RibbonPanel);
            this.BackTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BackTopPanel.Location = new System.Drawing.Point(0, 0);
            this.BackTopPanel.Name = "BackTopPanel";
            this.BackTopPanel.Size = new System.Drawing.Size(483, 34);
            this.BackTopPanel.TabIndex = 0;
            // 
            // TabButtonPanel
            // 
            this.TabButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.TabButtonPanel.Name = "TabButtonPanel";
            this.TabButtonPanel.Size = new System.Drawing.Size(402, 30);
            this.TabButtonPanel.TabIndex = 1;
            // 
            // RibbonPanel
            // 
            this.RibbonPanel.BackColor = System.Drawing.Color.Black;
            this.RibbonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RibbonPanel.Location = new System.Drawing.Point(0, 32);
            this.RibbonPanel.Name = "RibbonPanel";
            this.RibbonPanel.Size = new System.Drawing.Size(483, 2);
            this.RibbonPanel.TabIndex = 0;
            // 
            // TabPanel
            // 
            this.TabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabPanel.BackColor = System.Drawing.Color.LightGray;
            this.TabPanel.Location = new System.Drawing.Point(0, 34);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.Size = new System.Drawing.Size(483, 282);
            this.TabPanel.TabIndex = 1;
            // 
            // TabControlX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabPanel);
            this.Controls.Add(this.BackTopPanel);
            this.Name = "TabControlX";
            this.Size = new System.Drawing.Size(483, 316);
            this.BackTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackTopPanel;
        private System.Windows.Forms.Panel TabButtonPanel;
        private System.Windows.Forms.Panel RibbonPanel;
        private System.Windows.Forms.Panel TabPanel;
    }
}
