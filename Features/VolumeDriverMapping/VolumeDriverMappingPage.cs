using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.VolumeDriverMapping
{
    public class VolumeDriverMappingPage
    {
        const string PROFILING_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        const string VOLUMEDRIVERMAPPING_TAB = "//a[text()='Volume Driver Mapping']";
        const string VOLUMEDRIVERMAPPING_PAGE = "//*[@class='page-title' and text()='Volume Driver Mappings']";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        const string ADD_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string ADD_VOLUMEDRIVERMAPPINGSET_LINK = "(//*[contains(@class,'dropdown open')]//a)[2]";
        const string ADD_VOLUMEDRIVERMAPPING_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        const string NAME_INPUT = "//*[@id='name']";
        const string VOLUMEDRIVER_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string VOLUMEDRIVER_INPUT = "//input[@type='number']";
        const string DEPARTMENT_DROPDOWN = "//select[@id='departmentId']";
        const string CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        const string EDIT_BUTTON = "//*[@title='{0}']/../button";
        const string DELETE_BUTTON = "//i[contains(@title,'Delete')]";
        const string VOLUME_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string VOLUMESET_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'New Volume Driver Mapping Set')]";
        const string CONFIRM_POPUP_BUTTON = "//button[contains(@type,'button') and contains(text(),'Confirm')]";
        const string DEPARTMENT_VALUE = "//option[contains(text(),'{0}')]";
        const string VOLUMEDRIVER_DROPDOWN = "//*[@id='volumeDriverId']";
        const string UOM_DROPDOWN = "//*[@id='unitOfMeasureId']";
        const string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        const string CLOSE_VOLUMEDRIVERMAPPING_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        const string CLOSE_VOLUMEDRIVERMAPPING_DETAILS = "//button[text()='Close']";
        const string CANCEL_VOLUMEDRIVERMAPPING_DETAILS = "//button[text()='Cancel']";
        const string VOLUMEDRIVERMAPPING_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string CREATED_VOLUMEDRIVERMAPPINGSET = "//div[contains(@class,'volume-driver-mapping-set-list-entry')]//span[contains(text(),'{0}')]";
        const string VOLUMEDRIVERMAPPING_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        const string VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        const string VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        const string VOLUMEDRIVER_POPUP = "//*[@role='dialog']//*[@class='modal-title' and contains(text(), 'New Volume Driver')]";
        const string FORM_INPUT_FIELD_ERROR_XPATH = "//*[contains(@class,'validation-error')]";
        const string TABLE_HEADER = "//th";
        const string ELEMENT_ALERT = "//*[@class='form-group has-error']";
        public static void CloseVolumeDriverMappingDetailSideBar()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.CloseVolumeDriverMappingDetailSideBar");
            IWebElement VolumeDriverMappingDetailsSideBar = WebDriverUtil.GetWebElement(CLOSE_VOLUMEDRIVERMAPPING_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (VolumeDriverMappingDetailsSideBar != null)
            {
                VolumeDriverMappingDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
            VolumeDriverMappingDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_VOLUMEDRIVERMAPPING_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (VolumeDriverMappingDetailsSideBar != null)
            {
                VolumeDriverMappingDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
        }
        public static void DeleteVolumeDriverMappingsetIfExist(string VolumeDriverMappingsetName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingsetPage.DeleteVolumeDriverMappingsetIfExist");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(TABLE_HEADER));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                string headerData = header.GetAttribute("innerHTML");
                if (headerData.Contains(VolumeDriverMappingsetName))
                {

                    DeleteCreatedVolumeDriverMappingSet(VolumeDriverMappingsetName);
                    break;

                }

            }
        }

        public static void DeleteVolumeDriverMappingIfExist(string VolumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.DeleteVolumeDriverMappingIfExist");
            WaitForVolumeDriverMappingAlertCloseIfAny();
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(VOLUMEDRIVERMAPPING_RECORD, VolumeDriverMappingName), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteCreatedVolumeDriverMapping(VolumeDriverMappingName);
            }


        }
        public static void DeleteCreatedUOM(string UomName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.DeleteCreatedUOM");
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, UomName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping record on VolumeDriverMapping page - {0}", String.Format(VOLUMEDRIVERMAPPING_RECORD, UomName))).Click();

            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, UomName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping delete button on VolumeDriverMapping details - {0}", String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, UomName))).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
 
            WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete UOM Error - {0}", alert.Text));
            }
            
        }
        public static void DeleteCreatedVolumeDriverMapping(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMapping DeleteCreatedVolumeDrivert");
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping record on VolumeDriverMapping page - {0}", String.Format(VOLUMEDRIVERMAPPING_RECORD, VolumeDriverName))).Click();

            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, VolumeDriverName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping delete button on VolumeDriverMapping details - {0}", String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, VolumeDriverName))).Click();

            WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete VolumeDriverMapping Error - {0}", alert.Text));
            }
            
        }
        public static void VerifyCreatedVolumeDriverMapping(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMapping  VerifyCreatedVolumeDriver");
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record VolumeDriverMapping page - {0}", String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName)));
            BaseClass._AttachScreenshot.Value = true;
            CloseVolumeDriverMappingDetailSideBar();
        }
        public static void DeleteCreatedVolumeDriverMappingSet(string VolumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage DeleteCreatedVolumeDriverMappingSet");
            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
            WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate the check VolumeDriverMappingPage of respective department- {0}",
            CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT)).Click();

            WebDriverUtil.GetWebElement(String.Format(EDIT_BUTTON, VolumeDriverMappingName),
            WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate VolumeDriverMappingPage record on VolumeDriverMappingPage - {0}", String.Format(EDIT_BUTTON, VolumeDriverMappingName))).Click();
            WebDriverUtil.GetWebElement(DELETE_BUTTON,
            WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();

            WebDriverUtil.GetWebElement(CONFIRM_POPUP_BUTTON, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VOLUME_CONFIRM_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception(string.Format("Unable to delete Volume Driver Mapping Error - {0}", alert.Text));
            }
            
            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
            WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate the check VOLUMEDRIVERMAPPINGset of respective department- {0}",
            CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT)).Click();

        }
        public static void ClickOnProfilingTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnProfilingTab");
            IWebElement profilingtab = WebDriverUtil.GetWebElement(PROFILING_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (profilingtab != null)
            {
                profilingtab.Click();
                WebDriverUtil.WaitForAWhile();

            }
        }
        public static void SelectCreatedDepartment(string deptName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMapping SelectCreatedDepartment");
            WebDriverUtil.GetWebElement(DEPARTMENT_DROPDOWN, WebDriverUtil.FIVE_SECOND_WAIT, String.Format("Unable to locate the department dropdown - {0}", DEPARTMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(String.Format(DEPARTMENT_VALUE, deptName),
            WebDriverUtil.NO_WAIT, String.Format("Unable to locate z record on VolumeDriverMappingset page - {0}", String.Format(DEPARTMENT_VALUE, deptName))).Click();

        }
        public static void ClickOnVolumeDriverMappingTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab");
            if (WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_TAB, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void WaitForVolumeDriverMappingAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.WaitForVolumeDriverMappingAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
                if (nametag != null)
                {
                    nametag.Click();
                }
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void CloseVolumeDriverMappingForm()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.CloseVolumeDriverMappingForm");
            WaitForVolumeDriverMappingAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_VOLUMEDRIVERMAPPING_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnAddButton");
            CloseVolumeDriverMappingDetailSideBar();
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button on VolumeDriverMapping page - {0}", ADD_BUTTON)).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void ClickOnNewVolumeDriverMappingsetMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnNewVolumeDriverMappingMenuLink");
            WebDriverUtil.GetWebElement(ADD_VOLUMEDRIVERMAPPINGSET_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate New VolumeDriverMapping menu link on add menu popup - {0}", ADD_VOLUMEDRIVERMAPPINGSET_LINK)).Click();

        }
        public static void ClickOnNewVolumeDriverMappingMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnNewVolumeDriverMappingMenuLink");
            WebDriverUtil.GetWebElement(ADD_VOLUMEDRIVERMAPPING_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate New VolumeDriverMapping menu link on add menu popup - {0}", ADD_VOLUMEDRIVERMAPPING_LINK)).Click();

        }
        public static void AddNewVolumeDriverMappingWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInputIfNotExist");
            var dictionary = Util.ConvertToDictionary(inputData);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(String.Format(VOLUMEDRIVER_RECORD, dictionary["VolumeDriver"]), WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record == null)
            {
                AddNewVolumeDriverMappingWithGivenInput(inputData);
            }
            else
            {
                record.Click();
            }

        }
        public static void ClickOnVolumeDriverMapping()
        {
            LogWriter.WriteLog("Executing VolumeDriverMapping  ClickOnVolumeDriverse");
            ClickOnAddButton();
            ClickOnNewVolumeDriverMappingMenuLink();

        }
        public static void ClickOnVolumeDriverSet()
        {
            LogWriter.WriteLog("Executing VolumeDriverMapping  ClickOnVolumeDriverSet");
            ClickOnAddButton();
            ClickOnNewVolumeDriverMappingsetMenuLink();

        }
        public static void AddNewVolumeDriverMappingWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.AddNewVolumeDriverMappingWithGivenInput");
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);
            //Enter VolumeDriverMapping name if provided
            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate Name input on create VolumeDriverMapping page - {0}", NAME_INPUT))
                  .SendKeys(dictionary["Name"]);
            }

            if (Util.ReadKey(dictionary, "VolumeDriverMappingSet") != null)
            {
                WebDriverUtil.GetWebElement(VOLUMEDRIVER_INPUT, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate Description input on create VolumeDriverMapping page - {0}", VOLUMEDRIVER_INPUT))
                  .SendKeys(dictionary["VolumeDriverMappingSet"]);
            }

            if (Util.ReadKey(dictionary, "VolumeDriver") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(VOLUMEDRIVER_DROPDOWN, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate VolumeDriverMapping Profile input on create VolumeDriverMapping page - {0}", VOLUMEDRIVER_DROPDOWN)))
                  .SelectByText(dictionary["VolumeDriver"]);
            }
            if (Util.ReadKey(dictionary, "UOM") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(UOM_DROPDOWN, WebDriverUtil.NO_WAIT,
                    String.Format("Unable to locate UOM input on create VolumeDriverMapping page - {0}", UOM_DROPDOWN)))
                  .SelectByText(dictionary["UOM"]);
            }

            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate save button on create VolumeDriverMapping page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (WebDriverUtil.GetWebElement(VOLUMEDRIVER_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FORM_INPUT_FIELD_ERROR_XPATH, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ELEMENT_ALERT, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVER_POPUP, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception(string.Format("Unable to create new allowance Error - {0}", alert.Text));
                        }
                    }
                }
            }
        }
        public static void VerifyCreatedVolumeDriverMappingSet(string VolumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.VerifyCreatedVolumeDriverMappingSet");

            if (WebDriverUtil.GetWebElement(VOLUMESET_CONFIRM_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VOLUMESET_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }

            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
            WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate the check VOLUMEDRIVERMAPPINGset of respective department- {0}",
            CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT)).Click();
            BaseClass._AttachScreenshot.Value = true;
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            IWebElement VolumeDriverMappingsetData = WebDriverUtil.GetWebElement(String.Format(CREATED_VOLUMEDRIVERMAPPINGSET, VolumeDriverMappingName),
            WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate VOLUMEDRIVERMAPPINGset record on VOLUMEDRIVERMAPPINGset page - {0}", String.Format(CREATED_VOLUMEDRIVERMAPPINGSET, VolumeDriverMappingName)));

            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
            WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate the check VOLUMEDRIVERMAPPINGset of respective department- {0}",
            CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT)).Click();

        }

    }
}
