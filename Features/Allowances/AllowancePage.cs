using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Assist;

namespace LaborPro.Automation.Features.Allowances
{
    public class AllowancePage
    {
        private const string StandardCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        private const string AllowanceCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Allowances')]";
        private const string CalculatorTab = "//a[text()='Calculator']";
        private const string AllowancesPage = "//*[@class='page-title' and contains( text(),'Allowances')]";
        private const string NameTagInput = "//*[@id='name']";
        private const string PaidTimeTagInput = "//input[@id='paidTimeMinutes']";
        private const string ExcludedPaidBreakInput = "//input[@id='excludedPaidBreaksMinutes']";
        private const string ReliefTimeInput = "//input[@id='reliefTimeMinutes']";
        private const string IncludedPaidInput = "//input[@id='includedPaidBreaksMinutes']";
        private const string RestCalculationInput = "//select[@id='allowanceRestId']";
        private const string MinorUnavoidableInput = "//input[@id='minorUnavoidableDelayPercent']";
        private const string AdditionalDelayInput = "//input[@id='additionalDelayPercent']";
        private const string IncentiveOpportunityAllowanceInput = "//input[@id='machineAllowancePercent']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseAllowanceFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string AllowanceEditLink = "//button[.//*[text()='edit']]";
        private const string AllowanceDeleteButton = "//button[contains(@class,'delete')]";
        private const string AllowanceDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string AllowanceDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string PageTitle = "//*[@class='page-title']";
        private const string AllowanceDetailsPagePreviousLink = "//a[.//*[@class='fa fa-caret-left']]";
        private const string CreateNewAllowanceMenuOption = "//a[@role='menuitem' and text()='New Allowance']";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string AllowanceReportButton = "//button[contains(@title,'Allowance Detail Report')]";
        private const string OpenEditSidebarForm = "//*[@class='sidebar-scrollable']//div[@class='form-group']";
        private const string CopyButton = "//button[contains(@class,'btn btn-sm btn-default')]";
        private const string AddAllowanceButton = "//button[.//*[@class='fa fa-plus']]";
        private const string AllowanceDetailsMenuButton = "//button[.//*[@class='fa fa-list-ul']]";
        private const string CreatedAllowanceTitle = "//*[@class='page-title' and contains(text(),'{0}')]";
        private const string AllowanceRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string SaveInProgress = "//button[contains(text(),'Saving...')]";
        private const string DeleteInProgress = "//button[contains(text(),'Deleting...')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string AllowanceForm = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Allowance')]";

