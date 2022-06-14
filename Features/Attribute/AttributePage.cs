using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
 

namespace LaborPro.Automation.Features.Attribute
{
    public class AttributePage
    {
        public static string WorkingDirectory = Environment.CurrentDirectory;
        public static string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
        public static string AttributeImportTemplateCsv = @"\downloads\Attributes-import-template.csv";
        public static string LocationAttributeImportTemplateXlsx = @"\downloads\All-location-attributes-import-template.xlsx";
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
        const string ATTRIBUTE_HEADER = "//span[contains(text(),'{0}')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string EXPORT_ICON = "//*[@class='page-header']//*[@id='export']";
        const string EXPORT_ATTRIBUTE_ICON = "//*[@class='header-button dropdown open btn-group']//*[@aria-labelledby='export']//*[text()='Export Attributes']";
        const string DOWNLOAD_ATTRIBUTE_IMPORT_TEMPLATE_ICON = "//*[@class='header-button dropdown open btn-group']//*[@aria-labelledby='export']//*[text()='Download Attribute Import Template']";
        const string DOWNLOAD_LOCATION_ATTRIBUTE_IMPORT_TEMPLATE_ICON = "//*[@class='header-button dropdown open btn-group']//*[@aria-labelledby='export']//a";
        const string EXPORT_ATTRIBUTE_DAILOGBOX = "//*[@class='modal-content']//*[text()='Export Attributes']";
       


        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnProfilingTab");
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
             
            foreach (IWebElement header in headers)
            {
                 
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
            IWebElement addAttribute = WebDriverUtil.GetWebElement(ADD_ATTRIBUTE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to Locate Add Attribute Button - {0}", ADD_ATTRIBUTE_BUTTON));
            IWebElement newAttribute = WebDriverUtil.GetWebElement(NEW_ATTRIBUTE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate the New Attribute Button - {0}", NEW_ATTRIBUTE_BUTTON));
            if (addAttribute != null || newAttribute != null)
            {
                addAttribute.Click();
                newAttribute.Click();
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
            Boolean found = false;
            foreach (IWebElement header in headers)
            {
                string headerData = header.GetAttribute("innerHTML");
                if (headerData.Contains(attributeName))
                {
                    found = true;
                    WebDriverUtil.GetWebElementAndScroll(String.Format(ATTRIBUTE_HEADER, attributeName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                    BaseClass._AttachScreenshot.Value = true;
                    break;

                }
            }
            if(!found)
                throw new Exception(string.Format("No attribute found - {0} but we expect it should be display!", attributeName));
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
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyAddButtonIsNotPresent");
            IWebElement addAttribute = WebDriverUtil.GetWebElement(ADD_ATTRIBUTE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addAttribute != null)
                throw new Exception("Add Button is present but it is not suppose to be present as current user is logged in from viewonly mode user! ");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyClickOnExportIcon()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyClickOnExportIcon");
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement exportIcon = WebDriverUtil.GetWebElement(EXPORT_ICON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (exportIcon != null)
                {
                    exportIcon.Click();
                    BaseClass._AttachScreenshot.Value = true;

                }
                else
                {
                    throw new Exception("Export button is missing in attribute but we expect it to be present!");
                }

            }
        }
        public static void ClickOnExportIcon()
        {
            LogWriter.WriteLog("AttributePage.ClickOnExportIcon");
            if(WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement exportIcon = WebDriverUtil.GetWebElement(EXPORT_ICON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if(exportIcon != null)
                exportIcon.Click();
                else
                    throw new Exception("Export button is missing in attribute but we expect it to be present!");      
            }
            
        }
        public static void ClickOnExportAttributeIcon()
        {
            LogWriter.WriteLog("AttributePage.ClickOnExportAttributeIcon");
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement exportAttributeIcon = WebDriverUtil.GetWebElement(EXPORT_ATTRIBUTE_ICON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (exportAttributeIcon != null)
                    exportAttributeIcon.Click();
                else
                    throw new Exception("Export Attributte Icon is not found!");
            }
        }
        public static void VerifyEditButtonIsNotPresent()
        {
            LogWriter.WriteLog("AttributePage.VerifyEditButton");
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT,
               WebDriverUtil.NO_WAIT, String.Format("Unable to locate the check attribute of respective department- {0}", CHECK_ATTRIBUTE_OF_RESPECTIVE_DEPARTMENT)).Click();
                IWebElement editButton = WebDriverUtil.GetWebElement(EDIT_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (editButton != null)
                    throw new Exception("Edit Button is found! but we are not suppose to get it as logged in from view only user access");
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static void ClickOnDownloadAttributeImportTemplate()
        {
            LogWriter.WriteLog("AttributePage.ClickOnDownloadAttributeImporttemplate");
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement downloadAttributeImportTemplate = WebDriverUtil.GetWebElement(DOWNLOAD_ATTRIBUTE_IMPORT_TEMPLATE_ICON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (downloadAttributeImportTemplate != null) 
                {
                    downloadAttributeImportTemplate.Click();
                    WebDriverUtil.WaitForAWhile();
                    if (File.Exists(AttributeImportTemplateCsv))
                        WebDriverUtil.WaitFor(WebDriverUtil.SIXTY_SECOND_WAIT);
                }
                else
                    throw new Exception("Download Attribute Import Template Icon is not found!");
            }
        }
        public static bool VerifyFileDownloadInAttribute(string fileName)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyFileDownloadInAttribute");
            bool exist = false;
            String[] filepaths = Directory.GetFiles(SeleniumDriver.DownloadDirectory);
            foreach (string p in filepaths)
            {
                if (p.Contains(fileName))
                {
                    FileInfo thisFile = new FileInfo(p);
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    exist = true;
                    break;
                }
            }

            return exist;

        }
        public static void VerifyExportAttributeDailogBox()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyExportAttributeDailogBox");
            IWebElement exportAttributeDialogBox = WebDriverUtil.GetWebElement(EXPORT_ATTRIBUTE_DAILOGBOX, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportAttributeDialogBox == null)
                throw new Exception("Export Attribute Dialog Box is not found!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClickOnDownloadLocationAttributeImportTemplate()
        {
            LogWriter.WriteLog("AttributePage.ClickOnDownloadLocationAttributeImporttemplate");
            if (WebDriverUtil.GetWebElement(ATTRIBUTE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement downloadLocationAttributeImportTemplate = WebDriverUtil.GetWebElement(DOWNLOAD_LOCATION_ATTRIBUTE_IMPORT_TEMPLATE_ICON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (downloadLocationAttributeImportTemplate != null)
                {
                    downloadLocationAttributeImportTemplate.Click();
                    WebDriverUtil.WaitForAWhile();
                    if (File.Exists(LocationAttributeImportTemplateXlsx))
                        WebDriverUtil.WaitFor(WebDriverUtil.SIXTY_SECOND_WAIT);
                }
                else
                    throw new Exception("Download Location Attribute Import Template Icon is not found!");
            }
        }



    }
}
