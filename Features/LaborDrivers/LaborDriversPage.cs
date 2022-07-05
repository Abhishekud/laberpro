using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.LaborDrivers
{
    public class LaborDriversPage
    {
        const string KRONOS_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        const string LABOR_DRIVERS_TAB = "//a[text()='Labor Drivers']";
        const string ADD_BUTTON = "//button[@id='add']";
        const string ADD_LABORDRIVERS_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@role='dialog']//*[@id='name']";
        const string SAVE_BUTTON = "//button[text()='Save']";
        const string CLOSE_LABORDRIVERS_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CLOSE_LABORDRIVERS_DETAILS = "//button[text()='Close']";
        const string LABORDRIVERS_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string LABORDRIVERS_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string LABORDRIVERS_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string LABORDRIVERS_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string LABORDRIVERSS_PAGE = "//h3[contains(text(),'Labor Drivers')]";
        const string LABORDRIVERSS_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Labor Driver')]";
        const string DRIVER_TYPE_INPUT = "  //select[@id='laborDriverType']";
        const string NUMBER_INPUT = "//input[@id='number']";
        const string NUMBER_OF_BUSINESS_DAYS_TO_LOOK_BACK_FOR_VOLUME_INPUT = " //input[@id='lookBackCount']";
        const string DRIVER_INPUT = "//input[@id='driver']";
        const string GENERIC_CATEGORY_INPUT = "//input[@id='genericCategory']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        private const string LaborDriversRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string AddButton = "//button[@id='add']";
        private const string ExportButton = "//button[@id='export']";
        private const string LaborDriversDeleteButton = "//button[contains(@class,'delete')]";
        private const string ExportLaborDrivers = "//*[contains(@class,'dropdown-menu dropdown-menu-right')]//a[text()='Export Labor Drivers']";
        private const string NameInput = "//*[@id='name']";

        public static void AddNewLaborDriversWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.AddLaborDriversWithGivenInputIfNotExist");
            WaitForLaborDriversAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(LABORDRIVERS_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewLaborDriversWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void DeleteLaborDriversIfExist(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.DeleteLaborDriversIfExist");
            WaitForLaborDriversAlertCloseIfAny();
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(LABORDRIVERS_RECORD, laborDriversName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedLaborDrivers(laborDriversName);
            }
        }
        public static void CloseLaborDriversDetailSideBar()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.CloseLaborDriversDetailSideBar");
            IWebElement LaborDriversDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_LABORDRIVERS_DETAILS, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (LaborDriversDetailsSideBar != null)
            {
                LaborDriversDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }
        }
        public static void DeleteCreatedLaborDrivers(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.DeleteCreatedLaborDrivers");
            CloseLaborDriversDetailSideBar();
            WebDriverUtil.GetWebElement(String.Format(LABORDRIVERS_RECORD, laborDriversName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate LaborDrivers record on LaborDriverss page - {0}", String.Format(LABORDRIVERS_RECORD, laborDriversName))).Click();


            WebDriverUtil.GetWebElement(String.Format(LABORDRIVERS_DELETE_BUTTON, laborDriversName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate LaborDrivers delete button on LaborDrivers details - {0}", String.Format(
                LABORDRIVERS_DELETE_BUTTON, laborDriversName))).Click();
            WebDriverUtil.GetWebElement(LABORDRIVERS_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", LABORDRIVERS_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LABORDRIVERS_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Labor Driver Error - {0}", alert.Text));
            }
        }
        public static void VerifyCreatedLaborDrivers(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyCreatedLaborDrivers");
            WebDriverUtil.GetWebElement(String.Format(LABORDRIVERS_RECORD, laborDriversName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate record LaborDriverss page - {0}", String.Format(LABORDRIVERS_RECORD, laborDriversName)));
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyCreatedLaborDrivers");
            WebDriverUtil.GetWebElement(LABORDRIVERSS_POPUP, WebDriverUtil.NO_WAIT, String.Format("Unable to locate AddMenuPopup"));
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddNewLaborDriversWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.AddNewLaborDriversWithGivenInput");
            CloseLaborDriversDetailSideBar();
            ClickOnAddButton();
            UserClickOnNewLaborDriversMenuLink();

            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input LaborDriverss page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Driver Type") != null)
            {
                WebDriverUtil.WaitFor(1);
                new SelectElement(WebDriverUtil.GetWebElement(DRIVER_TYPE_INPUT, WebDriverUtil.FIVE_SECOND_WAIT,
                String.Format("Unable to locate Driver Type input on create LaborDrivers  page - {0}", DRIVER_TYPE_INPUT)))
                    .SelectByText(dictionary["Driver Type"]);

            }

            if (Util.ReadKey(dictionary, "Number") != null)
            {
                WebDriverUtil.GetWebElement(NUMBER_INPUT, WebDriverUtil.FIVE_SECOND_WAIT,
                String.Format("Unable to locate  Number input on create LaborDrivers  page - {0}", NUMBER_INPUT))
                    .SendKeys(dictionary["Number"]);
            }
            if (Util.ReadKey(dictionary, "Number of business days to look back for volume") != null)
            {
                WebDriverUtil.GetWebElement(NUMBER_OF_BUSINESS_DAYS_TO_LOOK_BACK_FOR_VOLUME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate  Number of business days to look back for volume input on create  LaborDrivers page - {0}", NUMBER_OF_BUSINESS_DAYS_TO_LOOK_BACK_FOR_VOLUME_INPUT))
                    .SendKeys(dictionary["Number of business days to look back for volume"]);
            }
            if (Util.ReadKey(dictionary, "Driver") != null)
            {
                WebDriverUtil.GetWebElement(DRIVER_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Driverinput on create  LaborDrivers page - {0}", DRIVER_INPUT))
                    .SendKeys(dictionary["Driver"]);
            }
            if (Util.ReadKey(dictionary, "Generic Category") != null)
            {
                WebDriverUtil.GetWebElement(GENERIC_CATEGORY_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Generic Category input on create  LaborDrivers page - {0}", GENERIC_CATEGORY_INPUT))
                    .SendKeys(dictionary["Generic Category"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate save button on page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(LABORDRIVERSS_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ELEMENT_ALERT, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(LABORDRIVERSS_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new LaborDrivers Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void UserClickAddLaborDriversButton()
        {
            ClickOnAddButton();
            UserClickOnNewLaborDriversMenuLink();
        }
        public static void UserClickOnNewLaborDriversMenuLink()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.UserClickOnNewLaborDriversMenuLink");
            WebDriverUtil.GetWebElement(ADD_LABORDRIVERS_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewLaborDriversMenu menu link on add menu popup - {0}", ADD_LABORDRIVERS_LINK)).Click();
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button LaborDriverss page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseLaborDriversForm()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.CloseLaborDriversForm");
            WaitForLaborDriversAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_LABORDRIVERS_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnLaborDriversTab()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.ClickOnLaborDriversTab");
            if (WebDriverUtil.GetWebElement(LABORDRIVERSS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(LABOR_DRIVERS_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.ClickOnKronosTab");
            IWebElement kronosTab = WebDriverUtil.GetWebElement(KRONOS_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (kronosTab != null)
            {
                kronosTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForLaborDriversAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.WaitForLaborDriversAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);

            }
            WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportLaborDrivers, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export Option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyDeleteButtonIsNotPresent");
            var laborRecordXpath = string.Format(LaborDriversRecord, laborDriversName);
            WebDriverUtil.GetWebElement(laborRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate LaborDrivers record on LaborDrivers page - {laborRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(LaborDriversDeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);

            if (deleteButton.Enabled)
                throw new Exception("delete button is found but we expect it should not be present when user login from view only access");
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("edit TextBox is Enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }


    }
}

