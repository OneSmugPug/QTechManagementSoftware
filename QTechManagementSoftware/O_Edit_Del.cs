using QTechManagementSoftware.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QTechManagementSoftware
{
    public partial class O_Edit_Del : Form
    {
        #region Variables
        private bool mouseDown = false;
        private DataTable dt, quoteDT;
        private string oldCONum, SELECTED_ORDER, clientName;
        private Decimal pInv, pRec;
        private Point lastLocation;
        private NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
        #endregion

        #region Initialize Form
        public O_Edit_Del()
        {
            InitializeComponent();

            nfi.NumberGroupSeparator = " ";
        }
        #endregion

        #region Load Form
        private void O_Edit_Del_Load(object sender, EventArgs e)
        {
            if (this.Owner.GetType() == typeof(Orders))
            {
                Orders owner = (Orders)this.Owner;

                dt = owner.GetOrders();
                SELECTED_ORDER = owner.GetSelectedOrder();

                txt_OED_CCode.Text = owner.GetClientCode();
                txt_OED_CName.Text = owner.GetClientName();
                clientName = owner.GetClientName();
            }
            else
            {
                Int_Orders owner = (Int_Orders)this.Owner;

                dt = owner.GetOrders();
                SELECTED_ORDER = owner.GetSelectedOrder();

                txt_OED_CCode.Text = owner.GetClientCode();
                txt_OED_CName.Text = owner.GetClientCode();
                clientName = owner.GetClientName();
            }

            LoadQuotes();
            LoadOrder();

            oldCONum = txt_OED_CONum.Text.Trim();
        }

        private void LoadQuotes()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Quote_Number, Quote_Description FROM Quotes_Send WHERE Client = '" + clientName + "'", conn);
                quoteDT = new DataTable();
                da.Fill(quoteDT);
            }

            List<String> temp = new List<String>();
            foreach (DataRow row in quoteDT.Rows)
            {
                string item = row["Quote_Number"].ToString() + " - " + row["Quote_Description"].ToString();
                temp.Add(item);
            }

            ddb_OED_QuoteNum.Items = temp.ToArray();
        }

        private void LoadOrder()
        {
            double percInv, percRec;

            int rowIdx = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Client_Order_Number"].ToString().Equals(SELECTED_ORDER))
                    rowIdx = dt.Rows.IndexOf(dr);
            }

            txt_OED_CONum.Text = dt.Rows[rowIdx]["Client_Order_Number"].ToString().Trim();

            if (dt.Rows[rowIdx]["Date"].ToString() != string.Empty)
                dtp_OED_Date.Value = Convert.ToDateTime(dt.Rows[rowIdx]["Date"].ToString());
            else dtp_OED_Date.Value = DateTime.Now;

            if (dt.Rows[rowIdx]["Amount"].ToString() != string.Empty)
            {
                string temp = dt.Rows[rowIdx]["Amount"].ToString();
                string currency = temp.Remove(1, temp.Length - 1);

                for (int i = 0; i < ddb_OrdersCur.Items.Length - 1; i++)
                {
                    if (ddb_OrdersCur.Items[i].Equals(currency))
                        ddb_OrdersCur.selectedIndex = i;
                }

                txt_OED_Amt.Text = temp.Remove(0, 1).Trim();
            }
            else txt_OED_Amt.Text = "0.00";

            txt_OED_Amt.SelectionStart = txt_OED_Amt.Text.Length;
            txt_OED_Desc.Text = dt.Rows[rowIdx]["Description"].ToString().Trim();

            if (dt.Rows[rowIdx]["Percentage_Invoiced"].ToString() != string.Empty)
                percInv = Convert.ToDouble(dt.Rows[rowIdx]["Percentage_Invoiced"].ToString().Trim());
            else percInv = 0;
            txt_OED_PercInv.Text = percInv.ToString("p0");

            if (dt.Rows[rowIdx]["Percentage_Received"].ToString() != string.Empty)
                percRec = Convert.ToDouble(dt.Rows[rowIdx]["Percentage_Received"].ToString().Trim());
            else percRec = 0;
            txt_OED_PercRec.Text = percRec.ToString("p0");

            string quote = dt.Rows[rowIdx]["Quote_Number"].ToString().Trim();
            for (int i = 0; i < ddb_OED_QuoteNum.Items.Length; i++)
            {
                string[] temp = ddb_OED_QuoteNum.Items[i].Split('-');
                if (temp[0].Trim().Equals(quote))
                    ddb_OED_QuoteNum.selectedIndex = i;
            }
        }
        #endregion

        #region Amount & Percentage Value Change
        //================================================================================================================================================//
        // FORMAT AMOUNT TEXTBOX                                                                                                                          //
        //================================================================================================================================================//
        private void Txt_OED_Amt_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(txt_OED_Amt.Text.Replace(",", string.Empty).Replace("$", string.Empty).Replace(".", string.Empty).TrimStart('0'), out decimal ul))
            {
                ul /= 100;

                txt_OED_Amt.TextChanged -= Txt_OED_Amt_TextChanged;

                txt_OED_Amt.Text = ul.ToString("N2", nfi);
                txt_OED_Amt.TextChanged += Txt_OED_Amt_TextChanged;
                txt_OED_Amt.Select(txt_OED_Amt.Text.Length, 0);
            }
        }

        //================================================================================================================================================//
        // FORMAT PERCENTAGE RECIEVED TEXTBOX                                                                                                             //
        //================================================================================================================================================//
        private void Txt_OED_Perc_Rec_Validating(object sender, CancelEventArgs e)
        {
            double temp;

            if (Double.TryParse(txt_OED_PercRec.Text, out temp) && Convert.ToDouble(txt_OED_PercRec.Text) >= 0 && Convert.ToDouble(txt_OED_PercRec.Text) <= 1)
            {
                pRec = Convert.ToDecimal(txt_OED_PercRec.Text.ToString());
                txt_OED_PercRec.Text = temp.ToString("p0");
            }
            else if (txt_OED_PercRec.Text == String.Empty)
                txt_OED_PercRec.Text = "0%";
            else
            {
                e.Cancel = true;
                MessageBox.Show("Invalid value entered. Please enter a value between 0 and 1. Make use of \",\" instead of \".\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //================================================================================================================================================//
        // FORMAT PERCENTAGE INVOICED TEXTBOX                                                                                                             //
        //================================================================================================================================================//
        private void Txt_OED_Perc_Inv_Validating(object sender, CancelEventArgs e)
        {
            double temp;

            if (Double.TryParse(txt_OED_PercInv.Text, out temp) && Convert.ToDouble(txt_OED_PercInv.Text) >= 0 && Convert.ToDouble(txt_OED_PercInv.Text) <= 1)
            {
                pInv = Convert.ToDecimal(txt_OED_PercInv.Text.ToString());
                txt_OED_PercInv.Text = temp.ToString("p0");
            }

            else if (txt_OED_PercInv.Text == String.Empty)
                txt_OED_PercInv.Text = "0%";
            else
            {
                e.Cancel = true;
                MessageBox.Show("Invalid value entered. Please enter a value between 0 and 1. Make use of \",\" instead of \".\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Done Clicked
        private void Btn_OED_Done_Click(object sender, EventArgs e)
        {
            if (txt_OED_CONum.Text != string.Empty)
            {
                if (MessageBox.Show("Are you sure you want to update order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txt_OED_CONum.Text.Trim() == oldCONum)
                    {
                        using (SqlConnection conn = DBUtils.GetDBConnection())
                        {
                            conn.Open();

                            try
                            {
                                string sql = "UPDATE Orders_Received SET Date = @Date, Description = @Desc, Amount = @Amt, Percentage_Invoiced = @PercInv, " +
                                    "Percentage_Received = @PercRec, Quote_Number = @QNum WHERE Client_Order_Number = @CONum";

                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Date", dtp_OED_Date.Value);
                                    cmd.Parameters.AddWithValue("@Desc", txt_OED_Desc.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Amt", ddb_OrdersCur.selectedValue + " " + txt_OED_Amt.Text);
                                    cmd.Parameters.AddWithValue("@PercInv", pInv);
                                    cmd.Parameters.AddWithValue("@PercRec", pRec);

                                    string[] temp = ddb_OED_QuoteNum.selectedValue.Split('-');
                                    cmd.Parameters.AddWithValue("@QNum", temp[0]);

                                    cmd.Parameters.AddWithValue("@CONum", oldCONum);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Order successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (txt_OED_CONum.Text.Trim() != oldCONum)
                    {
                        using (SqlConnection conn = DBUtils.GetDBConnection())
                        {
                            conn.Open();

                            try
                            {
                                string sql = "UPDATE Orders_Received SET Client_Order_Number = @CONum, Date = @Date, Description = @Desc, Amount = @Amt, Percentage_Invoiced = @PercInv, " +
                                    "Percentage_Received = @PercRec, Quote_Number = @QNum WHERE Client_Order_Number = @oldCONum";

                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@CONum", txt_OED_CONum.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Date", dtp_OED_Date.Value);
                                    cmd.Parameters.AddWithValue("@Desc", txt_OED_Desc.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Amt", ddb_OrdersCur.selectedValue + " " + txt_OED_Amt.Text);
                                    cmd.Parameters.AddWithValue("@PercInv", pInv);
                                    cmd.Parameters.AddWithValue("@PercRec", pRec);

                                    string[] temp = ddb_OED_QuoteNum.selectedValue.Split('-');
                                    cmd.Parameters.AddWithValue("@QNum", temp[0]);

                                    cmd.Parameters.AddWithValue("@oldCONum", oldCONum);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Order successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            }
            else MessageBox.Show("Please enter a Client Order Number to continue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Close Clicked
        private void Btn_OED_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Cancel Clicked
        private void Btn_OED_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Controls Effects
        //================================================================================================================================================//
        // PERCENTAGE INVOICED                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_OED_PercInv_Leave(object sender, EventArgs e)
        {
            ln_OED_PercInv.LineColor = Color.Gray;
        }

        private void Txt_OED_PercInv_MouseEnter(object sender, EventArgs e)
        {
            ln_OED_PercInv.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OED_PercInv_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OED_PercInv.Focused)
                ln_OED_PercInv.LineColor = Color.Gray;
        }

        private void Txt_OED_PercInv_Enter(object sender, EventArgs e)
        {
            txt_OED_PercInv.Clear();
        }


        //================================================================================================================================================//
        // PERCENTAGE RECEIVED                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_OED_PercRec_Leave(object sender, EventArgs e)
        {
            ln_OED_PercRec.LineColor = Color.Gray;
        }

        private void Txt_OED_PercRec_MouseEnter(object sender, EventArgs e)
        {
            ln_OED_PercRec.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OED_PercRec_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OED_PercRec.Focused)
                ln_OED_PercRec.LineColor = Color.Gray;
        }

        private void Txt_OED_PercRec_Enter(object sender, EventArgs e)
        {
            txt_OED_PercRec.Clear();
        }


        //================================================================================================================================================//
        // CLIENT ORDER NUMBER                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_OED_CONum_MouseEnter(object sender, EventArgs e)
        {
            ln_OED_CONum.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OED_CONum_Leave(object sender, EventArgs e)
        {
            ln_OED_CONum.LineColor = Color.Gray;
        }

        private void Txt_OED_CONum_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OED_CONum.Focused)
                ln_OED_CONum.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void Txt_OED_Desc_Leave(object sender, EventArgs e)
        {
            ln_OED_Desc.LineColor = Color.Gray;
        }

        private void Txt_OED_Desc_MouseEnter(object sender, EventArgs e)
        {
            ln_OED_Desc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OED_Desc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OED_Desc.Focused)
                ln_OED_Desc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // AMOUNT                                                                                                                                         //
        //================================================================================================================================================//
        private void Txt_OED_Amt_Leave(object sender, EventArgs e)
        {
            ln_OED_Amt.LineColor = Color.Gray;
        }

        private void Txt_OED_Amt_MouseEnter(object sender, EventArgs e)
        {
            ln_OED_Amt.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OED_Amt_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OED_Amt.Focused)
                ln_OED_Amt.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_OED_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_OED_Close.Image = Resources.close_white;
        }

        private void Btn_OED_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_OED_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_OED_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_OED_Done.ForeColor = Color.White;
        }

        private void Btn_OED_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_OED_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_OED_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_OED_Cancel.ForeColor = Color.White;
        }

        private void Btn_OED_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_OED_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }
        #endregion

        #region ReadOnly Controls
        private void Txt_OED_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_OED_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txt_OED_Amt_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) && !(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && !(e.KeyCode == Keys.Back))
                e.SuppressKeyPress = true;
        }
        #endregion

        #region Form Movement
        private void O_Edit_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; //If user clicks on main form mouseDown is set to true
            lastLocation = e.Location; //The last location of the mouse click is captured
        }

        private void O_Edit_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                //Moves the form to a new location as long as user has mouse click down
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                //Updates the main form with the new position
                this.Update();
            }
        }

        private void O_Edit_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false; //Sets mouseDown to false when user stops clicking
        }
        #endregion
    }
}
