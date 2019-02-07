using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        public int ProductID { get; set; }
        public int CustomerID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfTransaction { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product  Product { get; set; }
    }
}