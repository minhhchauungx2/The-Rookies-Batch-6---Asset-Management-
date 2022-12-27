using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Automation.PageObject
{
    public class RequestPage : WebDriverAction
    {
        public RequestPage(IWebDriver driver) : base(driver)
        {
        }

        private string tfRequestPage = "//*[text()='Request returning']//ancestor::li";
        private string tfRequestList = "//*[text()='Request List']";
        private string tfSearchBar = "//*[@aria-label='search']";

        private string tfNumberColumn = "//*[text()='No.']//ancestor::th";
        private string tfAssetCodeColumn = "//*[text()='Asset Code']//ancestor::th";
        private string tfAssetNameColumn = "//*[text()='Asset Name']//ancestor::th";
        private string tfRequestedByColumn = "//*[text()='Requested by']//ancestor::th";
        private string tfAssignedDateColumn = "//*[text()='Assigned Date']//ancestor::th";
        private string tfAcceptedByColumn = "//*[text()='Accepted by']//ancestor::th";
        private string tfReturnedDateColumn = "//*[text()='Returned Date']//ancestor::th";
        private string tfStateColumn = "//*[text()='State']//ancestor::th";
        private string tfActionColumn = "//th[text()='Action']";

        private string tfPopUpTitle1 = "//*[text()='Are you sure?']";
        private string tfPopUpMess1 = "//*[contains(text(), 'mark this returning request as \"Completed\"?')]";
        private string tfPopUpNoBtn = "//*[text()='No']//ancestor::button";
        private string tfPopUpYesBtn = "//*[text()='Yes']//ancestor::button";

        private string tfPopUpTitle2 = "//*[text()='Completed Request Returning Successfully']";
        private string tfPopUpOKBtn = "//*[text()='OK']//ancestor::button";

        private string tfPopUpMess3 = "//*[contains(text(), 'cancel this returning request?')]";

        private string tfPopUpTitle4 = "//*[text()='Cancel Request Returning Successfully']";

        public bool IsRequestPageDisplayed()
        {
            if (IsElementDisplay(tfRequestPage)
                && IsElementDisplay(tfRequestList)
                && IsElementDisplay(tfSearchBar))
            {
                TestContext.WriteLine("\n Request Page is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Request Page is not displayed!");
                return false;
            }
        }
        public bool IsRequestListDisplayed()
        {
            if (IsElementDisplay(tfNumberColumn)
               && IsElementDisplay(tfAssetCodeColumn)
               && IsElementDisplay(tfAssetNameColumn)
               && IsElementDisplay(tfRequestedByColumn)
               && IsElementDisplay(tfAssignedDateColumn)
               && IsElementDisplay(tfAcceptedByColumn)
               && IsElementDisplay(tfReturnedDateColumn)
               && IsElementDisplay(tfStateColumn)
               && IsElementDisplay(tfActionColumn))
            {
                TestContext.WriteLine("\n Request List is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Request List is not displayed!");
                return false;
            }
        }
        public void ChooseRequestToComplete()
        {
            Click("//*[text()='Waiting for returning']//ancestor::tr//*[@data-testid='CheckIcon']//ancestor::div[1]");
        }
        public bool IsCompleteRequestConfirmationPopupDisplayed()
        {
            if (IsElementDisplay(tfPopUpTitle1)
                && IsElementDisplay(tfPopUpMess1)
                && IsElementDisplay(tfPopUpYesBtn)
                && IsElementDisplay(tfPopUpNoBtn))
            {
                TestContext.WriteLine("\n Complete Request Confirmation Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Complete Request Confirmation Popup is not displayed!");
                return false;
            }
        }
        public void CompleteRequest()
        {
            Click(tfPopUpYesBtn);
        }
        public bool IsCompleteRequestSuccessfullyPopupDisplayed()
        {
            if (IsElementDisplay(tfPopUpTitle2)
                && IsElementDisplay(tfPopUpOKBtn))
            {
                TestContext.WriteLine("\n Complete Request Successfully Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Complete Request Successfully Popup is not displayed!");
                return false;
            }
        }
        public void Confirm()
        {
            Click(tfPopUpOKBtn);
        }
        public void ChooseRequestToCancel()
        {
            Click("//*[text()='Waiting for returning']//ancestor::tr//*[@data-testid='ClearIcon']//ancestor::div[1]");
        }
        public bool IsCancelRequestConfirmationPopupDisplayed()
        {
            if (IsElementDisplay(tfPopUpTitle1)
                && IsElementDisplay(tfPopUpMess3)
                && IsElementDisplay(tfPopUpYesBtn)
                && IsElementDisplay(tfPopUpNoBtn))
            {
                TestContext.WriteLine("\n Cancel Request Confirmation Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Cancel Request Confirmation Popup is not displayed!");
                return false;
            }
        }
        public void CancelRequest()
        {
            Click(tfPopUpYesBtn);
        }
        public bool IsCancelRequestSuccessfullyPopupDisplayed()
        {
            if (IsElementDisplay(tfPopUpTitle4)
                && IsElementDisplay(tfPopUpOKBtn))
            {
                TestContext.WriteLine("\n Cancel Request Successfully Popup is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Cancel Request Successfully Popup is not displayed!");
                return false;
            }
        }
    }
}
