using laberpro.pages;
using System;
using TechTalk.SpecFlow;

namespace laberpro
{
    [Binding]
    public class VerifyLocationsModuleFunctionalityStepDefinitions
    {
        [When(@"user enter  blank details")]
        public void WhenUserEnterBlankDetails()
        {
            location.addlocaton();
        }

        [When(@"user enter existing details it show error")]
        public void WhenUserEnterExistingDetailsItShowError()
        {
           location.addlocatonp();
        }

        [When(@"user enter correct details it shows error")]
        public void WhenUserEnterCorrectDetailsItShowsError()
        {
            location.addlocatonq();
        }

        [When(@"user enter edit  blank details")]
        public void WhenUserEnterEditBlankDetails()
        {
            location.editlocation();
        }

        [When(@"user enter edit existing details it show error")]
        public void WhenUserEnterEditExistingDetailsItShowError()
        {
          location.editlocationp(); 
        }

        [When(@"user enter edit correct details it shows error")]
        public void WhenUserEnterEditCorrectDetailsItShowsError()
        {
        location.editlocationq();
        }

        [When(@"seect a location it selects location and on delete it")]
        public void WhenSeectALocationItSelectsLocationAndOnDeleteIt()
        {
           location.delete();
        }
    }
}
