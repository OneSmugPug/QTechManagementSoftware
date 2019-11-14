using QTechManagementSoftware.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QTechManagementSoftware
{
    public partial class O_Add : Form
    {
        #region Variables
        private bool mouseDown = false;
        private Decimal pInv, pRec;
        private StringBuilder sb;
        private Point lastLocation;
        private NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
        private DataTable dt;
        private string clientName;
        #endregion

        #region Initialize Form
        public O_Add()
        {
            InitializeComponent();
            nfi.NumberGroupSeparator = " ";
        }
        #endregion

        #region Load Form
        private void O_Add_Load(object sender, EventArgs e)
        {
            txt_OA_PercInv.Text = "0%";
            txt_OA_PercRec.Text = "0%";

            if (this.Owner.GetType() == typeof(Orders))
            {
                Orders owner = (Orders)this.Owner;

                txt_OA_CCode.Text = owner.GetClientCode();
                txt_OA_CName.Text = owner.GetClientName();
                clientName = owner.GetClientName();
            }
            else
            {
                Int_Orders owner = (Int_Orders)this.Owner;

                txt_OA_CCode.Text = owner.GetClientCode();
                txt_OA_CName.Text = owner.GetClientName();
                clientName = owner.GetClientName();
            }

            txt_OA_Amt.Text = "0.00";
            txt_OA_Amt.SelectionStart = txt_OA_Amt.Text.Length;

            LoadQuotes();
        }

        private void LoadQuotes()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Quote_Number, Quote_Description FROM Quotes_Send WHERE Client = '" + clientName + "'", conn);
                dt = new DataTable();
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                string item = row["Quote_Number"].ToString() + " - " + row["Quote_Description"].ToString();
                ddb_OA_QuoteNum.AddItem(item);
            }

            ddb_OA_QuoteNum.selectedIndex = 0;
        }
        #endregion

        #region Amount Value Changed
        private void Txt_OA_Amt_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.TryParse(txt_OA_Amt.Text.Replace(",", "").Replace("$", "").Replace(".", "").TrimStart('0'), out decimal ul))
            {
                ul /= 100;

                txt_OA_Amt.TextChanged -= Txt_OA_Amt_TextChanged;

                txt_OA_Amt.Text = ul.ToString("N2", nfi);
                txt_OA_Amt.TextChanged += Txt_OA_Amt_TextChanged;
                txt_OA_Amt.Select(txt_OA_Amt.Text.Length, 0);
            }
        }
        #endregion

        #region Precentage Invoiced Value Changed
        private void Txt_OA_Perc_Inv_Validating(object sender, CancelEventArgs e)
        {
            if (double.TryParse(txt_OA_PercInv.Text, out double ul) && Convert.ToDouble(txt_OA_PercInv.Text) >= 0 && Convert.ToDouble(txt_OA_PercInv.Text) <= 1)
            {
                pInv = Convert.ToDecimal(txt_OA_PercInv.Text.ToString());
                txt_OA_PercInv.Text = ul.ToString("p0");
            }
            else if (txt_OA_PercInv.Text == string.Empty)
                txt_OA_PercInv.Text = "0%";
            else
            {
                e.Cancel = true;
                MessageBox.Show("Invalid value entered. Please enter a value between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_OA_Perc_Inv_Enter(object sender, EventArgs e)
        {
            txt_OA_PercInv.Clear();
        }
        #endregion

        #region Percentage Received Value Changed
        private void Txt_OA_Perc_Rec_Validating(object sender, CancelEventArgs e)
        {
            if (double.TryParse(txt_OA_PercRec.Text, out double result) && Convert.ToDouble(txt_OA_PercRec.Text) >= 0 && Convert.ToDouble(txt_OA_PercRec.Text) <= 1)
            {
                pRec = Convert.ToDecimal(txt_OA_PercRec.Text.ToString());
                txt_OA_PercRec.Text = result.ToString("p0");
            }
            else if (txt_OA_PercRec.Text == string.Empty)
                txt_OA_PercRec.Text = "0%";
            else
            {
                e.Cancel = true;
                MessageBox.Show("Invalid value entered. Please enter a value between 0 and 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_OA_Perc_Rec_Enter(object sender, EventArgs e)
        {
            txt_OA_PercRec.Clear();
        }
        #endregion

        #region Done Clicked
        private void Btn_OA_Done_Click(object sender, EventArgs e)
        {
            string newCONum = txt_OA_CONum.Text;

            sb = new StringBuilder().Append("Are you sure you want to add order with Client Order Number: ").Append(newCONum).Append("?");

            if (newCONum != string.Empty)
            {
                if (MessageBox.Show(sb.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection conn = DBUtils.GetDBConnection())
                    {
                        conn.Open();
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders_Received VALUES (@Date, @Client, @CONum, @Desc, @Amt, @PercInv, @PercRec, @QNum)", conn))
                            {
                                cmd.Parameters.AddWithValue("@Date", dtp_OA_Date.Value);
                                cmd.Parameters.AddWithValue("@Client", txt_OA_CName.Text.Trim());
                                cmd.Parameters.AddWithValue("@CONum", txt_OA_CONum.Text.Trim());
                                cmd.Parameters.AddWithValue("@Desc", txt_OA_Desc.Text.Trim());
                                cmd.Parameters.AddWithValue("@Amt", ddb_OrdersCur.selectedValue + " " + txt_OA_Amt.Text);
                                cmd.Parameters.AddWithValue("@PercInv", pInv);
                                cmd.Parameters.AddWithValue("@PercRec", pRec);

                                string[] temp = ddb_OA_QuoteNum.selectedValue.Split('-');

                                cmd.Parameters.AddWithValue("@QNum", temp[0]);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("New order successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            else
            {
                MessageBox.Show("Please enter a Client Order Number to continue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Cancel Clicked
        private void Btn_OA_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Close Clicked
        private void Btn_OA_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Controls Effects
        //================================================================================================================================================//
        // CLIENT ORDER NUMBER                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_OA_CONum_MouseEnter(object sender, EventArgs e)
        {
            ln_OA_CONum.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OA_CONum_Leave(object sender, EventArgs e)
        {
            ln_OA_CONum.LineColor = Color.Gray;
        }

        private void Txt_OA_CONum_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OA_CONum.Focused)
                ln_OA_CONum.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // DESCRIPTION                                                                                                                                    //
        //================================================================================================================================================//
        private void Txt_OA_Desc_Leave(object sender, EventArgs e)
        {
            ln_OA_Desc.LineColor = Color.Gray;
        }

        private void Txt_OA_Desc_MouseEnter(object sender, EventArgs e)
        {
            ln_OA_Desc.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OA_Desc_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OA_Desc.Focused)
                ln_OA_Desc.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // AMOUNT                                                                                                                                         //
        //================================================================================================================================================//
        private void Txt_OA_Amt_Leave(object sender, EventArgs e)
        {
            ln_OA_Amt.LineColor = Color.Gray;
        }

        private void Txt_OA_Amt_MouseEnter(object sender, EventArgs e)
        {
            ln_OA_Amt.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OA_Amt_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OA_Amt.Focused)
                ln_OA_Amt.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // PERCENTAGE INVOICED                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_OA_PercInv_Leave(object sender, EventArgs e)
        {
            ln_OA_PercInv.LineColor = Color.Gray;
        }

        private void Txt_OA_PercInv_MouseEnter(object sender, EventArgs e)
        {
            ln_OA_PercInv.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OA_PercInv_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OA_PercInv.Focused)
                ln_OA_PercInv.LineColor = Color.Gray;
        }


        //================================================================================================================================================//
        // PERCENTAGE RECEIVED                                                                                                                            //
        //================================================================================================================================================//
        private void Txt_OA_PercRec_Leave(object sender, EventArgs e)
        {
            ln_OA_PercRec.LineColor = Color.Gray;
        }

        private void Txt_OA_PercRec_MouseEnter(object sender, EventArgs e)
        {
            ln_OA_PercRec.LineColor = Color.FromArgb(19, 118, 188);
        }

        private void Txt_OA_PercRec_MouseLeave(object sender, EventArgs e)
        {
            if (!txt_OA_PercRec.Focused)
                ln_OA_PercRec.LineColor = Color.Gray;
        }

        //================================================================================================================================================//
        // CLOSE BUTTON                                                                                                                                   //
        //================================================================================================================================================//
        private void Btn_OA_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_OA_Close.Image = Resources.close_white;
        }

        private void Btn_OA_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_OA_Close.Image = Resources.close_black;
        }


        //================================================================================================================================================//
        // DONE BUTTON                                                                                                                                    //
        //================================================================================================================================================//
        private void Btn_OA_Done_MouseEnter(object sender, EventArgs e)
        {
            btn_OA_Done.ForeColor = Color.White;
        }

        private void Btn_OA_Done_MouseLeave(object sender, EventArgs e)
        {
            btn_OA_Done.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_OA_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_OA_Cancel.ForeColor = Color.White;
        }

        private void Btn_OA_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_OA_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }
        #endregion

        #region ReadOnly Controls
        private void Txt_OA_CCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Txt_OA_CName_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txt_OA_Amt_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) && !(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && !(e.KeyCode == Keys.Back))
                e.SuppressKeyPress = true;
        }
        #endregion

        #region Form Movement
        private void O_Add_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; //If user clicks on main form mouseDown is set to true
            lastLocation = e.Location; //The last location of the mouse click is captured
        }

        private void O_Add_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                //Moves the form to a new location as long as user has mouse click down
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                //Updates the main form with the new position
                this.Update();
            }
        }

        private void O_Add_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion
    }
}
