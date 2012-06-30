using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Factory;
using System.Data.SqlServerCe;

namespace DB
{
    public class SqlServerDBAccess : DBAccess
    {
        SqlConnection conn = null;

        public SqlServerDBAccess()
        {
            conn = SysFactory.getDBManager().getConnection();
        }

        /**
         * 
         * 执行sql，包括 ： 插入、更新、删除
         * 
         * */
        public bool excute(string sql) 
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = sql;
                if (-1 != command.ExecuteNonQuery())
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if(command != null)
                    command.Dispose();
            }


        }


        /**
         * 
         * 执行带参数的sql，包括 ： 插入、更新、删除
         * 
         * */
        public bool excute(string sql, Dictionary<string, Object> parameters)
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = sql;

                foreach (KeyValuePair<string, Object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                if (-1 != command.ExecuteNonQuery())
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if(command != null)
                    command.Dispose();
            }
        }

        /**
         * 
         * 执行查询
         * 
         * */
        public SqlDataReader excuteQuery(string sql)
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = sql;
                return command.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
            }
        }

        /**
        * 
        * 执行带参数的查询
        * 
        * */
        public SqlDataReader excuteQuery(string sql, Dictionary<string, Object> parameters)
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = sql;

                foreach (KeyValuePair<string, Object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                return command.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
            }
        }

        /**
        * 
        * 执行查询
        * 
        * */
        public SqlCeDataReader excuteSqlCeQuery(string sql)
        {
            return null;
        }

        /**
        * 
        * 执行带参数的查询
        * 
        * */
        public SqlCeDataReader excuteSqlCeQuery(string sql, Dictionary<string, Object> parameters)
        {
            return null;
        }


    }
}
