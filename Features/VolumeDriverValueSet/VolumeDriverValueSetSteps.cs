using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.VolumeDriverValueSet
{
    [Binding]
    public class VolumeDriverValueSetSteps
    {
        
        [Given(@"User navigates to volume driver value set page")]
        [When(@"User navigates to volume driver value set page")]
        [Then(@"User navigates to volume driver value set page")]
        public void NavigatesToVolumeDriverValueSetPage()
        {
            LogWriter.WriteLog("Executing Step User navigates to volume driver value set page");
            VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup();
            VolumeDriverValueSetPage.ClickOnProfilingTab();
            VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab();
        }

        [Given(@"User verify new volume driver value set popup")]
        [When(@"User verify new volume driver value set popup")]
        [Then(@"User verify new volume driver value set popup")]
        public void VerifyNewVolumeDriverValueSetPopup()
        {
            LogWriter.WriteLog("Executing Step User verify new volume driver value set popup");
            VolumeDriverValueSetPage.ClickOnNewVolumeDriverValueSet();
            VolumeDriverValueSetPage.VerifyVolumeDriverValueSetPopup();
        }

        [Given(@"User add new volume driver value set using below input")]
        [When(@"User add new volume driver value set using below input")]
        [Then(@"User add new volume driver value set using below input")]
        public void AddNewVolumeValueSet(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User add new volume value set using below input" + inputData);
            VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInput(inputData);
            VolumeDriverValueSetPage.ImportTheVolumeDriverValueUpdatedFile();
            VolumeDriverValueSetPage.ClickOnSaveButton();
        }

        [Given(@"User click save button on volume driver value set popup")]
        [When(@"User click save button on volume driver value set popup")]
        [Then(@"User click save button on volume driver value set popup")]
        public void ClickSaveButtonOnVolumeDriverValueSetPopup()
        {
            LogWriter.WriteLog("Executing Step User click save button on volume driver value set popup");
            VolumeDriverValueSetPage.ClickOnSaveButton();
        }

        [Given(@"User verify validation message ""([^""]*)"" on volume driver value set popup")]
        [When(@"User verify validation message ""([^""]*)"" on volume driver value set popup")]
        [Then(@"User verify validation message ""([^""]*)"" on volume driver value set popup")]
        public void VerifyValidationMessageOnVolumeDriverValueSetPopup(string message)
        {
            LogWriter.WriteLog("Executing Step User verify validation message: " + message + " on volume driver value set popup");
            VolumeDriverValueSetPage.VerifyAddVolumeDriverValueSetErrorMessage(message);
        }

        [Given(@"User import volume driver value in the set")]
        [When(@"User import volume driver value in the set")]
        [Then(@"User import volume driver value in the set")]
        public void ImportVolumeDriverValueInTheSet()
        {
            LogWriter.WriteLog("Executing Step User import volume driver value in the set");
            VolumeDriverValueSetPage.ImportTheVolumeDriverValueUpdatedFile();
        }

        [Given(@"User verify volume driver value set by name ""([^""]*)""")]
        [When(@"User verify volume driver value set by name ""([^""]*)""")]
        [Then(@"User verify volume driver value set by name ""([^""]*)""")]
        public void VerifyVolumeDriverValueSetByName(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing Step User verify volume driver value set by name" + volumeDriverValueSet);
            VolumeDriverValueSetPage.IgnoreImportErrorMessage();
            VolumeDriverValueSetPage.VerifyVolumeDriverValueSet(volumeDriverValueSet);
        }

        [Given(@"User selects volume driver value sets by name ""([^""]*)""")]
        [When(@"User selects volume driver value sets by name ""([^""]*)""")]
        [Then(@"User selects volume driver value sets by name ""([^""]*)""")]
        public void SelectsVolumeDriverValueSetsByName(string volumeDriverValueSetValue)
        {
            LogWriter.WriteLog("Executing Step User selects volume driver value sets by name" + volumeDriverValueSetValue);
            VolumeDriverValueSetPage.SelectTheVolumeDriverValueSet(volumeDriverValueSetValue);
        }
        [Given(@"User add new volume driver value set using below input if not exist")]
        [When(@"User add new volume driver value set using below input if not exist")]
        [Then(@"User add new volume driver value set using below input if not exist")]
        public void AddNewVolumeDriverValueSetUsingBelowInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing Step User add new volume driver value set using below input if not exist " + inputData);
            VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInputIfNotExist(inputData);
        }
        [Given(@"User delete volume driver value set by name ""([^""]*)""")]
        [When(@"User delete volume driver value set by name ""([^""]*)""")]
        [Then(@"User delete volume driver value set by name ""([^""]*)""")]
        public void DeleteVolumeDriverValueSetByName(string volumeDriverValueSetRecord)
        {
            LogWriter.WriteLog("Executing Step User delete volume driver value set by name" + volumeDriverValueSetRecord);
            VolumeDriverValueSetPage.DeleteCreatedVolumeDriverValueSet(volumeDriverValueSetRecord);
        }
        [Given(@"User download volume driver value import template")]
        [When(@"User download volume driver value import template")]
        [Then(@"User download volume driver value import template")]
        public void DownloadVolumeDriverValueImportTemplate()
        {
            LogWriter.WriteLog("Executing Step User download volume driver value import template");
            VolumeDriverValueSetPage.DownloadVolumeDriverValueTemplate();
        }
        [Given(@"User selects default volume driver value set ""([^""]*)""")]
        [When(@"User selects default volume driver value set ""([^""]*)""")]
        [Then(@"User selects default volume driver value set ""([^""]*)""")]
        public void SelectsDefaultVolumeDriverValueSet(string record)
        {
            LogWriter.WriteLog("Executing Step User selects default volume driver value set" + record);
            VolumeDriverValueSetPage.SelectDefaultVolumeDriverValueSet(record);
        }

        [Given(@"User verify delete button is disabled in default volume driver value set")]
        [When(@"User verify delete button is disabled in default volume driver value set")]
        [Then(@"User verify delete button is disabled in default volume driver value set")]
        public void VerifyDeleteButtonIsDisabledInDefaultVolumeDriverValueSet()
        {
            LogWriter.WriteLog("Executing Step User verify delete button is disabled in default volume driver value set");
            VolumeDriverValueSetPage.VerifyDeleteButtonIsDisabledForDefault();
        }
        [Given(@"User verify volume driver value downloaded file ""([^""]*)""")]
        [When(@"User verify volume driver value downloaded file ""([^""]*)""")]
        [Then(@"User verify volume driver value downloaded file ""([^""]*)""")]
        public void ThenUserVerifyVolumeDriverValueDownloadedFile(string filename)
        {
            LogWriter.WriteLog("Executing Step User verify volume driver value downloaded file");
            VolumeDriverValueSetPage.VerifyFileDownload(filename);
        }
        [Given(@"User access the downloaded file and update volume driver value in location ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [When(@"User access the downloaded file and update volume driver value in location ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [Then(@"User access the downloaded file and update volume driver value in location ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void WhenUserAccessTheDownloadedFileAndUpdateVolumeDriverValueInLocation(string location, string department, string volumeDriver, string vdValue)
        {
            LogWriter.WriteLog("Executing Step User access the downloaded file and update volume driver value in location");
            VolumeDriverValueSetPage.AddRecordToCsv(location, "", department, volumeDriver, vdValue, SeleniumDriver.CsvFile);
        }
        [Given(@"User verify location department volume driver in volume driver value page ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [When(@"User verify location department volume driver in volume driver value page ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [Then(@"User verify location department volume driver in volume driver value page ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void VerifyLocationDepartmentVolumeDriverInVolumeDriverValuePage(string location, string department, string volumeDriver)
        {
            LogWriter.WriteLog("Executing Step User verify location department volume driver in volume driver value page");
            VolumeDriverValueSetPage.IgnoreImportErrorMessage();
            VolumeDriverValueSetPage.VerifyLocationDepartmentVolumeDriverInVolumeDriverValue(location, department, volumeDriver);
        }
        [Given(@"User verify export option on volume driver values page")]
        [When(@"User verify export option on volume driver values page")]
        [Then(@"User verify export option on volume driver values page")]
        public void SelectExportOptionOnVolumeDriverValuesPage()
        {
            LogWriter.WriteLog("Executing Step User select export option on volume driver values page");
            VolumeDriverValueSetPage.SelectExportOption();
        }

        

    }
}
