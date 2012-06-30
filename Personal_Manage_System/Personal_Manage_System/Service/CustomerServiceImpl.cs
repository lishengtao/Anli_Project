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
    class CustomerServiceImpl : CommonServiceImpl, ICustomerService
    {
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
    }
}
