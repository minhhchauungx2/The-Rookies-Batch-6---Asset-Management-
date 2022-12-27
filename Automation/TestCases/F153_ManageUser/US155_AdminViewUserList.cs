using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F153_ManageUser
{
    public class US155_AdminViewUserList : ProjectNUnitTestSetUp
    {
        [Test]
        public void US155_ViewUserList()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(5000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            Thread.Sleep(5000);
            MenuLeftPage menuLeftPage = new MenuLeftPage(_driver);
            menuLeftPage.GoToUserPage();

            Thread.Sleep(5000);
            UserPage userPage = new UserPage(_driver);
            Assert.True(userPage.IsUserPageDisplayed());
            Assert.True(userPage.IsUserListDisplayed());

            userPage.SearchUser("minhchaus");

            Thread.Sleep(5000);
            Assert.True(userPage.IsInformationPopUpDisplayed());
        }
    }
}
