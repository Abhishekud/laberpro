using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.LaborCategories
{
    [Binding]
    public class LaborCategoriesSteps
    {

        [When(@"User navigates to the LaborCategories tab")]
        [Given(@"User navigates to the LaborCategories tab")]
        [Then(@"User navigates to the LaborCategories tab")]
        public void NavigatesToTheLaborCategoriesTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the LaborCategories tab");
            LaborCategoriesPage.CloseLaborCategoriesForm();
            LaborCategoriesPage.ClickOnStandardTab();
            LaborCategoriesPage.ClickOnListManagementTab();
            LaborCategoriesPage.ClickOnLaborCategories();

        }  
        [Given(@"User create new LaborCategories with below input")]
        [When(@"User create new LaborCategories with below input")]
        [Then(@"User create new LaborCategories with below input")]
        public void AddNewLaborCategoriesWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new LaborCategories with below input");
            LaborCategoriesPage.AddNewLaborCategoriesWithGivenInput(inputData);
        }

        [Given(@"User create new LaborCategories with below input if not exist")]
        [When(@"User create new LaborCategories with below input if not exist")]
        [Then(@"User create new LaborCategories with below input if not exist")]
        public void AddNewLaborCategoriesWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new LaborCategories with below input if not exist");
            LaborCategoriesPage.AddNewLaborCategoriesWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created LaborCategories by name ""([^""]*)""")]
        [When(@"User verify created LaborCategories by name ""([^""]*)""")]
        [Then(@"User verify created LaborCategories by name ""([^""]*)""")]
        public void VerifyCreatedLaborCategories(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing Step User verify created LaborCategories by name");
            LaborCategoriesPage.VerifyCreatedLaborCategories(laborCategoriesName);
        }

        [Given(@"User delete created LaborCategories by name ""([^""]*)""")]
        [When(@"User delete created LaborCategories by name ""([^""]*)""")]
        [Then(@"User delete created LaborCategories by name ""([^""]*)""")]
        public void DeleteCreatedLaborCategories(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing Step User delete created LaborCategories by name");
            LaborCategoriesPage.DeleteCreatedLaborCategories(laborCategoriesName);
        }  

        [Given(@"User delete LaborCategories ""([^""]*)"" if exist")]
        [When(@"User delete LaborCategories ""([^""]*)"" if exist")]
        [Then(@"User delete LaborCategories ""([^""]*)"" if exist")]
        public void DeleteLaborCategoriesIfExist(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing Step User delete created LaborCategories by name" + laborCategoriesName);
            LaborCategoriesPage.DeleteLaborCategoriesIfExist(laborCategoriesName);
        }

        [Given(@"User find LaborCategories by name ""([^""]*)""")]
        [When(@"User find LaborCategories by name ""([^""]*)""")]
        [Then(@"User find LaborCategories by name ""([^""]*)""")]
        public void FindLaborCategoriesByName(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing Step User find LaborCategories by name " + laborCategoriesName);
            LaborCategoriesPage.FindLaborCategoriesByName(laborCategoriesName);
        }


        [Given(@"Verify add button is not present on LaborCategories page")]
        [When(@"Verify add button is not present on LaborCategories page")]
        [Then(@"Verify add Button is not present on LaborCategories page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step Verify Add button is not present on LaborCategories page");
            LaborCategoriesPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"Verify delete Button is not present on LaborCategories page")]
        [When(@"Verify delete Button is not present on LaborCategories page")]
        [Then(@"Verify delete Button is not present on LaborCategories page")]
        public void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Delete Button is not present on LaborCategories page");
            LaborCategoriesPage.VerifyDeleteButtonIsNotPresent();
        }
        [Given(@"Verify export option is not Present on LaborCategories page")]
        [When(@"Verify export option is not Present on LaborCategories page")]
        [Then(@"Verify export option is not Present on LaborCategories page")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export button is not present");
            LaborCategoriesPage.VerifyExportOptionIsNotPresent();
        }
    }
}
