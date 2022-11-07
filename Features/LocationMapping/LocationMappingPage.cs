using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.LocationMapping
{
    public class LocationMappingPage
    {
        private const string ProfilingCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        private const string ProfilingTab = "//li//span[contains(text(),'Profiling')]";
        private const string LocationMappingRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseLocationMappingDetails = "//button[text()='Close']";
        private const string LocationMappingDeleteButton = "//button[contains(@class,'delete')]";
        private const string CloseLocationMappingFormButton = "//button[contains(text(),'Cancel')]";
        private const string LocationMappingRecordMapping = "//*[@role='row' and .//*[text()='{0}']]//td[{1}]/input";
        private const string LocationMappingDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string LocationMappingDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string LocationMappingTab = "//a[text()='Location Mapping']";
        private const string LocationsMappingPage = "//*[@class='page-title' and text()=' Mapping']";
        private const string VolumeDriverDropdown = "//select[@id='volumeDriverMappingSetId']";
        private const string CharacteristicDropdown = "//select[@id='characteristicSetId']";
        private const string Header = "//th";
        private const string LocationMappingPopup = "//*[contains(text(),'Edit Location Mapping')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string ExportButton = "//button[@title='Download Location Mapping Import Template']";
        private const string DepartmentDropdownValue = "//select[contains(@id,'departmentId')]//option[contains(text(),'{0}')]";
        private const string DepartmentDropdown = "//select[contains(@id,'departmentId')]";
        private const string EditLocationsMappingSidebar = "//*[@class='sidebar-title ' and contains(text(),'Edit Location Mapping')]";
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

        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyExportOptionIsPresent");
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export button is not found but we expect it should be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDetailsAreNotEditable(string locationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyDetailsAreNotEditable");
            var locationMappingRecordXpath = string.Format(LocationMappingRecord, locationMappingName);
            WebDriverUtil.GetWebElement(locationMappingRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate LocationMapping record on LocationMapping page - {locationMappingRecordXpath}").Click();
            var editTextBox = WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("Edit TextBox is enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifySaveButtonIsNotPresent(string locationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifySaveButtonIsNotPresent");
            var locationMappingRecordXpath = string.Format(LocationMappingRecord, locationMappingName);
            WebDriverUtil.GetWebElement(locationMappingRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate LocationMapping record on LocationMapping page - {locationMappingRecordXpath}").Click();
            var saveButton = WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (saveButton != null)
                throw new Exception("Save button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.SelectTheDepartment");
            var departmentValue = string.Format(DepartmentDropdownValue, departmentName);
            WebDriverUtil.GetWebElement(DepartmentDropdown, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate the department dropdown - {DepartmentDropdown}").Click();
            WebDriverUtil.GetWebElement(departmentValue,
           WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate department record on department page - {departmentValue}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void AddNewLocationMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.AddNewLocationMappingWithGivenInput");
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            shared.hooks.BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            //Enter VolumeDriverMapping name if provided
            if (Util.ReadKey(dictionary, "VolumeDriverMappingSet") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.MAX_WAIT,
                $"Unable to locate Volume Driver Mapping record on create Location Mapping page - {VolumeDriverDropdown}"))
                .SelectByText(dictionary["VolumeDriverMappingSet"]);
            }
            if (Util.ReadKey(dictionary, "CharacteristicSet") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(CharacteristicDropdown, WebDriverUtil.MAX_WAIT,
                $"Unable to locate characteristic set input on create Location Mapping page - {CharacteristicDropdown}"))
                .SelectByText(dictionary["CharacteristicSet"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create Location Mapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(LocationMappingPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationMappingPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new Location Mapping page error - {alert.Text}");
            }
        }
        public static void CloseLocationMappingDetailSideBar()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.CloseLocationMappingDetailSideBar");
            var LocationMappingDetailsSideBar = WebDriverUtil.GetWebElement(CloseLocationMappingDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (LocationMappingDetailsSideBar == null) return;
            LocationMappingDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void CloseLocationDriverMappingForm()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.CloseLocationDriverMappingForm");
            var formCloseButton = WebDriverUtil.GetWebElement(CloseLocationMappingFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitForAWhile();
            }
            WebDriverUtil.WaitForAWhile();
        }
        public static void DeleteCreatedLocationMapping(string locationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.DeleteCreatedLocationMapping");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationMappingName);
            var locationMappingDelete = string.Format(LocationMappingDeleteButton, locationMappingName);
            CloseLocationMappingDetailSideBar();
            WebDriverUtil.GetWebElement(locationMappingRecord, WebDriverUtil.NO_WAIT,
            $"Unable to locate Location Mapping record on Location Mapping page - {locationMappingRecord}").Click();

            WebDriverUtil.GetWebElement(locationMappingDelete, WebDriverUtil.NO_WAIT,
            $"Unable to locate Location Mapping delete button on Location Mapping details - {locationMappingDelete}").Click();

            WebDriverUtil.GetWebElement(LocationMappingDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate confirm button on delete confirmation popup - {LocationMappingDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationMappingDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Location Mapping Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedLocationMapping(string locationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyCreatedLocationMapping");
            WebDriverUtil.WaitForAWhile();
            var locationMappingRecord = string.Format(LocationMappingRecord, locationMappingName);
            WebDriverUtil.GetWebElement(locationMappingRecord, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate record on Location Mapping page - {locationMappingRecord}").Click();
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void MapsCreatedDepartmentAndLocation(string location, string department)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.MapsCreatedDepartmentAndLocation");
            CloseLocationMappingDetailSideBar();
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(Header));
            var found = false;
            var index = 0;
            foreach (var header in headers)
            {
                index++;
                var headerData = header.GetAttribute("innerHTML");
                if (!headerData.Contains(department)) continue;
                found = true;
                var locationMappingRecordMapping = string.Format(LocationMappingRecordMapping, location, index);
                WebDriverUtil.GetWebElement(locationMappingRecordMapping, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                break;
            }
            if (!found)
                throw new Exception($"No department found - {department} but we expect it should be display!");
        }
        public static void SelectTheLocation(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.SelectTheLocation");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            WebDriverUtil.GetWebElement(locationMappingRecord, WebDriverUtil.NO_WAIT,
            $"Unable to locate Location Mapping record on Location Mapping page - {locationMappingRecord}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void Refresh()
        {
            SeleniumDriver.Driver().Navigate().Refresh();
            WebDriverUtil.WaitForPageLoading();
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null) return;
            WebDriverUtil.WaitForWebElementClickable(ProfilingTab, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            profilingTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.ClickOnProfilingTab");
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null) return;
            WebDriverUtil.WaitForWebElementClickable(ProfilingCollapsedTab, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            profilingTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnLocationMappingTab()
        {
            LogWriter.WriteLog("Executing LocationMapping.ClickOnLocationMappingTab");
            if (WebDriverUtil.GetWebElement(LocationsMappingPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElementAndScroll(LocationMappingTab, WebDriverUtil.DEFAULT_WAIT, "Unable to locate Location Mapping Tab - " + LocationMappingTab).Click();
                WebDriverUtil.WaitForAWhile();
            }
            WebDriverUtil.WaitForAWhile();
        }

        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyAddButtonIsNotAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyEditLocationMappingSidebarIsAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyEditLocationMappingSidebarIsAvailable");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            WebDriverUtil.GetWebElement(locationMappingRecord, WebDriverUtil.NO_WAIT,
                $"Unable to locate location mapping record on location mapping page - {locationMappingRecord}").Click();
            WebDriverUtil.WaitForAWhile();
            var editLocationsMappingSidebar = WebDriverUtil.GetWebElement(EditLocationsMappingSidebar, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editLocationsMappingSidebar == null)
                throw new Exception("Edit location mapping sidebar is not found but we expect it should be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyEditDetailOptionsAreNotAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyEditDetailOptionsAreNotAvailable");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            if (WebDriverUtil.GetWebElement(EditLocationsMappingSidebar, WebDriverUtil.NO_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(locationMappingRecord, WebDriverUtil.NO_WAIT, $"Unable to locate location mapping record on location mapping page - {locationMappingRecord}").Click();
            }
            WebDriverUtil.WaitForAWhile();
            var nameInput = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (nameInput.Enabled)
                throw new Exception("Name input is enabled but we expect it should be disabled when user login from admin only access");
            var volumeDriverDropdown = WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverDropdown.Enabled)
                throw new Exception("VolumeDriver dropdown input is enabled but we expect it should be disabled when user login from admin only access");
            var characteristicDropdown = WebDriverUtil.GetWebElement(CharacteristicDropdown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (characteristicDropdown.Enabled)
                throw new Exception("Characteristic dropdown input is enabled but we expect it should be disabled when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifySaveButtonIsNotAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifySaveButtonIsNotAvailable");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            if (WebDriverUtil.GetWebElement(EditLocationsMappingSidebar, WebDriverUtil.NO_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(locationMappingRecord, WebDriverUtil.NO_WAIT, $"Unable to locate location mapping record on location mapping page - {locationMappingRecord}").Click();
            } 
            WebDriverUtil.WaitForAWhile();
            var saveButton = WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (saveButton != null)
                throw new Exception("Save button is found but we expect it should not be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void AddNewDepartmentWithGivenInput(string department)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.AddNewDepartmentWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewDepartmentMenuLink();
            if (department != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                        $"Unable to locate name input on departments page  - {NameInput}")
                    .SendKeys(Util.ProcessInputData(department));
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on departments page - {SaveButton}").Click();
            WebDriverUtil.WaitForAWhile();
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(DepartmentsPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(DepartmentsPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new department Error - {alert.Text}");
            }
        } 
        
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddNewDepartment, WebDriverUtil.NO_WAIT,
                $"Unable to locate add button on departments Page - {AddNewDepartment}").Click();

        }

        public static void UserClickOnNewDepartmentMenuLink()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.UserClickOnNewDepartmentMenuLink");
            WebDriverUtil.GetWebElement(AddDepartmentLink, WebDriverUtil.NO_WAIT,
                $"Unable to locate new department menu link on add menu popup - {AddDepartmentLink}").Click();

        }
        public static void ClickOnAddLocation()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.ClickOnAddLocation");
            CloseLocationDetailSideBar();
            WebDriverUtil.GetWebElement(AddLocationButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on locations page - {AddLocationButton}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void WaitForLoading()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.WaitForLoading");
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void CloseLocationDetailSideBar()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.CloseLocationDetailSideBar");
            var locationDetailsSideBar = WebDriverUtil.GetWebElement(CloseLocationDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (locationDetailsSideBar != null)
            {
                locationDetailsSideBar.Click();
                WaitForLoading();
            }
            locationDetailsSideBar = WebDriverUtil.GetWebElement(CancelLocationDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (locationDetailsSideBar == null) return;
            locationDetailsSideBar.Click();
            WaitForLoading();

        }
        public static void AddNewLocationWithGivenInput(string location)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.AddNewLocationWithGivenInput");
            WebDriverUtil.WaitForAWhile();
            ClickOnAddLocation();
            WebDriverUtil.WaitForAWhile();
            ClickOnNewLocationMenuLink();
            WebDriverUtil.WaitForAWhile();
            if (location != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create location page - {NameInput}")
                    .SendKeys(Util.ProcessInputData(location));
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create location page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(NewLocationFormPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(NewLocationFormPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new location Error - {alert.Text}");
            }

        }
        public static void ClickOnNewLocationMenuLink()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.ClickOnNewLocationMenuLink");
            WebDriverUtil.GetWebElement(AddLocationLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new location menu link on add menu popup - {AddLocationLink}").Click();
            WebDriverUtil.WaitForAWhile();
        }
    }
}
