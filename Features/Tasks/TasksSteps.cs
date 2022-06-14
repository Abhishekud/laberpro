using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Tasks
{
    [Binding]
    public class TasksSteps
    {

        [When(@"User navigates to the Tasks tab")]
        [Given(@"User navigates to the Tasks tab")]
        [Then(@"User navigates to the Tasks tab")]
        public void UserNavigatesToTheTasksTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the Tasks tab  ");
            TasksPage.CloseTasksForm();
            TasksPage.ClickOnKronosTab();
            TasksPage.ClickOnTasksTab();

        }
        [Given(@"User create new Tasks with below input if not exist")]
        [When(@"User create new Tasks with below input if not exist")]
        [Then(@"User create new Tasks with below input if not exist")]
        public void AddNewTasksWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new Tasks with below input if not exist - " + inputData);
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
            LogWriter.WriteLog("Executing Step User clicks cancel button");
            TasksPage.UserClickAddTasksButton();
        }

        [Given(@"User verify created Tasks ""([^""]*)""")]
        [When(@"User verify created Tasks ""([^""]*)""")]
        [Then(@"User verify created Tasks ""([^""]*)""")]
        public void UserVerifyCreatedTasks(string tasksName)
        {
            LogWriter.WriteLog("Executing Step User verify created Tasks by name" + tasksName);
            TasksPage.VerifyCreatedTasks(tasksName);
        }

        [Given(@"User verify Add Menu Tasks Popup")]
        [When(@"User verify Add Menu Tasks Popup")]
        [Then(@"User verify Add Menu Tasks Popup")]
        public void UserVerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing Step User verify Add Menu Popup");
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

        [Given(@"Verify add button is not present on Tasks page")]
        [When(@"Verify add button is not present on Tasks page")]
        [Then(@"Verify add button is not present on Tasks page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step Verify Add button is not present on Tasks page");
            TasksPage.VerifyAddButtonIsNotPresent();
        }
        [Then(@"Verify delete button is not present on Tasks page in  ""(.*)""")]
        [When(@"Verify delete button is not present on Tasks page in  ""(.*)""")]
        [Then(@"Verify delete button is not present on Tasks page in  ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string tasksName)
        {
            LogWriter.WriteLog("Executing Step Verify Delete button is not present on Tasks page");
            TasksPage.VerifyDeleteButtonIsNotPresent(tasksName);
        }
        [Given(@"Verify export option is present on Tasks page")]
        [When(@"Verify export option is present on Tasks page")]
        [Then(@"Verify export option is present on Tasks page")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step Verify Export option is present on Tasks page");
            TasksPage.VerifyExportOptionIsPresent();
        }
    }
}
