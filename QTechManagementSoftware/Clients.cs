using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QTechManagementSoftware.Properties;

namespace QTechManagementSoftware
{
    public partial class Clients : Form
    {
        private DataTable dt;
        private BindingSource bs = new BindingSource();
        private int totClients, curClient;
        private bool isReadOnly;
        private bool localInt; //False = Local; True = Int
        private Home frmHome;
        private string selectedClientName, selectedClientCode;

        public Clients()
        {
            InitializeComponent();
        }


        //================================================================================================================================================//
        // LOAD CLIENT FORM                                                                                                                               //
        //================================================================================================================================================//
        private void Clients_Load(object sender, EventArgs e)
        {
            isReadOnly = true;

            frmHome = (Home)this.Parent.Parent;

            curClient = 0;
            dgv_Clients.DataSource = bs;

            if (frmHome.GetSelectedButton().Equals("Local"))
            {
                localInt = false;
                LoadLocalClients();
            }
            else if (frmHome.GetSelectedButton().Equals("Int"))
            {
                localInt = true;
                LoadIntClients();               
            }

            if (dgv_Clients.Rows.Count > 0 && !string.IsNullOrEmpty(dgv_Clients.Rows[0].Cells[0].Value as string))
                DGV_CellClick(dgv_Clients, new DataGridViewCellEventArgs(0, 0));
        }

        private void LoadLocalClients()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clients", conn);
                da.Fill(dt);
            }

            bs.DataSource = dt;
            totClients = dt.Rows.Count;

