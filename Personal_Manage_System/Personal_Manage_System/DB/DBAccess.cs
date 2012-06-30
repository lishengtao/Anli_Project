using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace DB
{
    public interface DBAccess
    {
        /**
         * 
         * 执行sql，包括 ： 插入、更新、删除
         * 
         * */
       bool excute(string sql);


        /**
         * 
         * 执行带参数的sql，包括 ： 插入、更新、删除
         * 
         * */
       bool excute(string sql, Dictionary<string, Object> parameters);

        /**
         * 
         * 执行查询
         * 
         * */
        SqlDataReader excuteQuery(string sql);

        /**
        * 
        * 执行带参数的查询
        * 
        * */
        SqlDataReader excuteQuery(string sql, Dictionary<string, Object> parameters);

        /**
         * 
         * 执行查询
         * 
         * */
        SqlCeDataReader excuteSqlCeQuery(string sql);

        /**
        * 
        * 执行带参数的查询
        * 
        * */
        SqlCeDataReader excuteSqlCeQuery(string sql, Dictionary<string, Object> parameters);


    }
}
