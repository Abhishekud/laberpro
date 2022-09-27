using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Kronos.LaborDrivers
{
    public class LaborDriversPage
    {
        private const string KronosCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        private const string LaborDriversTab = "//a[text()='Labor Drivers']";
        private const string AddLaborDriversLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string SaveButton = "//button[text()='Save']";
        private const string CloseLaborDriversFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseLaborDriversDetails = "//button[text()='Close']";
        private const string LaborDriversDeleteButton = "//button[contains(@class,'delete')]";
        private const string LaborDriversRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string LaborDriversDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string LaborDriversDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string LaborDriversPages = "//h3[contains(text(),'Labor Drivers')]";
        private const string LaborDriversPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Labor Driver')]";
        private const string DriverTypeInput = "  //select[@id='laborDriverType']";
        private const string NumberInput = "//input[@id='number']";
        private const string NumberOfBusinessDaysToLookBackForVolumeInput = " //input[@id='lookBackCount']";
        private const string DriverInput = "//input[@id='driver']";
        private const string GenericCategoryInput = "//input[@id='genericCategory']";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string AddButton = "//button[@id='add']";
        private const string ExportButton = "//button[@id='export']";
        private const string ExportLaborDrivers = "//*[contains(@class,'dropdown-menu dropdown-menu-right')]//a[text()='Export Labor Drivers']";
        private const string NameInput = "//*[@id='name']";
        public static void AddNewLaborDriversWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.AddNewLaborDriversWithGivenInputIfNotExist");
            WaitForLaborDriversAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            var laborDriverXpath = string.Format(LaborDriversRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(laborDriverXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewLaborDriversWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void DeleteLaborDriversIfExist(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.DeleteLaborDriversIfExist");
            WaitForLaborDriversAlertCloseIfAny();
            var laborDriverXpath = string.Format(LaborDriversRecord, laborDriversName);
            var record = WebDriverUtil.GetWebElementAndScroll(laborDriverXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedLaborDrivers(laborDriversName);
            }
        }
        public static void CloseLaborDriversDetailSideBar()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.CloseLaborDriversDetailSideBar");
            var laborDriversDetailsSideBar = WebDriverUtil.GetWebElement(CloseLaborDriversDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (laborDriversDetailsSideBar == null) return;
            laborDriversDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void DeleteCreatedLaborDrivers(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.DeleteCreatedLaborDrivers");
            CloseLaborDriversDetailSideBar();
            var laborDriverXpath = string.Format(LaborDriversRecord, laborDriversName);

            WebDriverUtil.GetWebElement(laborDriverXpath, WebDriverUtil.NO_WAIT,
            $"Unable to locate LaborDrivers record on LaborDrivers page - {laborDriverXpath}").Click();

            WebDriverUtil.GetWebElement(LaborDriversDeleteButton, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate LaborDrivers delete button on LaborDrivers details page - {LaborDriversDeleteButton}").Click();
            WebDriverUtil.GetWebElement(LaborDriversDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {LaborDriversDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LaborDriversDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Labor Driver Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedLaborDrivers(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyCreatedLaborDrivers");
            var laborDriverXpath = string.Format(LaborDriversRecord, laborDriversName);
            WebDriverUtil.GetWebElement(laborDriverXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate record on LaborDrivers page - {laborDriverXpath}");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyAddMenuPopup");
            WebDriverUtil.GetWebElement(LaborDriversPopup, WebDriverUtil.NO_WAIT, $"Unable to locate Add Menu Popup - {LaborDriversPopup}");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddNewLaborDriversWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.AddNewLaborDriversWithGivenInput");
            CloseLaborDriversDetailSideBar();
            ClickOnAddButton();
            UserClickOnNewLaborDriversMenuLink();

            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on create LaborDrivers page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Driver Type") != null)
            {
                WebDriverUtil.WaitFor(1);
                new SelectElement(WebDriverUtil.GetWebElement(DriverTypeInput, WebDriverUtil.FIVE_SECOND_WAIT,
                $"Unable to locate Driver Type input on create LaborDrivers page - {DriverTypeInput}"))
                    .SelectByText(dictionary["Driver Type"]);

            }

            if (Util.ReadKey(dictionary, "Number") != null)
            {
                WebDriverUtil.GetWebElement(NumberInput, WebDriverUtil.FIVE_SECOND_WAIT,
                $"Unable to locate  Number input on create LaborDrivers page - {NumberInput}")
                    .SendKeys(dictionary["Number"]);
            }
            if (Util.ReadKey(dictionary, "Number of business days to look back for volume") != null)
            {
                WebDriverUtil.GetWebElement(NumberOfBusinessDaysToLookBackForVolumeInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate  Number of business days to look back for volume input on create LaborDrivers page - {NumberOfBusinessDaysToLookBackForVolumeInput}")
                    .SendKeys(dictionary["Number of business days to look back for volume"]);
            }
            if (Util.ReadKey(dictionary, "Driver") != null)
            {
                WebDriverUtil.GetWebElement(DriverInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Driver input on create LaborDrivers page - {DriverInput}")
                    .SendKeys(dictionary["Driver"]);
            }
            if (Util.ReadKey(dictionary, "Generic Category") != null)
            {
                WebDriverUtil.GetWebElement(GenericCategoryInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Generic Category input on create LaborDrivers page - {GenericCategoryInput}")
                    .SendKeys(dictionary["Generic Category"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on LaborDrivers page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(LaborDriversPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LaborDriversPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new LaborDrivers Error - {alert.Text}");
            }
        }
        public static void UserClickAddLaborDriversButton()
        {
            ClickOnAddButton();
            UserClickOnNewLaborDriversMenuLink();
        }
        public static void UserClickOnNewLaborDriversMenuLink()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.UserClickOnNewLaborDriversMenuLink");
            WebDriverUtil.GetWebElement(AddLaborDriversLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new LaborDrivers menu link on add menu popup - {AddLaborDriversLink}").Click();
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
          $"Unable to locate add button on LaborDrivers page  - {AddButton}").Click();

        }
        public static void CloseLaborDriversForm()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.CloseLaborDriversForm");
            WaitForLaborDriversAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseLaborDriversFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnLaborDriversTab()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.ClickOnLaborDriversTab");
            if (WebDriverUtil.GetWebElement(LaborDriversPages, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            WebDriverUtil.GetWebElement(LaborDriversTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.ClickOnKronosTab");
            var kronosTab = WebDriverUtil.GetWebElement(KronosCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (kronosTab == null) return;
            kronosTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForLaborDriversAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.WaitForLaborDriversAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
                WebDriverUtil.GetWebElementAndScroll(NameInput);

            }
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportLaborDrivers, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string laborDriversName)
        {
            LogWriter.WriteLog("Executing LaborDriversPage.VerifyDeleteButtonIsNotPresent");
            var laborRecordXpath = string.Format(LaborDriversRecord, laborDriversName);
            WebDriverUtil.GetWebElement(laborRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate LaborDrivers record on LaborDrivers page - {laborRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(LaborDriversDeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);

            if (deleteButton.Enabled)
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("Edit TextBox is enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }

    }
}

