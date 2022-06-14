using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.JobClasses
{
    [Binding]
    public class JobClassesSteps
    {

        [When(@"User navigates to the JobClasses tab")]
        [Given(@"User navigates to the JobClasses tab")]
        [Then(@"User navigates to the JobClasses tab")]
        public void NavigatesToTheJobClassesTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the JobClasses tab");
            JobClassesPage.CloseJobClassesForm();
            JobClassesPage.ClickOnStandardTab();
            JobClassesPage.ClickOnListManagementTab();
            JobClassesPage.ClickOnJobClasses();

        }
        [Given(@"User create new JobClasses with below input")]
        [When(@"User create new JobClasses with below input")]
        [Then(@"User create new JobClasses with below input")]
        public void AddNewJobClassesWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new JobClasses with below input");
            JobClassesPage.AddNewJobClassesWithGivenInput(inputData);
        }

        [Given(@"User create new JobClasses with below input if not exist")]
        [When(@"User create new JobClasses with below input if not exist")]
        [Then(@"User create new JobClasses with below input if not exist")]
        public void AddNewJobClassesWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new JobClasses with below input if not exist");
            JobClassesPage.AddNewJobClassesWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created JobClasses by name ""([^""]*)""")]
        [When(@"User verify created JobClasses by name ""([^""]*)""")]
        [Then(@"User verify created JobClasses by name ""([^""]*)""")]
        public void VerifyCreatedJobClasses(string jobClassesName)
        {
            LogWriter.WriteLog("Executing Step User verify created JobClasses by name");
            JobClassesPage.VerifyCreatedJobClasses(jobClassesName);
        }

        [Given(@"User delete created JobClasses by name ""([^""]*)""")]
        [When(@"User delete created JobClasses by name ""([^""]*)""")]
        [Then(@"User delete created JobClasses by name ""([^""]*)""")]
        public void DeleteCreatedJobClasses(string jobClassesName)
        {
            LogWriter.WriteLog("Executing Step User delete created JobClasses by name");
            JobClassesPage.DeleteCreatedJobClasses(jobClassesName);
        }

        [Given(@"User delete JobClasses ""([^""]*)"" if exist")]
        [When(@"User delete JobClasses ""([^""]*)"" if exist")]
        [Then(@"User delete JobClasses ""([^""]*)"" if exist")]
        public void DeleteJobClassesIfExist(string jobClassesName)
        {
            LogWriter.WriteLog("Executing Step User delete created JobClasses by name" + jobClassesName);
            JobClassesPage.DeleteJobClassesIfExist(jobClassesName);
        }

        [Given(@"User find JobClasses by name ""([^""]*)""")]
        [When(@"User find JobClasses by name ""([^""]*)""")]
        [Then(@"User find JobClasses by name ""([^""]*)""")]
        public void FindJobClassesByName(string jobClassesName)
        {
            LogWriter.WriteLog("Executing Step User find JobClasses by name " + jobClassesName);
            JobClassesPage.FindJobClassesByName(jobClassesName);
        }


        [Given(@"Verify add button is not present on JobClasses page")]
        [When(@"Verify add button is not present on JobClasses page")]
        [Then(@"Verify add Button is not present on JobClasses page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step Verify Add button is not present on JobClasses page");
            JobClassesPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"Verify delete Button is not present on JobClasses page")]
        [When(@"Verify delete Button is not present on JobClasses page")]
        [Then(@"Verify delete Button is not present on JobClasses page")]
        public void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Delete Button is not present on JobClasses page");
            JobClassesPage.VerifyDeleteButtonIsNotPresent();
        }
        [Given(@"Verify export option is not Present on JobClasses page")]
        [When(@"Verify export option is not Present on JobClasses page")]
        [Then(@"Verify export option is not Present on JobClasses page")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export button is not present");
            JobClassesPage.VerifyExportOptionIsNotPresent();
        }
    }
}
