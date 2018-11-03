using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwiddleToe.Workers.FileHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiddleToe.Tests;

namespace TwiddleToe.Workers.FileHandlers.Tests
{
    [TestClass()]
    public class StateFileHandlerTests : TestBase<TestScope>
    {
        [TestMethod()]
        public void Initialize()
        {
            using (var scope= this.StartTest())
            {
                // Arrang & Act
                var provider = scope.StateFileHandler;

    }
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveStateToFileTest()
        {
            Assert.Fail();
        }
    }
}