﻿using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Invoices_Send : Form
    {
        private int CUR_CLIENT = 0, NUM_OF_CLIENTS, SELECTED_INVSEND;
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private string CNAME, NEW_INVOICE;
        private DataTable clientsDT, dt;

        public Invoices_Send()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // LOCAL INVOICES SENT FORM LOAD                                                                                                                  //
        //================================================================================================================================================//
        private void Invoices_Send_Load(object sender, EventArgs e)
        {
            dtp_LIS_From.Value = DateTime.Now;
            dtp_LIS_To.Value = DateTime.Now;

            clientsDT = new DataTable();
            dgv_LInvSent.DataSource = bs;

            LoadClients();
            LoadInvSend();

            dgv_LInvSent.Columns[4].DefaultCellStyle.Format = "c";
            dgv_LInvSent.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_LInvSent.Columns[5].DefaultCellStyle.Format = "c";
            dgv_LInvSent.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        //================================================================================================================================================//
        // LOAD CLIENT DETAILS                                                                                                                            //
        //================================================================================================================================================//
        private void LoadClients()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Clients", conn);
                clientsDT = new DataTable();
                sqlDataAdapter.Fill(clientsDT);
            }

            if (clientsDT.Rows.Count > 0)
            {

                if (!dgv_LInvSent.Enabled)
                    dgv_LInvSent.Enabled = true;

                if (!btn_LIS_NewIS.Enabled)
                    btn_LIS_NewIS.Enabled = true;

                if (!btn_LIS_Filter.Enabled)
                    btn_LIS_Filter.Enabled = true;

                NUM_OF_CLIENTS = clientsDT.Rows.Count - 1;
                txt_LIS_CCode.Text = clientsDT.Rows[CUR_CLIENT]["Code"].ToString().Trim();
                CNAME = clientsDT.Rows[CUR_CLIENT]["Name"].ToString().Trim();
                txt_LIS_CName.Text = CNAME;
            }
            else
            {
                dgv_LInvSent.Enabled = false;
                btn_LIS_NewIS.Enabled = false;
                btn_LIS_Filter.Enabled = false;
            }
        }


        //================================================================================================================================================//
        // LOAD INVOICES SENT DETAILS                                                                                                                     //
        //================================================================================================================================================//
        private void LoadInvSend()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Invoices_Send WHERE Client LIKE '" + CNAME + "%'", conn);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);
            }

            bs.DataSource = dt;
        }

        //================================================================================================================================================//
        // SET NEW CLIENT DETAILS                                                                                                                         //
        //================================================================================================================================================//
        public void SetNewClient(int rowIdx)
        {
            CUR_CLIENT = rowIdx;

            LoadClients();
            LoadInvSend();
        }


        //================================================================================================================================================//
        // NEW INVOICE SENT CLICKED                                                                                                                       //
        //================================================================================================================================================//
        private void btn_LIS_NewIS_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                removeFilter();

            using (Inv_Send_Add frmISA = new Inv_Send_Add())
            {
                frmISA.ShowDialog(this);
            }

            LoadInvSend();
        }


        //================================================================================================================================================//
        // GETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public string GetCCode()
        {
            return txt_LIS_CCode.Text;
        }

        public string GetCName()
        {
            return CNAME;
        }

        public int GetSelectedInvSend()
        {
            return SELECTED_INVSEND;
        }

        public DataTable GetInvoices()
        {
            return dt;
        }


        //================================================================================================================================================//
        // SET NEW INVOICE                                                                                                                                //
        //================================================================================================================================================//
        public void setNewInvoice(string invNum)
        {
            NEW_INVOICE = invNum;
        }


        //================================================================================================================================================//
        // DATAGRIDVIEW CELL DOUBLECLICK                                                                                                                  //
        //================================================================================================================================================//
        private void dgv_LInvSent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFiltered)
                removeFilter();

            SELECTED_INVSEND = e.RowIndex;

            using (Inv_Send_Edit_Del frmISED = new Inv_Send_Edit_Del())
                frmISED.ShowDialog(this);

            LoadInvSend();
        }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void dgv_LInvSent_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_LInvSent.FilterString;
        }

        private void dgv_LInvSent_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_LInvSent.SortString;
        }

        private void btn_LIS_Filter_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;
            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Invoices_Send WHERE Client LIKE '" + CNAME + "%' AND Date BETWEEN '" + dtp_LIS_From.Value + "' AND '" + dtp_LIS_To.Value + "' OR Client LIKE '" + CNAME + "%' AND Date_Paid BETWEEN '" + dtp_LIS_From.Value + "' AND '" + dtp_LIS_To.Value + "'", conn);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);
            }

            bs.DataSource = (object)dt;
            btn_LIS_Filter.Visible = false;
            btn_LIS_ClearFilter.Visible = true;
        }

        private void btn_LIS_ClearFilter_Click(object sender, EventArgs e)
        {
            removeFilter();
        }

        private void removeFilter()
        {
            LoadInvSend();
            btn_LIS_Filter.Visible = true;
            btn_LIS_ClearFilter.Visible = false;
        }

        //================================================================================================================================================//
        // NEW INVOICE SENT BUTTON                                                                                                                        //
        //================================================================================================================================================//
        private void btn_LIS_NewIS_MouseEnter(object sender, EventArgs e)
        {
            btn_LIS_NewIS.Image = Resources.add_white;
            btn_LIS_NewIS.ForeColor = Color.White;
        }

        private void btn_LIS_NewIS_MouseLeave(object sender, EventArgs e)
        {
            btn_LIS_NewIS.Image = Resources.add_grey;
            btn_LIS_NewIS.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void btn_LIS_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_LIS_Filter.Image = Resources.filter_white;
            btn_LIS_Filter.ForeColor = Color.White;
        }

        private void btn_LIS_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_LIS_Filter.Image = Resources.filter_grey;
            btn_LIS_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void btn_LIS_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_LIS_ClearFilter.ForeColor = Color.White;
        }

        private void btn_LIS_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_LIS_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READONLY                                                                                                                               //
        //================================================================================================================================================//
        private void txt_LIS_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txt_LIS_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
