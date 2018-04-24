using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Tests.Test
{
    [TestClass]
    public class TestTheTestProject
    {

        [TestMethod]
        [TestCategory("Test project")]
        public void TestTheTests()
        {
            // Arrange
            string test = null;

            // Act
            test = "test";

            // Assert
            Assert.IsNotNull(test);

        }
    }
}
