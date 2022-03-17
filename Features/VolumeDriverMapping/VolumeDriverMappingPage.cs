using laborpro.drivers;
using laborpro.hooks;
using laborpro.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace laborpro.pages
{
    public class VolumeDriverMappingPage
    {
        public static readonly string RECORD_FOR_DEPT = "//td[contains(text(),'{0}')]";
        const string PROFILING_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Profiling')]";
        const string VOLUMEDRIVERMAPPING_TAB = "//a[text()='Volume Driver Mapping']";
        const string VOLUMEDRIVERMAPPING_PAGE = "//*[@class='page-title' and text()='Volume Driver Mappings']";
        const string PAGE_TITLE = "//*[@class='page-title']";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";

        const string ADD_BUTTON = "//button[.//*[@class='fa fa-plus']]";
        const string ADD_VOLUMEDRIVERMAPPINGSET_LINK = "(//*[contains(@class,'dropdown open')]//a)[2]";
        const string ADD_VOLUMEDRIVERMAPPING_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";

        const string NAME_INPUT = "//*[@id='name']";
        public static readonly string VOLUMEDRIVER_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        const string VOLUMEDRIVER_INPUT = "//input[@type='number']";
        const string DEPARTMENT_DROPDOWN = "//select[@id='departmentId']";
        public static readonly string CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT = "//div[contains(@class,'flyout-button')]//button[@type='button']";
        public static readonly string EDIT_BUTTON = "//*[@title='{0}']/../button";
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
        public static void DeleteCreatedUOM(string UomName)
        {
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, UomName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping record on VolumeDrivers page - {0}", String.Format(VOLUMEDRIVERMAPPING_RECORD, UomName))).Click();


            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, UomName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping delete button on VolumeDriver details - {0}", String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, UomName))).Click();


            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void DeleteCreatedVolumeDriverMapping(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverMapping DeleteCreatedVolumeDrivert");

            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.TWO_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping record on VolumeDrivers page - {0}", String.Format(VOLUMEDRIVERMAPPING_RECORD, VolumeDriverName))).Click();


            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, VolumeDriverName), WebDriverUtil.ONE_SECOND_WAIT,
            String.Format("Unable to locate VolumeDriverMapping delete button on VolumeDriver details - {0}", String.Format(VOLUMEDRIVERMAPPING_DELETE_BUTTON, VolumeDriverName))).Click();


            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVERMAPPING_DELETE_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void VerifyCreatedVolumeDriverMapping(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriversPage VerifyCreatedVolumeDriver");
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record VolumeDrivers page - {0}", String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName)));
            BaseClass._AttachScreenshot.Value = true;
            CloseVolumeDriverMappingDetailSideBar();
        }

        public static void DeleteCreatedVolumeDriverMappingset(string VolumeDriverMappingName)
        {
            LogWriter.WriteLog("Executing VOLUMEDRIVERMAPPINGsPage DeleteCreatedVOLUMEDRIVERMAPPINGset");


            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
                WebDriverUtil.NO_WAIT,
                String.Format
                ("Unable to locate the check VOLUMEDRIVERMAPPINGset of respective department- {0}",
                CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT)).Click();


            WebDriverUtil.GetWebElement(String.Format(EDIT_BUTTON, VolumeDriverMappingName),
                WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate VOLUMEDRIVERMAPPINGset record on VOLUMEDRIVERMAPPINGset page - {0}"
            , String.Format(EDIT_BUTTON, VolumeDriverMappingName))).Click();
            WebDriverUtil.GetWebElement(DELETE_BUTTON,
              WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate delete button - {0}", DELETE_BUTTON)).Click();
            if (WebDriverUtil.GetWebElement(VOLUME_CONFIRM_POPUP, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(CONFIRM_POPUP_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitForWebElementInvisible(VOLUME_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);


            }

            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
               WebDriverUtil.ONE_SECOND_WAIT,
               String.Format
               ("Unable to locate the check VOLUMEDRIVERMAPPINGset of respective department- {0}",
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

            LogWriter.WriteLog("Executing UnitOfMeasurePage.SelectCreatedDepartment");

            WebDriverUtil.GetWebElement(DEPARTMENT_DROPDOWN, WebDriverUtil.NO_WAIT, String.Format("Unable to locate the department dropdown - {0}", DEPARTMENT_DROPDOWN)).Click();
            WebDriverUtil.GetWebElement(String.Format(DEPARTMENT_VALUE, deptName),
           WebDriverUtil.NO_WAIT, String.Format("Unable to locate z record on attribute page - {0}"
            , String.Format(DEPARTMENT_VALUE, deptName))).Click();


        }
        public static void ClickOnVolumeDriverMappingTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverMappingPage.ClickOnVolumeDriverMappingTab");
            if (WebDriverUtil.GetWebElement(VOLUMEDRIVERMAPPING_PAGE, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                SeleniumDriver.Driver().FindElement(By.XPath(VOLUMEDRIVERMAPPING_TAB)).Click();
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

            AddNewVolumeDriverMappingWithGivenInput(inputData);


        }

        public static void ClickOnVolumeDriverMapping()
        {
            LogWriter.WriteLog("Executing VolumeDriversPage ClickOnVolumeDriverse");

            ClickOnAddButton();
            ClickOnNewVolumeDriverMappingMenuLink();


        }
        public static void ClickOnVolumeDriverset()
        {
            LogWriter.WriteLog("Executing VolumeDriversPage ClickOnVolumeDriverset");
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
            WebDriverUtil.WaitForAWhile();
        }

        public static void VerifyCreatedVolumeDriverMappingset(string VolumeDriverMappingName)
        {

            WebDriverUtil.WaitForWebElementInvisible(VOLUMESET_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);

            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
                 WebDriverUtil.NO_WAIT,
                 String.Format
                 ("Unable to locate the check VOLUMEDRIVERMAPPINGset of respective department- {0}",
                 CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT)).Click();



            BaseClass._AttachScreenshot.Value = true;


            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            IWebElement attributeData = WebDriverUtil.GetWebElement(String.Format(CREATED_VOLUMEDRIVERMAPPINGSET, VolumeDriverMappingName),
              WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate VOLUMEDRIVERMAPPINGset record on VOLUMEDRIVERMAPPINGset page - {0}"
                 , String.Format(CREATED_VOLUMEDRIVERMAPPINGSET, VolumeDriverMappingName)));






            WebDriverUtil.GetWebElement(CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT,
                        WebDriverUtil.NO_WAIT,
                        String.Format
                        ("Unable to locate the check VOLUMEDRIVERMAPPINGset of respective department- {0}",
                        CHECK_VOLUMEDRIVERMAPPING_OF_RESPECTIVE_DEPARTMENT)).Click();



        }

    }
}

