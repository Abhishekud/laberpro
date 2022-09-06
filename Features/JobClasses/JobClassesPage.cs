using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util; 

namespace LaborPro.Automation.Features.JobClasses
{
    public class JobClassesPage
    {
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string AddButton = "//button[@id='add']";
        private const string AddJobClassesLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseJobClassesFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseJobClassesDetails = "//button[text()='Close']";
        private const string CancelJobClassesDetails = "//button[contains(@class, 'cancel')]";
        private const string JobClassesDeleteButton = "//button[contains(@class,'delete')]";
        private const string JobClassesRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string JobClassesDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string JobClassesDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string JobClassesPageTitle = " //*[@class='page-title' and contains(text(),'Job Classes')]";
        private const string JobClassesPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Job Class')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ListManagementTab = "//a[text()='List Management']";
        private const string ListManagementDropdown = "//select[@id='standardFilingFieldId']";
        private const string JobClassesValueInLmDropdown = "//select[@id='standardFilingFieldId']//option[@value='JOB_CLASSES']";
        private const string ExportButton = "//button[@id='export']";

        public static void DeleteJobClassesIfExist(string jobClassesName)
        {
            LogWriter.WriteLog("Executing  JobClassesPage.DeleteJobClassesIfExist");
            WaitForJobClassesAlertCloseIfAny();
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(JobClassesRecord, jobClassesName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedJobClasses(jobClassesName);
            }
        } 
        public static void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing JobClassesPage.VerifyExportOptionIsNotPresent"); 
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton != null)
                throw new Exception("Export Option is found but we expect it should not be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
           }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing JobClassesPage.ClickOnListManagementTab");
            if (WebDriverUtil.GetWebElement(JobClassesPageTitle, WebDriverUtil.NO_WAIT,
                    WebDriverUtil.NO_MESSAGE) != null) return;
            WebDriverUtil.GetWebElement(ListManagementTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void CloseJobClassesDetailSideBar()
        {
            LogWriter.WriteLog("Executing JobClassesPage CloseJobClassesDetailSideBar()");
            var jobClassesDetailsSideBar = WebDriverUtil.GetWebElement(CloseJobClassesDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (jobClassesDetailsSideBar != null)
            {
                jobClassesDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            jobClassesDetailsSideBar = WebDriverUtil.GetWebElement(CancelJobClassesDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (jobClassesDetailsSideBar == null) return;
            jobClassesDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        
        public static void DeleteCreatedJobClasses(string jobClassesName)
        {
            LogWriter.WriteLog("Executing JobClassesPage DeleteCreatedJobClasses");
            var jobClassesRecordXpath = string.Format(JobClassesRecord, jobClassesName);
            WebDriverUtil.GetWebElement(jobClassesRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate JobClasses record on JobClasses page - {jobClassesRecordXpath}").Click();

            var jobClassesDeleteButtonXpath = string.Format(JobClassesDeleteButton, jobClassesName);
            WebDriverUtil.GetWebElement(jobClassesDeleteButtonXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate JobClasses delete button on JobClasses details - {jobClassesDeleteButtonXpath}").Click();


            var confirmationPopup = WebDriverUtil.GetWebElement(JobClassesDeleteConfirmPopup, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup == null) return;
            WebDriverUtil.GetWebElement(JobClassesDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {JobClassesDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(JobClassesDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete JobClasses Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedJobClasses(string jobClassesName)
        {
            LogWriter.WriteLog("Executing JobClassesPage VerifyCreatedJobClasses");
            var jobClassesRecordXpath = string.Format(JobClassesRecord, jobClassesName);
            WebDriverUtil.GetWebElement(jobClassesRecordXpath, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record on JobClasses page - {jobClassesRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            CloseJobClassesDetailSideBar();
        }

        public static void FindJobClassesByName(string jobClassesName)
        {
            LogWriter.WriteLog("Executing JobClassesPage FindJobClassesByName");
            var jobClassesRecordXpath = string.Format(JobClassesRecord, jobClassesName);
            WebDriverUtil.GetWebElement(jobClassesRecordXpath, WebDriverUtil.DEFAULT_WAIT,
                $"Unable to locate record on JobClasses page - {jobClassesRecordXpath}").Click();
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing JobClassesPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add Button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing JobClassesPage.VerifyDeleteButtonIsNotPresent");
            var deleteButton = WebDriverUtil.GetWebElement(JobClassesDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete Button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value=true;
        }

        public static void AddNewJobClassesWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing JobClassesPage AddNewJobClassesWithGivenInputIfNotExist");
            WaitForJobClassesAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            var jobClassesRecordXpath = string.Format(JobClassesRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(jobClassesRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewJobClassesWithGivenInput(inputData);
            }
        }

        public static void AddNewJobClassesWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing JobClassesPage AddNewJobClassesWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewJobClassesMenuLink();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on JobClasses page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on JobClasses page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(JobClassesPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(JobClassesPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new JobClasses Error - {alert.Text}");
            }
        }
        public static void UserClickOnNewJobClassesMenuLink()
        {
            LogWriter.WriteLog("Executing JobClassesPage UserClickOnNewJobClassesMenuLink");
            WebDriverUtil.GetWebElement(AddJobClassesLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate NewJobClassesMenu menu link on add menu popup - {AddJobClassesLink}").Click();
        }
      
        
        public static void ClickOnJobClasses()
        {
            LogWriter.WriteLog("Executing JobClassesPage ClickOnJobClasses");
            WebDriverUtil.GetWebElement(ListManagementDropdown,
                WebDriverUtil.NO_WAIT, $"Unable to locate list management dropdown - {ListManagementDropdown}").Click();
            WebDriverUtil.GetWebElement(JobClassesValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate JobClasses value - {JobClassesValueInLmDropdown}").Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing JobClassesPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on JobClasses page  - {AddButton}").Click();

        }
        public static void CloseJobClassesForm()
        {
            LogWriter.WriteLog("Executing JobClassesPage CloseJobClassesForm");
            WaitForJobClassesAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseJobClassesFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing JobClassesPage ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null) return;
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForJobClassesAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing JobClassesPage WaitForJobClassesAlertCloseIfAny ");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
            WebDriverUtil.GetWebElementAndScroll(NameInput);
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

