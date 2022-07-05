using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Elements
{
    [Binding]
    public class ElementsSteps
    {

        [When(@"User navigates to the elements page")]
        [Given(@"User navigates to the elements page")]
        [Then(@"User navigates to the elements page")]
        public void NavigatesToTheElementsTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the elements page");
            ElementsPage.CloseElementsForm();
            ElementsPage.ClickOnMeasurementsTab();
            ElementsPage.ClickOnElements();
        }

        [Given(@"User delete elements ""([^""]*)"" if exist")]
        [When(@"User delete elements ""([^""]*)"" if exist")]
        [Then(@"User delete elements ""([^""]*)"" if exist")]
        public void DeleteElementsIfExist(string elementsName)
        {
            LogWriter.WriteLog("Executing Step: User delete elements if exist" + elementsName);
            ElementsPage.DeleteElementsIfExist(elementsName);
        }
        
        [Then(@"User verify delete button is not present on elements page")]
        [When(@"User verify delete button is not present on elements page")]
        [Then(@"User verify delete button is not present on elements page")]
        public void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step: User verify delete button is not present on elements page");
            ElementsPage.VerifyDeleteButtonIsNotPresent( );
        }
        [Given(@"Verify export option is present")]
        [When(@"Verify export option is present")]
        [Then(@"Verify export option is present")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step: Verify export option is present");
            ElementsPage.VerifyExportOptionIsPresent();
        }
        [Given(@"User verify that select multiple elements checkbox is not available")]
        [When(@"User verify that select multiple elements checkbox is not available")]
        [Then(@"User verify that select multiple elements checkbox is not available")]
        public void VerifySelectMultipleElementsCheckboxIsUnavailable()
        {
            LogWriter.WriteLog("Executing Step: User verify that select multiple elements checkbox is not available");
            ElementsPage.VerifySelectMultipleElementsCheckboxIsUnavailable();
        }
        [Given(@"Verify user is able to download element report in ""(.*)""")]
        [When(@"Verify user is able to download element report in ""(.*)""")]
        [Then(@"Verify user is able to download element report in ""(.*)""")]
        public void VerifyIfUserIsAbleToDownloadElementReport(string elementsName)
        {
            LogWriter.WriteLog("Executing Step: Verify user is able to download element report in" + elementsName);
            ElementsPage.VerifyIfUserIsAbleToDownloadElementReport(elementsName);
        }
        [Given(@"Verify user is not able to edit the element steps")]
        [When(@"Verify user is not able to edit the element steps")]
        [Then(@"Verify user is not able to edit the element steps")]
        public void VerifyIfUserIsNotAbleToEditTheElementSteps()
        {
            LogWriter.WriteLog("Executing Step: Verify user is not able to edit the element steps");
            ElementsPage.VerifyIfUserIsNotAbleToEditTheElementSteps();
        }
        [Given(@"Verify user is not able to access more options menu")]
        [When(@"Verify user is not able to access more options menu")]
        [Then(@"Verify user is not able to access more options menu")]
        public void VerifyIfUserIsUnableToAccessMoreOptionsMenu()
        {
            LogWriter.WriteLog("Executing Step: Verify user is unable to access more options menu");
            ElementsPage.VerifyIfUserIsUnableToAccessMoreOptionsMenu();
        }
        [Given(@"Verify user is not able to access simo toggle")]
        [When(@"Verify user is not able to access simo toggle")]
        [Then(@"Verify user is not able to access simo toggle")]
        public void VerifyIfTheUserIsUnableToAccessToggle()
        {
            LogWriter.WriteLog("Executing Step: Verify user is not able to access simo toggle");
            ElementsPage.VerifyIfTheUserIsUnableToAccessToggle();
        }
        [Given(@"Verify user does not have access to edit element step details")]
        [When(@"Verify user does not have access to edit element step details")]
        [Then(@"Verify user does not have access to edit element step details")]
        public void VerifyIfUserDoesNotHaveAccessToEditElementStepDetails()
        {
            LogWriter.WriteLog("Executing Step: Verify user does not have access to edit element step details");
            ElementsPage.VerifyIfUserDoesNotHaveAccessToEditElementStepDetails();
        }
        [Given(@"User verify select checkboxes are not available for multi select")]
        [When(@"User verify select checkboxes are not available for multi select")]
        [Then(@"User verify select checkboxes are not available for multi select")]
        public void VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails()
        {
            LogWriter.WriteLog("Executing Step: User Verify select checkboxes are unavailable for multi select");
            ElementsPage.VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails();
        }
        [Then(@"User create new elements with below input if not exist")]
        [When(@"User create new elements with below input if not exist")]
        public void ThenUserCreateNewElementsWithBelowInputIfNotExist(Table table)
        {
            LogWriter.WriteLog("Executing Step: User create new Elements with below input if not exist" + table);       
            ElementsPage.AddElementWithGivenInputIfNotExist(table);
        }

    }

}
