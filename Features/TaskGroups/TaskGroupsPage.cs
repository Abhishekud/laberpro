using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.TaskGroups
{
    public class TaskGroupsPage
    {
        const string KRONOS_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        const string TASKGROUPS_TAB = "//a[text()='Task Groups']";
        const string ADD_BUTTON = "//button[@id='add']";
        const string ADD_TASKGROUPS_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@role='dialog']//*[@id='name']";
        const string SAVE_BUTTON = "//button[text()='Save']";
        const string CLOSE_TASKGROUPS_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CLOSE_TASKGROUPS_DETAILS = "//button[text()='Close']";
        const string TASKGROUPS_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string TASKGROUPS_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string TASKGROUPS_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string TASKGROUPS_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string TASKGROUPS_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string TASKGROUPSS_PAGE = "//h3[contains(text(),'Task Groups')]";
        const string TASKGROUPSS_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New TaskGroup')]";
        const string ALLOCATE_LABOR_HOUR_TYPE_INPUT = "  //select[@id='allocateLaborHours']";
        const string COMBINED_DISTRIBUTION_INPUT = "//input[@id='combinedDistribution']";
        const string GENERIC_DEPT_INPUT = "//input[@id='genericDepartment']";
        const string JOB_INPUT = "//input[@id='jobName']";
        const string NAME = "Name";
        const string TASKGROUPS_TABLE_HEADER = "//table[@role='presentation']//th//*[@class='k-link']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string CLEAR_FILTER_BUTTON = "//button[@title='Clear All Filters']";
        private const string TaskGroupsRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string TaskGroupsDeleteButton = "//button[contains(@class,'delete')]";
        private const string ExportButton = "//button[@id='export']";
        private const string AddButton = "//button[@id='add']";
        private const string ExportTaskGroups = "//*[contains(@class,'dropdown-menu dropdown-menu-right')]//a[text()='Export Task Groups']";
        private const string NameInput = "//*[@id='name']";
        public static void AddNewTaskGroupsWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.AddTaskGroupsWithGivenInputIfNotExist");
            WaitForTaskGroupsAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            ClearAllFilter();
            SearchTaskGroups(dictionary["Name"]);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(TASKGROUPS_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewTaskGroupsWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void DeleteTaskGroupsIfExist(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.DeleteTaskGroupsIfExist");
            ClearAllFilter();
            SearchTaskGroups(taskGroupsName);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(TASKGROUPS_RECORD, taskGroupsName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedTaskGroups(taskGroupsName);
            }

        }
        public static void CloseTaskGroupsDetailSideBar()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.CloseTaskGroupsDetailSideBar");
            IWebElement TaskGroupsDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_TASKGROUPS_DETAILS, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (TaskGroupsDetailsSideBar != null)
            {
                TaskGroupsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }

        }
        public static void DeleteCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.DeleteCreatedTaskGroups");
            CloseTaskGroupsDetailSideBar();
            WebDriverUtil.GetWebElement(String.Format(TASKGROUPS_RECORD, taskGroupsName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate TaskGroups record on TaskGroupss page - {0}", String.Format(TASKGROUPS_RECORD, taskGroupsName))).Click();


            WebDriverUtil.GetWebElement(String.Format(TASKGROUPS_DELETE_BUTTON, taskGroupsName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate TaskGroups delete button on TaskGroups details - {0}", String.Format(
                TASKGROUPS_DELETE_BUTTON, taskGroupsName))).Click();
            WebDriverUtil.GetWebElement(TASKGROUPS_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", TASKGROUPS_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(TASKGROUPS_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Task Group Error - {0}", alert.Text));
            }

        }
        public static void SearchTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.SearchTaskGroups");
            WebDriverUtil.GetWebElement(String.Format(TASKGROUPS_FILTER_INPUT, FindColumnIndexInTaskGroups(NAME)), WebDriverUtil.NO_WAIT,
                         String.Format("Unable to locate filter input on TaskGroups page - {0}", TASKGROUPS_FILTER_INPUT)).SendKeys(taskGroupsName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static int FindColumnIndexInTaskGroups(string headername)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.FindColumnIndexInTaskGroups");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TASKGROUPS_TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                if (headername.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }
            return index;
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClearAllFilter");

            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(CLEAR_FILTER_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
        public static void VerifyCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyCreatedTaskGroups");
            ClearAllFilter();
            SearchTaskGroups(taskGroupsName);
            WebDriverUtil.GetWebElement(String.Format(TASKGROUPS_RECORD, taskGroupsName), WebDriverUtil.FIVE_SECOND_WAIT,
            String.Format("Unable to locate record TaskGroupss page - {0}", String.Format(TASKGROUPS_RECORD, taskGroupsName)));
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyCreatedTaskGroups");
            WebDriverUtil.GetWebElement(TASKGROUPSS_POPUP, WebDriverUtil.NO_WAIT, String.Format("Unable to locate AddMenuPopup"));
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
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input TaskGroupss page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Allocate Labor Hours") != null)
            {
                WebDriverUtil.WaitFor(1);
                new SelectElement(WebDriverUtil.GetWebElement(ALLOCATE_LABOR_HOUR_TYPE_INPUT, WebDriverUtil.FIVE_SECOND_WAIT,
                String.Format("Unable to locate Allocate Labor Hours input on create TaskGroups  page - {0}", ALLOCATE_LABOR_HOUR_TYPE_INPUT)))
                    .SelectByText(dictionary["Allocate Labor Hours"]);
            }

            if (Util.ReadKey(dictionary, "Combined Distribution") != null)
            {
                WebDriverUtil.GetWebElement(COMBINED_DISTRIBUTION_INPUT, WebDriverUtil.FIVE_SECOND_WAIT,
                String.Format("Unable to locate Combined Distribution input on create TaskGroups  page - {0}", COMBINED_DISTRIBUTION_INPUT))
                    .SendKeys(dictionary["Combined Distribution"]);
            }
            if (Util.ReadKey(dictionary, "Generic Department") != null)
            {
                WebDriverUtil.GetWebElement(GENERIC_DEPT_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate generic dept input on create  TaskGroups page - {0}", GENERIC_DEPT_INPUT))
                    .SendKeys(dictionary["Generic Department"]);
            }
            if (Util.ReadKey(dictionary, "Job Name") != null)
            {
                WebDriverUtil.GetWebElement(JOB_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Job Name input on create  TaskGroups page - {0}", JOB_INPUT))
                    .SendKeys(dictionary["Job Name"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.FIVE_SECOND_WAIT,
            String.Format("Unable to locate save button on page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(TASKGROUPSS_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(TASKGROUPSS_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new TaskGroups Error - {0}", alert.Text));
                        }
                    }
                }
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
            WebDriverUtil.GetWebElement(ADD_TASKGROUPS_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewTaskGroupsMenu menu link on add menu popup - {0}", ADD_TASKGROUPS_LINK)).Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button TaskGroupss page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseTaskGroupsForm()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.CloseTaskGroupsForm");
            WaitForTaskGroupsAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_TASKGROUPS_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnTaskGroupsTab()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClickOnTaskGroupsTab");
            if (WebDriverUtil.GetWebElement(TASKGROUPSS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(TASKGROUPS_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.ClickOnKronosTab");
            IWebElement Kronostab = WebDriverUtil.GetWebElement(KRONOS_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (Kronostab != null)
            {
                Kronostab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForTaskGroupsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.WaitForTaskGroupsAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);

            }
            WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportTaskGroups, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export Option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing TaskGroupsPage.VerifyDeleteButtonIsNotPresent");
            ClearAllFilter();
            SearchTaskGroups(taskGroupsName);
            var taskGroupRecordXpath = string.Format(TaskGroupsRecord, taskGroupsName);
            WebDriverUtil.GetWebElement(taskGroupRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate TaskGroups record on TaskGroups page - {taskGroupRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(TaskGroupsDeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("delete button is found but we expect it should not be present when user login from view only access");

            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
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

    }
}
