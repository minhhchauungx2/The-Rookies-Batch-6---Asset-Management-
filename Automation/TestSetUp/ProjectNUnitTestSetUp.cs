using CoreFramework.NUnitTestSetUp;
using NUnit.Framework;

namespace Automation.TestSetUp
{
    public class ProjectNUnitTestSetUp : NUnitWebTestSetUp
    {
        
        [SetUp]
        public void Setup()
        {
            driverBaseAction.GoToURL(ConstantSetUp.BASE_URL);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
