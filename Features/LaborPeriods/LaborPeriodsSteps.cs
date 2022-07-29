using LaborPro.Automation.shared.util;
 
namespace LaborPro.Automation.Features.LaborPeriods
{
    [Binding]
    public class LaborPeriodsSteps
    {
        [Given(@"User navigates to LaborPeriod Tab")]
        [When(@"User navigates to LaborPeriod Tab")]
        [Then(@"User navigates to LaborPeriod Tab")]
        public void GivenUserNavigatesToLaborPeriodTab()
        {
            LogWriter.WriteLog("Executing Step:User navigates to LaborPeriod Tab");
            LaborPeriodsPage.ClickOnKronosTab();
            LaborPeriodsPage.ClickOnLaborPeriodsTab();
        }

        [When(@"User selects New LaborPeriod")]
        [Then(@"User selects New LaborPeriod")]
        public void WhenUserSelectsNewLaborPeriod()
        {
            LogWriter.WriteLog("Executing Step:User selects New LaborPeriod");
            LaborPeriodsPage.AddLaborPeriod();
        }

        [Then(@"User verify page ""([^""]*)""")]
        public void ThenUserVerifyPage(string createlaborPeriod)
        {
            LogWriter.WriteLog("Executing Step: User verify page" + createlaborPeriod);
            LaborPeriodsPage.CreateLaborPeriodPageVerification(createlaborPeriod);
        }

        [Then(@"User click cancel button")]
        public void ThenUserClickCancelButton()
        {
            LogWriter.WriteLog("Executing Step: User click cancel button");
            LaborPeriodsPage.ClickOnCancelButton();
        }

        [Then(@"User click save button")]
        public void ThenUserClickSaveButton()
        {
            LogWriter.WriteLog("Executing Step:User click save button");
            LaborPeriodsPage.ClickOnSaveButton();
        }

        [When(@"User Add New LaborPeriod Using Below Input")]
        [Then(@"User Add New LaborPeriod Using Below Input")]
        public void WhenUserAddNewLaborPeriodUsingBelowInput(Table table)
        {
            LogWriter.WriteLog("Executing Step: User Add New LaborPeriod Using Below Input ");
            LaborPeriodsPage.AddLaborPeriod(table);
        }

        [Then(@"User Verify HouseOfOperation by name ""([^""]*)""")]
        public void ThenUserVerifyHouseOfOperationByName(string houseOfOperatiion)
        {
            LogWriter.WriteLog("Executing Step: User Verify HouseOfOperation by name");
            LaborPeriodsPage.VerifyHouseOfOperation(houseOfOperatiion);
        }

        [Then(@"User Add HouseOfPeriod")]
        public void ThenUserAddHouseOfPeriod()
        {
            LogWriter.WriteLog("Executing Step:User Add HouseOfPeriod ");
            LaborPeriodsPage.AddHouseOfOperation();
        }

        [Then(@"User search LaborPeriod ""([^""]*)""")]
        [When(@"User search LaborPeriod ""([^""]*)""")]
        public void ThenUserSearchLaborPeriod(string laborPeriod)
        {
            LogWriter.WriteLog("Executing Step:User search LaborPeriod " + laborPeriod);
            LaborPeriodsPage.ClearAllFilter();
            LaborPeriodsPage.SearchLaborPeriod(laborPeriod);
        }

        [Then(@"User Verify LaborPeriod By Name ""([^""]*)""")]
        public void ThenUserVerifyLaborPeriodByName(string laborPeriod)
        {
            LogWriter.WriteLog("Executing Step:User Verify LaborPeriod By Name");
            LaborPeriodsPage.VerifyLaborPeriodByName(laborPeriod);
        }

        [Then(@"User selects LaborPeriod By Name ""([^""]*)""")]
        [When(@"User selects LaborPeriod By Name ""([^""]*)""")]
        public void ThenUserSelectsLaborPeriodByName(string laborPeriod)
        {
            LogWriter.WriteLog("Executing Step: User selects LaborPeriod By Name" + laborPeriod);
            LaborPeriodsPage.SelectLaborPeriod(laborPeriod);
        }

        [Then(@"User delete created LaborPeriod")]
        public void ThenUserDeleteCreatedLaborPeriodByName()
        {
            LogWriter.WriteLog("Executing Step:User delete created LaborPeriod");
            LaborPeriodsPage.DeleteLaborPeriod();

        }

        [Then(@"User Delete record If Exist ""([^""]*)""")]
        public void ThenUserDeleteRecordIfExist(string record)
        {
            LogWriter.WriteLog("User Delete record If Exist " + record);
            LaborPeriodsPage.DeleteRecordIfExist(record);
        }

        [Then(@"Verify Validation message :""([^""]*)""")]
        [When(@"Verify Validation message :""(.*)""")]
        public void ThenVerifyValidationMessageForLaborPeriod(string message)
        {
            LogWriter.WriteLog("Verify Validation message :" + message);
            LaborPeriodsPage.VerifyAddLaborPeriodErrorMessage(message);
        }
        [Then(@"User verify add button is not available on labor period page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("User verify add button is not available on labor period page");
            LaborPeriodsPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify export option is available on labor period page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("User verify export option is available on labor period page");
            LaborPeriodsPage.VerifyExportOptionIsPresent();
        }

        [Then(@"User verify delete button and edit option is not available on labor period page")]
        public void VerifyDeleteButtonAndEditOptionIsNotAvailable()
        {
            LogWriter.WriteLog("User verify delete button and edit option is not available on labor period page");
            LaborPeriodsPage.VerifyDeleteButtonAndEditOptionIsNotPresent();
            LaborPeriodsPage.ClickOnPreviousLink();
        }

    }
}
