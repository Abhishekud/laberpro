using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Characteristic
{
    [Binding]
    public class CharacteristicSteps
    {

        [When(@"User navigates to the Characteristic tab")]
        [Given(@"User navigates to the Characteristic tab")]
        [Then(@"User navigates to the Characteristic tab")]
        public void NavigatesToTheCharacteristicTab()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserNavigatesToTheCharacteristicTab ");
            CharacteristicsPage.CloseCharacteristicForm();
            CharacteristicsPage.ClickOnStandardTab(); ;
            CharacteristicsPage.ClickOnCharacteristicTab();

        }

        [Then(@"Verify Record Of Selected Dept ""(.*)""")]
        [When(@"Verify Record Of Selected Dept ""(.*)""")]
        [Given(@"Verify Record Of Selected Dept ""(.*)""")]
        public void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage Verify Record Of Selected Dept ");
            CharacteristicsPage.VerifyRecordOfSelectedDept(message);
        }

        [Given(@"User click on Characteristic")]
        [When(@"User click on Characteristic")]
        [Then(@"User click on Characteristic")]
        public void ClickOnCharacteristic()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnCharacteristic ");
            CharacteristicsPage.ClickOnCharacteristic();
        }

        [Given(@"User click on Characteristic set")]
        [When(@"User click on Characteristic set")]
        [Then(@"User click on Characteristic set")]
        public void ClickOnCharacteristicSet()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnCharacteristicset ");
            CharacteristicsPage.ClickOnCharacteristicSet();
        }

        [Given(@"User create new Characteristic with below input")]
        [When(@"User create new Characteristic with below input")]
        [Then(@"User create new Characteristic with below input")]
        public void AddNewCharacteristicWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage AddNewCharacteristicWithGivenInput");
            CharacteristicsPage.AddNewCharacteristicWithGivenInput(inputData);
        }

        [Given(@"User create new Characteristic with below input if not exist")]
        [When(@"User create new Characteristic with below input if not exist")]
        [Then(@"User create new Characteristic with below input if not exist")]
        public void CharacteristicWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing step: User add  Characteristic using below input if not exist - " + inputData);
            CharacteristicsPage.CharacteristicWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created Characteristic by name ""([^""]*)""")]
        [When(@"User verify created Characteristic by name ""([^""]*)""")]
        [Then(@"User verify created Characteristic by name ""([^""]*)""")]
        public void VerifyCreatedCharacteristic(String CharacteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserVerifyCreatedCharacteristic");
            CharacteristicsPage.VerifyCreatedCharacteristic(CharacteristicName);
        }
        [Given(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        [When(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        [Then(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        public void VerifyCreatedCharacteristicSet(String CharacteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserVerifyCreatedCharacteristic");
            CharacteristicsPage.VerifyCreatedCharacteristicSet(CharacteristicName); 
        }

        [Given(@"User delete created Characteristic by name ""([^""]*)""")]
        [When(@"User delete created Characteristic by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic by name ""([^""]*)""")]
        public void DeleteCreatedCharacteristic(String CharacteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserDeleteCreatedCharacteristic");
            CharacteristicsPage.DeleteCreatedCharacteristic(CharacteristicName);
        }

        [Given(@"User delete created Characteristic set by name ""([^""]*)""")]
        [When(@"User delete created Characteristic set by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic set by name ""([^""]*)""")]
        public void DeleteCreatedCharacteristicSet(String CharacteristicsetName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserDeleteCreatedCharacteristicset");
            CharacteristicsPage.DeleteCreatedCharacteristicSet(CharacteristicsetName);
        }

        [Given(@"User delete Characteristic set ""([^""]*)"" if exist")]
        [When(@"User delete Characteristic set ""([^""]*)"" if exist")]
        [Then(@"User delete Characteristic set ""([^""]*)"" if exist")]
        public void DeleteCharacteristicSetIfExist(String CharacteristicName)
        {
            LogWriter.WriteLog("Executing Step User delete created Characteristic by name" + CharacteristicName);
            CharacteristicsPage.DeleteCharacteristicSetIfExist(CharacteristicName);
        }

        [Given(@"User delete Characteristic ""([^""]*)"" if exist")]
        [When(@"User delete Characteristic ""([^""]*)"" if exist")]
        [Then(@"User delete Characteristic ""([^""]*)"" if exist")]
        public void DeleteCharacteristicIfExist(String CharacteristicName)
        {
            LogWriter.WriteLog("Executing Step User delete created Characteristic by name" + CharacteristicName);
            CharacteristicsPage.DeleteCharacteristicIfExist(CharacteristicName);
        }

    }
}
