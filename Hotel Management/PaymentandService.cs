using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Hotel_Management.Bookroom;

namespace Hotel_Management
{
    public partial class PaymentandService : Form
    {
        public PaymentandService()
        {
            InitializeComponent();
            //populate combobox
            PopulateComboBox();
            comboservicelist.SelectedIndexChanged += comboservicelist_SelectedIndexChanged;


            listViewUseService.View = View.Details;

      
        }


        private void btnaddservice_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(numberofitems.Value);
            string namefood = comboservicelist.SelectedItem.ToString();
            string priceText = txtpriceitems.Text;

            // Kiểm tra xem các đầu vào có hợp lệ không
            if (string.IsNullOrEmpty(namefood) || string.IsNullOrEmpty(priceText) || amount <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuyển đổi giá từ chuỗi sang số
            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính tổng tiền
            decimal total = price * amount;

            // Tạo số thứ tự cho mục mới
            int stt = listViewUseService.Items.Count + 1;

            // Tạo một mảng các chuỗi để thêm vào ListView
            string[] row = { stt.ToString(), namefood, price.ToString(), amount.ToString(), (price * amount).ToString(), total.ToString() };

            // Tạo một đối tượng ListViewItem từ mảng chuỗi
            ListViewItem listViewItem = new ListViewItem(row);

            // Thêm ListViewItem vào ListView
            listViewUseService.Items.Add(listViewItem);

            // Cập nhật lại số thứ tự cho tất cả các mục
            UpdateListViewIndices();
        }

        private void UpdateListViewIndices()
        {
            for (int i = 0; i < listViewUseService.Items.Count; i++)
            {
                listViewUseService.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }



        private void PaymentandService_Load(object sender, EventArgs e)
        {

        }

        // xử lí pupulate data
        public class InventoryData
        {
            MY_DB mydb = new MY_DB();

            public List<string> GetRoomKinds()
            {
                List<string> names = new List<string>();
                try
                {
                    mydb.openConnection();
                    string query = "SELECT DISTINCT [Name] FROM [HotelData].[dbo].[Inventory]";
                    SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        names.Add(reader["Name"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    mydb.closeConnection();
                }

                return names;
            }

            public DataRow GetitemDetails(string itemName)
            {
                DataTable table = new DataTable();
                try
                {
                    mydb.openConnection();
                    string query = "SELECT  [Price] FROM [HotelData].[dbo].[Inventory] WHERE [Name] = @Name";
                    SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
                    cmd.Parameters.AddWithValue("@Name", itemName);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    mydb.closeConnection();
                }

                if (table.Rows.Count > 0)
                    return table.Rows[0];
                else
                    return null;
            }

        }


        // Xử lí 

        InventoryData inventoryData = new InventoryData();
        public void PopulateComboBox()
        {
            List<string> names = inventoryData.GetRoomKinds();
            comboservicelist.DataSource = names;
        }

        private void comboservicelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecteditemName = comboservicelist.SelectedItem.ToString();
            DataRow inventoryDetails = inventoryData.GetitemDetails(selecteditemName);

            if (inventoryDetails != null)
            {
                txtpriceitems.Text = inventoryDetails["Price"].ToString();
            }
        }
    }
}
