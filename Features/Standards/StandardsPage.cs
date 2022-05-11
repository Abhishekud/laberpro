using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Standards
{
    public class StandardsPage
    {
        const string STANDARDS_TAB = "//a[@href='/standards']";
        const string STANDARD_PAGE = "//h3[contains(text(),'Standards')]";
        const string CLOSE_STANDARDS_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string NAMETAG_INPUT = "//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string DEPARTMENT_INPUT = "//select[@id='departmentId']";
        const string ADD_STANDARD_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string NEW_STANDARD = "//a[contains(text(),'New Standard')]";
        const string NAME_TAG_INPUT_IN_EDIT_FORM = "//input[@value='{0}']";
        const string OPEN_EDIT_SIDEBAR_FORM = "//*[@class='sidebar-scrollable']//div[@class='form-group']";
        const string EDIT_BUTTON_SIDEBAR = "//button//strong[contains(text(),'edit')]";
        const string DELETE_BUTTON = "//button//i[contains(@title,'Delete')]";
        const string CONFIRM_POPUP_BUTTON = "//button[contains(text(),'Confirm')]";
        const string NEW_STANDARD_ELEMENT = "//*[@class='add-standard-item standalone']//button[@title='New Standard Element']";
        const string NEW_STANDARD_ELEMENT_POPUP = "//*[@role='dialog']//h4[contains(text(),'{0}')]";
        const string PAGE_TITLE = "//*[@class='page-title']";
        const string STANDARD_ELEMENT_DROPDOWN = "//select[@id='standardElementType']";
        const string STANDARD_ELEMENT_POPUP = "//*[@role='dialog']//h4[contains(text(),'Select Standard Element Type')]";
        const string STANDARAD_BYNAME = "//*[@role='row' and .//*[text()='{0}']]";
        const string STANDARD_DETAILS_SIDEBAR = "//*[@class='sidebar standard-profile']";
        const string STANDARD_ELEMENT_DROPDOWN_BUTTON = "//*[@class='content']//button[@class='dropdown-toggle btn btn-link']";
        const string STANDARD_ELEMENT_DELETE_BUTTON = "//*[@role='presentation']//a[contains(text(),'Delete')]";
        const string STANDARD_SIDEBAR = "//*[@class='page-header']//button[@class='btn-wheat btn btn-default']//i";
        const string STANDARD_ELEMENT_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CONFIRM_BUTTON = "//*[@class='modal-content']//button[text()='Confirm']";
        const string STANDARD_ELEMENT_NAME_TAG = "//*[@class='form-group']//input[@name='name']";
        const string STANDARD_ELEMENT_FREQUENCY_TAG = "//*[@class='form-group']//input[@name='frequencyFormula']";
        const string STANDARD_ELEMENT_UOM_TAG = "//select[@id='unitOfMeasureId']";
        const string CREATED_STANDARD_ELEMENT = "//*[@class='content']//span[contains(text(),'{0}')]";
        const string STANDARD_ELEMENT_CONTENT = "//*[@class='content']";
        const string STANDARD_ELEMENT_OK_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'OK')]";
        const string STANDARD_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string CLEAR_FILTER_BUTTON = "//button[@title='Clear All Filters']";
        const string STANDARD_ELEMENT_FREQUENCY_ALERT = "//*[@class='form-group has-error']";
        const string NEW_STANDARD_ELEMENT_FORM = "//*[@role='dialog']//h4[contains(text(),'New Estimate')]";
        const string STANDARD_ELEMENT_UOM_VALUE_IN_DROPDOWN = "//*[@id='unitOfMeasureId']//option[contains(text(),'{0}')]";
        const string STANDARD_DETAILS_SIDEBAR_BUTTON = "//*[@class='page-header']//button[@class='btn-default btn btn-default']//i";
        const string STANDARD_ELEMENT_TIME_TAG = "//*[@class='form-group']//input[@id='measuredTimeMeasurementUnits']";
        const string STANDARD_FORM = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Standard')]";
        const string ATTRIBUTE_INPUT = "//select[@id='attributeId']";
        const string NAME = "Name";
        const string STANDARAD_TABLE_HEADER = "//table[@role='presentation']//th//*[@class='k-link']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string STANDARD_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";

        public static void ClickOnStandardsTab()
        {
            LogWriter.WriteLog("Executing StandardPage.ClickOnStandardsTab");
            if (WebDriverUtil.GetWebElement(STANDARD_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(STANDARDS_TAB, WebDriverUtil.DEFAULT_WAIT, String.Format("Unable to locate the standard tab - {0}", STANDARDS_TAB)).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void CloseStandardsForm()
        {
            LogWriter.WriteLog("Executing StandardPage.CloseStandardsForm");
            WaitForStandardsAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_STANDARDS_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForStandardsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing StandardPage.WaitForAllowanceAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAMETAG_INPUT);
                if (nametag != null)
                {
                    nametag.Click();
                }
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void ClickOnAddStandards()
        {
            LogWriter.WriteLog("Executing StandardPage.ClickOnAddStandards");
            IWebElement AddStandard = WebDriverUtil.GetWebElement(ADD_STANDARD_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to Locate Add Standard Button - {0}", ADD_STANDARD_BUTTON));
            IWebElement NewStandard = WebDriverUtil.GetWebElement(NEW_STANDARD, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate the New Standard Button - {0}", NEW_STANDARD));
            if (AddStandard != null || NewStandard != null)
            {
                AddStandard.Click();
                NewStandard.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }

        }
        public static void AddStandardsWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing StandardPage.AddStandardWithGivenInput");
            ClickOnAddStandards();
            WaitForStandardsAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAMETAG_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate name input on create standard page - {0}", NAMETAG_INPUT)).SendKeys(dictionary["Name"]);
            }

            if (Util.ReadKey(dictionary, "Department") != null)
            {
               new SelectElement( WebDriverUtil.GetWebElement(DEPARTMENT_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate DEPARTMENT input on create standard page - {0}", DEPARTMENT_INPUT))).SelectByText(dictionary["Department"]);
               
            }

            if(Util.ReadKey(dictionary, "Attribute") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(ATTRIBUTE_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate Attribute input on create standard page - {0}", ATTRIBUTE_INPUT))).SelectByText(dictionary["Attribute"]);
            }



            WebDriverUtil.GetWebElement(SAVE_BUTTON,
                WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Save Button- {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);

            if (WebDriverUtil.GetWebElement(STANDARD_FORM, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ELEMENT_ALERT, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(STANDARD_FORM, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Standard Error - {0}", alert.Text));
                        }
                    }
                }
            }
           
        }
        public static void VerifyCreatedStandard(string standardName)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyCreatedStandard");
            IWebElement standardValueInEditForm = WebDriverUtil.GetWebElement(String.Format(NAME_TAG_INPUT_IN_EDIT_FORM, standardName), WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardValueInEditForm == null)
            {
                standardValueInEditForm = WebDriverUtil.GetWebElement(OPEN_EDIT_SIDEBAR_FORM, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception(String.Format("We supposed to get StandardPage tile - {0} but found - {1}", standardName, standardValueInEditForm.Text));
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteCreatedStandard()
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteCreatedStandard ");
            if (WebDriverUtil.GetWebElement(OPEN_EDIT_SIDEBAR_FORM, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(STANDARD_DETAILS_SIDEBAR_BUTTON, 
                WebDriverUtil.ONE_SECOND_WAIT, 
                String.Format("Unable to locate standard details sidebar button - {0}",
                STANDARD_DETAILS_SIDEBAR_BUTTON)).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            WebDriverUtil.GetWebElement(EDIT_BUTTON_SIDEBAR,WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate edit button - {0}",EDIT_BUTTON_SIDEBAR)).Click();
            WebDriverUtil.GetWebElement(DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate DELETE button - {0}", DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CONFIRM_POPUP_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate confirm button - {0}", CONFIRM_POPUP_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Standard Error - {0}", alert.Text));
            }
            
      


        }
        public static void NewStandardElement()
        {
            LogWriter.WriteLog("Executing StandardPage.NewStandardElement");
            if (WebDriverUtil.GetWebElement(NEW_STANDARD_ELEMENT, WebDriverUtil.ONE_SECOND_WAIT, String.Format("unable to find the new standard element button - {0}", NEW_STANDARD_ELEMENT)) != null)
            {
                WebDriverUtil.GetWebElement(NEW_STANDARD_ELEMENT, WebDriverUtil.ONE_SECOND_WAIT, String.Format("unable to find the new standard element button - {0}", NEW_STANDARD_ELEMENT)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void VerifyNewStandardElementPopup(string value)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyNewStandardElementPopup");
            IWebElement standardelementPopup = WebDriverUtil.GetWebElement(String.Format(NEW_STANDARD_ELEMENT_POPUP, value), WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardelementPopup == null)
            {
                standardelementPopup = WebDriverUtil.GetWebElement(PAGE_TITLE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception(String.Format("We supposed to get standard element title - {0} but found - {1}", value, standardelementPopup.Text));
            }

            
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectElementType(string value)
        {
            LogWriter.WriteLog("Executing StandaradPage.selectElementType");
            if (WebDriverUtil.GetWebElement(STANDARD_ELEMENT_POPUP, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate standard element popup - {0}", STANDARD_ELEMENT_POPUP)) != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(STANDARD_ELEMENT_DROPDOWN, WebDriverUtil.ONE_SECOND_WAIT, 
                    WebDriverUtil.NO_MESSAGE)).SelectByText(value);
                WebDriverUtil.GetWebElement(STANDARD_ELEMENT_OK_BUTTON, WebDriverUtil.NO_WAIT, string.Format("UNABLE TO LOCATE OK BUTTON - {0}", STANDARD_ELEMENT_OK_BUTTON)).Click();
            }

        }
        public static void DeleteStandardIfExist(string StandardName)
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteStandardIfExist");
            ClearAllFilter();
            SearchStandard(StandardName);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(STANDARD_RECORD, StandardName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteStandardByName(StandardName);
            }

        }
        public static void DeleteStandardByName(string StandardName)
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteStandardByName");
            WebDriverUtil.GetWebElement(String.Format(STANDARD_RECORD,StandardName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate Standard  record on StandardPage page - {0}", String.Format(STANDARD_RECORD, StandardName))).Click();

            if (WebDriverUtil.GetWebElement(OPEN_EDIT_SIDEBAR_FORM, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(STANDARD_DETAILS_SIDEBAR_BUTTON,
                WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate standard details sidebar button - {0}",
                STANDARD_DETAILS_SIDEBAR_BUTTON)).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            WebDriverUtil.GetWebElement(EDIT_BUTTON_SIDEBAR, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate edit button - {0}", EDIT_BUTTON_SIDEBAR)).Click();
            WebDriverUtil.GetWebElement(DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate DELETE button - {0}", DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CONFIRM_POPUP_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate confirm button - {0}", CONFIRM_POPUP_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Standard Error - {0}", alert.Text));
            }
        }
        public static void SelectStandarad(string Standard)
        {
            LogWriter.WriteLog("Executing StandardPage.SelectStandarad");
            if(WebDriverUtil.GetWebElement(STANDARD_PAGE, WebDriverUtil.ONE_SECOND_WAIT,WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(STANDARAD_BYNAME, Standard), WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate the Stanadard By name - {0}", String.Format(STANDARAD_BYNAME, Standard))).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
        }
        public static void AddStandardElementWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing StandardPage.AddStandardElementWithGivenInput");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(STANDARD_ELEMENT_NAME_TAG, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate name input - {0}", STANDARD_ELEMENT_NAME_TAG)).SendKeys(dictionary["Name"]);
            }

            if(Util.ReadKey(dictionary, "Frequency") != null)
            {
                WebDriverUtil.GetWebElement(STANDARD_ELEMENT_FREQUENCY_TAG, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate frequency input - {0}", STANDARD_ELEMENT_FREQUENCY_TAG)).SendKeys(dictionary["Frequency"]);
            }

            if (Util.ReadKey(dictionary, "Unit of Measure") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(STANDARD_ELEMENT_UOM_TAG, WebDriverUtil.NO_WAIT,
                     String.Format("Unable to locate UNIT OF MEASURE INPUT - {0}", STANDARD_ELEMENT_UOM_TAG))).SelectByText(dictionary["Unit of Measure"]);

            }

            if (Util.ReadKey(dictionary, "Time (Seconds)") != null)
            {
                WebDriverUtil.GetWebElement(STANDARD_ELEMENT_TIME_TAG, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate time input - {0}", STANDARD_ELEMENT_TIME_TAG)).Clear();
                WebDriverUtil.GetWebElement(STANDARD_ELEMENT_TIME_TAG, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate time input - {0}", STANDARD_ELEMENT_TIME_TAG)).SendKeys(dictionary["Time (Seconds)"]);
            }



            WebDriverUtil.GetWebElement(SAVE_BUTTON,
                WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Save Button- {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            if (WebDriverUtil.GetWebElement(NEW_STANDARD_ELEMENT_FORM, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(NEW_STANDARD_ELEMENT_FORM, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Standard Error - {0}", alert.Text));
                        }
                    }
                }

            }

        }
        public static void VerifyCreatedStandardElement(string StandardElement)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyCreatedStandardElement");
            if (WebDriverUtil.GetWebElement(STANDARD_ELEMENT_CONTENT, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(CREATED_STANDARD_ELEMENT,StandardElement),
                    WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate the Standard element - {0}", String.Format(CREATED_STANDARD_ELEMENT, StandardElement)));

            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteStandardElement()
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteStandardElementByName");
            if(WebDriverUtil.GetWebElement(STANDARD_DETAILS_SIDEBAR, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(STANDARD_SIDEBAR, WebDriverUtil.ONE_SECOND_WAIT, 
                    String.Format("Unable to locate standard sidebar button {0}", STANDARD_SIDEBAR)).Click();
            }
            WebDriverUtil.GetWebElement
                (STANDARD_ELEMENT_DROPDOWN_BUTTON,
                WebDriverUtil.ONE_SECOND_WAIT, 
                String.Format("Unable to locate the standard element dropdown button - {0}", STANDARD_ELEMENT_DROPDOWN_BUTTON)).Click();

            WebDriverUtil.GetWebElement(STANDARD_ELEMENT_DELETE_BUTTON, 
            WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", 
            STANDARD_ELEMENT_DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CONFIRM_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate confirm button - {0}", CONFIRM_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(STANDARD_ELEMENT_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete StandardElement Error - {0}", alert.Text));
            }
            

        }
        public static void SearchStandard(String standardName)
        {
                LogWriter.WriteLog("Executing StandardPage.ClickOnProfilingTab");
                WebDriverUtil.GetWebElement(String.Format(STANDARD_FILTER_INPUT, FindColumnIndexInStandard(NAME)), WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate location filter input on Standard page - {0}", STANDARD_FILTER_INPUT)).SendKeys(standardName);
                WebDriverUtil.WaitForAWhile();
                WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing StandardPage.ClickOnProfilingTab");
            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(CLEAR_FILTER_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
        public static void VerifyFrequencyIsEmpty()
        {
            LogWriter.WriteLog("Executing StandaradPage.VerifyFrequencyIsEmpty");
            if(WebDriverUtil.GetWebElement(NEW_STANDARD_ELEMENT_FORM, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(STANDARD_ELEMENT_FREQUENCY_ALERT, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
               
            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyUomInDropDown(string UOM)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyUOMInDropDown");
            if(WebDriverUtil.GetWebElement(NEW_STANDARD_ELEMENT_FORM, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(STANDARD_ELEMENT_UOM_TAG, 
                 WebDriverUtil.ONE_SECOND_WAIT, 
                 String.Format("unable to locate units of measure in standard element - {0}", 
                 STANDARD_ELEMENT_FREQUENCY_TAG)).Click();

                WebDriverUtil.GetWebElement(String.Format(STANDARD_ELEMENT_UOM_VALUE_IN_DROPDOWN, UOM), 
                    WebDriverUtil.ONE_SECOND_WAIT, 
                    String.Format("Unable to locate UOM value in standard element dropdown - {0}", 
                    String.Format(STANDARD_ELEMENT_UOM_VALUE_IN_DROPDOWN, UOM)));

            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static int FindColumnIndexInStandard(string headername)
        {
            LogWriter.WriteLog("Executing StandardPage.FindColumnIndexInStandard");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(STANDARAD_TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                if (headername.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }
            index++;

            return index;
        }
    }
}
