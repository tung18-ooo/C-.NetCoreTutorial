using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS039_TestAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable("Nhanvien");
        SqlConnection connect;
        SqlDataAdapter adapter;
        DataSet dataSet = new DataSet();

        public MainWindow()
        {
            try
            {
                InitAdapter();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}");
            }
        }
        void InitAdapter()
        {

            var sqlStringBuilder = new SqlConnectionStringBuilder();
            sqlStringBuilder["Server"] = "localhost,1433";
            sqlStringBuilder["Database"] = "xtlab";
            sqlStringBuilder["User Id"] = "sa";
            sqlStringBuilder["Password"] = "password123";
            sqlStringBuilder["TrustServerCertificate"] = true;

            var sqlStringConnection = sqlStringBuilder.ToString();

            //string sqlStringConnection = "Data Source = localhost,1433; Initial Catalog=xtlab;User ID=SA;Password=password123";



            connect = new SqlConnection(sqlStringConnection);
            Console.WriteLine(connect.State);

            connect.Open();
            /*using DbCommand command = new SqlCommand();
            command.Connection = connect;
            command.CommandText = "Select top (5) * from Sanpham";

            var datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Console.WriteLine($"{datareader["TenSanPham"],10} - {datareader["Gia"],8}");
            }


            connect.Close();*/


            //ADO.NET 2
            using var command = new SqlCommand();
            command.Connection = connect;
            command.CommandText = "select DanhmucID, TenDanhMuc, Mota from Danhmuc  where DanhmucID >= @DanhmucID";

            /*var danhmucid = new SqlParameter("@DanhmucID", 5);
            command.Parameters.Add(danhmucid);*/
            //or
            //var danhmucid = command.Parameters.AddWithValue("@DanhmucID",4);
            /*danhmucid.Value = 3; */


            //command.ExecuteReader() -- tra ve nhieu dong

            /*using var sqlreader = command.ExecuteReader();

            if (sqlreader.HasRows)
            {
                while (sqlreader.Read())
                {
                    var id = sqlreader.GetInt32(0);
                    var ten = sqlreader["TenDanhMuc"];
                    var mota = sqlreader["Mota"];
                    Console.WriteLine($"{id} {ten} {mota}");
                }
            }
            else
            {
                Console.WriteLine("Khong co du lieu");
            }
            var datatable = new DataTable();
            datatable.Load(sqlreader);*/


            /*//command.ExecuteScalar() -- tra ve 1 gia tri (1 dong 1 cot)
            command.CommandText = "select count(1) from Sanpham where DanhmucID = @DanhmucID";

            var danhmucid = command.Parameters.AddWithValue("@Danhmucid", 4);

            var returnValue = command.ExecuteScalar();
            Console.WriteLine(returnValue);*/

            //command.ExecuteNonQuery(); -- insert, update, delete

            /*//insert
            command.CommandText = "insert into Shippers (Hoten, Sodienthoai) values (@Hoten,@Sodienthoai)";

            var hoten = command.Parameters.AddWithValue("@Hoten", "");
            var sdt = command.Parameters.AddWithValue("@Sodienthoai", "");

            *//*hoten.Value = "Hoang Tung";
            sdt.Value = "24275675";
            var kq = command.ExecuteNonQuery();
            Console.WriteLine(kq);*//*

            for(int i = 0;i < 4; i++)
            {
                hoten.Value = "Hoten " + i;
                sdt.Value = "23324 " + i;
                var kq = command.ExecuteNonQuery();
                Console.WriteLine(kq);
            }*/

            /*//update
            command.CommandText = "update Shippers set Sodienthoai = '0000' where ShipperID >= 4";
            var kq = command.ExecuteNonQuery();
            Console.WriteLine(kq);
            */


            /*//delete
            command.CommandText = "delete from Shippers where ShipperID >= 10";
            var kq = command.ExecuteNonQuery();
            Console.WriteLine(kq);*/


            /*//StoredProceduce
            command.CommandText = "getproductinfo";
            command.CommandType = CommandType.StoredProcedure;
            var id = new SqlParameter("@id", 0);
            command.Parameters.Add(id);

            id.Value = 3;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var tensp = reader["TenSanPham"];
                var tendm = reader["TenDanhMuc"];

                Console.WriteLine($"{tensp} - {tendm}");
            }*/

            /*//DataTable
            var dataset = new DataSet();
            //dataset.Tables
            var table = new DataTable("MyTable");
            table.Columns.Add("STT");
            table.Columns.Add("HoTen");
            table.Columns.Add("Tuoi");

            table.Rows.Add(1,"Hoang Tung", 23);
            table.Rows.Add(2,"Phan Van Vu", 22);
            table.Rows.Add(3,"Nguyen Van A", 21);

            Console.WriteLine($"Ten bang: {table.TableName}");

            foreach(DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName,20}");
            }
            Console.WriteLine();
            foreach(DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Console.WriteLine($"{row[i],15}");
                }
                *//*Console.Write($"{row[0],20}");
                Console.Write($"{row["HoTen"],20}");
                Console.Write($"{row[2],20}");*//*
                Console.WriteLine();

            }*/

            //adapter
            adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "Nhanvien");

            //SelectCommand
            adapter.SelectCommand = new SqlCommand("select NhanviennID, Ten,Ho from Nhanvien", connect);
            //InsertCommand
            adapter.InsertCommand = new SqlCommand("insert into Nhanvien(Ho,Ten) values (@Ho,@Ten)", connect);
            adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");

            //DeleteCommand
            adapter.DeleteCommand = new SqlCommand("delete from Nhanvien where NhanviennID = @NhanvienID", connect);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanvienID", SqlDbType.Int));
            pr1.SourceColumn = "NhanviennID";
            pr1.SourceVersion = DataRowVersion.Original;

            //UpdateCommand
            adapter.UpdateCommand = new SqlCommand("update Nhanvien Set Ho = @Ho, Ten = @Ten where NhanviennID = @NhanvienID", connect);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NhanvienID", SqlDbType.Int));
            pr2.SourceColumn = "NhanviennID";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.UpdateCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");



            dataSet.Tables.Add(table);




            static void ShowDataTable(DataTable table)
            {
                Console.WriteLine($"Ten bang: {table.TableName}");
                Console.Write($"{"Index",20}");

                foreach (DataColumn column in table.Columns)
                {
                    Console.Write($"{column.ColumnName,20}");
                }
                Console.WriteLine();
                int index = 0;
                foreach (DataRow row in table.Rows)
                {
                    Console.Write($"{index,20}");
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        Console.Write($"{row[i],20}");

                    }
                    /*Console.Write($"{row[0],20}");
                    Console.Write($"{row["HoTen"],20}");
                    Console.Write($"{row[2],20}"); */
                    Console.WriteLine();
                    index++;
                }
            }
        }
        void LoadDataTable()
        {
            table.Rows.Clear();
            adapter.Fill(dataSet);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
            datagrid.DataContext = table.DefaultView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dataSet);
            table.Rows.Clear ();
            adapter.Fill(dataSet);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedItem = (DataRowView)datagrid.SelectedItem;

            if(selectedItem != null)
            {
                selectedItem.Delete();
            }
        }
    }
}