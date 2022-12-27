using Automation.DAO;
using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F174_ManageAssignment
{
    public class US167_AdminDeleteAssignment : ProjectNUnitTestSetUp
    {
        [Test]
        public void US167_DeleteAssignment()
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

            Thread.Sleep(5000);
            assignPage.ChooseAssignmentToDelete();

            Thread.Sleep(3000);
            Assert.True(assignPage.IsDeletePopupDisplayed());

            Thread.Sleep(3000);
            assignPage.DeleteAsset();

            Thread.Sleep(3000);
            Assert.True(assignPage.IsDeleteSuccessfullyPopupDisplayed());
        }
    }
}
