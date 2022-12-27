using Automation.DAO;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Automation.PageObject
{
    public class AssetPage : WebDriverAction
    {
        public AssetPage(IWebDriver driver) : base(driver)
        {
        }

        private string tfAssetPage = "//*[text()='Manage Asset']//ancestor::li";
        private string tfAssetList = "//div[text()='Asset List']";
        private string tfSearchBar = "//input[@aria-label='search']";
        private string tfCreateAssetBtn = "//*[text()='Create new asset']//ancestor::button";

        private string tfAssetCodeColumn = "//span[text()='Asset Code']/ancestor::th";
        private string tfAssetNameColumn = "//span[text()='Asset Name']//ancestor::th";
        private string tfCategoryColumn = "//span[text()='Category']//ancestor::th";
        private string tfStateColumn = "//span[text()='State']//ancestor::th";
        private string tfActionColumn = "//th[text()='Action']";

        private string tfCreateFormTitle = "//*[text()='Create New Asset']";
        private string tfAssetName = "//*[@id='basic_assetName']";
        private string tfCategory = "//*[@id='basic_categoryId']";
        private string tfInstalledDate = "//*[@id='basic_InstalledDate']";
        private string tfSpecification = "//*[@id='basic_Specification']";

        private string tfAddCategory = "//*[text()='Add Category']//ancestor::button";
        private string tfPopupTitle = "//*[text()='Create Category']";
        private string tfPopupLabel = "//*[text()='Category Name']";
        private string tfCategoryName = "//*[@id='form_in_modal_categoryName']";
        
        private string tfOKBtn = "//*[text()='OK']//ancestor::button";
        private string tfCancelBtn = "//*[text()='Cancel']";
        private string tfCloseBtn = "//*[@aria-label='Close']";
        private string tfSubmitBtn = "//button[@type='submit']";

        private string tfYearPicker = "//*[@class='ant-picker-year-btn']";
        private string tfPrevYear = "//*[@class='ant-picker-header-super-prev-btn']";
        private string tfNextYear = "//*[@class='ant-picker-header-super-next-btn']";
        private string tfMonthPicker = "//*[@class='ant-picker-month-btn']";

        private string tfPopupTitle2 = "//*[@class='ant-modal-confirm-title']";
        private string tfPopupMessage2 = "//*[text()='Create Success']";
        
        private string tfPopupTitle3 = "//*[text()='Assignment history of asset']";
        private string tfPopupMessage3 = "//*[contains(text(), 'Assigned to')]";

        private string tfPopupTitle4 = "//*[text()='Create Asset']";

        private string tfEditFormTitle = "//*[text()='Edit Asset']";
        private string tfEditCategoryField = "//*[@id='basic_categoryName']";
        private string tfEditSpecificationField = "//*[@id='basic_specification']";
        private string tfEditInstalledDateField = "//*[@id='basic_installedDate']";

        private string tfPopupTitle5 = "//*[text()='Are you sure?']";
        private string tfPopupMessage5 = "//*[contains(text(), 'delete this asset')]";
        private string tfPopupDeleteBtn = "//*[text()='Delete']//ancestor::button";

        private string tfPopupAssetName = "//*[contains(text(), 'Asset Name: ')]";

        public bool IsAssetPageDisplayed()
        {
            if (IsElementDisplay(tfAssetPage)
                && IsElementDisplay(tfAssetList)
                && IsElementDisplay(tfSearchBar)
                && IsElementDisplay(tfCreateAssetBtn))
            {
                TestContext.WriteLine("\n Asset Page is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Asset Page is not displayed!");
                return false;
            }
        }
        public bool IsAssetListDisplayed()
        {
            if (IsElementDisplay(tfAssetCodeColumn)
               && IsElementDisplay(tfAssetNameColumn)
               && IsElementDisplay(tfCategoryColumn)
               && IsElementDisplay(tfStateColumn)
               && IsElementDisplay(tfActionColumn))
            {
                TestContext.WriteLine("\n Asset List is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Asset List is not displayed!");
                return false;
            }
        }
        public void ClickCreateBtn()
        {
            Click(tfCreateAssetBtn);
        }
        public bool IsCreateNewAssetFormDisplayed()
        {
            if (IsElementDisplay(tfCreateFormTitle)
               && IsElementDisplay(tfAssetName)
               && IsElementDisplay(tfCategory)
               && IsElementDisplay(tfInstalledDate)
               && IsElementDisplay(tfSpecification)
               && IsElementDisplay(tfCancelBtn)
               && IsElementDisplay(tfSubmitBtn))
            {
                TestContext.WriteLine("\n Create New Asset Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create New Asset Form is not displayed!");
                return false;
            }
        }
        public void CreateNewAsset(NewAsset asset)
        {
            SendKeys(tfAssetName, asset.AssetName);
            Click(tfCategory);
            ChooseCategory(asset.Category);
            Thread.Sleep(3000);
            Click(tfInstalledDate);
            Thread.Sleep(3000);
            ChooseDate(asset.InstalledYear, asset.InstalledMonth, asset.InstalledDay);
            SendKeys(tfSpecification, asset.Specification);
            Thread.Sleep(3000);
            Click(tfSubmitBtn);
        }
        public void ChooseCategory(string category)
        {
            if (IsElementDisplay("//*[@title='" + category + "']"))
            {
                Click("//*[@title='" + category + "']");
            }
            else
            {
                Click(tfAddCategory);
                Assert.True(IsCreateCategoryPopupDisplayed());
                SendKeys(tfCategoryName, category);
                Thread.Sleep(3000);
                Click(tfOKBtn);
                Thread.Sleep(5000);
                Assert.True(IsCreateCategorySuccessPopupDisplayed());
                Thread.Sleep(3000);
                Click(tfOKBtn);
                Thread.Sleep(3000);
                Click(tfCategory);
                Thread.Sleep(3000);
                Click("//*[@title='" + category + "']");
            }
        }
        public bool IsCreateCategoryPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle)
               && IsElementDisplay(tfPopupLabel)
               && IsElementDisplay(tfCategoryName)
               && IsElementDisplay(tfCloseBtn)
               && IsElementDisplay(tfCancelBtn)
               && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Create Category Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create Category Popup is not displayed!");
                return false;
            }
        }
        public bool IsCreateCategorySuccessPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle2)
                && IsElementDisplay(tfPopupMessage2)
                && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Create Category Success Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create Category Success Popup is not displayed!");
                return false;
            }
        }
        public void ChooseDate(int year, string month, int day)
        {
            string defaultYear = getText(tfYearPicker);
            int yearDiff = year - Int32.Parse(defaultYear);
            if (yearDiff == 0)
            {
                ChooseMonthAndDay(month, day);
            }
            else if (yearDiff != 0)
            {
                if (yearDiff > 0)
                {
                    for (int i = 0; i < yearDiff; i++)
                    {
                        Click(tfNextYear);
                    }
                    ChooseMonthAndDay(month, day);
                }
                else if (yearDiff < 0)
                {
                    for (int i = 0; i < (yearDiff * (-1)); i++)
                    {
                        Click(tfPrevYear);
                    }
                    ChooseMonthAndDay(month, day);
                }
            }
        }
        public void ChooseMonthAndDay(string month, int day)
        {
            Click(tfMonthPicker);
            Click("//*[text()='" + month + "']");
            Click("//*[text()='" + day + "']");
        }
        public void ChooseState(int state)
        {
            Click("//input[@value='" + state + "']");
        }
        public bool IsCreateSuccessPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle4)
                && IsElementDisplay(tfPopupMessage2)
                && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Create Asset Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create Asset Popup is not displayed!");
                return false;
            }
        }
        public void ClickPopup()
        {
            Click(tfOKBtn);
        }
        public void ChooseCreatedAsset(NewAsset asset)
        {
            SendKeys(tfSearchBar, asset.AssetName);
            Thread.Sleep(3000);
            Click("//td[text()='" + asset.AssetName + "']");
        }
        public bool IsInformationPopUpDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle3)
                && IsElementDisplay(tfPopupMessage3)
                && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Information Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Information Popup is not displayed!");
                return false;
            }
        }
        public void SearchAsset(string assetname)
        {
            FindElementByXpath(tfSearchBar).Clear();
            SendKeys(tfSearchBar, assetname);
        }
        public void ChooseAssetToView(string assetname)
        {
            string AssetXpath = "//*[text()='" + assetname + "']";
            Click(AssetXpath);
        }
        public bool CheckInformationOfAsset()
        {
            string info = getText(tfPopupAssetName);
            string assetname = info.Substring(12);

            if (IsElementDisplay(tfPopupTitle3)
                && IsElementDisplay(tfOKBtn)
                && "Asset Name: " + assetname == info)
            {
                TestContext.WriteLine("\n Information Popup of " + assetname + " is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Information Popup of " + assetname + " is not displayed!");
                return false;
            }
        }
        public void ChooseAssetToEdit()
        {
            Click(tfOKBtn);
            string tfEditXpath = "//*[@data-testid='EditIcon']//ancestor::div[1]";
            Click(tfEditXpath);
        }
        public bool IsEditAssetFormDisplayed()
        {
            if (IsElementDisplay(tfEditFormTitle)
                && IsElementDisplay(tfAssetName)
                && IsElementDisplay(tfEditCategoryField)
                && IsElementDisplay(tfEditSpecificationField)
                && IsElementDisplay(tfEditInstalledDateField)
                && IsElementDisplay(tfCancelBtn)
                && IsElementDisplay(tfSubmitBtn))
            {
                TestContext.WriteLine("\n Edit Asset Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Edit Asset Form is not displayed!");
                return false;
            }
        }
        public void EditAssetName(string assetname)
        {
            FindElementByXpath(tfAssetName).Clear();
            SendKeys(tfAssetName, assetname);
        }
        public void EditSpetification(string assetSpecific)
        {
            FindElementByXpath(tfEditSpecificationField).Clear();
            SendKeys(tfEditSpecificationField, assetSpecific);
        }
        public void EditInstalledDate(int year, string month, int day)
        {
            Click(tfEditInstalledDateField);
            ChooseDate(year, month, day);
        }
        public void EditAssetStatus(int status)
        {
            Click("//input[@value='" + status + "']");
        }
        public void SaveEdit()
        {
            Click(tfSubmitBtn);
        }
        public void ChooseAssetToDelete(string assetname)
        {
            string tfDeleteXpath = "//*[text()='" + assetname + "']//ancestor::tr//div//*[@data-testid='HighlightOffIcon']//ancestor::div[1]";
            Click(tfDeleteXpath);
        }
        public bool IsDeletePopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle5)
                && IsElementDisplay(tfPopupMessage5)
                && IsElementDisplay(tfCancelBtn)
                && IsElementDisplay(tfPopupDeleteBtn))
            {
                TestContext.WriteLine("\n Confirmation delete popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Confirmation delete popup is not displayed!");
                return false;
            }
        }
        public void DeleteAsset()
        {
            Click(tfPopupDeleteBtn);
        }
        public bool CheckDeleteAssetSuccessfully()
        {
            if (IsElementDisplay("//*[text()='No data']"))
            {
                TestContext.WriteLine("\n Delete asset successfully!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Delete asset failed!");
                return false;
            }
        }
    }
}
