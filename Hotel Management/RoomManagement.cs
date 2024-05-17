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
                combostateroom.SelectedIndex == -1 ||// Kiểm tra ComboBox đã được chọn
                comboidroom.SelectedIndex == -1 ||
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
    }
}
