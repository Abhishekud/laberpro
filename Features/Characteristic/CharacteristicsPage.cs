using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.Characteristic
{
    public class CharacteristicsPage
    {
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string CharacteristicTab = "//a[text()='Characteristics']";
        private const string AddButton = "//button[@id='characteristics-list-actions']";
        private const string AddCharacteristicSet = "(//*[contains(@class,'dropdown open')]//a)[2]";
        private const string AddCharacteristicLink = "(//*[contains(@class,'dropdown open')]//a)[1]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseCharacteristicFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CheckCharacteristicOfRespectiveDepartment = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        private const string EditButton = "//*[@title='{0}']/../button";
        private const string DeleteButton = "//i[contains(@title,'Delete')]";
        private const string RecordForDept = "//td[contains(text(),'{0}')]";
        private const string CloseCharacteristicDetails = "//button[text()='Close']";
        private const string CancelCharacteristicDetails = "//button[contains(@class, 'cancel')]";
        private const string CharacteristicDeleteButton = "//button[contains(@class,'delete')]";
        private const string CharacteristicRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string CharacteristicDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string CharacteristicDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string TableHeader = "//th";
        private const string CharacteristicPage = "//*[@class='page-title' and contains(text(),'Characteristics')]";
        private const string CharacteristicPopup = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Characteristic')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string CharacteristicHeader = "//a[contains(text(),'{0}')]";
        private const string ExportButton = "//button[@id='export']";
        private const string ExportCharacteristic = "//a[text()='Export All Characteristics (.xlsx)']";
        private const string EditDetailsButton = "//button[text()='Edit']";
        private const string DepartmentDropdownValue = "//select[contains(@id,'departmentId')]//option[contains(text(),'{0}')]";
        private const string DepartmentDropdown = "//select[contains(@id,'departmentId')]";
        private const string SaveInprogress = "//button[contains(text(),'Saving...')]";
        private const string DeleteInprogress = "//button[contains(text(),'Deleting...')]";
        public static void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing  CharacteristicsPage.VerifyRecordOfSelectedDept");
            var departmentRecordXpath = string.Format(RecordForDept, message);
            WebDriverUtil.GetWebElement(departmentRecordXpath, WebDriverUtil.NO_WAIT, $"Unable to locate record - {departmentRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void AddCharacteristicWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing  CharacteristicsPage.AddCharacteristicWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            var characteristicRecordXpath = string.Format(CharacteristicRecord, dictionary["Name"]);
            var record = WebDriverUtil.GetWebElementAndScroll(characteristicRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                ClickOnAddButton();
                UserClickOnNewCharacteristicMenuLink();
                AddNewCharacteristicWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }

        public static void DeleteCharacteristicSetIfExist(string characteristicName)
        {
            LogWriter.WriteLog("Executing  CharacteristicsPage.DeleteCharacteristicSetIfExist");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TableHeader));

            if (headers.Select(header => header.GetAttribute("innerHTML")).Any(headerData => headerData.Contains(characteristicName)))
            {
                DeleteCreatedCharacteristicSet(characteristicName);
            }
        }
        public static void DeleteCharacteristicIfExist(string characteristicName)
        {
            LogWriter.WriteLog("Executing  CharacteristicsPage.DeleteCharacteristicIfExist");
            WaitForCharacteristicAlertCloseIfAny();
            var characteristicRecordXpath = string.Format(CharacteristicRecord, characteristicName);
            var record = WebDriverUtil.GetWebElementAndScroll(characteristicRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedCharacteristic(characteristicName);
            }
        }
        public static void ClickOnCharacteristicTab()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.ClickOnCharacteristicTab");
            CloseCharacteristicDetailSideBar();
            if (WebDriverUtil.GetWebElement(CharacteristicPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            WebDriverUtil.GetWebElement(CharacteristicTab, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate Characteristic tab - {CharacteristicTab}").Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void CloseCharacteristicDetailSideBar()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.CloseCharacteristicDetailSideBar");
            var characteristicDetailsSideBar = WebDriverUtil.GetWebElement(CloseCharacteristicDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (characteristicDetailsSideBar != null)
            {
                characteristicDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            characteristicDetailsSideBar = WebDriverUtil.GetWebElement(CancelCharacteristicDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (characteristicDetailsSideBar == null) return;
            characteristicDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void DeleteCreatedCharacteristicSet(string characteristicSetName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.DeleteCreatedCharacteristicSet");

            WebDriverUtil.GetWebElement(CheckCharacteristicOfRespectiveDepartment,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate the check Characteristic set of respective department- {CheckCharacteristicOfRespectiveDepartment}").Click();

            var editButtonXpath = string.Format(EditButton, characteristicSetName);
            WebDriverUtil.GetWebElement(editButtonXpath,
                WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate Characteristic set record on Characteristic page - {editButtonXpath}").Click();

            WebDriverUtil.GetWebElement(DeleteButton,
                  WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate delete button - {DeleteButton}").Click();

            WebDriverUtil.GetWebElement(CharacteristicDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {CharacteristicDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CharacteristicDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Characteristic Error - {alert.Text}");
            }

            WebDriverUtil.GetWebElement(CheckCharacteristicOfRespectiveDepartment,
               WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate the check Characteristic set of respective department- {CheckCharacteristicOfRespectiveDepartment}").Click();
        }
        public static void DeleteCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.DeleteCreatedCharacteristic");
            var characteristicRecordXpath = string.Format(CharacteristicRecord, characteristicName);

            WebDriverUtil.GetWebElement(characteristicRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate Characteristic record on Characteristics page - {characteristicRecordXpath}").Click();


            WebDriverUtil.GetWebElement(CharacteristicDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate Characteristic delete button on Characteristic details - {CharacteristicDeleteButton}").Click();


            var confirmationPopup = WebDriverUtil.GetWebElement(CharacteristicDeleteConfirmPopup, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup == null) return;
            WebDriverUtil.GetWebElement(CharacteristicDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {CharacteristicDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CharacteristicDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Characteristic Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.VerifyCreatedCharacteristic");
            var characteristicRecordXpath = string.Format(CharacteristicRecord, characteristicName);
            WebDriverUtil.GetWebElement(characteristicRecordXpath, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record Characteristics page - {characteristicRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            CloseCharacteristicDetailSideBar();
        }
        public static void VerifyCreatedCharacteristicSet(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.VerifyCreatedCharacteristicSet");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TableHeader));
            var found = false;
            var characteristicHeaderWithName = string.Format(CharacteristicHeader, characteristicName);
            if (headers.Select(header => header.GetAttribute("innerHTML")).Any(headerData => !headerData.Contains(characteristicName)))
            {
                found = true;
                WebDriverUtil.GetWebElementAndScroll(characteristicHeaderWithName,
                    WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                BaseClass._AttachScreenshot.Value = true;
            }
            if (!found)
                throw new Exception($"No characteristic set found - {characteristicName} but we expect it should be display!");

        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.VerifyDeleteButtonIsNotPresent");
            var characteristicRecordXpath = string.Format(CharacteristicRecord, characteristicName);
            WebDriverUtil.GetWebElement(characteristicRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate Characteristics record on Characteristics page - {characteristicRecordXpath}").Click();
            var deleteButton = WebDriverUtil.GetWebElement(CharacteristicDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.VerifyExportOptionIsPresent");
            WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            var exportButton = WebDriverUtil.GetWebElement(ExportCharacteristic, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("Export option is not found but we expect it should be present as logged in user has view only access!");
            BaseClass._AttachScreenshot.Value = true;
        }


        public static void VerifyEditButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.VerifyEditButtonIsNotPresent");
            WebDriverUtil.GetWebElement(CheckCharacteristicOfRespectiveDepartment,
              WebDriverUtil.NO_WAIT, $"Unable to locate the check Characteristic set of respective department- {CheckCharacteristicOfRespectiveDepartment}").Click();
            var editButton = WebDriverUtil.GetWebElement(EditDetailsButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editButton != null)
                throw new Exception("Edit button is enabled but we expect it should be disabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddNewCharacteristicWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.AddNewCharacteristicWithGivenInput");

            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input Characteristics page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button Characteristics page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
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
        public static void UserClickOnNewCharacteristicMenuLink()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.UserClickOnNewCharacteristicMenuLink");
            WebDriverUtil.GetWebElement(AddCharacteristicLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate New Characteristic menu link on add menu popup - {AddCharacteristicLink}").Click();
        }
        public static void UserClickOnNewCharacteristicSetMenuLink()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.UserClickOnNewCharacteristicSetMenuLink");
            WebDriverUtil.GetWebElement(AddCharacteristicSet, WebDriverUtil.NO_WAIT,
            $"Unable to locate  New Characteristic set menu link on add menu popup - {AddCharacteristicSet}").Click();
        }
        public static void ClickOnCharacteristicSet()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.ClickOnCharacteristicSet");
            ClickOnAddButton();
            UserClickOnNewCharacteristicSetMenuLink();

        }
        public static void ClickOnCharacteristic()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.ClickOnCharacteristic");
            ClickOnAddButton();
            UserClickOnNewCharacteristicMenuLink();
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Characteristics page  - {AddButton}").Click();

        }
        public static void CloseCharacteristicForm()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.CloseCharacteristicForm");
            WaitForCharacteristicAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseCharacteristicFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null) return;
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForCharacteristicAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.WaitForCharacteristicAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
            WebDriverUtil.GetWebElementAndScroll(NameInput);
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void SelectTheDepartment(string departmentName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.SelectTheDepartment");
            var departmentValue = string.Format(DepartmentDropdownValue, departmentName);
            WebDriverUtil.GetWebElement(DepartmentDropdown, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate the department dropdown - {DepartmentDropdown}").Click();
            WebDriverUtil.GetWebElement(departmentValue,
           WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate department record on characteristics page - {departmentValue}").Click();
            WebDriverUtil.WaitForAWhile();

        }
        public static void AddNewCharacteristicSet(string characteristicSet)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.AddNewCharacteristicSet");
            if (characteristicSet != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on characteristics page  - {NameInput}")
                    .SendKeys(Util.ProcessInputData(characteristicSet));
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on characteristics page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInprogress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
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
                throw new Exception($"Unable to create new characteristics Error - {alert.Text}");
            }
        }

    }
}

