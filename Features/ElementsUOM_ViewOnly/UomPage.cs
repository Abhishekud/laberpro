using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.ElementsUOM_ViewOnly
{
    public class UomPage
    {
        const string MEASUREMENTS_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Measurements')]";
        const string ADD_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string NAME_INPUT = "//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_UOM_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CLOSE_UOM_DETAILS = "//button[text()='Close']";
        const string CANCEL_UOM_DETAILS = "//button[contains(@class, 'cancel')]";
        const string UOM_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string UOM_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string UOM_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string UOM_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string UOM_POPUP = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Classification')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string LIST_MANAGEMENT_TAB = "//a[text()='List Management']";
        const string LIST_MANAGEMENT_DROPDOWN = "//select[@id='elementListOptionId']";
        const string UOM_VALUE_IN_LM_DROPDOWN = "//select[@id='elementListOptionId']//option[contains(text(),'Units Of Measure')]";
        const string LIST_MANAGEMENT_PAGE = " //*[@class='page-title' and contains(text(),'Element List Management')]";
        public static void DeleteUomIfExist(string uomName)
        {
            LogWriter.WriteLog("Executing  UomPage.DeleteUomIfExist");
            WaitForUomAlertCloseIfAny();
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(UOM_RECORD, uomName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedUom(uomName);
            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing UomPage.ClickOnListManagementTab");


            if (WebDriverUtil.GetWebElement(LIST_MANAGEMENT_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(LIST_MANAGEMENT_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnMeasurementsTab()
        {
            LogWriter.WriteLog("Executing UomPage ClickOnMeasurementsTab");
            IWebElement measurementsTab = WebDriverUtil.GetWebElement(MEASUREMENTS_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (measurementsTab != null)
            {
                measurementsTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void CloseUomDetailSideBar()
        {
            LogWriter.WriteLog("Executing UomPage CloseUomDetailSideBar");
            IWebElement uomDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_UOM_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (uomDetailsSideBar != null)
            {
                uomDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            uomDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_UOM_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (uomDetailsSideBar != null)
            {
                uomDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        
        public static void DeleteCreatedUom(string uomName)
        {
            LogWriter.WriteLog("Executing UomPage DeleteCreatedUom");

            WebDriverUtil.GetWebElement(String.Format(UOM_RECORD, uomName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate UOM record on UOMs page - {0}", String.Format(UOM_RECORD, uomName))).Click();


            WebDriverUtil.GetWebElement(UOM_DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate UOM delete button on UOM details - {0}", UOM_DELETE_BUTTON)).Click();


            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(UOM_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(UOM_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", UOM_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
                WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
                IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (alert == null)
                {
                    WebDriverUtil.WaitForWebElementInvisible(UOM_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                }
                else
                {
                    throw new Exception(string.Format("Unable to delete UOM Error - {0}", alert.Text));
                }
            }
        }
        public static void VerifyCreatedUom(string uomName)
        { 
            LogWriter.WriteLog("Executing UomPage VerifyCreatedUom");
            WebDriverUtil.GetWebElement(String.Format(UOM_RECORD, uomName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record on UOMs page - {0}", String.Format(UOM_RECORD, uomName)));
            BaseClass._AttachScreenshot.Value = true;
            CloseUomDetailSideBar();
        }
         
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing UomPage.VerifyAddButtonIsNotPresent");
            IWebElement addButtton = WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButtton != null)
                throw new Exception("add button is found but we expect it should not be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string uomName)
        {
            LogWriter.WriteLog("Executing UomPage.VerifyDeleteButtonIsNotPresent");
            WebDriverUtil.GetWebElement(String.Format(UOM_RECORD, uomName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate UOM record on UOM page - {0}", String.Format(UOM_RECORD, uomName))).Click();
            IWebElement deleteButton = WebDriverUtil.GetWebElement(UOM_DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("delete button is found but we expect it should not be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;
        }


        public static void AddNewUomWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing UomPage AddNewUomWithGivenInput");
            ClickOnAddButton();
 
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input on UOMs page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button on UOMs page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(UOM_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(UOM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new UOMs Error - {0}", alert.Text));
                        }
                    }
                }
            }
        } 
        public static void ClickOnUOM()
        {
            LogWriter.WriteLog("Executing UomPage ClickOnUOM");
            WebDriverUtil.GetWebElement(LIST_MANAGEMENT_DROPDOWN,
                WebDriverUtil.NO_WAIT, String.Format("Unable to locate list management dropdown - {0}", LIST_MANAGEMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(UOM_VALUE_IN_LM_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate UOM value - {0}", UOM_VALUE_IN_LM_DROPDOWN)).Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing UomPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button on UOMs page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseUomForm()
        {
            LogWriter.WriteLog("Executing UomPage CloseUOMForm");
            WaitForUomAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_UOM_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
 
        public static void WaitForUomAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing UomPage WaitForUOMAlertCloseIfAny ");
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

