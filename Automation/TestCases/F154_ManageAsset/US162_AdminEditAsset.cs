using Automation.DAO;
using Automation.PageObject;
using Automation.TestSetUp;
using NUnit.Framework;

namespace Automation.TestCases.F154_ManageAsset
{
    public class US162_AdminEditAsset : ProjectNUnitTestSetUp
    {
        [Test]
        public void US162_AdminEditInformation()
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
            Assert.True(assetPage.IsCreateNewAssetFormDisplayed());

            NewAsset validasset = new NewAsset("Ipad Mini 1", "Ipad", 2022, "Dec", 10, "Lastest Version");
            assetPage.CreateNewAsset(validasset);

            Thread.Sleep(5000);
            Assert.True(assetPage.IsCreateSuccessPopupDisplayed());

            Thread.Sleep(3000);
            assetPage.ChooseAssetToEdit();

            Thread.Sleep(3000);
            Assert.True(assetPage.IsEditAssetFormDisplayed());

            assetPage.EditAssetName("2022");
            assetPage.EditSpetification("Lastest Version (Update: 16/12/2022)");
            Thread.Sleep(3000);

            assetPage.SaveEdit();
            Thread.Sleep(5000);
        }
    }
}
