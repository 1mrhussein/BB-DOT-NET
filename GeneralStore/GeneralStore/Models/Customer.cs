using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.Models
{
    public class Customer
    {
        [Key]   // Must be on the top of the first propery 
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
    }
}