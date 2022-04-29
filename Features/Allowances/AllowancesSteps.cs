using LaborPro.Automation.shared.util;
using NUnit.Framework;

namespace LaborPro.Automation.Features.Allowances
{
    [Binding]
    public class AllowancesSteps
    {
        [When(@"User navigates to the Allowance tab")]
        [Given(@"User navigates to the Allowance tab")]
        [Then(@"User navigates to the Allowance tab")]
        public void UserNavigatesToTheAllowanceTab()
        {
            LogWriter.WriteLog("Executing step: User navigates to the Allowance tab");
            AllowancesPage.CloseAllowanceForm();
            AllowancesPage.ClickOnStandardTab();
            AllowancesPage.ClickOnAllowanceTab();
            AllowancesPage.ClickOnCalculatorTab();
            AllowancesPage.WaitForAllowanceAlertCloseIfAny();
        }

        [Given(@"User click on cancel Button")]
        [When(@"User click on cancel Button")]
        [Then(@"User click on cancel Button")]
        public void UserPressCancelButton()
        {
            LogWriter.WriteLog("Executing step: User click on cancel Button");
            AllowancesPage.CloseAllowanceForm();
        }

        [Given(@"Verify validation Message: ""([^""]*)""")]
        [When(@"Verify validation Message: ""([^""]*)""")]
        [Then(@"Verify validation Message: ""([^""]*)""")]
        public void VerifyValidationMessage(string message)
        {
            LogWriter.WriteLog("Executing step: Verify validation Message: "+message);
            AllowancesPage.VerifyAddAllowanceErrorMessage(message);
        }

        [Given(@"User add allowance using below input")]
        [When(@"User add allowance using below input")]
        [Then(@"User add allowance using below input")]
        public void AddAllowanceWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User add allowance using below input - "+ inputData);
            AllowancesPage.AddAllowanceWithGivenInput(inputData);
        }

        [Given(@"User add allowance using below input to verify vaidation message")]
        [When(@"User add allowance using below input to verify vaidation message")]
        [Then(@"User add allowance using below input to verify vaidation message")]
        public void AddAllowanceWithGivenInputToVerifyValidationMessage(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User add allowance using below input - "+ inputData);
            AllowancesPage.AddAllowanceWithGivenInputToVerifyValidationMessage(inputData);
        }

        [Given(@"User add allowance using below input if not exist")]
        [When(@"User add allowance using below input if not exist")]
        [Then(@"User add allowance using below input if not exist")]
        public void AddAllowanceWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User add allowance using below input if not exist - "+ inputData);
            AllowancesPage.AddAllowanceWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User delete allowance record")]
        [When(@"User delete allowance record")]
        [Then(@"User delete allowance record")]
        public void UserWillDeleteThePreviouslyAddedRecord()
        {
            LogWriter.WriteLog("Executing step: User delete allowance record");
            AllowancesPage.DeleteAllowance();
        }

        [Given(@"User verify created allowance name ""([^""]*)""")]
        [When(@"User verify created allowance name ""([^""]*)""")]
        [Then(@"User verify created allowance name ""([^""]*)""")]
        public void UserVerifyCreatedAllowance(String allowanceName)
        {
            LogWriter.WriteLog("Executing step: User verify created allowance name "+allowanceName);
            AllowancesPage.VerifyCreatedAllowance(allowanceName);
        }

        [Given(@"User click on cancel button")]
        [When(@"User click on cancel button")]
        [Then(@"User click on cancel button")]
        public void UserWillPressCancelButton()
        {
            LogWriter.WriteLog("Executing step: User click on cancel button");
            AllowancesPage.CloseAllowanceForm();
        }

        [Given(@"User verify error alert message: ""([^""]*)""")]
        [When(@"User verify error alert message: ""([^""]*)""")]
        [Then(@"User verify error alert message: ""([^""]*)""")]
        public void VerifyErrorAlertMessage(string expectedErrorMessage)
        {
            LogWriter.WriteLog("Executing step: User verify error alert message: "+expectedErrorMessage);
            AllowancesPage.VerifyErrorAlertMessage(expectedErrorMessage);
        }

        [When(@"User click on previous link")]
        [Then(@"User click on previous link")]
        public static void ClickOnPreviousButton()
        {
            LogWriter.WriteLog("Executing step: User click on previous link");
            AllowancesPage.ClickOnPreviousLink();
        }

        [Given(@"User delete created allowance: ""([^""]*)""")]
        [Then(@"User delete created allowance: ""([^""]*)""")]
        public static void DeleteCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing step: User delete created allowance: "+ allowanceName);
            AllowancesPage.UserDeleteCreatedAllowance(allowanceName);
        }

        [Given(@"User delete allowance ""([^""]*)"" if exist")]
        [When(@"User delete allowance ""([^""]*)"" if exist")]
        [Then(@"User delete allowance ""([^""]*)"" if exist")]
        public void UserDeleteallowance(String allowanceName)
        {
            LogWriter.WriteLog("Executing Step User delete created allowance by name" + allowanceName);
            AllowancesPage.DeleteAllowanceifexist(allowanceName);
        }
    }
}