        public static void ClickOnPreviousLink()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnPreviousLink");
            WebDriverUtil.GetWebElement(AllowanceDetailsPagePreviousLink, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate previous button on Allowance details page - {AllowanceDetailsPagePreviousLink}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

        }
        public static void VerifyCopyButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyCopyButtonIsNotPresent");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(AllowanceDetailsMenuButton,
                    WebDriverUtil.ONE_SECOND_WAIT,
                    $"Unable to locate allowance details sidebar button - {AllowanceDetailsMenuButton}"
                ).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            var copyButton = WebDriverUtil.GetWebElement(CopyButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (copyButton != null)
                throw new Exception("Copy button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDownloadAllowanceDetailsReportForAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyDownloadAllowanceDetailsReportForAllowance");
            var allowanceRecordXpath = string.Format(AllowanceRecord, allowanceName);
            WebDriverUtil.GetWebElement(allowanceRecordXpath, WebDriverUtil.NO_WAIT,
                $"Unable to locate allowance record on allowance page - {allowanceRecordXpath}").Click();
            var allowanceXpath = string.Format(CreatedAllowanceTitle, allowanceName);
            if (WebDriverUtil.GetWebElement(allowanceXpath, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var allowanceReportButton = WebDriverUtil.GetWebElement(AllowanceReportButton, WebDriverUtil.NO_WAIT,
               WebDriverUtil.NO_MESSAGE);
            if (allowanceReportButton == null)
                throw new Exception(
                      "Allowance Report button is not found but we expect it should be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddAllowanceButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyErrorAlertMessage(string expectedMessage)
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyErrorAlertMessage");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            Console.WriteLine(alert.Text);
            if (!alert.Text.Contains(expectedMessage))
                throw new Exception($"Error message is not being matched as we expected it should be - {expectedMessage}");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void WaitForAllowanceAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing AllowancesPage.WaitForAllowanceAlertCloseIfAny");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            var nameTag = WebDriverUtil.GetWebElementAndScroll(NameTagInput);
            if (nameTag != null)
            {
                nameTag.Click();
            }
            if (WebDriverUtil.GetWebElement(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);

            }
        }
        public static void VerifyAddAllowanceErrorMessage(string message)
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyAddAllowanceErrorMessage");
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null)
            {
                var actualError = errorMessage.Text;
                if (!(actualError.ToLower()).Equals(message.ToLower()))
                    throw new Exception($"We supposed to get error message - {message} but getting - {actualError}");

            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void ClickOnStandardTab()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnStandardTab");
            var standardTab = WebDriverUtil.GetWebElement(StandardCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardTab == null) return;
            standardTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnAllowanceTab()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnAllowanceTab");
            var allowanceTab = WebDriverUtil.GetWebElement(AllowanceCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (allowanceTab == null) return;
            allowanceTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnCalculatorTab()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnCalculatorTab");
            if (WebDriverUtil.GetWebElement(AllowancesPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) !=
                null) return;
            WebDriverUtil.GetWebElement(CalculatorTab, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate Calculator tab - {CalculatorTab}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void CloseAllowanceForm()
        {
            LogWriter.WriteLog("Executing AllowancesPage.CloseAllowanceForm");
            WaitForAllowanceAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseAllowanceFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton == null) return;
            formCloseButton.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void ClickOnAddAllowanceButton()
        {
            LogWriter.WriteLog("Executing AllowancesPage.ClickOnAddAllowanceButton");
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.GetWebElement(AddAllowanceButton, WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate add allowance button on Allowance page - {AddAllowanceButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            var menuOption = WebDriverUtil.GetWebElement(CreateNewAllowanceMenuOption, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (menuOption != null)
            {
                menuOption.Click();
            }

        }
        public static void DeleteAllowance()
        {
            LogWriter.WriteLog("Executing AllowancesPage.DeleteAllowance..");
            WebDriverUtil.GetWebElement(AllowanceDetailsMenuButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(AllowanceEditLink, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(AllowanceDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.GetWebElement(AllowanceDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(DeleteInProgress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(AllowanceDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete allowance Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing AllowancesPage.VerifyCreatedAllowance");
            var allowanceTitleXpath = string.Format(CreatedAllowanceTitle, allowanceName);
            var allowanceTitle = WebDriverUtil.GetWebElement(allowanceTitleXpath, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (allowanceTitle == null)
            {
                allowanceTitle = WebDriverUtil.GetWebElement(PageTitle, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception($"We supposed to get Allowance tile - {allowanceName} but found - {allowanceTitle.Text}");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void UserDeleteCreatedAllowance(string allowanceName)
        {
            LogWriter.WriteLog("Executing AllowancesPage.UserDeleteCreatedAllowance");
            var allowanceRecordXpath = string.Format(AllowanceRecord, allowanceName);
            WebDriverUtil.GetWebElement(allowanceRecordXpath, WebDriverUtil.NO_WAIT,
            $"Unable to locate allowance record allowance page - {allowanceRecordXpath}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            DeleteAllowance();
        }
        public static void AddAllowanceWithoutName()
        {
            LogWriter.WriteLog("Executing AllowancePage.AddAllowanceWithoutName");
            ClickOnAddAllowanceButton();
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create allowance page - {SaveButton}").Click();
            WebDriverUtil.WaitForWebElementInvisible(SaveInProgress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void AddAllowanceWithNameAndWithoutPaidTime(string name)
        {
            LogWriter.WriteLog("Exeuting AllowancePage.AddAllowanceWithNameAndWithoutPaidTime");
            ClickOnAddAllowanceButton();
            if (name != null)
            {
                WebDriverUtil.GetWebElement(NameTagInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create allowance page - {NameTagInput}")
                    .SendKeys(Util.ProcessInputData(name));
            }
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create allowance page - {SaveButton}").Click();
            WebDriverUtil.WaitForWebElementInvisible(SaveInProgress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);

        }
        public static void AddAllowanceWithNameAndPaidTime(string name, string paidTime)
        {
            LogWriter.WriteLog("Exeuting AllowancePage.AddAllowanceWithNameAndPaidTime");
            ClickOnAddAllowanceButton();
            if (name != null)
            {
                WebDriverUtil.GetWebElement(NameTagInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create allowance page - {NameTagInput}")
                    .SendKeys(Util.ProcessInputData(name));
            }
            if (paidTime != null)
            {
                WebDriverUtil.GetWebElement(PaidTimeTagInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Paid Time (Minutes) input on create allowance page - {PaidTimeTagInput}")
                    .SendKeys(paidTime);
            }
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create allowance page - {SaveButton}").Click();
            WebDriverUtil.WaitForWebElementInvisible(SaveInProgress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);

        }
        public static void AddNewAllowance(Table inputData, Boolean negativeScenario)
        {
            LogWriter.WriteLog("Executing AllowancePage.AddNewAllowance");
            ClickOnAddAllowanceButton();
            var AllowanceRecord = inputData.CreateInstance<AllowanceRecord>();
            if (AllowanceRecord.Name != null)
            {
                WebDriverUtil.GetWebElement(NameTagInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create allowance page - {NameTagInput}")
                    .SendKeys(Util.ProcessInputData(AllowanceRecord.Name));
            }

            if (AllowanceRecord.PaidTime != null)
            {
                WebDriverUtil.GetWebElement(PaidTimeTagInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Paid Time (Minutes) input on create allowance page - {PaidTimeTagInput}")
                    .SendKeys(AllowanceRecord.PaidTime);
            }

            if (AllowanceRecord.ExcludePaidBreak != null)
            {
                WebDriverUtil.GetWebElement(ExcludedPaidBreakInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Excluded Paid Breaks (Minutes) input on create allowance page - {ExcludedPaidBreakInput}")
                    .SendKeys(AllowanceRecord.ExcludePaidBreak);
            }
            if (AllowanceRecord.ReleifTime != null)
            {
                WebDriverUtil.GetWebElement(ReliefTimeInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Relief Time (Minutes) input on create allowance page - {ReliefTimeInput}")
                    .SendKeys(AllowanceRecord.ReleifTime);
            }
            if (AllowanceRecord.IncludePaidBreak != null)
            {
                WebDriverUtil.GetWebElement(IncludedPaidInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Included Paid Breaks (Minutes) input on create allowance page - {IncludedPaidInput}")
                    .SendKeys(AllowanceRecord.IncludePaidBreak);
            }
            if (AllowanceRecord.RestCalculation != null)
            {
                try
                {
                    new SelectElement(WebDriverUtil.GetWebElement(RestCalculationInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Rest Calculation input on create allowance page - {RestCalculationInput}"))
                    .SelectByText(AllowanceRecord.RestCalculation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (AllowanceRecord.MinorDelay != null)
            {
                WebDriverUtil.GetWebElement(MinorUnavoidableInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Minor Unavoidable Delay (Percent) input on create allowance page - {MinorUnavoidableInput}")
                    .SendKeys(AllowanceRecord.MinorDelay);
            }
            if (AllowanceRecord.AdditionalDelay != null)
            {
                WebDriverUtil.GetWebElement(AdditionalDelayInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Additional Delay (Percent) input on create allowance page - {AdditionalDelayInput}")
                    .SendKeys(AllowanceRecord.AdditionalDelay);
            }
            if (AllowanceRecord.IncentiveOpportunityAllowance != null)
            {
                WebDriverUtil.GetWebElement(IncentiveOpportunityAllowanceInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Incentive Opportunity Allowance (Percent) input on create allowance page - {IncentiveOpportunityAllowanceInput}")
                    .SendKeys(AllowanceRecord.IncentiveOpportunityAllowance);
            }

            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on create allowance page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible(SaveInProgress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (negativeScenario) return;
            if (WebDriverUtil.GetWebElement(AllowanceForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) ==
                null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(AllowanceForm, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to create new allowance Error - {alert.Text}");
            }
        }
        public static void AddAllowanceWithDuplicateName(string name, string paidTime)
        {
            LogWriter.WriteLog("Executing AllowancePage.AddAllowanceWithDuplicateName");
            ClickOnAddAllowanceButton();
            if (name != null)
            {
                WebDriverUtil.GetWebElement(NameTagInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate name input on create allowance page - {NameTagInput}")
                    .SendKeys(name);
            }
            if (paidTime != null)
            {
                WebDriverUtil.GetWebElement(PaidTimeTagInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Paid Time (Minutes) input on create allowance page - {PaidTimeTagInput}")
                    .SendKeys(paidTime);
            }
            WebDriverUtil.GetWebElement(SaveButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate save button on create allowance page - {SaveButton}").Click();
            WebDriverUtil.WaitForWebElementInvisible(SaveInProgress, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);

        }
    }
}
