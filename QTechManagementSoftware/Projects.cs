﻿using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Projects : Form
    {
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private DataTable dt;
        private string selectedProjectCode, SELECTED_PROJECT;
        private Home frmHome;

        public Projects()
        {
            InitializeComponent();
        }

        private void Projects_Load(object sender, EventArgs e)
        {
            dgv_Projects.DataSource = bs;
            LoadProjects();
        }

        #region Load Project Details
        //================================================================================================================================================//
        // PROJECT DETAILS LOAD                                                                                                                           //
        //================================================================================================================================================//
        private void LoadProjects()
        {
            frmHome = (Home)this.Parent.Parent;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Projects", conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            bs.DataSource = dt;
        }
        #endregion

        #region New Project Click
        //================================================================================================================================================//
        // NEW PROJECT CLICKED                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_P_NewProject_Click(object sender, EventArgs e)
        {

            if (isFiltered)
                RemoveFilter();

            using (Proj_Add frmPAdd = new Proj_Add())
            {
                frmPAdd.Owner = this;
                frmPAdd.ShowDialog();
            }

            LoadProjects();
        }
        #endregion

        //================================================================================================================================================//
        // EDIT PROJECT CLICKED                                                                                                                           //
        //================================================================================================================================================//
        private void Btn_P_EditProject_Click(object sender, EventArgs e)
        {
            int rowIdx = dgv_Projects.SelectedRows[0].Index;
            SELECTED_PROJECT = dgv_Projects[0, rowIdx].Value.ToString();

            using (Proj_Edit_Del frmPED = new Proj_Edit_Del())
            {
                frmPED.Owner = this;
                frmPED.ShowDialog();
            }

            LoadProjects();
        }


        //================================================================================================================================================//
        // GETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public string GetSelectedProj()
        {
            return SELECTED_PROJECT;
        }

        public DataTable GetProjects()
        {
            return dt;
        }


        //================================================================================================================================================//
        // DATAGRIDVIEW CELL DOUBLECLICK                                                                                                                  //
        //================================================================================================================================================//
        private void Dgv_Projects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProjectCode = dgv_Projects[0, e.RowIndex].Value.ToString().Trim();

            frmHome.ProjectsDoubleClick(selectedProjectCode);
        }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void Dgv_Projects_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_Projects.FilterString;
        }

        private void Dgv_Projects_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_Projects.SortString;
        }

        private void Btn_P_Filter_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;

            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Projects WHERE Date BETWEEN '" + dtp_P_From.Value + "' AND '" + dtp_P_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
            btn_P_Filter.Visible = false;
            btn_P_ClearFilter.Visible = true;
        }

        private void Btn_P_ClearFilter_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            LoadProjects();
            btn_P_Filter.Visible = true;
            btn_P_ClearFilter.Visible = false;
        }


        //================================================================================================================================================//
        // NEW PROJECT BUTTON                                                                                                                             //
        //================================================================================================================================================//
        private void Btn_P_NewProject_MouseEnter(object sender, EventArgs e)
        {
            btn_P_NewProject.Image = Resources.add_white;
            btn_P_NewProject.ForeColor = Color.White;
        }

        private void Btn_P_NewProject_MouseLeave(object sender, EventArgs e)
        {
            btn_P_NewProject.Image = Resources.add_grey;
            btn_P_NewProject.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // EDIT PROJECT BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_P_EditProject_MouseEnter(object sender, EventArgs e)
        {
            btn_P_EditProject.Image = Resources.edit_white;
            btn_P_EditProject.ForeColor = Color.White;
        }

        private void Btn_P_EditProject_MouseLeave(object sender, EventArgs e)
        {
            btn_P_EditProject.Image = Resources.edit_grey;
            btn_P_EditProject.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_P_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_P_Filter.Image = Resources.filter_white;
            btn_P_Filter.ForeColor = Color.White;
        }

        private void Btn_P_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_P_Filter.Image = Resources.filter_grey;
            btn_P_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_P_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_P_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_P_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_P_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }
    }
}
