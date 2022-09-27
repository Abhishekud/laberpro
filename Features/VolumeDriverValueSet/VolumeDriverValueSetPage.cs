using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.VolumeDriverValueSet
{
    public class VolumeDriverValueSetPage
    {
        private const string ProfilingCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        private const string VolumeDriverValueSetPageTitle = "//*[@class='page-title' and contains( text(),'Volume Driver Value Sets')]";
        private const string VolumeDriverValueSetTab = "//a[text()='Volume Driver Value Sets']";
        private const string AddVolumeDriverValueSet = "//button[.//*[@class='fa fa-plus']]";
        private const string NewVolumeDriverValueSet = "//a[text()='New Volume Driver Value Set']";
        private const string VolumeDriverValueSetPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Volume Driver Value Set')]";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'help-block help-block')]";
        private const string VolumeDriverValueSetByName = "//*[@role='row' and .//*[text()='{0}']]";
        private const string VolumeDriverValueSetValue = "//select[contains(@id,'volumeDriverValueSetId')]//option[contains(text(),'{0}')]";
        private const string VolumeDriverValueSetDropdown = "//select[contains(@id,'volumeDriverValueSetId')]";
        private const string NameInput = "//input[contains(@id,'name') and contains(@name,'name')]";
        private const string CloseVolumeDriverValueSetDetails = "//button[text()='Cancel']";
        private const string VolumeDriverValueSetDeleteButton = "//button[contains(@class,'delete')]";
        private const string VolumeDriverValueSetConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string VolumeDriverValueSetConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string CancelButton = "//button[text()='Cancel']";
        private const string VolumeDriverValueSetDownload = "//*[@class='page volume-driver-value-sets-list-page']//*[@id='export']//*[@class='fa fa-file-excel-o']";
        private const string VolumeDriverValueSetDownloadTemplate = "//a[contains(text(),'Download Volume Driver Values Import Template')]";
        private const string ImportErrorModal = "//*[@class='modal-content']//*[text()='Import Errors']";
        private const string ImportErrorModalOkButton = "//*[@class='modal-content']//*[text()='OK']";
        private const string FormInputFieldValidationXpath = "//*[contains(@class,'validation-error')]";
        private const string VolumeDriverValueTableHeaders = "//table[@role='presentation']//th//*[@class='k-link']";
        private const string VolumeDriverValueTable = "//tbody[@role='presentation']";
        private const string VolumeDriverValueVerificationOfRecord = "//tbody[@role='presentation']//td[@aria-colindex='{0}' and contains(text(),'{1}')]";
        private const string VolumeDriverValuePage = "//*[@class='page volume-driver-values-list-page']//*[@title='Volume Driver Values']";
        private const string VolumeDriverValueExport = "//*[@class='page volume-driver-values-list-page']//*[@id='export']//*[@class='fa fa-file-excel-o']";
        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnProfilingTab");
            var profilingTab = WebDriverUtil.GetWebElement(ProfilingCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab == null) return;
            profilingTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnVolumeDriverValueSetTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnVolumeDriverValueSetTab");
            if (WebDriverUtil.GetWebElement(VolumeDriverValueSetPageTitle, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null) return;
            WebDriverUtil.GetWebElement(VolumeDriverValueSetTab, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate volume driver value set tab - {VolumeDriverValueSetTab}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnNewVolumeDriverValueSet()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnNewVolumeDriverValueSet");
            var addVolumeDriverValueSet = WebDriverUtil.GetWebElement(AddVolumeDriverValueSet, WebDriverUtil.NO_WAIT,
                $"Unable to locate the add volume driver value set button - {AddVolumeDriverValueSet}");
            var newVolumeDriverValueSet = WebDriverUtil.GetWebElement(NewVolumeDriverValueSet, WebDriverUtil.NO_WAIT,
                $"Unable to locate the new volume driver value set button - {NewVolumeDriverValueSet}");
            if (addVolumeDriverValueSet == null && newVolumeDriverValueSet == null) return;
            addVolumeDriverValueSet.Click();
            newVolumeDriverValueSet.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void VerifyVolumeDriverValueSetPopup()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.VerifyVolumeDriverValueSetPopup");
            var volumeDriverValueSetPopup = WebDriverUtil.GetWebElement(VolumeDriverValueSetPopup, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverValueSetPopup == null)
                throw new Exception("Volume driver value set popup is not found but we expect it should be present");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void CloseVolumeDriverValueSetPopup()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.CloseVolumeDriverValueSetPopup");
            var volumeDriverValueSetPopup = WebDriverUtil.GetWebElement(VolumeDriverValueSetPopup, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            var cancelButton = WebDriverUtil.GetWebElement(CancelButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverValueSetPopup != null)
                cancelButton.Click();
        }
        public static void ClickOnSaveButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnSaveButton");
            var saveButton = WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate save button - {SaveButton}");
            if (saveButton == null) return;
            saveButton.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverValueSetPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null)
                return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverValueSetPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new volume driver value set Error - {alert.Text}");
            }


        }
        public static void VerifyAddVolumeDriverValueSetErrorMessage(string message)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.VerifyAddVolumeDriverValueSetErrorMessage");
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldValidationXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null)
            {
                var actualError = errorMessage.Text;
                if (!(actualError.ToLower()).Equals(message.ToLower()))
                    throw new Exception($"We supposed to get error message - {message} but getting - {actualError}");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyVolumeDriverValueSet(string record)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.VerifyVolumeDriverValueSet");
            var volumeDriverValueSetName = string.Format(VolumeDriverValueSetByName, record);
            if (WebDriverUtil.GetWebElement(volumeDriverValueSetName, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate the volume driver value set record - {volumeDriverValueSetName}") == null)
                return;
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectTheVolumeDriverValueSet(string volumeDriverValueSetName)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.SelectTheVolumeDriverValueSet");
            var volumeDriverValueSetValue = string.Format(VolumeDriverValueSetValue, volumeDriverValueSetName);
            WebDriverUtil.GetWebElement(VolumeDriverValueSetDropdown, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate the volume driver value set dropdown - {VolumeDriverValueSetDropdown}").Click();
            WebDriverUtil.GetWebElement(volumeDriverValueSetValue,
            WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate volume driver value set record on volume driver value page - {volumeDriverValueSetValue}").Click();
            WebDriverUtil.WaitForAWhile();

        }
        public static void ImportTheVolumeDriverValueUpdatedFile()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ImportTheVolumeDriverValueUpdatedFile");
            var volumeDriverValueSetPopup = WebDriverUtil.GetWebElement(VolumeDriverValueSetPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverValueSetPopup == null) return;
            var js = (IJavaScriptExecutor)SeleniumDriver.Driver();
            var element = (IWebElement)js.ExecuteScript("return document.evaluate('//input[@type=\"file\"]',document,null,XPathResult.FIRST_ORDERED_NODE_TYPE,null).singleNodeValue;");
            element.SendKeys(SeleniumDriver.CsvFile);
        }
        public static void AddVolumeDriverValueSetWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            var volumeDriverValueSetRecordXpath = string.Format(VolumeDriverValueSetByName, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(volumeDriverValueSetRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddVolumeDriverValueSetWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void AddVolumeDriverValueSetWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInput");
            ClickOnNewVolumeDriverValueSet();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create volume driver set page - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
        }
        public static void CloseVolumeDriverValueSetDetailSideBar()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.CloseVolumeDriverValueSetDetailSideBar");
            var volumeDriverValueSetDetailSideBar = WebDriverUtil.GetWebElement(CloseVolumeDriverValueSetDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (volumeDriverValueSetDetailSideBar == null) return;
            volumeDriverValueSetDetailSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void DeleteCreatedVolumeDriverValueSet(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.DeleteCreatedVolumeDriverValueSet");
            CloseVolumeDriverValueSetDetailSideBar();
            var volumeDriverValueSetRecordXpath = string.Format(VolumeDriverValueSetByName, volumeDriverValueSet);
            WebDriverUtil.GetWebElement(volumeDriverValueSetRecordXpath, WebDriverUtil.NO_WAIT,
            $"Unable to locate volume driver value set record on volume driver value set page - {volumeDriverValueSetRecordXpath}").Click();

            WebDriverUtil.GetWebElement(VolumeDriverValueSetDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate delete button on volume value set details page -{VolumeDriverValueSetDeleteButton}").Click();

            WebDriverUtil.GetWebElement(VolumeDriverValueSetConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate confirm button on delete confirmation popup - {VolumeDriverValueSetConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverValueSetConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete volume driver value set error - {alert.Text}");
            }
        }
        public static void DownloadVolumeDriverValueTemplate()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.DownloadVolumeDriverValueTemplate");
            if (WebDriverUtil.GetWebElement(VolumeDriverValueSetPageTitle, WebDriverUtil.ONE_SECOND_WAIT,
                    $"Unable to locate the page - {VolumeDriverValueSetPageTitle}") == null) return;
            WebDriverUtil.GetWebElement(VolumeDriverValueSetDownload, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate volume driver value download - {VolumeDriverValueSetDownload}").Click();
            WebDriverUtil.GetWebElement(VolumeDriverValueSetDownloadTemplate, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate volume driver value template - {VolumeDriverValueSetDownloadTemplate}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.TEN_SECOND_WAIT);
            if (File.Exists(SeleniumDriver.CsvFile) == false)
            {
                WebDriverUtil.WaitFor(WebDriverUtil.MAX_WAIT);
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void IgnoreImportErrorMessage()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.IgnoreImportErrorMessage");
            if (WebDriverUtil.GetWebElement(ImportErrorModal, WebDriverUtil.TWO_SECOND_WAIT,
                    WebDriverUtil.NO_MESSAGE) == null) return;
            WebDriverUtil.GetWebElement(ImportErrorModalOkButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);

        }
        public static void SelectDefaultVolumeDriverValueSet(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.SelectDefaultVolumeDriverValueSet");
            if (WebDriverUtil.GetWebElement(VolumeDriverValueSetPageTitle, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                return;
            var volumeDriverValueSetRecordXpath = string.Format(VolumeDriverValueSetByName, volumeDriverValueSet);
            WebDriverUtil.GetWebElement(volumeDriverValueSetRecordXpath, WebDriverUtil.NO_WAIT,
            $"Unable to locate volume driver value set record on volume driver value set page - {volumeDriverValueSetRecordXpath}").Click();
        }
        public static void VerifyDeleteButtonIsDisabledForDefault()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.VerifyDeleteButtonIsDisabledForDefault");
            if (WebDriverUtil.GetWebElement(VolumeDriverValueSetDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Enabled)
                throw new Exception("Delete button is enabled but we expect it should be disabled for default volume driver value set");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static bool VerifyFileDownload(string fileName)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.VerifyFileDownload");
            var exist = false;
            var filepath = Directory.GetFiles(SeleniumDriver.DownloadDirectory);
            foreach (var p in filepath)
            {
                if (!p.Contains(fileName)) continue;
                var thisFile = new FileInfo(p);
                if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    exist = true;
                break;
            }

            return exist;

        }
        public static void AddRecordToCsv(string location, string locationDescription, string department, string volumeDriver, string value, string filePath)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddRecordToCsv");
            const string locationTemplate = "Location";
            const string locationDescriptionTemplate = "Location Description";
            const string departmentTemplate = "Department";
            const string volumeDriverTemplate = "Volume Driver";
            const string valueTemplate = "Value";
            try
            {
                using var file = new StreamWriter(@filePath, true);
                file.WriteLine(locationTemplate + "," + locationDescriptionTemplate + "," + departmentTemplate + "," + volumeDriverTemplate + "," + valueTemplate);
                file.WriteLine(location + "," + locationDescription + "," + department + "," + volumeDriver + "," + value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static int FindColumnIndex(string headerName)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.FindColumnIndex");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(VolumeDriverValueTableHeaders));
            var index = 0;
            foreach (var header in headers)
            {
                index++;
                if (headerName.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }

            return index;
        } 
        public static void VerifyLocationDepartmentVolumeDriverInVolumeDriverValue(string location, string department, string volumeDriver)
        {
            const string location1 = "Location";
            const string departments = "Department";
            const string volDriver = "Volume Driver";
            var locationInVolumeDriverValue = string.Format(VolumeDriverValueVerificationOfRecord, FindColumnIndex(location1), location);
            var departmentInVolumeDriverValue = string.Format(VolumeDriverValueVerificationOfRecord, FindColumnIndex(departments), department);
            var volumeDriverInVolumeDriverValue = string.Format(VolumeDriverValueVerificationOfRecord, FindColumnIndex(volDriver), volumeDriver);
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.VerifyLocationDepartmentVolumeDriverInVolumeDriverValue");
            FindColumnIndex(location1);
            if (WebDriverUtil.GetWebElement(VolumeDriverValueTable, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                return;

            if (WebDriverUtil.GetWebElement(locationInVolumeDriverValue, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null &&
              WebDriverUtil.GetWebElement(departmentInVolumeDriverValue, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null &&
              WebDriverUtil.GetWebElement(volumeDriverInVolumeDriverValue, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                throw new Exception("We are suppose to get location: "+ location +" department: "+ department +" and volume driver:"+ volumeDriver +" record in the volume driver value table but it is not visible.. ");

            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectExportOption()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.SelectExportOption");
            var exportVolumeDriverValue = WebDriverUtil.GetWebElement(VolumeDriverValueExport, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverValuePage, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                return;
            exportVolumeDriverValue.Click();
            BaseClass._AttachScreenshot.Value = true;
        }
       
    }
}

