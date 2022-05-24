using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Allowances
{
    public class AllowancePage
    {
        const string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        const string ALLOWANCE_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Allowances')]";
        const string CALCULATOR_TAB = "//a[text()='Calculator']";
        const string ADD_ALLOWANCE_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string ALLOWANCES_PAGE = "//*[@class='page-title' and text()='Allowances']";
        const string NAMETAG_INPUT = "//*[@id='name']";
        const string PAIDTIMETAG_INPUT = "//input[@id='paidTimeMinutes']";
        const string EXCLUDEDPAIDBREAK_INPUT = "//input[@id='excludedPaidBreaksMinutes']";
        const string RELEIFTIME_INPUT = "//input[@id='reliefTimeMinutes']";
        const string INCLUDEDPAID_INPUT = "//input[@id='includedPaidBreaksMinutes']";
        const string RESTCALCULATION_INPUT = "//select[@id='allowanceRestId']";
        const string MINORUNAVOIDABLE_INPUT = "//input[@id='minorUnavoidableDelayPercent']";
        const string ADDITIONALDELAY_INPUT = "//input[@id='additionalDelayPercent']";
        const string INCENTIVEOPPORTUNITYALLOWANCE_INPUT = "//input[@id='machineAllowancePercent']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_ALLOWANCE_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ALLOWANCE_DETAILS_MENU_BUTTON = "//button[.//*[@class='fa fa-list-ul']]";
        const string ALLOWANCE_EDIT_LINK = "//button[.//*[text()='edit']]";
        const string ALLOWANCE_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string ALLOWANCE_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string ALLOWANCE_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string PAGE_TITLE = "//*[@class='page-title']";
        const string CREATED_ALLOWANCE_TITLE = "//*[@class='page-title' and contains(text(),'{0}')]";
        const string ALLOWANCE_DETAILS_PAGE_PREBVIOUS_LINK = "//a[.//*[@class='fa fa-caret-left']]";
        const string ALLOWANCE_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string ALLOWANCE_FORM = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Allowance')]";
        const string CREATE_NEW_ALLOWANCE_MENU_OPTION = "//a[@role='menuitem' and text()='New Allowance']";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";

        public static void ClickOnPreviousLink()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnPreviousLink");
            WebDriverUtil.GetWebElement(ALLOWANCE_DETAILS_PAGE_PREBVIOUS_LINK, WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate previous button on Allowance details page - {0}", ALLOWANCE_DETAILS_PAGE_PREBVIOUS_LINK)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            
        }
        public static void VerifyErrorAlertMessage(String expectedMessage) 
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyErrorAlertMessage");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if(alert != null)
            {
                Console.WriteLine(alert.Text);
                if(!alert.Text.Contains(expectedMessage))
                    throw new Exception(string.Format("Error message is not being matched as we expected it should be - {0}", expectedMessage));
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static void WaitForAllowanceAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing AllowancesPage.WaitForAllowanceAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAMETAG_INPUT);
                if(nametag != null)
                {
                    nametag.Click();
                }
                if (WebDriverUtil.GetWebElement(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=null)
                {
                    WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);

                }
               
            }
        }
        public static void VerifyAddAllowanceErrorMessage(string message) 
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyAddAllowanceErrorMessage");
            IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if(errorMessage!=null)
            {
                string actualError = errorMessage.Text;
                if (!(actualError.ToLower()).Equals(message.ToLower()))
                    throw new Exception(String.Format("We supposed to get error message - {0} but getting - {1}", message, actualError));

            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnStandardTab");
            IWebElement standardtab = WebDriverUtil.GetWebElement(STANDARD_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if(standardtab!=null)
            {
                standardtab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnAllowanceTab()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnAllowanceTab");
            IWebElement allowanceTab = WebDriverUtil.GetWebElement(ALLOWANCE_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (allowanceTab!= null)
            {
                allowanceTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnCalculatorTab()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnCalculatorTab");
            if (WebDriverUtil.GetWebElement(ALLOWANCES_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE)==null)
            {
                WebDriverUtil.GetWebElement(CALCULATOR_TAB, WebDriverUtil.DEFAULT_WAIT, String.Format("Unable to locate Calculator tab - {0}", CALCULATOR_TAB)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void CloseAllowanceForm()
        {
            LogWriter.WriteLog("Executing AllowancesPage.CloseAllowanceForm");
            WaitForAllowanceAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_ALLOWANCE_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnAddAllowanceButton()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnAddAllowanceButton");
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.GetWebElement(ADD_ALLOWANCE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, 
                String.Format("Unable to locate add allowance button on Allowance page - {0}", ADD_ALLOWANCE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            IWebElement menuOption = WebDriverUtil.GetWebElement(CREATE_NEW_ALLOWANCE_MENU_OPTION, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if(menuOption!=null)
            {
                menuOption.Click();
            }
            
        }
        public static void AddAllowanceWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing AllowancesPage.AddAllowanceWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(ALLOWANCE_RECORD, dictionary["Name"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddAllowanceWithGivenInput(inputData);
            } 
            else 
            {
                record.Click();
            }
        }
        public static void AddAllowanceWithGivenInputToVerifyValidationMessage(Table inputData)
        {
            AddAllowanceWithGivenInput(inputData, true);
        }
        public static void AddAllowanceWithGivenInput(Table inputData)
        {
            AddAllowanceWithGivenInput(inputData, false);
        }
        public static void AddAllowanceWithGivenInput(Table inputData, Boolean negativeScenario)
        {
            LogWriter.WriteLog("Executing AllowancesPage.AddAllowanceWithGivenInput");
            ClickOnAddAllowanceButton();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            //Enter allowance name if provided
            if(Util.ReadKey(dictionary, "Name")!=null)
            {
                WebDriverUtil.GetWebElement(NAMETAG_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate name input on create allowance page - {0}", NAMETAG_INPUT))
                    .SendKeys(dictionary["Name"]);   
            }

            if (Util.ReadKey(dictionary, "Paid Time (Minutes)") != null)
            {
                WebDriverUtil.GetWebElement(PAIDTIMETAG_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Paid Time (Minutes) input on create allowance page - {0}", PAIDTIMETAG_INPUT))
                    .SendKeys(dictionary["Paid Time (Minutes)"]);
            }

            if (Util.ReadKey(dictionary, "Excluded Paid Breaks (Minutes)") != null)
            {
                WebDriverUtil.GetWebElement(EXCLUDEDPAIDBREAK_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Excluded Paid Breaks (Minutes) input on create allowance page - {0}", EXCLUDEDPAIDBREAK_INPUT))
                    .SendKeys(dictionary["Excluded Paid Breaks (Minutes)"]);
            }
            if (Util.ReadKey(dictionary, "Relief Time (Minutes)") != null)
            {
                WebDriverUtil.GetWebElement(RELEIFTIME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Relief Time (Minutes) input on create allowance page - {0}", RELEIFTIME_INPUT))
                    .SendKeys(dictionary["Relief Time (Minutes)"]);
            }
            if (Util.ReadKey(dictionary, "Included Paid Breaks (Minutes)") != null)
            {
                WebDriverUtil.GetWebElement(INCLUDEDPAID_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Included Paid Breaks (Minutes) input on create allowance page - {0}", INCLUDEDPAID_INPUT))
                    .SendKeys(dictionary["Included Paid Breaks (Minutes)"]);
            }
            if (Util.ReadKey(dictionary, "Rest Calculation") != null)
            {
                try 
                {
                    new SelectElement(WebDriverUtil.GetWebElement(RESTCALCULATION_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Rest Calculation input on create allowance page - {0}", RESTCALCULATION_INPUT)))
                    .SelectByText(dictionary["Rest Calculation"], true);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (Util.ReadKey(dictionary, "Minor Unavoidable Delay (Percent)") != null)
            {
                WebDriverUtil.GetWebElement(MINORUNAVOIDABLE_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Minor Unavoidable Delay (Percent) input on create allowance page - {0}", MINORUNAVOIDABLE_INPUT))
                    .SendKeys(dictionary["Minor Unavoidable Delay (Percent)"]);
            }
            if (Util.ReadKey(dictionary, "Additional Delay (Percent)") != null)
            {
                WebDriverUtil.GetWebElement(ADDITIONALDELAY_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Additional Delay (Percent) input on create allowance page - {0}", ADDITIONALDELAY_INPUT))
                    .SendKeys(dictionary["Additional Delay (Percent)"]);
            }
            if (Util.ReadKey(dictionary, "Incentive Opportunity Allowance (Percent)") != null)
            {
                WebDriverUtil.GetWebElement(INCENTIVEOPPORTUNITYALLOWANCE_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Incentive Opportunity Allowance (Percent) input on create allowance page - {0}", INCENTIVEOPPORTUNITYALLOWANCE_INPUT))
                    .SendKeys(dictionary["Incentive Opportunity Allowance (Percent)"]);
            }

            WebDriverUtil.GetWebElement(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button on create allowance page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);

            if (!negativeScenario)
            {
                if (WebDriverUtil.GetWebElement(ALLOWANCE_FORM, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                                WebDriverUtil.WaitForWebElementInvisible(ALLOWANCE_FORM, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                            }
                            else
                            {
                                throw new Exception(string.Format("Unable to create new allowance Error - {0}", alert.Text));
                            }
                        }
                    }

                }
            }
        }
        public static void DeleteAllowance()
        {
            LogWriter.WriteLog("Executing AllowancesPage.DeleteAllowance..");
            WebDriverUtil.GetWebElement(ALLOWANCE_DETAILS_MENU_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(ALLOWANCE_EDIT_LINK, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(ALLOWANCE_DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(ALLOWANCE_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ALLOWANCE_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete allowance Error - {0}", alert.Text));
            }
        }
        public static void VerifyCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyCreatedAllowance");
            IWebElement allowanceTitle = WebDriverUtil.GetWebElement(String.Format(CREATED_ALLOWANCE_TITLE, allowanceName), WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (allowanceTitle == null)
            {
                allowanceTitle = WebDriverUtil.GetWebElement(PAGE_TITLE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception(String.Format("We supposed to get Allowance tile - {0} but found - {1}", allowanceName, allowanceTitle.Text));
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void UserDeleteCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing AllowancesPage.UserDeleteCreatedAllowance");
            WebDriverUtil.GetWebElement(String.Format(ALLOWANCE_RECORD,allowanceName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate allowance record allowance page - {0}", String.Format(ALLOWANCE_RECORD, allowanceName))).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            DeleteAllowance();
        }
        public static void DeleteAllowanceIfExist(string allowanceName)
        {
            LogWriter.WriteLog("Executing  AllowancesPage.DeleteAllowanceIfExist");
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(ALLOWANCE_RECORD, allowanceName ), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                UserDeleteCreatedAllowance(allowanceName);
            }


        }
    }
}
