using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.Characteristic
{
    public class CharacteristicsPage
    {
        const string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        const string CHARACTERISTIC_TAB = "//a[text()='Characteristics']";
        const string ADD_BUTTON = "//button[@id='characteristics-list-actions']";
        const string ADD_CHARACTERISTIC_SET = "(//*[contains(@class,'dropdown open')]//a)[2]";
        const string ADD_CHARACTERISTIC_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_CHARACTERISTIC_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        const string EDIT_BUTTON = "//*[@title='{0}']/../button";
        const string DELETE_BUTTON = "//i[contains(@title,'Delete')]";
        const string RECORD_FOR_DEPT = "//td[contains(text(),'{0}')]";
        const string CLOSE_CHARACTERISTIC_DETAILS = "//button[text()='Close']";
        const string CANCEL_CHARACTERISTIC_DETAILS = "//button[contains(@class, 'cancel')]";
        const string CHARACTERISTIC_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string CHARACTERISTIC_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string CHARACTERISTIC_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string TABLE_HEADER = "//th";
        const string CHARACTERISTIC_PAGE = "//*[@class='page-title' and contains(text(),'Characteristics')]";
        const string CHARACTERISTIC_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Characteristic')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string CHARACTERISTIC_HEADER = "//a[contains(text(),'{0}')]";
        const string EXPORT_BUTTON = "//button[@id='export']";
        const string EXPORT_CHARACTERISTIC = "//a[text()='Export All Characteristics (.xlsx)']";
        const string EDIT_DETAILS_BUTTON = "//button[text()='Edit']";

        public static void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing  CharacteristicsPage.VerifyRecordOfSelectedDept");
            IWebElement recordOfDept = WebDriverUtil.GetWebElement(String.Format(RECORD_FOR_DEPT, message), WebDriverUtil.NO_WAIT, String.Format("Unable to locate record - {0}", String.Format(RECORD_FOR_DEPT, message)));
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void CharacteristicWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing  CharacteristicPage.AddCharacteristicWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(CHARACTERISTIC_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewCharacteristicWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }
        }
        
        public static void DeleteCharacteristicSetIfExist(string characteristicName)
        {
            LogWriter.WriteLog("Executing  CharacteristicPage.DeleteCharacteristicSetIfExist");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                string headerData = header.GetAttribute("innerHTML");
                if (headerData.Contains(characteristicName))
                {

                    DeleteCreatedCharacteristicSet(characteristicName);
                    break;

                }

            }
        }   
        public static void DeleteCharacteristicIfExist(string characteristicName)
        {
            LogWriter.WriteLog("Executing  CharacteristicPage.DeleteCharacteristicIfExist");
            WaitForCharacteristicAlertCloseIfAny();
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(CHARACTERISTIC_RECORD, characteristicName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedCharacteristic(characteristicName);
            }
        }
        public static void ClickOnCharacteristicTab()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage.ClickOnCharacteristicTab");
            CloseCharacteristicDetailSideBar();
            if (WebDriverUtil.GetWebElement(CHARACTERISTIC_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(CHARACTERISTIC_TAB, WebDriverUtil.DEFAULT_WAIT, String.Format("Unable to locate Characteristic tab - {0}", CHARACTERISTIC_TAB)).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void CloseCharacteristicDetailSideBar()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage CloseCharacteristicDetailSideBar()");
            IWebElement CharacteristicDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_CHARACTERISTIC_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (CharacteristicDetailsSideBar != null)
            {
                CharacteristicDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            CharacteristicDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_CHARACTERISTIC_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (CharacteristicDetailsSideBar != null)
            {
                CharacteristicDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void DeleteCreatedCharacteristicSet(string characteristicSetName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage DeleteCreatedCharacteristicSet");


            WebDriverUtil.GetWebElement(CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT,
                WebDriverUtil.NO_WAIT,
                String.Format
                ("Unable to locate the check Characteristic set of respective department- {0}",
                CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT)).Click();


            WebDriverUtil.GetWebElement(String.Format(EDIT_BUTTON, characteristicSetName),
                WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate Characteristic set record on Characteristic set page - {0}"
            , String.Format(EDIT_BUTTON, characteristicSetName))).Click();

            WebDriverUtil.GetWebElement(DELETE_BUTTON,
                  WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CHARACTERISTIC_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Characteristic Error - {0}", alert.Text));
            }
            
            WebDriverUtil.GetWebElement(CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT,
               WebDriverUtil.ONE_SECOND_WAIT,
               String.Format
               ("Unable to locate the check Characteristic set of respective department- {0}",
           CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT)).Click();
        }
        public static void DeleteCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage DeleteCreatedCharacteristic");

            WebDriverUtil.GetWebElement(String.Format(CHARACTERISTIC_RECORD, characteristicName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate Characteristic record on Characteristics page - {0}", String.Format(CHARACTERISTIC_RECORD, characteristicName))).Click();


            WebDriverUtil.GetWebElement(String.Format(CHARACTERISTIC_DELETE_BUTTON, characteristicName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Characteristic delete button on Characteristic details - {0}", String.Format(CHARACTERISTIC_DELETE_BUTTON, characteristicName))).Click();


            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
                WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
                IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (alert == null)
                {
                    WebDriverUtil.WaitForWebElementInvisible(CHARACTERISTIC_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                }
                else
                {
                    throw new Exception(string.Format("Unable to delete Characteristic Error - {0}", alert.Text));
                }
            }
        }
        public static void VerifyCreatedCharacteristic(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage VerifyCreatedCharacteristic");
            WebDriverUtil.GetWebElement(String.Format(CHARACTERISTIC_RECORD, characteristicName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record Characteristics page - {0}", String.Format(CHARACTERISTIC_RECORD, characteristicName)));
            BaseClass._AttachScreenshot.Value = true;
            CloseCharacteristicDetailSideBar();
        }
        public static void VerifyCreatedCharacteristicSet(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicPage.VerifyCreatedCharacteristicSet");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TABLE_HEADER));
            Boolean found = false;
            foreach (IWebElement header in headers)
            {
                string headerData = header.GetAttribute("innerHTML");
                if (headerData.Contains(characteristicName))
                {
                    found = true;
                    WebDriverUtil.GetWebElementAndScroll(String.Format(CHARACTERISTIC_RECORD, characteristicName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                    BaseClass._AttachScreenshot.Value = true;
                    break;

                }
            }
            if (!found)
                throw new Exception(string.Format("No characteristic set found - {0} but we expect it should be display!", characteristicName));

        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing CharacteristicPage.VerifyAddButtonIsNotPresent");
            IWebElement addButton = WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton == null)
            {
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void VerifyDeleteButtonIsNotPresent(string characteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicPage.VerifyDeleteButtonIsNotPresent");
            WebDriverUtil.GetWebElement(String.Format(CHARACTERISTIC_RECORD, characteristicName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate UnitOfMeasure record on UnitOfMeasures page - {0}", String.Format(CHARACTERISTIC_RECORD, characteristicName))).Click();
            IWebElement deleteButton = WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton == null)
            {
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing CharacteristicPage.VerifyExportOptionIsNotPresent");
            WebDriverUtil.GetWebElement(EXPORT_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            IWebElement exportButton = WebDriverUtil.GetWebElement( EXPORT_CHARACTERISTIC, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);

            if (exportButton != null)
            {
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void VerifyEditButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing CharacteristicPage.VerifyEditButtonIsNotPresent");
            WebDriverUtil.GetWebElement(CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT,
              WebDriverUtil.NO_WAIT,
              String.Format
              ("Unable to locate the check Characteristicset of respective department- {0}",
              CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT)).Click(); 
            IWebElement editButton = WebDriverUtil.GetWebElement( EDIT_DETAILS_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);

            if (editButton == null)
            {
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void AddNewCharacteristicWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage AddNewCharacteristicWithGivenInput");

            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input Characteristics page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button Characteristics page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(CHARACTERISTIC_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(CHARACTERISTIC_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Characteristics Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void UserClickOnNewCharacteristicMenuLink()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnNewCharacteristicMenuLink");
            WebDriverUtil.GetWebElement(ADD_CHARACTERISTIC_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewCharacteristicMenu menu link on add menu popup - {0}", ADD_CHARACTERISTIC_LINK)).Click();
        }
        public static void UserClickOnNewCharacteristicSetMenuLink()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnNewCharacteristicsetMenuLink");
            WebDriverUtil.GetWebElement(ADD_CHARACTERISTIC_SET, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate  New Characteristic set menu link on add menu popup - {0}", ADD_CHARACTERISTIC_SET)).Click();
        }
        public static void ClickOnCharacteristicSet()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage ClickOnCharacteristicSet");

            ClickOnAddButton();
            UserClickOnNewCharacteristicSetMenuLink();

        }
        public static void ClickOnCharacteristic()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage ClickOnCharacteristic");
            ClickOnAddButton();
            UserClickOnNewCharacteristicMenuLink();
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button Characteristics page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseCharacteristicForm()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage CloseCharacteristicForm");
            WaitForCharacteristicAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_CHARACTERISTIC_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage ClickOnStandardTab");
            IWebElement standardtTab = WebDriverUtil.GetWebElement(STANDARD_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardtTab != null)
            {
                standardtTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForCharacteristicAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage WaitForCharacteristicAlertCloseIfAny ");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }

    }
}

