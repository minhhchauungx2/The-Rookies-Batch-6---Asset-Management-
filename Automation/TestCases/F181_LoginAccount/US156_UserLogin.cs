using NUnit.Framework;
using Automation.PageObject;
using Automation.Services;
using Automation.DAO;
using CoreFramework.APICore;
using System.Text.Json;
using Automation.TestSetUp;

namespace Automation.TestCases.F181_LoginAccount
{
    public class US156_UserLogin : ProjectNUnitTestSetUp
    {
        //[Test]
        public void US156_AdminLoginAtTheFirstTime()
        {
            UserService userService = new UserService();
            APIResponse response = userService.RegisterAccount("Admin");
            var userRegister = JsonSerializer.Deserialize<UserRegister>(response.requestBody);
            TestContext.WriteLine("\n Username is " + userRegister.username);
            TestContext.WriteLine("\n Password is " + userRegister.password);

            //Do Login
            LoginPage loginpage = new LoginPage(_driver);
            Assert.True(loginpage.IsLoginPageDisplayed());
            loginpage.DoLogin(userRegister.username, userRegister.password);

            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsChangePasswordPopupDisplayed());

            Thread.Sleep(10000);
            homePage.ChangePasswordAtTheFirstTime(userRegister.password + "S@@");
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(userRegister.username));
        }

        [Test]
        public void US156_AdminLoginAtTheSecondTime()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));
        }

        //[Test]
        public void US156_StaffLoginAtTheFirstTime()
        {
            //Register new Admin account
            string text = File.ReadAllText(@"./Constant.json");
            var constant = JsonSerializer.Deserialize<Constant>(text);

            UserService userService = new UserService();
            APIResponse response = userService.RegisterAccount("Staff");
            var userRegister = JsonSerializer.Deserialize<UserRegister>(response.requestBody);
            TestContext.WriteLine("\n Username is " + userRegister.username);
            TestContext.WriteLine("\n Password is " + userRegister.password);

            //Do Login
            LoginPage loginpage = new LoginPage(_driver);
            Assert.True(loginpage.IsLoginPageDisplayed());
            loginpage.DoLogin(userRegister.username, userRegister.password);

            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsChangePasswordPopupDisplayed());

            Thread.Sleep(10000);
            string newpassword = "Mc12345#";
            homePage.ChangePasswordAtTheFirstTime(newpassword);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(userRegister.username));
        }

        [Test]
        public void US156_StaffLoginAtTheSecondTime()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.StaffUsername, ConstantSetUp.StaffPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.StaffUsername));
        }
    }
}
