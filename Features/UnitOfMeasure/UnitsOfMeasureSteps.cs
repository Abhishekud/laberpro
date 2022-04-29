using LaborPro.Automation.shared.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborPro.Automation.Features.UnitOfMeasure
{
    [Binding]
    public class UnitsOfMeasureSteps
    {
        [Given(@"User selects ""([^""]*)""")]
        [When(@"User selects ""([^""]*)""")]
        [Then(@"User selects ""([^""]*)""")]
        public void SelectunitsOfMeasure(string value)
        {
            LogWriter.WriteLog("Executing Step User selects Units of Measure");
            UnitsOfMeasurePage.SelectListMangement(value);
        }

        [Given(@"User Selects Created Department ""([^""]*)""")]
        [When(@"User Selects Created Department ""([^""]*)""")]
        [Then(@"User Selects Created Department ""([^""]*)""")]
        public void SelectDepartment(string DeptName)
        {
            LogWriter.WriteLog("Executing Step User Selects Created Department " + DeptName);
            UnitsOfMeasurePage.SelectCreatedDepartment(DeptName);

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
        public void VerifyUnitOfMeasure(string UOM)
        {
            LogWriter.WriteLog("Executing Step User verify Added Unit of Measure" + UOM);
            UnitsOfMeasurePage.VerifyCreatedUnitOfMeasure(UOM);
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
        public void UserDeleteUnitOfMeasure(String UnitOfMeasureName)
        {
            LogWriter.WriteLog("Executing Step User delete created UnitOfMeasure by name" + UnitOfMeasureName);
            UnitsOfMeasurePage.DeleteUnitOfMeasureifexist(UnitOfMeasureName);
        }

    }
}
