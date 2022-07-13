using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.Activity
{
    public class ActivityPage
    {
        private const string MeasurementsCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Measurements')]";
        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseActivityFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseActivityDetails = "//button[text()='Close']";
        private const string CancelActivityDetails = "//button[contains(@class, 'cancel')]";
        private const string ActivityDeleteButton = "//button[contains(@class,'delete')]";
        private const string ActivityRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string ActivityDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string ActivityDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string ListManagementPage = " //*[@class='page-title' and contains(text(),'Element List Management')]";
        private const string ActivityPopup = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Activity')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ListManagementTab = "//a[text()='List Management']";
        private const string ListManagementDropdown = "//select[@id='elementListOptionId']";
        private const string ActivityValueInLmDropdown = "//select[@id='elementListOptionId']//option[contains(text(),'Activities')]";

        public static void DeleteActivityIfExist(string activityName)
        {
            LogWriter.WriteLog("Executing  ActivityPage.DeleteActivityIfExist");
            WaitForActivityAlertCloseIfAny();
            var activityRecordXpath = string.Format(ActivityRecord, activityName);
            var record = WebDriverUtil.GetWebElementAndScroll(activityRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedActivity(activityName);
            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing ActivityPage.ClickOnListManagementTab");
            if (WebDriverUtil.GetWebElement(ListManagementPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null) return;
            WebDriverUtil.GetWebElement(ListManagementTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void CloseActivityDetailSideBar()
        {
            LogWriter.WriteLog("Executing ActivityPage CloseActivityDetailSideBar()");
            var activityDetailsSideBar = WebDriverUtil.GetWebElement(CloseActivityDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (activityDetailsSideBar != null)
            {
                activityDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            activityDetailsSideBar = WebDriverUtil.GetWebElement(CancelActivityDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (activityDetailsSideBar == null) return;
            activityDetailsSideBar.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        
        public static void DeleteCreatedActivity(string activityName)
        {
            LogWriter.WriteLog("Executing ActivityPage DeleteCreatedActivity");
            var activityRecordXpath = string.Format(ActivityRecord, activityName);
            WebDriverUtil.GetWebElement(activityRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
           $"Unable to locate Activity record on Activity page - {activityRecordXpath}").Click();


            WebDriverUtil.GetWebElement( ActivityDeleteButton , WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate Activity delete button on Activity details - {ActivityDeleteButton}" ).Click();


            var confirmationPopup = WebDriverUtil.GetWebElement(ActivityDeleteConfirmPopup, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup == null) return;
            WebDriverUtil.GetWebElement(ActivityDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                $"Unable to locate Confirm button on delete confirmation popup - {ActivityDeleteConfirmPopupAccept}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ActivityDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Activity Error - {alert.Text}");
            }
        }
        public static void VerifyCreatedActivity(string activityName)
        {
            LogWriter.WriteLog("Executing ActivityPage VerifyCreatedActivity");

            var activityRecordXpath = string.Format(ActivityRecord, activityName);
            WebDriverUtil.GetWebElement(activityRecordXpath, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record on Activity page - {activityRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            CloseActivityDetailSideBar();
        }

        public static void FindActivityByName(string activityName)
        {
            LogWriter.WriteLog("Executing ActivityPage FindActivityByName");

            var activityRecordXpath = string.Format(ActivityRecord, activityName);
            WebDriverUtil.GetWebElement(activityRecordXpath, WebDriverUtil.DEFAULT_WAIT,
                $"Unable to locate record on Activity page - {activityRecordXpath}").Click();
        }

        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ActivityPage.VerifyAddButtonIsNotPresent");
            var addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing ActivityPage.VerifyDeleteButtonIsNotPresent");
            var deleteButton = WebDriverUtil.GetWebElement(ActivityDeleteButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("delete button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }

        public static void AddNewActivityWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing ActivityPage AddNewActivityWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            var record = WebDriverUtil.GetWebElementAndScroll(string.Format(ActivityRecord, dictionary["Name"]), WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewActivityWithGivenInput(inputData);
            }
        }

        public static void AddNewActivityWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing ActivityPage AddNewActivityWithGivenInput");
            ClickOnAddButton();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
              $"Unable to locate Name input on Activity page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
              $"Unable to locate save button on Activity page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(ActivityPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null) return;
            var errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMessage != null) return;
            var errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (errorMsg != null) return;
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ActivityPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception( $"Unable to create new Activity Error - {alert.Text}");
            }
        } 
        public static void ClickOnActivity()
        {
            LogWriter.WriteLog("Executing ActivityPage ClickOnActivity");
            WebDriverUtil.GetWebElement(ListManagementDropdown,
                WebDriverUtil.NO_WAIT,  $"Unable to locate list management dropdown - {ListManagementDropdown}").Click();
            WebDriverUtil.GetWebElement(ActivityValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate Activity value - {ActivityValueInLmDropdown}").Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing ActivityPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on Activity page  - {AddButton}").Click();

        }
        public static void CloseActivityForm()
        {
            LogWriter.WriteLog("Executing ActivityPage CloseActivityForm");
            WaitForActivityAlertCloseIfAny();
            var formCloseButton = WebDriverUtil.GetWebElement(CloseActivityFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
        public static void ClickOnMeasurementsTab()
        {
            LogWriter.WriteLog("Executing ActivityPage ClickOnMeasurementsTab");
            var measurementsTab = WebDriverUtil.GetWebElement(MeasurementsCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (measurementsTab == null) return;
            measurementsTab.Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
        }
        public static void WaitForActivityAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing ActivityPage WaitForActivityAlertCloseIfAny ");
            var alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null) return;
            WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
            var nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);
            WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
        }

    }
}

