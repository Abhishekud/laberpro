using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Elements_ViewOnly
{
    public class ElementsPage
    {
        private const string MeasurementsCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Measurements')]";
        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string AddElementsLink = "(//*[contains(@class,'dropdown open')]//a)[3]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseElementsFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseElementsDetails = "//button[text()='Close']";
        private const string CancelElementsDetails = "//button[contains(@class, 'cancel')]";
        private const string ElementsDeleteButton = "//button[contains(@class,'delete')]";
        private const string ElementsRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string ElementPage = "//*[@class='page-title' and contains(text(),'Elements')]";
        private const string ElementsTab = "//a[@href='/elements']";
        private const string ElementsPopup = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Classification')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string UomDropdown = "//*[@id='elementUnitOfMeasureId']";
        private const string ActivityDropdown = "//*[@id='elementActivityId']";
        private const string ElementDetailsSidebarButton = "//*[@class='page-header']//button[@class='btn-default btn btn-default']//i";
        private const string OpenEditSidebarForm = "//*[@class='sidebar-scrollable']//div[@class='form-group']";
        private const string DeleteButton = "//button//i[contains(@title,'Delete')]";
        private const string EditButtonSidebar = "//button//strong[contains(text(),'edit')]";
        private const string ConfirmPopupButton = "//button[contains(text(),'Confirm')]";
        private const string ConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string NameTagInputInEditForm = "//input[@value='{0}']";
        private const string ExportButton = "//button/i[contains(@class, 'fa fa-file-excel-o')]";
        private const string CheckboxInput = "//input[@type ='checkbox']";
        private const string ElementReportButton = "//button[contains(@title,'Element Report')]";
        private const string ElementStep = "//span[contains(@title,'Default MOST Analysis Step')]";
        private const string ElementStepEditButton = " //button[contains(text(),'Edit')]";
        private const string ClearFilterButton = "//button[@title='Clear All Filters']";
        private const string ElementTableHeader = "//table[@role='presentation']//th//*[@class='k-link']";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string ElementFilterInput = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        private const string Name = "Name";
        private const string ElementMoreOptionButton = "//button/i[contains(@class,'fa fa-ellipsis-h')]";
        private const string ToggleButton = "//*[contains(@class, 'simo-toggle')]//*[contains(@class,'fa-toggle-off disabled')]";
        private const string ViewButton = "//button[contains(text(),'View')]";
        private const string CheckboxInputElementDetails = " //*[contains(@class, 'bulk-edit-checkbox')]//*[contains(@class,'fa fa-square-o ')]";
        public static void DeleteElementsIfExist(string elementsName)
        {
            LogWriter.WriteLog("Executing  ElementsPage.DeleteElementsIfExist");
            WaitForElementsAlertCloseIfAny();
            ClearAllFilter();
            SearchElements(elementsName);
            var elementsRecordXpath = string.Format(ElementsRecord, elementsName);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(elementsRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedElementsByName(elementsName);
            }
        }

        public static void CloseElementsDetailSideBar()
        {
            LogWriter.WriteLog("Executing ElementsPage CloseElementsDetailSideBar()");
            IWebElement elementsDetailsSideBar = WebDriverUtil.GetWebElement(CloseElementsDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementsDetailsSideBar != null)
            {
                elementsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            elementsDetailsSideBar = WebDriverUtil.GetWebElement(CancelElementsDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementsDetailsSideBar != null)
            {
                elementsDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static int FindColumnIndexInElementsInViewOnly(string headerName)
        {
            LogWriter.WriteLog("Executing ElementsPage.FindColumnIndexInElementsInViewOnly");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(ElementTableHeader));
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
            var elementsRecordXpath = string.Format(ElementsRecord, elementsName);
            WebDriverUtil.GetWebElement(elementsRecordXpath, WebDriverUtil.NO_WAIT,
          $"Unable to locate Elements record on ElementsPage page - {elementsRecordXpath}").Click();

            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ElementDetailsSidebarButton,
                WebDriverUtil.ONE_SECOND_WAIT,
               $"Unable to locate Elements details sidebar button - {ElementDetailsSidebarButton}"
                ).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            WebDriverUtil.GetWebElement(EditButtonSidebar, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate edit button - {EditButtonSidebar}").Click();
            WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate DELETE button - {DeleteButton}").Click();

            WebDriverUtil.GetWebElement(ConfirmPopupButton, WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate confirm button - {ConfirmPopupButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Elements Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedElements(string elementsName)
        {
            LogWriter.WriteLog("Executing ElementsPage VerifyCreatedElements");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ElementDetailsSidebarButton,
                WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate Elements details sidebar button - {ElementDetailsSidebarButton}").Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            IWebElement elementsValueInEditForm = WebDriverUtil.GetWebElement(String.Format(NameTagInputInEditForm, elementsName), WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementsValueInEditForm == null)
            {
                elementsValueInEditForm = WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception($"We supposed to get ElementsPage tile - {elementsName} but found - {elementsValueInEditForm.Text}" );
            }
            BaseClass._AttachScreenshot.Value = true;
            CloseElementsDetailSideBar();
        }

        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyAddButtonIsNotPresent");
            IWebElement addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyIfUserIsUnableToAccessMoreOptionsMenu()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserIsUnableToAccessMoreOptionsMenu");
            IWebElement moreOptionButton = WebDriverUtil.GetWebElement(ElementMoreOptionButton, WebDriverUtil.NO_WAIT, $"Unable to locate more option button - {ElementMoreOptionButton}");
            if (!moreOptionButton.Enabled)
                throw new Exception("more Option Button is disabled but we expect it should be enabled when user login from view only access");

            BaseClass._AttachScreenshot.Value = true;
        }

        public static void VerifyIfTheUserIsUnableToAccessToggle()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfTheUserIsUnableToAccessToggle");
            IWebElement toggleButton = WebDriverUtil.GetWebElement(ToggleButton, WebDriverUtil.NO_WAIT, $"Unable to locate Toggle button - {ToggleButton}");
            if (!toggleButton.Enabled)
                throw new Exception("Toggle is disabled but we expect it should be enabled when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyIfUserDoesNotHaveAccessToEditElementStepDetails()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserDoesNotHaveAccessToEditElementStepDetails");
            WebDriverUtil.GetWebElement(ElementStep, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate Elements step on Elements page - {ElementStep}").Click();
            WebDriverUtil.GetWebElement(ViewButton, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate view button on Elements page - {ViewButton}").Click();

            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyThatIfSelectCheckboxesAreUnavailableForMultiSelectInElementDetails");
            IWebElement checkbox = WebDriverUtil.GetWebElement(CheckboxInputElementDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (checkbox != null)
                throw new Exception("checkbox is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;

        }

        public static void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyDeleteButtonIsNotPresent");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ElementDetailsSidebarButton,
                WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate Elements details sidebar button - {ElementDetailsSidebarButton}"
                 ).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            IWebElement deleteButton = WebDriverUtil.GetWebElement(ElementsDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyExportOptionIsPresent()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyExportOptionIsNotPresent");
            IWebElement exportButton = WebDriverUtil.GetWebElement(ExportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (exportButton == null)
                throw new Exception("export button is not found but we expect it should be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyIfUserIsAbleToDownloadElementReport(string elementsName)
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserIsAbleToDownloadElementReport");
            ClearAllFilter();
            WebDriverUtil.GetWebElement(String.Format(ElementFilterInput, FindColumnIndexInElementsInViewOnly(Name)), WebDriverUtil.NO_WAIT,
            $"Unable to locate filter input on Elements page - {ElementFilterInput}").SendKeys(elementsName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
            var elementsRecordXpath = String.Format(ElementsRecord, elementsName);
            WebDriverUtil.GetWebElement(elementsRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate Elements record on Elements page - {elementsRecordXpath}").Click();

            IWebElement elementReportButton = WebDriverUtil.GetWebElement(ElementReportButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (elementReportButton == null)
                throw new Exception("ElementReport button is not found but we expect it should be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;

        }
        public static void VerifyIfUserIsNotAbleToEditTheElementSteps()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifyIfUserIsNotAbleToEditTheElementSteps");
            WebDriverUtil.GetWebElement(ElementStep, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate Elements step on Elements page - {ElementStep}").Click();

            IWebElement editButton = WebDriverUtil.GetWebElement(ElementStepEditButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (editButton != null)
                throw new Exception("edit button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;

        }

        public static void VerifySelectMultipleElementsCheckboxIsUnavailable()
        {
            LogWriter.WriteLog("Executing ElementsPage.VerifySelectMultipleElementsCheckboxIsUnavailable");
            IWebElement checkbox = WebDriverUtil.GetWebElement(CheckboxInput, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
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
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on Elements page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "UOM") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(UomDropdown, WebDriverUtil.NO_WAIT,
                    $"Unable to locate UOM input on create Elements page - {UomDropdown}"))
                  .SelectByText(dictionary["UOM"]);
            }
            if (Util.ReadKey(dictionary, "Activity") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(ActivityDropdown, WebDriverUtil.NO_WAIT,
                    $"Unable to locate Activity input on create Elements page - {ActivityDropdown}"))
                  .SelectByText(dictionary["Activity"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on Elements page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(ElementsPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(ElementsPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception($"Unable to create new Elements Error - {alert.Text}");
                        }
                    }
                }
            }
        }
        public static void UserClickOnNewElementsMenuLink()
        {
            LogWriter.WriteLog("Executing ElementsPage UserClickOnNewElementsMenuLink");
            WebDriverUtil.GetWebElement(AddElementsLink, WebDriverUtil.NO_WAIT,
            $"Unable to locate New Elements Menu menu link on add menu popup - {AddElementsLink}").Click();
        }


        public static void ClickOnElements()
        {
            LogWriter.WriteLog("Executing ElementsPage ClickOnElements");
            if (WebDriverUtil.GetWebElement(ElementPage, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ElementsTab, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate the Elements tab - {ElementsTab}").Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing ElementsPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Elements page  - {AddButton}").Click();

        }
        public static void CloseElementsForm()
        {
            LogWriter.WriteLog("Executing ElementsPage CloseElementsForm");
            WaitForElementsAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CloseElementsFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnMeasurementsTab()
        {
            LogWriter.WriteLog("Executing ElementsPage ClickOnMeasurementsTab");
            IWebElement measurementsTab = WebDriverUtil.GetWebElement(MeasurementsCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (measurementsTab != null)
            {
                measurementsTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForElementsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing ElementsPage WaitForElementsAlertCloseIfAny ");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
                IWebElement nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);
                WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void SearchElements(string elementsName)
        {
            LogWriter.WriteLog("Executing ElementsPage.SearchElements");
            var elementFilterInput = string.Format(ElementFilterInput, FindColumnIndexInElements(Name));
            WebDriverUtil.GetWebElement(elementFilterInput, WebDriverUtil.NO_WAIT,
                         $"Unable to locate filter input on Elements page - {ElementFilterInput}").SendKeys(elementsName);
            WebDriverUtil.WaitForAWhile();
            WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static int FindColumnIndexInElements(string headerName)
        {
            LogWriter.WriteLog("Executing ElementsPage.FindColumnIndexInElements");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(ElementTableHeader));
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

            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(ClearFilterButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
    }
}

