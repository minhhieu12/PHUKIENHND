using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHUKIENHN.DAO
{
    class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connectionString = @"Data Source=NGHIAPH\SQLEXPRESS;Initial Catalog=PHUKIENHN;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisPara)
                    {
                        command.Parameters.AddWithValue(item, lisPara[i]);
                        i++;
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();

            }

            return data;

        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {

            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisPara)
                    {
                        command.Parameters.AddWithValue(item, lisPara[i]);
                        i++;
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();

            }

            return data;

        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {

            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisPara)
                    {
                        command.Parameters.AddWithValue(item, lisPara[i]);
                        i++;
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();

            }

            return data;

        }
    }
}
