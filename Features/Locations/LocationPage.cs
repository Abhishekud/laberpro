using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Locations
{
    public class LocationPage
    {
        const string PROFILING_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        const string LOCATIONS_TAB = "//a[text()='Locations']";
        const string LOCATIONS_PAGE = "//*[@class='page-title' and text()='Locations']";
        const string UNSORT_BUTTON = "//button[.//*[text()='Unsort']]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string CONFIG_GRID_BUTTON = "//button[.//*[@class='fa fa-cogs']]";
        const string CONFIG_GRID_SECTION = "//*[@class='grid-configuration sidebar-section']";
        const string CONFIG_NEWEST_BRAND = "//*[@class='grid-configuration sidebar-section']//*[text()='New Brand']/..//*[@role='switch' and @aria-checked='true']";
        const string CONFIG_NEW_BRAND = "//*[@class='grid-configuration sidebar-section']//*[text()='Newest brand']/..//*[@role='switch' and @aria-checked='true']";
        const string CLEAR_FILTER_BUTTON = "//button[@title='Clear All Filters']";
        const string LOCATION_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='7']//input";
        const string ADD_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string ADD_LOCATION_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@id='name']";
        const string DESCRIPTION_INPUT = "//*[@id='description']";
        const string LOCATION_PROFILE_DROPDOWN = "//*[@id='locationProfileId']";
        const string BRAND_DROPDOWN = "//*[@id='parentOrgHierarchyLevelOptionId']";
        const string ACTIVE_DATE_INPUT = "//*[@id='activeDate']";
        const string INACTIVE_DATE_INPUT = "//*[@id='inactiveDate']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_LOCATION_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string CLOSE_LOCATION_DETAILS = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Close']";
        const string CANCEL_LOCATION_DETAILS = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Cancel']";
        const string LOCATION_RECORD = "//*[@role='row']//*[text()='{0}']";
        const string LOCATION_DELETE_BUTTON = "//*[contains(@class,'locations-list-edit-sidebar')]//button[contains(@class,'delete')]";
        const string LOCATION_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string LOCATION_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string NEW_LOCATION_FORM_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Location')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string ExportButton = "//*[@id='export']";
        private const string ExportLocation = "//*[@class='dropdown-menu dropdown-menu-right' and @aria-labelledby='export']";
        private const string LocationRecord = "//*[@role='row']//*[text()='{0}']";
        private const string NameInput = "//*[@id='name']";
        private const string DeleteButton = "//*[contains(@class,'locations-list-edit-sidebar')]//button[contains(@class,'delete')]";
        private const string Header = "//th";
        private const string LocationMappingRecordMapping = "//*[@role='row' and .//*[text()='{0}']]//td[{1}]/input";
        private const string LocationRecordMapped = "//*[@role='row' and .//*[text()='{0}']]//td[{1}]/input[@checked]";


        public static void CloseLocationDetailSideBar()
        {
            LogWriter.WriteLog("Executing LocationsPage.CloseLocationDetailSideBar");
            IWebElement locationDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_LOCATION_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (locationDetailsSideBar != null)
            {
                locationDetailsSideBar.Click();
                WaitForLoading();
            }
            locationDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_LOCATION_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (locationDetailsSideBar != null)
            {
                locationDetailsSideBar.Click();
                WaitForLoading();
            }
            
        }
        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnProfilingTab");
            IWebElement profilingtab = WebDriverUtil.GetWebElement(PROFILING_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingtab != null)
            {
                profilingtab.Click();
                WebDriverUtil.WaitForAWhile(); 
            }
        }
        public static void ClickOnLocationsTab()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnLocationsTab");
            if (WebDriverUtil.GetWebElement(LOCATIONS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                SeleniumDriver.Driver().FindElement(By.XPath(LOCATIONS_TAB)).Click();
                WebDriverUtil.WaitForAWhile();
                SwitchOffNewestBrandColumn();
            }
        }
        public static void WaitForLocationAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing LocationsPage.WaitForLocationAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
                if (nametag != null)
                {
                    nametag.Click();    
                }
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void CloseLocationForm()
        {
            LogWriter.WriteLog("Executing LocationsPage.CloseLocationForm");
            WaitForLocationAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_LOCATION_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WaitForLoading();
            }
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnAddButton");
            CloseLocationDetailSideBar();
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button on Locations page - {0}", ADD_BUTTON)).Click();
            WebDriverUtil.WaitForAWhile();
        } 
        public static void ClickOnNewLocationMenuLink()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnNewLocationMenuLink");
            WebDriverUtil.GetWebElement(ADD_LOCATION_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate New Location menu link on add menu popup - {0}", ADD_LOCATION_LINK)).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void AddNewLocationWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing LocationsPage.AddNewLocationWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(LOCATION_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
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
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input on create location page - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }

            if (Util.ReadKey(dictionary, "Description") != null)
            {
                WebDriverUtil.GetWebElement(DESCRIPTION_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Description input on create location page - {0}", DESCRIPTION_INPUT))
                    .SendKeys(dictionary["Description"]);
            }

            if (Util.ReadKey(dictionary, "Location Profile") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LOCATION_PROFILE_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Location Profile input on create location page - {0}", LOCATION_PROFILE_DROPDOWN)))
                   .SelectByValue(dictionary["Location Profile"]);
            }
            if (Util.ReadKey(dictionary, "Brand") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(BRAND_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Brand input on create location page - {0}", BRAND_DROPDOWN)))
                    .SelectByValue(dictionary["Brand"]);
            }
            if (Util.ReadKey(dictionary, "Active Date") != null)
            {
                WebDriverUtil.GetWebElement(ACTIVE_DATE_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Included Paid Breaks (Minutes) input on create location page - {0}", ACTIVE_DATE_INPUT))
                    .SendKeys(dictionary["Active Date"]);
            }
            if (Util.ReadKey(dictionary, "Inactive Date") != null)
            {
                WebDriverUtil.GetWebElement(INACTIVE_DATE_INPUT, WebDriverUtil.NO_WAIT,
                 String.Format("Unable to locate Included Paid Breaks (Minutes) input on create location page - {0}", INACTIVE_DATE_INPUT))
                     .SendKeys(dictionary["Inactive Date"]);
            }
            
            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button on create allowance page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(NEW_LOCATION_FORM_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(NEW_LOCATION_FORM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new allowance Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void EditLocationWithGivenInput(string locationName, Table inputData)
        {
            LogWriter.WriteLog("Executing LocationsPage.EditLocationWithGivenInput");
            CloseLocationDetailSideBar();
            KeepRecordUnsort();
            WebDriverUtil.GetWebElement(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate location record on locations page - {0}", String.Format(LOCATION_RECORD, locationName))).Click();
            WebDriverUtil.WaitForAWhile();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            IWebElement element;
            //Enter location name if provided
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                element = WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                if (element==null)
                {
                    WebDriverUtil.GetWebElement(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate location record on locations page - {0}", String.Format(LOCATION_RECORD, locationName))).Click();
                    WebDriverUtil.WaitForAWhile();
                }
                element = WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input on create location page - {0}", NAME_INPUT));
                element.Click();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Description") != null)
            {
                element = WebDriverUtil.GetWebElement(DESCRIPTION_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Description input on create location page - {0}", DESCRIPTION_INPUT));
                element.Clear();
                element.SendKeys(dictionary["Description"]);
            }
            if (Util.ReadKey(dictionary, "Location Profile") != null)
            {
               new SelectElement(WebDriverUtil.GetWebElement(LOCATION_PROFILE_DROPDOWN, WebDriverUtil.NO_WAIT,
               String.Format("Unable to locate Location Profile input on create location page - {0}", LOCATION_PROFILE_DROPDOWN)))
                   .SelectByValue(dictionary["Location Profile"]);
            }
            if (Util.ReadKey(dictionary, "Brand") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(BRAND_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Brand input on create location page - {0}", BRAND_DROPDOWN)))
                    .SelectByValue(dictionary["Brand"]);
            }
            if (Util.ReadKey(dictionary, "Active Date") != null)
            {
                element = WebDriverUtil.GetWebElement(ACTIVE_DATE_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Included Paid Breaks (Minutes) input on create location page - {0}", ACTIVE_DATE_INPUT));
                element.Clear();
                element.SendKeys(dictionary["Active Date"]);
            }
            if (Util.ReadKey(dictionary, "Inactive Date") != null)
            {
                element = WebDriverUtil.GetWebElement(INACTIVE_DATE_INPUT, WebDriverUtil.NO_WAIT,
                 String.Format("Unable to locate Included Paid Breaks (Minutes) input on create location page - {0}", INACTIVE_DATE_INPUT));
                element.Clear();
                element.SendKeys(dictionary["Inactive Date"]);
            }
            
            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button on create allowance page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void VerifyCreatedLocation(string locationName)
        {
            LogWriter.WriteLog("Executing LocationsPage.VerifyCreatedLocation");
            WebDriverUtil.GetWebElementAndScroll(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate location record on locations page - {0}", String.Format(LOCATION_RECORD, locationName)));
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteCreatedLocation(string locationName)
        {
            LogWriter.WriteLog("Executing LocationsPage.DeleteCreatedLocation");
            CloseLocationDetailSideBar();
            KeepRecordUnsort();
            WebDriverUtil.GetWebElementAndScroll(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate location record on locations page - {0}", String.Format(LOCATION_RECORD, locationName))).Click();
            WebDriverUtil.WaitForAWhile();
            if(WebDriverUtil.GetWebElement(String.Format(LOCATION_DELETE_BUTTON, locationName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE)==null)
            {
                KeepRecordUnsort();
                WebDriverUtil.GetWebElementAndScroll(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate location record on locations page - {0}", String.Format(LOCATION_RECORD, locationName))).Click();
            }
            WebDriverUtil.GetWebElement(String.Format(LOCATION_DELETE_BUTTON, locationName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate location delete button on location details - {0}", String.Format(LOCATION_DELETE_BUTTON, locationName))).Click();
            WebDriverUtil.WaitForAWhile();

            WebDriverUtil.GetWebElement(LOCATION_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", LOCATION_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LOCATION_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Location Error - {0}", alert.Text));
            }
            
        }
        public static void DeleteLocationIfExist(string locationName)
        {
            LogWriter.WriteLog("Executing LocationsPage.DeleteLocationIfExist");
            //CloseLocationDetailSideBar();
            IWebElement record = WebDriverUtil.GetWebElement(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if(record != null)
            {
                //CloseLocationDetailSideBar();
                KeepRecordUnsort();
                WebDriverUtil.GetWebElementAndScroll(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate location record on locations page - {0}", String.Format(LOCATION_RECORD, locationName))).Click();
                WebDriverUtil.WaitForAWhile();
                if (WebDriverUtil.GetWebElement(String.Format(LOCATION_DELETE_BUTTON, locationName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                {
                    KeepRecordUnsort();
                    WebDriverUtil.GetWebElementAndScroll(String.Format(LOCATION_RECORD, locationName), WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate location record on locations page - {0}", String.Format(LOCATION_RECORD, locationName))).Click();
                }

                WebDriverUtil.GetWebElement(String.Format(LOCATION_DELETE_BUTTON, locationName), WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate location delete button on location details - {0}", String.Format(LOCATION_DELETE_BUTTON, locationName))).Click();
                WebDriverUtil.WaitForAWhile();

                WebDriverUtil.GetWebElement(LOCATION_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", LOCATION_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
                IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (alert == null)
                {
                    WebDriverUtil.WaitForWebElementInvisible(LOCATION_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                }
                else
                {
                    throw new Exception(string.Format("Unable to delete Location Mapping Error - {0}", alert.Text));
                }

            }
            
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing LocationsPage.ClickOnProfilingTab");
            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(CLEAR_FILTER_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
        public static void SearchLocation(String locationName)
        {
            WebDriverUtil.GetWebElement(LOCATION_FILTER_INPUT, WebDriverUtil.NO_WAIT,
                 String.Format("Unable to locate location filter input on location page - {0}", LOCATION_FILTER_INPUT)).SendKeys(locationName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void SwitchOffNewestBrandColumn()
        {
            WebDriverUtil.GetWebElement(CONFIG_GRID_BUTTON, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate configure grid button on location page - {0}", CONFIG_GRID_BUTTON)).Click();
            WebDriverUtil.WaitForAWhile();
            WebDriverUtil.GetWebElement(CONFIG_GRID_SECTION, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate configure grid section on location page - {0}", CONFIG_GRID_SECTION));
            IWebElement newestBrandSwithOn = WebDriverUtil.GetWebElement(CONFIG_NEWEST_BRAND, WebDriverUtil.NO_WAIT,WebDriverUtil.NO_MESSAGE);
            if(newestBrandSwithOn != null)
                newestBrandSwithOn.Click();
            IWebElement newBrandSwithOn = WebDriverUtil.GetWebElement(CONFIG_NEW_BRAND, WebDriverUtil.NO_WAIT,WebDriverUtil.NO_MESSAGE);
            if(newBrandSwithOn != null)
                newBrandSwithOn.Click();
            WebDriverUtil.GetWebElement(CONFIG_GRID_BUTTON, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate configure grid button on location page - {0}", CONFIG_GRID_BUTTON)).Click();
        }
        public static void KeepRecordUnsort()
        {
            WaitForLoading();
            IWebElement unsortButton = WebDriverUtil.GetWebElement(UNSORT_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (unsortButton != null)
            {
                unsortButton.Click();
                WaitForLoading();
            }
        }
        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyAddButtonIsNotAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportLocation, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export Option is not found but we expect it should be present as logged in user has view only access!");
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
                throw new Exception("edit TextBox is Enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LocationPage.VerifyDeleteButtonIsNotAvailable");
            var deleteButton = WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("delete button is found but we expect it should not be present when user login from view only access");
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
                    throw new Exception("Mapping of location and department is Enabled but we expect it should be disabled when user login from view only access");
                break;
            }
            if (!found)
                throw new Exception($"No department found - {department} but we expect it should be display!");
            BaseClass._AttachScreenshot.Value = true;
        }
    }        
}
