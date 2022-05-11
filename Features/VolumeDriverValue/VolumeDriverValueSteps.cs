using LaborPro.Automation.Features.Locations;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LaborPro.Automation.Features.VolumeDriverValue
{
    [Binding]
    public class VolumeDriverSteps
    {
        [Given(@"User navigates to volume driver values tab")]
        public void GivenUserNavigatesToVolumeDriverValuesTab()
        {
            LogWriter.WriteLog("Executing Step User navigates to volume driver values tab");
            LocationPage.ClickOnProfilingTab();
            VolumeDriverValuePage.ClickOnVolumeDriverValueTab();
        }

        [When(@"User click download template")]
        public void WhenUserClickDownloadTemplate()
        {
            LogWriter.WriteLog("Executing Step User click download template");
            VolumeDriverValuePage.ClickOnDownloadTemplate();
        }

        [Then(@"User verify volume driver value downloaded file ""([^""]*)""")]
        public void ThenUserVerifyVolumeDriverValueDownloadedFile(string filename)
        {
            LogWriter.WriteLog("Executing Step User verify volume driver value downloaded file");
            VolumeDriverValuePage.VerifyFileDownload(filename);
        }

        [When(@"User Access the downloaded file and update volume driver value in location ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void WhenUserAccessTheDownloadedFileAndUpdateVolumeDriverValueInLocation(string location, string department, string volumedriver, string vdvalue)
        {
            LogWriter.WriteLog("Executing Step User Access the downloaded file and update volume driver value in location");
            VolumeDriverValuePage.AddRecordToCsv(location, "", department, volumedriver, vdvalue, SeleniumDriver.CsvFile);
        }

        [Then(@"User import value in volume driver value")]
        public void ThenUserImportValueInVolumeDriverValue()
        {
            LogWriter.WriteLog("Executing Step User import value in volume driver value");
            VolumeDriverValuePage.UploadTheUpdatedFile();
            VolumeDriverValuePage.DeleteDownloadedCsvFile();
        }

        [Then(@"User verify location department volumedriver in volume driver value page ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void ThenUserVerifyLocationDepartmentVolumedriverInVolumeDriverValuePage(string location, string department, string volumedriver)
        {
            LogWriter.WriteLog("Executing Step User verify location department volumedriver in volume driver value page");
            VolumeDriverValuePage.VerifyLocationInVolumeDriverValue(location);
            VolumeDriverValuePage.VerifyDepartmentInVolumeDriverValue(department);
            VolumeDriverValuePage.VerifyVolumedriverInVolumeDriverValue(volumedriver);
        }


    }
}
