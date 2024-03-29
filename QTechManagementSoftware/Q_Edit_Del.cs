﻿using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;
using System.Collections.Generic;

namespace QTechManagementSoftware
{
    public partial class Q_Edit_Del : Form
    {
        #region Variables
        private bool mouseDown = false;
        private DataTable dt, projDT;
        private string SELECTED_QUOTE;
        private Point lastLocation;
        #endregion

        #region Initialize Form
        public Q_Edit_Del()
        {
            InitializeComponent();
        }
        #endregion

        #region Load Form
        private void Q_Edit_Del_Load(object sender, EventArgs e)
        {
            if (this.Owner.GetType() == typeof(Quotes))
            {
                Quotes owner = (Quotes)this.Owner;

                dt = owner.GetQuotes();
                SELECTED_QUOTE = owner.GetSelectedQuote();
                txt_QED_CCode.Text = owner.GetClientCode();
                txt_QED_CName.Text = owner.GetClientName();
            }
            else
            {
                Int_Quotes owner = (Int_Quotes)this.Owner;

                dt = owner.GetQuotes();
                SELECTED_QUOTE = owner.GetSelectedQuote();
                txt_QED_CCode.Text = owner.GetClientCode();
                txt_QED_CName.Text = owner.GetClientName();
            }
            LoadQuote();
        }

        private void LoadQuote()
        {
            int rowIdx = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Quote_Number"].ToString().Equals(SELECTED_QUOTE))
                    rowIdx = dt.Rows.IndexOf(dr);
            }

            txt_QED_QNum.Text = dt.Rows[rowIdx]["Quote_Number"].ToString().Trim();

            dtp_QED_Date.Value = (dt.Rows[rowIdx]["Date_Send"].ToString() == string.Empty) ? DateTime.Now : Convert.ToDateTime(dt.Rows[rowIdx]["Date_Send"].ToString());

            txt_QED_Desc.Text = dt.Rows[rowIdx]["Quote_Description"].ToString().Trim();

            if (dt.Rows[rowIdx]["Order_Placed"].ToString() == "Yes")
                cb_QED_OrderPlaced.Checked = true;
            else cb_QED_OrderPlaced.Checked = false;
        }
        #endregion

        #region Done Clicked
        private void Btn_QED_Done_Click(object sender, EventArgs e)
        {
            string qNum = txt_QED_QNum.Text;

            if (MessageBox.Show("Are you sure you want to update quote?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();

                    try
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("UPDATE Quotes_Send SET Date_Send = @Date, Quote_Description = @Desc, Order_Placed = @OPlaced WHERE Quote_Number = @QNum", conn))
                        {
                            sqlCommand.Parameters.AddWithValue("@Date", dtp_QED_Date.Value);
                            sqlCommand.Parameters.AddWithValue("@Desc", txt_QED_Desc.Text.Trim());

                            if (cb_QED_OrderPlaced.Checked)
                                sqlCommand.Parameters.AddWithValue("@OPlaced", "Yes");
                            else sqlCommand.Parameters.AddWithValue("@OPlaced", "No");

                            sqlCommand.Parameters.AddWithValue("@QNum", qNum);
                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Quote successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Close Clicked
        private void Btn_QED_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Cancel Clicked
        private void Btn_QED_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Controls Effects
        //================================================================================================================================================//
        // ORDER NUMBER                                                                                                                                   //
        //================================================================================================================================================//
        private void Txt_QED_ONum_MouseEnter(object sender, EventArgs e)
        {
            ln_QED_CONum.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_QED_ONum_Leave(object sender, EventArgs e)
        {
            ln_QED_CONum.LineColor = Color.Gray;
        }

        private void Txt_QED_ONum_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_QED_QNum.Focused)
                ln_QED_CONum.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void Txt_QED_Desc_Leave(object sender, EventArgs e)
        {
            ln_QED_Desc.LineColor = Color.Gray;
        }

        private void Txt_QED_Desc_MouseEnter(object sender, EventArgs e)
        {
            ln_QED_Desc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_QED_Desc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_QED_Desc.Focused)
                ln_QED_Desc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_QED_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_QED_Close.Image = Resources.close_white;
        }

        private void Btn_QED_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_QED_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_QED_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_QED_Done.ForeColor = Color.White;
        }

        private void Btn_QED_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_QED_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_QED_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_QED_Cancel.ForeColor = Color.White;
        }

        private void Btn_QED_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_QED_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }
        #endregion

        #region ReadOnly Controls
        private void Txt_QED_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_QED_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion

        #region Form Movement
        private void Q_Edit_Del_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Q_Edit_Del_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Q_Edit_Del_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #region Project Creation
        private void Cb_QED_OrderPlaced_OnChange(object sender, EventArgs e)
        {
            bool matchFound = false;
            if (cb_QED_OrderPlaced.Checked)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();
                    try
                    {
                        // Generates string array with QNum values from Projects
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Quote_Number FROM Projects", conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        List<string> keyValues = new List<string>();

                        // Checks if there exists a project with the same Quote Number
                        foreach (DataRow row in dt.Rows)
                        {
                            if (txt_QED_QNum.Text.Equals(row["Quote_Number"].ToString().Trim()))
                                matchFound = true;
                        }

                        // If there is no match found then create a blank project in Projects table
                        if (!matchFound)
                        {
                            // Obtains project IDs to obtain the last known entry for Projects to generate a new project ID
                            da = new SqlDataAdapter("SELECT * FROM Projects", conn);
                            projDT = new DataTable();
                            da.Fill(projDT);

                            int CCode = 0;
                            string projCode;

                            foreach (DataRow row in projDT.Rows)
                            {
                                string[] strArray1 = row["Project_ID"].ToString().Trim().Split('_');

                                int x = 0;

                                if (strArray1[1].Equals(txt_QED_CCode.Text))
                                {
                                    x = Convert.ToInt32(strArray1[0].Remove(0, 1));
                                }

                                if (x > CCode)
                                    CCode = x;
                            }
                            string[] strArray2 = txt_QED_QNum.Text.Trim().Split('_');
                            projCode = "P" + txt_QED_CCode.Text.Remove(0, 3) + "_" + strArray2[1];

                            string timeKeep = projCode + "_" + txt_QED_CName.Text.Trim() + "" + txt_QED_Desc.Text.Trim();

                            // Inserts the new project
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Projects VALUES (@ProjID, @Date, @ClientCode, @ClientName, @Desc, @QNum, @Timekeep)", conn))
                            {
                                cmd.Parameters.AddWithValue("@ProjID", projCode.Trim());
                                cmd.Parameters.AddWithValue("@Date", DBNull.Value);
                                cmd.Parameters.AddWithValue("@ClientCode", txt_QED_CCode.Text.Trim());
                                cmd.Parameters.AddWithValue("@ClientName", txt_QED_CName.Text.Trim());
                                cmd.Parameters.AddWithValue("@Desc", DBNull.Value);
                                cmd.Parameters.AddWithValue("@QNum", txt_QED_QNum.Text.Trim());
                                cmd.Parameters.AddWithValue("@Timekeep", timeKeep.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
    }
}
