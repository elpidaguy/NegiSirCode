using MVCDemo.DAL;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCDemo.BAL
{
    public class CustomerBAL
    {
        ConnectionClass con = new ConnectionClass();
        ConnectionUsingSQL conSql = new ConnectionUsingSQL();
        public bool AddCustomer(string cutomerName, string cutomerAge, string customerEmail)
        {
            return con.AddCustomer(cutomerName, cutomerAge, customerEmail);
        }

        public IEnumerable<tbl_Customer> GetAllCustomers()
        {
            return con.GetAllCustomers();
        }

        public List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            SqlDataReader dr = conSql.GetAllCustomers();
            if (dr != null)
            {
                while (dr.Read())
                {
                    CustomerModel cust = new CustomerModel
                    {
                        CustomerName = Convert.ToString(dr["customername"]),
                        CustomerAge = Convert.ToString(dr["customerage"]),
                        CustomerEmail = Convert.ToString(dr["customeremail"])
                    };
                    customerList.Add(cust);
                }
            }
            return customerList;
        }

        public List<CustomerModel> GetCustomersUsingSP()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            SqlDataReader dr = conSql.GetAllCustomersUsingProcedure();
            if (dr != null)
            {
                while (dr.Read())
                {
                    CustomerModel cust = new CustomerModel
                    {
                        CustomerName = Convert.ToString(dr["customername"]),
                        CustomerAge = Convert.ToString(dr["customerage"]),
                        CustomerEmail = Convert.ToString(dr["customeremail"])
                    };
                    customerList.Add(cust);
                }
            }
            return customerList;
        }
    }
}