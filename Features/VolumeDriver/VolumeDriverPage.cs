using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.VolumeDriver
{
    public class VolumeDriverPage
    {
        private const string StandardFilingFieldId = "//select[@id='standardFilingFieldId']";
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string ListManagementTab = "//a[text()='List Management']";
        private const string AddButton = "//button[@id='create-volume-drivers']";
        private const string AddVolumeDriverLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string DepartmentInput = "//*[@id='departmentId']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseVolumeDriverFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseVolumeDriverDetails = "//button[text()='Close']";
        private const string CancelVolumeDriverDetails = "//button[text()='Cancel']]";
        private const string VolumeDriverDeleteButton = "//button[contains(@class,'delete')]";
        private const string VolumeDriverRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string VolumeDriverDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string VolumeDriverDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string VolumeDriverPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Volume Driver')]";
        private const string VolumeDriverFilterInput = "//th[@aria-colindex='1']//input";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string ClearFilterButton = "//button[@title='Clear All Filters']";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string VolumeDriverValueInLmDropdown = "//select[@id='standardFilingFieldId']//option[@value='VOLUME_DRIVERS']";
        private const string ExportButton = "//button[@id='export']";
        private const string SaveInprogress = "//button[contains(text(),'Saving...')]";
        private const string DeleteInprogress = "//button[contains(text(),'Deleting...')]";

        public static void CloseVolumeDriverDetailSideBar()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.CloseVolumeDriverDetailSideBar");
            var volumeDriverDetailsSideBar = WebDriverUtil.GetWebElement(CloseVolumeDriverDetails, WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (volumeDriverDetailsSideBar != null)
            {
                volumeDriverDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            volumeDriverDetailsSideBar = WebDriverUtil.GetWebElement(CancelVolumeDriverDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverDetailsSideBar == null)
            {
                return;
            }
            volumeDriverDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.VerifyAddButtonIsNotPresent");
            var addVolumeDriver = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addVolumeDriver != null)
            {
                throw new Exception("Add button is found but we expect it should not be present as logged in user has view only access!");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.VerifyDeleteButtonIsNotPresent");
            var volumeDriverRecordXpath = string.Format(VolumeDriverRecord, volumeDriverName);
            WebDriverUtil.GetWebElement(volumeDriverRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate VolumeDriver record on VolumeDriverPage - {volumeDriverRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(VolumeDriverDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
            {
                throw new Exception("Delete button is found but we expect it should not be present as logged in user has view only access!");
            }
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
            {
                throw new Exception("Edit text box is enabled but we expect it should be disabled when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.VerifyExportOptionIsNotPresent");
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton != null)
            {
                throw new Exception("Export button is found but we expect it should not be present as logged in user has view only access!");
            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void DeleteCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.DeleteCreatedVolumeDriver");
            CloseVolumeDriverDetailSideBar();
            var volumeDriverRecordXpath = string.Format(VolumeDriverRecord, volumeDriverName);
            WebDriverUtil.GetWebElement(volumeDriverRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate VolumeDriver record on VolumeDriver page - {volumeDriverRecordXpath}").Click();

            WebDriverUtil.GetWebElement(VolumeDriverDeleteButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate VolumeDriver delete button on VolumeDriver details page - {VolumeDriverDeleteButton}").Click();

            WebDriverUtil.GetWebElement(VolumeDriverDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate confirm button on delete confirmation popup - {VolumeDriverDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete VolumeDriver Error - {formAlert.Text}");
            }

        }
        public static void VerifyCreatedVolumeDriver(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.VerifyCreatedVolumeDriver");
            var volumeDriverRecordXpath = string.Format(VolumeDriverRecord, volumeDriverName);
            WebDriverUtil.GetWebElement(volumeDriverRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate VolumeDriver record on VolumeDriver Page - {volumeDriverRecordXpath}").Click();
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddNewVolumeDriverWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.AddNewVolumeDriverWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewVolumeDriverMenuLink();
            WebDriverUtil.WaitForAWhile();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on VolumeDrivers page  - {NameInput}")
                  .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Department") != null)
            {
                WebDriverUtil.GetWebElement(DepartmentInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate department input on VolumeDrivers page  - {DepartmentInput}")
                  .SendKeys(dictionary["Department"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on VolumeDrivers page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.NO_WAIT,
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
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new VolumeDriver Error - {formAlert.Text}");
            }

        }
        public static void AddNewVolumeDriverWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.AddNewVolumeDriverWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(VolumeDriverRecord, dictionary["Name"]),
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewVolumeDriverWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }

        }

        public static void DeleteVolumeDriverIfExist(string volumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.DeleteVolumeDriverIfExist");
            WaitForVolumeDriverAlertCloseIfAny();
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(VolumeDriverRecord, volumeDriverName),
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedVolumeDriver(volumeDriverName);
            }
        }
        public static void UserClickOnNewVolumeDriverMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.UserClickOnNewVolumeDriverMenuLink");
            WebDriverUtil.GetWebElement(AddVolumeDriverLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new VolumeDriver menu link on add menu popup - {AddVolumeDriverLink}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnVolumeDriver()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.ClickOnVolumeDriver");
            WebDriverUtil.GetWebElement(StandardFilingFieldId,
            WebDriverUtil.NO_WAIT, $"Unable to locate list management dropdown - {StandardFilingFieldId}").Click();
            WebDriverUtil.GetWebElement(VolumeDriverValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate VolumeDriver value - {VolumeDriverValueInLmDropdown}").Click();
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on VolumeDrivers page  - {AddButton}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void CloseVolumeDriverForm()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.CloseVolumeDriverForm");
            WaitForVolumeDriverAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseVolumeDriverFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.ClickOnListManagementTab");
            CloseVolumeDriverDetailSideBar();
            var listManagementTab = WebDriverUtil.GetWebElement(ListManagementTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (listManagementTab == null)
            {
                return;
            }
            listManagementTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null)
            {
                return;
            }
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForVolumeDriverAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.WaitForVolumeDriverAlertCloseIfAny");
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                return;
            }
            WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
            WebDriverUtil.GetWebElementAndScroll(NameInput);
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void SearchVolumeDriver(string volumeDriver)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.SearchVolumeDriver");
            WebDriverUtil.GetWebElement(VolumeDriverFilterInput, WebDriverUtil.NO_WAIT,
                 $"Unable to locate VolumeDriver filter input - {VolumeDriverFilterInput}").SendKeys(volumeDriver);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.WaitForLoading");
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.ClearAllFilter");
            var clearFilterButton = WebDriverUtil.GetWebElement(ClearFilterButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton == null)
            {
                return;
            }
            clearFilterButton.Click();
            WaitForLoading();
        }
        public static void AddNewVolumeDriverWithGivenInput(string volumeDriver, string department)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.AddNewVolumeDriverWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewVolumeDriverMenuLink();
            WebDriverUtil.WaitForAWhile();

            if (volumeDriver != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on VolumeDrivers page  - {NameInput}")
                  .SendKeys(Util.ProcessInputData(volumeDriver));
            }
            if (department != null)
            {
                WebDriverUtil.GetWebElement(DepartmentInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate department input on VolumeDrivers page  - {DepartmentInput}")
                  .SendKeys(department);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on VolumeDrivers page - {SaveButton}").Click();
            WebDriverUtil.WaitForAWhile();
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.NO_WAIT,
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
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new VolumeDriver Error - {formAlert.Text}");
            }

        }
    }
}
