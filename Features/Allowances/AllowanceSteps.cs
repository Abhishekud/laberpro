using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Allowances
{
    [Binding]
    public class AllowanceSteps
    {
        [When(@"User navigates to the Allowance tab")]
        [Given(@"User navigates to the Allowance tab")]
        [Then(@"User navigates to the Allowance tab")]
        public void UserNavigatesToTheAllowanceTab()
        {
            LogWriter.WriteLog("Executing step: User navigates to the Allowance tab");
            AllowancePage.CloseAllowanceForm();
            AllowancePage.ClickOnStandardTab();
            AllowancePage.ClickOnAllowanceTab();
            AllowancePage.ClickOnCalculatorTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
        }

        [Given(@"User click on cancel Button")]
        [When(@"User click on cancel Button")]
        [Then(@"User click on cancel Button")]
        public void UserPressCancelButton()
        {
            LogWriter.WriteLog("Executing step: User click on cancel Button");
            AllowancePage.CloseAllowanceForm();
        }

        [Given(@"Verify validation Message: ""([^""]*)""")]
        [When(@"Verify validation Message: ""([^""]*)""")]
        [Then(@"Verify validation Message: ""([^""]*)""")]
        public void VerifyValidationMessage(string message)
        {
            LogWriter.WriteLog("Executing step: Verify validation Message: "+message);
            AllowancePage.VerifyAddAllowanceErrorMessage(message);
        }

        [Given(@"User add allowance using below input")]
        [When(@"User add allowance using below input")]
        [Then(@"User add allowance using below input")]
        public void AddAllowanceWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User add allowance using below input - "+ inputData);
            AllowancePage.AddAllowanceWithGivenInput(inputData);
        }

        [Given(@"User add allowance using below input to verify validation message")]
        [When(@"User add allowance using below input to verify validation message")]
        [Then(@"User add allowance using below input to verify validation message")]
        public void AddAllowanceWithGivenInputToVerifyValidationMessage(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User add allowance using below input - "+ inputData);
            AllowancePage.AddAllowanceWithGivenInputToVerifyValidationMessage(inputData);
        }

        [Given(@"User add allowance using below input if not exist")]
        [When(@"User add allowance using below input if not exist")]
        [Then(@"User add allowance using below input if not exist")]
        public void AddAllowanceWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User add allowance using below input if not exist - "+ inputData);
            AllowancePage.AddAllowanceWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User delete allowance record")]
        [When(@"User delete allowance record")]
        [Then(@"User delete allowance record")]
        public void UserWillDeleteThePreviouslyAddedRecord()
        {
            LogWriter.WriteLog("Executing step: User delete allowance record");
            AllowancePage.DeleteAllowance();
        }

        [Given(@"User verify created allowance name ""([^""]*)""")]
        [When(@"User verify created allowance name ""([^""]*)""")]
        [Then(@"User verify created allowance name ""([^""]*)""")]
        public void UserVerifyCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing step: User verify created allowance name "+allowanceName);
            AllowancePage.VerifyCreatedAllowance(allowanceName);
        }

        [Given(@"User click on cancel button")]
        [When(@"User click on cancel button")]
        [Then(@"User click on cancel button")]
        public void UserWillPressCancelButton()
        {
            LogWriter.WriteLog("Executing step: User click on cancel button");
            AllowancePage.CloseAllowanceForm();
        }

        [Given(@"User verify error alert message: ""([^""]*)""")]
        [When(@"User verify error alert message: ""([^""]*)""")]
        [Then(@"User verify error alert message: ""([^""]*)""")]
        public void VerifyErrorAlertMessage(string expectedErrorMessage)
        {
            LogWriter.WriteLog("Executing step: User verify error alert message: "+expectedErrorMessage);
            AllowancePage.VerifyErrorAlertMessage(expectedErrorMessage);
        }

        [When(@"User click on previous link")]
        [Then(@"User click on previous link")]
        public static void ClickOnPreviousButton()
        {
            LogWriter.WriteLog("Executing step: User click on previous link");
            AllowancePage.ClickOnPreviousLink();
        }

        [Given(@"User delete created allowance: ""([^""]*)""")]
        [Then(@"User delete created allowance: ""([^""]*)""")]
        public static void DeleteCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing step: User delete created allowance: "+ allowanceName);
            AllowancePage.UserDeleteCreatedAllowance(allowanceName);
        }

        [Given(@"User delete allowance ""([^""]*)"" if exist")]
        [When(@"User delete allowance ""([^""]*)"" if exist")]
        [Then(@"User delete allowance ""([^""]*)"" if exist")]
        public void UserDeleteAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing Step User delete created allowance by name" + allowanceName);
            AllowancePage.DeleteAllowanceIfExist(allowanceName);
        }
        [Then(@"User verify add button is not available on allowance page")]
        [When(@"User verify add button is not available on allowance page")]
        [Given(@"User verify add button is not available on allowance page")]
        public void VerifyAddButtonIsNotAvailableOnAllowancePage()
        {
            LogWriter.WriteLog("Executing step: User verify add button is not available on allowance page");
            AllowancePage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify download allowance details report for allowance: ""([^""]*)""")]
        [Given(@"User verify download allowance details report for allowance: ""([^""]*)""")]
        [When(@"User verify download allowance details report for allowance: ""([^""]*)""")]
        public void VerifyDownloadAllowanceDetailsReportForAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing step: User verify download allowance details report for allowance"+ allowanceName);
            AllowancePage.VerifyDownloadAllowanceDetailsReportForAllowance(allowanceName);
            
        } 

        [Then(@"User verify copy option is not available on allowance page")]
        [When(@"User verify copy option is not available on allowance page")]
        [Given(@"User verify copy option is not available on allowance page")]
        public void VerifyCopyOptionIsNotAvailableOnAllowancePage()
        {
            LogWriter.WriteLog("Executing step: User verify copy option is not available on allowance page");
            AllowancePage.VerifyCopyButtonIsNotPresent();
            AllowancePage.ClickOnPreviousLink();

        }

    }
}