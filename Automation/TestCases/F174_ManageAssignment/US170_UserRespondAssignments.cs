using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F174_ManageAssignment
{
    public class US170_UserRespondAssignments : ProjectNUnitTestSetUp
    {
        [Test]
        public void US170_AdminAcceptAssignment()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));
            Assert.True(homePage.IsUserAssignmentDisplayed());

            homePage.ChooseAssignmentToAccept();
            Thread.Sleep(3000);

            Assert.True(homePage.IsAcceptConfirmationPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Accept();
            Thread.Sleep(5000);

            Assert.True(homePage.IsAcceptSuccessfullyPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Confirm();
            Thread.Sleep(3000);
        }

        [Test]
        public void US170_AdminDeclineAssignment()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));
            Assert.True(homePage.IsUserAssignmentDisplayed());

            homePage.ChooseAssignmentToDecline();
            Thread.Sleep(3000);

            Assert.True(homePage.IsDeclineConfirmationPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Decline();
            Thread.Sleep(10000);

            Assert.True(homePage.IsDeclineSuccessfullyPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Confirm();
            Thread.Sleep(3000);
        }

        [Test]
        public void US170_StaffAcceptAssignment()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.StaffUsername, ConstantSetUp.StaffPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.StaffUsername));
            Assert.True(homePage.IsUserAssignmentDisplayed());

            homePage.ChooseAssignmentToAccept();
            Thread.Sleep(3000);

            Assert.True(homePage.IsAcceptConfirmationPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Accept();
            Thread.Sleep(5000);
        }

        [Test]
        public void US170_StaffDeclineAssignment()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.StaffUsername, ConstantSetUp.StaffPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.StaffUsername));
            Assert.True(homePage.IsUserAssignmentDisplayed());

            homePage.ChooseAssignmentToDecline();
            Thread.Sleep(3000);

            Assert.True(homePage.IsDeclineConfirmationPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Decline();
            Thread.Sleep(10000);

            Assert.True(homePage.IsDeclineSuccessfullyPopupDisplayed());
            Thread.Sleep(3000);

            homePage.Confirm();
            Thread.Sleep(3000);
        }
    }
}
