using Automation.DAO;
using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F153_ManageUser
{
    public class US157_AdminCreateUser : ProjectNUnitTestSetUp
    {
        [Test]
        public void US157_AdminCreateNewUser()
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

            NewUser validuser = new NewUser("MinhChau", "Demo", 2001, "Sep", 20, "2021-07-16", 16, 1, "Admin");
            userPage.CreateNewUser(validuser);

            Thread.Sleep(10000);
            Assert.True(userPage.IsCreateSuccessPopupDisplayed());

            Thread.Sleep(5000);
            userPage.GetUsername();

            Thread.Sleep(5000);
            Assert.True(userPage.IsInformationPopUpDisplayed());

            Thread.Sleep(3000);
        }
    }
}
