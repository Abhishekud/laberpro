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
            ElementsPage.VerifyDeleteButtonIsNotPresent();
            ElementsPage.ClickOnPreviousLink();
        }
        [Given(@"User verify add button is not available on elements page")]
        [When(@"User verify add button is not available on elements page")]
        [Then(@"User verify add button is not available on elements page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on elements page");
            ElementsPage.VerifyAddButtonIsNotPresent();
        }

        [Given(@"User verify export option is present")]
        [When(@"User verify export option is present")]
        [Then(@"User verify export option is present")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step: User verify export option is present");
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
        [Given(@"User verify download element report for element: ""(.*)""")]
        [When(@"User verify download element report for element: ""(.*)""")]
        [Then(@"User verify download element report for element: ""(.*)""")]
        public void VerifyIfUserIsAbleToDownloadElementReport(string elementsName)
        {
            LogWriter.WriteLog("Executing Step: User verify download element report for element" + elementsName);
            ElementsPage.VerifyIfUserIsAbleToDownloadElementReport(elementsName);
        }
        [Given(@"User verify edit option for the element page is not available")]
        [When(@"User verify edit option for the element page is not available")]
        [Then(@"User verify edit option for the element page is not available")]
        public void VerifyIfUserIsNotAbleToEditTheElementSteps()
        {
            LogWriter.WriteLog("Executing Step: User verify edit option for the element page is not available");
            ElementsPage.VerifyIfUserIsNotAbleToEditTheElementSteps();
        }
        [Given(@"User verify more options menu is not available")]
        [When(@"User verify more options menu is not available")]
        [Then(@"User verify more options menu is not available")]
        public void VerifyIfUserIsUnableToAccessMoreOptionsMenu()
        {
            LogWriter.WriteLog("Executing Step: Verify user is unable to access more options menu");
            ElementsPage.VerifyIfUserIsUnableToAccessMoreOptionsMenu();
        }
        [Given(@"User verify simo toggle is not available")]
        [When(@"User verify simo toggle is not available")]
        [Then(@"User verify simo toggle is not available")]
        public void VerifyIfTheUserIsUnableToAccessToggle()
        {
            LogWriter.WriteLog("Executing Step: User verify simo toggle is not available");
            ElementsPage.VerifyIfTheUserIsUnableToAccessToggle();
        }
        [Given(@"User verify edit option for the element step is not available")]
        [When(@"User verify edit option for the element step is not available")]
        [Then(@"User verify edit option for the element step is not available")]
        public void VerifyIfUserDoesNotHaveAccessToEditElementStepDetails()
        {
            LogWriter.WriteLog("Executing Step: User verify edit option for the element step is not available") ;
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
