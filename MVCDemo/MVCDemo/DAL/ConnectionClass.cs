using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.DAL
{
    public class ConnectionClass
    {
        
        DataClassesDataContext dataAccess = new DataClassesDataContext();
        public bool AddCustomer(string cutomerName,string cutomerAge,string customerEmail)
        {
            bool _isAdded = false;
            try
            {
                tbl_Customer obj = new tbl_Customer();
                obj.customername = cutomerName;
                obj.customerage = cutomerAge;
                obj.customeremail = customerEmail;
                dataAccess.tbl_Customers.InsertOnSubmit(obj);
                dataAccess.SubmitChanges();
                _isAdded = true;
            }
            catch (Exception ex)
            { 

            }
            return _isAdded;
        }

        public IEnumerable<tbl_Customer> GetAllCustomers()
        {
            var allcustomers = from allrec in dataAccess.tbl_Customers
                               select allrec;
            return allcustomers;
        }

        public bool isUpdated(int customerId,string customerAge)
        {
            bool isUpdated = false;
            var rec = (from allrec in dataAccess.tbl_Customers
                      where allrec.Id==customerId
                      select allrec).FirstOrDefault();
            if (null != rec)
            {
                rec.customerage = customerAge;
                dataAccess.SubmitChanges();
            }
            return isUpdated;
        }
    }
}