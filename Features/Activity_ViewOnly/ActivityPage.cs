using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.Activity_ViewOnly
{
    public class ActivityPage
    {
        const string MEASUREMENTS_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Measurements')]";
        const string ADD_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string NAME_INPUT = "//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_ACTIVITY_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CLOSE_ACTIVITY_DETAILS = "//button[text()='Close']";
        const string CANCEL_ACTIVITY_DETAILS = "//button[contains(@class, 'cancel')]";
        const string ACTIVITY_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string ACTIVITY_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string ACTIVITY_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string ACTIVITY_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string LIST_MANAGEMENT_PAGE = " //*[@class='page-title' and contains(text(),'Element List Management')]";
        const string ACTIVITY_POPUP = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Activity')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string LIST_MANAGEMENT_TAB = "//a[text()='List Management']";
        const string LIST_MANAGEMENT_DROPDOWN = "//select[@id='elementListOptionId']";
        const string ACTIVITY_VALUE_IN_LM_DROPDOWN = "//select[@id='elementListOptionId']//option[contains(text(),'Activities')]";

        public static void DeleteActivityIfExist(string activityName)
        {
            LogWriter.WriteLog("Executing  ActivityPage.DeleteActivityIfExist");
            WaitForActivityAlertCloseIfAny();
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(ACTIVITY_RECORD, activityName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedActivity(activityName);
            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing ActivityPage.ClickOnListManagementTab");
            if (WebDriverUtil.GetWebElement(LIST_MANAGEMENT_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(LIST_MANAGEMENT_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void CloseActivityDetailSideBar()
        {
            LogWriter.WriteLog("Executing ActivityPage CloseActivityDetailSideBar()");
            IWebElement activityDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_ACTIVITY_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (activityDetailsSideBar != null)
            {
                activityDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            activityDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_ACTIVITY_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (activityDetailsSideBar != null)
            {
                activityDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        
        public static void DeleteCreatedActivity(string activityName)
        {
            LogWriter.WriteLog("Executing ActivityPage DeleteCreatedActivity");

            WebDriverUtil.GetWebElement(String.Format(ACTIVITY_RECORD, activityName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate Activity record on Activity page - {0}", String.Format(ACTIVITY_RECORD, activityName))).Click();


            WebDriverUtil.GetWebElement(String.Format(ACTIVITY_DELETE_BUTTON, activityName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Activity delete button on Activity details - {0}", String.Format(ACTIVITY_DELETE_BUTTON, activityName))).Click();


            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(ACTIVITY_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(ACTIVITY_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", ACTIVITY_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
                WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
                IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (alert == null)
                {
                    WebDriverUtil.WaitForWebElementInvisible(ACTIVITY_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                }
                else
                {
                    throw new Exception(string.Format("Unable to delete Activity Error - {0}", alert.Text));
                }
            }
        }
        public static void VerifyCreatedActivity(string activityName)
        {
            LogWriter.WriteLog("Executing ActivityPage VerifyCreatedActivity");
            WebDriverUtil.GetWebElement(String.Format(ACTIVITY_RECORD, activityName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record on Activity page - {0}", String.Format(ACTIVITY_RECORD, activityName)));
            BaseClass._AttachScreenshot.Value = true;
            CloseActivityDetailSideBar();
        }
         
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ActivityPage.VerifyAddButtonIsNotPresent");
            IWebElement addButton = WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string activityName)
        {
            LogWriter.WriteLog("Executing ActivityPage.VerifyDeleteButtonIsNotPresent");
            WebDriverUtil.GetWebElement(String.Format(ACTIVITY_RECORD, activityName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Activity record on Activity page - {0}", String.Format(ACTIVITY_RECORD, activityName))).Click();
            IWebElement deleteButton = WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);

            if (deleteButton != null)
                throw new Exception("delete button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }


        public static void AddNewActivityWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing ActivityPage AddNewActivityWithGivenInput");
            ClickOnAddButton();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input on Activity page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button on Activity page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(ACTIVITY_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(ACTIVITY_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Activity Error - {0}", alert.Text));
                        }
                    }
                }
            }
        } 
        public static void ClickOnActivity()
        {
            LogWriter.WriteLog("Executing ActivityPage ClickOnActivity");
            WebDriverUtil.GetWebElement(LIST_MANAGEMENT_DROPDOWN,
                WebDriverUtil.NO_WAIT, String.Format("Unable to locate list management dropdown - {0}", LIST_MANAGEMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(ACTIVITY_VALUE_IN_LM_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Activity value - {0}", ACTIVITY_VALUE_IN_LM_DROPDOWN)).Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing ActivityPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button on Activitys page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseActivityForm()
        {
            LogWriter.WriteLog("Executing ActivityPage CloseActivityForm");
            WaitForActivityAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_ACTIVITY_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnMeasurementsTab()
        {
            LogWriter.WriteLog("Executing ActivityPage ClickOnMeasurementsTab");
            IWebElement measurementsTab = WebDriverUtil.GetWebElement(MEASUREMENTS_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (measurementsTab != null)
            {
                measurementsTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForActivityAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing ActivityPage WaitForActivityAlertCloseIfAny ");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }

    }
}

