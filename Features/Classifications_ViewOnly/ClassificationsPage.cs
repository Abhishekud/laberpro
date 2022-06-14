using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.Classifications_ViewOnly
{
    public class ClassificationsPage
    {
        const string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        const string ADD_BUTTON = "//button[@id='add']";
        const string ADD_CLASSIFICATIONS_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_CLASSIFICATIONS_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CLOSE_CLASSIFICATIONS_DETAILS = "//button[text()='Close']";
        const string CANCEL_CLASSIFICATIONS_DETAILS = "//button[contains(@class, 'cancel')]";
        const string CLASSIFICATIONS_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string CLASSIFICATIONS_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string CLASSIFICATIONS_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CLASSIFICATIONS_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string CLASSIFICATIONS_PAGE = "//*[@class='page-title' and contains(text(),'Classifications')]";
        const string CLASSIFICATIONS_POPUP = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Classification')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string LIST_MANAGEMENT_TAB = "//a[text()='List Management']";
        const string LIST_MANAGEMENT_DROPDOWN = "//select[@id='standardFilingFieldId']";
        const string CLASSIFICATIONS_VALUE_IN_LM_DROPDOWN = "//select[@id='standardFilingFieldId']//option[@value='CLASSIFICATIONS']";

        public static void DeleteClassificationsIfExist(string classificationsName)
        {
            LogWriter.WriteLog("Executing  ClassificationsPage.DeleteClassificationsifexist");
            WaitForClassificationsAlertCloseIfAny();
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(CLASSIFICATIONS_RECORD, classificationsName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedClassifications(classificationsName);
            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.ClickOnListManagementTab");


            if (WebDriverUtil.GetWebElement(CLASSIFICATIONS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(LIST_MANAGEMENT_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void CloseClassificationsDetailSideBar()
        {
            LogWriter.WriteLog("Executing ClassificationsPage CloseClassificationsDetailSideBar()");
            IWebElement ClassificationsDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_CLASSIFICATIONS_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (ClassificationsDetailsSideBar != null)
            {
                ClassificationsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            ClassificationsDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_CLASSIFICATIONS_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (ClassificationsDetailsSideBar != null)
            {
                ClassificationsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        
        public static void DeleteCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage DeleteCreatedClassificationst");

            WebDriverUtil.GetWebElement(String.Format(CLASSIFICATIONS_RECORD, classificationsName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate Classifications record on Classificationss page - {0}", String.Format(CLASSIFICATIONS_RECORD, classificationsName))).Click();


            WebDriverUtil.GetWebElement(String.Format(CLASSIFICATIONS_DELETE_BUTTON, classificationsName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Classifications delete button on Classifications details - {0}", String.Format(CLASSIFICATIONS_DELETE_BUTTON, classificationsName))).Click();


            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(CLASSIFICATIONS_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(CLASSIFICATIONS_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", CLASSIFICATIONS_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
                WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
                IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (alert == null)
                {
                    WebDriverUtil.WaitForWebElementInvisible(CLASSIFICATIONS_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                }
                else
                {
                    throw new Exception(string.Format("Unable to delete Classifications Error - {0}", alert.Text));
                }
            }
        }
        public static void VerifyCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage VerifyCreatedClassifications");
            WebDriverUtil.GetWebElement(String.Format(CLASSIFICATIONS_RECORD, classificationsName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record on Classificationss page - {0}", String.Format(CLASSIFICATIONS_RECORD, classificationsName)));
            BaseClass._AttachScreenshot.Value = true;
            CloseClassificationsDetailSideBar();
        }
         
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.VerifyAddButtonIsNotPresent");
            IWebElement addClassification = WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addClassification != null)
                throw new Exception("Add Button is found but we expect it should not be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage.VerifyDeleteButtonIsNotPresent");
            WebDriverUtil.GetWebElement(String.Format(CLASSIFICATIONS_RECORD, classificationsName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate classifications record on classifications page - {0}", String.Format(CLASSIFICATIONS_RECORD, classificationsName))).Click();
            IWebElement deleteClassification = WebDriverUtil.GetWebElement(CLASSIFICATIONS_DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteClassification != null)
                throw new Exception("Delete Button is found but we expect it should not be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value=true;
        }
        
         
        public static void AddNewClassificationsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing ClassificationsPage AddNewClassificationsWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewClassificationsMenuLink();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input on Classificationss page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button on Classificationss page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(CLASSIFICATIONS_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(CLASSIFICATIONS_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Classificationss Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void UserClickOnNewClassificationsMenuLink()
        {
            LogWriter.WriteLog("Executing ClassificationsPage UserClickOnNewClassificationsMenuLink");
            WebDriverUtil.GetWebElement(ADD_CLASSIFICATIONS_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewClassificationsMenu menu link on add menu popup - {0}", ADD_CLASSIFICATIONS_LINK)).Click();
        }
      
        
        public static void ClickOnClassifications()
        {
            LogWriter.WriteLog("Executing ClassificationsPage ClickOnClassifications");
            WebDriverUtil.GetWebElement(LIST_MANAGEMENT_DROPDOWN,
                WebDriverUtil.NO_WAIT, String.Format("Unable to locate list management dropdown - {0}", LIST_MANAGEMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(CLASSIFICATIONS_VALUE_IN_LM_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Classifications value - {0}", CLASSIFICATIONS_VALUE_IN_LM_DROPDOWN)).Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing ClassificationsPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button on Classificationss page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseClassificationsForm()
        {
            LogWriter.WriteLog("Executing ClassificationsPage CloseClassificationsForm");
            WaitForClassificationsAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_CLASSIFICATIONS_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing ClassificationsPage ClickOnStandardTab");
            IWebElement standardtab = WebDriverUtil.GetWebElement(STANDARD_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardtab != null)
            {
                standardtab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForClassificationsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing ClassificationsPage WaitForClassificationsAlertCloseIfAny ");
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

