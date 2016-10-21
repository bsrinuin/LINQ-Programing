using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.BL
{
    public class InvoiceRepository
    {

        //Total Amount
        public decimal CalculatedTotalAmountInvoiced(List<Invoice> invoicelist)
        {
            return invoicelist.Sum(inv => inv.TotalAmount);
        }

        //Total of units sold
        public decimal CalculatedTotalUnitsSold(List<Invoice> invoicelist)
        {
            return invoicelist.Sum(inv => inv.NumberOfUnitis);
        }

        public decimal CalculateMean(List<Invoice> invoicelist)
        {
            return invoicelist.Average(inv => inv.DiscountPercet);
        }

        //Calculate median 
        public decimal CalculateMedian(List<Invoice> invoicelist)
        {
            var sortedlist = invoicelist.OrderBy(inv => inv.DiscountPercet);

            var count = invoicelist.Count();
            var position = count / 2;

            decimal median; 

            if (count % 2 == 0)
            {
                 median = (sortedlist.ElementAt(position).DiscountPercet + sortedlist.ElementAt(position - 1).DiscountPercet) / 2;
            }
            else
            {
                 median = sortedlist.ElementAt(position).DiscountPercet;
            }

            return median; 

        }

        //Calculate Mode 
        public decimal CalculateMode(List<Invoice> invoicelist)
        {

            var mode = invoicelist.GroupBy(inv => inv.DiscountPercet) //Group by discunt percent
                                                          .OrderByDescending(group => group.Count()) //Sort the list 
                                                          .Select(group => group.Key) //get the value 
                                                          .FirstOrDefault(); //Display the first 


            return mode;
        }

        //Invoice total by Paid customers 1 Groupby
        public dynamic GetInvoiceTotalByIsPaid(List<Invoice> invoicelist)
        {
            var query = invoicelist.GroupBy(inv => inv.IsPaid ?? false,//Group by 
                                                inv => inv.TotalAmount, //selecting from list
                                               (groupkey, invTotal) => new //Result or projection of result
                                               {
                                                   Key = groupkey,
                                                   invoicedAmount = invTotal.Sum()
                                               });  //Result 

            foreach (var item in query)
            {
                Console.WriteLine(item.Key + " : " + item.invoicedAmount);
            }


            return query;
        }

        //Groupby 2 - get the invoice totals by month and ispaid parameter
        public dynamic GetInvoiceTotalByIsPaidByMonth(List<Invoice> invoicelist)
        {
            var query = invoicelist.GroupBy(inv => new
                                                    {
                                                       ispaid = inv.IsPaid ?? false,
                                                       invoicemonth=  inv.InvoiceDate.ToString("MMMM")
                                                    } , //Group by month and ispaid
                                               inv => inv.TotalAmount, //selecting from list
                                              (groupkey, invTotal) => new
                                               {
                                                  Key = groupkey,
                                                  invoicedAmount = invTotal.Sum()
                                              });  //Result or projection of result

            foreach (var item in query)
            {
                Console.WriteLine(item.Key.ispaid + " / " +item.Key.invoicemonth +" : "+ item.invoicedAmount);
            }


            return query;
        }

        //Group by 3: 



        public List<Invoice> RetrieveInvoice()
        {
            List<Invoice> InvoiceList = new List<Invoice>()
            {
                new Invoice()
                {
                    InvoiceId =1,
                    CustomerId =1,
                    InvoiceDate = DateTime.UtcNow,
                    DueDate = DateTime.Now,
                    IsPaid =null,
                    Amount = 15M,
                    NumberOfUnitis= 5,
                    DiscountPercet= 10M
    },
                 new Invoice()
                {
                    InvoiceId =2,
                    CustomerId =1,
                    InvoiceDate = DateTime.UtcNow,
                    DueDate = DateTime.Now,
                    IsPaid =true,
                    Amount = 200.7M,
                    NumberOfUnitis= 7,
                    DiscountPercet= 30M
                },

                   new Invoice()
                {
                    InvoiceId =3,
                    CustomerId =2,
                    InvoiceDate = DateTime.UtcNow.AddDays(-200),
                    DueDate = DateTime.Now,
                    IsPaid =null,
                    Amount = 158M,
                    NumberOfUnitis= 8,
                    DiscountPercet= 40M
                    },
                  new Invoice()
                    {
                        InvoiceId =4,
                        CustomerId =4,
                        InvoiceDate = DateTime.UtcNow.AddDays(-30),
                        DueDate = DateTime.Now,
                        IsPaid =false,
                        Amount = 150M,
                        NumberOfUnitis= 9,
                        DiscountPercet= 10.0M
                  },
                 new Invoice()
                 {
                     InvoiceId = 5,
                     CustomerId = 4,
                     InvoiceDate = DateTime.UtcNow.AddDays(-180),
                     DueDate = DateTime.Now,
                     IsPaid = false,
                     Amount = 150M,
                     NumberOfUnitis = 9,
                     DiscountPercet = 10.0M
                     },
                    new Invoice()
                    {
                        InvoiceId = 6,
                                CustomerId = 4,
                                InvoiceDate = DateTime.UtcNow.AddDays(-60),
                                DueDate = DateTime.Now,
                                IsPaid = false,
                                Amount = 150M,
                                NumberOfUnitis = 9,
                                DiscountPercet = 20.0M
                            }

    };

            return InvoiceList;
        }


        public List<Invoice> RetrieveInvoice(int customerId)
        {
            var InvoiceList = this.RetrieveInvoice();

            List<Invoice> filteredList = InvoiceList.Where(i => i.CustomerId == customerId).ToList();

            return filteredList;
        }


    }
}

