using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.BL
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool? IsPaid { get; set; }

        public decimal Amount { get; set; }
        public int NumberOfUnitis { get; set; }
        public decimal DiscountPercet { get; set; }
        //ReadOnly property
        public decimal TotalAmount
        {
            get
            {
                return this.Amount - (this.Amount * (this.DiscountPercet / 100));
            }
        }




    }
}
