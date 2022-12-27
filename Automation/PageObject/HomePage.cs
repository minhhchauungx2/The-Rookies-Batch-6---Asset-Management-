using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Automation.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private string tfHomePage = "//*[text()='Home']";
        private string tfUsername = "//a[@class='ant-dropdown-trigger']";

        private string tfChangePasswordBtn = "//*[text()='Change Password']//ancestor::li";
        private string tfLogoutBtn = "//*[text()='Logout']";

        private string tfPopupTitle = "//*[text()='Change Password']";
        private string tfPopupMessage = "//*[contains(text(), 'first time')]";
        private string tfPopupEyeIconOldPassword = "//input[@id='form_in_modal_oldPassword']//ancestor::div[1]//span[@aria-label='eye-invisible']";
        private string tfPopupEyeIconNewPassword = "//input[@id='form_in_modal_newPassword']//ancestor::div[1]//span[@aria-label='eye-invisible']";

        private string tfLabelOldPassword = "//*[@title='Old Password']";
        private string tfOldPassword = "//input[@id='form_in_modal_oldPassword']";
        private string tfLabelNewPassword = "//*[text()='New Password']";
        private string tfNewPassword = "//input[@id='form_in_modal_newPassword']";

        private string tfPopupTitle2 = "//*[text()='Are You Sure']";
        private string tfPopupMessage2 = "//*[contains(text(), 'log out')]";
        private string tfCancelBtn = "//*[text()='Cancel']";
        private string tfPopupMessage3 = "//*[contains(text(), 'changed successfully')]";
        
        private string tfSaveBtn = "//*[text()='Save']/ancestor::button";
        private string tfOKBtn = "//*[text()='OK']/ancestor::button";

        private string tfAssignment = "//*[text()='My Assignment']";
        private string tfAssetCodeColumn = "//*[text()='Asset Code']//ancestor::th";
        private string tfAssetNameColumn = "//*[text()='Asset Name']//ancestor::th";
        private string tfAssignedToColumn = "//*[text()='Assigned To']//ancestor::th";
        private string tfAssignedByColumn = "//*[text()='Assigned By']//ancestor::th";
        private string tfAssignedDateColumn = "//*[text()='Assigned Date']//ancestor::th";
        private string tfStateColumn = "//*[text()='State']//ancestor::th";
        private string tfActionColumn = "//th[text()='Action']";

        private string tfAcceptIcon = "//*[text()='Waiting for acceptance']//ancestor::tr//*[@data-testid='DoneOutlinedIcon']//ancestor::div[1]";
        private string tfDeclineIcon = "//*[text()='Waiting for acceptance']//ancestor::tr//*[@data-testid='ClearOutlinedIcon']//ancestor::div[1]";
        private string tfReturnIcon = "//*[text()='Accepted']//ancestor::tr//*[@data-testid='ReplayOutlinedIcon']//ancestor::div[1]";

        private string tfPopupTitle4 = "//*[text()='Are you sure ?']";
        private string tfPopupMessage4 = "//*[contains(text(), 'accept this assignment')]";
        private string tfPopupAcceptBtn = "//*[text()='Accept']//ancestor::button";
        
        private string tfPopupMessage6 = "//*[contains(text(), 'decline this assignment')]";
        private string tfPopupDeclineBtn = "//*[text()='Decline']//ancestor::button";
        
        private string tfPopupMessage7 = "//*[text()='Decline Assignmennt Successfully']";
        private string tfPopupMessage8 = "//*[text()='Accept Assignmennt Successfully']";
        private string tfPopupMessage9 = "//*[text()='Create Request For Returning Successfully']";

        private string tfPopupMessage5 = "//*[contains(text(), 'create request returning')]";
        public void ChangePasswordAtTheFirstTime(string password)
        {
            Click(tfNewPassword);
            SendKeys(tfNewPassword, password);
            Click(tfSaveBtn);
        }
        public bool IsHomePageDisplayed()
        {
            if (IsElementDisplay(tfHomePage))
            {
                TestContext.WriteLine("\n Home Page is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Home Page is not displayed!");
                return false;
            }
        }
        public bool CheckAccountThatUserLogin(string username)
        {
            if (username == getText(tfUsername))
            {
                TestContext.WriteLine("\n User is login with account: " + username);
                return true;
            }
            else
            {
                TestContext.WriteLine("\n User is login with wrong account");
                return false;
            }
        }
        public void LogOut()
        {
            Click(tfUsername);
            Thread.Sleep(3000);
            Click(tfLogoutBtn);
        }
        public bool IsLogOutPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle2)
                && IsElementDisplay(tfPopupMessage2)
                && IsElementDisplay(tfCancelBtn)
                && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n LogOut Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n LogOut Popup is not displayed!");
                return false;
            }
        }
        public void Confirm()
        {
            Click(tfOKBtn);
        }
        public void ChangePassword()
        {
            Click(tfUsername);
            Thread.Sleep(3000);
            Click(tfChangePasswordBtn);
        }
        public bool IsChangePasswordPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle)
                && IsElementDisplay(tfLabelOldPassword)
                && IsElementDisplay(tfOldPassword)
                && IsElementDisplay(tfLabelNewPassword)
                && IsElementDisplay(tfNewPassword)
                && IsElementDisplay(tfPopupEyeIconOldPassword)
                && IsElementDisplay(tfPopupEyeIconNewPassword)
                && IsElementDisplay(tfCancelBtn)
                && IsElementDisplay(tfSaveBtn))
            {
                TestContext.WriteLine("\n Change Password Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Change Password Popup is not displayed!");
                return false;
            }
        }
        public void DoChangePassword(string oldpw, string newpw)
        {
            SendKeys(tfOldPassword, oldpw);
            Click(tfPopupEyeIconOldPassword);
            SendKeys(tfNewPassword, newpw);
            Click(tfPopupEyeIconNewPassword);
        }
        public void SavePassword()
        {
            Click(tfSaveBtn);
        }
        public bool ChangePasswordSuccessfullyPopup()
        {
            if (IsElementDisplay(tfPopupTitle)
                && IsElementDisplay(tfPopupMessage3)
                && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Change Password successfully!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Change Password failed!");
                return false;
            }
        }
        public bool IsUserAssignmentDisplayed()
        {
            if (IsElementDisplay(tfAssignment)
               && IsElementDisplay(tfAssetCodeColumn)
               && IsElementDisplay(tfAssetNameColumn)
               && IsElementDisplay(tfAssignedToColumn)
               && IsElementDisplay(tfAssignedByColumn)
               && IsElementDisplay(tfAssignedDateColumn)
               && IsElementDisplay(tfStateColumn)
               && IsElementDisplay(tfActionColumn))
            {
                TestContext.WriteLine("\n User Assignment List is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n User Assignment List is not displayed!");
                return false;
            }
        }
        public void ChooseAssignmentToAccept()
        {
            Click(tfAcceptIcon);
        }
        public void Accept()
        {
            Click(tfPopupAcceptBtn);
        }
        public bool IsAcceptConfirmationPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle4)
               && IsElementDisplay(tfPopupMessage4)
               && IsElementDisplay(tfCancelBtn)
               && IsElementDisplay(tfPopupAcceptBtn))
            {
                TestContext.WriteLine("\n Accept confirmation popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Accept confirmation popup is not displayed!");
                return false;
            }
        }
        public bool IsAcceptSuccessfullyPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupMessage8)
               && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Accept successfully confirmation popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Accept successfully confirmation popup is not displayed!");
                return false;
            }
        }
        public void ChooseAssignmentToDecline()
        {
            Click(tfDeclineIcon);
        }
        public void Decline()
        {
            Click(tfPopupDeclineBtn);
        }
        public bool IsDeclineConfirmationPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle4)
               && IsElementDisplay(tfPopupMessage6)
               && IsElementDisplay(tfCancelBtn)
               && IsElementDisplay(tfPopupDeclineBtn))
            {
                TestContext.WriteLine("\n Decline confirmation popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Decline confirmation popup is not displayed!");
                return false;
            }
        }
        public bool IsDeclineSuccessfullyPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupMessage7)
               && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Decline successfully popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Decline successfully popup is not displayed!");
                return false;
            }
        }
        public void ChooseAssignmentToRequest()
        {
            Click(tfReturnIcon);
        }
        public bool IsRequestConfirmationPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupTitle4)
               && IsElementDisplay(tfPopupMessage5)
               && IsElementDisplay(tfCancelBtn)
               && IsElementDisplay(tfPopupAcceptBtn))
            {
                TestContext.WriteLine("\n Request confirmation popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Request confirmation popup is not displayed!");
                return false;
            }
        }
        public bool IsRequestSuccessfullyPopupDisplayed()
        {
            if (IsElementDisplay(tfPopupMessage9)
               && IsElementDisplay(tfOKBtn))
            {
                TestContext.WriteLine("\n Request successfully popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Request successfully popup is not displayed!");
                return false;
            }
        }
    }
}
