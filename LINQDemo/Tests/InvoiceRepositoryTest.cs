using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ.BL;

namespace Tests
{
    [TestClass]
    public class InvoiceRepositoryTest
    {
        [TestMethod]
        public void CalculatedTotalAmountInvoicedTest()
        {
            //Arrange
            var invoicerepository = new InvoiceRepository();
            var invoicelist = invoicerepository.RetrieveInvoice();


            //Act
            var actual= invoicerepository.CalculatedTotalAmountInvoiced(invoicelist);

            Console.WriteLine(actual);

            //Assert
            Assert.AreEqual(actual, 383.79M);

        }

        [TestMethod]
        public void CalculateMeanTest()
        {
            //Arrange
            var invoicerepository = new InvoiceRepository();
            var invoicelist = invoicerepository.RetrieveInvoice();


            //Act
            var actual = invoicerepository.CalculateMean(invoicelist);

            Console.WriteLine(actual);

            //Assert
            Assert.AreEqual(actual, 20M);

        }


        [TestMethod]
        public void CalculateMedianTest()
        {
            //Arrange
            var invoicerepository = new InvoiceRepository();
            var invoicelist = invoicerepository.RetrieveInvoice();


            //Act
            var actual = invoicerepository.CalculateMedian(invoicelist);

            Console.WriteLine(actual);

            //Assert
            Assert.AreEqual(actual, 15M);

        }

        [TestMethod]
        public void CalculateModeTest()
        {
            //Arrange
            var invoicerepository = new InvoiceRepository();
            var invoicelist = invoicerepository.RetrieveInvoice();


            //Act
            var actual = invoicerepository.CalculateMode(invoicelist);

            Console.WriteLine(actual);

            //Assert
            Assert.AreEqual(actual, 10M);

        }

        [TestMethod]
        public void CalculatedTotalUnitsSoldTest()
        {
            //Arrange
            var invoicerepository = new InvoiceRepository();
            var invoicelist = invoicerepository.RetrieveInvoice();


            //Act
            var actual = invoicerepository.CalculatedTotalUnitsSold(invoicelist);

            Console.WriteLine(actual);

            //Assert
            Assert.AreEqual(actual, 29);

        }


        [TestMethod]
        public void GetInvoiceTotalByIsPaidTest()
        {
            //Arrange
            var invoicerepository = new InvoiceRepository();
            var invoicelist = invoicerepository.RetrieveInvoice();


            //Act
            var actual = invoicerepository.GetInvoiceTotalByIsPaid(invoicelist);

           // Console.WriteLine(actual);

            ////Assert
            //Assert.AreEqual(actual, 29);

        }


        [TestMethod]
        public void GetInvoiceTotalByIsPaidByMonthTest()
        {
            //Arrange
            var invoicerepository = new InvoiceRepository();
            var invoicelist = invoicerepository.RetrieveInvoice();


            //Act
            var actual = invoicerepository.GetInvoiceTotalByIsPaidByMonth(invoicelist);

            // Console.WriteLine(actual);

            ////Assert
            //Assert.AreEqual(actual, 29);

        }

        [TestMethod]
        public void GetInvoiceTotalByCustomerTypeTest()
        {
            //Arrange
            var customerrepository = new CustomerRepository();
            var customerlist = customerrepository.Retrieve();

            var customertyperepository = new CustomerTypeRepository();
            var customertypelist = customertyperepository.Retrieve();


           // var customer = new list<Customer>();
           // var customertype = new CustomerType();

            //Act
            var actual = customerrepository.GetInvoiceTotalByCustomerType(customerlist, customertypelist);

            // Console.WriteLine(actual);

            ////Assert
            //Assert.AreEqual(actual, 29);

        }
    }
}
