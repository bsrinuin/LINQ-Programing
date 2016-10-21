using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.BL.Tests
{
    [TestClass()]
    public class CustomerRepositoryTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
        public void FindTestExistingCustomer()
        {
            //Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerlist = repository.Retrieve();


            //Act
            var result = repository.Find(customerlist, 2 );
           
           //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Revelation", result.LastName);
            
        }


        [TestMethod()]
        public void GetNamesTest()
        {
            //Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerlist = repository.Retrieve();

            //Act
            // var result = repository.Find(customerlist, 2 );
            var query = repository.GetNames(customerlist);

            //Analyze 
            foreach (var item in query)
            {
                TestContext.WriteLine(item);
            }

            //Assert
            Assert.IsNotNull(query);

        }

        //Dynamic -Select Projection ,
        [TestMethod()]
        public void GetNamesEmailTest()
        {
            //This is NOT a Unit test, since anonymous types are used only within the function

            //Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerlist = repository.Retrieve();

            //Act
            // var result = repository.Find(customerlist, 2 );
            var customernameemail = repository.GetNamesAndEmail(customerlist);

            // No Analyze 
            //No Assertion
            //Assert.IsNotNull(customernameemail);

        }

            //Dynamic -Select Projection , Join Test 
        [TestMethod()]
        public void GetNamesAndTypeTest()
        {
            //This is NOT a Unit test, since anonymous types are used only within the function

            //Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerlist = repository.Retrieve();

            CustomerTypeRepository typerepository = new CustomerTypeRepository();
            var customertypelist = typerepository.Retrieve();

            //Act
            // var result = repository.Find(customerlist, 2 );
            var customernameemail = repository.GetNameAndType(customerlist, customertypelist);

            // No Analyze 
           //No Assertion

        }

        //Dynamic -Select Projection , Join Test 
        [TestMethod()]
        public void GetOverDueCustomersTest()
        {
            //This is NOT a Unit test, since anonymous types are used only within the function

            //Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerlist = repository.Retrieve();

            //Act
            // var result = repository.Find(customerlist, 2 );
           // var query = repository.GetOverDueCustomers(customerlist);
            var query = repository.GetOverDueCustomers_SM(customerlist);

            //  Analyze 
            foreach (var item in query)
            {
                   TestContext.WriteLine(item.LastName + ", " + item.FirstName );
            }

            //No Assertion
            Assert.IsNotNull(query);

        }

    }
}