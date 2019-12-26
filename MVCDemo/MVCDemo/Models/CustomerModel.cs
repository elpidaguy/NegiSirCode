using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class CustomerModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAge { get; set; }

        public string CustomerEmail { get; set; }
    }
}