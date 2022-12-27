using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F154_ManageAsset
{
    public class US160_AdminViewAssetList : ProjectNUnitTestSetUp
    {
        [Test]
        public void US160_ViewAssetList()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(5000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            Thread.Sleep(5000);
            MenuLeftPage menuLeftPage = new MenuLeftPage(_driver);
            menuLeftPage.GoToAssetPage();

            Thread.Sleep(5000);
            AssetPage assetPage = new AssetPage(_driver);
            Assert.True(assetPage.IsAssetPageDisplayed());
            Assert.True(assetPage.IsAssetListDisplayed());

            string assetname = "galaxy y";
            assetPage.SearchAsset(assetname);
            Thread.Sleep(3000);

            assetPage.ChooseAssetToView(assetname);
            Thread.Sleep(3000);

            Assert.True(assetPage.IsInformationPopUpDisplayed());
            Assert.True(assetPage.CheckInformationOfAsset());

            Thread.Sleep(3000);
        }
    }
}
