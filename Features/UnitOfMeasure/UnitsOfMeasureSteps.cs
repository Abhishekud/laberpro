using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.UnitOfMeasure
{
    [Binding]
    public class UnitsOfMeasureSteps
    {
        [Given(@"User selects UnitOfMeasure")]
        [When(@"User selects UnitOfMeasure")]
        [Then(@"User selects UnitOfMeasure")]
        public void SelectUnitsOfMeasure()
        {
            LogWriter.WriteLog("Executing Step User selects Units of Measure");
            UnitsOfMeasurePage.ClickOnUnitOfMeasure();
        }

        [Given(@"User Selects Created Department ""([^""]*)""")]
        [When(@"User Selects Created Department ""([^""]*)""")]
        [Then(@"User Selects Created Department ""([^""]*)""")]
        public void SelectDepartment(string deptName)
        {
            LogWriter.WriteLog("Executing Step User Selects Created Department " + deptName);
            UnitsOfMeasurePage.SelectCreatedDepartment(deptName);

        }

        [Given(@"User create new UnitOfMeasure with below input if not exist")]
        [When(@"User create new UnitOfMeasure with below input if not exist")]
        [Then(@"User create new UnitOfMeasure with below input if not exist")]
        public void AddNewUnitOfMeasureWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new UnitOfMeasure with below input if not exist - " + inputData);
            UnitsOfMeasurePage.AddNewUnitOfMeasureWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User adds Unit Of Measure using below input")]
        [When(@"User adds Unit Of Measure using below input")]
        [Then(@"User adds Unit Of Measure using below input")]
        public void AddUnitOfMeasure(Table inputData )
        {
            LogWriter.WriteLog("Executing Step User adds Unit Of Measure using below input" + inputData);
            UnitsOfMeasurePage.AddUnitOfMeasureWihGivenInput(inputData);    
        }

        [Given(@"User verify Added Unit of Measure ""([^""]*)""")]
        [When(@"User verify Added Unit of Measure ""([^""]*)""")]
        [Then(@"User verify Added Unit of Measure ""([^""]*)""")]
        public void VerifyUnitOfMeasure(string uom)
        {
            LogWriter.WriteLog("Executing Step User verify Added Unit of Measure" + uom);
            UnitsOfMeasurePage.VerifyCreatedUnitOfMeasure(uom);
        }

        [Then(@"User delete created Unit Of Measure")]
        public void DeleteCreatedUnitOfMeasure()
        {
            LogWriter.WriteLog("Executing Step User delete created Unit Of Measure");
            UnitsOfMeasurePage.DeleteCreatedUnitOfMeasure();
        }

        [Then(@"User verify the Department record ""([^""]*)""")]
        public void VerifyNoRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing Step User verify the Department record" + message);
            UnitsOfMeasurePage.VerifyRecordOfSelectedDept(message);
        }

        [Given(@"User delete UnitOfMeasure ""([^""]*)"" if exist")]
        [When(@"User delete UnitOfMeasure ""([^""]*)"" if exist")]
        [Then(@"User delete UnitOfMeasure ""([^""]*)"" if exist")]
        public void UserDeleteUnitOfMeasure(string unitOfMeasureName)
        {
            LogWriter.WriteLog("Executing Step User delete created UnitOfMeasure by name" + unitOfMeasureName);
            UnitsOfMeasurePage.DeleteUnitOfMeasureIfExist(unitOfMeasureName);
        }
        [Given(@"User verify add button is not present on units of measure page")]
        [When(@"User verify add button is not present on units of measure page")]
        [Then(@"User verify add button is not present on units of measure page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not present on units of measure page");
            UnitsOfMeasurePage.VerifyAddButtonIsNotAvailable();
        }
        [Given(@"User verify export option is not present on units of measure page")]
        [When(@"User verify export option is not present on units of measure page")]
        [Then(@"User verify export option is not present on units of measure page")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export button is not present on units of measure page ");
            UnitsOfMeasurePage.VerifyExportOptionIsNotAvailable();
        }
        [Given(@"User verify delete button and edit option is not present for record ""([^""]*)"" on units of measure page")]
        [When(@"User verify delete button and edit option is not present for record ""([^""]*)"" on units of measure page")]
        [Then(@"User verify delete button and edit option is not present for record ""([^""]*)"" on units of measure page")]
        public void VerifyDeleteButtonIsNotPresent(string unitOfMeasureName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button and edit option is not present for record" + unitOfMeasureName + " on units of measure page");
            UnitsOfMeasurePage.VerifyDeleteButtonIsNotAvailable(unitOfMeasureName);
        }

    }
}
