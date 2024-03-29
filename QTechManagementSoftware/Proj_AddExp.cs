﻿using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;
using ADGV;
using ClosedXML.Excel;
using System.IO;

namespace QTechManagementSoftware
{
    public partial class Proj_AddExp : Form
    {
        private BindingSource bs = new BindingSource();
        private DataTable dt;
        private string selectedProjectCode;
        private Home frmHome;
        private bool isFiltered;

        public Proj_AddExp()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // PROJECT ADD EXPENSE FORM LOAD                                                                                                                  //
        //================================================================================================================================================//
        private void Proj_AddExp_Load(object sender, EventArgs e)
        {
            dtp_PAE_From.Value = DateTime.Now;
            dtp_PAE_To.Value = DateTime.Now;

            lblProjExp.Text = "Expenses for Project: " + selectedProjectCode;

            dgv_ProjAddExp.DataSource = bs;
            LoadExpenses();

            dgv_ProjAddExp.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        //================================================================================================================================================//
        // LOAD EXPENSES                                                                                                                                  //
        //================================================================================================================================================//
        private void LoadExpenses()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Project_Expenses WHERE [Project ID] = '" + selectedProjectCode + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
        }


        //================================================================================================================================================//
        // GETS ALL EXPENSES                                                                                                                              //
        //================================================================================================================================================//
        public AdvancedDataGridView GetLines()
        {
            return dgv_ProjAddExp;
        }


        //================================================================================================================================================//
        // ADD EXPENSE CLICKED                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_PAE_AddExp_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                removeFilter();

            using (New_Expense frmNE = new New_Expense())
            {
                frmNE.SetParent(this);
                frmNE.ShowDialog();
            }

            LoadExpenses();
        }


        //================================================================================================================================================//
        // GET PROJECT ID                                                                                                                                 //
        //================================================================================================================================================//
        public string GetProjectID()
        {
            return selectedProjectCode;
        }

        public void SetProjectCode(string selectedProjectCode)
        {
            this.selectedProjectCode = selectedProjectCode;
        }


        //================================================================================================================================================//
        // SET HOME FORM                                                                                                                                  //
        //================================================================================================================================================//
        public void SetHome(Home frmHome)
        {
            this.frmHome = frmHome;
        }


        //================================================================================================================================================//
        // CLOSE CLICKED                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_PAE_Close_Click(object sender, EventArgs e)
        {
            frmHome.AddExpFormClose();
            this.Close();
        }


        //================================================================================================================================================//
        // REMOVE EXPENSE CLICKED                                                                                                                         //
        //================================================================================================================================================//
        private void Btn_PAE_RemoveExp_Click(object sender, EventArgs e)
        {
            if (dgv_ProjAddExp.Rows.Count > 0)
            {
                int index = dgv_ProjAddExp.SelectedRows[0].Index;

                if (MessageBox.Show("Are you sure you want to remove selected expense?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = DBUtils.GetDBConnection())
                    {
                        conn.Open();
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM Project_Expenses WHERE ID = '" + dt.Rows[index]["ID"].ToString() + "'", conn))
                                cmd.ExecuteNonQuery();

                            MessageBox.Show("Expense successfully removed.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadExpenses();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Table is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        //================================================================================================================================================//
        // ADD EXPENSE BUTTON                                                                                                                             //
        //================================================================================================================================================//
        private void Btn_PAE_AddExp_MouseEnter(object sender, EventArgs e)
        {
            btn_PAE_AddExp.Image = Resources.add_white;
            btn_PAE_AddExp.ForeColor = Color.White;
        }

        private void Btn_PAE_AddExp_MouseLeave(object sender, EventArgs e)
        {
            btn_PAE_AddExp.Image = Resources.add_grey;
            btn_PAE_AddExp.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_PAE_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_PAE_Filter.Image = Resources.filter_white;
            btn_PAE_Filter.ForeColor = Color.White;
        }

        private void Btn_PAE_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_PAE_Filter.Image = Resources.filter_grey;
            btn_PAE_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_PAE_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_PAE_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_PAE_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_PAE_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_PAE_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_PAE_Close.ForeColor = Color.White;
        }

        private void Btn_PAE_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_PAE_Close.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // REMOVE LINE BUTTON                                                                                                                             //
        //================================================================================================================================================//
        private void Btn_PAE_RemoveLine_MouseEnter(object sender, EventArgs e)
        {
            btn_PAE_RemoveLine.ForeColor = Color.White;
        }

        private void Btn_PAE_RemoveLine_MouseLeave(object sender, EventArgs e)
        {
            btn_PAE_RemoveLine.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void dgv_ProjAddExp_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_ProjAddExp.FilterString;
        }

        private void dgv_ProjAddExp_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_ProjAddExp.SortString;
        }

        private void Btn_PAE_Filter_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;
            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Project_Expenses WHERE Date BETWEEN '" + dtp_PAE_From.Value + "' AND '" + dtp_PAE_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
            btn_PAE_Filter.Visible = false;
            btn_PAE_ClearFilter.Visible = true;
        }

        private void Btn_PAE_ClearFilter_Click(object sender, EventArgs e)
        {
            removeFilter();
        }

        private void removeFilter()
        {
            LoadExpenses();
            btn_PAE_Filter.Visible = true;
            btn_PAE_ClearFilter.Visible = false;
        }

        private void Btn_PAE_Export_Click(object sender, EventArgs e)
        {
            string path = "c:\\Project Expenses";

            path = Path.Combine(path, selectedProjectCode);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = string.Format("{0:yyMMMdd_hh-mm-ss}.xlsx", DateTime.Now);
            path = Path.Combine(path, fileName);

            XLWorkbook wb = new XLWorkbook();

            try
            {
                wb.Worksheets.Add(dt, fileName);
                wb.SaveAs(path);

                MessageBox.Show("Data successfully exported to " + path, "Export Complete", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_PAE_Export_MouseEnter(object sender, EventArgs e)
        {
            btn_PAE_Export.Image = Resources.export_white;
            btn_PAE_Export.ForeColor = Color.White;
        }

        private void Btn_PAE_Export_MouseLeave(object sender, EventArgs e)
        {
            btn_PAE_Export.Image = Resources.export_grey;
            btn_PAE_Export.ForeColor = Color.FromArgb(64, 64, 64);
        }
    }
}
