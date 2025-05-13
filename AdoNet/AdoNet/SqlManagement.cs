using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System.Data;
using Microsoft.Data.SqlClient;
using SqlException = System.Data.SqlClient.SqlException;
using SqlDataReader = System.Data.SqlClient.SqlDataReader;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace AdoNet
{

    public class SqlManagement
    {
        public string connectionString { get; set; }

        public SqlManagement(string connectionString)
        {
            this.connectionString = connectionString;
        }

        [Obsolete]
        public int InsertCatrogy(string catgoryName)
        {
            string query = "insert into dbo.Category VALUES (@name)";
            using(SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = catgoryName;
                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowsAffected;
            }

        }


        public int InsertProduct(int Category_ID, string Product_Name, string Product_Description,int Price, string image_Path)
        {
            string query = "insert into dbo.Products VALUES (@Category_ID , @Product_Name, @Product_Description , @Price , @image_Path)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Category_ID", SqlDbType.VarChar, 50).Value = Category_ID;
                cmd.Parameters.Add("@Product_Name", SqlDbType.VarChar, 50).Value = Product_Name;
                cmd.Parameters.Add("@Product_Description", SqlDbType.VarChar, 50).Value = Product_Description;
                cmd.Parameters.Add("@Price", SqlDbType.VarChar, 50).Value = Price;
                cmd.Parameters.Add("@image_Path", SqlDbType.VarChar, 50).Value = image_Path;
                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowsAffected;
            }

        }

        public void readTable(string tableName)
        {
            string query = "select * from dbo." + tableName;
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader[i] + "\t");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }

}
