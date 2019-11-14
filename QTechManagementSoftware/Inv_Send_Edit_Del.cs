using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QTechManagementSoftware.Properties;
using System;

namespace QTechManagementSoftware
{
    public partial class Inv_Send_Edit_Del : Form
    {
        #region Variables
        private bool mouseDown = false;
        private DataTable dt;
        private string oldINum, SELECTED_INVOICE;
        private Point lastLocation;
        private NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
        #endregion

        #region Initialize Form
        public Inv_Send_Edit_Del()
        {
            InitializeComponent();

            nfi.NumberGroupSeparator = " ";
        }
        #endregion

        #region Load Form
        private void Inv_Send_Edit_Del_Load(object sender, EventArgs e)
        {
            if (this.Owner.GetType() == typeof(Invoices_Send))
            {
                Invoices_Send owner = (Invoices_Send)this.Owner;

                dt = owner.GetInvoices();

                txt_ISED_CCode.Text = owner.GetClientCode();
                txt_ISED_CName.Text = owner.GetClientName();

                SELECTED_INVOICE = owner.GetSelectedInvSend();
            }
            else
            {
                Int_Invoices_Send owner = (Int_Invoices_Send)this.Owner;

                dt = owner.GetInvoices();

                txt_ISED_CCode.Text = owner.GetClientCode();
                txt_ISED_CName.Text = owner.GetClientName();

                SELECTED_INVOICE = owner.GetSelectedInvSend();
            }

            LoadInvSend();

            if (txt_ISED_INInst.Text.Trim() != string.Empty)
                oldINum = txt_ISED_InvNum.Text.Trim() + "." + txt_ISED_INInst.Text.Trim();
            else oldINum = txt_ISED_InvNum.Text.Trim();
        }

        private void LoadInvSend()
        {
            int rowIdx = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Invoice_Number"].ToString().Equals(SELECTED_INVOICE))
                    rowIdx = dt.Rows.IndexOf(dr);
            }

            if (dt.Rows[rowIdx]["Invoice_Number"].ToString().Trim().Contains("."))
            {
                string[] strArray = dt.Rows[rowIdx]["Invoice_Number"].ToString().Trim().Split('.');

                txt_ISED_InvNum.Text = strArray[0];
                txt_ISED_INInst.Text = strArray[1];
            }
            else txt_ISED_InvNum.Text = dt.Rows[rowIdx]["Invoice_Number"].ToString().Trim();

            if (dt.Rows[rowIdx]["Date"].ToString() != string.Empty)
                dtp_ISED_Date.Value = Convert.ToDateTime(dt.Rows[rowIdx]["Date"].ToString());
            else dtp_ISED_Date.Value = DateTime.Now;

            txt_ISED_Desc.Text = dt.Rows[rowIdx]["Description"].ToString().Trim();

            if (dt.Rows[rowIdx]["Total_Amount"].ToString() != string.Empty)
            {
                string temp = dt.Rows[rowIdx]["Total_Amount"].ToString();
                string currency = temp.Remove(1, temp.Length - 1);

                for (int i = 0; i < ddb_InvSendCur.Items.Length - 1; i++)
                {
                    if (ddb_InvSendCur.Items[i].Equals(currency))
                        ddb_InvSendCur.selectedIndex = i;
                }

                txt_ISED_Amt.Text = temp.Remove(0, 1).Trim();
            }              
            else txt_ISED_Amt.Text = "0.00";

            if (dt.Rows[rowIdx]["VAT"].ToString() != string.Empty)
                txt_ISED_VAT.Text = dt.Rows[rowIdx]["VAT"].ToString().Trim();
            else txt_ISED_VAT.Text = ddb_InvSendCur.selectedValue + "0.00";

            if (dt.Rows[rowIdx]["Paid"].ToString() == "Yes")
            {
                cb_ISED_Paid.Checked = true;
                dtp_ISED_DatePaid.Enabled = true;
            }
            else cb_ISED_Paid.Checked = false;

            if (dt.Rows[rowIdx]["Date_Paid"].ToString() != string.Empty)
                dtp_ISED_DatePaid.Value = Convert.ToDateTime(dt.Rows[rowIdx]["Date_Paid"].ToString());
            else dtp_ISED_DatePaid.Value = DateTime.Now;
        }
        #endregion

