using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F174_ManageAssignment
{
    public class US164_AdminViewAssignmentList : ProjectNUnitTestSetUp
    {
        [Test]
        public void US164_ViewAssignmentList()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(5000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            Thread.Sleep(5000);
            MenuLeftPage menuLeftPage = new MenuLeftPage(_driver);
            menuLeftPage.GoToAssignmentPage();

            Thread.Sleep(5000);
            AssignmentPage assignPage = new AssignmentPage(_driver);
            Assert.True(assignPage.IsAssignmentPageDisplayed());
            Assert.True(assignPage.IsAssignmentListDisplayed());
        }
    }
}
