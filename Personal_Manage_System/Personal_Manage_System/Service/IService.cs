using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Service
{
    interface IService
    {
        /**
         * 
         * 检查是否存在用户名为userName,密码为password的用户
         * 如果有则返回User对象，否则返回null
         * 
         * */
        User checkUser(string userName, string password);

        /**
         * 
         * 查询所有品牌
         * 
         * */
        List<Brand> findBrands();

        /**
         * 
         * 增加品牌
         * 
         * */
        bool addBrand(Brand brand);

        /**
         * 
         * 更新品牌
         * 
         * */
        bool updateBrand(Model.Brand brand);


        /**
         * 
         * 查询所有类别
         * 
         * */
        List<Category> findCategorys();

        /**
         * 
         * 增加类别
         * 
         * */
        bool addCategory(Category category);

        /**
         * 
         * 更新类别
         * 
         * */
        bool updateCategory(Category Category);


        /**
         * 
         * 查询表最大的id
         * 
         * */
        int findMaxId(string  tableName);


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
        bool deleteBusinessModel(string tableName,BusinessModel model);


    }
}
