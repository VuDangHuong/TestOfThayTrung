using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyDonHang
{
    public class DatabaseConnection
    {
        private static string connectionString = "Data Source=.;Initial Catalog=QLDONHANG;Integrated Security=True";
        private static DatabaseConnection instance;
        private SqlConnection connection;

        private DatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (OpenConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (OpenConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public int ExecuteNonQuery(string query)
        {
            int result = 0;
            try
            {
                if (OpenConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int result = 0;
            try
            {
                if (OpenConnection())
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (OpenConnection())
                {
                    SqlCommand command = new SqlCommand(procedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi stored procedure: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public int ExecuteStoredProcedureNonQuery(string procedureName, SqlParameter[] parameters = null)
        {
            int result = 0;
            try
            {
                if (OpenConnection())
                {
                    SqlCommand command = new SqlCommand(procedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi stored procedure: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
    }
} 