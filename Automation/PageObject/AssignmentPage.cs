using Automation.DAO;
using AventStack.ExtentReports.Model;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Automation.PageObject
{
    public class AssignmentPage : WebDriverAction
    {
        private string tfAssignmentPage = "//*[text()='Manage Assignment']//ancestor::li";
        private string tfAssignmentList = "//*[text()='Assigment list']";
        private string tfFilterByType = "//*[@id='demo-simple-select-label']//ancestor::div[2]";
        private string tfFilterByAssignedDate = "//*[@placeholder='Assigned Date']";
        private string tfSearchBar = "//*[@aria-label='search']";
        private string tfCreateBtn = "//*[text()='Create new assignment']//ancestor::button";

        private string tfNumberColumn = "//*[text()='No.']//ancestor::th";
        private string tfAssetCodeColumn = "//*[text()='Asset Code']//ancestor::th";
        private string tfAssetNameColumn = "//*[text()='Asset Name']//ancestor::th";
        private string tfAssignedToColumn = "//*[text()='Assigned To']//ancestor::th";
        private string tfAssignedByColumn = "//*[text()='Assigned By']//ancestor::th";
        private string tfAssignedDateColumn = "//*[text()='Assigned Date']//ancestor::th";
        private string tfStateColumn = "//*[text()='State']//ancestor::th";
        private string tfActionColumn = "//th[text()='Action']";

        private string tfCreateFormTitle = "//*[text()='Create New Assignment']";
        private string tfEditFormTitle = "//*[text()='Edit assignment']";

        private string tfUserField = "//*[@id='userInfor']";
        private string tfUserFieldGlass = "//*[@id='userInfor']//ancestor::div[1]//*[@data-icon='search']";
        private string tfAssetField = "//*[@id='assetInfor']";
        private string tfAssetFieldGlass = "//*[@id='assetInfor']//ancestor::div[1]//*[@data-icon='search']";
        private string tfAssignedDate = "//*[@id='assignedDate']";
        private string tfNoteField = "//*[@id='note']";

        private string tfSaveBtn = "//*[text()='Save']//ancestor::button";
        private string tfCancelBtn = "//*[text()='Cancel']";

        private string tfSUFormTitle = "//*[text()='Select User']";
        private string tfSUFormSearchBar = "//*[text()='Select User']//ancestor::div[2]//*[@aria-label='search']";
        private string tfSUFormStaffCode = "//*[text()='Select User']//ancestor::div[2]//*[text()='Staff Code']//ancestor::th";
        private string tfSUFormFullName = "//*[text()='Select User']//ancestor::div[2]//*[text()='Full Name']//ancestor::th";
        private string tfSUFormType = "//*[text()='Select User']//ancestor::div[2]//*[text()='Type']//ancestor::th";
        private string tfSUFormCancelBtn = "//*[text()='Select User']//ancestor::div[2]//*[text()='Cancel']//ancestor::button";
        private string tfSUFormSaveBtn = "//*[text()='Select User']//ancestor::div[2]//*[text()='Save']//ancestor::button";
        
        private string tfSAFormTitle = "//*[contains(text(), 'Select Asset')]";
        private string tfSAFormSearchBar = "//*[contains(text(), 'Select Asset')]//ancestor::div[2]//*[@aria-label='search']";
        private string tfSAFormAssetCode = "//*[contains(text(), 'Select Asset')]//ancestor::div[2]//*[text()='Asset Code']//ancestor::th";
        private string tfSAFormAssetName = "//*[contains(text(), 'Select Asset')]//ancestor::div[2]//*[text()='Asset Name']//ancestor::th";
        private string tfSAFormCategory = "//*[contains(text(), 'Select Asset')]//ancestor::div[2]//*[text()='Category']//ancestor::th";
        private string tfSAFormCancelBtn = "//*[contains(text(), 'Select Asset')]//ancestor::div[2]//*[text()='Cancel']//ancestor::button";
        private string tfSAFormSaveBtn = "//*[contains(text(), 'Select Asset')]//ancestor::div[2]//*[text()='Save']//ancestor::button";

        private string tfYearPicker = "//*[@class='ant-picker-year-btn']";
        private string tfPrevYear = "//*[@class='ant-picker-header-super-prev-btn']";
        private string tfNextYear = "//*[@class='ant-picker-header-super-next-btn']";
        private string tfMonthPicker = "//*[@class='ant-picker-month-btn']";

        private string tfEditIcon = "//*[text()='Waiting for acceptance']//ancestor::tr//*[@data-testid='EditIcon']//ancestor::div[1]";
        private string tfEditUserSearchBar = "//*[text()='User list']//ancestor::div[2]//*[@aria-label='search']";
        private string tfEditUserFormSaveBtn = "//*[text()='User list']//ancestor::div[2]//*[text()='Save']//ancestor::button";
        private string tfEditAssetSearchBar = "//*[text()='Asset list']//ancestor::div[2]//*[@aria-label='search']";
        private string tfEditAssetFormSaveBtn = "//*[text()='Asset list']//ancestor::div[2]//*[text()='Save']//ancestor::button";

        private string tfPopupTitle1 = "//*[text()='Are you sure ?']";
        private string tfPopupMessage1 = "//*[contains(text(), 'delete this assignment')]";
        private string tfPopupDeleteBtn = "//*[text()='Delete']//ancestor::button";

        private string tfPopupTitle2 = "//*[text()='Delete Assignment Successfully']";
        private string tfOKBtn = "//*[text()='OK']//ancestor::button";

        public AssignmentPage(IWebDriver driver) : base(driver)
        {
        }
        public bool IsAssignmentPageDisplayed()
        {
            if (IsElementDisplay(tfAssignmentPage)
                && IsElementDisplay(tfAssignmentList)
                && IsElementDisplay(tfFilterByType)
                && IsElementDisplay(tfFilterByAssignedDate)
                && IsElementDisplay(tfSearchBar)
                && IsElementDisplay(tfCreateBtn))
            {
                TestContext.WriteLine("\n Assignment Page is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Assignment Page is not displayed!");
                return false;
            }
        }
        public bool IsAssignmentListDisplayed()
        {
            if (IsElementDisplay(tfNumberColumn)
               && IsElementDisplay(tfAssetCodeColumn)
               && IsElementDisplay(tfAssetNameColumn)
               && IsElementDisplay(tfAssignedToColumn)
               && IsElementDisplay(tfAssignedByColumn)
               && IsElementDisplay(tfAssignedDateColumn)
               && IsElementDisplay(tfStateColumn)
               && IsElementDisplay(tfActionColumn))
            {
                TestContext.WriteLine("\n Assignment List is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Assignment List is not displayed!");
                return false;
            }
        }
        public void ClickCreateBtn()
        {
            Click(tfCreateBtn);
        }
        public bool IsCreateNewAssignmentFormDisplayed()
        {
            if (IsElementDisplay(tfCreateFormTitle)
               && IsElementDisplay(tfUserField)
               && IsElementDisplay(tfUserFieldGlass)
               && IsElementDisplay(tfAssetField)
               && IsElementDisplay(tfAssetFieldGlass)
               && IsElementDisplay(tfAssignedDate)
               && IsElementDisplay(tfNoteField)
               && IsElementDisplay(tfSaveBtn)
               && IsElementDisplay(tfCancelBtn))
            {
                TestContext.WriteLine("\n Create New Assignment Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create New Assignment Form is not displayed!");
                return false;
            }
        }
        public void CreateNewAssignment(NewAssignment assign)
        {
            Click(tfUserFieldGlass);
            Thread.Sleep(3000);
            Assert.True(IsSelectUserFormDisplayed());
            SendKeys(tfSUFormSearchBar, assign.StaffInfo);
            Click("//*[text()='"+ assign.StaffInfo + "']//ancestor::tr//*[@type='radio']");
            Click(tfSUFormSaveBtn);

            Click(tfAssetFieldGlass);
            Thread.Sleep(3000);
            Assert.True(IsSelectAssetFormDisplayed());
            SendKeys(tfSAFormSearchBar, assign.AssetInfo);
            Click("//*[text()='" + assign.AssetInfo + "']//ancestor::tr//*[@type='radio']");
            Click(tfSAFormSaveBtn);

            Click(tfAssignedDate);
            Thread.Sleep(3000);
            ChooseDate(assign.AssignedYear, assign.AssignedMonth, assign.AssignedDay);

            Click(tfSaveBtn);
        }
        public bool IsSelectUserFormDisplayed()
        {
            if (IsElementDisplay(tfSUFormTitle)
               && IsElementDisplay(tfSUFormSearchBar)
               && IsElementDisplay(tfSUFormStaffCode)
               && IsElementDisplay(tfSUFormFullName)
               && IsElementDisplay(tfSUFormType)
               && IsElementDisplay(tfSUFormCancelBtn)
               && IsElementDisplay(tfSUFormSaveBtn))
            {
                TestContext.WriteLine("\n Select User Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Select User Form is not displayed!");
                return false;
            }
        }
        public bool IsSelectAssetFormDisplayed()
        {
            if (IsElementDisplay(tfSAFormTitle)
               && IsElementDisplay(tfSAFormSearchBar)
               && IsElementDisplay(tfSAFormAssetCode)
               && IsElementDisplay(tfSAFormAssetName)
               && IsElementDisplay(tfSAFormCategory)
               && IsElementDisplay(tfSAFormCancelBtn)
               && IsElementDisplay(tfSAFormSaveBtn))
            {
                TestContext.WriteLine("\n Select Asset Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Select Asset Form is not displayed!");
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
        public void ChooseAssignmentToEdit()
        {
            Click(tfStateColumn);
            Click(tfEditIcon);
        }
        public bool IsEditAssignmentFormDisplayed()
        {
            if (IsElementDisplay(tfEditFormTitle)
               && IsElementDisplay(tfUserField)
               && IsElementDisplay(tfUserFieldGlass)
               && IsElementDisplay(tfAssetField)
               && IsElementDisplay(tfAssetFieldGlass)
               && IsElementDisplay(tfAssignedDate)
               && IsElementDisplay(tfNoteField)
               && IsElementDisplay(tfSaveBtn)
               && IsElementDisplay(tfCancelBtn))
            {
                TestContext.WriteLine("\n Create New Assignment Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create New Assignment Form is not displayed!");
                return false;
            }
    }
        public void EditUser(string UserInfo)
        {
            Click(tfUserFieldGlass);
            Thread.Sleep(3000);
            SendKeys(tfEditUserSearchBar, UserInfo);
            Click("//*[text()='" + UserInfo + "']//ancestor::tr//*[@type='radio']");
            Click(tfEditUserFormSaveBtn);
        }
        public void EditAsset(string AssetInfo)
        {
            Click(tfAssetFieldGlass);
            Thread.Sleep(3000);
            SendKeys(tfEditAssetSearchBar, AssetInfo);
            Click("//*[text()='" + AssetInfo + "']//ancestor::tr//*[@type='radio']");
            Click(tfEditAssetFormSaveBtn);
        }
        public void EditNote(string Note)
        {
            FindElementByXpath(tfNoteField).Clear();
            SendKeys(tfNoteField, Note);
        }
        public void SaveEdit()
        {
            Click(tfSaveBtn);
        }
        public void ChooseAssignmentToDelete()
        {
            Click("//*[text()='Waiting for acceptance']//ancestor::tr//*[@data-testid='HighlightOffIcon']//ancestor::div[1]");
        }
        
        public bool IsDeletePopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle1)
                && IsElementDisplay(tfPopupMessage1)
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
        public bool IsDeleteSuccessfullyPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle2)
                && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Delete successfully popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Delete successfully popup is not displayed!");
                return false;
            }
        }
    }
}
