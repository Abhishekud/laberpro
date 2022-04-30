using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.TaskGroups
{
    [Binding]
    public class TaskGroupsSteps
    {

        [When(@"User navigates to the TaskGroups tab")]
        [Given(@"User navigates to the TaskGroups tab")]
        [Then(@"User navigates to the TaskGroups tab")]
        public void UserNavigatesToTheKronosTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the  Kronos tab  ");
            TaskGroupsPage.CloseTaskGroupsForm();
            TaskGroupsPage.ClickOnKronosTab();
            TaskGroupsPage.ClickOnTaskGroupsTab();
        }

        [Given(@"User create new TaskGroups with below input if not exist")]
        [When(@"User create new TaskGroups with below input if not exist")]
        [Then(@"User create new TaskGroups with below input if not exist")]
        public void AddNewTaskGroupsWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new TaskGroups with below input if not exist - " + inputData);
            TaskGroupsPage.AddNewTaskGroupsWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User create new TaskGroups with below input")]
        [When(@"User create new TaskGroups with below input")]
        [Then(@"User create new TaskGroups with below input")]
        public void AddNewTaskGroupsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new TaskGroups with below input " + inputData);
            TaskGroupsPage.AddNewTaskGroupsWithGivenInput(inputData);
        }

        [Given(@"User clicks Add TaskGroups Button")]
        [When(@"User clicks Add TaskGroups Button")]
        [Then(@"User clicks Add TaskGroups Button")]
        public void UserClickAddTaskGroupsButton()
        {
            LogWriter.WriteLog("Exceuting Step User clicks cancel button");
            TaskGroupsPage.UserClickAddTaskGroupsButton();
        }

        [Given(@"User verify created TaskGroups ""([^""]*)""")]
        [When(@"User verify created TaskGroups ""([^""]*)""")]
        [Then(@"User verify created TaskGroups ""([^""]*)""")]
        public void UserVerifyCreatedTaskGroups(String TaskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User verify created TaskGroups by name" + TaskGroupsName);
            TaskGroupsPage.VerifyCreatedTaskGroups(TaskGroupsName);
        }

        [Given(@"User verify Add Menu TaskGroups Popup")]
        [When(@"User verify Add Menu TaskGroups Popup")]
        [Then(@"User verify Add Menu TaskGroups Popup")]
        public void UserVerifyAddMenuPopup()
        {
            LogWriter.WriteLog("Executing Step User verify Add Menu Popup");
            TaskGroupsPage.VerifyAddMenuPopup();
        }

        [Given(@"User delete created TaskGroups ""([^""]*)""")]
        [When(@"User delete created TaskGroups ""([^""]*)""")]
        [Then(@"User delete created TaskGroups ""([^""]*)""")]
        public void UserDeleteCreatedTaskGroups(String TaskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User delete created TaskGroups by name" + TaskGroupsName);
            TaskGroupsPage.DeleteCreatedTaskGroups(TaskGroupsName);
        }

        [Given(@"User delete TaskGroups ""([^""]*)"" if exist")]
        [When(@"User delete TaskGroups ""([^""]*)"" if exist")]
        [Then(@"User delete TaskGroups ""([^""]*)"" if exist")]
        public void UserDeleteTaskGroups(String TaskGroupsName)
        {
            LogWriter.WriteLog("Executing Step User delete created TaskGroups by name" + TaskGroupsName);
            TaskGroupsPage.DeleteTaskGroupsIfExist(TaskGroupsName);
        }

    }
}
