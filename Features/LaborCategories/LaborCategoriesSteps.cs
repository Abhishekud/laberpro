using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.LaborCategories
{
    [Binding]
    public class LaborCategoriesSteps
    {

        [When(@"User navigates to the labor categories page")]
        [Given(@"User navigates to the labor categories page")]
        [Then(@"User navigates to the labor categories page")]
        public void NavigatesToTheLaborCategoriesTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to the labor categories page");
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

        [Given(@"User create new labor category with below input if not exist")]
        [When(@"User create new labor category with below input if not exist")]
        [Then(@"User create new labor category with below input if not exist")]
        public void AddNewLaborCategoriesWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new labor category with below input if not exist");
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

        [Given(@"User find labor category by name ""([^""]*)""")]
        [When(@"User find labor category by name ""([^""]*)""")]
        [Then(@"User find labor category by name ""([^""]*)""")]
        public void FindLaborCategoriesByName(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing Step User find labor category by name" + laborCategoriesName);
            LaborCategoriesPage.FindLaborCategoriesByName(laborCategoriesName);
        }


        [Given(@"User verify add button is not available on labor categories page")]
        [When(@"User verify add button is not available on labor categories page")]
        [Then(@"User verify add button is not available on labor categories page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step Verify Add button is not present on labor categories page");
            LaborCategoriesPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify delete button and edit option is not available on labor categories page")]
        [When(@"User verify delete button and edit option is not available on labor categories page")]
        [Then(@"User verify delete button and edit option is not available on labor categories page")]
        public void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify delete button and edit option is not available on labor categories page");
            LaborCategoriesPage.VerifyDeleteButtonIsNotPresent();
        }
        [Given(@"User verify export option is not available on labor categories page")]
        [When(@"User verify export option is not available on labor categories page")]
        [Then(@"User verify export option is not available on labor categories page")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export button is not present");
            LaborCategoriesPage.VerifyExportOptionIsNotPresent();
        }
    }
}
