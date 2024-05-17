using Hotel_Management.Resources;
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
    public partial class AdminMenu : Form
    {
        private bool isCollapsed;
        private bool ismenu;
        private Form currentChildForm;
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                guna2Panel1.Width += 15;
                if (guna2Panel1.Size == guna2Panel1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                guna2Panel1.Width -= 15;
                if (guna2Panel1.Size == guna2Panel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnshowmenu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnmanacustomer_Click(object sender, EventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement();
            customerManagement.ShowDialog();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btncreateroom_Click(object sender, EventArgs e)
        {
            RoomManagement roomManagement = new RoomManagement();   
            roomManagement.ShowDialog();    
        }

        private void btnbookroom_Click(object sender, EventArgs e)
        {
            Bookroom bookroom = new Bookroom();
            bookroom.ShowDialog();  
        }

        private void btnmanaemployee_Click(object sender, EventArgs e)
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();   
            employeeManagement.ShowDialog();
        }

        private void btnmanainventory_Click(object sender, EventArgs e)
        {
            InventoryManagement inventoryManagement = new InventoryManagement();    
            inventoryManagement.ShowDialog();
        }

        private void btnschedule_Click(object sender, EventArgs e)
        {
            ScheduleManagement scheduleManagement = new ScheduleManagement();
            scheduleManagement.ShowDialog();
        }

        private void btnmanaitems_Click(object sender, EventArgs e)
        {
           
        }

        private void btnstatistical_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}
