using laborpro.drivers;
using laborpro.hooks;
using laborpro.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace laborpro.pages
{
    public class VolumeDriverPage
    {
        public static readonly string standard_Filing_FieldId = "//select[@id='standardFilingFieldId']";
        public static readonly string STANDARD_COLLAPSED_TAB = "//li[contains(@class,'collapsed')]//span[contains(text(),'Standards')]";
        public static readonly string LIST_MANAGEMENT_TAB = "//a[text()='List Management']";
        public static readonly string ADD_BUTTON = "//button[@id='create-volume-drivers']";
        public static readonly string ADD_VOLUMEDRIVER_LINK = "(//*[contains(@class,'dropdown open')]//a)[1]";
        public static readonly string NAME_INPUT = "//*[@id='name']";
        public static readonly string DEPARTMENT_INPUT = "//*[@id='departmentId']";
        public static readonly string SAVE_BUTTON = "//button[contains(text(),'Save')]";
        public static readonly string CLOSE_VOLUMEDRIVER_FORM_BUTTON = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        public static readonly string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        public static readonly string CREATED_VOLUMEDRIVER_TITLE = "//*[@class='page-title' and contains(text(),'{0}')]";

        public static readonly string PAGE_TITLE = "//*[@class='page-title']";
        public static readonly string  CLOSE_VOLUMEDRIVER_DETAILS = "//button[text()='Close']";
        public static readonly string CANCEL_VOLUMEDRIVER_DETAILS = "//button[text()='Cancel']]";
        public static readonly string VOLUMEDRIVER_DELETE_BUTTON = "//button[contains(@class,'delete')]";
        public static readonly string VOLUMEDRIVER_RECORD = "//*[@role='row' and .//*[text()='{0}']]";
        public static readonly string VOLUMEDRIVER_DELETE_CONFIRM_POPUP = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        public static readonly string VOLUMEDRIVER_DELETE_CONFIRM_POPUP_ACCEPT = "//*[@class='modal-dialog']//button[text()='Confirm']";
        public static readonly string CLOSE_BUTTON = "//button[@id='newVolumeDrivers']";




        
        public static void CloseVolumeDriverDetailSideBar()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.CloseVolumeDriverDetailSideBar");
            IWebElement VolumeDriverDetailsSideBar = WebDriverUtil.GetWebElement( CLOSE_VOLUMEDRIVER_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (VolumeDriverDetailsSideBar != null)
            {
                VolumeDriverDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            VolumeDriverDetailsSideBar = WebDriverUtil.GetWebElement(CANCEL_VOLUMEDRIVER_DETAILS, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (VolumeDriverDetailsSideBar != null)
            {
                VolumeDriverDetailsSideBar.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void DeleteCreatedVolumeDriver(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage.DeleteCreatedVolumeDriver");
            CloseVolumeDriverDetailSideBar();
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate VolumeDriver record on VolumeDrivers page - {0}", String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName))).Click();
           

            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_DELETE_BUTTON, VolumeDriverName), WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate VolumeDriver delete button on VolumeDriver details - {0}", String.Format(VOLUMEDRIVER_DELETE_BUTTON, VolumeDriverName))).Click();
             

            IWebElement confirmationPopup = WebDriverUtil.GetWebElement(VOLUMEDRIVER_DELETE_CONFIRM_POPUP, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (confirmationPopup != null)
            {
                WebDriverUtil.GetWebElement(VOLUMEDRIVER_DELETE_CONFIRM_POPUP_ACCEPT, WebDriverUtil.TWO_SECOND_WAIT,
                    String.Format("Unable to locate Confirm button on delete confirmation popup - {0}", VOLUMEDRIVER_DELETE_CONFIRM_POPUP_ACCEPT)).Click();
                WebDriverUtil.WaitForWebElementInvisible(VOLUMEDRIVER_DELETE_CONFIRM_POPUP, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void VerifyCreatedVolumeDriver(string VolumeDriverName)
        {
            LogWriter.WriteLog("Executing VolumeDriverPage VerifyCreatedDepartmen");
            WebDriverUtil.GetWebElement(String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName), WebDriverUtil.DEFAULT_WAIT,
            String.Format("Unable to locate record VolumeDrivers page - {0}", String.Format(VOLUMEDRIVER_RECORD, VolumeDriverName)));
            BaseClass._AttachScreenshot.Value = true;
             
        }
        public static void AddNewVolumeDriverWithGivenInput(Table inputData)
        {
            ClickOnAddButton();
            UserClickOnNewVolumeDriverMenuLink();
            LogWriter.WriteLog("Executing VolumeDriverPage AddNewVolumeDriverWithGivenInput");
            WebDriverUtil.WaitForAWhile();
            //Read input data
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NAME_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input VolumeDrivers page  - {0}", NAME_INPUT))
                    .SendKeys(dictionary["Name"]);
            }
            if (Util.ReadKey(dictionary, "Department") != null)
            {
                WebDriverUtil.GetWebElement(DEPARTMENT_INPUT, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate Name input VolumeDrivers page  - {0}",DEPARTMENT_INPUT))
                    .SendKeys(dictionary["Department"]);
            }


            WebDriverUtil.GetWebElementAndScroll(SAVE_BUTTON, WebDriverUtil.NO_WAIT,
                String.Format("Unable to locate save button VolumeDrivers page - {0}", SAVE_BUTTON)).Click();
            WebDriverUtil.WaitForAWhile();
        }

        public static void  UserClickOnNewVolumeDriverMenuLink()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage UserClickOnNewVolumeDriverMenuLink");
            WebDriverUtil.GetWebElement(ADD_VOLUMEDRIVER_LINK, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate NewVolumeDriverMenu menu link on add menu popup - {0}", ADD_VOLUMEDRIVER_LINK)).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void  ClickOnVolumeDriver()
        {
            LogWriter.WriteLog("Executing VolumeDriverPage ClickOnVolumeDriver");

            new SelectElement(WebDriverUtil.GetWebElement(standard_Filing_FieldId, WebDriverUtil.NO_WAIT,
               String.Format("Unable to locate standard_Filing_FieldId input VolumeDrivers page  - {0}", standard_Filing_FieldId)))
               .SelectByText("Volume Drivers");

        }
        public static void ClickOnAddButton()
        {
            LogWriter.WriteLog("Executing VolumeDriverPageClickOnAddButton");
            WebDriverUtil.GetWebElement(ADD_BUTTON, WebDriverUtil.NO_WAIT,
            String.Format("Unable to locate add button VolumeDrivers page  - {0}", ADD_BUTTON)).Click();
            WebDriverUtil.WaitForAWhile();
        }
        public static void CloseVolumeDriverForm()
        {
            LogWriter.WriteLog("Executing VolumeDriverCloseVolumeDriverForm");
            WaitForVolumeDriverAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CLOSE_VOLUMEDRIVER_FORM_BUTTON, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
             
            }
        }
       
        






        public static void ClickOnListManagementTab()
        {
            LogWriter.WriteLog("Executing VolumeDriver  ClickOnListManagementTab");
            CloseVolumeDriverDetailSideBar();
            IWebElement ListManagementTab = WebDriverUtil.GetWebElement(LIST_MANAGEMENT_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (ListManagementTab != null)
            {
                ListManagementTab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }








        public static void ClickOnStandardTab()
        {
            IWebElement standardtab = WebDriverUtil.GetWebElement(STANDARD_COLLAPSED_TAB, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardtab != null)
            {
                standardtab.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        
    
      
        public static void WaitForVolumeDriverAlertCloseIfAny()
        {
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                WebDriverUtil.GetWebElementAndScroll(NAME_INPUT).Click();
                IWebElement nametag = WebDriverUtil.GetWebElementAndScroll(NAME_INPUT);
                WebDriverUtil.WaitForWebElementInvisible(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        
        }
    }

