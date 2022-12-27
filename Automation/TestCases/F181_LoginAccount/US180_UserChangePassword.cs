using NUnit.Framework;
using Automation.PageObject;
using Automation.TestSetUp;
using CoreFramework.DriverCore;

namespace Automation.TestCases.F181_LoginAccount
{
    public class US180_UserChangePassword : ProjectNUnitTestSetUp
    {
        [Test]
        public void US180_AdminChangePassword()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            homePage.ChangePassword();
            Thread.Sleep(3000);
            Assert.True(homePage.IsChangePasswordPopupDisplayed());
            homePage.DoChangePassword(ConstantSetUp.AdminPassword, ConstantSetUp.AdminNewPassword);

            Thread.Sleep(5000);
            homePage.SavePassword();

            Thread.Sleep(3000);
            Assert.True(homePage.ChangePasswordSuccessfullyPopup());

            Thread.Sleep(3000);
            homePage.Confirm();

            Thread.Sleep(3000);
            Assert.True(homePage.IsHomePageDisplayed());

            //Chuyen ve password ban dau
            homePage.ChangePassword();
            Thread.Sleep(2000);
            homePage.DoChangePassword(ConstantSetUp.AdminNewPassword, ConstantSetUp.AdminPassword);
            Thread.Sleep(2000);
            homePage.SavePassword();
            Thread.Sleep(3000);
            homePage.Confirm();
            Thread.Sleep(3000);
        }

        [Test]
        public void US152_StaffChangePassword()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.StaffUsername, ConstantSetUp.StaffPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.StaffUsername));

            homePage.ChangePassword();
            Thread.Sleep(3000);
            Assert.True(homePage.IsChangePasswordPopupDisplayed());
            homePage.DoChangePassword(ConstantSetUp.StaffPassword, ConstantSetUp.StaffNewPassword);

            Thread.Sleep(5000);
            homePage.SavePassword();

            Thread.Sleep(3000);
            Assert.True(homePage.ChangePasswordSuccessfullyPopup());

            Thread.Sleep(3000);
            homePage.Confirm();

            Thread.Sleep(3000);
            Assert.True(homePage.IsHomePageDisplayed());

            //Chuyen ve password ban dau
            homePage.ChangePassword();
            Thread.Sleep(2000);
            homePage.DoChangePassword(ConstantSetUp.StaffNewPassword, ConstantSetUp.StaffPassword);
            Thread.Sleep(2000);
            homePage.SavePassword();
            Thread.Sleep(3000);
            homePage.Confirm();
            Thread.Sleep(3000);
        }
    }
}
