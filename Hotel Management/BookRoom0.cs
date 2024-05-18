using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management
{
    internal class BookRoom0
    {
        MY_DB mydb = new MY_DB();
        public DataTable getInfoBookRoom(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertBookroom(int idroom, string namecustomer, string idcard, string roomtype, DateTime timecheckin, DateTime timecheckout, string roomname, string roomstate, int idbookroom)
        {

            SqlCommand command = new SqlCommand("INSERT INTO dbo.BookRoomView (ID_Room, CustomerName, IDcard,RoomKind, Timecheckin, Timecheckout, RoomName,RoomState,ID_BookRoom)" +
             "VALUES (@idr, @cusname, @Idcard,@kind, @timein, @timeout, @rname, @rstate, @idbk)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = idroom;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = namecustomer;
            command.Parameters.Add("@Idcard", SqlDbType.VarChar).Value = idcard;
            command.Parameters.Add("@kind", SqlDbType.VarChar).Value = roomtype;
            command.Parameters.Add("@timein", SqlDbType.DateTime).Value = timecheckin;
            command.Parameters.Add("@timeout", SqlDbType.DateTime).Value = timecheckout;
            command.Parameters.Add("@rname", SqlDbType.VarChar).Value = roomname;
            command.Parameters.Add("@rstate", SqlDbType.VarChar).Value = roomstate;
            command.Parameters.Add("@idbk", SqlDbType.VarChar).Value = idbookroom;

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool DeleteCustomer(int idcustomer)
        {
            // Câu lệnh SQL để xóa khách hàng dựa trên ID
            SqlCommand command = new SqlCommand("DELETE FROM   dbo.BookRoomView WHERE ID_BookRoom = @id", mydb.getConnection);

            // Gán giá trị cho tham số
            command.Parameters.Add("@id", SqlDbType.Int).Value = idcustomer;

            // Mở kết nối và thực thi câu lệnh
            mydb.openConnection();

            // Kiểm tra xem câu lệnh thực thi thành công không
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
