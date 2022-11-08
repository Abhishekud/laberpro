using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;


namespace LaborPro.Automation.Features.Attribute
{
    public class AttributePage
    {
        private const string AttributeImportTemplateCsv = @"\downloads\Attributes-import-template.csv";
        private const string LocationAttributeImportTemplateXlsx = @"\downloads\All-location-attributes-import-template.xlsx";
        private const string ProfilingCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        private const string AttributeTab = "//a[@href='/attributes']";
        private const string AttributePageTitle = "//*[@class='page-title' and text()='Attributes']";
        private const string AddAttributeButton = "//button[.//*[@class='fa fa-plus']]";
        private const string NewAttributeButton = "//a[contains(text(),'New Attribute')]";
        private const string NameTagInput = "//input[contains(@id,'name') and contains(@name,'name')]";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CancelButton = "//button[contains(text(),'Cancel')]";
        private const string DepartmentDropdown = "//select[contains(@id,'departmentId')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CheckAttributeOfRespectiveDepartment = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string EditButton = "//*[@class='attribute-list-entry']//*[@title='{0}']/../button";
        private const string DeleteButton = "//*[@class='attribute-list-entry-editor']//button[contains(@class,'delete')]";
        private const string AttributeConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string ConfirmPopupButton = "//button[contains(@type,'button') and contains(text(),'Confirm')]";
        private const string DepartmentDropdownValue = "//select[contains(@id,'departmentId')]//option[contains(text(),'{0}')]";
        private const string NewAttributeForm = "//h4[contains(text(),'New Attribute in {0}')]";
        private const string AttributeModal = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Attribute')]";
        private const string TableHeader = "//th";
        private const string AttributeHeader = "//span[contains(text(),'{0}')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ExportIcon = "//*[@class='page-header']//*[@id='export']";
        private const string ExportAttributeIcon = "//*[@class='header-button dropdown open btn-group']//*[@aria-labelledby='export']//*[text()='Export Attributes']";
        private const string DownloadAttributeImportTemplateIcon = "//*[@class='header-button dropdown open btn-group']//*[@aria-labelledby='export']//*[text()='Download Attribute Import Template']";
        private const string DownloadLocationAttributeImportTemplateIcon = "//*[@class='header-button dropdown open btn-group']//*[@aria-labelledby='export']//a";
        private const string ExportAttributeDialogueBox = "//*[@class='modal-content']//*[text()='Export Attributes']";
        private const string OpenEditSidebarForm = "//*[@class='sidebar-scrollable']//div[@class='action-buttons-none sidebar-section']";
        private const string EditAttributeButton = "//button[contains(text(),'Edit')]";
        private const string TickOption = "//*[@class='k-grid-edit-cell disabled-input ']/input";
        private const string LocationRecord = "//*[@role='row']//*[text()='{0}']";
        private const string NameInput = "//*[@id='name']";
        private const string AddNewDepartment = "//button[@id='newDepartments']";
        private const string AddDepartmentLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string DepartmentsPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Department')]";
        private const string NewLocationFormPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Location')]";
        private const string AddLocationLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string AddLocationButton = "//button[.//*[@class='fa fa-plus']]";
        private const string CancelLocationDetails = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Cancel']";
        private const string CloseLocationDetails = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Close']";
        private const string SaveInprogress = "//button[contains(text(),'Saving...')]";
        private const string DeleteInprogress = "//button[contains(text(),'Deleting...')]";

        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnProfilingTab");
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null) return;
            profilingTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }
        public static void DeleteAttributeIfExist(string attributeName)
        {
            LogWriter.WriteLog("Executing AttributePage.DeleteAttributeIfExist");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TableHeader));

            if (headers.Select(header => header.GetAttribute("innerHTML")).Any(headerData => headerData.Contains(attributeName)))
            {
                DeleteCreatedAttribute(attributeName);
            }
        }
        public static void ClickOnAttributeTab()
        {

            LogWriter.WriteLog("Executing AttributePage.ClickOnAttributeTab");
            if (WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null) return;
            WebDriverUtil.GetWebElement(AttributeTab, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate Attribute tab - {AttributeTab}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnAddAttribute()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnAddAttribute");
            var addAttribute = WebDriverUtil.GetWebElement(AddAttributeButton, WebDriverUtil.NO_WAIT,
                $"Unable to Locate Add Attribute Button - {AddAttributeButton}");
            var newAttribute = WebDriverUtil.GetWebElement(NewAttributeButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate the New Attribute Button - {NewAttributeButton}");
            if (addAttribute == null && newAttribute == null) return;
            addAttribute.Click();
            newAttribute.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void CloseAttributeForm()
        {
            LogWriter.WriteLog("Executing AttributePage.CloseAttributeForm");
            var formCloseButton = WebDriverUtil.GetWebElement(CancelButton, WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formCloseButton == null) return;
            formCloseButton.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void AddAttributeWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing AttributePage.AddAttributeWithGivenInput");
            ClickOnAddAttribute();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameTagInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on create attribute page - {NameTagInput}").SendKeys(dictionary["Name"]);
            }

            WebDriverUtil.GetWebElement(SaveButton,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate Save Button- {SaveButton}").Click();

            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(AttributeModal, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(AttributeModal, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new attribute Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyCreatedAttribute");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TableHeader));
            var found = false;
            var attributeHeaderWithName = string.Format(AttributeHeader, attributeName);
            if (headers.Select(header => header.GetAttribute("innerHTML")).Any(headerData => headerData.Contains(attributeName)))
            {
                found = true;
                WebDriverUtil.GetWebElementAndScroll(attributeHeaderWithName, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                BaseClass._AttachScreenshot.Value = true;
            }
            if (!found)
                throw new Exception($"No attribute found - {attributeName} but we expect it should be display!");
        }
        public static void VerifyAddAttributeErrorMessage(string message)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyAddAttributeErrorMessage");
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null)
            {
                var actualError = errorMessage.Text;
                if (!(actualError.ToLower()).Equals(message.ToLower()))
                    throw new Exception($"We supposed to get error message - {message} but getting - {actualError}");

            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void DeleteCreatedAttribute(string attributeName)
        {
            LogWriter.WriteLog("Executing AttributePage.DeleteCreatedAttribute");
            var editButtonForAttribute = string.Format(EditButton, attributeName);
            WebDriverUtil.GetWebElement(CheckAttributeOfRespectiveDepartment,
            WebDriverUtil.NO_WAIT, $"Unable to locate the check attribute of respective department- {CheckAttributeOfRespectiveDepartment}").Click();


            WebDriverUtil.GetWebElement(editButtonForAttribute,
                WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate attribute record on attribute page - {editButtonForAttribute}").Click();

            WebDriverUtil.GetWebElement(DeleteButton,
                  WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate delete button - {DeleteButton}").Click();
            WebDriverUtil.GetWebElement(ConfirmPopupButton, WebDriverUtil.TWO_SECOND_WAIT, "Unable to find delete attribute confirmation popup!").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(AttributeConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Attribute Error - {alert.Text}");
            }

            WebDriverUtil.GetWebElement(CheckAttributeOfRespectiveDepartment, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate the check attribute of respective department- {CheckAttributeOfRespectiveDepartment}").Click();
        }
        public static void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing AttributePage.SelectTheDepartment");
            var departmentValue = string.Format(DepartmentDropdownValue, departmentName);
            WebDriverUtil.GetWebElement(DepartmentDropdown, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate the department dropdown - {DepartmentDropdown}").Click();
            WebDriverUtil.GetWebElement(departmentValue,
           WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate attribute record on attribute page - {departmentValue}").Click();
            WebDriverUtil.WaitForAWhile();

        }
        public static void VerifyTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyTheDepartment");
            ClickOnAddAttribute();
            var departmentValue = string.Format(NewAttributeForm, departmentName);
            var attributeTitle = WebDriverUtil.GetWebElement(departmentValue,
                WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate - {departmentValue}");

            if (attributeTitle == null)
            {
                attributeTitle = WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception($"We supposed to get department title for respective form -'New Attribute in {departmentName}' but found - {attributeTitle.Text}");
            }
            BaseClass._AttachScreenshot.Value = true;
            CloseAttributeForm();
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyAddButtonIsNotPresent");
            var addAttribute = WebDriverUtil.GetWebElement(AddAttributeButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addAttribute != null)
                throw new Exception("Add Button is present but it is not suppose to be present as current user is logged in from view only mode user! ");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyClickOnExportIcon()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyClickOnExportIcon");
            if (WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            var exportIcon = WebDriverUtil.GetWebElement(ExportIcon, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
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
        public static void ClickOnExportIcon()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnExportIcon");
            if (WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            var exportIcon = WebDriverUtil.GetWebElement(ExportIcon, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportIcon != null)
                exportIcon.Click();
            else
                throw new Exception("Export button is missing in attribute but we expect it to be present!");

        }
        public static void ClickOnExportAttributeIcon()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnExportAttributeIcon");
            if (WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            var exportAttributeIcon = WebDriverUtil.GetWebElement(ExportAttributeIcon, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportAttributeIcon != null)
                exportAttributeIcon.Click();
            else
                throw new Exception("Export Attribute Icon is not found!");
        }
        public static void VerifyEditButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyEditButton");
            if (WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            WebDriverUtil.GetWebElement(CheckAttributeOfRespectiveDepartment,
                WebDriverUtil.NO_WAIT, $"Unable to locate the check attribute of respective department- {CheckAttributeOfRespectiveDepartment}").Click();
            var editButton = WebDriverUtil.GetWebElement(EditButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editButton != null)
                throw new Exception("Edit Button is found! but we are not suppose to get it as logged in from view only user access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClickOnDownloadAttributeImportTemplate()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnDownloadAttributeImportTemplate");
            if (WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            var downloadAttributeImportTemplate = WebDriverUtil.GetWebElement(DownloadAttributeImportTemplateIcon, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
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
        public static bool VerifyFileDownloadInAttribute(string fileName)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyFileDownloadInAttribute");
            var exist = false;
            var filePaths = Directory.GetFiles(SeleniumDriver.DownloadDirectory);
            foreach (var p in filePaths)
            {
                if (!p.Contains(fileName)) continue;
                var thisFile = new FileInfo(p);
                if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    exist = true;
                break;
            }

            return exist;

        }
        public static void VerifyExportAttributeDialogueBox()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyExportAttributeDialogueBox");
            var exportAttributeDialogBox = WebDriverUtil.GetWebElement(ExportAttributeDialogueBox, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportAttributeDialogBox == null)
                throw new Exception("Export Attribute Dialog Box is not found!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClickOnDownloadLocationAttributeImportTemplate()
        {
            LogWriter.WriteLog("Executing AttributePage.ClickOnDownloadLocationAttributeImportTemplate");
            if (WebDriverUtil.GetWebElement(AttributePageTitle, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            var downloadLocationAttributeImportTemplate = WebDriverUtil.GetWebElement(DownloadLocationAttributeImportTemplateIcon, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
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

        public static void CreateAttribute(string attribute)
        {
            LogWriter.WriteLog("Executing AttributePage.CreateAttribute");
            ClickOnAddAttribute();
            if (attribute != null)
            {
                WebDriverUtil.GetWebElement(NameTagInput, WebDriverUtil.NO_WAIT,
                        $"Unable to locate name input on create attribute page  - {NameTagInput}")
                    .SendKeys(Util.ProcessInputData(attribute));
            }
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT, $"Unable to locate save button - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(AttributeModal, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(AttributeModal, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new attribute Error - {alert.Text}");
            }
        }

        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyAddButtonIsNotAvailable");
            var addAttribute = WebDriverUtil.GetWebElement(AddAttributeButton, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (addAttribute != null)
                throw new Exception("Add button is present but it is not suppose to be present as current user is logged in from admin only user");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyAttributeListingIsAvailable()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyAttributeListingIsAvailable");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CheckAttributeOfRespectiveDepartment, WebDriverUtil.NO_WAIT, $"Unable to locate the check attribute button - {CheckAttributeOfRespectiveDepartment}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyEditButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyEditButtonIsNotAvailable");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CheckAttributeOfRespectiveDepartment, WebDriverUtil.NO_WAIT,
                    $"Unable to locate the check attribute button - {CheckAttributeOfRespectiveDepartment}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            var editAttributeButton = WebDriverUtil.GetWebElement(EditAttributeButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editAttributeButton != null)
                throw new Exception("Edit button is present but it is not suppose to be present as current user is logged in from admin only user");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyCheckboxesAreDisabled()
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyCheckboxesAreDisabled");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CheckAttributeOfRespectiveDepartment, WebDriverUtil.NO_WAIT,
                    $"Unable to locate the check attribute button - {CheckAttributeOfRespectiveDepartment}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            var tickOption = WebDriverUtil.GetWebElement(TickOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (tickOption == null)
                throw new Exception("Tick option is enabled but we expect it should be disabled when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.WaitForAWhile();
        }

        public static void VerifyAddedLocationIsAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing AttributePage.VerifyAddedLocationIsAvailable");
            var locationRecord = string.Format(LocationRecord, locationName);
            WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.DEFAULT_WAIT,
                $"Unable to locate location record on attribute page - {locationRecord}");
            BaseClass._AttachScreenshot.Value = true;
        }

    }

}