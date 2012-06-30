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
    class ServiceImpl : IService
    {
        DBAccess dbAccess = null;

        public ServiceImpl()
        {
            dbAccess = new SqlCeDBAccess();
        }

        /**
         * 
         * 检查是否存在用户名为userName,密码为password的用户
         * 如果有则返回User对象，否则返回null
         * 
         * */
        public User checkUser(string userName, string password)
        {
            return null;
        }

        /**
         * 
         * 查询所有品牌
         * 
         * */
        public List<Brand> findBrands()
        {
            SqlCeDataReader dr = null;

            List<Brand> brands = new List<Brand>();

            try
            {
                string sql = "select id, brand_name from brand";

                dr = dbAccess.excuteSqlCeQuery(sql);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                       Brand brand = new Brand();

                       brand.Id = dr.GetInt32(0);

                       if (dr.IsDBNull(1))
                           brand.setBrandName("");
                       else
                           brand.setBrandName(dr.GetString(1));


                       brands.Add(brand);
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

            return brands;
        }


        /**
         * 
         * 增加品牌
         * 
         * */
        public bool addBrand(Brand brand)
        {

            try
            {
                string sql = "insert into brand (brand_name) values(@brandName)";

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@brandName", brand.getBrandName());

                dbAccess.excute(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
            
        }

        /**
         * 
         * 更新品牌
         * 
         * */
        public bool updateBrand(Brand brand)
        {
            try
            {
                string sql = "update brand set brand_name = @brandName where id = @id";

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@brandName", brand.getBrandName());
                parameters.Add("@id", brand.Id);

                dbAccess.excute(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
        }



        /**
         * 
         * 查询所有品牌
         * 
         * */
        public List<Category> findCategorys()
        {
            SqlCeDataReader dr = null;

            List<Category> categorys = new List<Category>();

            try
            {
                string sql = "select a.id, a.category_name, a.net_rate, b.brand_name, a.brand from category a , brand b where a.brand = b.id";

                dr = dbAccess.excuteSqlCeQuery(sql);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Category category = new Category();

                        category.Id = dr.GetInt32(0);

                        if (dr.IsDBNull(1))
                            category.setCategoryName("");
                        else
                            category.setCategoryName(dr.GetString(1));

                        if (dr.IsDBNull(2))
                            category.setNetRate(float.NaN);
                        else
                            category.setNetRate((float)dr.GetDouble(2));

                        if (dr.IsDBNull(3))
                            category.setBrandName("");
                        else
                            category.setBrandName(dr.GetString(3));

                        category.setBrandId(dr.GetInt32(4));

                        categorys.Add(category);
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

            return categorys;
        }

        /**
         * 
         * 增加品牌
         * 
         * */
        public bool addCategory(Category category)
        {
            try
            {
               // int brandId = this.findIdByColomn("brand","brand_name",category.getBrandName());

                string sql = "insert into category (category_name,net_rate,brand) values(@categoryName,@netRate,@brandId)";

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@categoryName", category.getCategoryName());
                parameters.Add("@netRate", category.getNetRate());
                parameters.Add("@brandId", category.getBrandId());


                dbAccess.excute(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
        }

        /**
         * 
         * 更新品牌
         * 
         * */
        public bool updateCategory(Category Category)
        {
            try
            {
                string sql = "update category set category_name = @categoryName, net_rate = @netRate, brand = @brandId where id = @id";

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@categoryName", Category.getCategoryName());
                parameters.Add("@netRate", Category.getNetRate());
                parameters.Add("@brandId", Category.getBrandId());
                parameters.Add("@id", Category.Id);

                dbAccess.excute(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
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