            if (totClients == 0)
                btn_ClientEdit.Enabled = false;
            else if (totClients != 0 && !btn_ClientEdit.Enabled)
                btn_ClientEdit.Enabled = true;
        }

        private void LoadIntClients()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();

                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Int_Clients", conn);
                da.Fill(dt);
            }

            bs.DataSource = dt;
            totClients = dt.Rows.Count;

            if (totClients == 0)
                btn_ClientEdit.Enabled = false;
            else if (totClients != 0 && !btn_ClientEdit.Enabled)
                btn_ClientEdit.Enabled = true;
        }

        //================================================================================================================================================//
        // CELL CLICK IN DATAGRIDVIEW                                                                                                                     //
        //================================================================================================================================================//
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string str = dgv_Clients.Rows[e.RowIndex].Cells["Code"].Value.ToString();

                DataTable tempDT;

                if (!localInt)
                {
                    using (SqlConnection conn = DBUtils.GetDBConnection())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Clients WHERE Code = '" + str + "'";
                            tempDT = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(tempDT);
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = DBUtils.GetDBConnection())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Int_Clients WHERE Code = '" + str + "'";
                            tempDT = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(tempDT);
                        }
                    }
                }                

                foreach (DataRow row in tempDT.Rows)
                {
                    txt_ClientCode.Text = row["Code"].ToString().Trim();
                    txt_ClientName.Text = row["Name"].ToString().Trim();
                }
            }
        }

        private void Dgv_Clients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedClientCode = dgv_Clients[0, e.RowIndex].Value.ToString().Trim();
            selectedClientName = dgv_Clients[1, e.RowIndex].Value.ToString().Trim();

            if (!localInt)
                frmHome.LocalClientDoubleClick(selectedClientCode, selectedClientName);
            else
                frmHome.IntClientDoubleClick(selectedClientCode, selectedClientName);
        }


        //================================================================================================================================================//
        // CLIENTS ADD BUTTON                                                                                                                             //
        //================================================================================================================================================//
        private void Btn_ClientAdd_Click(object sender, EventArgs e)
        {
            isReadOnly = false;

            btn_ClientAdd.Visible = false;
            btn_ClientEdit.Visible = false;
            btn_DoneAdd.Visible = true;
            btn_Cancel.Visible = true;

            txt_ClientName.Text = string.Empty;
            txt_ClientName.Focus();

            int newClientCode = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                {
                    int x = Convert.ToInt32(dr["Code", DataRowVersion.Original].ToString().Trim().Remove(0, 4));
                    if (x > newClientCode)
                        newClientCode = x;
                }
                else
                {
                    int x = Convert.ToInt32(dr["Code"].ToString().Trim().Remove(0, 4));
                    if (x > newClientCode)
                        newClientCode = x;
                }
            }
            newClientCode++;

            if (!localInt)
                txt_ClientCode.Text = "QTL" + newClientCode.ToString("000");
            else txt_ClientCode.Text = "QTI" + newClientCode.ToString("000");
        }

        private void Btn_ClientAdd_MouseEnter(object sender, EventArgs e)
        {
            btn_ClientAdd.ForeColor = Color.White;
            btn_ClientAdd.Image = Resources.add_white;
        }

        private void Btn_ClientAdd_MouseLeave(object sender, EventArgs e)
        {
            btn_ClientAdd.ForeColor = Color.FromArgb(64, 64, 64);
            btn_ClientAdd.Image = Resources.add_grey;
        }


        //================================================================================================================================================//
        // CLIENTS EDIT BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_ClientEdit_Click(object sender, EventArgs e)
        {
            btn_ClientAdd.Visible = false;
            btn_ClientEdit.Visible = false;
            btn_DoneEdit.Visible = true;
            btn_Cancel.Visible = true;

            isReadOnly = false;

            txt_ClientName.Focus();
        }

        private void Btn_ClientEdit_MouseEnter(object sender, EventArgs e)
        {
            btn_ClientEdit.ForeColor = Color.White;
            btn_ClientEdit.Image = Resources.edit_white;
        }

        private void Btn_ClientEdit_MouseLeave(object sender, EventArgs e)
        {
            btn_ClientEdit.ForeColor = Color.FromArgb(64, 64, 64);
            btn_ClientEdit.Image = Resources.edit_grey;
        }


        //================================================================================================================================================//
        // DONE ADDING BUTTON                                                                                                                             //
        //================================================================================================================================================//
        private void Btn_DoneAdd_Click(object sender, EventArgs e)
        {
            string newClientCode = txt_ClientCode.Text.Trim();

            StringBuilder sb = new StringBuilder().Append("Are you sure you want to add client with code: ").Append(newClientCode).Append("?");

            if (MessageBox.Show(sb.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();

                    try
                    {
                        if (!localInt)
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Clients VALUES (@Code, @Name)", conn))
                            {
                                cmd.Parameters.AddWithValue("@Code", newClientCode);
                                cmd.Parameters.AddWithValue("@Name", txt_ClientName.Text.Trim());
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("New client successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            LoadLocalClients();
                            
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Int_Clients VALUES (@Code, @Name)", conn))
                            {
                                cmd.Parameters.AddWithValue("@Code", newClientCode);
                                cmd.Parameters.AddWithValue("@Name", txt_ClientName.Text.Trim());
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("New client successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            LoadIntClients();
                        }

                        dgv_Clients.CurrentCell = dgv_Clients.Rows[dgv_Clients.Rows.Count - 1].Cells[0];

                        if (dgv_Clients.Rows.Count != 1)
                        {
                            dgv_Clients.ClearSelection();
                            int index = dgv_Clients.Rows.Count - 1;
                            dgv_Clients.Rows[index].Selected = true;
                            dgv_Clients.FirstDisplayedScrollingRowIndex = index;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        btn_ClientAdd.Visible = true;
                        btn_ClientEdit.Visible = true;
                        btn_DoneAdd.Visible = false;
                        btn_Cancel.Visible = false;
                        isReadOnly = true;
                    }
                }
            }
        }
        private void Btn_DoneAdd_MouseEnter(object sender, EventArgs e)
        {
            btn_DoneAdd.ForeColor = Color.White;
        }

        private void Btn_DoneAdd_MouseLeave(object sender, EventArgs e)
        {
            btn_DoneAdd.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // DONE EDITING BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_DoneEdit_Click(object sender, EventArgs e)
        {
            string clientCode = dgv_Clients.CurrentRow.Cells[0].Value.ToString().Trim();

            StringBuilder sb = new StringBuilder().Append("Are you sure you want to edit client with code: ").Append(clientCode).Append("?");

            if (MessageBox.Show(sb.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();
                    try
                    {
                        if (!localInt)
                        {
                            using (SqlCommand cmd = new SqlCommand("UPDATE Clients SET Name = @Name WHERE Code = @Code", conn))
                            {
                                cmd.Parameters.AddWithValue("@Name", txt_ClientName.Text.Trim());
                                cmd.Parameters.AddWithValue("@Code", clientCode);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Client successfully Updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadLocalClients();
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("UPDATE Int_Clients SET Name = @Name WHERE Code = @Code", conn))
                            {
                                cmd.Parameters.AddWithValue("@Name", txt_ClientName.Text.Trim());
                                cmd.Parameters.AddWithValue("@Code", clientCode);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Client successfully Updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadIntClients();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        btn_DoneEdit.Visible = false;
                        btn_Cancel.Visible = false;
                        btn_ClientAdd.Visible = true;
                        btn_ClientEdit.Visible = true;

                        isReadOnly = true;
                    }
                }
            }
        }

        private void Btn_DoneEdit_MouseEnter(object sender, EventArgs e)
        {
            btn_DoneEdit.ForeColor = Color.White;
        }

        private void Btn_DoneEdit_MouseLeave(object sender, EventArgs e)
        {
            btn_DoneEdit.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CANCEL BUTTON                                                                                                                                  //
        //================================================================================================================================================//
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            isReadOnly = true;

            btn_DoneAdd.Visible = false;
            btn_DoneEdit.Visible = false;
            btn_Cancel.Visible = false;
            btn_ClientEdit.Visible = true;
            btn_ClientAdd.Visible = true;

            DGV_CellClick(dgv_Clients, new DataGridViewCellEventArgs(0, 0));
            if (dgv_Clients.Rows.Count != 1)
            {
                dgv_Clients.ClearSelection();
                dgv_Clients.Rows[0].Selected = true;
                dgv_Clients.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void Btn_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_Cancel.ForeColor = Color.White;
        }

        private void Btn_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_Cancel.ForeColor = Color.FromArgb(64, 64, 64);
        }


        //================================================================================================================================================//
        // CLIENTS PREVIOUS BUTTON                                                                                                                        //
        //================================================================================================================================================//
        private void Btn_PrevClient_Click(object sender, EventArgs e)
        {
            if ((curClient - 1) > 0)
            {
                dgv_Clients.Rows[curClient].Selected = false;
                --curClient;

                if (!string.IsNullOrEmpty(dgv_Clients.Rows[curClient].Cells[0].Value as string))
                    DGV_CellClick(dgv_Clients, new DataGridViewCellEventArgs(0, curClient));

                dgv_Clients.Rows[curClient].Selected = true;
            }
            else if ((curClient - 1) == 0)
            {
                btn_PrevClient.Enabled = false;
                dgv_Clients.Rows[curClient].Selected = false;
                --curClient;

                if (!string.IsNullOrEmpty(dgv_Clients.Rows[curClient].Cells[0].Value as string))
                    DGV_CellClick((object)dgv_Clients, new DataGridViewCellEventArgs(0, curClient));

                dgv_Clients.Rows[curClient].Selected = true;
            }
            if (curClient != totClients && !btn_NextClient.Enabled)
                btn_NextClient.Enabled = true;
        }

        private void Btn_PrevClient_MouseEnter(object sender, EventArgs e)
        {
            btn_PrevClient.Image = Resources.back_white;
        }

        private void Btn_PrevClient_MouseLeave(object sender, EventArgs e)
        {
            btn_PrevClient.Image = Resources.back_black;
        }


        //================================================================================================================================================//
        // CLIENTS NEXT BUTTON                                                                                                                            //
        //================================================================================================================================================//
        private void Btn_NextClient_Click(object sender, EventArgs e)
        {
            if ((curClient + 1) < (totClients - 1))
            {
                dgv_Clients.Rows[curClient].Selected = false;
                ++curClient;

                if (!string.IsNullOrEmpty(dgv_Clients.Rows[curClient].Cells[0].Value as string))
                    DGV_CellClick(dgv_Clients, new DataGridViewCellEventArgs(0, curClient));

                dgv_Clients.Rows[curClient].Selected = true;
            }
            else if ((curClient + 1) == (totClients - 1))
            {
                btn_NextClient.Enabled = false;
                dgv_Clients.Rows[curClient].Selected = false;
                ++curClient;

                if (!string.IsNullOrEmpty(dgv_Clients.Rows[curClient].Cells[0].Value as string))
                    DGV_CellClick(dgv_Clients, new DataGridViewCellEventArgs(0, curClient));

                dgv_Clients.Rows[curClient].Selected = true;
            }
            if (curClient != 0 && !btn_PrevClient.Enabled)
                btn_PrevClient.Enabled = true;
        }

        private void Btn_NextClient_MouseEnter(object sender, EventArgs e)
        {
            btn_NextClient.Image = Resources.forward_white;
        }

        private void Btn_NextClient_MouseLeave(object sender, EventArgs e)
        {
            btn_NextClient.Image = Resources.forawrd_black;
        }


        //================================================================================================================================================//
        // DATAGRIDVIEW FILTER AND SORT                                                                                                                   //
        //================================================================================================================================================//
        private void DGV_Clients_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = dgv_Clients.FilterString;

            if (dgv_Clients.Rows.Count > 0 && !string.IsNullOrEmpty(dgv_Clients.Rows[0].Cells[0].Value as string))
                DGV_CellClick(dgv_Clients, new DataGridViewCellEventArgs(0, 0));
        }

        private void DGV_Clients_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = dgv_Clients.SortString;

            if (dgv_Clients.Rows.Count > 0 && !string.IsNullOrEmpty(dgv_Clients.Rows[0].Cells[0].Value as string))
                DGV_CellClick(dgv_Clients, new DataGridViewCellEventArgs(0, 0));
        }


        //================================================================================================================================================//
        // READONLY ON TEXTBOXES                                                                                                                          //
        //================================================================================================================================================//
        private void Txt_ClientCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (isReadOnly)
                e.SuppressKeyPress = true;
        }

        private void Txt_ClientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (isReadOnly)
                e.SuppressKeyPress = true;
        }
    }
}
