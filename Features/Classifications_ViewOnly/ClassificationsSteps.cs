using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Classifications_ViewOnly
{
    [Binding]
    public class ClassificationsSteps
    {

        [When(@"User navigates to the Classifications tab")]
        [Given(@"User navigates to the Classifications tab")]
        [Then(@"User navigates to the Classifications tab")]
        public void NavigatesToTheClassificationsTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the Classifications tab");
            ClassificationsPage.CloseClassificationsForm();
            ClassificationsPage.ClickOnStandardTab(); 
            ClassificationsPage.ClickOnListManagementTab();
            ClassificationsPage.ClickOnClassifications();

        }  
        [Given(@"User create new Classifications with below input")]
        [When(@"User create new Classifications with below input")]
        [Then(@"User create new Classifications with below input")]
        public void AddNewClassificationsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Classifications with below input");
            ClassificationsPage.AddNewClassificationsWithGivenInput(inputData);
        } 

        [Given(@"User verify created Classifications by name ""([^""]*)""")]
        [When(@"User verify created Classifications by name ""([^""]*)""")]
        [Then(@"User verify created Classifications by name ""([^""]*)""")]
        public void VerifyCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User verify created Classifications by name");
            ClassificationsPage.VerifyCreatedClassifications(classificationsName);
        }

        [Given(@"User delete created Classifications by name ""([^""]*)""")]
        [When(@"User delete created Classifications by name ""([^""]*)""")]
        [Then(@"User delete created Classifications by name ""([^""]*)""")]
        public void DeleteCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User delete created Classifications by name");
            ClassificationsPage.DeleteCreatedClassifications(classificationsName);
        }  

        [Given(@"User delete Classifications ""([^""]*)"" if exist")]
        [When(@"User delete Classifications ""([^""]*)"" if exist")]
        [Then(@"User delete Classifications ""([^""]*)"" if exist")]
        public void DeleteClassificationsIfExist(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User delete created Classifications by name" + classificationsName);
            ClassificationsPage.DeleteClassificationsIfExist(classificationsName);
        }
        [Given(@"User verify Add Button is not Present in Classifications")]
        [When(@"User verify Add Button is not Present in Classifications")]
        [Then(@"User verify Add Button is not Present in Classifications")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not present");
            ClassificationsPage.VerifyAddButtonIsNotPresent();
        } 
        [Then(@"User verify Delete Button is not Present in Classifications ""(.*)""")]
        [When(@"User verify Delete Button is not Present in Classifications ""(.*)""")]
        [Then(@"User verify Delete Button is not Present in Classifications ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User verify Delete button is not present");
            ClassificationsPage.VerifyDeleteButtonIsNotPresent(classificationsName);
        } 
    }
}
