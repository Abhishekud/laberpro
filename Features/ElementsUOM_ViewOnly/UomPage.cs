using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;

namespace LaborPro.Automation.Features.ElementsUOM_ViewOnly
{
    public class UomPage
    {
        private const string MeasurementsCollapsedTab = "//li[contains(@class,'collapsed')]//span[contains(text(),'Measurements')]";
        private const string AddButton = "//button[.//*[@class='fa fa-plus']]";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string CloseUomFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string CloseUomDetails = "//button[text()='Close']";
        private const string CancelUomDetails = "//button[contains(@class, 'cancel')]";
        private const string UomDeleteButton = "//button[contains(@class,'delete')]";
        private const string UomRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string UomDeleteConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string UomDeleteConfirmPopupAccept = "//*[@class='modal-dialog']//button[text()='Confirm']";
        private const string UomPopup = " //*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Classification')]";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string ElementAlert = "//*[@class='form-group has-error']";
        private const string ListManagementTab = "//a[text()='List Management']";
        private const string ListManagementDropdown = "//select[@id='elementListOptionId']";
        private const string UomValueInLmDropdown = "//select[@id='elementListOptionId']//option[contains(text(),'Units Of Measure')]";
        private const string ListManagementPage = " //*[@class='page-title' and contains(text(),'Element List Management')]";
        public static void DeleteUomIfExist(string uomName)
        {
            LogWriter.WriteLog("Executing  UomPage.DeleteUomIfExist");
            WaitForUomAlertCloseIfAny();
            var uomRecordXpath = string.Format(UomRecord, uomName);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(uomRecordXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedUom(uomName);
            }
        }
        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing UomPage.ClickOnListManagementTab");


            if (WebDriverUtil.GetWebElement(ListManagementPage, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(ListManagementTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void ClickOnMeasurementsTab()
        {
            LogWriter.WriteLog("Executing UomPage.ClickOnMeasurementsTab");
            IWebElement measurementsTab = WebDriverUtil.GetWebElement(MeasurementsCollapsedTab, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (measurementsTab != null)
            {
                measurementsTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void CloseUomDetailSideBar()
        {
            LogWriter.WriteLog("Executing UomPage.CloseUomDetailSideBar");
            IWebElement uomDetailsSideBar = WebDriverUtil.GetWebElement(CloseUomDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (uomDetailsSideBar != null)
            {
                uomDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            uomDetailsSideBar = WebDriverUtil.GetWebElement(CancelUomDetails, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (uomDetailsSideBar != null)
            {
                uomDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        
        public static void DeleteCreatedUom(string uomName)
        {
            LogWriter.WriteLog("Executing UomPage.DeleteCreatedUom");
            var uomRecordXpath = string.Format(UomRecord, uomName);
            WebDriverUtil.GetWebElement(uomRecordXpath, WebDriverUtil.TWO_SECOND_WAIT,
            $"Unable to locate UOM record on UOMs page - {uomRecordXpath}").Click();


            WebDriverUtil.GetWebElement(UomDeleteButton, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate UOM delete button on UOM details - {UomDeleteButton}").Click();


            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(UomDeleteConfirmPopup, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(UomDeleteConfirmPopupAccept, WebDriverUtil.TWO_SECOND_WAIT,
                    $"Unable to locate Confirm button on delete confirmation popup - {UomDeleteConfirmPopupAccept}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
                WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
                IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (alert == null)
                {
                    WebDriverUtil.WaitForWebElementInvisible(UomDeleteConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                }
                else
                {
                    throw new Exception($"Unable to delete UOM Error - {alert.Text}");
                }
            }
        }
        public static void VerifyCreatedUom(string uomName)
        { 
            LogWriter.WriteLog("Executing UomPage.VerifyCreatedUom");

            var uomRecordXpath = string.Format(UomRecord, uomName);
            WebDriverUtil.GetWebElement(uomRecordXpath, WebDriverUtil.DEFAULT_WAIT,
            $"Unable to locate record on UOMs page - {uomRecordXpath}");
            BaseClass._AttachScreenshot.Value = true;
            CloseUomDetailSideBar();
        }
         
        public static void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing UomPage.VerifyAddButtonIsNotPresent");
            IWebElement addButton = WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (addButton != null)
                throw new Exception("Add button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyDeleteButtonIsNotPresent(string uomName)
        {
            LogWriter.WriteLog("Executing UomPage.VerifyDeleteButtonIsNotPresent");

            var uomRecordXpath = string.Format(UomRecord, uomName);
            WebDriverUtil.GetWebElement(uomRecordXpath, WebDriverUtil.ONE_SECOND_WAIT,
            $"Unable to locate UOM record on UOM page - {uomRecordXpath}").Click();
            IWebElement deleteButton = WebDriverUtil.GetWebElement(UomDeleteButton, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (deleteButton != null)
                throw new Exception("Delete button is found but we expect it should not be present when user login from view only access");
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void AddNewUomWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing UomPage.AddNewUomWithGivenInput");
            ClickOnAddButton();
 
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate Name input on UOMs page  - {NameInput}")
                    .SendKeys(dictionary["Name"]);
            }
            WebDriverUtil.GetWebElementAndScroll(SaveButton, WebDriverUtil.NO_WAIT,
                $"Unable to locate save button on UOMs page - {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(UomPopup, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
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
                            WebDriverUtil.WaitForWebElementInvisible(UomPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception($"Unable to create new UOMs Error - {alert.Text}");
                        }
                    }
                }
            }
        } 
        public static void ClickOnUOM()
        {
            LogWriter.WriteLog("Executing UomPage ClickOnUOM");
            WebDriverUtil.GetWebElement(ListManagementDropdown,
                WebDriverUtil.NO_WAIT, $"Unable to locate list management dropdown - {ListManagementDropdown}").Click();
            WebDriverUtil.GetWebElement(UomValueInLmDropdown, WebDriverUtil.NO_WAIT,
                $"Unable to locate UOM value - {UomValueInLmDropdown}" ).Click();

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing UomPage ClickOnAddButton");
            WebDriverUtil.GetWebElement(AddButton, WebDriverUtil.NO_WAIT,
            $"Unable to locate add button on UOMs page  - {AddButton}").Click();

        }
        public static void CloseUomForm()
        {
            LogWriter.WriteLog("Executing UomPage.CloseUOMForm");
            WaitForUomAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CloseUomFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();

            }
        }
 
        public static void WaitForUomAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing UomPage.WaitForUOMAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NameInput).Click();
                IWebElement nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);
                WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }

    }
}

