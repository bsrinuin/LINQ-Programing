using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.BL;

namespace LINQ.BL
{
    public class CustomerRepository
    {
        public Customer Find(List<Customer> customerlist, int CustomerId)
        {
            Customer FoundCustomer = null;


            //Traditional 
            //foreach (var c in customerlist)
            //{
            //    if(c.CustomerId== CustomerId)
            //    {
            //        FoundCustomer = c;
            //        break; 
            //    }
            //}

            //LINQ SQL - similar to foreach 

            var query = from c in customerlist
                        where c.CustomerId == CustomerId
                        select c;

            FoundCustomer = query.First();

            return FoundCustomer;

        }

        //public IEnumerable<Customer> RetrieveEmptyList()
        //{
        //    return Enumerable.Repeat(new Customer(), 5);
        //}

        //using Select (projection)  Selector is a delegate , we are writing the Lambda expression
        public IEnumerable<string> GetNames(List<Customer> customerlist)
        {
            var query = customerlist.Select(c => c.LastName + ", " + c.FirstName);

            return query;
        }

        //sort by name
        public IEnumerable<Customer> SortByName(IEnumerable<Customer> customerlist)
        {
            return customerlist.OrderBy(c => c.LastName)
                .ThenBy( c=> c.FirstName);
        }


        //Select projection to get anonymus type , anonymous types are used only within the function
        public dynamic GetNamesAndEmail(List<Customer> customerlist)
        {
            var query = customerlist.Select(c => new
            {
                Name = c.LastName + ", " + c.FirstName,
                c.EmailAddress
            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " : " + item.EmailAddress);
            }

            return (query); //return type of the query is unknown , in this case we use Dynamic in class 
        }

        //Join tables using LINQ 
        public dynamic GetNameAndType(List<Customer> customerList, List<CustomerType> CustomerTypeList)
        {
            var queryResults = customerList.Join(CustomerTypeList,
                c => c.CustomerTypeId,
                ct => ct.CustomerTypeId,
                (c, ct) => new
                {
                    Name = c.LastName + ", " + c.FirstName,
                    CustomerTypeName = ct.TypeName
                });

            foreach (var item in queryResults)
            {
                Console.WriteLine("Name: " + item.Name + " , Type: " + item.CustomerTypeName);
            }
            return queryResults.ToList();

        }

        //Get Names and id's for combo box
        public dynamic GetNameAndId(List<Customer> customerlist)
        {
            var query = customerlist.OrderBy(c => c.LastName)
                                                  .ThenBy(c => c.FirstName)
                                                  .Select(c => new
                                                  {
                                                      Name = c.LastName +", "+c.FirstName,
                                                      c.CustomerId
                                                  });

                return query.ToList();
        }


        //Select  -This method and GetOverDueCustomers_SM also does the same thing 
        public IEnumerable<IEnumerable<Invoice>> GetOverDueCustomers(List<Customer> customerList)
        {
            var query = customerList.Select(c => c.InvoiceList
                                                    .Where(i => (i.IsPaid ?? false) == false));

            return query;
        }

        //SelectMany  
        public  IEnumerable<Customer> GetOverDueCustomers_SM(List<Customer> customerList)
        {
            var query = customerList.SelectMany(c => c.InvoiceList
                                                    .Where(i => (i.IsPaid ?? false) == false),
                                                    (c,i) => c).Distinct();
            return query;
        }

        public dynamic GetInvoiceTotalByCustomerType(List<Customer> customer, List<CustomerType> customertype)
        {

            var customertyprquery = customer.Join(customertype, c => c.CustomerTypeId, ct => ct.CustomerTypeId,
                                                  (c, ct) => new
                                                  {
                                                      customerinstance = c,
                                                      customertypename = ct.TypeName
                                                  });

            var query = customertyprquery.GroupBy(c => c.customertypename,
                                        c => c.customerinstance.InvoiceList.Sum(inv => inv.TotalAmount),
                                       (groupkey, invtotal) => new
                                       {
                                           key = groupkey,
                                           invoiceamount = invtotal.Sum()
                                       });

            foreach (var item in query)
            {
                Console.WriteLine(item.key + " , " + item.invoiceamount);
            }

            return query;
        }

        public List<Customer> Retrieve()
        {

            //List<Invoice> invoice = new List<Invoice>();
            InvoiceRepository invoiceRepository = new  InvoiceRepository();
          
           List<Customer> custlist = new List<Customer>();

            custlist.Add(
                new Customer()
                {
                    CustomerId = 1,
                    FirstName = "Peter",
                    LastName = "Christ",
                    EmailAddress = "HeavenSource@everlastinglife.com",
                    CustomerTypeId = 1,
                    InvoiceList =   invoiceRepository.RetrieveInvoice(1) 

                });

            custlist.Add(
                new Customer()
                {
                    CustomerId = 2,
                    FirstName = "John",
                    LastName = "Revelation",
                    EmailAddress = "FutureVision@everlastinglife.com",
                    CustomerTypeId = 1,
                    InvoiceList = invoiceRepository.RetrieveInvoice(2)

                });

            custlist.Add(
                new Customer()
                {
                    CustomerId = 3,
                    FirstName = "Andrew",
                    LastName = "Faithful",
                    EmailAddress = "FutureVision@everlastinglife.com",
                    CustomerTypeId = 2,
                    InvoiceList = invoiceRepository.RetrieveInvoice(3)

                });

            custlist.Add(
                new Customer()
                {
                    CustomerId = 4,
                    FirstName = "Paul",
                    LastName = "GentileGospel",
                    EmailAddress = "FutureVision@everlastinglife.com",
                    CustomerTypeId = 3,
                    InvoiceList = invoiceRepository.RetrieveInvoice(4)

                });

            custlist.Add(
              new Customer()
              {
                  CustomerId = 5,
                  FirstName = "Srini",
                  LastName = "Bandaru",
                  EmailAddress = "Srini@everlastinglife.com",
                  CustomerTypeId =4,
                  InvoiceList = invoiceRepository.RetrieveInvoice(5)

              });


            return custlist;
        }
    }
}
