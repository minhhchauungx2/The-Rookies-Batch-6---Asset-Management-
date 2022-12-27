using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F174_ManageAssignment
{
    public class US166_AdminEditAssignment : ProjectNUnitTestSetUp
    {
        [Test]
        public void US166_AdminEditInformation()
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

            assignPage.ChooseAssignmentToEdit();
            Thread.Sleep(3000);

            Assert.True(assignPage.IsEditAssignmentFormDisplayed());
            assignPage.EditUser("SD0060");
            assignPage.EditAsset("SA00031");
            assignPage.EditNote("assign new asset");

            Thread.Sleep(3000);
            assignPage.SaveEdit();

            Thread.Sleep(10000);
        }
    }
}
