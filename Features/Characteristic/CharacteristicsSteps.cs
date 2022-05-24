using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Characteristic
{
    [Binding]
    public class CharacteristicsSteps
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
        [Given(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        [When(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        [Then(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        public void VerifyCreatedCharacteristicSet(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserVerifyCreatedCharacteristic");
            CharacteristicsPage.VerifyCreatedCharacteristicSet(characteristicName);
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
        public void VerifyCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserVerifyCreatedCharacteristic");
            CharacteristicsPage.VerifyCreatedCharacteristic(characteristicName);
        }

        [Given(@"User delete created Characteristic by name ""([^""]*)""")]
        [When(@"User delete created Characteristic by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic by name ""([^""]*)""")]
        public void DeleteCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserDeleteCreatedCharacteristic");
            CharacteristicsPage.DeleteCreatedCharacteristic(characteristicName);
        }

        [Given(@"User delete created Characteristic set by name ""([^""]*)""")]
        [When(@"User delete created Characteristic set by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic set by name ""([^""]*)""")]
        public void DeleteCreatedCharacteristicSet(string characteristicsetName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserDeleteCreatedCharacteristicset");
            CharacteristicsPage.DeleteCreatedCharacteristicSet(characteristicsetName);
        }

        [Given(@"User delete Characteristic set ""([^""]*)"" if exist")]
        [When(@"User delete Characteristic set ""([^""]*)"" if exist")]
        [Then(@"User delete Characteristic set ""([^""]*)"" if exist")]
        public void DeleteCharacteristicSetIfExist(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step User delete created Characteristic by name" + characteristicName);
            CharacteristicsPage.DeleteCharacteristicSetIfExist(characteristicName);
        }

        [Given(@"User delete Characteristic ""([^""]*)"" if exist")]
        [When(@"User delete Characteristic ""([^""]*)"" if exist")]
        [Then(@"User delete Characteristic ""([^""]*)"" if exist")]
        public void DeleteCharacteristicIfExist(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step User delete created Characteristic by name" + characteristicName);
            CharacteristicsPage.DeleteCharacteristicIfExist(characteristicName);
        }
        [Given(@"User verify Add Button is not Present")]
        [When(@"User verify Add Button is not Present")]
        [Then(@"User verify Add Button is not Present")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not present");
            CharacteristicsPage.VerifyAddButtonIsNotPresent();
        }
        [Given(@"User verify Export option is Present")]
        [When(@"User verify Export option is Present")]
        [Then(@"User verify Export option is Present")]
        public void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Export option is Present");
            CharacteristicsPage.VerifyExportOptionIsPresent();
        }
        [Then(@"User verify Delete Button is not Present ""(.*)""")]
        [When(@"User verify Delete Button is not Present ""(.*)""")]
        [Then(@"User verify Delete Button is not Present ""(.*)""")]
        public void VerifyDeleteButtonIsNotPresent(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step User verify Delete button is not present");
            CharacteristicsPage.VerifyDeleteButtonIsNotPresent(characteristicName);
        }
        [Given(@"User verify Edit option is not Present")]
        [When(@"User verify Edit option is not Present")]
        [Then(@"User verify Edit option is not Present")]
        public void VerifyEditButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Edit button is not present");
            CharacteristicsPage.VerifyEditButtonIsNotPresent();
        }

    }
}
