 using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Locations
{
    public class LocationPage
    {

        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string ExportButton = "//*[@id='export']";
        private const string ExportLocation = "//*[@class='dropdown-menu dropdown-menu-right' and @aria-labelledby='export']";
        private const string LocationRecord = "//*[@role='row']//*[text()='{0}']";
        private const string NameInput = "//*[@id='name']";
        private const string DeleteButton = "//*[contains(@class,'locations-list-edit-sidebar')]//button[contains(@class,'delete')]";
        private const string Header = "//th";
        private const string LocationMappingRecordMapping = "//*[@role='row' and .//*[text()='{0}']]//td[{1}]/input";
        private const string LocationRecordMapped = "//*[@role='row' and .//*[text()='{0}']]//td[{1}]/input[@checked]";
        private const string ProfilingCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        private const string LocationsTab = "//a[text()='Locations']";
        private const string LocationsPage = "//*[@class='page-title' and text()='Locations']";
        private const string UnSortButton = "//button[.//*[text()='Unsort']]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string ConfigGridButton = "//button[.//*[@class='fa fa-cogs']]";
        private const string ConfigGridSection = "//*[@class='grid-configuration sidebar-section']";
        private const string ConfigNewestBrand = "//*[@class='grid-configuration sidebar-section']//*[text()='New Brand']/..//*[@role='switch' and @aria-checked='true']";
        private const string ConfigNewBrand = "//*[@class='grid-configuration sidebar-section']//*[text()='Newest brand']/..//*[@role='switch' and @aria-checked='true']";
        private const string ClearFilterButton = "//button[@title='Clear All Filters']";
        private const string LocationFilterInput = "//*[@aria-label='Filter' and @aria-colindex='7']//input";
        private const string AddLocationLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string DescriptionInput = "//*[@id='description']";
        private const string LocationProfileDropdown = "//*[@id='locationProfileId']";
        private const string BrandDropdown = "//*[@id='parentOrgHierarchyLevelOptionId']";
        private const string ActiveDateInput = "//*[@id='activeDate']";
        private const string InactiveDateInput = "//*[@id='inactiveDate']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseLocationFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string CloseLocationDetails = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Close']";
        private const string CancelLocationDetails = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Cancel']";
        private const string LocationDeleteButton = "//*[contains(@class,'locations-list-edit-sidebar')]//button[contains(@class,'delete')]";
        private const string LocationDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string LocationDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string NewLocationFormPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Location')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string NewLocationProfileFormPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Location Profile')]";
        private const string ImportLocationsFormPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'Import Locations')]";
        private const string ImportLocationProfilesFormPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'Import Location Profiles')]";
        private const string LocationProfilesRecord = "//*[@class='location-profile-list-entry']//*[@title='{0}']";
        private const string CloseLocationProfileFormButton = "//button[contains(text(),'Cancel')]";
        private const string EditButton = "//*[@class='location-profile-list-entry']//*[@title='{0}']/../button";
        private const string CheckLocationProfile = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        private const string DeleteLocationProfileButton = "//div[contains(@class,'location-profile-list-entry-editor')]//button[@class='btn btn-sm btn-default']";
        private const string OpenEditSidebarForm = "//*[@class='sidebar-scrollable']//div[@class='action-buttons-none sidebar-section']";
        private const string TickOption = "//*[@class='k-checkbox']";
        private const string BulkEditOption = "//button[@title='Bulk Edit']";
        private const string FirstRecord = "//tr[@data-grid-row-index='0']/td[1]/input";
        private const string UpdateLocationProfile = "//div[contains(@class,'checkbox')]//input[@id='updateLocationProfileId']";
        private const string UpdateActiveDate = "//div[contains(@class,'checkbox')]//input[@id='updateActiveDate']";
        private const string UpdateInactiveDate = "//div[contains(@class,'checkbox')]//input[@id='updateInactiveDate']";
        private const string EditLocationProfileSidebar = "//*[@class='sidebar-scrollable']//div[@class='location sidebar-section']";
        private const string AssignDepartmentsDropDown = "//div[contains(@class,'select-list-item-appender')]//select[contains(@class, 'form-control')]";
        private const string SavingWait = "//button[contains(text(),'Saving...')]";


        public static void CloseLocationDetailSideBar()
        {
            LogWriter.WriteLog("Executing LocationsPage.CloseLocationDetailSideBar");
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
        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnProfilingTab");
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null) return;
            profilingTab.Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnLocationsTab()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnLocationsTab");
            if (WebDriverUtil.GetWebElement(LocationsPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            SeleniumDriver.Driver().FindElement(By.XPath(LocationsTab)).Click();
            WebDriverUtil.WaitForAWhile();
            SwitchOffNewestBrandColumn();
        }
        public static void WaitForLocationAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing LocationsPage.WaitForLocationAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            var nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);
            if (nameTag != null)
            {
                nameTag.Click();
            }
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void CloseLocationForm()
        {
            LogWriter.WriteLog("Executing LocationsPage.CloseLocationForm");
            WaitForLocationAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseLocationFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton == null) return;
            formCloseButton.Click();
            WaitForLoading();
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnAddButton");
            CloseLocationDetailSideBar();
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Locations page - {AddButton}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnNewLocationMenuLink()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnNewLocationMenuLink");
            WebDriverUtil.GetWebElement(AddLocationLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate New Location menu link on add menu popup - {AddLocationLink}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void AddNewLocationWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing LocationsPage.AddNewLocationWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            var locationRecord = string.Format(LocationRecord, dictionary["Name"]);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            var record = WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewLocationWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void AddNewLocationWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing LocationsPage.AddNewLocationWithGivenInput");
            WebDriverUtil.WaitForAWhile();
            ClickOnAddButton();
            WebDriverUtil.WaitForAWhile();
            ClickOnNewLocationMenuLink();
            WebDriverUtil.WaitForAWhile();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            //Enter location name if provided
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on create location page - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }

            if (Util.ReadKey(dictionary, "Description") != null)
            {
                WebDriverUtil.GetWebElement(DescriptionInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Description input on create location page - {DescriptionInput}")
                    .SendKeys(dictionary["Description"]);
            }

            if (Util.ReadKey(dictionary, "Location Profile") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LocationProfileDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate Location Profile input on create location page - {LocationProfileDropdown}"))
                   .SelectByValue(dictionary["Location Profile"]);
            }
            if (Util.ReadKey(dictionary, "Brand") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(BrandDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate Brand input on create location page - {BrandDropdown}"))
                    .SelectByValue(dictionary["Brand"]);
            }
            if (Util.ReadKey(dictionary, "Active Date") != null)
            {
                WebDriverUtil.GetWebElement(ActiveDateInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate active date input on create location page - {ActiveDateInput}")
                    .SendKeys(dictionary["Active Date"]);
            }
            if (Util.ReadKey(dictionary, "Inactive Date") != null)
            {
                WebDriverUtil.GetWebElement(InactiveDateInput, WebDriverUtil.NO_WAIT,
                 $"Unable to locate inactive date input on create location page - {InactiveDateInput}")
                     .SendKeys(dictionary["Inactive Date"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create location page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible( SavingWait, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
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
        public static void EditLocationWithGivenInput(string locationName, Table inputData)
        {
            LogWriter.WriteLog("Executing LocationsPage.EditLocationWithGivenInput");
            CloseLocationDetailSideBar();
            KeepRecordUnSort();
            var locationRecord = string.Format(LocationRecord, locationName);
            WebDriverUtil.GetWebElement(locationRecord, WebDriverUtil.NO_WAIT,
                    $"Unable to locate location record on locations page - {locationRecord}").Click();
            WebDriverUtil.WaitForAWhile();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            IWebElement element;
            //Enter location name if provided
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                element = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                if (element == null)
                {
                    WebDriverUtil.GetWebElement(locationRecord, WebDriverUtil.NO_WAIT,
                    $"Unable to locate location record on locations page - {LocationRecord}").Click();
                    WebDriverUtil.WaitForAWhile();
                }
                element = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on create location page - {NameInput}");
                element.Click();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Description") != null)
            {
                element = WebDriverUtil.GetWebElement(DescriptionInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Description input on create location page - {DescriptionInput}");
                element.Clear();
                element.SendKeys(dictionary["Description"]);
            }
            if (Util.ReadKey(dictionary, "Location Profile") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LocationProfileDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate Location Profile input on create location page - {LocationProfileDropdown}"))
                    .SelectByValue(dictionary["Location Profile"]);
            }
            if (Util.ReadKey(dictionary, "Brand") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(BrandDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate Brand input on create location page - {BrandDropdown}"))
                    .SelectByValue(dictionary["Brand"]);
            }
            if (Util.ReadKey(dictionary, "Active Date") != null)
            {
                element = WebDriverUtil.GetWebElement(ActiveDateInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate active date input on create location page - {ActiveDateInput}");
                element.Clear();
                element.SendKeys(dictionary["Active Date"]);
            }
            if (Util.ReadKey(dictionary, "Inactive Date") != null)
            {
                element = WebDriverUtil.GetWebElement(InactiveDateInput, WebDriverUtil.NO_WAIT,
                 $"Unable to locate inactive date input on create location page - {InactiveDateInput}");
                element.Clear();
                element.SendKeys(dictionary["Inactive Date"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create location page - {SaveButton}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void VerifyCreatedLocation(string locationName)
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyCreatedLocation");
            var locationRecord = string.Format(LocationRecord, locationName);
            WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate location record on locations page - {locationRecord}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteCreatedLocation(string locationName)
        {
            LogWriter.WriteLog("Executing LocationsPage.DeleteCreatedLocation");
            CloseLocationDetailSideBar();
            KeepRecordUnSort();
            var locationRecord = string.Format(LocationRecord, locationName);
            var locationDelete = string.Format(LocationDeleteButton, locationName);
            WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.NO_WAIT,
            $"Unable to locate location record on locations page - {locationRecord}").Click();
            WebDriverUtil.WaitForAWhile();
            if (WebDriverUtil.GetWebElement(locationDelete, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                KeepRecordUnSort();
                WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.NO_WAIT,
                $"Unable to locate location record on locations page - {locationRecord}").Click();
            }
            WebDriverUtil.GetWebElement(locationDelete, WebDriverUtil.NO_WAIT,
            $"Unable to locate location delete button on location details - {locationDelete}").Click();
            WebDriverUtil.WaitForAWhile();

            WebDriverUtil.GetWebElement(LocationDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {LocationDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Location Error - {alert.Text}");
            }

        }
        public static void DeleteLocationIfExist(string locationName)
        {
            LogWriter.WriteLog("Executing LocationsPage.DeleteLocationIfExist");
            var locationRecord = string.Format(LocationRecord, locationName);
            var locationDelete = string.Format(LocationDeleteButton, locationName);
            var record = WebDriverUtil.GetWebElement(locationRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null) return;
            KeepRecordUnSort();
            WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.NO_WAIT,
                $"Unable to locate location record on locations page - {locationRecord}").Click();
            WebDriverUtil.WaitForAWhile();
            if (WebDriverUtil.GetWebElement(locationDelete, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                KeepRecordUnSort();
                WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.NO_WAIT,
                    $"Unable to locate location record on locations page - {locationRecord}").Click();
            }

            WebDriverUtil.GetWebElement(locationDelete, WebDriverUtil.NO_WAIT,
                $"Unable to locate location delete button on location details - {locationDelete}").Click();
            WebDriverUtil.WaitForAWhile();

            WebDriverUtil.GetWebElement(LocationDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate confirm button on delete confirmation popup - {LocationDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete location error - {alert.Text}");
            }

        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnProfilingTab");
            var clearFilterButton = WebDriverUtil.GetWebElement(ClearFilterButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton == null) return;
            clearFilterButton.Click();
            WaitForLoading();
        }
        public static void SearchLocation(string locationName)
        {
            WebDriverUtil.GetWebElement(LocationFilterInput, WebDriverUtil.NO_WAIT,
                 $"Unable to locate location filter input on location page - {LocationFilterInput}").SendKeys(locationName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void SwitchOffNewestBrandColumn()
        {
            WebDriverUtil.GetWebElement(ConfigGridButton, WebDriverUtil.NO_WAIT,
                    $"Unable to locate configure grid button on location page - {ConfigGridButton}").Click();
            WebDriverUtil.WaitForAWhile();
            WebDriverUtil.GetWebElement(ConfigGridSection, WebDriverUtil.NO_WAIT,
                    $"Unable to locate configure grid section on location page - {ConfigGridSection}");
            var newestBrandSwitchOn = WebDriverUtil.GetWebElement(ConfigNewestBrand, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (newestBrandSwitchOn != null)
                newestBrandSwitchOn.Click();
            var newBrandSwitchOn = WebDriverUtil.GetWebElement(ConfigNewBrand, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (newBrandSwitchOn != null)
                newBrandSwitchOn.Click();
            WebDriverUtil.GetWebElement(ConfigGridButton, WebDriverUtil.NO_WAIT,
                    $"Unable to locate configure grid button on location page - {ConfigGridButton}").Click();
        }
        public static void KeepRecordUnSort()
        {
            WaitForLoading();
            var unSortButton = WebDriverUtil.GetWebElement(UnSortButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (unSortButton == null) return;
            unSortButton.Click();
            WaitForLoading();
        }



        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyAddButtonIsNotAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportLocation, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectLocationRecord(string locationRecord)
        {
            LogWriter.WriteLog("Executing LocationPage.SelectLocationRecord");
            var locationValue = string.Format(LocationRecord, locationRecord);
            var location = WebDriverUtil.GetWebElement(locationValue, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate location record on location page - {locationValue}");
            if (location == null)
                return;
            location.Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void VerifyEditOptionIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyEditOptionIsNotAvailable");
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("Edit TextBox is enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyDeleteButtonIsNotAvailable");
            var deleteButton = WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void MapsCreatedDepartmentAndLocationNotAvailable(string location, string department)
        {
            LogWriter.WriteLog("Executing LocationPage.MapsCreatedDepartmentAndLocation");
            CloseLocationDetailSideBar();
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
                var locationDepartmentMapping = WebDriverUtil.GetWebElement(locationMappingRecordMapping, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                locationDepartmentMapping.Click();
                var locationMapped = string.Format(LocationRecordMapped, location, index);
                var locationRecordMapped = WebDriverUtil.GetWebElement(locationMapped, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                if (locationRecordMapped != null)
                    throw new Exception("Mapping of location and department is enabled but we expect it should be disabled when user login from view only access");
                break;
            }
            if (!found)
                throw new Exception($"No department found - {department} but we expect it should be display!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyAddButtonIsAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton == null)
                throw new Exception("Add button is not found but we expect it should be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonOptionsAreAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyAddButtonOptionsAreAvailable");
            CloseLocationDetailSideBar();
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate add button on Locations page - {AddButton}").Click();
            WebDriverUtil.WaitForAWhile();
            var importLocationProfiles = SeleniumDriver.Driver().FindElement(By.LinkText("Import Location Profiles"));
            if (importLocationProfiles == null)
                throw new Exception("Import location profiles button is not found but we expect it should be present when user login from admin only access");
            var newLocation = SeleniumDriver.Driver().FindElement(By.LinkText("New Location"));
            if (newLocation == null)
                throw new Exception("New location button is not found but we expect it should be present when user login from admin only access");
            var newLocationProfile = SeleniumDriver.Driver().FindElement(By.LinkText("New Location Profile"));
            if (newLocationProfile == null)
                throw new Exception("New location profile button is not found but we expect it should be present when user login from admin only access");
            var importLocations = SeleniumDriver.Driver().FindElement(By.LinkText("Import Locations"));
            if (importLocations == null)
                throw new Exception("Import locations button is not found but we expect it should be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyNewLocationPopupIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyNewLocationPopupIsAvailable");
            ClickOnNewLocationMenuLink();
            WebDriverUtil.GetWebElement(NewLocationFormPopup, WebDriverUtil.NO_WAIT, $"Unable to locate add location menu popup - {NewLocationFormPopup}");
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.WaitForAWhile();
        }
        public static void CreateNewLocation(string locationName)
        {
            LogWriter.WriteLog("Executing LocationsPage.CreateNewLocation");
            WebDriverUtil.WaitForAWhile();
            ClickOnAddButton();
            WebDriverUtil.WaitForAWhile();
            ClickOnNewLocationMenuLink();
            WebDriverUtil.WaitForAWhile();

            WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on create location page - {NameInput}")
                    .SendKeys(Util.ProcessInputData(locationName));

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create location page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible( SavingWait, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
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
        public static void VerifyNewLocationProfilePopupIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyNewLocationProfilePopupIsAvailable");
            ClickOnAddButton();
            var newLocationProfile = SeleniumDriver.Driver().FindElement(By.LinkText("New Location Profile"));
            newLocationProfile.Click();
            if (newLocationProfile == null)
                throw new Exception("New location profile button is not found but we expect it should be present when user login from admin only access");
            WebDriverUtil.GetWebElement(NewLocationProfileFormPopup, WebDriverUtil.NO_WAIT, $"Unable to locate add location profile menu popup - {NewLocationProfileFormPopup}");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyImportLocationsPopupIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyImportLocationsPopupIsAvailable");
            ClickOnAddButton();
            var importLocations = SeleniumDriver.Driver().FindElement(By.LinkText("Import Locations"));
            importLocations.Click();
            if (importLocations == null)
                throw new Exception("Import locations button is not found but we expect it should be present when user login from admin only access");
            WebDriverUtil.GetWebElement(ImportLocationsFormPopup, WebDriverUtil.NO_WAIT, $"Unable to locate import locations menu popup - {ImportLocationsFormPopup}");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyImportLocationsProfilePopupIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyImportLocationsProfilePopupIsAvailable");
            ClickOnAddButton();
            var importLocationProfiles = SeleniumDriver.Driver().FindElement(By.LinkText("Import Location Profiles"));
            importLocationProfiles.Click();
            if (importLocationProfiles == null)
                throw new Exception("Import location profiles button is not found but we expect it should be present when user login from admin only access");
            WebDriverUtil.GetWebElement(ImportLocationProfilesFormPopup, WebDriverUtil.NO_WAIT, $"Unable to locate import location profiles menu popup - {ImportLocationProfilesFormPopup}");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddNewLocationProfileWithGivenInput(string locationProfile)
        {
            LogWriter.WriteLog("Executing LocationsPage.AddNewLocationProfileWithGivenInput");
            WebDriverUtil.WaitForAWhile();
            ClickOnAddButton();
            WebDriverUtil.WaitForAWhile();

            var newLocationProfile = SeleniumDriver.Driver().FindElement(By.LinkText("New Location Profile"));
            newLocationProfile.Click();
            if (newLocationProfile == null)
                throw new Exception("New location profile button is not found but we expect it should be present when user login from admin only access");
            WebDriverUtil.WaitForAWhile();
            WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on create location profile page - {NameInput}")
                    .SendKeys(Util.ProcessInputData(locationProfile));

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create location profile page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible( SavingWait, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(NewLocationProfileFormPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(NewLocationProfileFormPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new location profile Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedLocationProfile(string locationProfile)
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyCreatedLocationProfile");
            WaitForLocationAlertCloseIfAny();
            WebDriverUtil.GetWebElement(CloseLocationProfileFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            var locationRecord = string.Format(LocationProfilesRecord, DataCache.Read(locationProfile));
            WebDriverUtil.GetWebElementAndScroll(locationRecord, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate location profile record on locations profile page - {locationRecord}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyLocationProfileListingIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyLocationProfileListingIsAvailable");
            WaitForLocationAlertCloseIfAny();
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CheckLocationProfile, WebDriverUtil.NO_WAIT, $"Unable to locate the check location profile button - {CheckLocationProfile}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            var locationProfileListing = WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (locationProfileListing == null)
                throw new Exception("Locations profiling listing is not found but we expect it should be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyLocationProfileEditOptionsAreAvailable(string locationProfile)
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyLocationProfileEditOptionsAreAvailable");
            WaitForLocationAlertCloseIfAny();
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CheckLocationProfile, WebDriverUtil.NO_WAIT, $"Unable to locate the check location profile button - {CheckLocationProfile}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            var editButtonFordLocationProfile = string.Format(EditButton, DataCache.Read(locationProfile));
            WebDriverUtil.GetWebElement(editButtonFordLocationProfile, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(DeleteLocationProfileButton, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate delete button - {DeleteLocationProfileButton}");
            WebDriverUtil.GetWebElement(AssignDepartmentsDropDown, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate assign departments dropdown - {AssignDepartmentsDropDown}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyCheckboxesAreAvailable()
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyCheckboxesAreAvailable");
            WebDriverUtil.GetWebElement(CheckLocationProfile, WebDriverUtil.NO_WAIT, $"Unable to locate the check location profile button - {CheckLocationProfile}").Click();
            var tickOption = WebDriverUtil.GetWebElement(TickOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (tickOption == null)
                throw new Exception("Tick option is not found but we expect it should be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.WaitForAWhile();

        }
        public static void VerifyBulkEditOptionIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyBulkEditOptionIsAvailable");
            WebDriverUtil.GetWebElement(FirstRecord, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate first record - {FirstRecord}").Click();
            var bulkEditOption = WebDriverUtil.GetWebElement(BulkEditOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (bulkEditOption == null)
                throw new Exception("Bulk edit option is not found but we expect it should be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.WaitForAWhile();

        }
        public static void VerifyEditLocationOptionsAreAvailable()
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyEditLocationOptionsAreAvailable");
            if (WebDriverUtil.GetWebElement(BulkEditOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            { WebDriverUtil.GetWebElement(FirstRecord, WebDriverUtil.NO_WAIT, $"Unable to locate first record - {FirstRecord}").Click(); }
            var bulkEditOption = WebDriverUtil.GetWebElement(BulkEditOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            bulkEditOption.Click();
            if (bulkEditOption == null)
                throw new Exception("Bulk edit option is not found but we expect it should be present when user login from admin only access");
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.GetWebElement(UpdateLocationProfile, WebDriverUtil.NO_WAIT, $"Unable to locate update location profile input - {UpdateLocationProfile}");
            WebDriverUtil.GetWebElement(UpdateActiveDate, WebDriverUtil.NO_WAIT, $"Unable to locate update active date input - {UpdateActiveDate}");
            WebDriverUtil.GetWebElement(UpdateInactiveDate, WebDriverUtil.NO_WAIT, $"Unable to locate update inactive date input - {UpdateInactiveDate}");
            WebDriverUtil.WaitForAWhile();

        }
        public static void VerifyEditLocationSidebarIsAvailable()
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyEditLocationSidebarIsAvailable");
            if (WebDriverUtil.GetWebElement(BulkEditOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            { WebDriverUtil.GetWebElement(FirstRecord, WebDriverUtil.NO_WAIT, $"Unable to locate first record - {FirstRecord}").Click(); }

            if (WebDriverUtil.GetWebElement(EditLocationProfileSidebar, WebDriverUtil.NO_WAIT,
                    $"Unable to locate edit location profile sidebar - {EditLocationProfileSidebar}") == null)
            {
                var bulkEditOption = WebDriverUtil.GetWebElement(BulkEditOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                bulkEditOption.Click();
                if (bulkEditOption == null)
                    throw new Exception("Bulk edit option is not found but we expect it should be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.GetWebElement(EditLocationProfileSidebar, WebDriverUtil.NO_WAIT, $"Unable to locate edit location profile sidebar - {EditLocationProfileSidebar}");
            WebDriverUtil.GetWebElement(FirstRecord, WebDriverUtil.NO_WAIT, $"Unable to locate first record - {FirstRecord}").Click();
            WebDriverUtil.WaitForAWhile();
        }

        public static void DeleteCreatedLocationProfile(string locationProfile)
        {
            LogWriter.WriteLog("Executing LocationsPage.DeleteCreatedLocationProfile");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CheckLocationProfile, WebDriverUtil.NO_WAIT, $"Unable to locate the check location profile button - {CheckLocationProfile}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            var editButtonFordLocationProfile = string.Format(EditButton, DataCache.Read(locationProfile));
            if (WebDriverUtil.GetWebElement(DeleteLocationProfileButton, WebDriverUtil.FIVE_SECOND_WAIT, $"Unable to locate delete button - {DeleteLocationProfileButton}") == null)
            {
                WebDriverUtil.GetWebElement(editButtonFordLocationProfile, WebDriverUtil.FIVE_SECOND_WAIT, $"Unable to locate edit button -{editButtonFordLocationProfile}").Click();
            }
            WebDriverUtil.GetWebElement(DeleteLocationProfileButton, WebDriverUtil.FIVE_SECOND_WAIT, $"Unable to locate delete button - {DeleteLocationProfileButton}").Click();
            WebDriverUtil.GetWebElement(LocationDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT, "Unable to find delete confirmation popup!").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete location profile Error - {alert.Text}");
            }
            WebDriverUtil.GetWebElement(CheckLocationProfile, WebDriverUtil.NO_WAIT, $"Unable to locate the check location profile button - {CheckLocationProfile}").Click();

        }
    }
}

