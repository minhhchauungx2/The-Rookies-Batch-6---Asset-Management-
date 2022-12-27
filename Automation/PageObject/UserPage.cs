using Automation.DAO;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Automation.PageObject
{
    public class UserPage : WebDriverAction
    {
        public UserPage(IWebDriver driver) : base(driver)
        {
        }

        private string tfUserPage = "//*[text()='Manage User']//ancestor::li";
        private string tfUserList = "//div[text()='User list']";
        private string tfSearchBar = "//*[@aria-label='search']";

        private string tfCreateUserBtn = "//button[text()='Create new user']";
        private string tfSubmitBtn = "//button[@type='submit']";

        private string tfCreateFormTitle = "//*[text()='Create New User']";
        private string tfFirstName = "//input[@id='basic_FirstName']";
        private string tfLastName = "//input[@id='basic_LastName']";
        private string tfDoB = "//input[@id='basic_DateOfBirth']";
        private string tfJoinedDate = "//input[@id='basic_JoinedDate']";
        private string tfType = "//div[@class='ant-select-selector']";

        private string tfYearPicker = "//button[@class='ant-picker-year-btn']";
        private string tfPrevYear = "//*[@class='ant-picker-header-super-prev-btn']";
        private string tfNextYear = "//*[@class='ant-picker-header-super-next-btn']";
        private string tfMonthPicker = "//*[@class='ant-picker-month-btn']";

        private string tfPopupTitle = "//*[contains(text(), 'created')]";
        private string tfPopupMessage = "//*[contains(text(), 'created')]//ancestor::div[2]//*[@class='ant-modal-confirm-content']";
        private string tfPopupOkBtn = "//*[text()='OK']//ancestor::button";
        private string tfPopupTitle2 = "//*[contains(text(), 'This is information')]";
        private string tfPopupUserName = "//*[contains(text(), 'User Name: ')]";

        private string tfStaffCodeColumn = "//span[text()='Staff Code']/ancestor::th";
        private string tfFullNameColumn = "//span[text()='Full Name']//ancestor::th";
        private string tfUserNameColumn = "//span[text()='User Name']//ancestor::th";
        private string tfJoinedDateColumn = "//span[text()='Joined Date']//ancestor::th";
        private string tfTypeColumn = "//span[text()='Type']//ancestor::th";
        private string tfActionColumn = "//th[text()='Action']";

        private string tfEditFormTitle = "//p[text()='Edit User']";
        private string tfUserName = "//input[@id='basic_UserName']";
        private string tfCancelBtn = "//*[text()='Cancel']";

        private string tfPopupTitle3 = "//*[text()='Are you sure ?']";
        private string tfPopupMessage3 = "//*[contains(text(), 'disable this user')]";
        private string tfDisableBtn = "//*[text()='Disable']";

        private string tfPopupTitle4 = "//*[text()='User delete successfully!']";

        public bool IsUserPageDisplayed()
        {
            if (IsElementDisplay(tfUserPage)
                && IsElementDisplay(tfUserList)
                && IsElementDisplay(tfSearchBar)
                && IsElementDisplay(tfCreateUserBtn))
            {
                TestContext.WriteLine("\n User Page is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n User Page is not displayed!");
                return false;
            }
        }
        public void ClickCreateBtn()
        {
            Click(tfCreateUserBtn);
        }
        public bool IsCreateNewUserFormDisplayed()
        {
            if (IsElementDisplay(tfCreateFormTitle)
                && IsElementDisplay(tfFirstName)
                && IsElementDisplay(tfLastName)
                && IsElementDisplay(tfDoB)
                && IsElementDisplay(tfJoinedDate)
                && IsElementDisplay(tfType)
                && IsElementDisplay(tfCancelBtn)
                && IsElementDisplay(tfSubmitBtn))
            {
                TestContext.WriteLine("\n Create New User Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create New User Form is not displayed!");
                return false;
            }
        }
        public void CreateNewUser(NewUser user)
        {
            SendKeys(tfFirstName, user.FirstName);
            SendKeys(tfLastName, user.LastName);
            Click(tfDoB);
            Thread.Sleep(5000);
            ChooseDate(user.DOBYear, user.DOBMonth, user.DOBDay);
            SendKeys(tfJoinedDate, user.JoinedDate);
            ChooseJoinedDate(user.JoinedDate, user.JoinedDay);
            ChooseGender(user.Gender);
            ChooseRole(user.Type);
            Thread.Sleep(3000);
            Click(tfSubmitBtn);
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
        public void ChooseJoinedDate(string date, int day)
        {
            Click("//td[@title='" + date + "']//*[text()='" + day + "']");
        }
        public void ChooseGender(int gender)
        {
            Click("//input[@value='" + gender + "']");
        }
        public void ChooseRole(string type)
        {
            Click(tfType);
            Click("//*[@title='" + type + "']");
        }
        public bool IsCreateSuccessPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle)
                && IsElementDisplay(tfPopupOkBtn))
            {
                TestContext.WriteLine("\n Create Success Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Create Success Popup is not displayed!");
                return false;
            }
        }
        public void GetUsername()
        {
            string info = getText(tfPopupUserName);
            string username = info.Substring(11);
            TestContext.WriteLine("\n Username: " + username);
            Click(tfPopupOkBtn);
            Thread.Sleep(5000);
            SearchUser(username);
        }
        public void ClickPopup()
        {
            Click(tfPopupOkBtn);
        }
        public void SearchUser(string username)
        {
            FindElementByXpath(tfSearchBar).Clear();
            SendKeys(tfSearchBar, username);
            Thread.Sleep(3000);
            ChooseUser(username);
        }
        public void ChooseUser(string username)
        {
            Click("//*[text()='" + username + "']");
        }
        public bool IsInformationPopUpDisplayed()
        {
            string info = getText(tfPopupUserName);
            string username = info.Substring(11);

            if (IsElementDisplay(tfPopupTitle2)
                && IsElementDisplay(tfPopupOkBtn)
                && "User Name: " + username == info)
            {
                TestContext.WriteLine("\n Information Popup is displayed! \n Username is " + username);
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Information Popup is not displayed!");
                return false;
            }
        }
        public void ChooseUserToEdit()
        {
            string info = getText(tfPopupUserName);
            string username = info.Substring(11);

            ClickPopup();
            Click(tfSearchBar);
            FindElementByXpath(tfSearchBar).Clear();
            SendKeys(tfSearchBar, username);
            Thread.Sleep(3000);
            string tfEditXpath = "//*[text()='" + username + "']//ancestor::tr//div//*[@data-testid='EditIcon']";
            Click(tfEditXpath);
        }
        public bool IsEditUserFormDisplayed()
        {
            if (IsElementDisplay(tfEditFormTitle)
                && IsElementDisplay(tfUserName)
                && IsElementDisplay(tfFirstName)
                && IsElementDisplay(tfLastName)
                && IsElementDisplay(tfDoB)
                && IsElementDisplay(tfJoinedDate)
                && IsElementDisplay(tfType)
                && IsElementDisplay(tfCancelBtn)
                && IsElementDisplay(tfSubmitBtn))
            {
                TestContext.WriteLine("\n Edit User Form is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Edit User Form is not displayed!");
                return false;
            }
        }
        public void SaveEdit()
        {
            Click(tfSubmitBtn);
        }
        public void ChooseUserToDelete()
        {
            string info = getText(tfPopupUserName);
            string username = info.Substring(11);

            ClickPopup();
            Click(tfSearchBar);
            FindElementByXpath(tfSearchBar).Clear();
            SendKeys(tfSearchBar, username);
            Thread.Sleep(3000);
            string tfDeleteXpath = "//*[text()='" + username + "']//ancestor::tr//div//*[@data-testid='HighlightOffIcon']//ancestor::div[1]";
            Click(tfDeleteXpath);
        }
        public bool IsDisablePopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle3)
               && IsElementDisplay(tfPopupMessage3)
               && IsElementDisplay(tfCancelBtn)
               && IsElementDisplay(tfDisableBtn))
            {
                TestContext.WriteLine("\n Confirmation disable popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Confirmation disable popup is not displayed!");
                return false;
            }
        }
        public bool IsDisableSuccessfullyPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle4)
               && IsElementDisplay(tfPopupOkBtn))
            {
                TestContext.WriteLine("\n Disable successfully popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Disable successfully popup is not displayed!");
                return false;
            }
        }
        public bool IsUserListDisplayed()
        {
            if (IsElementDisplay(tfStaffCodeColumn)
               && IsElementDisplay(tfFullNameColumn)
               && IsElementDisplay(tfUserNameColumn)
               && IsElementDisplay(tfJoinedDateColumn)
               && IsElementDisplay(tfTypeColumn)
               && IsElementDisplay(tfActionColumn))
            {
                TestContext.WriteLine("\n User List is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n User List is not displayed!");
                return false;
            }
        }
        public void DisableUser()
        {
            Click("//*[text()='Disable']//ancestor::button");
        }
        public bool CheckDisableUserSuccessfully(string username)
        {
            FindElementByXpath(tfSearchBar).Clear();
            SendKeys(tfSearchBar, username);
            Thread.Sleep(3000);
            if (IsElementDisplay("//*[text()='No data']"))
            {
                TestContext.WriteLine("\n Disable user successfully!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Disable user failed!");
                return false;
            }
        }
    }
}
