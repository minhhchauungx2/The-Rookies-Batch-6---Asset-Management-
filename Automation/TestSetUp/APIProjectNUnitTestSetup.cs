using CoreFramework.NUnitTestSetUp;
using NUnit.Framework;

namespace Automation.TestSetUp
{
    public class APIProjectNUnitTestSetup : NUnitWebTestSetUp
    {
        
        [SetUp]
        public void Setup()
        {
            driverBaseAction.GoToURL(ConstantSetUp.API_URL);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
