using Automation.DAO;
using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F154_ManageAsset
{
    public class US161_AdminCreateAsset : ProjectNUnitTestSetUp
    {
        [Test]
        public void US161_AdminCreateNewAsset()
        {
            LoginPage login = new LoginPage(_driver);
            Assert.True(login.IsLoginPageDisplayed());
            login.DoLogin(ConstantSetUp.AdminUsername, ConstantSetUp.AdminPassword);

            Thread.Sleep(10000);
            HomePage homePage = new HomePage(_driver);
            Assert.True(homePage.CheckAccountThatUserLogin(ConstantSetUp.AdminUsername));

            Thread.Sleep(2000);
            MenuLeftPage menuLeftPage = new MenuLeftPage(_driver);
            menuLeftPage.GoToAssetPage();

            Thread.Sleep(5000);
            AssetPage assetPage = new AssetPage(_driver);
            Assert.True(assetPage.IsAssetPageDisplayed());
            Assert.True(assetPage.IsAssetListDisplayed());

            assetPage.ClickCreateBtn();
            Thread.Sleep(3000);
            Assert.True(assetPage.IsCreateNewAssetFormDisplayed());

            NewAsset validasset = new NewAsset("Ipad Pro", "Ipad", 2022, "Dec", 10, "Lastest Version");
            assetPage.CreateNewAsset(validasset);

            Thread.Sleep(5000);
            Assert.True(assetPage.IsCreateSuccessPopupDisplayed());
            assetPage.ClickPopup();

            Thread.Sleep(3000);
            assetPage.ChooseCreatedAsset(validasset);

            Thread.Sleep(5000);
            Assert.True(assetPage.IsInformationPopUpDisplayed());

            Thread.Sleep(3000);
        }
    }
}
