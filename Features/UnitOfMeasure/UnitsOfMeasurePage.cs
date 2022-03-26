using laborpro.hooks;
using laborpro.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborpro.Features.UnitOfMeasure
{
    public class UnitsOfMeasurePage
    {
        const string RECORD_FOR_DEPT = "//td[contains(text(),'{0}')]";
        const string LIST_MANAGEMENT_DROPDOWN = "//select[@id='standardFilingFieldId']";
        const string DEPARTMENT_DROPDOWN = "//select[@id='departmentId']";
        const string DEPARTMENT_VALUE = "//select[@id='departmentId']//option[contains(text(),'{0}')]";
        const string ADD_UNITS_OF_MEASURE = "//button[.//*[@class='fa fa-plus']]";
        const string NEW_UNIT_OF_MEASURE = "//a[contains(text(),'New Unit of Measure')]";
        const string UNITSOFMEASURE_PAGE = "//h3[@class='page-title' and contains(text(),'Units Of Measure')]";
        const string NAMETAG_INPUT = "//*[@role='dialog']//input[@id='name']";
        const string EDIT_NAMETAG_INPUT = "//input[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string UOM_VALUE_IN_EDITFORM = "//*[@name='name' and contains(@value,'{0}')]";
        const string UOM_EDIT_FORM = "//*[@class='sidebar-header']//h4[contains(text(),'Edit UOM')]";
        const string EDIT_FORM_CLOSE_BUTTON = "//*[@class='controlled-actions']//button[contains(text(),'Close')]";
        const string DELETE_BUTTON = "//*[@class='controlled-actions']//button[@class='delete report-button btn btn-sm btn-default']";
        const string CONFIRM_BUTTON = "//*[@class='modal-content']//button[text()='Confirm']";
        const string UOM_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string UNITS_OF_MEASURE = "//*[@role='presentation']//td[contains(text(),'{0}')]";
        const string UNITS_OF_MEASURE_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Unit of Measure')]";
        public static void SelectListMangement(string ListManagementValue)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.SelectListManagement");
            if (WebDriverUtil.GetWebElement(UNITSOFMEASURE_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LIST_MANAGEMENT_DROPDOWN, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate the list maangemement dropdown - {0}", LIST_MANAGEMENT_DROPDOWN))).SelectByText(ListManagementValue);
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
        }
        public static void SelectCreatedDepartment(string deptName)
        {

            LogWriter.WriteLog("Executing UnitOfMeasurePage.SelectCreatedDepartment");

            if (WebDriverUtil.GetWebElement(UNITSOFMEASURE_PAGE, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(DEPARTMENT_DROPDOWN, WebDriverUtil.TWO_SECOND_WAIT,
                  String.Format("Unable to locate the department dropdown - {0}", DEPARTMENT_DROPDOWN))).SelectByText(deptName);
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
        }
        public static void clickOnAddUnitOfMeasure()
        {

            LogWriter.WriteLog("Executing UnitsOfMeasurePage.clickOnAddUnitOfMeasure");
            IWebElement AddUnitOfMeasure = WebDriverUtil.GetWebElement(ADD_UNITS_OF_MEASURE, WebDriverUtil.NO_WAIT,
                String.Format("Unable to Locate Add Attribute Button - {0}", ADD_UNITS_OF_MEASURE));
            IWebElement NewUnitOfMeasure = WebDriverUtil.GetWebElement(NEW_UNIT_OF_MEASURE, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate the New Attribute Button - {0}", NEW_UNIT_OF_MEASURE));
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
            clickOnAddUnitOfMeasure();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAMETAG_INPUT, WebDriverUtil.ONE_SECOND_WAIT,
                    String.Format("Unable to locate name input on create attribute page - {0}", NAMETAG_INPUT)).SendKeys(dictionary["Name"]);
            }

            WebDriverUtil.GetWebElement(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Save Button- {0}", SAVE_BUTTON)).Click();

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(UNITS_OF_MEASURE_POPUP, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
            else
            {
                WebDriverUtil.WaitForWebElementInvisible(UNITS_OF_MEASURE_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }


        }
        public static void CloseUOMEditForm()
        {
            WebDriverUtil.GetWebElement(EDIT_FORM_CLOSE_BUTTON,
                WebDriverUtil.NO_WAIT,
                String.Format
                ("Unable to locate close button in edit form - {0}", EDIT_FORM_CLOSE_BUTTON)).Click();
        }
        public static void VerifyCreatedUnitOfMeasure(string UOM)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.VerifyCreatedUnitOfMeasure");

            IWebElement UOMDATA = WebDriverUtil.GetWebElement(String.Format(UOM_VALUE_IN_EDITFORM, UOM),
            WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate the unit of measure value - {0}", String.Format(UOM_VALUE_IN_EDITFORM, UOM)));
            BaseClass._AttachScreenshot.Value = true;



        }
        public static void DeleteCreatedUnitOfMeasure()
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteCreatedUnitOfMeasure");
            WebDriverUtil.GetWebElement(DELETE_BUTTON, WebDriverUtil.NO_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();
            if (WebDriverUtil.GetWebElement(UOM_CONFIRM_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CONFIRM_BUTTON, WebDriverUtil.NO_WAIT, String.Format("Unable to locate confirm button - {0}", CONFIRM_BUTTON)).Click();
                WebDriverUtil.WaitForWebElementInvisible(UOM_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);

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

        public static void DeleteUnitOfMeasureByName(string UOM)
        {
            LogWriter.WriteLog("Executing UnitOfMeasurePage.DeleteUnitOfMeasureByName");
            if (WebDriverUtil.GetWebElement(UNITSOFMEASURE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(UNITS_OF_MEASURE, UOM),
                WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate Unit Of measure - {0}",
                String.Format(UNITS_OF_MEASURE, UOM))).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            DeleteCreatedUnitOfMeasure();
        }




    }
}
