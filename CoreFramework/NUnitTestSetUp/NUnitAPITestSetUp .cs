using CoreFramework.DriverCore;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using CoreFramework.Reporter;

namespace CoreFramework.NUnitTestSetUp 
{
    [TestFixture]
    public class NUnitAPITestSetUp : NUnitWebTestSetUp
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}