using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Activity
{
    [Binding]
    public class ActivitySteps
    {
        [Given(@"User create new activity ""([^""]*)""")]
        [When(@"User create new activity ""([^""]*)""")]
        [Then(@"User create new activity ""([^""]*)""")]
        public void CreateNewActivity(string activity)
        {
            LogWriter.WriteLog("Executing Step User create new activity " + activity);
            ActivityPage.CloseActivityForm();
            ActivityPage.ClickOnMeasurementsTab();
            ActivityPage.ClickOnListManagementTab();
            ActivityPage.ClickOnActivity();
            ActivityPage.AddNewActivityWithGivenInput(activity);
        }

        [Given(@"User verify add button is not available in activity")]
        [When(@"User verify add button is not available in activity")]
        [Then(@"User verify add button is not available in activity")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available in activity");
            ActivityPage.CloseActivityForm();
            ActivityPage.ClickOnMeasurementsTab();
            ActivityPage.ClickOnListManagementTab();
            ActivityPage.ClickOnActivity();
            ActivityPage.VerifyAddButtonIsNotAvailable();

        }

        [Given(@"User verify delete and edit option is not available for activity ""([^""]*)""")]
        [When(@"User verify delete and edit option is not available for activity ""([^""]*)""")]
        [Then(@"User verify delete and edit option is not available for activity ""([^""]*)""")]
        public void VerifyDeleteAndEditOptionIsNotAvailable(string activity)
        {
            LogWriter.WriteLog("Executing Step User verify delete and edit option is not available for activity " + activity);
            ActivityPage.FindActivityByName(DataCache.Read(activity));
            ActivityPage.VerifyDeleteButtonIsNotAvailable();
        }

        [Given(@"User delete activity ""([^""]*)""")]
        [When(@"User delete activity ""([^""]*)""")]
        [Then(@"User delete activity ""([^""]*)""")]
        public void DeleteActivity(string activity)
        {
            LogWriter.WriteLog("Executing Step User delete activity " + activity);
            ActivityPage.CloseActivityForm();
            ActivityPage.ClickOnMeasurementsTab();
            ActivityPage.ClickOnListManagementTab();
            ActivityPage.ClickOnActivity();
            ActivityPage.DeleteCreatedActivity(DataCache.Read(activity));

        }
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
        [Given(@"User create new Activity with below input if not exist")]
        [When(@"User create new Activity with below input if not exist")]
        [Then(@"User create new Activity with below input if not exist")]
        public void AddNewActivityWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Activity with below input if not exist");
            ActivityPage.AddNewActivityWithGivenInputIfNotExist(inputData);
        }
        [Given(@"User delete Activity ""([^""]*)"" if exist")]
        [When(@"User delete Activity ""([^""]*)"" if exist")]
        [Then(@"User delete Activity ""([^""]*)"" if exist")]
        public void DeleteActivityIfExist(string activityName)
        {
            LogWriter.WriteLog("Executing Step User delete created Activity by name" + activityName);
            ActivityPage.DeleteActivityIfExist(activityName);
        }

    }
}
