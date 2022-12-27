using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F177_ManageRequestForReturning
{
    public class US176_AdminCancelRequest : ProjectNUnitTestSetUp
    {
        [Test]
        public void US176_CancelRequest()
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

            reqPage.ChooseRequestToCancel();
            Thread.Sleep(3000);

            Assert.True(reqPage.IsCancelRequestConfirmationPopupDisplayed());
            Thread.Sleep(3000);

            reqPage.CancelRequest();
            Thread.Sleep(5000);

            Assert.True(reqPage.IsCancelRequestSuccessfullyPopupDisplayed());
            Thread.Sleep(3000);

            reqPage.Confirm();
            Thread.Sleep(3000);
        }
    }
}
