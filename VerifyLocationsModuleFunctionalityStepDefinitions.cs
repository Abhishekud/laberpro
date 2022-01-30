using laberpro.pages;
using System;
using TechTalk.SpecFlow;

namespace laberpro
{
    [Binding]
    public class VerifyLocationsModuleFunctionalityStepDefinitions
    {
        [Given(@"User Enters the HomePage")]
        public void GivenUserEntersTheHomePage() => location.addlocaton();
        

        [Then(@"User navigates to the Profiling  tab")]
        public void ThenUserNavigatesToTheProfilingTab()
        {
            throw new PendingStepException();
        }

        [Then(@"User navigates to the location tab")]
        public void ThenUserNavigatesToTheLocationTab()
        {
            throw new PendingStepException();
        }

        [Then(@"User presses on Add location Button")]
        public void ThenUserPressesOnAddLocationButton()
        {
            throw new PendingStepException();
        }

        [When(@"user  enter  blank details")]
        public void WhenUserEnterBlankDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"Verify Alert Message: ""([^""]*)""")]
        public void ThenVerifyAlertMessage(string message)
        {
            throw new PendingStepException();
        }

        [Given(@"User press cancel Button")]
        public void GivenUserPressCancelButton()
        {
            location.addlocatonp();
        }

        [Then(@"User opens the form again by pressing Add Location button")]
        public void ThenUserOpensTheFormAgainByPressingAddLocationButton()
        {
            throw new PendingStepException();
        }

        [Then(@"User enters value in Name:""([^""]*)"" tag  and press submit button")]
        public void ThenUserEntersValueInNameTagAndPressSubmitButton(string labor)
        {
            throw new PendingStepException();
        }

        [Then(@"Verify validation Message: ""([^""]*)""")]
        public void ThenVerifyValidationMessage(string message)
        {
            throw new PendingStepException();
        }

        [Given(@"User press cancel Buttons")]
        public void GivenUserPressCancelButtons()
        {
            location.addlocatonq();
        }

        [Then(@"User opens the form again by pressing Add location buttons")]
        public void ThenUserOpensTheFormAgainByPressingAddLocationButtons()
        {
            throw new PendingStepException();
        }

        [Then(@"User enters value in Name:""([^""]*)"" tag the value entered is already present in database and press submit button")]
        public void ThenUserEntersValueInNameTagTheValueEnteredIsAlreadyPresentInDatabaseAndPressSubmitButton(string labor)
        {
            throw new PendingStepException();
        }

        [Given(@"User press cancel Butto")]
        public void GivenUserPressCancelButto()
        {location.editlocation();
        }

        [When(@"user click on profile it opens a profile")]
        public void WhenUserClickOnProfileItOpensAProfile()
        {
            throw new PendingStepException();
        }

        [Then(@"User enters empty value in Name:""([^""]*)"" tag   and press submit button")]
        public void ThenUserEntersEmptyValueInNameTagAndPressSubmitButton(string labor)
        {
            throw new PendingStepException();
        }

        [Given(@"User press cancel Button after previous test case")]
        public void GivenUserPressCancelButtonAfterPreviousTestCase()
        {
            location.editlocationp();
        }

        [When(@"user click on profile it open a profile")]
        public void WhenUserClickOnProfileItOpenAProfile()
        {
            throw new PendingStepException();
        }

        [Then(@"User enters existing value in Name:""([^""]*)"" tag   and press submit button")]
        public void ThenUserEntersExistingValueInNameTagAndPressSubmitButton(string labor)
        {
            throw new PendingStepException();
        }

        [Given(@"User will press previous button")]
        public void GivenUserWillPressPreviousButton()
        {
            location.editlocationq();
        }

        [When(@"user click on profile it open a profiles")]
        public void WhenUserClickOnProfileItOpenAProfiles()
        {
            throw new PendingStepException();
        }

        [Then(@"User enters  value in Name:""([^""]*)"" tag and press submit")]
        public void ThenUserEntersValueInNameTagAndPressSubmit(string labor)
        {
            throw new PendingStepException();
        }

        [Given(@"User will press cancel button")]
        public void GivenUserWillPressCancelButton()
        {
            location.delete();
        }

        [When(@"select a location it selects location and on deletes it")]
        public void WhenSelectALocationItSelectsLocationAndOnDeletesIt()
        {
            throw new PendingStepException();
        }
    }
}
