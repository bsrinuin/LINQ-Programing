using LINQ.Library;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace LINQ.Library.Tests
//{
//    [TestClass()]
//    public class StringExtensionsTest
//    {
//        [TestMethod()]
//        public void ConvertToTitleCaseTest()
//        {
//            Assert.Fail();
//        }
//    }
//}

namespace Tests
{
    [TestClass]
    public class StringExtensionsTest
    {
        public TestContext testContext { get; set; }

        [TestMethod]
        public void ConvertToTitleCase()
        {
            //Arrange
            var source = "The return of the king";
            var expected = "The Return Of The King";

            //Act 
            //var result = StringExtensions.ConvertToTitleCase(source);
            var result = source.ConvertToTitleCase();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
    }
}
