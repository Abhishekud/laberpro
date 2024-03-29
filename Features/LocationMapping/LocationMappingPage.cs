﻿using LaborPro.Automation.shared.drivers;
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
        private const string CloseLocationMappingFormButton = "//button[contains(text(),'Cancel')]";
        private const string LocationMappingRecordMapping = "//*[@role='row' and .//*[text()='{0}']]//td[{1}]/input";
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
        private const string SaveInprogress = "//button[contains(text(),'Saving...')]";
        private const string RecordForDept = "//td[contains(text(),'{0}')]";
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyExportOptionIsPresent");
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
            {
                throw new Exception("Export button is not found but we expect it should be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
            {
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDetailsAreNotEditable(string locationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyDetailsAreNotEditable");
            var locationMappingRecordXpath = string.Format(LocationMappingRecord, locationMappingName);
            WebDriverUtil.GetWebElement(locationMappingRecordXpath,
                                            WebDriverUtil.ONE_SECOND_WAIT,
                                            $"Unable to locate LocationMapping record on LocationMapping page - {locationMappingRecordXpath}"
                                            ).Click();
            var editTextBox = WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
            {
                throw new Exception("Edit TextBox is enabled but we expect it should be disabled when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifySaveButtonIsNotPresent(string locationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifySaveButtonIsNotPresent");
            var locationMappingRecordXpath = string.Format(LocationMappingRecord, locationMappingName);
            WebDriverUtil.GetWebElement(locationMappingRecordXpath,
                                            WebDriverUtil.ONE_SECOND_WAIT,
                                            $"Unable to locate LocationMapping record on LocationMapping page - {locationMappingRecordXpath}"
                                            ).Click();
            var saveButton = WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (saveButton != null)
            {
                throw new Exception("Save button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.SelectTheDepartment");
            var departmentValue = string.Format(DepartmentDropdownValue, departmentName);
            WebDriverUtil.GetWebElement(DepartmentDropdown,
                                            WebDriverUtil.ONE_SECOND_WAIT,
                                            $"Unable to locate the department dropdown - {DepartmentDropdown}"
                                            ).Click();
            WebDriverUtil.GetWebElement(departmentValue,
                                            WebDriverUtil.ONE_SECOND_WAIT,
                                            $"Unable to locate department record on department page - {departmentValue}"
                                            ).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void AddNewLocationMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.AddNewLocationMappingWithGivenInput");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            if (Util.ReadKey(dictionary, "VolumeDriverMappingSet") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.MAX_WAIT,
                $"Unable to locate Volume Driver Mapping Set record on create Location Mapping page - {VolumeDriverDropdown}"))
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
            if (WebDriverUtil.GetWebElement(LocationMappingPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationMappingPopup,
                                                            WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                                                            "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new Location Mapping page error - {formAlert.Text}");
            }
        }
        public static void CloseLocationMappingDetailSideBar()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.CloseLocationMappingDetailSideBar");
            var closeLocationMappingDetailsSideBar = WebDriverUtil.GetWebElement(CloseLocationMappingDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (closeLocationMappingDetailsSideBar == null)
            {
                return;
            }
            closeLocationMappingDetailsSideBar.Click();
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
        public static void VerifyCreatedLocationMapping(string locationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyCreatedLocationMapping");
            WebDriverUtil.WaitForAWhile();
            var locationMappingRecord = string.Format(LocationMappingRecord, locationMappingName);
            WebDriverUtil.GetWebElement(locationMappingRecord,
                                            WebDriverUtil.ONE_SECOND_WAIT,
                                            $"Unable to locate record on Location Mapping page - {locationMappingRecord}"
                                            ).Click();
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
                if (!headerData.Contains(department))
                {
                    continue;
                }
                found = true;
                var locationMappingRecordMapping = string.Format(LocationMappingRecordMapping, location, index);
                WebDriverUtil.GetWebElement(locationMappingRecordMapping, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                break;
            }

            if (!found)
            {
                throw new Exception($"No department found - {department} but we expect it should be display!");
            }
        }
        public static void SelectTheLocation(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.SelectTheLocation");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            WebDriverUtil.GetWebElement(locationMappingRecord,
                                            WebDriverUtil.NO_WAIT,
                                            $"Unable to locate Location Mapping record on Location Mapping page - {locationMappingRecord}"
                                            ).Click();
            WebDriverUtil.WaitForAWhile();
        }

        public static void Refresh()
        {
            SeleniumDriver.Driver().Navigate().Refresh();
            WebDriverUtil.WaitForPageLoading();
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null)
            {
                return;
            }
            WebDriverUtil.WaitForWebElementClickable(ProfilingTab, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            profilingTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.ClickOnProfilingTab");
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null)
            {
                return;
            }
            WebDriverUtil.WaitForWebElementClickable(ProfilingCollapsedTab, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            profilingTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnLocationMappingTab()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.ClickOnLocationMappingTab");
            if (WebDriverUtil.GetWebElement(LocationsMappingPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElementAndScroll(LocationMappingTab,
                                                        WebDriverUtil.DEFAULT_WAIT,
                                                        "Unable to locate Location Mapping Tab - " + LocationMappingTab
                                                        ).Click();
                WebDriverUtil.WaitForAWhile();
            }
            WebDriverUtil.WaitForAWhile();
        }
        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyAddButtonIsNotAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
            {
                throw new Exception("Add button is found but we expect it should not be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyEditLocationMappingSidebarIsAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyEditLocationMappingSidebarIsAvailable");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            WebDriverUtil.GetWebElement(locationMappingRecord, WebDriverUtil.NO_WAIT,
                                            $"Unable to locate location mapping record on location mapping page - {locationMappingRecord}"
                                            ).Click();
            WebDriverUtil.WaitForAWhile();
            var editLocationsMappingSidebar = WebDriverUtil.GetWebElement(EditLocationsMappingSidebar, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editLocationsMappingSidebar == null)
            {
                throw new Exception("Edit location mapping sidebar is not found but we expect it should be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyEditDetailOptionsAreNotAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyEditDetailOptionsAreNotAvailable");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            if (WebDriverUtil.GetWebElement(EditLocationsMappingSidebar, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(locationMappingRecord,
                                                WebDriverUtil.NO_WAIT, $"Unable to locate location mapping record on location mapping page - {locationMappingRecord}"
                                                ).Click();
            }
            WebDriverUtil.WaitForAWhile();
            var nameInput = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (nameInput.Enabled)
            {
                throw new Exception("Name input is enabled but we expect it should be disabled when user login from admin only access");
            }
            var volumeDriverDropdown = WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverDropdown.Enabled)
            {
                throw new Exception("VolumeDriver dropdown input is enabled but we expect it should be disabled when user login from admin only access");
            }
            var characteristicDropdown = WebDriverUtil.GetWebElement(CharacteristicDropdown, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (characteristicDropdown.Enabled)
            {
                throw new Exception("Characteristic dropdown input is enabled but we expect it should be disabled when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifySaveButtonIsNotAvailable(string locationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifySaveButtonIsNotAvailable");
            var locationMappingRecord = string.Format(LocationMappingRecord, locationName);
            if (WebDriverUtil.GetWebElement(EditLocationsMappingSidebar, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(locationMappingRecord,
                                                WebDriverUtil.NO_WAIT, $"Unable to locate location mapping record on location mapping page - {locationMappingRecord}"
                                                ).Click();
            }
            WebDriverUtil.WaitForAWhile();
            var saveButton = WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (saveButton != null)
            {
                throw new Exception("Save button is found but we expect it should not be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyRecordOfSelectedDept");
            var departmentRecordXpath = string.Format(RecordForDept, message);
            WebDriverUtil.GetWebElement(departmentRecordXpath, WebDriverUtil.NO_WAIT, $"Unable to locate record - {departmentRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void AddNewLocationMappingWithGivenInput(string volumeDriverMappingSet, string characteristicSet)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.AddNewLocationMappingWithGivenInput");
            if (volumeDriverMappingSet != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.MAX_WAIT,
                $"Unable to locate volume driver mapping set record on create location mapping page - {VolumeDriverDropdown}"))
                .SelectByText(volumeDriverMappingSet);
            }
            if (characteristicSet != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(CharacteristicDropdown, WebDriverUtil.MAX_WAIT,
                $"Unable to locate characteristic set input on create location mapping page - {CharacteristicDropdown}"))
                .SelectByText(characteristicSet);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create location mapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(LocationMappingPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationMappingPopup,
                                                            WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                                                            "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new location mapping error - {formAlert.Text}");
            }
        }

    }
}
