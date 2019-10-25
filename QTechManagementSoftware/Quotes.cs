﻿using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Quotes : Form
    {
        private int CUR_CLIENT = 0;
        private BindingSource bs = new BindingSource();
        private bool isFiltered = false;
        private int NUM_OF_CLIENTS;
        private int SELECTED_QUOTE;
        private string clientName, clientCode;
        private DataTable clientsDT;
        private DataTable dt;

        public Quotes()
        {
            InitializeComponent();
        }

        private void Quotes_Load(object sender, EventArgs e)
        {
            dtp_LQ_From.Value = DateTime.Now;
            dtp_LQ_To.Value = DateTime.Now;

            dgv_Contractors.DataSource = bs;

            txt_LQ_CCode.Text = clientCode;
            txt_LQ_CName.Text = clientName;

            LoadQuotes();
        }


        //================================================================================================================================================//
        // LOAD QUOTE DETAILS                                                                                                                             //
        //================================================================================================================================================//
        private void LoadQuotes()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Quotes_Send WHERE Client = '" + clientName + "'", conn);
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
        // NEW QUOTE CLICKED                                                                                                                              //
        //================================================================================================================================================//
        private void Btn_LQ_NewQuote_Click(object sender, EventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            using (Q_Add frmQA = new Q_Add())
            {
                frmQA.Owner = this;
                frmQA.ShowDialog();
            }

            LoadQuotes();
        }


        //================================================================================================================================================//
        // GETTERS                                                                                                                                        //
        //================================================================================================================================================//
        public string GetClientCode()
        {
            return clientCode;
        }

        public string GetClientName()
        {
            return clientName;
        }

        public int GetSelectedQuote()
        {
            return SELECTED_QUOTE;
        }

        public DataTable GetQuotes()
        {
            return dt;
        }


        //================================================================================================================================================//
        // FILTERS                                                                                                                                        //
        //================================================================================================================================================//
        private void Dgv_LQuotes_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_Contractors.FilterString;
        }

        private void Dgv_LQuotes_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_Contractors.SortString;
        }

        private void Btn_LQ_Filter_Click(object sender, EventArgs e)
        {
            btn_LQ_Filter.Visible = false;
            btn_LQ_ClearFilter.Visible = true;
            bs.Filter = string.Empty;
            bs.Sort = string.Empty;
            isFiltered = true;

            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Quotes_Send WHERE Client = '" + clientName + "' AND Date_Send BETWEEN '" + dtp_LQ_From.Value + "' AND '" + dtp_LQ_To.Value + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }
            bs.DataSource = dt;
        }

        private void Btn_LQ_ClearFilter_Click(object sender, EventArgs e)
        {
            RemoveFilter();
        }

        private void RemoveFilter()
        {
            LoadQuotes();
            btn_LQ_Filter.Visible = true;
            btn_LQ_ClearFilter.Visible = false;
        }


        //================================================================================================================================================//
        // DATAGRIDVIEW CELL DOUBLECLICK                                                                                                                  //
        //================================================================================================================================================//
        private void Dgv_LQuotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isFiltered)
                RemoveFilter();

            SELECTED_QUOTE = e.RowIndex;

            using (Q_Edit_Del frmQED = new Q_Edit_Del())
            {
                frmQED.Owner = this;
                frmQED.ShowDialog();
            }

            LoadQuotes();
        }

        //================================================================================================================================================//
        // NEW QUOTE BUTTON                                                                                                                               //
        //================================================================================================================================================//
        private void Btn_LQ_NewQuote_MouseEnter(object sender, EventArgs e)
        {
            btn_C_NewWW.Image = Resources.add_white;
            btn_C_NewWW.ForeColor = Color.White;
        }

        private void Btn_LQ_NewQuote_MouseLeave(object sender, EventArgs e)
        {
            btn_C_NewWW.Image = Resources.add_grey;
            btn_C_NewWW.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // FILTER BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_LQ_Filter_MouseEnter(object sender, EventArgs e)
        {
            btn_LQ_Filter.Image = Resources.filter_white;
            btn_LQ_Filter.ForeColor = Color.White;
        }

        private void Btn_LQ_Filter_MouseLeave(object sender, EventArgs e)
        {
            btn_LQ_Filter.Image = Resources.filter_grey;
            btn_LQ_Filter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLEAR FILTER BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_LQ_ClearFilter_MouseEnter(object sender, EventArgs e)
        {
            btn_LQ_ClearFilter.ForeColor = Color.White;
        }

        private void Btn_LO_ClearFilter_MouseLeave(object sender, EventArgs e)
        {
            btn_LQ_ClearFilter.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // ENFORCE READ ONLY                                                                                                                              //
        //================================================================================================================================================//
        private void Txt_LQ_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_LQ_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
