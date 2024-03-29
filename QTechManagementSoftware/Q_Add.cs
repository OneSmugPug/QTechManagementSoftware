﻿using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;
using System.Collections.Generic;

namespace QTechManagementSoftware
{
    public partial class Q_Add : Form
    {
        #region Variables
        private DataTable dt = (DataTable)null;
        private DataTable projDT;
        private bool mouseDown = false;
        private Point lastLocation;
        #endregion

        #region Initialize
        public Q_Add()
        {
            InitializeComponent();
        }
        #endregion

        #region Load Form
        private void Q_Add_Load(object sender, EventArgs e)
        {
            if (this.Owner.GetType() == typeof(Quotes))
            {
                Quotes owner = (Quotes)this.Owner;
                txt_QA_CCode.Text = owner.GetClientCode();
                txt_QA_CName.Text = owner.GetClientName();
                dt = owner.GetQuotes();
            }
            else
            {
                Int_Quotes owner = (Int_Quotes)this.Owner;
                txt_QA_CCode.Text = owner.GetClientCode();
                txt_QA_CName.Text = owner.GetClientName();
                dt = owner.GetQuotes();
            }

            int qNum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                {
                    string str = dr["Quote_Number", DataRowVersion.Original].ToString().Trim();
                    int pos = str.IndexOf("_");
                    int x = Convert.ToInt32(str.Remove(0, pos + 2));

                    if (x > qNum)
                        qNum = x;
                }
                else
                {
                    string str = dr["Quote_Number"].ToString().Trim();
                    int pos = str.IndexOf("_");
                    int x = Convert.ToInt32(str.Remove(0, pos + 2));
                    if (x > qNum)
                        qNum = x;
                }
            }
            txt_QA_QNum.Text = txt_QA_CCode.Text + "_Q" + (qNum + 1).ToString("000");
            txt_QA_Desc.Focus();
        }
        #endregion

        #region Done Clicked
        private void Btn_QA_Done_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder().Append("Are you sure you want to add quote with Quote Number: ").Append(txt_QA_QNum.Text).Append("?");

            if (MessageBox.Show(sb.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Quotes_Send VALUES (@QNum, @Date, @Client, @Desc, @OPlaced)", conn))
                        {
                            cmd.Parameters.AddWithValue("@QNum", txt_QA_QNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@Date", dtp_QA_Date.Value);
                            cmd.Parameters.AddWithValue("@Client", txt_QA_CName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Desc", txt_QA_Desc.Text.Trim());

                            if (cb_QA_OrderPlaced.Checked)
                                cmd.Parameters.AddWithValue("@OPlaced", "Yes");
                            else cmd.Parameters.AddWithValue("@OPlaced", "No");

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("New quote successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Cancel Clicked
        private void Btn_QA_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Close Clicked
        private void Btn_QA_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Controls Effects
        //================================================================================================================================================//
        // ORDER NUMBER                                                                                                                                   //
        //================================================================================================================================================//
        private void Txt_QA_ONum_MouseEnter(object sender, EventArgs e)
        {
            ln_QA_CONum.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_QA_ONum_Leave(object sender, EventArgs e)
        {
            ln_QA_CONum.LineColor = Color.Gray;
        }

        private void Txt_QA_ONum_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_QA_QNum.Focused)
                ln_QA_CONum.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void Txt_QA_Desc_Leave(object sender, EventArgs e)
        {
            ln_QA_Desc.LineColor = Color.Gray;
        }

        private void Txt_QA_Desc_MouseEnter(object sender, EventArgs e)
        {
            ln_QA_Desc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_QA_Desc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_QA_Desc.Focused)
                ln_QA_Desc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_QA_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_QA_Close.Image = Resources.close_white;
        }

        private void Btn_QA_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_QA_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_QA_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_QA_Done.ForeColor = Color.White;
        }

        private void Btn_QA_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_QA_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_QA_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_QA_Cancel.ForeColor = Color.White;
        }

        private void Btn_QA_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_QA_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }
        #endregion

        #region ReadOnly Controls
        private void Txt_QA_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_QA_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion

        #region Form Movement
        private void Q_Add_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Q_Add_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Q_Add_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #region Project Creation
        private void Cb_QA_OrderPlaced_OnChange(object sender, EventArgs e)
        {
            bool matchFound = false;
            if (cb_QA_OrderPlaced.Checked)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();
                    try
                    {
                        // Generates string array with QNum values from Projects
                        SqlDataAdapter da = new SqlDataAdapter("SELECT Quote_Number FROM Projects", conn);
                        DataTable dt = new DataTable ();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            if (txt_QA_QNum.Text.Equals(row["Quote_Number"].ToString().Trim()))
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

                                if (strArray1[1].Equals(txt_QA_CCode.Text))
                                {
                                    x = Convert.ToInt32(strArray1[0].Remove(0, 1));
                                }

                                if (x > CCode)
                                    CCode = x;
                            }
                            string[] strArray2 = txt_QA_QNum.Text.Trim().Split('_');
                            projCode = "P" + txt_QA_CCode.Text.Remove(0,3) + "_" + strArray2[1];

                            string timeKeep = projCode + "_" + txt_QA_CName.Text.Trim() + "" + txt_QA_Desc.Text.Trim();

                            // Inserts the new project
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Projects VALUES (@ProjID, @Date, @ClientCode, @ClientName, @Desc, @QNum, @Timekeep)", conn))
                            {
                                cmd.Parameters.AddWithValue("@ProjID", projCode.Trim());
                                cmd.Parameters.AddWithValue("@Date", DBNull.Value);
                                cmd.Parameters.AddWithValue("@ClientCode", txt_QA_CCode.Text.Trim());
                                cmd.Parameters.AddWithValue("@ClientName", txt_QA_CName.Text.Trim());
                                cmd.Parameters.AddWithValue("@Desc", DBNull.Value);
                                cmd.Parameters.AddWithValue("@QNum", txt_QA_QNum.Text.Trim());
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
