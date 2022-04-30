using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
 

namespace LaborPro.Automation.Features.Attribute
{
    public class AttributePage
    {
        const string PROFILING_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        const string ATTRIBUTE_TAB = "//a[@href='/attributes']";
        const string ATTRIBUTE_PAGE = "//*[@class='page-title' and text()='Attributes']";
        const string ADD_ATTRIBUTE_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string NEW_ATTRIBUTE_BUTTON = "//a[contains(text(),'New Attribute')]";
        const string NAMETAG_INPUT = "//input[contains(@id,'name') and contains(@name,'name')]";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CANCEL_BUTTON = "//button[contains(text(),'Cancel')]";
        const string DEPARTMENT_DROPDOWN = "//select[contains(@id,'departmentId')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string EDIT_BUTTON = "//*[@class='attribute-list-entry']//*[@title='{0}']/../button";
        const string DELETE_BUTTON = "//*[@class='attribute-list-entry-editor']//button[contains(@class,'delete')]";
        const string ATTRIBUTE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CONFIRM_POPUP_BUTTON = "//button[contains(@type,'button') and contains(text(),'Confirm')]";
        const string DEPARTMENT_DROPDOWN_VALUE = "//select[contains(@id,'departmentId')]//option[contains(text(),'{0}')]";
        const string NEW_ATTRIBUTE_FORM = "//h4[contains(text(),'New Attribute in {0}')]";
        const string ATTRIBUTE_MODAL = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Attribute')]";
        const string TABLE_HEADER = "//th";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string ATTRIBUTE_HEADER = "//span[contains(text(),'{0}')]";

        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickonProfilingtab");
            IWebElement profilingTab = WebDriverUtil.GetWebElement(PROFILING_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab != null)
            {
                profilingTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }

        }
        public static void DeleteAttributeIfExist(string attributeName)
        {
            LogWriter.WriteLog("Executing AttributePage.DeleteattributeifExist");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                string headerData = header.GetAttribute("innerHTML");
                if (headerData.Contains(attributeName))
                {
                    DeleteCreatedAttribute(attributeName);
                    break;
                }
            }
        }
        public static void ClickOnAttributeTab()
        {

            LogWriter.WriteLog("Executing AttributePage.ClickOnAttributeTab");
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ATTRIBUTE_TAB, WebDriverUtil.DEFAULT_WAIT, String.Format("Unable to locate Attribute tab - {0}", ATTRIBUTE_TAB)).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void ClickOnAddAttribute()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnAddAttribute");
            IWebElement AddAttribute = WebDriverUtil.GetWebElement(ADD_ATTRIBUTE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to Locate Add Attribute Button - {0}", ADD_ATTRIBUTE_BUTTON));
            IWebElement NewAttribute = WebDriverUtil.GetWebElement(NEW_ATTRIBUTE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate the New Attribute Button - {0}", NEW_ATTRIBUTE_BUTTON));
            if (AddAttribute != null || NewAttribute != null)
            {
                AddAttribute.Click();
                NewAttribute.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }
        }
        public static void CloseAttributeForm()
        {
            LogWriter.WriteLog("Executing AttributePage.CloseAttributeForm");
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CANCEL_BUTTON, WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void AddAttributeWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing AttributePage.AddAttributeWithGivenInput");
            ClickOnAddAttribute();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAMETAG_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate name input on create attribute page - {0}", NAMETAG_INPUT)).SendKeys(dictionary["Name"]);
            }

            WebDriverUtil.GetWebElement(SAVE_BUTTON,
                WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Save Button- {0}", SAVE_BUTTON)).Click();

            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_MODAL, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(ATTRIBUTE_MODAL, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new attribute Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void VerifyCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyCreatedAttribute");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                string headerData = header.GetAttribute("innerHTML");
                if (headerData.Contains(attributeName))
                {

                    WebDriverUtil.GetWebElementAndScroll(String.Format(ATTRIBUTE_HEADER, attributeName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                    BaseClass._AttachScreenshot.Value = true;
                    break;

                }

            }

        }
        public static void VerifyAddAttributeErrorMessage(string message)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyAddAttributeErrorMessage");
            IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null)
            {
                string actualError = errorMessage.Text;
                if (!(actualError.ToLower()).Equals(message.ToLower()))
                    throw new Exception(String.Format("We supposed to get error message - {0} but getting - {1}", message, actualError));

            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void DeleteCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing AttributPage.DeleteCreatedAttribute");
            WebDriverUtil.GetWebElement(CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT,
            WebDriverUtil.NO_WAIT,String.Format("Unable to locate the check attribute of respective department- {0}",CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT)).Click();


            WebDriverUtil.GetWebElement(String.Format(EDIT_BUTTON, attributeName),
                WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate attribute record on attribute page - {0}", String.Format(EDIT_BUTTON, attributeName))).Click();

            WebDriverUtil.GetWebElement(DELETE_BUTTON,
                  WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();
                WebDriverUtil.GetWebElement(CONFIRM_POPUP_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, "Unable to find delete attribute confirmation popup!").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ATTRIBUTE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Attribute Error - {0}", alert.Text));
            }

            WebDriverUtil.GetWebElement(CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT,WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate the check attribute of respective department- {0}",CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT)).Click();
        }
        public static void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing AttributePage.SelectTheDepartment");
            WebDriverUtil.GetWebElement(DEPARTMENT_DROPDOWN, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate the department dropdown - {0}", DEPARTMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(String.Format(DEPARTMENT_DROPDOWN_VALUE, departmentName),
           WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate attribute record on attribute page - {0}"
            , String.Format(DEPARTMENT_DROPDOWN_VALUE, departmentName))).Click();
            WebDriverUtil.WaitForAWhile();

        }
        public static void VerifyTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing AttributePage.verifyTheDepartment");
            ClickOnAddAttribute();

            IWebElement attributeTitle = WebDriverUtil.GetWebElement(String.Format(NEW_ATTRIBUTE_FORM, departmentName),
                WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate - {0}",
                String.Format(NEW_ATTRIBUTE_FORM, departmentName)));

            if (attributeTitle == null)
            {
                attributeTitle = WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception(String.Format("We supposed to get department title for respective form -'New Attribute in {0}' but found - {1}", departmentName, attributeTitle.Text));
            }
            BaseClass._AttachScreenshot.Value = true;
            CloseAttributeForm();
        }
    }
}
