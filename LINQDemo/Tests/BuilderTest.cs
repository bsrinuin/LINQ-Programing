using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ.Library;

namespace Tests
{
    [TestClass]
    public class BuilderTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void BuildIntegerSequenceTest()
        {
            //Arrange
            Builder listBuilder = new Builder();


            //Act
            var result = listBuilder.BuildIntegerSequence();
            var Stringresult = listBuilder.BuildStringSequence();



            //Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            foreach (var item in Stringresult)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(Stringresult);



        }
    }
}
