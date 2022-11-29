using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Classifications
{
    public class ClassificationsPage
    {
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string AddButton = "//button[@id='add']";
        private const string AddClassificationsLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseClassificationsFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseClassificationsDetails = "//button[text()='Close']";
        private const string CancelClassificationsDetails = "//button[contains(@class, 'cancel')]";
        private const string ClassificationsDeleteButton = "//button[contains(@class,'delete')]";
        private const string ClassificationsRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string ClassificationsDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string ClassificationsDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string ClassificationsPageTitle = "//*[@class='page-title' and contains(text(),'Classifications')]";
        private const string ClassificationsPopup = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Classification')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ListManagementTab = "//a[text()='List Management']";
        private const string ListManagementDropdown = "//select[@id='standardFilingFieldId']";
        private const string ClassificationsValueInLmDropdown = "//select[@id='standardFilingFieldId']//option[@value='CLASSIFICATIONS']";
        private const string SaveInprogress = "//button[contains(text(),'Saving...')]";
        private const string DeleteInprogress = "//button[contains(text(),'Deleting...')]";

        public static void DeleteClassificationsIfExist(string classificationsName)
        {
            LogWriter.WriteLog("Executing  ClassificationsPage.DeleteClassificationsIfExist");
            WaitForClassificationsAlertCloseIfAny();
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(ClassificationsRecord, classificationsName),
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedClassifications(classificationsName);
            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.ClickOnListManagementTab");
            if (WebDriverUtil.GetWebElement(ClassificationsPageTitle, WebDriverUtil.NO_WAIT,
                    WebDriverUtil.NO_MESSAGE) != null)
            {
                return;
            }
            WebDriverUtil.GetWebElement(ListManagementTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void CloseClassificationsDetailSideBar()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.CloseClassificationsDetailSideBar()");
            var classificationsDetailsSideBar = WebDriverUtil.GetWebElement(CloseClassificationsDetails,
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (classificationsDetailsSideBar != null)
            {
                classificationsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            classificationsDetailsSideBar = WebDriverUtil.GetWebElement(CancelClassificationsDetails,
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (classificationsDetailsSideBar == null)
            {
                return;
            }
            classificationsDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }

        public static void DeleteCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage.DeleteCreatedClassifications");
            var classificationsRecordXpath = string.Format(ClassificationsRecord, classificationsName);
            WebDriverUtil.GetWebElement(classificationsRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate classifications record on classifications page - {classificationsRecordXpath}").Click();

            WebDriverUtil.GetWebElement(ClassificationsDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate classifications delete button on classifications details page - {ClassificationsDeleteButton}").Click();
            
            var confirmationPopup = WebDriverUtil.GetWebElement(ClassificationsDeleteConfirmPopup,
                WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup == null)
            {
                return;
            }
            WebDriverUtil.GetWebElement(ClassificationsDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate confirm button on delete confirmation popup - {ClassificationsDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ClassificationsDeleteConfirmPopup,
                    WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete classifications Error - {formAlert.Text}");
            }
        }
        public static void VerifyCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage.VerifyCreatedClassifications");
            var classificationRecordXpath = string.Format(ClassificationsRecord, classificationsName);
            WebDriverUtil.GetWebElement(classificationRecordXpath, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record on classifications page - {classificationRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            CloseClassificationsDetailSideBar();
        }

        public static void FindClassificationByName(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage.FindClassificationByName");
            var classificationRecordXpath = string.Format(ClassificationsRecord, classificationsName);
            WebDriverUtil.GetWebElementAndScroll(classificationRecordXpath, WebDriverUtil.DEFAULT_WAIT,
                $"Unable to locate record on classifications page - {classificationRecordXpath}").Click();
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
            {
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.VerifyDeleteButtonIsNotPresent");
            var deleteButton = WebDriverUtil.GetWebElement(ClassificationsDeleteButton,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
            {
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void AddNewClassificationsWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing ClassificationsPage.AddNewClassificationsWithGivenInputIfNotExist");
            WaitForClassificationsAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(ClassificationsRecord, dictionary["Name"]),
                WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewClassificationsWithGivenInput(inputData);
            }
        }

        public static void AddNewClassificationsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing ClassificationsPage.AddNewClassificationsWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewClassificationsMenuLink();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on classifications page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on classifications page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(ClassificationsPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath,
                WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ClassificationsPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new classifications Error - {formAlert.Text}");
            }
        }
        public static void UserClickOnNewClassificationsMenuLink()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.UserClickOnNewClassificationsMenuLink");
            WebDriverUtil.GetWebElement(AddClassificationsLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate new classifications menu link on add menu popup - {AddClassificationsLink}").Click();
        }


        public static void ClickOnClassifications()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.ClickOnClassifications");
            WebDriverUtil.GetWebElement(ListManagementDropdown,
                WebDriverUtil.NO_WAIT, $"Unable to locate list management dropdown - {ListManagementDropdown}").Click();
            WebDriverUtil.GetWebElement(ClassificationsValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate classifications value - {ClassificationsValueInLmDropdown}").Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on classifications page  - {AddButton}").Click();

        }
        public static void CloseClassificationsForm()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.CloseClassificationsForm");
            WaitForClassificationsAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseClassificationsFormButton, WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null)
            {
                return;
            }
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForClassificationsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.WaitForClassificationsAlertCloseIfAny");
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                return;
            }
            WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
            WebDriverUtil.GetWebElementAndScroll(NameInput);
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
        }

        public static void AddNewClassificationsWithGivenInput(string classifications)
        {
            LogWriter.WriteLog("Executing ClassificationsPage.AddNewClassificationsWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewClassificationsMenuLink();

            if (classifications != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on classifications page  - {NameInput}")
                    .SendKeys(Util.ProcessInputData(classifications));
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on classifications page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(ClassificationsPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                return;
            }
            var formInputError = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputError != null)
            {
                return;
            }
            var formInputFieldError = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formInputFieldError != null)
            {
                return;
            }
            var formAlert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (formAlert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ClassificationsPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT,
                    "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new classifications Error - {formAlert.Text}");
            }
        }
        public static void VerifyAddButtonIsNotAvailable()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.VerifyAddButtonIsNotAvailable");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
            {
                throw new Exception("Add button is found but we expect it should not be present when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonAndEditOptionIsNotAvailable()
        {
            LogWriter.WriteLog("Executing ClassificationsPage.VerifyDeleteButtonAndEditOptionIsNotAvailable");
            var deleteButton = WebDriverUtil.GetWebElement(ClassificationsDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
                WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
            {
                throw new Exception("Delete button is found but we expect it should not be present when user login from admin only access");
            }
            var editTextBox = WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editTextBox.Enabled)
            {
                throw new Exception("Edit text box is enabled but we expect it should be disabled when user login from admin only access");
            }
            BaseClass._AttachScreenshot.Value = true;
        }

    }
}

