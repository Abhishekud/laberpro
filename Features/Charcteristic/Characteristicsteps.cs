using laborpro.Features.Attribute;
using laborpro.pages;
using laborpro.util;

namespace laborpro.glue
{
    [Binding]
    public class CharacteristicSteps
    {

        [When(@"User navigates to the Characteristic tab")]
        [Given(@"User navigates to the Characteristic tab")]
        [Then(@"User navigates to the Characteristic tab")]
        public void UserNavigatesToTheCharacteristicTab()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserNavigatesToTheCharacteristicTab ");
            CharacteristicsPage.CloseCharacteristicForm();
            CharacteristicsPage.ClickOnStandardTab(); ;
            CharacteristicsPage.ClickOnCharacteristicTab();

        }



        [Then(@"Verify Record Of Selected Dept ""(.*)""")]
        [When(@"Verify Record Of Selected Dept ""(.*)""")]
        [Given(@"Verify Record Of Selected Dept ""(.*)""")]
        public void ThenVerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage Verify Record Of Selected Dept ");
            CharacteristicsPage.VerifyRecordOfSelectedDept(message);
        }

        [Given(@"User click on Characteristic")]
        [When(@"User click on Characteristic")]
        [Then(@"User click on Characteristic")]
        public void UserClickOnCharacteristic()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnCharacteristic ");
            CharacteristicsPage.ClickOnCharacteristic();
        }

        [Given(@"User click on Characteristic set")]
        [When(@"User click on Characteristic set")]
        [Then(@"User click on Characteristic set")]
        public void UserClickOnCharacteristicset()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnCharacteristicset ");

            CharacteristicsPage.ClickOnCharacteristicset();
        }


        [Given(@"User create new Characteristic with below input")]
        [When(@"User create new Characteristic with below input")]
        [Then(@"User create new Characteristic with below input")]
        public void AddNewCharacteristicWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage AddNewCharacteristicWithGivenInput");
            CharacteristicsPage.AddNewCharacteristicWithGivenInput(inputData);

        }



        [Given(@"User verify created Characteristic by name ""([^""]*)""")]
        [When(@"User verify created Characteristic by name ""([^""]*)""")]
        [Then(@"User verify created Characteristic by name ""([^""]*)""")]
        public void UserVerifyCreatedCharacteristic(String CharacteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserVerifyCreatedCharacteristic");
            CharacteristicsPage.VerifyCreatedCharacteristic(CharacteristicName);
        }

        [Given(@"User delete created Characteristic by name ""([^""]*)""")]
        [When(@"User delete created Characteristic by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic by name ""([^""]*)""")]
        public void UserDeleteCreatedCharacteristic(String CharacteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserDeleteCreatedCharacteristic");
            CharacteristicsPage.DeleteCreatedCharacteristic(CharacteristicName);
        }

        [Given(@"User delete created Characteristic set by name ""([^""]*)""")]
        [When(@"User delete created Characteristic set by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic set by name ""([^""]*)""")]
        public void UserDeleteCreatedCharacteristicset(String CharacteristicsetName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserDeleteCreatedCharacteristicset");
            CharacteristicsPage.DeleteCreatedCharacteristicset(CharacteristicsetName);
        }

    }
}
