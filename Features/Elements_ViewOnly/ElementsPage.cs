using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Elements_ViewOnly
{
    public class ElementsPage
    {
        const string MEASUREMENTS_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Measurements')]";
        const string ADD_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string ADD_ELEMENTS_LINK = "(//*[contains(@class,'dropdown open')]//a)[3]";
        const string NAME_INPUT = "//*[@id='name']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_ELEMENTS_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CLOSE_ELEMENTS_DETAILS = "//button[text()='Close']";
        const string CANCEL_ELEMENTS_DETAILS = "//button[contains(@class, 'cancel')]";
        const string ELEMENTS_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string ELEMENTS_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string ELEMENTS_PAGE = "//*[@class='page-title' and contains(text(),'Elements')]";
        const string ELEMENTS_TAB = "//a[@href='/elements']";
        const string ELEMENTS_POPUP = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Classification')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        const string UOM_DROPDOWN = "//*[@id='elementUnitOfMeasureId']";
        const string ACTIVITY_DROPDOWN = "//*[@id='elementActivityId']";
        const string ELEMENT_DETAILS_SIDEBAR_BUTTON = "//*[@class='page-header']//button[@class='btn-default btn btn-default']//i";
        const string OPEN_EDIT_SIDEBAR_FORM = "//*[@class='sidebar-scrollable']//div[@class='form-group']";
        const string DELETE_BUTTON = "//button//i[contains(@title,'Delete')]";
        const string EDIT_BUTTON_SIDEBAR = "//button//strong[contains(text(),'edit')]";
        const string CONFIRM_POPUP_BUTTON = "//button[contains(text(),'Confirm')]";
        const string CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string NAME_TAG_INPUT_IN_EDIT_FORM = "//input[@value='{0}']";
        const string EXPORT_BUTTON = "//button/i[contains(@class, 'fa fa-file-excel-o')]";
        const string CHECKBOX_INPUT = "//input[@type ='checkbox']";
        const string ELEMENT_REPORT_BUTTON = "//button[contains(@title,'Element Report')]";
        const string ELEMENT_STEP = "//span[contains(@title,'Default MOST Analysis Step')]";
        const string ELEMENT_STEP_EDIT_BUTTON = " //button[contains(text(),'Edit')]";
        const string CLEAR_FILTER_BUTTON = "//button[@title='Clear All Filters']";
        const string ELEMENT_TABLE_HEADER = "//table[@role='presentation']//th//*[@class='k-link']";
        const string PAGE_LOADER = "//*[@title='Submission in progress']";
        const string ELEMENT_FILTER_INPUT = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        const string NAME = "Name";
        const string ELEMENT_MORE_OPTION_BUTTON = "//button/i[contains(@class,'fa fa-ellipsis-h')]";
        const string SIMO_TOGGLE_BUTTON = "//*[contains(@class, 'simo-toggle')]//*[contains(@class,'fa-toggle-off disabled')]";
        const string VIEW_BUTTON = "//button[contains(text(),'View')]";
        const string CHECKBOX_INPUT_ELEMENT_DETAILS = " //*[contains(@class, 'bulk-edit-checkbox')]//*[contains(@class,'fa fa-square-o ')]";
        public static void DeleteElementsIfExist(string elementsName)
        {
            LogWriter.WriteLog("Executing  ElementsPage.DeleteElementsIfExist");
            WaitForElementsAlertCloseIfAny();
            ClearAllFilter();
            SearchElements(elementsName);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(ELEMENTS_RECORD, elementsName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedElementsByName(elementsName);
            }
        }

        public static void CloseElementsDetailSideBar()
        {
            LogWriter.WriteLog("Executing ElementsPage CloseElementsDetailSideBar()");
            IWebElement elementsDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_ELEMENTS_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementsDetailsSideBar != null)
            {
                elementsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            elementsDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_ELEMENTS_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementsDetailsSideBar != null)
            {
                elementsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static int FindColumnIndexInElementsInViewOnly(string headerName)
        {
            LogWriter.WriteLog("Executing ElementsPage.FindColumnIndexInElementsInViewOnly");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(ELEMENT_TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                if (headerName.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }

            return index;
        }

        public static void DeleteCreatedElementsByName(string elementsName)
        {
            LogWriter.WriteLog("Executing ElementsPage.DeleteCreatedElementsByName");
            WebDriverUtil.GetWebElement(String.Format(ELEMENTS_RECORD, elementsName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate Elements record on ElementsPage page - {0}", String.Format(ELEMENTS_RECORD, elementsName))).Click();

            if (WebDriverUtil.GetWebElement(OPEN_EDIT_SIDEBAR_FORM, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ELEMENT_DETAILS_SIDEBAR_BUTTON,
                WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate Elements details sidebar button - {0}",
                ELEMENT_DETAILS_SIDEBAR_BUTTON)).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            WebDriverUtil.GetWebElement(EDIT_BUTTON_SIDEBAR, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate edit button - {0}", EDIT_BUTTON_SIDEBAR)).Click();
            WebDriverUtil.GetWebElement(DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate DELETE button - {0}", DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CONFIRM_POPUP_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, String.Format("Unable to locate confirm button - {0}", CONFIRM_POPUP_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Elements Error - {0}", alert.Text));
            }
        }
        public static void VerifyCreatedElements(string elementsName)
        {
            LogWriter.WriteLog("Executing ElementsPage VerifyCreatedElements");
            if (WebDriverUtil.GetWebElement(OPEN_EDIT_SIDEBAR_FORM, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ELEMENT_DETAILS_SIDEBAR_BUTTON,
                WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate Elements details sidebar button - {0}",
                ELEMENT_DETAILS_SIDEBAR_BUTTON)).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            IWebElement elementsValueInEditForm = WebDriverUtil.GetWebElement(String.Format(NAME_TAG_INPUT_IN_EDIT_FORM, elementsName), WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementsValueInEditForm == null)
            {
                elementsValueInEditForm = WebDriverUtil.GetWebElement(OPEN_EDIT_SIDEBAR_FORM, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception(String.Format("We supposed to get ElementsPage tile - {0} but found - {1}", elementsName, elementsValueInEditForm.Text));
            }
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyAddButtonIsNotPresent");
            IWebElement addElements = WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addElements != null)
                throw new Exception("add button is found but we expect it should not be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyIfUserIsUnableToAccessMoreOptionsMenu()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserIsUnableToAccessMoreOptionsMenu");
            IWebElement moreOptionButton = WebDriverUtil.GetWebElement(ELEMENT_MORE_OPTION_BUTTON, WebDriverUtil.NO_WAIT, String.Format("Unable to locate moreOption button - {0}", ELEMENT_MORE_OPTION_BUTTON));
            if (!moreOptionButton.Enabled)
                throw new Exception("moreOptionButton is disabled but we expect it should be enabled when user login from viewonly access");

            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyIfTheUserIsUnableToAccessSimoToggle()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfTheUserIsUnableToAccessSimoToggle");
            IWebElement simoToggleButton = WebDriverUtil.GetWebElement(SIMO_TOGGLE_BUTTON, WebDriverUtil.NO_WAIT, String.Format("Unable to locate SimoToggle button - {0}", SIMO_TOGGLE_BUTTON));
            if (!simoToggleButton.Enabled)
                throw new Exception("SimoToggle is disabled but we expect it should be enabled when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyIfUserDoesNotHaveAccessToEditElementStepDetails()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserDoesNotHaveAccessToEditElementStepDetails");
            WebDriverUtil.GetWebElement(ELEMENT_STEP, WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Elements step on Elements page - {0}", ELEMENT_STEP)).Click();
            WebDriverUtil.GetWebElement(VIEW_BUTTON, WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate view button on Elements page - {0}", VIEW_BUTTON)).Click();

            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails");
            IWebElement checkbox = WebDriverUtil.GetWebElement(CHECKBOX_INPUT_ELEMENT_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (checkbox != null)
                throw new Exception("checkbox is found but we expect it should not be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;

        }

        public static void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyDeleteButtonIsNotPresent");
            if (WebDriverUtil.GetWebElement(OPEN_EDIT_SIDEBAR_FORM, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ELEMENT_DETAILS_SIDEBAR_BUTTON,
                WebDriverUtil.ONE_SECOND_WAIT,
                String.Format("Unable to locate Elements details sidebar button - {0}",
                ELEMENT_DETAILS_SIDEBAR_BUTTON)).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            IWebElement delete = WebDriverUtil.GetWebElement(ELEMENTS_DELETE_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (delete != null)
                throw new Exception("Delete button is found but we expect it should not be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyExportOptionIsNotPresent");
            IWebElement export = WebDriverUtil.GetWebElement(EXPORT_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (export == null)
                throw new Exception("export button is not found but we expect it should be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyIfUserIsAbleToDownloadElementReport(string elementsName)
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserIsAbleToDownloadElementReport");
            ClearAllFilter();
            WebDriverUtil.GetWebElement(String.Format(ELEMENT_FILTER_INPUT, FindColumnIndexInElementsInViewOnly(NAME)), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate filter input on Elements page - {0}", ELEMENT_FILTER_INPUT)).SendKeys(elementsName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
            WebDriverUtil.GetWebElement(String.Format(ELEMENTS_RECORD, elementsName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Elements record on Elements page - {0}", String.Format(ELEMENTS_RECORD, elementsName))).Click();

            IWebElement elementReportButton = WebDriverUtil.GetWebElement(ELEMENT_REPORT_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementReportButton == null)
                throw new Exception("ElementReport button is not found but we expect it should be present when user login from viewonly access");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyIfUserIsNotAbleToEditTheElementSteps()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserIsNotAbleToEditTheElementSteps");
            WebDriverUtil.GetWebElement(ELEMENT_STEP, WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Elements step on Elements page - {0}", ELEMENT_STEP)).Click();

            IWebElement editButton = WebDriverUtil.GetWebElement(ELEMENT_STEP_EDIT_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editButton != null)
                throw new Exception("edit button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;

        }

        public static void VerifySelectMultipleElementsCheckboxIsUnavailable()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifySelectMultipleElementsCheckboxIsUnavailable");
            IWebElement checkbox = WebDriverUtil.GetWebElement(CHECKBOX_INPUT, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (checkbox != null)
                throw new Exception("checkbox is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void AddNewElementsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing ElementsPage AddNewElementsWithGivenInput");
            ClickOnAddButton();
            UserClickOnNewElementsMenuLink();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input on Elementss page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "UOM") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(UOM_DROPDOWN, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate UOM input on create Elements page - {0}", UOM_DROPDOWN)))
                  .SelectByText(dictionary["UOM"]);
            }
            if (Util.ReadKey(dictionary, "Activity") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(ACTIVITY_DROPDOWN, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate Activity input on create Elements page - {0}", ACTIVITY_DROPDOWN)))
                  .SelectByText(dictionary["Activity"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button on Elementss page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(ELEMENTS_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(ELEMENTS_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new Elementss Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void UserClickOnNewElementsMenuLink()
        {
            LogWriter.WriteLog("Executing ElementsPage UserClickOnNewElementsMenuLink");
            WebDriverUtil.GetWebElement(ADD_ELEMENTS_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate New Elements Menu menu link on add menu popup - {0}", ADD_ELEMENTS_LINK)).Click();
        }


        public static void ClickOnElements()
        {
            LogWriter.WriteLog("Executing ElementsPage ClickOnElements");
            if (WebDriverUtil.GetWebElement(ELEMENTS_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ELEMENTS_TAB, WebDriverUtil.DEFAULT_WAIT, String.Format("Unable to locate the Elementss tab - {0}", ELEMENTS_TAB)).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing ElementsPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button on Elements page  - {0}", ADD_BUTTON)).Click();

        }
        public static void CloseElementsForm()
        {
            LogWriter.WriteLog("Executing ElementsPage CloseElementsForm");
            WaitForElementsAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_ELEMENTS_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnMeasurementsTab()
        {
            LogWriter.WriteLog("Executing ElementsPage ClickOnMeasurementsTab");
            IWebElement measurementsTab = WebDriverUtil.GetWebElement(MEASUREMENTS_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (measurementsTab != null)
            {
                measurementsTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForElementsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing ElementsPage WaitForElementsAlertCloseIfAny ");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void SearchElements(string elementsName)
        {
            LogWriter.WriteLog("Executing ElementsPage.SearchElements");
            WebDriverUtil.GetWebElement(String.Format(ELEMENT_FILTER_INPUT, FindColumnIndexInElements(NAME)), WebDriverUtil.NO_WAIT,
                         String.Format("Unable to locate filter input on Elements page - {0}", ELEMENT_FILTER_INPUT)).SendKeys(elementsName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PAGE_LOADER, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static int FindColumnIndexInElements(string headerName)
        {
            LogWriter.WriteLog("Executing ElementsPage.FindColumnIndexInElements");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(ELEMENT_TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                if (headerName.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }
            index++;

            return index;
        }

        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing ElementsPage.ClearAllFilter");

            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(CLEAR_FILTER_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
    }
}

