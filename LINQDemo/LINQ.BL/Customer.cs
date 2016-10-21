using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.BL
{
    public class Customer
    {
        public int CustomerId { get; set;}
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int? CustomerTypeId { get; set; }
        public String EmailAddress { get; set; }

        public List<Invoice> InvoiceList { get; set; }

    }
}
