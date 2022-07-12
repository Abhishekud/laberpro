using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Rest
{
    public class RestPage
    {
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string AllowanceCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Allowances')]";
        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseRestFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseRestDetails = "//button[text()='Close']";
        private const string CancelRestDetails = "//button[contains(@class, 'cancel')]";
        private const string RestDeleteButton = "//button[contains(@class,'delete')]";
        private const string RestRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string RestDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string RestDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']"; private const string RestPopup = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Rest')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string RestsPage = "//*[@class='page-title' and text()='Rests']";
        private const string RestTab = "//a[text()='Rest']";
        private const string EffectiveNetWeightPoundsHandledInput = "//select[@id='poundsHandled']";
        private const string PercentTimeUnderLoadInput = "//select[@id='percentUnderLoad']";

        public static void DeleteRestIfExist(string restName)
        {
            LogWriter.WriteLog("Executing  RestPage.DeleteRestIfExist");
            WaitForRestAlertCloseIfAny();
            var restRecordXpath = string.Format(RestRecord, restName);
            var record = WebDriverUtil.GetWebElementAndScroll(restRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedRest(restName);
            }
        }
        public static void ClickOnAllowanceTab()
        {
            LogWriter.WriteLog("Executing RestPage.ClickOnAllowanceTab");
            var allowanceTab = WebDriverUtil.GetWebElement(AllowanceCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (allowanceTab == null) return;
            allowanceTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void DeleteCreatedRest(string restName)
        {
            LogWriter.WriteLog("Executing RestPage DeleteCreatedRest");
            var restRecordXpath = string.Format(RestRecord, restName);
            WebDriverUtil.GetWebElement(restRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate Rest record on Rest page - {restRecordXpath}").Click();
            WebDriverUtil.GetWebElement(RestDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
           $"Unable to locate Rest delete button on Rest details - {RestDeleteButton}").Click();


            var confirmationPopup = WebDriverUtil.GetWebElement(RestDeleteConfirmPopup, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup == null) return;
            WebDriverUtil.GetWebElement(RestDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {RestDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(RestDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Rest Error - {alert.Text}");
            }
        }

        public static void CloseRestDetailSideBar()
        {
            LogWriter.WriteLog("Executing RestPage CloseRestDetailSideBar()");
            var restDetailsSideBar = WebDriverUtil.GetWebElement(CloseRestDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (restDetailsSideBar != null)
            {
                restDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            restDetailsSideBar = WebDriverUtil.GetWebElement(CancelRestDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (restDetailsSideBar == null) return;
            restDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }


        public static void VerifyCreatedRest(string restName)
        {
            LogWriter.WriteLog("Executing RestPage VerifyCreatedRest");
            var restRecordXpath = string.Format(RestRecord, restName);
            WebDriverUtil.GetWebElement(restRecordXpath, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record on Rest page - {restRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            CloseRestDetailSideBar();
        }

        public static void FindRestByName(string restName)
        {
            LogWriter.WriteLog("Executing RestPage FindRestByName");
            var restRecordXpath = string.Format(RestRecord, restName);
            WebDriverUtil.GetWebElement(restRecordXpath, WebDriverUtil.DEFAULT_WAIT,
                $"Unable to locate record on Rest page - {restRecordXpath}").Click();
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing RestPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add Button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing RestPage.VerifyDeleteButtonIsNotPresent");
            var deleteButton = WebDriverUtil.GetWebElement(RestDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete Button is found but we expect it should not be present when user login from view only access");
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("Edit TextBox is Enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void AddNewRestWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing RestPage AddNewRestWithGivenInputIfNotExist");
            WaitForRestAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            var restRecordXpath = string.Format(RestRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(restRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewRestWithGivenInput(inputData);
            }
        }

        public static void AddNewRestWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing RestPage AddNewRestWithGivenInput");
            ClickOnAddButton();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on Rest page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }

            if (Util.ReadKey(dictionary, "Effective Net Weight Pounds Handled") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(EffectiveNetWeightPoundsHandledInput, WebDriverUtil.NO_WAIT,
                       $"Unable to locate Effective Net Weight Pounds Handled input on create Rest page - {EffectiveNetWeightPoundsHandledInput}"))
                    .SelectByText(dictionary["Effective Net Weight Pounds Handled"]);
            }
            if (Util.ReadKey(dictionary, "Percent Time Under Load") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(PercentTimeUnderLoadInput, WebDriverUtil.FIVE_SECOND_WAIT,
                        $"Unable to locate Percent Time Under Load input on create Rest page - {PercentTimeUnderLoadInput}"))
                    .SelectByText(dictionary["Percent Time Under Load"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on Rest page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(RestPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(RestPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new Rest Error - {alert.Text}");
            }
        }


        public static void ClickOnRestTab()
        {
            LogWriter.WriteLog("Executing RestPage.ClickOnRestTab");
            if (WebDriverUtil.GetWebElement(RestsPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null) return;
            WebDriverUtil.GetWebElement(RestTab, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate Rest tab - {RestTab}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing RestPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Rest page  - {AddButton}").Click();

        }
        public static void CloseRestForm()
        {
            LogWriter.WriteLog("Executing RestPage CloseRestForm");
            WaitForRestAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseRestFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing RestPage ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null) return;
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForRestAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing RestPage WaitForRestAlertCloseIfAny ");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
            WebDriverUtil.GetWebElementAndScroll(NameInput);
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

