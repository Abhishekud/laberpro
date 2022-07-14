using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Department
{
    public class DepartmentsPage
    {
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string ListManagementTab = "//a[text()='List Management']";
        private const string AddButton = "//button[@id='newDepartments']";
        private const string AddDepartmentLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseDepartmentFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string UnitOfMeasurePage = "//h3[@class='page-title' and contains(text(),'Units Of Measure')]";
        private const string CloseDepartmentDetails = "//button[text()='Close']";
        private const string DepartmentDeleteButton = "//button[contains(@class,'delete')]";
        private const string DepartmentRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string DepartmentDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string DepartmentDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string ListManagementDropdown = "//select[@id='standardFilingFieldId']";
        private const string DepartmentValueInLmDropdown = "//select[@id='standardFilingFieldId']//option[@value='DEPARTMENTS']";
        private const string DepartmentPage = "//h3[contains(text(),'Departments')]";
        private const string DepartmentsPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Department')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ExportButton = "//button[@id='export']";

        public static void AddNewDepartmentWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing DepartmentPage.AddNewDepartmentWithGivenInputIfNotExist");
            WaitForDepartmentAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            var departmentRecordXpath = string.Format(DepartmentRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(departmentRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewDepartmentWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing DepartmentPage.VerifyAddButtonIsNotPresent");
            var addDepartment = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addDepartment != null)
                throw new Exception("Add button is found but we expect it should not be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string departmentName)
        {
            LogWriter.WriteLog("Executing DepartmentPage.VerifyDeleteButtonIsNotPresent");
            var departmentRecordXpath = string.Format(DepartmentRecord, departmentName);
            WebDriverUtil.GetWebElement(departmentRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate Department record on Department page - {departmentRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(DepartmentDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete button is found but we expect it should not be present as logged in user has view only access!");
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
                throw new Exception("Edit TextBox is Enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        
        }
        public static void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing DepartmentPage.VerifyExportOptionIsNotPresent");
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton != null)
                throw new Exception("Export Option is found but we expect it should not be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteDepartmentIfExist(string departmentName)
        {
            LogWriter.WriteLog("Executing DepartmentPage.DeleteDepartmentIfExist");
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(DepartmentRecord, departmentName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedDepartment(departmentName);
            }


        }
        public static void CloseDepartmentDetailSideBar()
        {
            LogWriter.WriteLog("Executing DepartmentPage.CloseDepartmentDetailSideBar");
            var departmentDetailsSideBar = WebDriverUtil.GetWebElement(CloseDepartmentDetails, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (departmentDetailsSideBar == null) return;
            departmentDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }
        public static void DeleteCreatedDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing DepartmentPage.DeleteCreatedDepartment");
            CloseDepartmentDetailSideBar();
            var departmentRecordXpath = string.Format(DepartmentRecord, departmentName);
            WebDriverUtil.GetWebElement(departmentRecordXpath, WebDriverUtil.NO_WAIT,
            $"Unable to locate Department record on Departments page - {departmentRecordXpath}").Click();

            WebDriverUtil.GetWebElement(DepartmentDeleteButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate Department delete button on Department details - {DepartmentDeleteButton}").Click();

            WebDriverUtil.GetWebElement(DepartmentDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {DepartmentDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(DepartmentDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete department Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing DepartmentPage.VerifyCreatedDepartment");
            var departmentRecordXpath = string.Format(DepartmentRecord, departmentName);
            WebDriverUtil.GetWebElement(departmentRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate record Departments page - {departmentRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void AddNewDepartmentWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing DepartmentPage.AddNewDepartmentWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewDepartmentMenuLink();

            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input Departments page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button Departments page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(DepartmentsPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
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
        public static void UserClickOnNewDepartmentMenuLink()
        {
            LogWriter.WriteLog("Executing DepartmentPage.UserClickOnNewDepartmentMenuLink");
            WebDriverUtil.GetWebElement(AddDepartmentLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate New Department Menu menu link on add menu popup - {AddDepartmentLink}").Click();

        }
        public static void ClickOnDepartment()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnDepartment");
            WebDriverUtil.GetWebElement(ListManagementDropdown,
                WebDriverUtil.NO_WAIT, $"Unable to locate list management dropdown - {ListManagementDropdown}").Click();
            WebDriverUtil.GetWebElement(DepartmentValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate Department value - {DepartmentValueInLmDropdown}").Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Departments page  - {AddButton}").Click();

        }
        public static void CloseDepartmentForm()
        {
            LogWriter.WriteLog("Executing DepartmentPage.CloseDepartmentForm");
            WaitForDepartmentAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseDepartmentFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnListManagementTab");
            if (WebDriverUtil.GetWebElement(DepartmentPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null &&
                WebDriverUtil.GetWebElement(UnitOfMeasurePage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            WebDriverUtil.GetWebElement(ListManagementTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing DepartmentPage.ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null) return;
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForDepartmentAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing DepartmentPage.WaitForDepartmentAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
                WebDriverUtil.GetWebElementAndScroll(NameInput);

            }
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

