using LaborPro.Automation.Features.VolumeDriverValue;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace LaborPro.Automation.Features.LaborPeriods
{
    public class LaborPeriodsPage
    {
        const string KRONOS_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Kronos')]";
        const string LABOR_PERIODS_TAB = "//a[text()='Labor Periods']";
        const string LABOR_PERIODS_PAGE = "//h3[text()='Labor Periods']";
        const string ADD_LABOR_PERIOD = "//button[@id='laborPeriods-list-actions']//i";
        const string NEW_LABOR_PERIOD = "//*[@role='presentation']//a[text()='New Labor Period']";
        const string CREATE_LABOR_PERIOD_PAGE = "//*[@class='page-header']//h3[text()='Create Labor Period']";
        const string CREATE_LABOR_PERIOD_VERIFICATION = "//*[@class='page-header']//h3[text()='{0}']";
        const string CANCEL_BUTTON = "//*[@class='page-header']//button[text()='Cancel']";
        const string SAVE_BUTTON = "//*[@class='page-header']//button[text()='Save']";
        const string NAME_INPUT = "//input[@id='name']";
        const string LABOR_PERIOD_TYPE = "//select[@id='laborPeriodType']";
        const string TRAFFIC_PATTERN = "//select[@id='trafficPatternType']";
        const string LABOR_DISTRIBUTION = "//select[@id='laborDistributionType']";
        const string HOUSE_OF_OPERATION_VERIFICATION = "//*[@class='control-label' and text()='{0}']";
        const string HOUSE_OF_OPERATION_ADD_BUTTON = "//button//i[@title='Add']";
        const string LABOR_PERIOD_BY_NAME = "//*[@role='presentation']//td[@aria-colindex='1' and contains(text(),'{0}')]";
        const string EDIT_LABOR_PERIOD_PAGE = "//*[@class='page-header']//h3[text()='Edit Labor Period']";
        const string DELETE_BUTTON_LABOR_PERIOD = "//button//i[@title='Delete']";
        const string CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string CONFIRM_BUTTON = "//*[@class='modal-content']//button[text()='Confirm']";
        const string LABOR_PERIOD_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        const string NAME = "Name";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string CLEAR_FILTER_BUTTON = "//button[@title='Clear All Filters']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//span[@class='validation-error help-block' and contains(text(),'{0}')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";


        public static void ClickOnKronosTab()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnKronosTab");
            if (WebDriverUtil.GetWebElement(KRONOS_TAB, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(KRONOS_TAB, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnLaborPeriodsTab()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnLaborPeriodsTab");
            if (WebDriverUtil.GetWebElement(LABOR_PERIODS_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(LABOR_PERIODS_TAB, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void AddLaborPeriod()
        {
            LogWriter.WriteLog("LaborPeriodsPage. AddLaborPeriod");
            if (WebDriverUtil.GetWebElement(LABOR_PERIODS_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(ADD_LABOR_PERIOD, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
                if (WebDriverUtil.GetWebElement(NEW_LABOR_PERIOD, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
                {
                    WebDriverUtil.GetWebElement(NEW_LABOR_PERIOD, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                    WebDriverUtil.WaitForAWhile();
                }
            }
        }
        public static void CreateLaborPeriodPageVerification(string createLaborPeriod)
        {
            LogWriter.WriteLog("LaborPeriodsPage.CreateLaborPeriodPageVerification");
            if (WebDriverUtil.GetWebElement(CREATE_LABOR_PERIOD_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(CREATE_LABOR_PERIOD_VERIFICATION, createLaborPeriod),
                WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate Create LaborPeriod Page - {0}",
                String.Format(CREATE_LABOR_PERIOD_VERIFICATION, createLaborPeriod)));
                BaseClass._AttachScreenshot.Value = true;
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void ClickOnCancelButton()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnCancelButton");
            if (WebDriverUtil.GetWebElement(CANCEL_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CANCEL_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnSaveButton()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClickOnSaveButton");
            if (WebDriverUtil.GetWebElement(SAVE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(SAVE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void AddLaborPeriod(Table inputData)
        {
            LogWriter.WriteLog("LaborPeriodsPage.AddLaborPeriod");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate name input on create LaborPeriod page - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "LaborPeriodType") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LABOR_PERIOD_TYPE, WebDriverUtil.NO_WAIT,
                  String.Format("Unable to locate LaborPeriodType input on create LaborPeriod page - {0}",
                  LABOR_PERIOD_TYPE))).SelectByText(dictionary["LaborPeriodType"]);
            }
            if (Util.ReadKey(dictionary, "TrafficPattern") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(TRAFFIC_PATTERN, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate TrafficPattern input on create LaborPeriod page - {0}", TRAFFIC_PATTERN)))
                    .SelectByText(dictionary["TrafficPattern"]);
            }
            if (Util.ReadKey(dictionary, "LaborDistribution") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(LABOR_DISTRIBUTION, WebDriverUtil.NO_WAIT,
                 String.Format("Unable to locate LaborDistribution input on create LaborPeriod page - {0}", LABOR_DISTRIBUTION)))
                     .SelectByText(dictionary["LaborDistribution"]);
            }

        }
        public static void VerifyHouseOfOperation(string houseofoperation)
        {
            LogWriter.WriteLog("LaborPeriodsPage.VerifyHouseOfOperation");
            if (WebDriverUtil.GetWebElement(SAVE_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(HOUSE_OF_OPERATION_VERIFICATION, houseofoperation), WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate the house of operation", String.Format(HOUSE_OF_OPERATION_VERIFICATION, houseofoperation)));
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void AddHouseOfOperation()
        {
            LogWriter.WriteLog("LaborPeriodsPage.AddHouseOfOperation");
            if (WebDriverUtil.GetWebElement(HOUSE_OF_OPERATION_ADD_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(HOUSE_OF_OPERATION_ADD_BUTTON,
                WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE).Click();
            }
            if (WebDriverUtil.GetWebElement(SAVE_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(SAVE_BUTTON,
                WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Save Button - {0}", SAVE_BUTTON)).Click();
            }
        }
        public static void VerifyLaborPeriodByName(string laborPeriod)
        {
            LogWriter.WriteLog("LaborPeriodsPage.VerifyLaborPeriodByName");
            if (WebDriverUtil.GetWebElement(LABOR_PERIODS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(LABOR_PERIOD_BY_NAME, laborPeriod), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static void DeleteLaborPeriod()
        {
            LogWriter.WriteLog("LaborPeriodsPage.DeleteLaborPeriod");
            if (WebDriverUtil.GetWebElement(EDIT_LABOR_PERIOD_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                if (WebDriverUtil.GetWebElement(DELETE_BUTTON_LABOR_PERIOD, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
                {
                    WebDriverUtil.GetWebElement(DELETE_BUTTON_LABOR_PERIOD,
                    WebDriverUtil.TEN_SECOND_WAIT,
                    String.Format("Unable to locate delete button - {0}",
                    DELETE_BUTTON_LABOR_PERIOD)).Click();

                    WebDriverUtil.GetWebElement(CONFIRM_BUTTON,
                    WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate the confirm BUTTON - {0}", CONFIRM_BUTTON)).Click();
                    WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
                    WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
                    IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (alert == null)
                    {
                        WebDriverUtil.WaitForWebElementInvisible( CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                    }
                    else
                    { 
                     throw new Exception(string.Format("Unable to delete Labor Period Error - {0}", alert.Text));
                    }

                }
            }
        }
        public static void SelectLaborPeriod(string laborPeriods)
        {
            LogWriter.WriteLog("LaborPeriodsPage.SelectLaborPeriod");
            if (WebDriverUtil.GetWebElement(LABOR_PERIODS_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(LABOR_PERIOD_BY_NAME, laborPeriods),
                WebDriverUtil.NO_WAIT,
                WebDriverUtil.NO_MESSAGE).Click();
            }
        }
        public static void SearchLaborPeriod(String LaborPeriod)
        {
            LogWriter.WriteLog("LaborPeriodsPage.SearchLaborPeriod");
            if (WebDriverUtil.GetWebElement(LABOR_PERIODS_PAGE, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(LABOR_PERIOD_FILTER_INPUT, VolumeDriverValuePage.FindColumnIndex(NAME)), WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate location filter input on LaborPeriod page - {0}", LABOR_PERIOD_FILTER_INPUT)).SendKeys(LaborPeriod);
                WebDriverUtil.WaitForAWhile();
                WaitForLoading();
            }

        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClearAllFilter");
            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(CLEAR_FILTER_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
        public static void DeleteRecordIfExist(string record)
        {
            LogWriter.WriteLog("LaborPeriodsPage.ClearAllFilter");
            SearchLaborPeriod(record);
            if (WebDriverUtil.GetWebElement(String.Format(LABOR_PERIOD_BY_NAME, record), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                SelectLaborPeriod(record);
                DeleteLaborPeriod();
            }
            else
            {
                ClearAllFilter();
            }
        }
        public static void VerifyAddLaborPeriodErrorMessage(string message)
        {
            LogWriter.WriteLog("LaborPeriodsPage.VerifyAddLaborPeriodErrorMessage");
            IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null)
            {
                string actualError = errorMessage.Text;
                if (!(actualError.ToLower()).Equals(message.ToLower()))
                    throw new Exception(String.Format("We supposed to get error message - {0} but getting - {1}", message, actualError));

            }
            BaseClass._AttachScreenshot.Value = true;
        }
    }
}
