using laborpro.drivers;
using laborpro.hooks;
using laborpro.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace laborpro.pages
{
    public class CharacteristicsPage
    {
        const string Department_Filing_FieldId = "//select[@id='departmentId']";
        const string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        const string CHARACTERISTIC_TAB = "//a[text()='Characteristics']";
        const string ADD_BUTTON = "//button[@id='characteristics-list-actions']";
        const string ADD_CHARACTERISTIC_SET = "(//*[contains(@class,'dropdown open')]//a)[2]";
        const string ADD_CHARACTERISTIC_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_CHARACTERISTIC_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CREATED_CHARACTERISTIC_TITLE = "//*[@class='page-title' and contains(text(),'{0}')]";
        const string CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        const string EDIT_BUTTON = "//*[@title='{0}']/../button";
        const string DELETE_BUTTON = "//i[contains(@title,'Delete')]";
        const string CONFIRM_POPUP = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string RECORD_FOR_DEPT = "//td[contains(text(),'{0}')]";
        const string PAGE_TITLE = "//*[@class='page-title']";
        const string CLOSE_CHARACTERISTIC_DETAILS = "//button[text()='Close']";
        const string CANCEL_CHARACTERISTIC_DETAILS = "//button[contains(@class, 'cancel')]";
        const string CHARACTERISTIC_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string CHARACTERISTIC_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string CHARACTERISTIC_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string CLOSE_BUTTON = "//button[@id='newCHARACTERISTICs']";
        const string CHARACTERISTIC_PAGE = "//*[@class='page-title' and contains(text(),'Characteristics')]";
        const string CHARACTERISTIC_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Characteristic')]";
        public static void VerifyRecordOfSelectedDept(string message)
        {
            LogWriter.WriteLog("Executing  CharacteristicsPagee.VerifyRecordOfSelectedDept");
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
        public static void ClickOnCharacteristicTab()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage  ClickOnCharacteristicTab");
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
        public static void DeleteCreatedCharacteristicset(string CharacteristicsetName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage DeleteCreatedCharacteristicset");
            WebDriverUtil.GetWebElement(CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT,
            WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate the check Characteristicset of respective department- {0}",
            CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT)).Click();

            WebDriverUtil.GetWebElement(String.Format(EDIT_BUTTON, CharacteristicsetName),
            WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate Characteristicset record on Characteristicset page - {0}", String.Format(EDIT_BUTTON, CharacteristicsetName))).Click();

            WebDriverUtil.GetWebElement(DELETE_BUTTON,
            WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();

            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_CONFIRM_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                  String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitForWebElementInvisible(CHARACTERISTIC_DELETE_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }
            WebDriverUtil.GetWebElement(CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT,
            WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate the check Characteristicset of respective department- {0}",
            CHECK_CHARACTERISTIC_OF_RESPECTIVE_DEPARTMENT)).Click();

        }

        public static void DeleteCreatedCharacteristic(string CharacteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage DeleteCreatedCharacteristict");
            WebDriverUtil.GetWebElement(String.Format(CHARACTERISTIC_RECORD, CharacteristicName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate Characteristic record on Characteristics page - {0}", String.Format(CHARACTERISTIC_RECORD, CharacteristicName))).Click();

            WebDriverUtil.GetWebElement(String.Format(CHARACTERISTIC_DELETE_BUTTON, CharacteristicName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Characteristic delete button on Characteristic details - {0}", String.Format(CHARACTERISTIC_DELETE_BUTTON, CharacteristicName))).Click();

            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                  String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", CHARACTERISTIC_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitForWebElementInvisible(CHARACTERISTIC_DELETE_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void VerifyCreatedCharacteristic(string CharacteristicName)
        {
            LogWriter.WriteLog("Executing CharacteristicsPage VerifyCreatedCharacteristic");
            WebDriverUtil.GetWebElement(String.Format(CHARACTERISTIC_RECORD, CharacteristicName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record Characteristics page - {0}", String.Format(CHARACTERISTIC_RECORD, CharacteristicName)));
            BaseClass._AttachScreenshot.Value = true;
            CloseCharacteristicDetailSideBar();
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
            if (WebDriverUtil.GetWebElement(CHARACTERISTIC_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CHARACTERISTIC_POPUP, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }

        }

        public static void UserClickOnNewCharacteristicMenuLink()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnNewCharacteristicMenuLink");
            WebDriverUtil.GetWebElement(ADD_CHARACTERISTIC_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewCharacteristicMenu menu link on add menu popup - {0}", ADD_CHARACTERISTIC_LINK)).Click();

        }
        public static void UserClickOnNewCharacteristicsetMenuLink()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage UserClickOnNewCharacteristicsetMenuLink");
            WebDriverUtil.GetWebElement(ADD_CHARACTERISTIC_SET, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewCharacteristicMenu menu link on add menu popup - {0}", ADD_CHARACTERISTIC_SET)).Click();

        }

        public static void ClickOnCharacteristicset()
        {
            LogWriter.WriteLog("Executing CharacteristicsPage ClickOnCharacteristicse");
            ClickOnAddButton();
            UserClickOnNewCharacteristicsetMenuLink();

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
            IWebElement standardtab = WebDriverUtil.GetWebElement(STANDARD_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardtab != null)
            {
                standardtab.Click();
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