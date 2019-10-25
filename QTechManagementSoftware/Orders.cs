﻿using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Orders : Form
    {
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private int SELECTED_ORDER;
        private string clientName, clientCode;
        private DataTable dt;

        public Orders()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // ORDERS FORM LOAD                                                                                                                               //
        //================================================================================================================================================//
        private void Orders_Load(object sender, EventArgs e)
        {
            dtp_LO_From.Value = DateTime.Now;
            dtp_LO_To.Value = DateTime.Now;
            
            dgv_LOrders.DataSource = bs;

            LoadOrders();

            dgv_LOrders.Columns[4].DefaultCellStyle.Format = "c";
            dgv_LOrders.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_LOrders.Columns[5].DefaultCellStyle.Format = "p0";
            dgv_LOrders.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_LOrders.Columns[6].DefaultCellStyle.Format = "p0";
            dgv_LOrders.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            txt_LO_CCode.Text = clientCode;
            txt_LO_CName.Text = clientName;
        }


        //================================================================================================================================================//
        // LOAD ORDER DETAILS                                                                                                                             //
        //================================================================================================================================================//
        private void LoadOrders()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orders_Received WHERE Client = '" + clientName + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
        }

        //================================================================================================================================================//
        // SET NEW CLIENT                                                                                                                                 //
        //================================================================================================================================================//
        public void SetClient(string selectedClientCode, string selectedClientName)
        {
            clientCode = selectedClientCode;
            clientName = selectedClientName;
        }

        //================================================================================================================================================//
        // NEW ORDER ADD CLICKED                                                                                                                          //
        //================================================================================================================================================//
        private void Btn_AddOrder_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            using (O_Add frmOA = new O_Add())
            {
                frmOA.Owner = this;
                frmOA.ShowDialog();
            }

            LoadOrders();
        }


        //================================================================================================================================================//
        // GETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public int GetSelectedOrder()
        {
            return SELECTED_ORDER;
        }

        public DataTable GetOrders()
        {
            return dt;
        }

        public string GetClientCode() { return clientCode; }

        public string GetClientName() { return clientName; }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void Dgv_Order_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_LOrders.FilterString;
        }

        private void Dgv_Order_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_LOrders.SortString;
        }

        private void Btn_O_FilterD_Click(object sender, EventArgs e)
        {
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;
            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orders_Received WHERE Client = '" + clientName + "' AND Date BETWEEN '" 
                    + dtp_LO_From.Value + "' AND '" + dtp_LO_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            bs.DataSource = dt;
            btn_LO_Filter.Visible = false;
            btn_LO_ClearFilter.Visible = true;
        }

        private void Btn_O_ClearF_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            LoadOrders();
            btn_LO_Filter.Visible = true;
            btn_LO_ClearFilter.Visible = false;
        }

        private void Dgv_Order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            SELECTED_ORDER = e.RowIndex;

            using (O_Edit_Del frmOED = new O_Edit_Del())
            {
                frmOED.Owner = this;
                frmOED.ShowDialog();
            }

            LoadOrders();
        }

        //================================================================================================================================================//
        // NEW ORDER ADD BUTTON                                                                                                                           //
        //================================================================================================================================================//
        private void Btn_LO_NewOrder_MouseEnter(object sender, EventArgs e)
        {
            btn_LO_NewOrder.Image = Resources.add_white;
            btn_LO_NewOrder.ForeColor = Color.White;
        }

        private void Btn_LO_NewOrder_MouseLeave(object sender, EventArgs e)
        {
            btn_LO_NewOrder.Image = Resources.add_grey;
            btn_LO_NewOrder.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_LO_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_LO_Filter.Image = Resources.filter_white;
            btn_LO_Filter.ForeColor = Color.White;
        }

        private void Btn_LO_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_LO_Filter.Image = Resources.filter_grey;
            btn_LO_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_LO_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_LO_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_LO_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_LO_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READONLY                                                                                                                               //
        //================================================================================================================================================//
        private void Txt_LO_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_LO_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
