using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Rest
{
    [Binding]
    public class RestSteps
    {

        [When(@"User navigates to the Rest tab")]
        [Given(@"User navigates to the Rest tab")]
        [Then(@"User navigates to the Rest tab")]
        public void NavigatesToTheRestTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the Rest tab");
            RestPage.CloseRestForm();
            RestPage.ClickOnStandardTab();
            RestPage.ClickOnAllowanceTab();
            RestPage.ClickOnRestTab();
            RestPage.WaitForRestAlertCloseIfAny();

        }
        [Given(@"User create new Rest with below input")]
        [When(@"User create new Rest with below input")]
        [Then(@"User create new Rest with below input")]
        public void AddNewRestWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Rest with below input" + inputData);
            RestPage.AddNewRestWithGivenInput(inputData);
        }

        [Given(@"User create new Rest with below input if not exist")]
        [When(@"User create new Rest with below input if not exist")]
        [Then(@"User create new Rest with below input if not exist")]
        public void AddNewRestWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Rest with below input if not exist" +inputData);
            RestPage.AddNewRestWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created Rest by name ""([^""]*)""")]
        [When(@"User verify created Rest by name ""([^""]*)""")]
        [Then(@"User verify created Rest by name ""([^""]*)""")]
        public void VerifyCreatedRest(string restName)
        {
            LogWriter.WriteLog("Executing Step User verify created Rest by name " +restName);
            RestPage.VerifyCreatedRest(restName);
        }

        [Given(@"User delete created Rest by name ""([^""]*)""")]
        [When(@"User delete created Rest by name ""([^""]*)""")]
        [Then(@"User delete created Rest by name ""([^""]*)""")]
        public void DeleteCreatedRest(string restName)
        {
            LogWriter.WriteLog("Executing Step User delete created Rest by name " + restName);
            RestPage.DeleteCreatedRest(restName);
        }

        [Given(@"User delete Rest ""([^""]*)"" if exist")]
        [When(@"User delete Rest ""([^""]*)"" if exist")]
        [Then(@"User delete Rest ""([^""]*)"" if exist")]
        public void DeleteRestIfExist(string restName)
        {
            LogWriter.WriteLog("Executing Step User delete created Rest by name" + restName);
            RestPage.DeleteRestIfExist(restName);
        }

        [Given(@"User find rest by name ""([^""]*)""")]
        [When(@"User find rest by name ""([^""]*)""")]
        [Then(@"User find rest by name ""([^""]*)""")]
        public void FindRestByName(string restName)
        {
            LogWriter.WriteLog("Executing Step User find rest by name " + restName);
            RestPage.FindRestByName(restName);
        }
        [Then(@"User verify add button is not available on rest page")]
        public void  VerifyAddButtonIsNotAvailableOnRestPage()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on rest page");
            RestPage.VerifyAddButtonIsNotPresent();
        }

         
        [Then(@"User verify delete button and edit option is not available on rest page")]
        public void VerifyDeleteButtonAndEditOptionIsNotAvailableOnRestPage()
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on rest page");
            RestPage.VerifyDeleteButtonIsNotPresent();
        }

    }
}
