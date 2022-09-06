using LaborPro.Automation.Features.Allowances;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Department
{
    [Binding]
    public class DepartmentSteps
    {

        [When(@"User navigates to the List Management tab")]
        [Given(@"User navigates to the List Management tab")]
        [Then(@"User navigates to the List Management tab")]
        public void UserNavigatesToTheListManagementTab()
        {
            LogWriter.WriteLog("Executing Step: User navigates to the List Management tab  ");
            DepartmentsPage.CloseDepartmentForm();
            DepartmentsPage.ClickOnStandardTab();
            DepartmentsPage.ClickOnListManagementTab();
            AllowancePage.WaitForAllowanceAlertCloseIfAny();
        }

        [Given(@"User selects Department")]
        [When(@"User selects Department")]
        [Then(@"User selects Department")]
        public void UserClickOnDepartment()
        { 
            LogWriter.WriteLog("Executing Step: User selects Department");
            DepartmentsPage.ClickOnDepartment();
        }

        [Given(@"User create new Department with below input if not exist")]
        [When(@"User create new Department with below input if not exist")]
        [Then(@"User create new Department with below input if not exist")]
        public void AddNewDepartmentWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User create new Department with below input if not exist - " + inputData);
            DepartmentsPage.AddNewDepartmentWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User create new Department with below input")]
        [When(@"User create new Department with below input")]
        [Then(@"User create new Department with below input")]
        public void AddNewDepartmentWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new Department with below input "+inputData);
            DepartmentsPage.AddNewDepartmentWithGivenInput(inputData);
        }

        [Given(@"User clicks cancel Button")]
        [When(@"User clicks cancel Button")]
        [Then(@"User clicks cancel Button")]
        public void UserClickCancelButton()
        {
            LogWriter.WriteLog("Executing Step User clicks cancel button");
            DepartmentsPage.CloseDepartmentForm();
        }

        [Given(@"User verify created Department ""([^""]*)""")]
        [When(@"User verify created Department ""([^""]*)""")]
        [Then(@"User verify created Department ""([^""]*)""")]
        public void UserVerifyCreatedDepartment(string departmentName) {
            LogWriter.WriteLog("Executing Step User verify created Department by name" + departmentName);
            DepartmentsPage.VerifyCreatedDepartment(departmentName); 
        }

        [Given(@"User delete created Department ""([^""]*)""")]
        [When(@"User delete created Department ""([^""]*)""")]
        [Then(@"User delete created Department ""([^""]*)""")]
        public void UserDeleteCreatedDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing Step User delete created Department by name" + departmentName);
            DepartmentsPage.DeleteCreatedDepartment(departmentName);
        }

        [Given(@"User delete Department ""([^""]*)"" if exist")]
        [When(@"User delete Department ""([^""]*)"" if exist")]
        [Then(@"User delete Department ""([^""]*)"" if exist")]
        public void UserDeleteDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing Step User delete created Department by name" + departmentName);
            DepartmentsPage.DeleteDepartmentIfExist(departmentName);
        }
        [Given(@"User verify add button is not available on department page")]
        [When(@"User verify add button is not available on department page")]
        [Then(@"User verify add button is not available on department page")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on department page");
            DepartmentsPage.VerifyAddButtonIsNotPresent();
        }
        [Given(@"User verify export option is not available on department page")]
        [When(@"User verify export option is not available on department page")]
        [Then(@"User verify export option is not available on department page")]
        public void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify export option is not available on department page ");
            DepartmentsPage.VerifyExportOptionIsNotPresent();
        }
        [Given(@"User verify delete button and edit option is not available for department record ""([^""]*)""")]
        [When(@"User verify delete button and edit option is not available for department record ""([^""]*)""")]
        [Then(@"User verify delete button and edit option is not available for department record ""([^""]*)""")]
        public void VerifyDeleteButtonIsNotPresent(string departmentName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button and edit option is not available for department record ");
            DepartmentsPage.VerifyDeleteButtonIsNotPresent(departmentName);
        }

    }
}
