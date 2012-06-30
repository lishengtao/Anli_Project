using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Service
{
    interface ICommonService
    {
        /**
         * 
         * 查询表最大的id
         * 
         * */
        int findMaxId(string tableName);


        /**
         * 
         * 判断在table表中，colName列是否存在值value，存在返回true，否则返回false
         * 
         * */
        bool isInTable(string table, string colName, object value);

        /**
         * 
         * 根据列名字以及value查找表中id
         * 
         * */
        int findIdByColomn(string table, string colName, object value);

        /**
         * 
         * 根据model 的Id删除
         * 
         * */
        bool deleteBusinessModel(string tableName, BusinessModel model);


    }
}
