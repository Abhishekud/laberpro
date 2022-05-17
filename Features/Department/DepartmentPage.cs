using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.Department
{
    public class DepartmentsPage
    {
        const string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        const string LIST_MANAGEMENT_TAB = "//a[text()='List Management']";
        const string ADD_BUTTON = "//button[@id='newDepartments']";
        const string ADD_DEPARTMENT_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@role='dialog']//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_DEPARTMENT_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string UNITSOFMEASURE_PAGE = "//h3[@class='page-title' and contains(text(),'Units Of Measure')]";
        const string CLOSE_DEPARTMENT_DETAILS = "//button[text()='Close']";
        const string DEPARTMENT_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string DEPARTMENT_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string DEPARTMENT_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string DEPARTMENT_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string LIST_MANAGEMENT_DROPDOWN = "//select[@id='standardFilingFieldId']";
        const string DEPARTMENT_VALUE_IN_LM_DROPDOWN = "//select[@id='standardFilingFieldId']//option[@value='DEPARTMENTS']";
        const string DEPARTMENTS_PAGE = "//h3[contains(text(),'Departments')]";
        const string DEPARTMENTS_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Department')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";

        public static void AddNewDepartmentWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing DepartmentPage.AddNewLocationWithGivenInputIfNotExist");
            WaitForDepartmentAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(DEPARTMENT_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewDepartmentWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void DeleteDepartmentIfExist(string DepartmentName)
        {

            LogWriter.WriteLog("Executing DepartmentPage.DeleteDepartmentifExist");
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(DEPARTMENT_RECORD, DepartmentName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedDepartment(DepartmentName);
            }


        }
        public static void CloseDepartmentDetailSideBar()
        {
            LogWriter.WriteLog("Executing DepartmentPage.CloseDepartmentDetailSideBar");
            IWebElement DepartmentDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_DEPARTMENT_DETAILS, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (DepartmentDetailsSideBar != null)
            {
                DepartmentDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }

        }
        public static void DeleteCreatedDepartment(string DepartmentName)
        {
            LogWriter.WriteLog("Executing DepartmentPage.DeleteCreatedDepartment");
            CloseDepartmentDetailSideBar();
            WebDriverUtil.GetWebElement(String.Format(DEPARTMENT_RECORD, DepartmentName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate Department record on Departments page - {0}", String.Format(DEPARTMENT_RECORD, DepartmentName))).Click();
            WebDriverUtil.GetWebElement(String.Format(DEPARTMENT_DELETE_BUTTON, DepartmentName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate Department delete button on Department details - {0}", String.Format(DEPARTMENT_DELETE_BUTTON, DepartmentName))).Click();

            WebDriverUtil.GetWebElement(DEPARTMENT_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", DEPARTMENT_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(DEPARTMENT_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete department Error - {0}", alert.Text));
            }
        }
        public static void VerifyCreatedDepartment(string DepartmentName)
        {
            LogWriter.WriteLog("Executing DepartmentPage.VerifyCreatedDepartment");
            WebDriverUtil.GetWebElement(String.Format(DEPARTMENT_RECORD, DepartmentName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate record Departments page - {0}", String.Format(DEPARTMENT_RECORD, DepartmentName)));
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void AddNewDepartmentWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing DepartmentPage.AddNewDepartmentWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewDepartmentMenuLink();


            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input Departments page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button Departments page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(DEPARTMENTS_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(DEPARTMENTS_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Department Error - {0}", alert.Text));
                        }
                    }
                }
            }           
        }
        public static void UserClickOnNewDepartmentMenuLink()
        {
            LogWriter.WriteLog("Executing DepartmentPage.UserClickOnNewDepartmentMenuLink");
            WebDriverUtil.GetWebElement(ADD_DEPARTMENT_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewDepartmentMenu menu link on add menu popup - {0}", ADD_DEPARTMENT_LINK)).Click();

        }
        public static void ClickOnDepartment()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnDepartment");

            WebDriverUtil.GetWebElement(LIST_MANAGEMENT_DROPDOWN,
                WebDriverUtil.NO_WAIT, String.Format("Unable to locate list management dropdown - {0}", LIST_MANAGEMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(DEPARTMENT_VALUE_IN_LM_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Department value - {0}", DEPARTMENT_VALUE_IN_LM_DROPDOWN)).Click();


        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button Departments page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseDepartmentForm()
        {
            LogWriter.WriteLog("Executing DepartmentPage.CloseDepartmentForm");
            WaitForDepartmentAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_DEPARTMENT_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnListManagementTab");


            if (WebDriverUtil.GetWebElement(DEPARTMENTS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null || WebDriverUtil.GetWebElement(UNITSOFMEASURE_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(LIST_MANAGEMENT_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnStandardTab");
            IWebElement standardTab = WebDriverUtil.GetWebElement(STANDARD_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab != null)
            {
                standardTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForDepartmentAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing DepartmentPage.WaitForDepartmentAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
               
            }
            WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

