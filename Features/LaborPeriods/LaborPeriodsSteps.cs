using LaborPro.Automation.shared.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborPro.Automation.Features.LaborPeriods
{
    [Binding]
    public class LaborPeriodsSteps
    {
        [Given(@"User navigates to LaborPeriod Tab")]
        public void GivenUserNavigatesToLaborPeriodTab()
        {
            LogWriter.WriteLog("Executing Step:User navigates to LaborPeriod Tab");
            LaborPeriodsPage.clickOnKronosTab();
            LaborPeriodsPage.clickOnLaborPeriodsTab();
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
            LogWriter.WriteLog("Executing Step: User verify page"+ createlaborPeriod);
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
        public void ThenUserSearchLaborPeriod(string LaborPeriod)
        {
            LogWriter.WriteLog("Executing Step:User search LaborPeriod " + LaborPeriod);
            LaborPeriodsPage.ClearAllFilter();
            LaborPeriodsPage.SearchLaborPeriod(LaborPeriod);
        }

        [Then(@"User Verify LaborPeriod By Name ""([^""]*)""")]
        public void ThenUserVerifyLaborPeriodByName(string LaborPeriod)
        {
            LogWriter.WriteLog("Executing Step:User Verify LaborPeriod By Name");
            LaborPeriodsPage.VerifyLaborPeriodByName(LaborPeriod);
        }

        [Then(@"User selects LaborPeriod By Name ""([^""]*)""")]
        public void ThenUserSelectsLaborPeriodByName(string LaborPeriod)
        {
            LogWriter.WriteLog("Executing Step: User selects LaborPeriod By Name" + LaborPeriod);
            LaborPeriodsPage.SelectLaborPeriod(LaborPeriod);
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
            LaborPeriodsPage.DeleteRecordIfExist(record);
        }
        [Then(@"Verify Validation Message for LaborPeriod:""([^""]*)""")]
        public void ThenVerifyValidationMessageForLaborPeriod(string message)
        {
            LaborPeriodsPage.VerifyAddLaborPeriodErrorMessage(message);
           
        }




    }
}
