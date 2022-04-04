using laborpro.pages;
using laborpro.util;

namespace laborpro.glue
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
            DepartmentsPage.ClickOnStandardTab(); ;
            DepartmentsPage.ClickOnListManagementTab();
            AllowancesPage.WaitForAllowanceAlertCloseIfAny();
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
            LogWriter.WriteLog("Executing User create new Department with below input " + inputData);
            DepartmentsPage.AddNewDepartmentWithGivenInput(inputData);
        }

        [Given(@"User clicks cancel Button")]
        [When(@"User clicks cancel Button")]
        [Then(@"User clicks cancel Button")]
        public void UserClickCancelButton()
        {
            LogWriter.WriteLog("Exceuting Step User clicks cancel button");
            DepartmentsPage.CloseDepartmentForm();
        }

        [Given(@"User verify created Department ""([^""]*)""")]
        [When(@"User verify created Department ""([^""]*)""")]
        [Then(@"User verify created Department ""([^""]*)""")]
        public void UserVerifyCreatedDepartment(String DepartmentName)
        {
            LogWriter.WriteLog("Executing Step User verify created Department by name" + DepartmentName);
            DepartmentsPage.VerifyCreatedDepartment(DepartmentName);
        }

        [Given(@"User delete created Department ""([^""]*)""")]
        [When(@"User delete created Department ""([^""]*)""")]
        [Then(@"User delete created Department ""([^""]*)""")]
        public void UserDeleteCreatedDepartment(String DepartmentName)
        {
            LogWriter.WriteLog("Executing Step User delete created Department by name" + DepartmentName);
            DepartmentsPage.DeleteCreatedDepartment(DepartmentName);
        }

    }
}
