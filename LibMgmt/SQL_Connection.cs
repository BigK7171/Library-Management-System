using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace LibMgmt
{
    class SQL_Connection
    {
        public static SqlConnection Connection;
        private SqlCommand Command;
        private SqlDataAdapter Adapter;
        public static string ConnectionString = @"Data source = (local)\SQLEXPRESS; Initial Catalog = LibMgmtSys; Integrated Security = True";
        private string CntStr()
        {
            return ConnectionString;
        }
        public static void OpenConnection()
        {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
        }
        public static void CloseConnection()
        {
            Connection.Close();
            Connection.Dispose();
        }
        public DataTable GetDataByUsingCmdText(string query)
        {
            try
            {
                OpenConnection();
                Command = new SqlCommand();
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = query;
                Command.Connection = Connection;
                DataTable Data = new DataTable();
                Adapter = new SqlDataAdapter(Command);
                Adapter.Fill(Data);
                return Data;
            }
            catch(Exception ex)
            {
                throw new Exception("Error when proceeding query: " + ex.Message);               
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable GetDataByUsingSP(string query)
        {
            try
            {
                OpenConnection();
                Command = new SqlCommand();
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.CommandText = query;
                Command.Connection = Connection;                
                DataTable data = new DataTable();
                Adapter = new SqlDataAdapter(Command);
                Adapter.Fill(data);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when proceeding query: " + ex.Message);
            }
            /*finally
            {
                CloseConnection();
            }*/
        }
        public SqlDataReader GetDataReader(string query)
        {
            try
            {
                OpenConnection();
                Command = new SqlCommand();
                Command.CommandType = CommandType.Text;
                Command.CommandText = query;
                Command.Connection = Connection;
                SqlDataReader DataReader = Command.ExecuteReader();
                return DataReader;
            }
            catch(Exception ex)
            {
                throw new Exception("Error when proceeding query: " + ex.Message);
            }            
        }
        public SqlDataReader GetDataReaderByUsingSP(string query)
        {
            try
            {
                OpenConnection();
                Command = new SqlCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = query;
                Command.Connection = Connection;
                SqlDataReader DataReader = Command.ExecuteReader();
                return DataReader;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when proceeding query: " + ex.Message);
            }
        }
        public int ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();              
                Command = new SqlCommand();
                Command.CommandType = CommandType.Text;
                Command.CommandText = query;
                Command.Connection = Connection;
                Command.ExecuteNonQuery();
                SqlDataAdapter ds = new SqlDataAdapter(Command);
                return 1;
            }
            catch 
            {
                return 0;
            }
        }
    }
}
