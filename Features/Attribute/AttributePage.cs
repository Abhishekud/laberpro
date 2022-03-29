using laborpro.hooks;
using laborpro.util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborpro.Features.Attribute
{
    public class AttributePage
    {
        const string PROFILING_COLLAPSED_TAB = "//span[contains(text(),'Profiling')]";
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
        const string CREATED_ATTRIBUTE = "//div[contains(@class,'attribute-list-entry')]//span[contains(text(),'{0}')]";
        const string CHECK_ATTRIBUTE_FORM = "//h4[contains(text(),'Attributes']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//span[@class='validation-error help-block' and contains(text(),'{0}')]";
        const string EDIT_BUTTON = "//*[@class='attribute-list-entry']//*[@title='{0}']/../button";
        const string DELETE_BUTTON = "//*[@class='attribute-list-entry-editor']//button[contains(@class,'delete')]";
        const string ATTRIBUTE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CONFIRM_POPUP_BUTTON = "//button[contains(@type,'button') and contains(text(),'Confirm')]";
        const string CHECK_ATTRIBUTE_CREATED_FORM = "//div[contains(@class,'sidebar-header')]";
        const string DEPARTMENT_DROPDOWN_VALUE = "//select[contains(@id,'departmentId')]//option[contains(text(),'{0}')]";
        const string NEW_ATTRIBUTE_FORM = "//h4[contains(text(),'New Attribute in {0}')]";
        const string ATTRIBUTE_MODAL = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Attribute')]";
        const string FORM_INPUT_FIELD_VALIDATION = "//*[contains(@class,'validation-error')]";

        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickonProfilingtab");
            IWebElement profilingTab = WebDriverUtil.GetWebElement(PROFILING_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if(profilingTab != null)
            {
                profilingTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }

        }

        public static void ClickOnAttributeTab()
        {

            LogWriter.WriteLog("Executing AttributePage.ClickOnAttributeTab");
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE )== null) 
            {
                WebDriverUtil.GetWebElement(ATTRIBUTE_TAB, WebDriverUtil.DEFAULT_WAIT, String.Format("Unable to locate Attribute tab - {0}", ATTRIBUTE_TAB)).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }

        public static void clickOnAddAttribute() 
        {
            LogWriter.WriteLog("Executing AttributePage.clickOnAddAttribute");
            IWebElement AddAttribute = WebDriverUtil.GetWebElement(ADD_ATTRIBUTE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to Locate Add Attribute Button - {0}", ADD_ATTRIBUTE_BUTTON));
            IWebElement NewAttribute = WebDriverUtil.GetWebElement(NEW_ATTRIBUTE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate the New Attribute Button - {0}", NEW_ATTRIBUTE_BUTTON));
            if(AddAttribute != null || NewAttribute != null) 
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
            if(formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void AddAttributeWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing AttributePage.AddAttributeWithGivenInput");
            clickOnAddAttribute();
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

            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_MODAL, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ATTRIBUTE_MODAL, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
            
        }

        public static void VerifyCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyCreatedAttribute");
           
                WebDriverUtil.GetWebElement(CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT,
               WebDriverUtil.NO_WAIT,
               String.Format
               ("Unable to locate the check attribute of respective department- {0}",
               CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT)).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

                IWebElement attributeData = WebDriverUtil.GetWebElement(String.Format(CREATED_ATTRIBUTE, attributeName),
                  WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate attribute record on attribute page - {0}"
                     , String.Format(CREATED_ATTRIBUTE, attributeName)));


                BaseClass._AttachScreenshot.Value = true;

            WebDriverUtil.GetWebElement(CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT,
               WebDriverUtil.NO_WAIT,
               String.Format
               ("Unable to locate the check attribute of respective department- {0}",
               CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT)).Click();








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
                WebDriverUtil.NO_WAIT,
                String.Format
                ("Unable to locate the check attribute of respective department- {0}",
                CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT)).Click();


            WebDriverUtil.GetWebElement(String.Format(EDIT_BUTTON, attributeName),
                WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate attribute record on attribute page - {0}"
            , String.Format(EDIT_BUTTON, attributeName))).Click();

          WebDriverUtil.GetWebElement(DELETE_BUTTON,
                WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}",DELETE_BUTTON)).Click();
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_CONFIRM_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CONFIRM_POPUP_BUTTON,WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForWebElementInvisible(ATTRIBUTE_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
                

            }


           

            WebDriverUtil.GetWebElement(CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT,
               WebDriverUtil.ONE_SECOND_WAIT,
               String.Format
               ("Unable to locate the check attribute of respective department- {0}",
               CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT)).Click();
            



        }
        
        public static void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing AttributePage.SelectTheDepartment");
            WebDriverUtil.GetWebElement(DEPARTMENT_DROPDOWN, WebDriverUtil.FIVE_SECOND_WAIT , String.Format("Unable to locate the department dropdown - {0}", DEPARTMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(String.Format(DEPARTMENT_DROPDOWN_VALUE, departmentName),
           WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate attribute record on attribute page - {0}"
            , String.Format(DEPARTMENT_DROPDOWN_VALUE, departmentName))).Click();
            WebDriverUtil.WaitForAWhile();

        }


        public static void VerifyTheDepartment(string departmentName)
        {
               LogWriter.WriteLog("Executing AttributePage.verifyTheDepartment");
               clickOnAddAttribute();
           
            IWebElement attributeTitle= WebDriverUtil.GetWebElement(String.Format(NEW_ATTRIBUTE_FORM, departmentName),
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
