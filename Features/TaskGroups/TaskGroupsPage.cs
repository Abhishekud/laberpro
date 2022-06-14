using LaborPro.Automation.Features.Standards;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.TaskGroups
{
    public class TaskGroupsPage
    {
        private const string CollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        private const string TaskGroupsTab = "//a[text()='Task Groups']";
        private const string AddButton = "//button[@id='add']";
        private const string AddTaskGroupsLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[text()='Save']";
        private const string CloseTaskGroupsFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseTaskGroupsDetails = "//button[text()='Close']";
        private const string TaskGroupsDeleteButton = "//button[contains(@class,'delete')]";
        private const string TaskGroupsRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string TaskGroupsFilterInput = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string TaskGroupsDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string TaskGroupsDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string TaskGroupsPages = "//h3[contains(text(),'Task Groups')]";
        private const string TaskGroupsPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New TaskGroup')]";
        private const string AllocateLaborHourTypeInput = "  //select[@id='allocateLaborHours']";
        private const string CombinedDistributionInput = "//input[@id='combinedDistribution']";
        private const string GenericDeptInput = "//input[@id='genericDepartment']";
        private const string JobInput = "//input[@id='jobName']";
        private const string Name = "Name";
        private const string TaskGroupsTableHeader = "//table[@role='presentation']//th//*[@class='k-link']";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ClearFilterButton = "//button[@title='Clear All Filters']";
        private const string ExportButton = "//button[@id='export']";
        private const string ExportTaskGroups = "//*[contains(@class,'dropdown-menu dropdown-menu-right')]//a[text()='Export Task Groups']";
    
        public static void AddNewTaskGroupsWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.AddTaskGroupsWithGivenInputIfNotExist");
            WaitForTaskGroupsAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            StandardsPage.ClearAllFilter();
            SearchTaskGroups(dictionary["Name"]);
            var taskGroupRecordXpath = string.Format(TaskGroupsRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(taskGroupRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewTaskGroupsWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
             var exportButton = WebDriverUtil.GetWebElement( ExportTaskGroups, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export Option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyDeleteButtonIsNotPresent");
            StandardsPage.ClearAllFilter();
            SearchTaskGroups(taskGroupsName);
            var taskGroupRecordXpath = string.Format(TaskGroupsRecord, taskGroupsName);
            WebDriverUtil.GetWebElement(taskGroupRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate TaskGroups record on TaskGroups page - {taskGroupRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(TaskGroupsDeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("delete button is found but we expect it should not be present when user login from view only access");

            var editTextBox = WebDriverUtil.GetWebElement(NameInput , WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("edit TextBox is Enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
       
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteTaskGroupsIfExist(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.DeleteTaskGroupsIfExist");
            StandardsPage.ClearAllFilter();
            SearchTaskGroups(taskGroupsName);
            var taskGroupRecordXpath = string.Format(TaskGroupsRecord, taskGroupsName);
             var record = WebDriverUtil.GetWebElementAndScroll(taskGroupRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedTaskGroups(taskGroupsName);
            }

        }
        public static void CloseTaskGroupsDetailSideBar()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.CloseTaskGroupsDetailSideBar");
            var taskGroupsDetailsSideBar = WebDriverUtil.GetWebElement(CloseTaskGroupsDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (taskGroupsDetailsSideBar == null) return;
            taskGroupsDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }

        public static void DeleteCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.DeleteCreatedTaskGroups");
            CloseTaskGroupsDetailSideBar();
            var taskGroupRecordXpath = string.Format(TaskGroupsRecord, taskGroupsName);
            WebDriverUtil.GetWebElement(taskGroupRecordXpath, WebDriverUtil.NO_WAIT,
            $"Unable to locate TaskGroups record on TaskGroups page - {taskGroupRecordXpath}").Click();

            WebDriverUtil.GetWebElement( TaskGroupsDeleteButton , WebDriverUtil.FIVE_SECOND_WAIT,
            $"Unable to locate TaskGroups delete button on TaskGroups details - {TaskGroupsDeleteButton}").Click();

            WebDriverUtil.GetWebElement(TaskGroupsDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {TaskGroupsDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(TaskGroupsDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception( $"Unable to delete Task Group Error - {alert.Text}");
            }

        }
        public static void SearchTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.SearchTaskGroups");
            WebDriverUtil.GetWebElement(String.Format(TaskGroupsFilterInput, FindColumnIndexInTaskGroups(Name)), WebDriverUtil.NO_WAIT,
                         $"Unable to locate filter input on TaskGroups page - {TaskGroupsFilterInput}").SendKeys(taskGroupsName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static int FindColumnIndexInTaskGroups(string headerName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.FindColumnIndexInTaskGroups");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TaskGroupsTableHeader));
            var index = 0;
            foreach (var header in headers)
            {
                index++;
                if (headerName.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }
            return index;
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClearAllFilter");

            var clearFilterButton = WebDriverUtil.GetWebElement(ClearFilterButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton == null) return;
            clearFilterButton.Click();
            WaitForLoading();
        }
        public static void VerifyCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyCreatedTaskGroups");
            ClearAllFilter();
            SearchTaskGroups(taskGroupsName);
            var taskGroupRecordXpath = string.Format(TaskGroupsRecord, taskGroupsName);
            WebDriverUtil.GetWebElement(taskGroupRecordXpath, WebDriverUtil.FIVE_SECOND_WAIT,
            $"Unable to locate record TaskGroups page - {taskGroupRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            

        }
        public static void VerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyCreatedTaskGroups");
            WebDriverUtil.GetWebElement(TaskGroupsPopup, WebDriverUtil.NO_WAIT, $"Unable to locate AddMenuPopup - {TaskGroupsPopup}");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddNewTaskGroupsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.AddNewTaskGroupsWithGivenInput");
            CloseTaskGroupsDetailSideBar();
            ClickOnAddButton();
            UserClickOnNewTaskGroupsMenuLink();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input TaskGroups page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Allocate Labor Hours") != null)
            {
                WebDriverUtil.WaitFor(1);
                new SelectElement(WebDriverUtil.GetWebElement(AllocateLaborHourTypeInput, WebDriverUtil.FIVE_SECOND_WAIT,
                $"Unable to locate Allocate Labor Hours input on create TaskGroups  page - {AllocateLaborHourTypeInput}" ))
                    .SelectByText(dictionary["Allocate Labor Hours"]);
            }

            if (Util.ReadKey(dictionary, "Combined Distribution") != null)
            {
                WebDriverUtil.GetWebElement(CombinedDistributionInput, WebDriverUtil.FIVE_SECOND_WAIT,
                $"Unable to locate Combined Distribution input on create TaskGroups  page - {CombinedDistributionInput}")
                    .SendKeys(dictionary["Combined Distribution"]);
            }
            if (Util.ReadKey(dictionary, "Generic Department") != null)
            {
                WebDriverUtil.GetWebElement(GenericDeptInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate generic dept input on create  TaskGroups page - {GenericDeptInput}")
                    .SendKeys(dictionary["Generic Department"]);
            }
            if (Util.ReadKey(dictionary, "Job Name") != null)
            {
                WebDriverUtil.GetWebElement(JobInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Job Name input on create  TaskGroups page - {JobInput}")
                    .SendKeys(dictionary["Job Name"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.FIVE_SECOND_WAIT,
            $"Unable to locate save button on page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(TaskGroupsPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(TaskGroupsPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new TaskGroups Error - {alert.Text}");
            }


        }
        public static void UserClickAddTaskGroupsButton()
        {
            ClickOnAddButton();
            UserClickOnNewTaskGroupsMenuLink();
        }
        public static void UserClickOnNewTaskGroupsMenuLink()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.UserClickOnNewTaskGroupsMenuLink");
            WebDriverUtil.GetWebElement(AddTaskGroupsLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate NewTaskGroupsMenu menu link on add menu popup - {AddTaskGroupsLink}").Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button TaskGroups page  - {AddButton}").Click();

        }
        public static void CloseTaskGroupsForm()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.CloseTaskGroupsForm");
            WaitForTaskGroupsAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseTaskGroupsFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnTaskGroupsTab()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClickOnTaskGroupsTab");
            if (WebDriverUtil.GetWebElement(TaskGroupsPages, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            WebDriverUtil.GetWebElement(TaskGroupsTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClickOnKronosTab");
            var kronosTab = WebDriverUtil.GetWebElement(CollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (kronosTab == null) return;
            kronosTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForTaskGroupsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.WaitForTaskGroupsAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
                var nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);

            }
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

