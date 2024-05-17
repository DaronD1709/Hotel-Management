using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management
{
    public partial class InventoryManagement : Form
    {
        public static int Id = -1;
        public InventoryManagement()
        {
            InitializeComponent();
        }

        private void txtiditems_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (!int.TryParse(textBox.Text, out _))
                {
                    MessageBox.Show("Invalid, please enter only number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = string.Empty;
                }
            }
        }

        private void txtpriceitems_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (!int.TryParse(textBox.Text, out _))
                {
                    MessageBox.Show("Invalid, please enter only number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = string.Empty;
                }
            }
        }

        private void txtnameitems_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                // Kiểm tra xem chuỗi có chứa số hay không
                if (textBox.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Invalid, please enter only letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = string.Empty;
                }
            }
        }

        private void btnaddcustomer_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
            {
                MessageBox.Show("Please fill in all fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        //Check
        private bool VerifyFields()
        {
            if (string.IsNullOrWhiteSpace(txtiditems.Text) ||
                string.IsNullOrWhiteSpace(txtnameitems.Text) ||
                string.IsNullOrWhiteSpace(txtpriceitems.Text) ||
                numberofitems.Value <= 0) // Kiểm tra giá trị của NumericUpDown
            {
                return false;
            }
            return true;
        }

        private void InventoryManagement_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void datagridviewitemlist_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {

        }

        private void datagridviewitemlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(datagridviewitemlist.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtiditems.Text = datagridviewitemlist.Rows[e.RowIndex].Cells[1].Value == DBNull.Value ? "" : datagridviewitemlist.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtnameitems.Text = datagridviewitemlist.Rows[e.RowIndex].Cells[2].Value == DBNull.Value ? "" : datagridviewitemlist.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (datagridviewitemlist.Rows[e.RowIndex].Cells[3].Value != DBNull.Value)
            {
                numberofitems.Value = Convert.ToDecimal(datagridviewitemlist.Rows[e.RowIndex].Cells[3].Value);
            }
            else
            {
                numberofitems.Value = numberofitems.Minimum; // Hoặc giá trị mặc định khác
            }
            txtpriceitems.Text = datagridviewitemlist.Rows[e.RowIndex].Cells[6].Value == DBNull.Value ? "" : datagridviewitemlist.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
