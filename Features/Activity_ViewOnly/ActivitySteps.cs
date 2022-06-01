using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Activity_ViewOnly
{
    [Binding]
    public class ActivitySteps
    {

        [When(@"User navigates to the Activity tab")]
        [Given(@"User navigates to the Activity tab")]
        [Then(@"User navigates to the Activity tab")]
        public void NavigatesToTheActivityTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the Activity tab");
            ActivityPage.CloseActivityForm();
            ActivityPage.ClickOnMeasurementsTab();
            ActivityPage.ClickOnListManagementTab();
            ActivityPage.ClickOnActivity();

        }  
        [Given(@"User create new Activity with below input")]
        [When(@"User create new Activity with below input")]
        [Then(@"User create new Activity with below input")]
        public void AddNewActivityWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Activity with below input");
            ActivityPage.AddNewActivityWithGivenInput(inputData);
        } 

        [Given(@"User verify created Activity by name ""([^""]*)""")]
        [When(@"User verify created Activity by name ""([^""]*)""")]
        [Then(@"User verify created Activity by name ""([^""]*)""")]
        public void VerifyCreatedActivity(string activityName)
        {
            LogWriter.WriteLog("Executing Step User verify created Activity by name");
            ActivityPage.VerifyCreatedActivity(activityName);
        }

        [Given(@"User delete created Activity by name ""([^""]*)""")]
        [When(@"User delete created Activity by name ""([^""]*)""")]
        [Then(@"User delete created Activity by name ""([^""]*)""")]
        public void DeleteCreatedActivity(string activityName)
        {
            LogWriter.WriteLog("Executing Step User delete created Activity by name");
            ActivityPage.DeleteCreatedActivity(activityName);
        }  

        [Given(@"User delete Activity ""([^""]*)"" if exist")]
        [When(@"User delete Activity ""([^""]*)"" if exist")]
        [Then(@"User delete Activity ""([^""]*)"" if exist")]
        public void DeleteActivityIfExist(string activityName)
        {
            LogWriter.WriteLog("Executing Step User delete created Activity by name" + activityName);
            ActivityPage.DeleteActivityIfExist(activityName);
        }
        [Given(@"User verify Add Button is not Present in Activity")]
        [When(@"User verify Add Button is not Present in Activity")]
        [Then(@"User verify Add Button is not Present in Activity")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not present");
            ActivityPage.VerifyAddButtonIsNotPresent();
        } 
        [Then(@"User verify Delete Button is not Present in Activity ""(.*)""")]
        [When(@"User verify Delete Button is not Present in Activity ""(.*)""")]
        [Then(@"User verify Delete Button is not Present in Activity ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string activityName)
        {
            LogWriter.WriteLog("Executing Step User verify Delete button is not present");
            ActivityPage.VerifyDeleteButtonIsNotPresent(activityName);
        } 
    }
}
