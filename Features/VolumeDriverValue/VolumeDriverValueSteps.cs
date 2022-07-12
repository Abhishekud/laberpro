using LaborPro.Automation.Features.Locations;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.VolumeDriverValue
{
    [Binding]
    public class VolumeDriverSteps
    {
        [Given(@"User navigates to volume driver values tab")]
        [When(@"User navigates to volume driver values tab")]
        [Then(@"User navigates to volume driver values tab")]
        public void GivenUserNavigatesToVolumeDriverValuesTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to volume driver values tab");
            LocationPage.ClickOnProfilingTab();
            VolumeDriverValuePage.ClickOnVolumeDriverValueTab();
        }

        [Given(@"User click download template")]
        [When(@"User click download template")]
        [Then(@"User click download template")]
        public void WhenUserClickDownloadTemplate()
        {
            LogWriter.WriteLog("Executing Step User click download template");
            VolumeDriverValuePage.ClickOnDownloadTemplate();
        }

        [Given(@"User verify volume driver value downloaded file ""([^""]*)""")]
        [When(@"User verify volume driver value downloaded file ""([^""]*)""")]
        [Then(@"User verify volume driver value downloaded file ""([^""]*)""")]
        public void ThenUserVerifyVolumeDriverValueDownloadedFile(string filename)
        {
            LogWriter.WriteLog("Executing Step User verify volume driver value downloaded file");
            VolumeDriverValuePage.VerifyFileDownload(filename);
        }

        [Given(@"User Access the downloaded file and update volume driver value in location ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [When(@"User Access the downloaded file and update volume driver value in location ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [Then(@"User Access the downloaded file and update volume driver value in location ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void WhenUserAccessTheDownloadedFileAndUpdateVolumeDriverValueInLocation(string location, string department, string volumedriver, string vdvalue)
        {
            LogWriter.WriteLog("Executing Step User Access the downloaded file and update volume driver value in location");
            VolumeDriverValuePage.AddRecordToCsv(location, "", department, volumedriver, vdvalue, SeleniumDriver.CsvFile);
        }

        [Given(@"User import value in volume driver value")]
        [When(@"User import value in volume driver value")]
        [Then(@"User import value in volume driver value")]
        public void ThenUserImportValueInVolumeDriverValue()
        {
            LogWriter.WriteLog("Executing Step User import value in volume driver value");
            VolumeDriverValuePage.UploadTheUpdatedFile();
            VolumeDriverValuePage.DeleteDownloadedCsvFile();
        }

        [Given(@"User verify location department volumedriver in volume driver value page ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [When(@"User verify location department volumedriver in volume driver value page ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        [Then(@"User verify location department volumedriver in volume driver value page ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void ThenUserVerifyLocationDepartmentVolumedriverInVolumeDriverValuePage(string location, string department, string volumedriver)
        {
            LogWriter.WriteLog("Executing Step User verify location department volumedriver in volume driver value page");
            VolumeDriverValuePage.IgnoreImportErrorMessage();
            VolumeDriverValuePage.VerifyLocationInVolumeDriverValue(location);
            VolumeDriverValuePage.VerifyDepartmentInVolumeDriverValue(department);
            VolumeDriverValuePage.VerifyVolumedriverInVolumeDriverValue(volumedriver);
        }

        [Given(@"User verify add button is not available on volume driver values page")]
        [When(@"User verify add button is not available on volume driver values page")]
        [Then(@"User verify add button is not available on volume driver values page")]
        public void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Exceuting Step User verify add button is not available on volume driver values page");
            VolumeDriverValuePage.VerifyAddButtonIsNotAvailable();
        }

        [Given(@"User verify export option is available on volume driver values page")]
        [When(@"User verify export option is available on volume driver values page")]
        [Then(@"User verify export option is available on volume driver values page")]
        public void VerifyExportOptionIsAvailable()
        {
            LogWriter.WriteLog("Exceuting Step User verify export option is available on volume driver values page");
            VolumeDriverValuePage.VerifyExportOptionIsAvailable();
        }



    }
}
