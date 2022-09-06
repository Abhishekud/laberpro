using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util; 

namespace LaborPro.Automation.Features.LaborCategories
{
    public class LaborCategoriesPage
    {
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string AddButton = "//button[@id='add']";
        private const string AddLaborCategoriesLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseLaborCategoriesFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseLaborCategoriesDetails = "//button[text()='Close']";
        private const string CancelLaborCategoriesDetails = "//button[contains(@class, 'cancel')]";
        private const string LaborCategoriesDeleteButton = "//button[contains(@class,'delete')]";
        private const string LaborCategoriesRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string LaborCategoriesDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string LaborCategoriesDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string LaborCategoriesPageTitle = "//*[@class='page-title' and contains(text(),'Labor Categories')]";
        private const string LaborCategoriesPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Labor Category')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ListManagementTab = "//a[text()='List Management']";
        private const string ListManagementDropdown = "//select[@id='standardFilingFieldId']";
        private const string LaborCategoriesValueInLmDropdown = "//select[@id='standardFilingFieldId']//option[@value='LABOR_CATEGORIES']";
        private const string ExportButton = "//button[@id='export']";

        public static void DeleteLaborCategoriesIfExist(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing  LaborCategoriesPage.DeleteLaborCategoriesIfExist");
            WaitForLaborCategoriesAlertCloseIfAny();
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(LaborCategoriesRecord, laborCategoriesName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedLaborCategories(laborCategoriesName);
            }
        } 
        public static void VerifyExportOptionIsNotPresent()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage.VerifyExportOptionIsNotPresent"); 
            var exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton != null)
                throw new Exception("Export Option is found but we expect it should not be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
           }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage.ClickOnListManagementTab");
            if (WebDriverUtil.GetWebElement(LaborCategoriesPageTitle, WebDriverUtil.NO_WAIT,
                    WebDriverUtil.NO_MESSAGE) != null) return;
            WebDriverUtil.GetWebElement(ListManagementTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void CloseLaborCategoriesDetailSideBar()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage CloseLaborCategoriesDetailSideBar()");
            var laborCategoriesDetailsSideBar = WebDriverUtil.GetWebElement(CloseLaborCategoriesDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (laborCategoriesDetailsSideBar != null)
            {
                laborCategoriesDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            laborCategoriesDetailsSideBar = WebDriverUtil.GetWebElement(CancelLaborCategoriesDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (laborCategoriesDetailsSideBar == null) return;
            laborCategoriesDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        
        public static void DeleteCreatedLaborCategories(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage DeleteCreatedLaborCategories");
            var laborCategoriesRecordXpath = string.Format(LaborCategoriesRecord, laborCategoriesName);
            WebDriverUtil.GetWebElement(laborCategoriesRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate LaborCategories record on LaborCategories page - {laborCategoriesRecordXpath}").Click();

            var laborCategoriesDeleteButtonXpath = string.Format(LaborCategoriesDeleteButton, laborCategoriesName);
            WebDriverUtil.GetWebElement(laborCategoriesDeleteButtonXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate LaborCategories delete button on LaborCategories details - {laborCategoriesDeleteButtonXpath}").Click();


            var confirmationPopup = WebDriverUtil.GetWebElement(LaborCategoriesDeleteConfirmPopup, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup == null) return;
            WebDriverUtil.GetWebElement(LaborCategoriesDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {LaborCategoriesDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LaborCategoriesDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete LaborCategories Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedLaborCategories(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage VerifyCreatedLaborCategories");
            var laborCategoriesRecordXpath = string.Format(LaborCategoriesRecord, laborCategoriesName);
            WebDriverUtil.GetWebElement(laborCategoriesRecordXpath, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record on LaborCategories page - {laborCategoriesRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            CloseLaborCategoriesDetailSideBar();
        }

        public static void FindLaborCategoriesByName(string laborCategoriesName)
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage FindLaborCategoriesByName");
            var laborCategoriesRecordXpath = string.Format(LaborCategoriesRecord, laborCategoriesName);
            WebDriverUtil.GetWebElement(laborCategoriesRecordXpath, WebDriverUtil.DEFAULT_WAIT,
                $"Unable to locate record on LaborCategories page - {laborCategoriesRecordXpath}").Click();
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add Button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage.VerifyDeleteButtonIsNotPresent");
            var deleteButton = WebDriverUtil.GetWebElement(LaborCategoriesDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete Button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value=true;
        }

        public static void AddNewLaborCategoriesWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage AddNewLaborCategoriesWithGivenInputIfNotExist");
            WaitForLaborCategoriesAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            var laborCategoriesRecordXpath = string.Format(LaborCategoriesRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(laborCategoriesRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewLaborCategoriesWithGivenInput(inputData);
            }
        }

        public static void AddNewLaborCategoriesWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage AddNewLaborCategoriesWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewLaborCategoriesMenuLink();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on LaborCategories page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on LaborCategories page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(LaborCategoriesPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LaborCategoriesPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new LaborCategories Error - {alert.Text}");
            }
        }
        public static void UserClickOnNewLaborCategoriesMenuLink()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage UserClickOnNewLaborCategoriesMenuLink");
            WebDriverUtil.GetWebElement(AddLaborCategoriesLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate NewLaborCategoriesMenu menu link on add menu popup - {AddLaborCategoriesLink}").Click();
        }
      
        
        public static void ClickOnLaborCategories()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage ClickOnLaborCategories");
            WebDriverUtil.GetWebElement(ListManagementDropdown,
                WebDriverUtil.NO_WAIT, $"Unable to locate list management dropdown - {ListManagementDropdown}").Click();
            WebDriverUtil.GetWebElement(LaborCategoriesValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate LaborCategories value - {LaborCategoriesValueInLmDropdown}").Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on LaborCategories page  - {AddButton}").Click();

        }
        public static void CloseLaborCategoriesForm()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage CloseLaborCategoriesForm");
            WaitForLaborCategoriesAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseLaborCategoriesFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null) return;
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForLaborCategoriesAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing LaborCategoriesPage WaitForLaborCategoriesAlertCloseIfAny ");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
            WebDriverUtil.GetWebElementAndScroll(NameInput);
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

