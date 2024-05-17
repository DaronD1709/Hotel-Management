﻿using System;
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
    public partial class CustomerManagement : Form
    {
        public CustomerManagement()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnamecustomer_TextChanged(object sender, EventArgs e)
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

        private void txtnationcustomer_TextChanged(object sender, EventArgs e)
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

        private void txtphonecustomer_TextChanged(object sender, EventArgs e)
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
            int born_year = dobpicker.Value.Year;
            int this_year = DateTime.Now.Year;

            if (string.IsNullOrWhiteSpace(txtphonecustomer.Text) ||
                string.IsNullOrWhiteSpace(txtnationcustomer.Text) ||
                string.IsNullOrWhiteSpace(txtnamecustomer.Text) ||
                string.IsNullOrWhiteSpace(txtcardidcustomer.Text) ||
                combogendercustomer.SelectedIndex == -1 || // Kiểm tra ComboBox đã được chọn
                dobpicker.Value == null || // Kiểm tra DateTimePicker có giá trị
                (this_year - born_year) < 10 || (this_year - born_year) > 100) // Kiểm tra tuổi hợp lệ
            {
                return false;
            }
            return true;
        }
    }
}