        #region Amount Value Changed
        private void Txt_ISED_Amt_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(txt_ISED_Amt.Text.Replace(",", string.Empty).Replace("R", string.Empty).Replace(".", string.Empty).TrimStart('0'), out decimal ul))
            {
                ul /= 100;

                txt_ISED_Amt.TextChanged -= Txt_ISED_Amt_TextChanged;

                txt_ISED_Amt.Text = ul.ToString("N2", nfi);
                txt_ISED_Amt.TextChanged += Txt_ISED_Amt_TextChanged;
                txt_ISED_Amt.Select(txt_ISED_Amt.Text.Length, 0);

                if (ddb_InvSendCur.selectedValue.Equals("R"))
                {
                    decimal temp = decimal.Round(0.15m * ul, 2);
                    txt_ISED_VAT.Text = ddb_InvSendCur.selectedValue + " " + temp.ToString("N2", nfi);
                }
                else
                {
                    if (!txt_ISED_VAT.Text.Remove(0, 1).Trim().Equals("0.00"))
                        txt_ISED_VAT.Text = ddb_InvSendCur.selectedValue + " " + 0.00m;
                }
            }
        }
        #endregion

        #region Done Clicked
        private void Btn_ISED_Done_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update invoice?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Invoices_Send SET Invoice_Number = @INum, Date = @Date, Description = @Desc, Total_Amount = @Amt, VAT = @VAT, Paid = @Paid, Date_Paid = @DPaid WHERE Invoice_Number = @oldINum", conn))
                    {
                        cmd.Parameters.AddWithValue("@Date", dtp_ISED_Date.Value);
                        cmd.Parameters.AddWithValue("@Desc", txt_ISED_Desc.Text.Trim());
                        cmd.Parameters.AddWithValue("@Amt", ddb_InvSendCur.selectedValue + " " + txt_ISED_Amt.Text);
                        cmd.Parameters.AddWithValue("@VAT", txt_ISED_VAT.Text);

                        if (cb_ISED_Paid.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Paid", "Yes");
                            cmd.Parameters.AddWithValue("@DPaid", dtp_ISED_DatePaid.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Paid", "No");
                            cmd.Parameters.AddWithValue("@DPaid", DBNull.Value);
                        }

                        if (txt_ISED_INInst.Text == string.Empty)
                            cmd.Parameters.AddWithValue("@INum", txt_ISED_InvNum.Text.Trim());
                        else cmd.Parameters.AddWithValue("@INum", txt_ISED_InvNum.Text.Trim() + "." + txt_ISED_INInst.Text.Trim());

                        cmd.Parameters.AddWithValue("@oldINum", oldINum.Trim());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Invoice successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Close Clicked
        private void Btn_ISED_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Cancel Clicked
        private void Btn_ISED_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Controls Effects
        //================================================================================================================================================//
        // INVOICE NUMBER                                                                                                                                 //
        //================================================================================================================================================//
        private void Txt_ISED_InvNum_MouseEnter(object sender, EventArgs e)
        {
            ln_ISED_InvNum.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISED_InvNum_Leave(object sender, EventArgs e)
        {
            ln_ISED_InvNum.LineColor = Color.Gray;
        }

        private void Txt_ISED_InvNum_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISED_InvNum.Focused)
                ln_ISED_InvNum.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // INVOICE INSTANCE NUMBER                                                                                                                        //
        //================================================================================================================================================//
        private void Txt_ISED_INInst_MouseEnter(object sender, EventArgs e)
        {
            ln_ISED_INInst.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISED_INInst_Leave(object sender, EventArgs e)
        {
            ln_ISED_INInst.LineColor = Color.Gray;
        }

        private void Txt_ISED_INInst_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISED_INInst.Focused)
                ln_ISED_INInst.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void Txt_ISED_Desc_Leave(object sender, EventArgs e)
        {
            ln_ISED_Desc.LineColor = Color.Gray;
        }

        private void Txt_ISED_Desc_MouseEnter(object sender, EventArgs e)
        {
            ln_ISED_Desc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISED_Desc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISED_Desc.Focused)
                ln_ISED_Desc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // AMOUNT                                                                                                                                         //
        //================================================================================================================================================//
        private void Txt_ISED_Amt_MouseEnter(object sender, EventArgs e)
        {
            ln_ISED_Amt.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISED_Amt_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISED_Amt.Focused)
                ln_ISED_Amt.LineColor = Color.Gray;
        }

        private void Txt_ISED_Amt_Leave(object sender, EventArgs e)
        {
            ln_ISED_Amt.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // VAT                                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_ISED_VAT_Leave(object sender, EventArgs e)
        {
            ln_ISED_VAT.LineColor = Color.Gray;
        }

        private void Txt_ISED_VAT_MouseEnter(object sender, EventArgs e)
        {
            ln_ISED_VAT.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_ISED_VAT_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_ISED_VAT.Focused)
                ln_ISED_VAT.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_ISED_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_ISED_Close.Image = Resources.close_white;
        }

        private void Btn_ISED_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_ISED_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_ISED_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_ISED_Done.ForeColor = Color.White;
        }

        private void Btn_ISED_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_ISED_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_ISED_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_ISED_Cancel.ForeColor = Color.White;
        }

        private void Btn_ISED_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_ISED_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }
        #endregion

        #region ReadOnly Controls
        private void Txt_ISED_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_ISED_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txt_ISED_Amt_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) && !(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && !(e.KeyCode == Keys.Back))
                e.SuppressKeyPress = true;
        }
        #endregion

        #region Form Movement
        private void Inv_Send_Edit_Del_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Inv_Send_Edit_Del_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Inv_Sent_Edit_Del_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #region Currency Symbol Change
        private void ddb_InvSendCur_onItemSelected(object sender, EventArgs e)
        {
            if (!txt_ISED_VAT.Text.Equals(string.Empty))
            {
                if (ddb_InvSendCur.selectedValue.Equals("R"))
                {

                    if (Decimal.TryParse(txt_ISED_Amt.Text.Replace(",", string.Empty).Replace(".", string.Empty).TrimStart('0'), out decimal ul))
                    {
                        ul /= 100;

                        decimal vat = decimal.Round(0.15m * ul, 2);
                        txt_ISED_Amt.Text = ddb_InvSendCur.selectedValue + " " + vat.ToString("N2", nfi);
                    }
                }
                else
                {
                    txt_ISED_Amt.Text = ddb_InvSendCur.selectedValue + " " + 0.00m;
                }
            }
        }
        #endregion

        #region Checkbox Checked/Unchecked
        private void Cb_ISED_Paid_OnChange(object sender, EventArgs e)
        {
            if (cb_ISED_Paid.Checked)
                dtp_ISED_DatePaid.Enabled = true;
            else dtp_ISED_DatePaid.Enabled = false;
        }
        #endregion
    }
}
