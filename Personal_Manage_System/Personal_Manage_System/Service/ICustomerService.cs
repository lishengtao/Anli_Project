using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Service
{
    interface ICustomerService : ICommonService
    {
        /**
         * 
         * 查询所有客户
         * 
         * */
        List<Customer> findCustomers();

        /**
         * 
         * 查询指定类别的客户
         * 
         * */
        List<Customer> findCustomersByType(CustomerType type);

        /**
         * 
         * 增加客户
         * 
         * */
        bool addCustomer(Customer customer);

        /**
         * 
         * 更新客户
         * 
         * */
        bool updateCustomer(Customer customer);

    }
}
