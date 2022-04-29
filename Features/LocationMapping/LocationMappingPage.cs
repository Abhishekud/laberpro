using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace LaborPro.Automation.Features.LocationMapping
{
    public class LocationMappingPage
    {
        const string PROFILING_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        const string standard_Filing_FieldId = "//select[@id='standardFilingFieldId']";
        const string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        const string LIST_MANAGEMENT_TAB = "//a[text()='List Management']";
        const string ADD_BUTTON = "//button[@id='newLocationMappings']";
        const string ADD_LOCATIONMAPPINGLINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string LOCATIONMAPPING_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_LOCATIONMAPPINGFORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string CREATED_LOCATIONMAPPINGTITLE = "//*[@class='page-title' and contains(text(),'{0}')]";
        const string UNITSOFMEASURE_PAGE = "//h3[@class='page-title' and contains(text(),'Units Of Measure')]";
        const string VOLUMEDRIVER_PAGE = "//h3[@class='page-title' and contains(text(),'Volume Driver Mappings')]";
        const string PAGE_TITLE = "//*[@class='page-title']";
        const string CLOSE_LOCATIONMAPPINGDETAILS = "//button[text()='Close']";
        const string CANCEL_LOCATIONMAPPINGDETAILS = "//button[text()='Cancel']]";
        const string LOCATIONMAPPINGDELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string CLOSE_LOCATIONRMAPPING_FORM_BUTTON = "//button[contains(text(),'Cancel')]";
        const string LOCATIONMAPPINGRECORD_MAPPING = "//*[@role='row' and .//*[text()='{0}']]//td[{1}]/input";
        const string LOCATIONMAPPINGDELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string LOCATIONMAPPINGDELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string CLOSE_BUTTON = "//button[@id='newLocationMappings']";
        const string LIST_MANAGEMENT_DROPDOWN = "//select[@id='standardFilingFieldId']";
        const string LOCATIONMAPPINGVALUE_IN_LM_DROPDOWN = "//select[@id='standardFilingFieldId']//option[contains(text(),'LocationMappings')]";
        const string LOCATIONMAPPING_TAB = "//a[text()='Location Mapping']";
        const string LOCATIONMAPPING_PAGE = "//*[@class='page-title' and text()=' Mapping']";
        const string VOLUMEDRIVER_DROPDOWN = "//select[@id='volumeDriverMappingSetId']";
        const string CHARACTERISTIC_DROPDOWN = "//select[@id='characteristicSetId']";
        const string HEADER = "//th";
        const string LOCATIONMAPPING_POPUP = "//*[contains(text(),'Edit Location Mapping')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        public static void AddNewLocationMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.AddLocationMappingWithGivenInput");
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            shared.hooks.BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            //Enter VolumeDriverMapping name if provided
            if (Util.ReadKey(dictionary, "VolumeDriverMappingSet") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VOLUMEDRIVER_DROPDOWN, WebDriverUtil.MAX_WAIT,
                String.Format("Unable to locate VolumeDriverMappingSet on create LocationMappingPage page - {0}", VOLUMEDRIVER_DROPDOWN)))
                .SelectByText(dictionary["VolumeDriverMappingSet"]);
            }

            if (Util.ReadKey(dictionary, "CharacteristicSet") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(CHARACTERISTIC_DROPDOWN, WebDriverUtil.MAX_WAIT,
                String.Format("Unable to locate CharacteristicSet input on create LocationMappingPage page - {0}", CHARACTERISTIC_DROPDOWN)))
                .SelectByText(dictionary["CharacteristicSet"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate save button on create LocationMappingPage page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            if (WebDriverUtil.GetWebElement(LOCATIONMAPPING_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ELEMENT_ALERT, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(LOCATIONMAPPING_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new LocationMappingPage Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void CloseLocationMappingDetailSideBar()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.CloseLocationMappingDetailSideBar");
            IWebElement LocationMappingDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_LOCATIONMAPPINGDETAILS, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (LocationMappingDetailsSideBar != null)
            {
                LocationMappingDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }

        }
        public static void CloseLocationDriverMappingForm()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.CloseLocationDriverMappingForm");
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_LOCATIONRMAPPING_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitForAWhile();
            }
            WebDriverUtil.WaitForAWhile();
        }
        public static void DeleteCreatedLocationMapping(string LocationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.DeleteCreatedLocationMapping");
            CloseLocationMappingDetailSideBar();
            WebDriverUtil.GetWebElement(String.Format(LOCATIONMAPPING_RECORD, LocationMappingName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate LocationMapping record on LocationMappings page - {0}", String.Format(LOCATIONMAPPING_RECORD, LocationMappingName))).Click();

            WebDriverUtil.GetWebElement(String.Format(LOCATIONMAPPINGDELETE_BUTTON, LocationMappingName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate LocationMapping delete button on LocationMapping details - {0}", String.Format(LOCATIONMAPPINGDELETE_BUTTON, LocationMappingName))).Click();

            WebDriverUtil.GetWebElement(LOCATIONMAPPINGDELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", LOCATIONMAPPINGDELETE_CONFIRM_POPUP_ACCEPT)).Click();

            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(LOCATIONMAPPINGDELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Location Mapping Error - {0}", alert.Text));
            }
        }

        public static void VerifyCreatedLocationMapping(string LocationMappingName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.VerifyCreatedLocationMapping");
            WebDriverUtil.WaitForAWhile();
            WebDriverUtil.GetWebElement(String.Format(LOCATIONMAPPING_RECORD, LocationMappingName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate record LocationMappings page - {0}", String.Format(LOCATIONMAPPING_RECORD, LocationMappingName))).Click();
            BaseClass._AttachScreenshot.Value = true;

        }

        public static void MapscreatedDepartmentandlocation(string Location, string Department)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.MapscreatedDepartmentandlocation");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                string headerData = header.GetAttribute("innerHTML");
                if (headerData.Contains(Department))
                {

                    WebDriverUtil.GetWebElement(String.Format(LOCATIONMAPPINGRECORD_MAPPING, Location, index), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                    break;

                }

            }

        }
        public static void SelectTheLocation(string LocationName)
        {
            LogWriter.WriteLog("Executing LocationMappingPage.SelectTheLocation");
            WebDriverUtil.GetWebElement(String.Format(LOCATIONMAPPING_RECORD, LocationName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate LocationMappingPage record on LocationMappingPage page - {0}", String.Format(LOCATIONMAPPING_RECORD, LocationName))).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void refresh()
        {
            SeleniumDriver.Driver().Navigate().Refresh();
        }

        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing LocationMappingPage.ClickonProfilingtab");
            IWebElement profilingTab = WebDriverUtil.GetWebElement(PROFILING_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingTab != null)
            {
                profilingTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }

        }

        public static void ClickOnLocationMappingTab()
        {
            LogWriter.WriteLog("Executing LocationMapping.ClickOnLocationMappingTab");
            if (WebDriverUtil.GetWebElement(LOCATIONMAPPING_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                SeleniumDriver.Driver().FindElement(By.XPath(LOCATIONMAPPING_TAB)).Click();
                WebDriverUtil.WaitForAWhile();
            }
            WebDriverUtil.WaitForAWhile();       
        }


    }
}
