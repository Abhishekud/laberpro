﻿using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        private const string AddButton = "//button[@id='newDepartments']";
        private const string AddDepartmentLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string DepartmentRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string DepartmentsPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Department')]";
        private const string AddAttributeButton = "//button[.//*[@class='fa fa-plus']]";
        private const string NewAttributeButton = "//a[contains(text(),'New Attribute')]";
        private const string NameTagInput = "//input[contains(@id,'name') and contains(@name,'name')]";
        private const string AttributeModal = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Attribute')]";
        private const string CharacteristicPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Characteristic')]";
        private const string DepartmentInput = "//select[@id='departmentId']";
        private const string AddStandardButton = "//button[.//*[@class='fa fa-plus']]";
        private const string NewStandards = "//a[contains(text(),'New Standard')]";
        private const string StandardForm = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Standard')]";
        private const string AttributeInput = "//select[@id='attributeId']";
        private const string UnitsOfMeasurePopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Unit of Measure')]";
        private const string AddUnitsOfMeasure = "//button[.//*[@class='fa fa-plus']]";
        private const string NewUnitOfMeasure = "//a[contains(text(),'New Unit of Measure')]";
        private const string StandardElementNameInput = "//*[@class='form-group']//input[@name='name']";
        private const string StandardElementFrequencyInput = "//*[@class='form-group']//input[@name='frequencyFormula']";
        private const string StandardElementUomInput = "//select[@id='unitOfMeasureId']";
        private const string NewStandardElementForm = "//*[@role='dialog']//h4[contains(text(),'New Estimate')]";
        private const string NewLocationFormPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Location')]";
        private const string AddLocationLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string VolumeDriverInput = "//input[@type='number']";
        private const string VolumeDriverDropdown = "//*[@id='volumeDriverMappingSetId']";
        private const string UomDropdown = "//*[@id='unitOfMeasureId']";
        private const string VolumeDriverPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Volume Driver')]";
        private const string AddVolumeDriverLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string CharacteristicDropdown = "//select[@id='characteristicSetId']";
        private const string LocationMappingPopup = "//*[contains(text(),'Edit Location Mapping')]";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string AddLocationButton = "//button[.//*[@class='fa fa-plus']]";
        private const string CancelLocationDetails = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Cancel']";
        private const string CloseLocationDetails = "//*[contains(@class,'locations-list-edit-sidebar')]//button[text()='Close']";
        private const string NameInput = "//*[@id='name']";
        private const string AddVolumeDriverButton = "//button[@id='create-volume-drivers']";
        private const string VolumeDriverDropdownInMapping = "//*[@id='volumeDriverId']";
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
        public static void AddVolumeDriverValueSetWithGivenInputIfNotExist(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInputIfNotExist");
            var volumeDriverValueSetRecordXpath = string.Format(VolumeDriverValueSetByName, volumeDriverValueSet);
            var record = WebDriverUtil.GetWebElementAndScroll(volumeDriverValueSetRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddVolumeDriverValueSetWithGivenInput(volumeDriverValueSet);
            }
            else
            {
                record.Click();
            }
        }
        public static void AddVolumeDriverValueSetWithGivenInput(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddVolumeDriverValueSetWithGivenInput");
            ClickOnNewVolumeDriverValueSet();
            if (volumeDriverValueSet != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create volume driver set page - {NameInput}")
                    .SendKeys(Util.ProcessInputData(volumeDriverValueSet));
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
        public static void VerifyLocationDepartmentVolumeDriverInVolumeDriverValue(Table inputData)
        {
            const string location1 = "Location";
            const string departments = "Department";
            const string volDriver = "Volume Driver";
            var dictionary = Util.ConvertToDictionary(inputData);
            var locationInVolumeDriverValue = string.Format(VolumeDriverValueVerificationOfRecord, FindColumnIndex(location1), DataCache.Read(dictionary["Location"]));
            var departmentInVolumeDriverValue = string.Format(VolumeDriverValueVerificationOfRecord, FindColumnIndex(departments), DataCache.Read(dictionary["Department"]));
            var volumeDriverInVolumeDriverValue = string.Format(VolumeDriverValueVerificationOfRecord, FindColumnIndex(volDriver), DataCache.Read(dictionary["VolumeDriver"]));
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.VerifyLocationDepartmentVolumeDriverInVolumeDriverValue");
            FindColumnIndex(location1);
            if (WebDriverUtil.GetWebElement(VolumeDriverValueTable, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                return;

            if (WebDriverUtil.GetWebElement(locationInVolumeDriverValue, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null &&
              WebDriverUtil.GetWebElement(departmentInVolumeDriverValue, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null &&
              WebDriverUtil.GetWebElement(volumeDriverInVolumeDriverValue, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
                throw new Exception("We are suppose to get location: " + DataCache.Read(dictionary["Location"]) + " department: " + DataCache.Read(dictionary["Department"]) + " and volume driver:" + DataCache.Read(dictionary["VolumeDriver"]) + " record in the volume driver value table but it is not visible.. ");

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
        public static void AddNewDepartmentWithGivenInputIfNotExist(string department)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage..AddNewLocationWithGivenInputIfNotExist");
            WaitForDepartmentAlertCloseIfAny();
            var departmentRecord = string.Format(DepartmentRecord, DataCache.Read(department));
            var record = WebDriverUtil.GetWebElementAndScroll(departmentRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewDepartmentWithGivenInput(department);
            }
            else
            {
                record.Click();
            }
        }
        public static void WaitForDepartmentAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.WaitForDepartmentAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
                WebDriverUtil.GetWebElementAndScroll(NameInput);

            }
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void AddNewDepartmentWithGivenInput(string department)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddNewDepartmentWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewDepartmentMenuLink();
            if (department != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input Departments page  - {NameInput}")
                    .SendKeys(Util.ProcessInputData(department));
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button Departments page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(DepartmentsPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(DepartmentsPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception($"Unable to create new Department Error - {alert.Text}");
                        }
                    }
                }
            }
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button Departments page  - {AddButton}").Click();

        }
        public static void UserClickOnNewDepartmentMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.UserClickOnNewDepartmentMenuLink");
            WebDriverUtil.GetWebElement(AddDepartmentLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new Department menu link on add menu popup - {AddDepartmentLink}").Click();

        }
        public static void AddAttributeWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddAttributeWithGivenInput");
            ClickOnAddAttribute();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Attribute") != null)
            {
                WebDriverUtil.GetWebElement(NameTagInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on create attribute page - {NameTagInput}").SendKeys(Util.ProcessInputData(dictionary["Attribute"])); ;
            }

            WebDriverUtil.GetWebElement(SaveButton,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate Save Button- {SaveButton}").Click();

            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(AttributeModal, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(AttributeModal, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new attribute Error - {alert.Text}");
            }
        }
        public static void ClickOnAddAttribute()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnAddAttribute");
            var addAttribute = WebDriverUtil.GetWebElement(AddAttributeButton, WebDriverUtil.NO_WAIT,
                $"Unable to Locate Add Attribute Button - {AddAttributeButton}");
            var newAttribute = WebDriverUtil.GetWebElement(NewAttributeButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate the New Attribute Button - {NewAttributeButton}");
            if (addAttribute == null && newAttribute == null) return;
            addAttribute.Click();
            newAttribute.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void AddNewCharacteristicWithGivenInput(string charactersticSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddNewCharacteristicWithGivenInput");

            if (charactersticSet != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input Characteristics page  - {NameInput}")
                    .SendKeys(Util.ProcessInputData(charactersticSet));
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button Characteristics page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(CharacteristicPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CharacteristicPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new Characteristics Error - {alert.Text}");
            }
        }
        public static void AddStandardsWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddStandardWithGivenInput");
            ClickOnAddStandards();
            WaitForStandardsAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on create standard page - {NameInput}").SendKeys(Util.ProcessInputData(dictionary["Name"]));
            }

            if (Util.ReadKey(dictionary, "Department") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(DepartmentInput, WebDriverUtil.NO_WAIT,
                     $"Unable to locate department input on create standard page - {DepartmentInput}")).SelectByText(DataCache.Read(dictionary["Department"]));

            }

            if (Util.ReadKey(dictionary, "Attribute") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(AttributeInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate attribute input on create standard page - {AttributeInput}")).SelectByText(DataCache.Read(dictionary["Attribute"]));
            }
            WebDriverUtil.GetWebElement(SaveButton,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate save button- {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(StandardForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(StandardForm, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new standard error - {alert.Text}");
            }

        }
        public static void ClickOnAddStandards()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnAddStandards");
            var AddStandard = WebDriverUtil.GetWebElement(AddStandardButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate add standard button - {AddStandardButton}");
            var NewStandard = WebDriverUtil.GetWebElement(NewStandards, WebDriverUtil.NO_WAIT,
                $"Unable to locate the new standard button - {NewStandards}");
            if (AddStandard == null && NewStandard == null) return;
            AddStandard.Click();
            NewStandard.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForStandardsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.WaitForAllowanceAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            var nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);
            if (nameTag != null)
            {
                nameTag.Click();
            }
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void AddUnitOfMeasureWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddUnitOfMeasureWithGivenInput");
            ClickOnAddUnitOfMeasure();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "UnitsOfMeasure") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.ONE_SECOND_WAIT,
                    $"Unable to locate name input on create UnitOfMeasure page - {NameInput}").SendKeys(Util.ProcessInputData(dictionary["UnitsOfMeasure"]));
            }
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(UnitsOfMeasurePopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UnitsOfMeasurePopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new UnitOfMeasure error - {alert.Text}");
            }
        }
        public static void ClickOnAddUnitOfMeasure()
        {

            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnAddUnitOfMeasure");
            var addUnitOfMeasure = WebDriverUtil.GetWebElement(AddUnitsOfMeasure, WebDriverUtil.NO_WAIT,
                $"Unable to locate add UnitsOfMeasure button - {AddUnitsOfMeasure}");
            var newUnitOfMeasure = WebDriverUtil.GetWebElement(NewUnitOfMeasure, WebDriverUtil.NO_WAIT,
                $"Unable to locate the new UnitsOfMeasure button - {NewUnitOfMeasure}");
            if (addUnitOfMeasure == null && newUnitOfMeasure == null) return;
            addUnitOfMeasure.Click();
            newUnitOfMeasure.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }
        public static void AddStandardElementWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddStandardElementWithGivenInput");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            var unitsOfMeasureValue = DataCache.Read(dictionary["Unit of Measure"]);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(StandardElementNameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input - {StandardElementNameInput}").SendKeys(Util.ProcessInputData(dictionary["Name"]));
            }

            if (Util.ReadKey(dictionary, "Frequency") != null)
            {
                WebDriverUtil.GetWebElement(StandardElementFrequencyInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate frequency input - {StandardElementFrequencyInput}").SendKeys(dictionary["Frequency"]);
            }

            if (Util.ReadKey(dictionary, "Unit of Measure") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(StandardElementUomInput, WebDriverUtil.NO_WAIT,
                     $"Unable to locate unit of measure input - {StandardElementUomInput}")).SelectByText(unitsOfMeasureValue);

            }
            WebDriverUtil.GetWebElement(SaveButton,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate save button- {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            if (WebDriverUtil.GetWebElement(NewStandardElementForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(NewStandardElementForm, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new Standard Error - {alert.Text}");
            }
        }
        public static void ClickOnAddLocation()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnAddLocation");
            CloseLocationDetailSideBar();
            WebDriverUtil.GetWebElement(AddLocationButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Locations page - {AddLocationButton}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void WaitForLoading()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.WaitForLoading");
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void CloseLocationDetailSideBar()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.CloseLocationDetailSideBar");
            var locationDetailsSideBar = WebDriverUtil.GetWebElement(CloseLocationDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (locationDetailsSideBar != null)
            {
                locationDetailsSideBar.Click();
                WaitForLoading();
            }
            locationDetailsSideBar = WebDriverUtil.GetWebElement(CancelLocationDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (locationDetailsSideBar == null) return;
            locationDetailsSideBar.Click();
            WaitForLoading();

        }
        public static void AddNewLocationWithGivenInput(string location)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddNewLocationWithGivenInput");
            WebDriverUtil.WaitForAWhile();
            ClickOnAddLocation();
            WebDriverUtil.WaitForAWhile();
            ClickOnNewLocationMenuLink();
            WebDriverUtil.WaitForAWhile();
            //Read input data
            //Enter location name if provided
            if (location!= null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on create location page - {NameInput}")
                    .SendKeys(Util.ProcessInputData(location));
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create location page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(NewLocationFormPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(NewLocationFormPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new location Error - {alert.Text}");
            }

        }
        public static void ClickOnNewLocationMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnNewLocationMenuLink");
            WebDriverUtil.GetWebElement(AddLocationLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate New Location menu link on add menu popup - {AddLocationLink}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void AddNewVolumeDriverMappingSetWithGivenInput(string volumeDriverMappingSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddNewVolumeDriverMappingWithGivenInput");
            //Enter VolumeDriverMapping name if provided
            if ( volumeDriverMappingSet != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate Name input on create VolumeDriverMapping page - {NameInput}")
                  .SendKeys(Util.ProcessInputData(volumeDriverMappingSet));
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create VolumeDriverMapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new VolumeDriverMapping Error - {alert.Text}");
            }
        }
        public static void AddNewVolumeDriverWithGivenInput(string volumeDriver, string department)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddNewVolumeDriverWithGivenInput");
            ClickOnAddVolumeDriverButton();
            UserClickOnNewVolumeDriverMenuLink();
            WebDriverUtil.WaitForAWhile();

            if (volumeDriver != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate Name input VolumeDrivers page  - {NameInput}")
                  .SendKeys(Util.ProcessInputData(volumeDriver));
            }
            if (department != null)
            {
                WebDriverUtil.GetWebElement(DepartmentInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate Department input VolumeDrivers page  - {DepartmentInput}")
                  .SendKeys(department);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button VolumeDrivers page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new VolumeDriver Error - {alert.Text}");
            }

        }
        public static void ClickOnAddVolumeDriverButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.ClickOnAddVolumeDriverButton");
            WebDriverUtil.GetWebElement(AddVolumeDriverButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button VolumeDrivers page  - {AddVolumeDriverButton}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void UserClickOnNewVolumeDriverMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.UserClickOnNewVolumeDriverMenuLink");
            WebDriverUtil.GetWebElement(AddVolumeDriverLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate New VolumeDriver menu link on add menu popup - {AddVolumeDriverLink}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void AddNewVolumeDriverMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddNewVolumeDriverMappingWithGivenInput");
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            //Enter VolumeDriverMapping name if provided
  

            if (Util.ReadKey(dictionary, "VolumeDriverMappingSet") != null)
            {
                WebDriverUtil.GetWebElement(VolumeDriverInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate VolumeDriverMapping set input on create VolumeDriverMapping page - {VolumeDriverInput}")
                  .SendKeys(dictionary["VolumeDriverMappingSet"]);
            }

            if (Util.ReadKey(dictionary, "VolumeDriver") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VolumeDriverDropdownInMapping, WebDriverUtil.NO_WAIT,
                    $"Unable to locate VolumeDriver input on create VolumeDriverMapping page - {VolumeDriverDropdownInMapping}"))
                  .SelectByText(DataCache.Read(dictionary["VolumeDriver"]));
            }
            if (Util.ReadKey(dictionary, "UOM") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(UomDropdown, WebDriverUtil.NO_WAIT,
                    $"Unable to locate UOM input on create VolumeDriverMapping page - {UomDropdown}"))
                  .SelectByText(DataCache.Read(dictionary["UOM"]));
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create VolumeDriverMapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VolumeDriverPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VolumeDriverPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new VolumeDriverMapping Error - {alert.Text}");
            }
        }
        public static void AddNewLocationMappingWithGivenInput(string volumeDriverMappingSet, string charactersticsSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValueSetPage.AddNewLocationMappingWithGivenInput");
            //Read input data
            //Enter VolumeDriverMapping name if provided
            if (volumeDriverMappingSet != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VolumeDriverDropdown, WebDriverUtil.MAX_WAIT,
                $"Unable to locate Volume Driver Mapping record on create Location Mapping page - {VolumeDriverDropdown}"))
                .SelectByText(volumeDriverMappingSet);
            }
            if (charactersticsSet != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(CharacteristicDropdown, WebDriverUtil.MAX_WAIT,
                $"Unable to locate characteristic set input on create Location Mapping page - {CharacteristicDropdown}"))
                .SelectByText(charactersticsSet);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create Location Mapping page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(LocationMappingPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LocationMappingPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new Location Mapping page error - {alert.Text}");
            }
        }
        public static void AddVolumeDriverValueSetDuplicateRecord(string volumeDriverValueSet)
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.AddVolumeDriverValueSetDuplicateRecord");
            ClickOnNewVolumeDriverValueSet();
            if (volumeDriverValueSet != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create volume driver set page - {NameInput}")
                    .SendKeys(volumeDriverValueSet);
            }
        }
    }
}

