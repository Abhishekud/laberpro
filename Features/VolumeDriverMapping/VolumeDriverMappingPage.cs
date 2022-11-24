using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.VolumeDriverMapping
{
    public class VolumeDriverMappingPage
    {
        private const string ProfilingCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        private const string VolumeDriverMappingTab = "//a[text()='Volume Driver Mapping']";
        private const string VolumeDriverMappingPages = "//*[@class='page-title' and text()='Volume Driver Mappings']";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string AddVolumeDriverMappingSetLink = "(//*[contains(@class,'dropdown open')]//a)[2]";
        private const string AddVolumeDriverMappingLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string VolumeDriverRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string VolumeDriverInput = "//input[@type='number']";
        private const string CheckVolumeDriverMappingOfRespectiveDepartment = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        private const string EditButton = "//*[@title='{0}']/../button";
        private const string DeleteButton = "//i[contains(@title,'Delete')]";
        private const string VolumeConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string VolumeSetConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'New Volume Driver Mapping Set')]";
        private const string ConfirmPopupButton = "//button[contains(@type,'button') and contains(text(),'Confirm')]";
        private const string DepartmentValue = "//option[contains(text(),'{0}')]";
        private const string VolumeDriverDropdown = "//*[@id='volumeDriverId']";
        private const string UomDropdown = "//*[@id='unitOfMeasureId']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseVolumeDriverMappingFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string CloseVolumeDriverMappingDetails = "//button[text()='Close']";
        private const string CancelVolumeDriverMappingDetails = "//button[text()='Cancel']";
        private const string VolumeDriverMappingRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string CreatedVolumeDriverMappingSet = "//div[contains(@class,'volume-driver-mapping-set-list-entry')]//span[contains(text(),'{0}')]";
        private const string VolumeDriverMappingDeleteButton = "//button[contains(@class,'delete')]";
        private const string VolumeDriverMappingDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string VolumeDriverMappingDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string VolumeDriverPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Volume Driver')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string TableHeader = "//th";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ExportButton = "//button[@id='export']";
        private const string ExportVolumeDriverMapping = " //*[@class='dropdown-menu dropdown-menu-right']//*//a[text()='Download Volume Driver Mapping Import Template']";
        private const string VolumeDriverDropDown = "//*[@id='volumeDriverId']";
        private const string DepartmentDropdownValue = "//select[contains(@id,'departmentId')]//option[contains(text(),'{0}')]";
        private const string DepartmentDropdown = "//select[contains(@id,'departmentId')]";
        private const string SaveInprogress = "//button[contains(text(),'Saving...')]";
        private const string DeleteInprogress = "//button[contains(text(),'Deleting...')]";
        private const string EditVolumeDriverMappingSidebar = "//*[@class='sidebar-title ' and contains(text(),'Edit Volume Driver Mapping')]";
        private const string OpenEditSidebarForm = "//*[@class='sidebar-scrollable']//div[@class='action-buttons-none sidebar-section']";
        private const string EditVolumeDriverMappingSetButton = "//button[contains(text(),'Edit')]";
        private const string CancelVolumeDriverDetails = "//button[text()='Cancel']";

        public static void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyExportOptionIsAvailable");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportVolumeDriverMapping, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
            {
                throw new Exception("Export button is not found but we expect it should be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyAddButtonIsNotAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
            {
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDetailsAreNotEditable()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyDetailsAreNotEditable");
            var editTextBox = WebDriverUtil.GetWebElement(VolumeDriverDropDown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
            {
                throw new Exception("Edit text box is enabled but we expect it should be disabled when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotAvailable(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyDeleteButtonIsNotAvailable");
            var volumeDriverMappingRecordXpath = string.Format(VolumeDriverMappingRecord, volumeDriverMappingName);
            WebDriverUtil.GetWebElement(volumeDriverMappingRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate VolumeDriverMapping record on VolumeDriverMapping page - {volumeDriverMappingRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(VolumeDriverMappingDeleteButton,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
            {
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.SelectTheDepartment");
            var departmentValue = string.Format(DepartmentDropdownValue, departmentName);
            WebDriverUtil.GetWebElement(DepartmentDropdown, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate the department dropdown - {DepartmentDropdown}").Click();
            WebDriverUtil.GetWebElement(departmentValue,
            WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate department record on department dropdown - {departmentValue}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void CloseVolumeDriverMappingDetailSideBar()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.CloseVolumeDriverMappingDetailSideBar");
            var volumeDriverMappingDetailsSideBar = WebDriverUtil.GetWebElement(CloseVolumeDriverMappingDetails,
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverMappingDetailsSideBar != null)
            {
                volumeDriverMappingDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
            volumeDriverMappingDetailsSideBar = WebDriverUtil.GetWebElement(CancelVolumeDriverMappingDetails, WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (volumeDriverMappingDetailsSideBar == null)
            {
                return;
            }
            volumeDriverMappingDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
        }
        public static void DeleteVolumeDriverMappingSetIfExist(string volumeDriverMappingSetName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.DeleteVolumeDriverMappingSetIfExist");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TableHeader));
            if (headers.Select(header => header.GetAttribute("innerHTML")).Any(headerData => headerData.Contains(volumeDriverMappingSetName)))
            {
                DeleteCreatedVolumeDriverMappingSet(volumeDriverMappingSetName);
            }
        }
        public static void DeleteVolumeDriverMappingIfExist(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.DeleteVolumeDriverMappingIfExist");
            WaitForVolumeDriverMappingAlertCloseIfAny();
            var volumeDriverMappingXpath = string.Format(VolumeDriverMappingRecord, volumeDriverMappingName);
            var record = WebDriverUtil.GetWebElementAndScroll(volumeDriverMappingXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedVolumeDriverMapping(volumeDriverMappingName);
            }
        }
        public static void DeleteCreatedUom(string uomName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.DeleteCreatedUom");
            var uomRecordXpath = string.Format(VolumeDriverRecord, uomName);
            WebDriverUtil.GetWebElement(uomRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate uom record on uom page - {uomRecordXpath}").Click();

            WebDriverUtil.GetWebElement(VolumeDriverMappingDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate uom delete button on uom details page - {VolumeDriverMappingDeleteButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);

            WebDriverUtil.GetWebElement(VolumeDriverMappingDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate confirm button on delete confirmation popup - {VolumeDriverMappingDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverMappingDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete UOM Error - {formAlert.Text}");
            }

        }
        public static void DeleteCreatedVolumeDriverMapping(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.DeleteCreatedVolumeDriverMapping");
            var volumeDriverMappingRecord = string.Format(VolumeDriverRecord, volumeDriverName);
            WebDriverUtil.GetWebElement(volumeDriverMappingRecord, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate VolumeDriverMapping record on VolumeDriverMapping page - {volumeDriverMappingRecord}").Click();

            WebDriverUtil.GetWebElement(VolumeDriverMappingDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate VolumeDriverMapping delete button on VolumeDriverMapping details page - {VolumeDriverMappingDeleteButton}").Click();

            WebDriverUtil.GetWebElement(VolumeDriverMappingDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate confirm button on delete confirmation popup - {VolumeDriverMappingDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverMappingDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete VolumeDriverMapping Error - {formAlert.Text}");
            }

        }
        public static void VerifyCreatedVolumeDriverMapping(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyCreatedVolumeDriverMapping");
            var volumeDriverMappingRecord = string.Format(VolumeDriverRecord, volumeDriverName);
            WebDriverUtil.GetWebElement(volumeDriverMappingRecord, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record on VolumeDriverMapping page - {volumeDriverMappingRecord}");
            BaseClass._AttachScreenshot.Value = true;
            CloseVolumeDriverMappingDetailSideBar();
        }
        public static void DeleteCreatedVolumeDriverMappingSet(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.DeleteCreatedVolumeDriverMappingSet");
            WebDriverUtil.GetWebElement(CheckVolumeDriverMappingOfRespectiveDepartment,
            WebDriverUtil.NO_WAIT,
            $"Unable to locate the check VolumeDriverMapping set button of respective department - {CheckVolumeDriverMappingOfRespectiveDepartment}").Click();
            var editButtonXpath = string.Format(EditButton, volumeDriverMappingName);
            WebDriverUtil.GetWebElement(editButtonXpath,
            WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate edit button on VolumeDriverMapping set record - {editButtonXpath}").Click();
            WebDriverUtil.GetWebElement(DeleteButton,
            WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate delete button - {DeleteButton}").Click();

            WebDriverUtil.GetWebElement(ConfirmPopupButton, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete VolumeDriverMapping set Error - {formAlert.Text}");
            }

            WebDriverUtil.GetWebElement(CheckVolumeDriverMappingOfRespectiveDepartment,
            WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate the check VolumeDriverMapping set button of respective department - {CheckVolumeDriverMappingOfRespectiveDepartment}").Click();

        }
        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnProfilingTab");
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null)
            {
                return;
            }
            profilingTab.Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void SelectCreatedDepartment(string deptName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.SelectCreatedDepartment");
            WebDriverUtil.GetWebElement(DepartmentDropdown, WebDriverUtil.FIVE_SECOND_WAIT,
                $"Unable to locate the department dropdown - {DepartmentDropdown}").Click();
            var departmentDropdownValue = string.Format(DepartmentValue, deptName);
            WebDriverUtil.GetWebElement(departmentDropdownValue,
            WebDriverUtil.NO_WAIT, $"Unable to locate department dropdown value on VolumeDriverMapping page - {departmentDropdownValue}").Click();

        }
        public static void ClickOnVolumeDriverMappingTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab");
            if (WebDriverUtil.GetWebElement(VolumeDriverMappingPages, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                return;
            }
            WebDriverUtil.GetWebElement(VolumeDriverMappingTab, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void WaitForVolumeDriverMappingAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.WaitForVolumeDriverMappingAlertCloseIfAny");
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                return;
            }
            var nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);
            if (nameTag != null)
            {
                nameTag.Click();
            }
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void CloseVolumeDriverMappingForm()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.CloseVolumeDriverMappingForm");
            WaitForVolumeDriverMappingAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseVolumeDriverMappingFormButton, WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formCloseButton == null)
            {
                return;
            }
            formCloseButton.Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnAddButton");
            CloseVolumeDriverMappingDetailSideBar();
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on VolumeDriverMapping page - {AddButton}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnNewVolumeDriverMappingSetMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnNewVolumeDriverMappingSetMenuLink");
            WebDriverUtil.GetWebElement(AddVolumeDriverMappingSetLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new VolumeDriverMapping set menu link on add menu popup - {AddVolumeDriverMappingSetLink}").Click();

        }
        public static void ClickOnNewVolumeDriverMappingMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnNewVolumeDriverMappingMenuLink");
            WebDriverUtil.GetWebElement(AddVolumeDriverMappingLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new VolumeDriverMapping menu link on add menu popup - {AddVolumeDriverMappingLink}").Click();

        }
        public static void AddNewVolumeDriverMappingWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            var volumeDriverRecord = string.Format(VolumeDriverRecord, dictionary["VolumeDriver"]);
            var record = WebDriverUtil.GetWebElementAndScroll(volumeDriverRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewVolumeDriverMappingWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }

        }
        public static void ClickOnVolumeDriverMapping()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnVolumeDriverMapping");
            ClickOnAddButton();
            ClickOnNewVolumeDriverMappingMenuLink();

        }
        public static void ClickOnVolumeDriverSet()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnVolumeDriverSet");
            ClickOnAddButton();
            ClickOnNewVolumeDriverMappingSetMenuLink();

        }
        public static void AddNewVolumeDriverMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput");
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            //Enter VolumeDriverMapping name if provided
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on create VolumeDriverMapping page - {NameInput}")
                  .SendKeys(dictionary["Name"]);
            }

            if (Util.ReadKey(dictionary, "VolumeDriverMappingSet") != null)
            {
                WebDriverUtil.GetWebElement(VolumeDriverInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate VolumeDriverMapping set input on create VolumeDriverMapping page - {VolumeDriverInput}")
                  .SendKeys(dictionary["VolumeDriverMappingSet"]);
            }

            if (Util.ReadKey(dictionary, "VolumeDriver") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.NO_WAIT,
                    $"Unable to locate VolumeDriver input on create VolumeDriverMapping page - {VolumeDriverDropdown}"))
                  .SelectByText(dictionary["VolumeDriver"]);
            }
            if (Util.ReadKey(dictionary, "UOM") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(UomDropdown, WebDriverUtil.NO_WAIT,
                    $"Unable to locate UOM input on create VolumeDriverMapping page - {UomDropdown}"))
                  .SelectByText(dictionary["UOM"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create VolumeDriverMapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new VolumeDriverMapping Error - {formAlert.Text}");
            }
        }
        public static void VerifyCreatedVolumeDriverMappingSet(string volumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyCreatedVolumeDriverMappingSet");
            if (WebDriverUtil.GetWebElement(VolumeSetConfirmPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeSetConfirmPopup, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }

            WebDriverUtil.GetWebElement(CheckVolumeDriverMappingOfRespectiveDepartment,
            WebDriverUtil.NO_WAIT,
            $"Unable to locate the check VolumeDriverMapping set button of respective department - {CheckVolumeDriverMappingOfRespectiveDepartment}").Click();
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            var volumeDriverMappingSetData = string.Format(CreatedVolumeDriverMappingSet, volumeDriverMappingName);
            WebDriverUtil.GetWebElement(volumeDriverMappingSetData, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate VolumeDriverMappingSet record on VolumeDriverMappingSet page - {volumeDriverMappingSetData}");

            WebDriverUtil.GetWebElement(CheckVolumeDriverMappingOfRespectiveDepartment,
            WebDriverUtil.NO_WAIT,
            $"Unable to locate the check VolumeDriverMapping set button of respective department - {CheckVolumeDriverMappingOfRespectiveDepartment}").Click();

        }
        public static void AddNewVolumeDriverMappingSet(string volumeDriverMappingSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.AddNewVolumeDriverMappingSet");
            if (volumeDriverMappingSet != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on create VolumeDriverMapping page - {NameInput}")
                  .SendKeys(Util.ProcessInputData(volumeDriverMappingSet));
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create VolumeDriverMapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new volume driver mapping set Error - {formAlert.Text}");
            }
        }
        public static void AddNewVolumeDriverMappingWithGivenInput(string volumeDriver, string uom)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput");
            ClickOnVolumeDriverMapping();
            WebDriverUtil.WaitForAWhile();
            if (volumeDriver != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.NO_WAIT,
                        $"Unable to locate volume driver input on create volume driver mapping page - {VolumeDriverDropdown}"))
                    .SelectByText(volumeDriver);
            }

            if (uom != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(UomDropdown, WebDriverUtil.NO_WAIT,
                        $"Unable to locate uom input on create volume driver mapping page - {UomDropdown}"))
                    .SelectByText(uom);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create volume driver mapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new volume driver mapping Error - {formAlert.Text}");
            }
        }

        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
            {
                throw new Exception("Add button is found but we expect it should not be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyEditVolumeDriverMappingSidebarIsAvailable(string volumeDriverMapping)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyEditVolumeDriverMappingSidebarIsAvailable");
            var volumeDriverRecord = string.Format(VolumeDriverRecord, volumeDriverMapping);
            WebDriverUtil.GetWebElement(volumeDriverRecord, WebDriverUtil.NO_WAIT,
                $"Unable to locate volume driver mapping record on volume driver mapping page - {volumeDriverRecord}").Click();
            WebDriverUtil.WaitForAWhile();
            var editVolumeDriverMappingSidebar = WebDriverUtil.GetWebElement(EditVolumeDriverMappingSidebar,
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editVolumeDriverMappingSidebar == null)
            {
                throw new Exception("Edit volume driver mapping sidebar is not found but we expect it should be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifySaveButtonIsNotAvailable(string volumeDriverMapping)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifySaveButtonIsNotAvailable");
            var volumeDriverRecord = string.Format(VolumeDriverRecord, volumeDriverMapping);
            var editVolumeDriverMappingSidebar = WebDriverUtil.GetWebElement(EditVolumeDriverMappingSidebar,
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editVolumeDriverMappingSidebar == null)
            {
                WebDriverUtil.GetWebElement(volumeDriverRecord, WebDriverUtil.NO_WAIT,
                        $"Unable to locate volume driver mapping record on volume driver mapping page - {volumeDriverRecord}").Click();
                WebDriverUtil.WaitForAWhile();
            }
            var saveButton = WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (saveButton != null)
            {
                throw new Exception("Save button is found but we expect it should not be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonAndEditOptionIsNotAvailable(string volumeDriverMapping)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyDeleteButtonAndEditOptionIsNotAvailable");
            var volumeDriverRecord = string.Format(VolumeDriverRecord, volumeDriverMapping);
            var editVolumeDriverMappingSidebar = WebDriverUtil.GetWebElement(EditVolumeDriverMappingSidebar,
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editVolumeDriverMappingSidebar == null)
            {
                WebDriverUtil.GetWebElement(volumeDriverRecord, WebDriverUtil.NO_WAIT,
                        $"Unable to locate volume driver mapping record on volume driver mapping page - {volumeDriverRecord}").Click();
            }
            var deleteButton = WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
            {
                throw new Exception("Delete button is found but we expect it should not be present when user login from admin only access");
            }
            var volumeDriverDropDown = WebDriverUtil.GetWebElement(VolumeDriverDropDown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverDropDown.Enabled)
            {
                throw new Exception("Volume driver dropdown is enabled but we expect it should be disabled when user login from admin only access");
            }
            var uomDropdown = WebDriverUtil.GetWebElement(UomDropdown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (uomDropdown.Enabled)
            {
                throw new Exception("Uom dropdown is enabled but we expect it should be disabled when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyVolumeDriverMappingListingIsAvailable()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyVolumeDriverMappingListingIsAvailable");
            if (WebDriverUtil.GetWebElement(CancelVolumeDriverDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CancelVolumeDriverDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForAWhile();
            }
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CheckVolumeDriverMappingOfRespectiveDepartment, WebDriverUtil.NO_WAIT,
                    $"Unable to locate the check volume driver mapping listing button - {CheckVolumeDriverMappingOfRespectiveDepartment}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyVolumeDriverMappingListingEditOptionIsNotAvailable()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyVolumeDriverMappingListingEditOptionIsNotAvailable");
            if (WebDriverUtil.GetWebElement(CancelVolumeDriverDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CancelVolumeDriverDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForAWhile();
            }
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CheckVolumeDriverMappingOfRespectiveDepartment, WebDriverUtil.NO_WAIT,
                    $"Unable to locate the check volume driver mapping listing button - {CheckVolumeDriverMappingOfRespectiveDepartment}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            var editVolumeDriverMappingSetButton = WebDriverUtil.GetWebElement(EditVolumeDriverMappingSetButton,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editVolumeDriverMappingSetButton != null)
            {
                throw new Exception("Edit button is present but it is not suppose to be present as current user is logged in from admin only user");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClickOnSaveButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnSaveButton");
            var saveButton = WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate save button - {SaveButton}");
            if (saveButton == null)
            {
                return;
            }
            saveButton.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new volume driver mapping set Error - {formAlert.Text}");
            }

        }
        public static void VerifyDepartmentIsAvailable(string departmentName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyDepartmentIsAvailable");
            var departmentValue = string.Format(DepartmentDropdownValue, departmentName);
            WebDriverUtil.GetWebElement(DepartmentDropdown, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate the department dropdown - {DepartmentDropdown}").Click();
            WebDriverUtil.GetWebElement(departmentValue,
            WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate department record on department dropdown - {departmentValue}").Click();
            WebDriverUtil.WaitForAWhile();
            BaseClass._AttachScreenshot.Value = true;
        }
    }
}
