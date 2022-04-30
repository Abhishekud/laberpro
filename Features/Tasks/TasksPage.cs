using LaborPro.Automation.Features.Standards;
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
        const string KRONOS_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        const string TASKS_TAB = "//a[text()='Tasks']";
        const string ADD_BUTTON = "//button[@id='add']";
        const string ADD_TASKS_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@role='dialog']//*[@id='name']";
        const string SAVE_BUTTON = "//button[text()='Save']";
        const string CLOSE_TASKS_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CLOSE_TASKS_DETAILS = "//button[text()='Close']";
        const string TASKS_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string TASKS_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string TASKS_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='1']//input";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string TASKS_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string TASKS_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string TASKSS_PAGE = "//h3[contains(text(),'Tasks')]";
        const string TASKSS_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Task')]";
        const string TIME_DEPENDENT_INPUT = "//select[@id='timeDependency']";
        const string COMBINED_DISTRIBUTION_INPUT = "//input[@id='combinedDistribution']";
        const string TASKGROUPS_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        const string GENERIC_DEPT_INPUT = "//input[@id='genericDepartment']";
        const string TASK_GROUPS_INPUT = "//select[@id='taskGroups']";
        const string NAME = "Name";
        const string TASKS_TABLE_HEADER = "//table[@role='presentation']//th//*[@class='k-link']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";

        public static void AddNewTasksWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing TasksPage.AddTasksWithGivenInputIfNotExist");
            WaitForTasksAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            StandardsPage.ClearAllFilter();
            SearchTasks(dictionary["Name"]);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(TASKS_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewTasksWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }

        public static void DeleteTasksIfExist(string TasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.DeleteTasksIfExist");
            StandardsPage.ClearAllFilter();
            SearchTasks(TasksName);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(TASKS_RECORD, TasksName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedTasks(TasksName);
            }

        }
        public static void CloseTasksDetailSideBar()
        {
            LogWriter.WriteLog("Executing TasksPage.CloseTasksDetailSideBar");
            IWebElement TasksDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_TASKS_DETAILS, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (TasksDetailsSideBar != null)
            {
                TasksDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }

        }
        public static void DeleteCreatedTasks(string TasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.DeleteCreatedTasks");
            CloseTasksDetailSideBar();
            WebDriverUtil.GetWebElement(String.Format(TASKS_RECORD, TasksName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate Tasks record on Taskss page - {0}", String.Format(TASKS_RECORD, TasksName))).Click();
            WebDriverUtil.GetWebElement(String.Format(TASKS_DELETE_BUTTON, TasksName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate Tasks delete button on Tasks details - {0}", String.Format(
                TASKS_DELETE_BUTTON, TasksName))).Click();
           WebDriverUtil.GetWebElement(TASKS_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                   String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", TASKS_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(TASKS_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Task Error - {0}", alert.Text));
            }
         }
        public static void SearchTasks(String TasksName)  
        {
            LogWriter.WriteLog("Executing TasksPage.SearchTasks");
            WebDriverUtil.GetWebElement(String.Format(TASKGROUPS_FILTER_INPUT, FindColumnIndexInTasks(NAME)), WebDriverUtil.NO_WAIT,
                 String.Format("Unable to locate TaskGroups filter input on TaskGroups page - {0}", TASKS_FILTER_INPUT)).SendKeys(TasksName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static int FindColumnIndexInTasks(string headername)
        {
            LogWriter.WriteLog("Executing TasksPage.FindColumnIndexInTasks");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TASKS_TABLE_HEADER));
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
        public static void VerifyCreatedTasks(string TasksName)
        {
            LogWriter.WriteLog("Executing TasksPage.VerifyCreatedTasks");
            StandardsPage.ClearAllFilter();
            SearchTasks(TasksName);
            WebDriverUtil.GetWebElement(String.Format(TASKS_RECORD, TasksName), WebDriverUtil.FIVE_SECOND_WAIT,
            String.Format("Unable to locate record Taskss page - {0}", String.Format(TASKS_RECORD, TasksName)));
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing TasksPage.VerifyCreatedTasks");
            WebDriverUtil.GetWebElement(TASKSS_POPUP, WebDriverUtil.NO_WAIT, String.Format("Unable to locate AddMenuPopup"));
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void DeleteCreatedTaskGroups(string TaskGroupsName)
        {
            LogWriter.WriteLog("Executing TasksPage.DeleteCreatedTaskGroups");
            StandardsPage.ClearAllFilter();
            TaskGroupsPage.SearchTaskGroups(TaskGroupsName);
            TaskGroupsPage.DeleteCreatedTaskGroups(TaskGroupsName);
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
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input Taskss page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Time Dependency") != null)
            {
                WebDriverUtil.WaitFor(1);
                new SelectElement( WebDriverUtil.GetWebElement(TIME_DEPENDENT_INPUT, WebDriverUtil.FIVE_SECOND_WAIT,
                String.Format("Unable to locate Time Dependency input on create Tasks  page - {0}", TIME_DEPENDENT_INPUT)))
                    .SelectByText(dictionary["Time Dependency"]);
               
            }

            if (Util.ReadKey(dictionary, "Combined Distribution") != null)
            {
                WebDriverUtil.GetWebElement(COMBINED_DISTRIBUTION_INPUT, WebDriverUtil.TEN_SECOND_WAIT,
                String.Format("Unable to locate Combined Distribution input on create Tasks  page - {0}", COMBINED_DISTRIBUTION_INPUT))
                    .SendKeys(dictionary["Combined Distribution"]);
            } 
            if (Util.ReadKey(dictionary, "Generic Department") != null)
            {
                WebDriverUtil.GetWebElement(GENERIC_DEPT_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate generic dept input on create  Tasks page - {0}", GENERIC_DEPT_INPUT))
                    .SendKeys(dictionary["Generic Department"]);
            }
            if (Util.ReadKey(dictionary, "TaskGroups") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement( TASK_GROUPS_INPUT, WebDriverUtil.FIVE_SECOND_WAIT,
               String.Format("Unable to locate TaskGroups input on create Tasks  page - {0}", TASK_GROUPS_INPUT)))
                   .SelectByText(dictionary["TaskGroups"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.FIVE_SECOND_WAIT,
            String.Format("Unable to locate save button on page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(TASKSS_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(TASKSS_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Task Error - {0}", alert.Text));
                        }
                    }
                }
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
            WebDriverUtil.GetWebElement(ADD_TASKS_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewTasksMenu menu link on add menu popup - {0}", ADD_TASKS_LINK)).Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing TasksPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button Taskss page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseTasksForm()
        {
            LogWriter.WriteLog("Executing TasksPage.CloseTasksForm");
            WaitForTasksAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_TASKS_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnTasksTab()
        {
            LogWriter.WriteLog("Executing TasksPage.ClickOnTasksTab");
           if (WebDriverUtil.GetWebElement(TASKSS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(TASKS_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("Executing TasksPage.ClickOnKronosTab");
            IWebElement Kronostab = WebDriverUtil.GetWebElement(KRONOS_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (Kronostab != null)
            {
                Kronostab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForTasksAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing TasksPage.WaitForTasksAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);

            }
            WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

