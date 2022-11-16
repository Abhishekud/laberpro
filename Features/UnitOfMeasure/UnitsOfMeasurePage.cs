using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.UnitOfMeasure
{
    public class UnitsOfMeasurePage
    {
        private const string RecordForDept = "//td[contains(text(),'{0}')]";
        private const string ListManagementDropdown = "//select[@id='standardFilingFieldId']";
        private const string DepartmentDropdown = "//select[@id='departmentId']";
        private const string AddUnitsOfMeasure = "//button[.//*[@class='fa fa-plus']]";
        private const string NewUnitOfMeasure = "//a[contains(text(),'New Unit of Measure')]";
        private const string UnitOfMeasurePage = "//h3[@class='page-title' and contains(text(),'Units Of Measure')]";
        private const string NameInput = "//*[@role='dialog']//input[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string UomValueInEditForm = "//*[@name='name' and contains(@value,'{0}')]";
        private const string DeleteButton = "//*[@class='controlled-actions']//button[@class='delete report-button btn btn-sm btn-default']";
        private const string ConfirmButton = "//*[@class='modal-content']//button[text()='Confirm']";
        private const string UomConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string UnitsOfMeasures = "//*[@role='presentation']//td[contains(text(),'{0}')]";
        private const string UnitsOfMeasurePopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Unit of Measure')]";
        private const string UomRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string UomValueInLmDropdown = "//select[@id='standardFilingFieldId']//option[@value='UNITS_OF_MEASURE']";
        private const string ExportButton = "//button[@id='export']";
        private const string SaveInprogress = "//button[contains(text(),'Saving...')]";
        private const string DeleteInprogress = "//button[contains(text(),'Deleting...')]";
        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddUnitsOfMeasure, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
            {
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyDeleteButtonIsNotAvailable(string unitOfMeasureName)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyDeleteButtonIsNotPresent");
            var uomRecord = string.Format(UomRecord, unitOfMeasureName);
            WebDriverUtil.GetWebElement(uomRecord, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate UnitOfMeasure record on UnitOfMeasures page - {uomRecord}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
            {
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyExportOptionIsNotAvailable()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyExportOptionIsNotPresent");
            var export = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (export != null)
            {
                throw new Exception("Export option is found but we expect it should be not present as logged in user has view only access!");
            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void ClickOnUnitOfMeasure()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.ClickOnUnitOfMeasure");
            WebDriverUtil.GetWebElement(ListManagementDropdown, WebDriverUtil.NO_WAIT, $"Unable to locate list management dropdown - {ListManagementDropdown}").Click();
            WebDriverUtil.GetWebElement(UomValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate UOM value - {UomValueInLmDropdown}").Click();

        }
        public static void DeleteUnitOfMeasureIfExist(string unitOfMeasureName)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteUnitOfMeasureIfExist");
            var uomRecord = string.Format(UomRecord, unitOfMeasureName);
            var record = WebDriverUtil.GetWebElementAndScroll(uomRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedUnitOfMeasureByName(unitOfMeasureName);
            }


        }
        public static void AddNewUnitOfMeasureWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.AddNewUnitOfMeasureWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            var uomRecord = string.Format(UomRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(uomRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddUnitOfMeasureWihGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void DeleteCreatedUnitOfMeasureByName(string unitOfMeasureName)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteCreatedUnitOfMeasureByName");
            var uomRecord = string.Format(UomRecord, unitOfMeasureName);

            WebDriverUtil.GetWebElement(uomRecord, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate UnitOfMeasure record on UnitOfMeasures page - {uomRecord}").Click();

            WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate delete button - {DeleteButton}").Click();

            WebDriverUtil.GetWebElement(ConfirmButton, WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate confirm button - {ConfirmButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UomConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete UnitOfMeasure Error - {formAlert.Text}");
            }
        }
        public static void SelectCreatedDepartment(string deptName)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.SelectCreatedDepartment");
            if (WebDriverUtil.GetWebElement(UnitOfMeasurePage, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            new SelectElement(WebDriverUtil.GetWebElement(DepartmentDropdown, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate the department dropdown - {DepartmentDropdown}")).SelectByText(deptName);
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
        }
        public static void ClickOnAddUnitOfMeasure()
        {
            LogWriter.WriteLog("Executing UnitsOfMeasurePage.ClickOnAddUnitOfMeasure");
            var addUnitOfMeasure = WebDriverUtil.GetWebElement(AddUnitsOfMeasure, WebDriverUtil.NO_WAIT,
                $"Unable to locate add UnitsOfMeasure button - {AddUnitsOfMeasure}");
            var newUnitOfMeasure = WebDriverUtil.GetWebElement(UnitsOfMeasurePage.NewUnitOfMeasure, WebDriverUtil.NO_WAIT,
                $"Unable to locate the new UnitsOfMeasure button - {UnitsOfMeasurePage.NewUnitOfMeasure}");
            if (addUnitOfMeasure == null && newUnitOfMeasure == null)
            {
                return;
            }
            addUnitOfMeasure.Click();
            newUnitOfMeasure.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }
        public static void AddUnitOfMeasureWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing UnitsOfMeasurePage.AddUnitOfMeasureWithGivenInput");
            ClickOnAddUnitOfMeasure();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.ONE_SECOND_WAIT,
                    $"Unable to locate name input on create UnitOfMeasure page - {NameInput}").SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(UnitsOfMeasurePopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UnitsOfMeasurePopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new UnitOfMeasure error - {formAlert.Text}");
            }
        }

        public static void VerifyCreatedUnitOfMeasure(string uom)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyCreatedUnitOfMeasure");
            var uomValueInEditForm = string.Format(UomValueInEditForm, uom);
            WebDriverUtil.GetWebElement(uomValueInEditForm,
            WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate the unit of measure value - {uomValueInEditForm}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteCreatedUnitOfMeasure()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteCreatedUnitOfMeasure");
            WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate delete button - {DeleteButton}").Click();
            WebDriverUtil.GetWebElement(ConfirmButton, WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate confirm button - {ConfirmButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UomConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete UnitOfMeasure error - {formAlert.Text}");
            }
        }
        public static void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyRecordOfSelectedDept");
            var recordForDept = string.Format(RecordForDept, message);
            if (WebDriverUtil.GetWebElement(UnitOfMeasurePage, WebDriverUtil.TWO_SECOND_WAIT,
                    $"Unable to locate the UnitsOfMeasure page - {UnitOfMeasurePage}") == null)
            {
                return;
            }
            WebDriverUtil.GetWebElement(recordForDept, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate record - {recordForDept}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteUnitOfMeasureByName(string uom)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteUnitOfMeasureByName");
            var unitsOfMeasures = string.Format(UnitsOfMeasures, uom);
            if (WebDriverUtil.GetWebElement(UnitOfMeasurePage, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(unitsOfMeasures,
                WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate Unit Of measure on UnitsOfMeasure page- {unitsOfMeasures}"
                ).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            DeleteCreatedUnitOfMeasure();
        }

        public static void AddUnitOfMeasureWihGivenInput(string unitsOfMeasure)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.AddUnitOfMeasureWithGivenInput");
            ClickOnAddUnitOfMeasure();
            if (unitsOfMeasure != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.ONE_SECOND_WAIT,
                    $"Unable to locate name input on create UnitOfMeasure page - {NameInput}").SendKeys(Util.ProcessInputData(unitsOfMeasure));
            }
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button - {SaveButton}").Click();
            WebDriverUtil.WaitForAWhile();
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(UnitsOfMeasurePopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UnitsOfMeasurePopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new UnitOfMeasure error - {formAlert.Text}");
            }
        }
    }
}
