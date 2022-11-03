using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Allowances
{
    [Binding]
    public class AllowanceSteps
    {
      
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

        
        [Given(@"User verify created allowance name ""([^""]*)""")]
        [When(@"User verify created allowance name ""([^""]*)""")]
        [Then(@"User verify created allowance name ""([^""]*)""")]
        public void UserVerifyCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing step: User verify created allowance name "+allowanceName);
            AllowancePage.VerifyCreatedAllowance(DataCache.Read(allowanceName));
            AllowancePage.ClickOnPreviousLink();
        }

        [Given(@"User click on cancel button")]
        [When(@"User click on cancel button")]
        [Then(@"User click on cancel button")]
        public void UserWillPressCancelButton()
        {
            LogWriter.WriteLog("Executing step: User click on cancel button");
            AllowancePage.CloseAllowanceForm();
        }

        [When(@"User click on previous link")]
        [Then(@"User click on previous link")]
        public static void ClickOnPreviousButton()
        {
            LogWriter.WriteLog("Executing step: User click on previous link");
            AllowancePage.ClickOnPreviousLink();
        }

        
        [Then(@"User verify add button is not available on allowance page")]
        [When(@"User verify add button is not available on allowance page")]
        [Given(@"User verify add button is not available on allowance page")]
        public void VerifyAddButtonIsNotAvailableOnAllowancePage()
        {
            LogWriter.WriteLog("Executing step: User verify add button is not available on allowance page");
            AllowancePage.CloseAllowanceForm();
            AllowancePage.ClickOnStandardTab();
            AllowancePage.ClickOnAllowanceTab();
            AllowancePage.ClickOnCalculatorTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify download allowance details report for allowance: ""([^""]*)""")]
        [Given(@"User verify download allowance details report for allowance: ""([^""]*)""")]
        [When(@"User verify download allowance details report for allowance: ""([^""]*)""")]
        public void VerifyDownloadAllowanceDetailsReportForAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing step: User verify download allowance details report for allowance"+ allowanceName);
            AllowancePage.VerifyDownloadAllowanceDetailsReportForAllowance(DataCache.Read(allowanceName));
            
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

        [Given(@"User add allowance without name")]
        [When(@"User add allowance without name")]
        [Then(@"User add allowance without name")]
        public void AddAllowanceWithoutName()
        {
            LogWriter.WriteLog("Executing Step: User add allowance without name");
            AllowancePage.CloseAllowanceForm();
            AllowancePage.ClickOnStandardTab();
            AllowancePage.ClickOnAllowanceTab();
            AllowancePage.ClickOnCalculatorTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.AddAllowanceWithoutName();
        }

        [Given(@"User verify validation message: ""([^""]*)"" on allowance popup")]
        [When(@"User verify validation message: ""([^""]*)"" on allowance popup")]
        [Then(@"User verify validation message: ""([^""]*)"" on allowance popup")]
        public void VerifyValidationMessageOnAllowancePopup(string message)
        {
            LogWriter.WriteLog("Executing Step: User verify validation message: " + message + "on allowance popup");
            AllowancePage.VerifyAddAllowanceErrorMessage(message);
        }

        [Given(@"User add new allowance with name ""([^""]*)"" and without paid time")]
        [When(@"User add new allowance with name ""([^""]*)"" and without paid time")]
        [Then(@"User add new allowance with name ""([^""]*)"" and without paid time")]
        public void AddNewAllowanceWithNameAndWithoutPaidTime(string name)
        {
            LogWriter.WriteLog("Executing Step: User add new allowance with name " + name + "and without paid time");
            AllowancePage.CloseAllowanceForm();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.AddAllowanceWithNameAndWithoutPaidTime(name);
        }

        [Given(@"User add new allowance with name ""([^""]*)"" and paid time ""([^""]*)""")]
        [When(@"User add new allowance with name ""([^""]*)"" and paid time ""([^""]*)""")]
        [Then(@"User add new allowance with name ""([^""]*)"" and paid time ""([^""]*)""")]
        public void AddNewAllowanceWithNameAndPaidTime(string name, string paidTime)
        {
            LogWriter.WriteLog("Executing Step: User add new allowance with name " + name + " and paid time " + paidTime);
            AllowancePage.CloseAllowanceForm();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.AddAllowanceWithNameAndPaidTime(name, paidTime);
        }

        [Given(@"User add new allowance with below input")]
        [When(@"User add new allowance with below input")]
        [Then(@"User add new allowance with below input")]
        public void AddNewAllowanceWithBelowInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User add new allowance with below input " + inputData);
            AllowancePage.CloseAllowanceForm();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.AddNewAllowance(inputData, false);
        }
        [Given(@"User add new allowance with below input to verify alert message")]
        [When(@"User add new allowance with below input to verify alert message")]
        [Then(@"User add new allowance with below input to verify alert message")]
        public void AddNewAllowanceToVerifyAlertMessage(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User add new allowance with below input to verify alert message" + inputData);
            AllowancePage.CloseAllowanceForm();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.AddNewAllowance(inputData, true);
        }

        [Given(@"User verify error alert message: ""([^""]*)"" on allowance page")]
        [When(@"User verify error alert message: ""([^""]*)"" on allowance page")]
        [Then(@"User verify error alert message: ""([^""]*)"" on allowance page")]
        public void VerifyErrorAlertMessageInAllowancePage(string message)
        {
            LogWriter.WriteLog("Executing Step: User verify error alert message: " + message + "on allowance page");
            AllowancePage.VerifyErrorAlertMessage(message);
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.CloseAllowanceForm();

        }

        [Given(@"User delete record of allowance ""([^""]*)""")]
        [When(@"User delete record of allowance ""([^""]*)""")]
        [Then(@"User delete record of allowance ""([^""]*)""")]
        public void DeleteAllowance(string allowance)
        {
            LogWriter.WriteLog("Executing Step: User delete record of allowance " + allowance);
            AllowancePage.CloseAllowanceForm();
            AllowancePage.ClickOnStandardTab();
            AllowancePage.ClickOnAllowanceTab();
            AllowancePage.ClickOnCalculatorTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.UserDeleteCreatedAllowance(DataCache.Read(allowance));

        }
        [Given(@"User add new allowance with duplicate name ""([^""]*)"" and paid time ""([^""]*)""")]
        [When(@"User add new allowance with duplicate name ""([^""]*)"" and paid time ""([^""]*)""")]
        [Then(@"User add new allowance with duplicate name ""([^""]*)"" and paid time ""([^""]*)""")]
        public void AddNewAllowanceWithDuplicateNameAndPaidTime(string name, string paidTime)
        {
            LogWriter.WriteLog("Executing Step: User add new allowance with duplicate name "+ name + "and paid time" + paidTime);
            AllowancePage.AddAllowanceWithDuplicateName(DataCache.Read(name), paidTime);

        }

        [Given(@"User add allowance with name ""([^""]*)"" and paid time ""([^""]*)"" for view only")]
        [When(@"User add allowance with name ""([^""]*)"" and paid time ""([^""]*)"" for view only")]
        [Then(@"User add allowance with name ""([^""]*)"" and paid time ""([^""]*)"" for view only")]
        public void AddAllowanceWithNameAndPaidTime(string name, string paidTime)
        {
            LogWriter.WriteLog("Executing Step: User add allowance with name " + name + " and paid time " + paidTime);
            AllowancePage.CloseAllowanceForm();
            AllowancePage.ClickOnStandardTab();
            AllowancePage.ClickOnAllowanceTab();
            AllowancePage.ClickOnCalculatorTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
            AllowancePage.AddAllowanceWithNameAndPaidTime(name, paidTime);
            AllowancePage.ClickOnPreviousLink();
        }

    }
}