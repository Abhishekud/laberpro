using LaborPro.Automation.Features.VolumeDriverValue;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace LaborPro.Automation.Features.Kronos.LaborPeriods
{
    public class LaborPeriodsPage
    {
        private const string KronosTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        private const string LaborPeriodsTab = "//a[text()='Labor Periods']";
        private const string LaborPeriodPage = "//h3[text()='Labor Periods']";
        private const string AddLaborPeriods = "//button[@id='laborPeriods-list-actions']//i";
        private const string NewLaborPeriod = "//*[@role='presentation']//a[text()='New Labor Period']";
        private const string CreateLaborPeriodPage = "//*[@class='page-header']//h3[text()='Create Labor Period']";
        private const string CreateLaborPeriodVerification = "//*[@class='page-header']//h3[text()='{0}']";
        private const string CancelButton = "//*[@class='page-header']//button[text()='Cancel']";
        private const string SaveButton = "//*[@class='page-header']//button[text()='Save']";
        private const string NameInput = "//input[@id='name']";
        private const string LaborPeriodType = "//select[@id='laborPeriodType']";
        private const string TrafficPattern = "//select[@id='trafficPatternType']";
        private const string LaborDistribution = "//select[@id='laborDistributionType']";
        private const string HouseOfOperationVerification = "//*[@class='control-label' and text()='{0}']";
        private const string HouseOfOperationAddButton = "//button//i[@title='Add']";
        private const string LaborPeriodByName = "//*[@role='presentation']//td[@aria-colindex='1' and contains(text(),'{0}')]";
        private const string EditLaborPeriodPage = "//*[@class='page-header']//h3[text()='Edit Labor Period']";
        private const string DeleteButtonLaborPeriod = "//button//i[@title='Delete']";
        private const string ConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string ConfirmButton = "//*[@class='modal-content']//button[text()='Confirm']";
        private const string LaborPeriodFilterInput = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        private const string Name = "Name";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string ClearFilterButton = "//button[@title='Clear All Filters']";
        private const string FormInputFieldErrorXpath = "//span[@class='validation-error help-block' and contains(text(),'{0}')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string AddButton = "//button[@id='add']";
        private const string ExportButton = "//button[@id='laborPeriods-export']";
        private const string ExportLaborPeriods = "//*[contains(@class,'dropdown-menu dropdown-menu-right')]//a[text()='Export Labor Periods']";
        private const string LaborPeriodDeleteButton = "//button//i[@title='Delete']";
        private const string PreviousButton = "//a[.//*[@class='fa fa-caret-left']]";
        private const string LaborPeriodsRecord = "//*[@role='row' and .//*[text()='{0}']]";

        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnKronosTab");
            if (WebDriverUtil.GetWebElement(KronosTab, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            WebDriverUtil.GetWebElement(KronosTab, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnLaborPeriodsTab()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnLaborPeriodsTab");
            if (WebDriverUtil.GetWebElement(LaborPeriodPage, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            WebDriverUtil.GetWebElement(LaborPeriodsTab, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void AddLaborPeriod()
        {
            LogWriter.WriteLog("LaborPeriodsPage.AddLaborPeriod");
            if (WebDriverUtil.GetWebElement(LaborPeriodPage, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            WebDriverUtil.GetWebElement(AddLaborPeriods, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            if (WebDriverUtil.GetWebElement(NewLaborPeriod, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            WebDriverUtil.GetWebElement(NewLaborPeriod, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void CreateLaborPeriodPageVerification(string createLaborPeriod)
        {
            LogWriter.WriteLog("LaborPeriodsPage.CreateLaborPeriodPageVerification");
            var laborPeriodVerification = string.Format(CreateLaborPeriodVerification, createLaborPeriod);
            if (WebDriverUtil.GetWebElement(CreateLaborPeriodPage, WebDriverUtil.ONE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            WebDriverUtil.GetWebElement(laborPeriodVerification,
                WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate Create LaborPeriod Page - {laborPeriodVerification}"
            );
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnCancelButton()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnCancelButton");
            if (WebDriverUtil.GetWebElement(CancelButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            WebDriverUtil.GetWebElement(CancelButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnSaveButton()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnSaveButton");
            if (WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void AddLaborPeriod(Table inputData)
        {
            LogWriter.WriteLog("LaborPeriodsPage.AddLaborPeriod");
            AddLaborPeriod();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create LaborPeriod page - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "LaborPeriodType") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LaborPeriodType, WebDriverUtil.NO_WAIT,
                  $"Unable to locate LaborPeriodType input on create LaborPeriod page - {LaborPeriodType}"
                  )).SelectByText(dictionary["LaborPeriodType"]);
            }
            if (Util.ReadKey(dictionary, "TrafficPattern") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(TrafficPattern, WebDriverUtil.NO_WAIT,
                $"Unable to locate TrafficPattern input on create LaborPeriod page - {TrafficPattern}"))
                    .SelectByText(dictionary["TrafficPattern"]);
            }
            if (Util.ReadKey(dictionary, "LaborDistribution") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LaborDistribution, WebDriverUtil.NO_WAIT,
                 $"Unable to locate LaborDistribution input on create LaborPeriod page - {LaborDistribution}"))
                     .SelectByText(dictionary["LaborDistribution"]);
            }

        }
        public static void VerifyHouseOfOperation(string houseOfOperation)
        {
            LogWriter.WriteLog("LaborPeriodsPage.VerifyHouseOfOperation");
            var houseOfOperationVerification = string.Format(HouseOfOperationVerification, houseOfOperation);
            if (WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            WebDriverUtil.GetWebElement(houseOfOperationVerification, WebDriverUtil.NO_WAIT,
                $"Unable to locate the house of operation - {houseOfOperationVerification}");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddHouseOfOperation()
        {
            LogWriter.WriteLog("LaborPeriodsPage.AddHouseOfOperation");
            if (WebDriverUtil.GetWebElement(HouseOfOperationAddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(HouseOfOperationAddButton,
                WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE).Click();
            }
            if (WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(SaveButton,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate Save Button - {SaveButton}").Click();
            }
        }
        public static void VerifyLaborPeriodByName(string laborPeriod)
        {
            LogWriter.WriteLog("LaborPeriodsPage.VerifyLaborPeriodByName");
            var laborPeriodByName = string.Format(LaborPeriodByName, laborPeriod);
            if (WebDriverUtil.GetWebElement(LaborPeriodPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            WebDriverUtil.GetWebElement(laborPeriodByName, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteLaborPeriod()
        {
            LogWriter.WriteLog("LaborPeriodsPage.DeleteLaborPeriod");
            if (WebDriverUtil.GetWebElement(EditLaborPeriodPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            if (WebDriverUtil.GetWebElement(DeleteButtonLaborPeriod, WebDriverUtil.TWO_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            WebDriverUtil.GetWebElement(DeleteButtonLaborPeriod,
                WebDriverUtil.TEN_SECOND_WAIT,
                $"Unable to locate delete button - {DeleteButtonLaborPeriod}"
            ).Click();
            WebDriverUtil.GetWebElement(ConfirmButton,
                WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate the confirm BUTTON - {ConfirmButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Labor Period Error - {alert.Text}");
            }
        }
        public static void SelectLaborPeriod(string laborPeriods)
        {
            LogWriter.WriteLog("LaborPeriodsPage.SelectLaborPeriod");
            var laborPeriodByName = string.Format(LaborPeriodByName, laborPeriods);
            if (WebDriverUtil.GetWebElement(LaborPeriodPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(laborPeriodByName,
                WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE).Click();
            }
        }
        public static void SearchLaborPeriod(string LaborPeriod)
        {
            LogWriter.WriteLog("LaborPeriodsPage.SearchLaborPeriod");
            var laborPeriodFilterColumnIndex =
                string.Format(LaborPeriodFilterInput, VolumeDriverValuePage.FindColumnIndex(Name));
            if (WebDriverUtil.GetWebElement(LaborPeriodPage, WebDriverUtil.FIVE_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            WebDriverUtil.GetWebElement(laborPeriodFilterColumnIndex, WebDriverUtil.NO_WAIT,
                $"Unable to locate location filter input on LaborPeriod page - {LaborPeriodFilterInput}").SendKeys(LaborPeriod);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClearAllFilter");
            var clearFilterButton = WebDriverUtil.GetWebElement(ClearFilterButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton == null) return;
            clearFilterButton.Click();
            WaitForLoading();
        }
        public static void DeleteRecordIfExist(string record)
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClearAllFilter");
            var laborPeriodName = string.Format(LaborPeriodByName, record);
            SearchLaborPeriod(record);
            if (WebDriverUtil.GetWebElement(laborPeriodName, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                SelectLaborPeriod(record);
                DeleteLaborPeriod();
            }
            else
            {
                ClearAllFilter();
            }
        }
        public static void VerifyAddLaborPeriodErrorMessage(string message)
        {
            LogWriter.WriteLog("LaborPeriodsPage.VerifyAddLaborPeriodErrorMessage");
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null)
            {
                var actualError = errorMessage.Text;
                if (!(actualError.ToLower()).Equals(message.ToLower()))
                    throw new Exception($"We supposed to get error message - {message} but getting - {actualError}");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing LaborPeriodsPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing LaborPeriodsPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportLaborPeriods, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonAndEditOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing LaborPeriodsPage.VerifyDeleteButtonIsNotPresent");
            var deleteButton = WebDriverUtil.GetWebElement(LaborPeriodDeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");

            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("Edit textbox is enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClickOnPreviousLink()
        {
            LogWriter.WriteLog("Executing LaborPeriodsPage.ClickOnPreviousLink");
            WebDriverUtil.GetWebElement(PreviousButton, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate previous button on Labor Period Details page- {PreviousButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }
        public static void AddNewLaborPeriodsWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing LaborPeriodsPage.AddNewLaborPeriodsWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            var laborPeriodXpath = string.Format(LaborPeriodsRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(laborPeriodXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddLaborPeriod(inputData);
                AddHouseOfOperation();
            }
            else
            {
                record.Click();
                ClickOnPreviousLink();
            }

        }
    }
}
