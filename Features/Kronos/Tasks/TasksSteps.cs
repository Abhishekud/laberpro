using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Kronos.Tasks
{
    [Binding]
    public class TasksSteps
    {

        [When(@"User navigates to the Tasks tab")]
        [Given(@"User navigates to the Tasks tab")]
        [Then(@"User navigates to the Tasks tab")]
        public void UserNavigatesToTheTasksTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the Tasks tab");
            TasksPage.CloseTasksForm();
            TasksPage.ClickOnKronosTab();
            TasksPage.ClickOnTasksTab();

        }
        [Given(@"User create new Tasks with below input if not exist")]
        [When(@"User create new Tasks with below input if not exist")]
        [Then(@"User create new Tasks with below input if not exist")]
        public void AddNewTasksWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User create new Tasks with below input if not exist - " + inputData);
            TasksPage.AddNewTasksWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User create new Tasks with below input")]
        [When(@"User create new Tasks with below input")]
        [Then(@"User create new Tasks with below input")]
        public void AddNewTasksWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Tasks with below input " + inputData);
            TasksPage.AddNewTasksWithGivenInput(inputData);
        }

        [Given(@"User clicks Add Tasks Button")]
        [When(@"User clicks Add Tasks Button")]
        [Then(@"User clicks Add Tasks Button")]
        public void UserClickAddTasksButton()
        {
            LogWriter.WriteLog("Executing Step User clicks Add Tasks Button");
            TasksPage.UserClickAddTasksButton();
        }

        [Given(@"User verify created Tasks ""([^""]*)""")]
        [When(@"User verify created Tasks ""([^""]*)""")]
        [Then(@"User verify created Tasks ""([^""]*)""")]
        public void UserVerifyCreatedTasks(string tasksName)
        {
            LogWriter.WriteLog("Executing Step User verify created Tasks by name" + tasksName);
            TasksPage.VerifyCreatedTasks(tasksName);
            TasksPage.CloseTasksDetailSideBar();
        }

        [Given(@"User verify Add Menu Tasks Popup")]
        [When(@"User verify Add Menu Tasks Popup")]
        [Then(@"User verify Add Menu Tasks Popup")]
        public void UserVerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing Step User verify Add Menu Tasks Popup");
            TasksPage.VerifyAddMenuPopup();
        }

        [Given(@"User delete created Tasks ""([^""]*)""")]
        [When(@"User delete created Tasks ""([^""]*)""")]
        [Then(@"User delete created Tasks ""([^""]*)""")]
        public void UserDeleteCreatedTasks(string tasksName)
        {
            LogWriter.WriteLog("Executing Step User delete created Tasks by name" + tasksName);
            TasksPage.DeleteCreatedTasks(tasksName);
        }

        [Given(@"User delete created TaskGroups by name ""([^""]*)""")]
        [When(@"User delete created TaskGroups by name ""([^""]*)""")]
        [Then(@"User delete created TaskGroups by name ""([^""]*)""")]
        public void UserDeleteCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User delete created TaskGroups by name" + taskGroupsName);
            TasksPage.DeleteCreatedTaskGroups(taskGroupsName);
        }

        [Given(@"User delete Tasks ""([^""]*)"" if exist")]
        [When(@"User delete Tasks ""([^""]*)"" if exist")]
        [Then(@"User delete Tasks ""([^""]*)"" if exist")]
        public void UserDeleteTasks(string tasksName)
        {
            LogWriter.WriteLog("Executing Step User delete created Tasks by name" + tasksName);
            TasksPage.DeleteTasksIfExist(tasksName);
        }
        [Given(@"User verify add button is not available on tasks page")]
        [When(@"User verify add button is not available on tasks page")]
        [Then(@"User verify add button is not available on tasks page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on tasks page");
            TasksPage.VerifyAddButtonIsNotPresent();
        }
        [Then(@"User verify delete button is not available on tasks page on record ""(.*)""")]
        [When(@"User verify delete button is not available on tasks page on record ""(.*)""")]
        [Then(@"User verify delete button is not available on tasks page on record ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string tasksName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on tasks page on record " + tasksName);
            TasksPage.VerifyDeleteButtonIsNotPresent(tasksName);
        }
        [Given(@"User verify export option is available on tasks page")]
        [When(@"User verify export option is available on tasks page")]
        [Then(@"User verify export option is available on tasks page")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on tasks page");
            TasksPage.VerifyExportOptionIsPresent();
        }
    }
}
