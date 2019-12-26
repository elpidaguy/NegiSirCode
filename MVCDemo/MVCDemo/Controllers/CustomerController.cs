using MVCDemo.BAL;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class CustomerController : Controller
    {
        CustomerBAL custBal = new CustomerBAL();
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string CustomerName,string CustomerAge,string CustomerEmail)
        {
            bool isAdded = custBal.AddCustomer(CustomerName, CustomerAge, CustomerEmail);


            if (isAdded)
            {
                ViewBag["Mesaage"] = "Success";
            }
            else
            {

            }
            return View();
        }

        public ActionResult GetAllCustomers()
        {
            //List<CustomerModel> list = new List<CustomerModel>();
            //foreach (tbl_Customer item in custBal.GetAllCustomers())
            //{
            //    CustomerModel customer = new CustomerModel
            //    {
            //        CustomerName = item.customername,
            //        CustomerAge = item.customerage,
            //        CustomerEmail = item.customeremail
            //    };
            //    list.Add(customer);
            //}
            return View(custBal.GetCustomersUsingSP());
        }
       
    }
}