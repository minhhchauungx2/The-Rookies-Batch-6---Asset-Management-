using Automation.DAO;
using Automation.PageObject;
using Automation.TestSetUp;
using CoreFramework.DriverCore;
using NUnit.Framework;

namespace Automation.TestCases.F153_ManageUser
{
    public class US159_AdminDisableUser : ProjectNUnitTestSetUp
    {
        [Test]
        public void US159_DisableUser()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(5000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            Thread.Sleep(5000);
            MenuLeftPage menuLeftPage = new MenuLeftPage(_driver);
            menuLeftPage.GoToUserPage();

            Thread.Sleep(5000);
            UserPage userPage = new UserPage(_driver);
            Assert.True(userPage.IsUserPageDisplayed());

            userPage.ClickCreateBtn();
            Thread.Sleep(3000);
            Assert.True(userPage.IsCreateNewUserFormDisplayed());

            NewUser validuser = new NewUser("Demo", "Delete", 2003, "Dec", 30, "2021-12-15", 15, 0, "Admin");
            userPage.CreateNewUser(validuser);

            Thread.Sleep(10000);
            Assert.True(userPage.IsCreateSuccessPopupDisplayed());

            userPage.ChooseUserToDelete();
            Thread.Sleep(5000);
            Assert.True(userPage.IsDisablePopupDisplayed());

            userPage.DisableUser();
            Thread.Sleep(5000);
            Assert.True(userPage.IsDisableSuccessfullyPopupDisplayed());

            userPage.ClickPopup();
            Thread.Sleep(3000);
        }
    }
}
