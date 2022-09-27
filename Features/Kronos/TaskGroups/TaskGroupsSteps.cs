using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Kronos.TaskGroups
{
    [Binding]
    public class TaskGroupsSteps
    {

        [When(@"User navigates to the TaskGroups tab")]
        [Given(@"User navigates to the TaskGroups tab")]
        [Then(@"User navigates to the TaskGroups tab")]
        public void UserNavigatesToTheTaskGroupsTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the TaskGroups tab");
            TaskGroupsPage.CloseTaskGroupsForm();
            TaskGroupsPage.ClickOnKronosTab();
            TaskGroupsPage.ClickOnTaskGroupsTab();
        }

        [Given(@"User create new TaskGroups with below input if not exist")]
        [When(@"User create new TaskGroups with below input if not exist")]
        [Then(@"User create new TaskGroups with below input if not exist")]
        public void AddNewTaskGroupsWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User create new TaskGroups with below input if not exist - " + inputData);
            TaskGroupsPage.AddNewTaskGroupsWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User create new TaskGroups with below input")]
        [When(@"User create new TaskGroups with below input")]
        [Then(@"User create new TaskGroups with below input")]
        public void AddNewTaskGroupsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new TaskGroups with below input " + inputData);
            TaskGroupsPage.AddNewTaskGroupsWithGivenInput(inputData);
        }

        [Given(@"User clicks Add TaskGroups Button")]
        [When(@"User clicks Add TaskGroups Button")]
        [Then(@"User clicks Add TaskGroups Button")]
        public void UserClickAddTaskGroupsButton()
        {
            LogWriter.WriteLog("Executing Step User clicks Add TaskGroups Button");
            TaskGroupsPage.UserClickAddTaskGroupsButton();
        }

        [Given(@"User verify created TaskGroups ""([^""]*)""")]
        [When(@"User verify created TaskGroups ""([^""]*)""")]
        [Then(@"User verify created TaskGroups ""([^""]*)""")]
        public void UserVerifyCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User verify created TaskGroups by name" + taskGroupsName);
            TaskGroupsPage.VerifyCreatedTaskGroups(taskGroupsName);
        }

        [Given(@"User verify Add Menu TaskGroups Popup")]
        [When(@"User verify Add Menu TaskGroups Popup")]
        [Then(@"User verify Add Menu TaskGroups Popup")]
        public void UserVerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing Step User verify Add Menu TaskGroups Popup");
            TaskGroupsPage.VerifyAddMenuPopup();
        }

        [Given(@"User delete created TaskGroups ""([^""]*)""")]
        [When(@"User delete created TaskGroups ""([^""]*)""")]
        [Then(@"User delete created TaskGroups ""([^""]*)""")]
        public void UserDeleteCreatedTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User delete created TaskGroups by name" + taskGroupsName);
            TaskGroupsPage.DeleteCreatedTaskGroups(taskGroupsName);
        }

        [Given(@"User delete TaskGroups ""([^""]*)"" if exist")]
        [When(@"User delete TaskGroups ""([^""]*)"" if exist")]
        [Then(@"User delete TaskGroups ""([^""]*)"" if exist")]
        public void UserDeleteTaskGroups(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User delete created TaskGroups by name" + taskGroupsName);
            TaskGroupsPage.DeleteTaskGroupsIfExist(taskGroupsName);
        }

        [Given(@"User verify add button is not available on task group page")]
        [When(@"User verify add button is not available on task group page")]
        [Then(@"User verify add button is not available on task group page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on task group page");
            TaskGroupsPage.VerifyAddButtonIsNotPresent();
        }
        [Then(@"User verify delete button is not available on task groups page in  ""(.*)""")]
        [When(@"User verify delete button is not available on task groups page in  ""(.*)""")]
        [Then(@"User verify delete button is not available on task groups page in  ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string taskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on task groups page in" + taskGroupsName);
            TaskGroupsPage.VerifyDeleteButtonIsNotPresent(taskGroupsName);
        }
        [Given(@"User verify export option is available on task groups page")]
        [When(@"User verify export option is available on task groups page")]
        [Then(@"User verify export option is available on task groups page")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on task groups page");
            TaskGroupsPage.VerifyExportOptionIsPresent();
        }

    }
}
