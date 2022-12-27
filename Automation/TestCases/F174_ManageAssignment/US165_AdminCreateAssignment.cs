using Automation.DAO;
using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F174_ManageAssignment
{
    public class US165_AdminCreateAssignment : ProjectNUnitTestSetUp
    {
        [Test]
        public void US165_AdminCreateNewAssignment()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            Thread.Sleep(5000);
            MenuLeftPage menuLeftPage = new MenuLeftPage(_driver);
            menuLeftPage.GoToAssignmentPage();

            Thread.Sleep(5000);
            AssignmentPage assignPage = new AssignmentPage(_driver);
            Assert.True(assignPage.IsAssignmentPageDisplayed());
            Assert.True(assignPage.IsAssignmentListDisplayed());

            assignPage.ClickCreateBtn();
            Thread.Sleep(3000);
            Assert.True(assignPage.IsCreateNewAssignmentFormDisplayed());

            NewAssignment validAssignment = new NewAssignment("SD0060", "Ipad Mini 1", 2022, "Dec", 16);
            assignPage.CreateNewAssignment(validAssignment);

            Thread.Sleep(5000);
        }
    }
}
