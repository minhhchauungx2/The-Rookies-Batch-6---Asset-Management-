using Automation.DAO;
using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F154_ManageAsset
{
    public class US163_AdminDeleteAsset : ProjectNUnitTestSetUp
    {
        [Test]
        public void US163_DeleteAsset()
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

            assetPage.ClickCreateBtn();
            Thread.Sleep(3000);

            NewAsset validasset = new NewAsset("DemoDelete", "Samsung", 2022, "Dec", 10, "Lastest Version");
            assetPage.CreateNewAsset(validasset);

            Thread.Sleep(5000);
            assetPage.ClickPopup();

            assetPage.ChooseAssetToDelete(validasset.AssetName);
            Thread.Sleep(3000);
            Assert.True(assetPage.IsDeletePopupDisplayed());

            Thread.Sleep(3000);
            assetPage.DeleteAsset();

            Thread.Sleep(5000);
            assetPage.SearchAsset(validasset.AssetName);

            Thread.Sleep(3000);
            Assert.True(assetPage.CheckDeleteAssetSuccessfully());
        }
    }
}
