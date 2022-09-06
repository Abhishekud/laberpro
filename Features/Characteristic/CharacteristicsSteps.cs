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
            LogWriter.WriteLog("Executing Step User navigates to the Characteristic tab");
            CharacteristicsPage.CloseCharacteristicForm();
            CharacteristicsPage.ClickOnStandardTab();
            CharacteristicsPage.ClickOnCharacteristicTab();

        }
        [Given(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        [When(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        [Then(@"User verify created CharacteristicSet by name ""([^""]*)""")]
        public void VerifyCreatedCharacteristicSet(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step User verify created CharacteristicSet by name" + characteristicName);
            CharacteristicsPage.VerifyCreatedCharacteristicSet(characteristicName);
        }

        [Then(@"Verify Record Of Selected Dept ""(.*)""")]
        [When(@"Verify Record Of Selected Dept ""(.*)""")]
        [Given(@"Verify Record Of Selected Dept ""(.*)""")]
        public void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing Step Verify Record Of Selected Dept" + message);
            CharacteristicsPage.VerifyRecordOfSelectedDept(message);
        }

        [Given(@"User click on Characteristic")]
        [When(@"User click on Characteristic")]
        [Then(@"User click on Characteristic")]
        public void ClickOnCharacteristic()
        {
            LogWriter.WriteLog("Executing Step User click on Characteristic");
            CharacteristicsPage.ClickOnCharacteristic();
        }

        [Given(@"User click on Characteristic set")]
        [When(@"User click on Characteristic set")]
        [Then(@"User click on Characteristic set")]
        public void ClickOnCharacteristicSet()
        {
            LogWriter.WriteLog("Executing Step User click on Characteristic set");
            CharacteristicsPage.ClickOnCharacteristicSet();
        }

        [Given(@"User create new Characteristic with below input")]
        [When(@"User create new Characteristic with below input")]
        [Then(@"User create new Characteristic with below input")]
        public void AddNewCharacteristicWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User create new Characteristic with below input" + inputData);
            CharacteristicsPage.AddNewCharacteristicWithGivenInput(inputData);
            CharacteristicsPage.CloseCharacteristicDetailSideBar();
        }


        [Given(@"User create new Characteristic with below input if not exist")]
        [When(@"User create new Characteristic with below input if not exist")]
        [Then(@"User create new Characteristic with below input if not exist")]
        public void CharacteristicWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step: User add  Characteristic using below input if not exist - " + inputData);
            CharacteristicsPage.AddCharacteristicWithGivenInputIfNotExist(inputData);
            CharacteristicsPage.CloseCharacteristicDetailSideBar();
        }

        [Given(@"User verify created Characteristic by name ""([^""]*)""")]
        [When(@"User verify created Characteristic by name ""([^""]*)""")]
        [Then(@"User verify created Characteristic by name ""([^""]*)""")]
        public void VerifyCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step: User verify created Characteristic by name " + characteristicName);
            CharacteristicsPage.VerifyCreatedCharacteristic(characteristicName);
        }

        [Given(@"User delete created Characteristic by name ""([^""]*)""")]
        [When(@"User delete created Characteristic by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic by name ""([^""]*)""")]
        public void DeleteCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step: User delete created Characteristic by name " + characteristicName);
            CharacteristicsPage.DeleteCreatedCharacteristic(characteristicName);
        }

        [Given(@"User delete created Characteristic set by name ""([^""]*)""")]
        [When(@"User delete created Characteristic set by name ""([^""]*)""")]
        [Then(@"User delete created Characteristic set by name ""([^""]*)""")]
        public void DeleteCreatedCharacteristicSet(string characteristicSetName)
        {
            LogWriter.WriteLog("Executing Step: User delete created Characteristic set by name " + characteristicSetName);
            CharacteristicsPage.DeleteCreatedCharacteristicSet(characteristicSetName);
        }

        [Given(@"User delete Characteristic set ""([^""]*)"" if exist")]
        [When(@"User delete Characteristic set ""([^""]*)"" if exist")]
        [Then(@"User delete Characteristic set ""([^""]*)"" if exist")]
        public void DeleteCharacteristicSetIfExist(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step User delete created Characteristic set by name" + characteristicName);
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

        [Then(@"User verify add button is not available on characteristic page")]
        public void VerifyAddButtonIsNotAvailableOnCharacteristicPage()
        {

            LogWriter.WriteLog("Executing Step User verify add button is not available on characteristic page");
            CharacteristicsPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify export option is available on characteristic page")]
        public void VerifyExportOptionIsAvailableOnCharacteristicPage()
        {
            LogWriter.WriteLog("Executing Step User verify export option is available on characteristic page");
            CharacteristicsPage.VerifyExportOptionIsPresent();
        }

        [Then(@"User verify delete button is not available on characteristic page in ""([^""]*)""")]
        public void VerifyDeleteButtonIsNotAvailableOnCharacteristicPageIn(string characteristicName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button is not available on characteristic page in" + characteristicName);
            CharacteristicsPage.VerifyDeleteButtonIsNotPresent(characteristicName);

        }
        [Then(@"User verify edit option is not available on characteristic page")]
        public void VerifyEditOptionIsNotAvailableOnCharacteristicPage()
        {
            LogWriter.WriteLog("Executing Step User verify edit option is not available on characteristic page");
            CharacteristicsPage.VerifyEditButtonIsNotPresent();
        }


    }
}
