using NUnit.Framework;
using Automation.PageObject;
using Automation.DAO;
using Automation.TestSetUp;

namespace Automation.TestCases.F153_ManageUser
{
    public class US158_AdminEditUser : ProjectNUnitTestSetUp
    {
        [Test]
        public void US158_AdminEditInformation()
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

            NewUser validuser = new NewUser("Demo", "Edit", 1999, "Dec", 30, "2022-12-15", 15, 0, "Admin");
            userPage.CreateNewUser(validuser);

            Thread.Sleep(10000);
            Assert.True(userPage.IsCreateSuccessPopupDisplayed());

            Thread.Sleep(3000);
            userPage.ChooseUserToEdit();

            Thread.Sleep(5000);
            Assert.True(userPage.IsEditUserFormDisplayed());

            userPage.ChooseGender(1);
            userPage.ChooseRole("Staff");
            Thread.Sleep(3000);

            userPage.SaveEdit();
            Thread.Sleep(10000);
        }
    }
}
