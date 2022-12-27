using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F177_ManageRequestForReturning
{
    public class US175_AdminCompleteRequest : ProjectNUnitTestSetUp
    {
        [Test]
        public void US175_CompleteRequest()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.IsHomePageDisplayed());
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            Thread.Sleep(5000);
            MenuLeftPage menuLeftPage = new MenuLeftPage(_driver);
            menuLeftPage.GoToRequestPage();

            Thread.Sleep(5000);
            RequestPage reqPage = new RequestPage(_driver);
            Assert.True(reqPage.IsRequestPageDisplayed());
            Assert.True(reqPage.IsRequestListDisplayed());

            reqPage.ChooseRequestToComplete();
            Thread.Sleep(3000);

            Assert.True(reqPage.IsCompleteRequestConfirmationPopupDisplayed());
            Thread.Sleep(3000);

            reqPage.CompleteRequest();
            Thread.Sleep(5000);

            Assert.True(reqPage.IsCompleteRequestSuccessfullyPopupDisplayed());
            Thread.Sleep(3000);

            reqPage.Confirm();
            Thread.Sleep(3000);
        }
    }
}
