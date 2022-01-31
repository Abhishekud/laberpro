using laberpro.pages;
using System;
using TechTalk.SpecFlow;

namespace laberpro
{
    [Binding]
    public class VerifyLocationsModuleFunctionalityStepDefinitions
    {
        [Given(@"User Enters the HomePage")]
        public void GivenUserEntersTheHomePage() { }
        

        [Then(@"User navigates to the Profiling  tab")]
        public void ThenUserNavigatesToTheProfilingTab() =>location.addlocatonblank();
         

        [Then(@"User navigates to the location tab")]
        public void ThenUserNavigatesToTheLocationTab()
        {
            
        }

        [Then(@"User presses on Add location Button")]
        public void ThenUserPressesOnAddLocationButton()
        {
            
        }

        [When(@"user  enter  blank details")]
        public void WhenUserEnterBlankDetails()
        {
            
        }

        [Then(@"Verify Alert Message: ""([^""]*)""")]
        public void ThenVerifyAlertMessage(string message)
        {
            
        }

        [Given(@"User press cancel Button")]
        public void GivenUserPressCancelButton() => location.addlocatonwithcorrect();
       

        [Then(@"User opens the form again by pressing Add Location button")]
        public void ThenUserOpensTheFormAgainByPressingAddLocationButton()
        {
            
        }

        [Then(@"User enters value in Name:""([^""]*)"" tag  and press submit button")]
        public void ThenUserEntersValueInNameTagAndPressSubmitButton(string labor)
        {
            
        }

        [Then(@"Verify validation Message: ""([^""]*)""")]
        public void ThenVerifyValidationMessage(string message)
        {
            
        }

        [Given(@"User press cancel Buttons")]
        public void GivenUserPressCancelButtons()=> location.addlocatonwithexisting();
        

        [Then(@"User opens the form again by pressing Add location buttons")]
        public void ThenUserOpensTheFormAgainByPressingAddLocationButtons()
        {
            
        }

        [Then(@"User enters value in Name:""([^""]*)"" tag the value entered is already present in database and press submit button")]
        public void ThenUserEntersValueInNameTagTheValueEnteredIsAlreadyPresentInDatabaseAndPressSubmitButton(string labor)
        {
            
        }

        [Given(@"User press cancel Butto")]
        public void GivenUserPressCancelButto()=>location.editlocationblank();
       

        [When(@"user click on profile it opens a profile")]
        public void WhenUserClickOnProfileItOpensAProfile()
        {
            
        }

        [Then(@"User enters empty value in Name:""([^""]*)"" tag   and press submit button")]
        public void ThenUserEntersEmptyValueInNameTagAndPressSubmitButton(string labor)
        {
            
        }

        [Given(@"User press cancel Button after previous test case")]
        public void GivenUserPressCancelButtonAfterPreviousTestCase()=>location.editlocationcorrect();
      

        [When(@"user click on profile it open a profile")]
        public void WhenUserClickOnProfileItOpenAProfile()
        {
            
        }

        [Then(@"User enters existing value in Name:""([^""]*)"" tag   and press submit button")]
        public void ThenUserEntersExistingValueInNameTagAndPressSubmitButton(string labor)
        {
            
        }

        [Given(@"User will press previous button")]
        public void GivenUserWillPressPreviousButton()=>location.editlocationexisting();
     

        [When(@"user click on profile it open a profiles")]
        public void WhenUserClickOnProfileItOpenAProfiles()
        {
            
        }

        [Then(@"User enters  value in Name:""([^""]*)"" tag and press submit")]
        public void ThenUserEntersValueInNameTagAndPressSubmit(string labor)
        {
            
        }

        [Given(@"User will press cancel button")]
        public void GivenUserWillPressCancelButton()=>location.delete();
       

        [When(@"select a location it selects location and on deletes it")]
        public void WhenSelectALocationItSelectsLocationAndOnDeletesIt()
        {
            
        }
    }
}
