using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.UnitOfMeasure
{
    public class UnitsOfMeasurePage
    {
        const string RECORD_FOR_DEPT = "//td[contains(text(),'{0}')]";
        const string LIST_MANAGEMENT_DROPDOWN = "//select[@id='standardFilingFieldId']";
        const string DEPARTMENT_DROPDOWN = "//select[@id='departmentId']";
        const string ADD_UNITS_OF_MEASURE = "//button[.//*[@class='fa fa-plus']]";
        const string NEW_UNIT_OF_MEASURE = "//a[contains(text(),'New Unit of Measure')]";
        const string UNITSOFMEASURE_PAGE = "//h3[@class='page-title' and contains(text(),'Units Of Measure')]";
        const string NAMETAG_INPUT = "//*[@role='dialog']//input[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string UOM_VALUE_IN_EDITFORM = "//*[@name='name' and contains(@value,'{0}')]";
        const string EDIT_FORM_CLOSE_BUTTON = "//*[@class='controlled-actions']//button[contains(text(),'Close')]";
        const string DELETE_BUTTON = "//*[@class='controlled-actions']//button[@class='delete report-button btn btn-sm btn-default']";
        const string CONFIRM_BUTTON = "//*[@class='modal-content']//button[text()='Confirm']";
        const string UOM_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string UNITS_OF_MEASURE = "//*[@role='presentation']//td[contains(text(),'{0}')]";
        const string UNITS_OF_MEASURE_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Unit of Measure')]";
        const string UOM_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string UOM_VALUE_IN_LM_DROPDOWN = "//select[@id='standardFilingFieldId']//option[@value='UNITS_OF_MEASURE']";
        const string EXPORT_BUTTON="//button[@id='export']";

        public static void ClickOnUnitOfMeasure()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.ClickOnUnitOfMeasure");

            WebDriverUtil.GetWebElement(LIST_MANAGEMENT_DROPDOWN,
            WebDriverUtil.NO_WAIT, String.Format("Unable to locate list management dropdown - {0}", LIST_MANAGEMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(UOM_VALUE_IN_LM_DROPDOWN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate UOM value - {0}",UOM_VALUE_IN_LM_DROPDOWN)).Click();

        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyAddButtonIsNotPresent");
            IWebElement AddUnitOfMeasure = WebDriverUtil.GetWebElement(ADD_UNITS_OF_MEASURE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (AddUnitOfMeasure == null)
            {
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void VerifyDeleteButtonIsNotPresent(string unitOfMeasureName)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyDeleteButtonIsNotPresent");
            WebDriverUtil.GetWebElement(String.Format(UOM_RECORD, unitOfMeasureName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate UnitOfMeasure record on UnitOfMeasures page - {0}", String.Format(UOM_RECORD, unitOfMeasureName))).Click();
            IWebElement Delete = WebDriverUtil.GetWebElement(DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
              if (Delete == null)
            {
                BaseClass._AttachScreenshot.Value = true;
            } 
        }
        public static void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyExportOptionIsNotPresent");
            IWebElement export = WebDriverUtil.GetWebElement(EXPORT_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (export == null)
            {
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void DeleteUnitOfMeasureIfExist(string unitOfMeasureName)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteUnitOfMeasureIfExist");
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(UOM_RECORD, unitOfMeasureName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedUnitOfMeasureByName(unitOfMeasureName);
            }


        }
        public static void AddNewUnitOfMeasureWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.AddUnitOfMeasureWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(UOM_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
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
            WebDriverUtil.GetWebElement(String.Format(UOM_RECORD, unitOfMeasureName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate UnitOfMeasure record on UnitOfMeasures page - {0}", String.Format(UOM_RECORD, unitOfMeasureName))).Click();


            WebDriverUtil.GetWebElement(DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CONFIRM_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate confirm button - {0}", CONFIRM_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UOM_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete UnitOfMeasure Error - {0}", alert.Text));
            }

        }
        public static void SelectCreatedDepartment(string deptName)
        {

            LogWriter.WriteLog("Executing UnitOfMeasurePage.SelectCreatedDepartment");

            if (WebDriverUtil.GetWebElement(UNITSOFMEASURE_PAGE, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(DEPARTMENT_DROPDOWN, WebDriverUtil.TWO_SECOND_WAIT,
                  String.Format("Unable to locate the department dropdown - {0}", DEPARTMENT_DROPDOWN))).SelectByText(deptName);
                WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            }
        }
        public static void ClickOnAddUnitOfMeasure()
        {

            LogWriter.WriteLog("Executing UnitsOfMeasurePage.clickOnAddUnitOfMeasure");
            IWebElement AddUnitOfMeasure = WebDriverUtil.GetWebElement(ADD_UNITS_OF_MEASURE, WebDriverUtil.NO_WAIT,
                String.Format("Unable to Locate Add UnitsOfMeasure Button - {0}", ADD_UNITS_OF_MEASURE));
            IWebElement NewUnitOfMeasure = WebDriverUtil.GetWebElement(NEW_UNIT_OF_MEASURE, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate the New UnitsOfMeasure Button - {0}", NEW_UNIT_OF_MEASURE));
            if (AddUnitOfMeasure != null || NewUnitOfMeasure != null)
            {
                AddUnitOfMeasure.Click();
                NewUnitOfMeasure.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }

        }
        public static void AddUnitOfMeasureWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing UnitsOfMeasurePage.AddUnitOfMeasureWithGivenInput");
            ClickOnAddUnitOfMeasure();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAMETAG_INPUT, WebDriverUtil.ONE_SECOND_WAIT,
                    String.Format("Unable to locate name input on create UnitOfMeasure page - {0}", NAMETAG_INPUT)).SendKeys(dictionary["Name"]);
            }

            WebDriverUtil.GetWebElement(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Save Button- {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(UNITS_OF_MEASURE_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ELEMENT_ALERT, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(UNITS_OF_MEASURE_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new UnitOfMeasure Error - {0}", alert.Text));
                        }
                    }
                }
            }
          


        }
        public static void CloseUomEditForm()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.CloseUomEditForm");
            WebDriverUtil.GetWebElement(EDIT_FORM_CLOSE_BUTTON,
                WebDriverUtil.NO_WAIT,
                String.Format
                ("Unable to locate close button in edit form - {0}", EDIT_FORM_CLOSE_BUTTON)).Click();
        }
        public static void VerifyCreatedUnitOfMeasure(string uom)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyCreatedUnitOfMeasure");

            WebDriverUtil.GetWebElement(String.Format(UOM_VALUE_IN_EDITFORM, uom),
            WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate the unit of measure value - {0}", String.Format(UOM_VALUE_IN_EDITFORM, uom)));
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteCreatedUnitOfMeasure()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteCreatedUnitOfMeasure");
            WebDriverUtil.GetWebElement(DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CONFIRM_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate confirm button - {0}", CONFIRM_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UOM_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete UnitOfMeasure Error - {0}", alert.Text));
            }
        }
        public static void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyRecordOfSelectedDept");

            if (WebDriverUtil.GetWebElement(UNITSOFMEASURE_PAGE, WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate the page - {0}", UNITSOFMEASURE_PAGE)) != null)
            {
                IWebElement recordOfDept = WebDriverUtil.GetWebElement(String.Format(RECORD_FOR_DEPT, message), WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate record - {0}", String.Format(RECORD_FOR_DEPT, message)));
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static void DeleteUnitOfMeasureByName(string uom)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteUnitOfMeasureByName");
            if (WebDriverUtil.GetWebElement(UNITSOFMEASURE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(UNITS_OF_MEASURE, uom),
                WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate Unit Of measure - {0}",
                String.Format(UNITS_OF_MEASURE, uom))).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            DeleteCreatedUnitOfMeasure();
        }
    }
}
