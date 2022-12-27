using NUnit.Framework;
using Automation.PageObject;
using Automation.TestSetUp;

namespace Automation.TestCases.F181_LoginAccount
{
    public class US152_UserLogOut : ProjectNUnitTestSetUp
    {
        [Test]
        public void US152_AdminLogOut()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            homePage.LogOut();
            Thread.Sleep(5000);
            Assert.True(homePage.IsLogOutPopupDisplayed());

            homePage.Confirm();
            Thread.Sleep(3000);

            Assert.True(login.IsLoginPageDisplayed());
            Thread.Sleep(2000);
        }

        [Test]
        public void US152_StaffLogOut()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.StaffUsername, ConstantSetUp.StaffPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.StaffUsername));

            homePage.LogOut();
            Thread.Sleep(5000);
            Assert.True(homePage.IsLogOutPopupDisplayed());

            homePage.Confirm();
            Thread.Sleep(3000);

            Assert.True(login.IsLoginPageDisplayed());
            Thread.Sleep(2000);
        }
    }
}
