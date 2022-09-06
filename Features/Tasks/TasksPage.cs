using LaborPro.Automation.Features.TaskGroups;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Tasks
{
    public class TasksPage
    {
        private const string CollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        private const string TasksTab = "//a[text()='Tasks']";
        private const string AddTasksLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[text()='Save']";
        private const string CloseTasksFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseTasksDetails = "//button[text()='Close']";
        private const string TasksDeleteButton = "//button[contains(@class,'delete')]";
        private const string TasksRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string TasksFilterInput = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string TasksDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string TasksDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string TasksPages = "//h3[contains(text(),'Tasks')]";
        private const string TasksPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Task')]";
        private const string TimeDependentInput = "//select[@id='timeDependency']";
        private const string CombinedDistributionInput = "//input[@id='combinedDistribution']";
        private const string GenericDeptInput = "//input[@id='genericDepartment']";
        private const string TaskGroupsInput = "//select[@id='taskGroups']";
        private const string Name = "Name";
        private const string TasksTableHeader = "//table[@role='presentation']//th//*[@class='k-link']";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ExportButton = "//button[@id='export']";
        private const string ExportTasks = "//*[contains(@class,'dropdown-menu dropdown-menu-right')]//a[text()='Export Tasks']";
        private const string AddButton = "//button[@id='add']";
        private const string ClearFilterButton = "//button[@title='Clear All Filters']";

        public static void AddNewTasksWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing TasksPage.AddNewTasksWithGivenInputIfNotExist");
            WaitForTasksAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            ClearAllFilter();
            SearchTasks(dictionary["Name"]);
            var taskRecordXpath = string.Format(TasksRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(taskRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewTasksWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void DeleteTasksIfExist(string tasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.DeleteTasksIfExist");
            ClearAllFilter();
            SearchTasks(tasksName);
            var taskRecordXpath = string.Format(TasksRecord, tasksName);
            var record = WebDriverUtil.GetWebElementAndScroll(taskRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedTasks(tasksName);
            }

        }
        public static void CloseTasksDetailSideBar()
        {
            LogWriter.WriteLog("Executing TasksPage.CloseTasksDetailSideBar");
            var tasksDetailsSideBar = WebDriverUtil.GetWebElement(CloseTasksDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (tasksDetailsSideBar == null) return;
            tasksDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }
        public static void DeleteCreatedTasks(string tasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.DeleteCreatedTasks");
            CloseTasksDetailSideBar();
            var taskRecordXpath = string.Format(TasksRecord, tasksName);
            WebDriverUtil.GetWebElement(taskRecordXpath, WebDriverUtil.NO_WAIT,
            $"Unable to locate Tasks record on Tasks page - {taskRecordXpath}").Click();
            WebDriverUtil.GetWebElement(TasksDeleteButton, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate Tasks delete button on Tasks details page - {TasksDeleteButton}").Click();
            WebDriverUtil.GetWebElement(TasksDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                    $"Unable to locate Confirm button on delete confirmation popup - {TasksDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(TasksDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Task Error - {alert.Text}");
            }
        }
        public static void SearchTasks(string tasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.SearchTasks");
            WebDriverUtil.GetWebElement(string.Format(TasksFilterInput, FindColumnIndexInTasks(Name)), WebDriverUtil.NO_WAIT,
                 $"Unable to locate Tasks filter input on Tasks page - {TasksFilterInput}").SendKeys(tasksName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static int FindColumnIndexInTasks(string headerName)
        {
            LogWriter.WriteLog("Executing TasksPage.FindColumnIndexInTasks");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TasksTableHeader));
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
        public static void VerifyCreatedTasks(string tasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.VerifyCreatedTasks");
            ClearAllFilter();
            SearchTasks(tasksName);
            var taskRecordXpath = string.Format(TasksRecord, tasksName);
            WebDriverUtil.GetWebElement(taskRecordXpath, WebDriverUtil.FIVE_SECOND_WAIT,
            $"Unable to locate record on Tasks page - {taskRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing TasksPage.VerifyAddMenuPopup");
            WebDriverUtil.GetWebElement(TasksPopup, WebDriverUtil.NO_WAIT, $"Unable to locate Add Menu Popup - {TasksPopup}");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void DeleteCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TasksPage.DeleteCreatedTaskGroups");
            ClearAllFilter();
            TaskGroupsPage.SearchTaskGroups(taskGroupsName);
            TaskGroupsPage.DeleteCreatedTaskGroups(taskGroupsName);
        }
        public static void AddNewTasksWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing TasksPage.AddNewTasksWithGivenInput");
            CloseTasksDetailSideBar();
            ClickOnAddButton();
            UserClickOnNewTasksMenuLink();

            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on create Tasks page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Time Dependency") != null)
            {
                WebDriverUtil.WaitFor(1);
                new SelectElement(WebDriverUtil.GetWebElement(TimeDependentInput, WebDriverUtil.FIVE_SECOND_WAIT,
                $"Unable to locate Time Dependency input on create Tasks page - {TimeDependentInput}"))
                    .SelectByText(dictionary["Time Dependency"]);

            }

            if (Util.ReadKey(dictionary, "Combined Distribution") != null)
            {
                WebDriverUtil.GetWebElement(CombinedDistributionInput, WebDriverUtil.TEN_SECOND_WAIT,
                $"Unable to locate Combined Distribution input on create Tasks page - {CombinedDistributionInput}")
                    .SendKeys(dictionary["Combined Distribution"]);
            }
            if (Util.ReadKey(dictionary, "Generic Department") != null)
            {
                WebDriverUtil.GetWebElement(GenericDeptInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Generic Department input on create Tasks page - {GenericDeptInput}")
                    .SendKeys(dictionary["Generic Department"]);
            }
            if (Util.ReadKey(dictionary, "TaskGroups") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(TaskGroupsInput, WebDriverUtil.FIVE_SECOND_WAIT,
               $"Unable to locate TaskGroups input on create Tasks page - {TaskGroupsInput}"))
                   .SelectByText(dictionary["TaskGroups"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.FIVE_SECOND_WAIT,
            $"Unable to locate save button on page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(TasksPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(TasksPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new Task Error - {alert.Text}");
            }

        }
        public static void UserClickAddTasksButton()
        {
            ClickOnAddButton();
            UserClickOnNewTasksMenuLink();
        }
        public static void UserClickOnNewTasksMenuLink()
        {

            LogWriter.WriteLog("Executing TasksPage.UserClickOnNewTasksMenuLink");
            WebDriverUtil.GetWebElement(AddTasksLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new Tasks menu link on add menu popup - {AddTasksLink}").Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing TasksPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Tasks page  - {AddButton}").Click();

        }
        public static void CloseTasksForm()
        {
            LogWriter.WriteLog("Executing TasksPage.CloseTasksForm");
            WaitForTasksAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseTasksFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnTasksTab()
        {
            LogWriter.WriteLog("Executing TasksPage.ClickOnTasksTab");
            if (WebDriverUtil.GetWebElement(TasksPages, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            WebDriverUtil.GetWebElement(TasksTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("Executing TasksPage.ClickOnKronosTab");
            var kronosTab = WebDriverUtil.GetWebElement(CollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (kronosTab == null) return;
            kronosTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForTasksAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing TasksPage.WaitForTasksAlertCloseIfAny");
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
            LogWriter.WriteLog("Executing TasksPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportTasks, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string tasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.VerifyDeleteButtonIsNotPresent");
            ClearAllFilter();
            SearchTasks(tasksName);
            var taskRecordXpath = string.Format(TasksRecord, tasksName);
            WebDriverUtil.GetWebElement(taskRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate Tasks record on Tasks page - {taskRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(TasksDeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);

            if (deleteButton != null)
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("Edit TextBox is enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing TasksPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing TasksPage.ClearAllFilter");
            var clearFilterButton = WebDriverUtil.GetWebElement(ClearFilterButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton == null) return;
            clearFilterButton.Click();
            WaitForLoading();
        }
    }
}

