using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.VolumeDriver
{
    public class VolumeDriverPage
    {
        const string standard_Filing_FieldId = "//select[@id='standardFilingFieldId']";
        const string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        const string LIST_MANAGEMENT_TAB = "//a[text()='List Management']";
        const string ADD_BUTTON = "//button[@id='create-volume-drivers']";
        const string ADD_VOLUMEDRIVER_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@id='name']";
        const string DEPARTMENT_INPUT = "//*[@id='departmentId']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_VOLUMEDRIVER_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CREATED_VOLUMEDRIVER_TITLE = "//*[@class='page-title' and contains(text(),'{0}')]";
        const string PAGE_TITLE = "//*[@class='page-title']";
        const string CLOSE_VOLUMEDRIVER_DETAILS = "//button[text()='Close']";
        const string CANCEL_VOLUMEDRIVER_DETAILS = "//button[text()='Cancel']]";
        const string VOLUMEDRIVER_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string VOLUMEDRIVER_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string VOLUMEDRIVER_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string VOLUMEDRIVER_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string CLOSE_BUTTON = "//button[@id='newVolumeDrivers']";
        const string VOLUMEDRIVER_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Volume Driver')]";
        const string VOLUME_DRIVER_FILTER_INPUT = "//th[@aria-colindex='1']//input";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string CLEAR_FILTER_BUTTON = "//button[@title='Clear All Filters']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";

        public static void CloseVolumeDriverDetailSideBar()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.CloseVolumeDriverDetailSideBar");
            IWebElement VolumeDriverDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_VOLUMEDRIVER_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (VolumeDriverDetailsSideBar != null)
            {
                VolumeDriverDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            VolumeDriverDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_VOLUMEDRIVER_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (VolumeDriverDetailsSideBar != null)
            {
                VolumeDriverDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void DeleteCreatedVolumeDriver(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.DeleteCreatedVolumeDriver");
            CloseVolumeDriverDetailSideBar();
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate VolumeDriver record on VolumeDrivers page - {0}", String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName))).Click();

            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_DELETE_BUTTON, VolumeDriverName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate VolumeDriver delete button on VolumeDriver details - {0}", String.Format(VOLUMEDRIVER_DELETE_BUTTON, VolumeDriverName))).Click();

            WebDriverUtil.GetWebElement(VOLUMEDRIVER_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", VOLUMEDRIVER_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVER_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Volume Driver Error - {0}", alert.Text));
            }
     
        }
        public static void VerifyCreatedVolumeDriver(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage VerifyCreatedDepartmen");
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record VolumeDrivers page - {0}", String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName)));
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void AddNewVolumeDriverWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage AddNewVolumeDriverWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewVolumeDriverMenuLink();
             WebDriverUtil.WaitForAWhile();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate Name input VolumeDrivers page  - {0}", NAME_INPUT))
                  .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Department") != null)
            {
                WebDriverUtil.GetWebElement(DEPARTMENT_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate Department input VolumeDrivers page  - {0}", DEPARTMENT_INPUT))
                  .SendKeys(dictionary["Department"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate save button VolumeDrivers page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            if (WebDriverUtil.GetWebElement( VOLUMEDRIVER_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ELEMENT_ALERT, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVER_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new VolumeDriver Error - {0}", alert.Text));
                        }
                    }
                }
            }

        }
        public static void AddNewVolumeDriverWithGivenInputifnotexist(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriversPage.AddVolumeDriverWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(VOLUMEDRIVER_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewVolumeDriverWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }

        }
        public static void DeleteVolumeDriverifexist(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriversPage.DeleteVolumeDriverifexist");
            WaitForVolumeDriverAlertCloseIfAny();
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedVolumeDriver(VolumeDriverName);
            }


        }

        public static void UserClickOnNewVolumeDriverMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage UserClickOnNewVolumeDriverMenuLink");
            WebDriverUtil.GetWebElement(ADD_VOLUMEDRIVER_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewVolumeDriverMenu menu link on add menu popup - {0}", ADD_VOLUMEDRIVER_LINK)).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnVolumeDriver()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage ClickOnVolumeDriver");
            new SelectElement(WebDriverUtil.GetWebElement(standard_Filing_FieldId, WebDriverUtil.FIVE_SECOND_WAIT,
            String.Format("Unable to locate standard_Filing_FieldId input VolumeDrivers page  - {0}", standard_Filing_FieldId)))
            .SelectByText("Volume Drivers");

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverPageClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button VolumeDrivers page  - {0}", ADD_BUTTON)).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void CloseVolumeDriverForm()
        {
            LogWriter.WriteLog("Executing VolumeDriverCloseVolumeDriverForm");
            WaitForVolumeDriverAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_VOLUMEDRIVER_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }

        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing VolumeDriver  ClickOnListManagementTab");
            CloseVolumeDriverDetailSideBar();
            IWebElement ListManagementTab = WebDriverUtil.GetWebElement(LIST_MANAGEMENT_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (ListManagementTab != null)
            {
                ListManagementTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }

        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing VolumeDriver.ClickOnStandardTab");
            IWebElement standardtab = WebDriverUtil.GetWebElement(STANDARD_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardtab != null)
            {
                standardtab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }

        public static void WaitForVolumeDriverAlertCloseIfAny()
        {
            LogWriter.WriteLog("VolumeDriver.WaitForVolumeDriverAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }

        public static void SearchvolumeDriver(String VolumeDriver)
        {
            LogWriter.WriteLog("VolumeDriver.SearchvolumeDriver");
            WebDriverUtil.GetWebElement(VOLUME_DRIVER_FILTER_INPUT, WebDriverUtil.NO_WAIT,
                 String.Format("Unable to locate VOLUME DRIVER FILTER INPUT - {0}", VOLUME_DRIVER_FILTER_INPUT)).SendKeys(VolumeDriver);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            LogWriter.WriteLog("VolumeDriver.WaitForLoading");
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("VolumeDriver.ClearAllFilter");
            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(CLEAR_FILTER_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }

    }
}
