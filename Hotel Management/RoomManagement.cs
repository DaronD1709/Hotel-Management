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
    public partial class RoomManagement : Form
    {
        public static int Id = -1;
        public RoomManagement()
        {
            InitializeComponent();
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {

        }

        private void txtcardidcustomer_TextChanged(object sender, EventArgs e)
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

        private void btnaddcustomer_Click(object sender, EventArgs e)
        {
            if (!VerifyFields())
            {
                MessageBox.Show("Please fill in all fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        // Check Info 
        private bool VerifyFields()
        {


            if (string.IsNullOrWhiteSpace(txtnameroom.Text) ||
                string.IsNullOrWhiteSpace(txtpriceroom.Text) ||
                string.IsNullOrWhiteSpace(txtidroom.Text) ||
                combotyperoom.SelectedIndex == -1 
               ) // Kiểm tra tuổi hợp lệ
            {
                return false;
            }
            return true;
        }

        private void txtnameroom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void datagridviewroomlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtidroom.Text = datagridviewroomlist.Rows[e.RowIndex].Cells[0].Value == DBNull.Value ? "" : datagridviewroomlist.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtnameroom.Text = datagridviewroomlist.Rows[e.RowIndex].Cells[1].Value == DBNull.Value ? "" : datagridviewroomlist.Rows[e.RowIndex].Cells[1].Value.ToString();
           
            if (datagridviewroomlist.Rows[e.RowIndex].Cells[2].Value.ToString() == "Male")
            {
                combostateroom.SelectedIndex = 1; // Sets the selected item to the first item
            }
            else
            {
                combostateroom.SelectedIndex = 0; // Sets the selected item to the second item
            }

            if (datagridviewroomlist.Rows[e.RowIndex].Cells[3].Value.ToString() == "Single Room") 


            {
                combotyperoom.SelectedIndex = 1; // Sets the selected item to the first item
            }
            else if (datagridviewroomlist.Rows[e.RowIndex].Cells[3].Value.ToString() == "Double Room")
            {
                combotyperoom.SelectedIndex = 2; // Sets the selected item to the first item
            }
            else
            {
                combotyperoom.SelectedIndex = 0; // Sets the selected item to the second item
            }
            txtpriceroom.Text = datagridviewroomlist.Rows[e.RowIndex].Cells[4].Value == DBNull.Value ? "" : datagridviewroomlist.Rows[e.RowIndex].Cells[4].Value.ToString();

        }
    }
}
