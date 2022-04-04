using laborpro.pages;
using laborpro.util;

namespace laborpro.glue
{
    [Binding]
    public class VolumeDriverteps
    {

        [When(@"User navigates to the VolumeDriver tab")]
        [Given(@"User navigates to the VolumeDriver tab")]
        [Then(@"User navigates to the VolumeDriver tab")]
        public void UserNavigatesToTheListManagementsTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.UserNavigatesToTheListManagementTab ");
            VolumeDriverPage.CloseVolumeDriverForm();
            VolumeDriverPage.ClickOnStandardTab(); ;
            VolumeDriverPage.ClickOnListManagementTab();
            VolumeDriverPage.ClickOnVolumeDriver();
        }
        [Given(@"User create new VolumeDriver with below input")]
        [When(@"User create new VolumeDriver with below input")]
        [Then(@"User create new VolumeDriver with below input")]
        public void AddNewVolumeDriverWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new VolumeDriver with below input " + inputData);
            VolumeDriverPage.AddNewVolumeDriverWithGivenInput(inputData);
        }

        [Given(@"User create new VolumeDriver with below input if not exist")]
        [When(@"User create new VolumeDriver with below input if not exist")]
        [Then(@"User create new VolumeDriver with below input if not exist")]
        public void AddNewVolumeDriverWithGivenInputifnotexist(Table inputData)
        {
            LogWriter.WriteLog("Executing User create new VolumeDriver with below input " + inputData);
            VolumeDriverPage.AddNewVolumeDriverWithGivenInputifnotexist(inputData);
        }

        [Given(@"User verify created VolumeDriver by name ""([^""]*)""")]
        [When(@"User verify created VolumeDriver by name ""([^""]*)""")]
        [Then(@"User verify created VolumeDriver by name ""([^""]*)""")]
        public void UserVerifyCreatedVolumeDriver(String VolumeDriverName)
        {
            LogWriter.WriteLog("Executinge User verify created VolumeDriver by name" + VolumeDriverName);
            VolumeDriverPage.VerifyCreatedVolumeDriver(VolumeDriverName);
        }

        [Given(@"User delete created VolumeDriver by name ""([^""]*)""")]
        [When(@"User delete created VolumeDriver by name ""([^""]*)""")]
        [Then(@"User delete created VolumeDriver by name ""([^""]*)""")]
        public void UserDeleteCreatedVolumeDriver(String VolumeDriverName)
        {
            LogWriter.WriteLog("Executinge User delete created VolumeDriver by name" + VolumeDriverName);
            VolumeDriverPage.DeleteCreatedVolumeDriver(VolumeDriverName);
        }

    }
}
