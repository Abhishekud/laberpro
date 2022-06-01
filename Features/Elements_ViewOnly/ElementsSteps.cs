using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Elements_ViewOnly
{
    [Binding]
    public class ElementsSteps
    {

        [When(@"User navigates to the Elements tab")]
        [Given(@"User navigates to the Elements tab")]
        [Then(@"User navigates to the Elements tab")]
        public void NavigatesToTheElementsTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the Elements tab");
            ElementsPage.CloseElementsForm();
            ElementsPage.ClickOnMeasurementsTab();
            ElementsPage.ClickOnElements();
             

        }  
        [Given(@"User create new Elements with below input")]
        [When(@"User create new Elements with below input")]
        [Then(@"User create new Elements with below input")]
        public void AddNewElementsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Elements with below input");
            ElementsPage.AddNewElementsWithGivenInput(inputData);
        } 

        [Given(@"User verify created Elements by name ""([^""]*)""")]
        [When(@"User verify created Elements by name ""([^""]*)""")]
        [Then(@"User verify created Elements by name ""([^""]*)""")]
        public void VerifyCreatedElements(string elementsName)
        {
            LogWriter.WriteLog("Executing Step User verify created Elements by name");
            ElementsPage.VerifyCreatedElements(elementsName);
        }

        [Given(@"User delete created Elements by name ""([^""]*)""")]
        [When(@"User delete created Elements by name ""([^""]*)""")]
        [Then(@"User delete created Elements by name ""([^""]*)""")]
        public void DeleteCreatedElements(string elementsName)
        {
            LogWriter.WriteLog("Executing Step User delete created Elements by name");
            ElementsPage.DeleteCreatedElementsByName(elementsName);
        }  

        [Given(@"User delete Elements ""([^""]*)"" if exist")]
        [When(@"User delete Elements ""([^""]*)"" if exist")]
        [Then(@"User delete Elements ""([^""]*)"" if exist")]
        public void DeleteElementsIfExist(string elementsName)
        {
            LogWriter.WriteLog("Executing Step User delete created Elements by name" + elementsName);
            ElementsPage.DeleteElementsIfExist(elementsName);
        }
        [Given(@"User verify Add Button is not Present in Elements")]
        [When(@"User verify Add Button is not Present in Elements")]
        [Then(@"User verify Add Button is not Present in Elements")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not present");
            ElementsPage.VerifyAddButtonIsNotPresent();
        } 
        [Then(@"User verify Delete Button is not Present in Elements")]
        [When(@"User verify Delete Button is not Present in Elements")]
        [Then(@"User verify Delete Button is not Present in Elements")]
        public void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Delete button is not present");
            ElementsPage.VerifyDeleteButtonIsNotPresent( );
        }
        [Given(@"User verify Export option is Present in Elements")]
        [When(@"User verify Export option is Present in Elements")]
        [Then(@"User verify Export option is Present in Elements")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Export option is Present");
            ElementsPage.VerifyExportOptionIsPresent();
        }
        [Given(@"User Verify that select multiple Elements checkbox is unavailable")]
        [When(@"User Verify that select multiple Elements checkbox is unavailable")]
        [Then(@"User Verify that select multiple Elements checkbox is unavailable")]
        public void VerifySelectMultipleElementsCheckboxIsUnavailable()
        {
            LogWriter.WriteLog("Executing Step User Verify that select multiple Elements checkbox is unavailable");
            ElementsPage.VerifySelectMultipleElementsCheckboxIsUnavailable();
        }
        [Given(@"User Verify if user is able to download Element Report in ""(.*)""")]
        [When(@"User Verify if user is able to download Element Report in ""(.*)""")]
        [Then(@"User Verify if user is able to download Element Report in ""(.*)""")]
        public void VerifyIfUserIsAbleToDownloadElementReport(string elementsName)
        {
            LogWriter.WriteLog("Executing Step User Verify if user is able to download Element Report");
            ElementsPage.VerifyIfUserIsAbleToDownloadElementReport(elementsName);
        }
        [Given(@"User Verify if user is not able to edit the element steps")]
        [When(@"User Verify if user is not able to edit the element steps")]
        [Then(@"User Verify if user is not able to edit the element steps")]
        public void VerifyIfUserIsNotAbleToEditTheElementSteps()
        {
            LogWriter.WriteLog("Executing Step User Verify if user is not able to edit the element steps");
            ElementsPage.VerifyIfUserIsNotAbleToEditTheElementSteps();
        }
        [Given(@"User Verify if user is unable to access more options menu")]
        [When(@"User Verify if user is unable to access more options menu")]
        [Then(@"User Verify if user is unable to access more options menu")]
        public void VerifyIfUserIsUnableToAccessMoreOptionsMenu()
        {
            LogWriter.WriteLog("Executing Step User Verify if user is unable to access more options menu");
            ElementsPage.VerifyIfUserIsUnableToAccessMoreOptionsMenu();
        }
        [Given(@"User Verify if the user is unable to access Simo toggle")]
        [When(@"User Verify if the user is unable to access Simo toggle")]
        [Then(@"User Verify if the user is unable to access Simo toggle")]
        public void VerifyIfTheUserIsUnableToAccessSimoToggle()
        {
            LogWriter.WriteLog("Executing Step User Verify if the user is unable to access Simo toggle");
            ElementsPage.VerifyIfTheUserIsUnableToAccessSimoToggle();
        }
        [Given(@"User Verify if user does not have access to edit element step details")]
        [When(@"User Verify if user does not have access to edit element step details")]
        [Then(@"User Verify if user does not have access to edit element step details")]
        public void VerifyIfUserDoesNotHaveAccessToEditElementStepDetails()
        {
            LogWriter.WriteLog("Executing Step User Verify if user does not have access to edit element step details");
            ElementsPage.VerifyIfUserDoesNotHaveAccessToEditElementStepDetails();
        }
        [Given(@"User Verify that if select checkboxes are unavailable for multi select in Element Details")]
        [When(@"User Verify that if select checkboxes are unavailable for multi select in Element Details")]
        [Then(@"User Verify that if select checkboxes are unavailable for multi select in Element Details")]
        public void VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails()
        {
            LogWriter.WriteLog("Executing Step User Verify that if select checkboxes are unavailable for multi select in Element Details");
            ElementsPage.VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails();
        }
    }
 
}
