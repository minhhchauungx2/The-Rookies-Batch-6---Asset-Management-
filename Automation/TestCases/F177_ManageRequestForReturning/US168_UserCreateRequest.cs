using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F177_ManageRequestForReturning
{
    public class US168_UserCreateRequest : ProjectNUnitTestSetUp
    {
        [Test]
        public void US168_StaffCreateRequest()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.StaffUsername, ConstantSetUp.StaffPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.StaffUsername));
            Assert.True(homePage.IsUserAssignmentDisplayed());

            homePage.ChooseAssignmentToRequest();
            Thread.Sleep(3000);

            Assert.True(homePage.IsRequestConfirmationPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Accept();
            Thread.Sleep(3000);

            Assert.True(homePage.IsRequestSuccessfullyPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Confirm();
            Thread.Sleep(3000);
        }
    }
}
