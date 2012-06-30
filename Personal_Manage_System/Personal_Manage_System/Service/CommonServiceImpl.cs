using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;
using Model;
using System.Data.SqlServerCe;
using Exceptions;

namespace Service
{
    class CommonServiceImpl : ICommonService
    {
        protected DBAccess dbAccess = null;

        public CommonServiceImpl()
        {
            dbAccess = new SqlCeDBAccess();
        }

        /**
         * 
         * 查询表最大的id
         * 
         * */
        public int findMaxId(string tableName)
        {
            SqlCeDataReader dr = null;
            int maxId = -1;

            try
            {
                string sql = "select max(id) from "+ tableName;

                dr = dbAccess.excuteSqlCeQuery(sql);
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        maxId = dr.GetInt32(0);
                    }
                    else
                    {
                        maxId = 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
            finally
            {
                if (null != dr)
                    dr.Close();
            }

            return maxId;
        }




        /**
         * 
         * 判断在table表中，colName列是否存在值value，存在返回true，否则返回false
         * 
         * */
        public bool isInTable(string table, string colName, object value)
        {

            SqlCeDataReader dr = null;

            try
            {
                string sql = "select * from "+table +" where " +colName+" = @value";

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@value", value);

                dr = dbAccess.excuteSqlCeQuery(sql, parameters);
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
            finally
            {
                if (null != dr)
                    dr.Close();
            }

            return false;
        }


        /**
         * 
         * 根据列名字以及value查找表中id, 返回id，如果没找到id，返回-1
         * 
         * */
        public int findIdByColomn(string table, string colName, object value)
        {
            SqlCeDataReader dr = null;

            try
            {
                string sql = "select id from " + table + " where " + colName + " = @value";

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@value", value);

                dr = dbAccess.excuteSqlCeQuery(sql, parameters);
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        return dr.GetInt32(0);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
            finally
            {
                if (null != dr)
                    dr.Close();
            }

            return -1;
        }

        /**
         * 
         * 根据model 的Id删除
         * 
         * */
        public bool deleteBusinessModel(string tableName,BusinessModel model)
        {
            try
            {
                string sql = "delete from " + tableName + " where id =@id";

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();
                parameters.Add("@id", model.Id);

                dbAccess.excute(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
        }

    }
}
