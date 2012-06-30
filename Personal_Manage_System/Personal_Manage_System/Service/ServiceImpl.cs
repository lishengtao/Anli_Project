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
        * 查询所有客户
        * 
        * */
        public List<Customer> findCustomers()
        {

            SqlCeDataReader dr = null;

            List<Customer> customers = new List<Customer>();

            try
            {
                StringBuilder builder = new StringBuilder("select ");
                builder.Append("id,");
                builder.Append("name,");
                builder.Append("card_no,");
                builder.Append("birthday,");
                builder.Append("profession,");
                builder.Append("isMarried,");
                builder.Append("income_level,");
                builder.Append("family_level,");
                builder.Append("first_contact_time,");
                builder.Append("make_card_time,");
                builder.Append("extend_card_time,");
                builder.Append("extend_card_num,");
                builder.Append("telephone,");
                builder.Append("email,");
                builder.Append("type,");
                builder.Append("level");
                builder.Append(" from customer");

                dr = dbAccess.excuteSqlCeQuery(builder.ToString());
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Customer customer = new Customer();

                        customer.Id = dr.GetInt32(0);          //id

                        if (dr.IsDBNull(1))                    //name
                            customer.name = "";
                        else
                            customer.name =dr.GetString(1);

                        if(dr.IsDBNull(2))                     //card_no
                            customer.cardNo = "";
                        else 
                            customer.cardNo = dr.GetString(2);

                        if(dr.IsDBNull(3))                     //birthday
                            customer.birthday = DateTime.MaxValue;
                        else 
                            customer.birthday = dr.GetDateTime(3);

                        if(dr.IsDBNull(4))                     //profession
                            customer.profession = "";
                        else 
                            customer.profession = dr.GetString(4);

                        if(dr.IsDBNull(5))                     //isMarried
                            customer.isMarried = false;
                        else 
                            customer.isMarried = dr.GetBoolean(5);

                         if(dr.IsDBNull(6))                    //income_level
                            customer.incomeLevel = IncomeLevel.GOOD;
                        else 
                            customer.incomeLevel = (IncomeLevel)dr.GetInt32(6);

                         if(dr.IsDBNull(7))                    //family_level
                            customer.familyLevel = FamilyLevel.MEDIUM;
                        else 
                            customer.familyLevel = (FamilyLevel)dr.GetInt32(7);

                         if(dr.IsDBNull(8))                    //first_contact_time
                            customer.firstContactTime = DateTime.MaxValue;
                        else 
                            customer.firstContactTime = dr.GetDateTime(8);

                         if(dr.IsDBNull(9))                    //make_card_time
                            customer.makeCardTime = DateTime.MaxValue;
                        else 
                            customer.makeCardTime = dr.GetDateTime(9);

                         if(dr.IsDBNull(10))                   //extend_card_time
                            customer.extendCardTime = DateTime.MaxValue;
                        else 
                            customer.extendCardTime = dr.GetDateTime(10);

                         if(dr.IsDBNull(11))                   //extend_card_num
                            customer.extendCardNum = 0;
                        else 
                            customer.extendCardNum = dr.GetInt32(11);

                         if(dr.IsDBNull(12))                   //telephone
                            customer.telephone = "";
                        else 
                            customer.telephone = dr.GetString(12);

                         if (dr.IsDBNull(13))                   //email
                             customer.email = "";
                         else
                             customer.email = dr.GetString(13);

                         if (dr.IsDBNull(14))                   //type
                             customer.type = CustomerType.PERSONAL;
                         else
                             customer.type = (CustomerType)dr.GetInt32(14);

                         if (dr.IsDBNull(15))                   //level
                             customer.level = CustomerLevel.MEDIUM;
                         else
                             customer.level = (CustomerLevel)dr.GetInt32(15);

                        customers.Add(customer);
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

            return customers;
        }

        /**
        * 
        * 查询指定类别的客户
        * 
        * */
        public List<Customer> findCustomersByType(CustomerType type)
        {


            SqlCeDataReader dr = null;

            List<Customer> customers = new List<Customer>();

            try
            {
                StringBuilder builder = new StringBuilder("select ");
                builder.Append("id,");
                builder.Append("name,");
                builder.Append("card_no,");
                builder.Append("birthday,");
                builder.Append("profession,");
                builder.Append("isMarried,");
                builder.Append("income_level,");
                builder.Append("family_level,");
                builder.Append("first_contact_time,");
                builder.Append("make_card_time,");
                builder.Append("extend_card_time,");
                builder.Append("extend_card_num,");
                builder.Append("telephone,");
                builder.Append("email,");
                builder.Append("type,");
                builder.Append("level");
                builder.Append(" from customer where type=@type");

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();
                parameters.Add("@type", type);

                dr = dbAccess.excuteSqlCeQuery(builder.ToString(), parameters);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Customer customer = new Customer();

                        customer.Id = dr.GetInt32(0);          //id

                        if (dr.IsDBNull(1))                    //name
                            customer.name = "";
                        else
                            customer.name = dr.GetString(1);

                        if (dr.IsDBNull(2))                     //card_no
                            customer.cardNo = "";
                        else
                            customer.cardNo = dr.GetString(2);

                        if (dr.IsDBNull(3))                     //birthday
                            customer.birthday = DateTime.MaxValue;
                        else
                            customer.birthday = dr.GetDateTime(3);

                        if (dr.IsDBNull(4))                     //profession
                            customer.profession = "";
                        else
                            customer.profession = dr.GetString(4);

                        if (dr.IsDBNull(5))                     //isMarried
                            customer.isMarried = false;
                        else
                            customer.isMarried = dr.GetBoolean(5);

                        if (dr.IsDBNull(6))                    //income_level
                            customer.incomeLevel = IncomeLevel.GOOD;
                        else
                            customer.incomeLevel = (IncomeLevel)dr.GetInt32(6);

                        if (dr.IsDBNull(7))                    //family_level
                            customer.familyLevel = FamilyLevel.MEDIUM;
                        else
                            customer.familyLevel = (FamilyLevel)dr.GetInt32(7);

                        if (dr.IsDBNull(8))                    //first_contact_time
                            customer.firstContactTime = DateTime.MaxValue;
                        else
                            customer.firstContactTime = dr.GetDateTime(8);

                        if (dr.IsDBNull(9))                    //make_card_time
                            customer.makeCardTime = DateTime.MaxValue;
                        else
                            customer.makeCardTime = dr.GetDateTime(9);

                        if (dr.IsDBNull(10))                   //extend_card_time
                            customer.extendCardTime = DateTime.MaxValue;
                        else
                            customer.extendCardTime = dr.GetDateTime(10);

                        if (dr.IsDBNull(11))                   //extend_card_num
                            customer.extendCardNum = 0;
                        else
                            customer.extendCardNum = dr.GetInt32(11);

                        if (dr.IsDBNull(12))                   //telephone
                            customer.telephone = "";
                        else
                            customer.telephone = dr.GetString(12);

                        if (dr.IsDBNull(13))                   //email
                            customer.email = "";
                        else
                            customer.email = dr.GetString(13);

                        if (dr.IsDBNull(14))                   //type
                            customer.type = CustomerType.PERSONAL;
                        else
                            customer.type = (CustomerType)dr.GetInt32(14);

                        if (dr.IsDBNull(15))                   //level
                            customer.level = CustomerLevel.MEDIUM;
                        else
                            customer.level = (CustomerLevel)dr.GetInt32(15);

                        customers.Add(customer);
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

            return customers;
        }

        /**
         * 
         * 增加客户
         * 
         * */
        public bool addCustomer(Customer customer)
        {
            try
            {
                StringBuilder builder = new StringBuilder("insert into customer (");
                builder.Append("name,");
                builder.Append("card_no,");
                builder.Append("birthday,");
                builder.Append("profession,");
                builder.Append("isMarried,");
                builder.Append("income_level,");
                builder.Append("family_level,");
                builder.Append("first_contact_time,");
                builder.Append("make_card_time,");
                builder.Append("extend_card_time,");
                builder.Append("extend_card_num,");
                builder.Append("telephone,");
                builder.Append("email,");
                builder.Append("type,");
                builder.Append("level");
                builder.Append(")");
                builder.Append(" values(");
                builder.Append("@name,");
                builder.Append("@card_no,");
                builder.Append("@birthday,");
                builder.Append("@profession,");
                builder.Append("@isMarried,");
                builder.Append("@income_level,");
                builder.Append("@family_level,");
                builder.Append("@first_contact_time,");
                builder.Append("@make_card_time,");
                builder.Append("@extend_card_time,");
                builder.Append("@extend_card_num,");
                builder.Append("@telephone,");
                builder.Append("@email,");
                builder.Append("@type,");
                builder.Append("@level");
                builder.Append(")");

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@name",               customer.name);
                parameters.Add("@card_no",            customer.cardNo);
                parameters.Add("@birthday",           customer.birthday);
                parameters.Add("@profession",         customer.profession);
                parameters.Add("@isMarried",          customer.isMarried);
                parameters.Add("@income_level",       customer.incomeLevel);
                parameters.Add("@family_level",       customer.familyLevel);
                parameters.Add("@first_contact_time", customer.firstContactTime);
                parameters.Add("@make_card_time",     customer.makeCardTime);
                parameters.Add("@extend_card_time",   customer.extendCardTime);
                parameters.Add("@extend_card_num",    customer.extendCardNum);
                parameters.Add("@telephone",          customer.telephone);
                parameters.Add("@email",              customer.email);
                parameters.Add("@type",               customer.type);
                parameters.Add("@level",              customer.level);

                dbAccess.excute(builder.ToString(), parameters);
                return true;
            }
            catch (Exception e)
            {
                throw new MyException(e.Message);
            }
        }

        /**
         * 
         * 更新客户
         * 
         * */
        public bool updateCustomer(Customer customer)
        {
            try
            {
                StringBuilder builder = new StringBuilder("update customer set ");
                builder.Append("name=@name,");
                builder.Append("card_no=@card_no,");
                builder.Append("birthday=@brithday,");
                builder.Append("profession=@profession,");
                builder.Append("isMarried=@isMarried,");
                builder.Append("income_level=@income_level,");
                builder.Append("family_level=@family_level,");
                builder.Append("first_contact_time=@first_contact_time,");
                builder.Append("make_card_time=@make_card_time,");
                builder.Append("extend_card_time=@extend_card_time,");
                builder.Append("extend_card_num=@extend_card_num,");
                builder.Append("telephone=@telephone,");
                builder.Append("email=@email,");
                builder.Append("type=@type,");
                builder.Append("level=@level");
                builder.Append(" where id=@id");

                Dictionary<string, Object> parameters = new Dictionary<string, Object>();

                parameters.Add("@id", customer.Id);
                parameters.Add("@name", customer.name);
                parameters.Add("@card_no", customer.cardNo);
                parameters.Add("@birthday", customer.birthday);
                parameters.Add("@profession", customer.profession);
                parameters.Add("@isMarried", customer.isMarried);
                parameters.Add("@income_level", customer.incomeLevel);
                parameters.Add("@family_level", customer.familyLevel);
                parameters.Add("@first_contact_time", customer.firstContactTime);
                parameters.Add("@make_card_time", customer.makeCardTime);
                parameters.Add("@extend_card_time", customer.extendCardTime);
                parameters.Add("@extend_card_num", customer.extendCardNum);
                parameters.Add("@telephone", customer.telephone);
                parameters.Add("@email", customer.email);
                parameters.Add("@type", customer.type);
                parameters.Add("@level", customer.level);

                dbAccess.excute(builder.ToString(), parameters);
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
