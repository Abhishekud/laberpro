using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.JobClasses
{
    [Binding]
    public class JobClassesSteps
    {

        [When(@"User navigates to the job classes page")]
        [Given(@"User navigates to the job classes page")]
        [Then(@"User navigates to the job classes page")]
        public void NavigatesToTheJobClassesTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the job classes page");
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

        [Given(@"User create new job classes with below input if not exist")]
        [When(@"User create new job classes with below input if not exist")]
        [Then(@"User create new job classes with below input if not exist")]
        public void AddNewJobClassesWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new job classes with below input if not exist");
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

        [Given(@"User delete job class ""([^""]*)"" if exist")]
        [When(@"User delete job class ""([^""]*)"" if exist")]
        [Then(@"User delete job class ""([^""]*)"" if exist")]
        public void DeleteJobClassesIfExist(string jobClassesName)
        {
            LogWriter.WriteLog("Executing Step User delete created JobClasses by name" + jobClassesName);
            JobClassesPage.DeleteJobClassesIfExist(jobClassesName);
        }

        [Given(@"User find job class by name ""([^""]*)""")]
        [When(@"User find job class by name ""([^""]*)""")]
        [Then(@"User find job class by name ""([^""]*)""")]
        public void FindJobClassesByName(string jobClassesName)
        {
            LogWriter.WriteLog("Executing Step User find job class by name" + jobClassesName);
            JobClassesPage.FindJobClassesByName(jobClassesName);
        }


        [Given(@"User verify add button is not available on job classes page")]
        [When(@"User verify add button is not available on job classes page")]
        [Then(@"User verify add button is not available on job classes page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not available on job classes page");
            JobClassesPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify delete button and edit option is not available on job classes page")]
        [When(@"User verify delete button and edit option is not available on job classes page")]
        [Then(@"User verify delete button and edit option is not available on job classes page")]
        public void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify delete button and edit option is not available on job classes page");
            JobClassesPage.VerifyDeleteButtonIsNotPresent();
        }
        [Given(@"User verify export option is not available on job classes page")]
        [When(@"User verify export option is not available on job classes page")]
        [Then(@"User verify export option is not available on job classes page")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User User verify export button is not available on job classes page");
            JobClassesPage.VerifyExportOptionIsNotPresent();
        }
    }
}
