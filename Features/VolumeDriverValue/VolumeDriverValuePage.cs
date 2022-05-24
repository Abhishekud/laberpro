using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;


namespace LaborPro.Automation.Features.VolumeDriverValue
{
    public class VolumeDriverValuePage : SeleniumDriver
    {
      
        const string VOLUME_DRIVER_VALUE_PAGE = "//*[@class='page volume-driver-values-list-page']//*[@title='Volume Driver Values']";
        const string VOLUME_DRIVER_VALUE_TAB = "//*[@class='navigation-container']//*[contains(text(),'Volume Driver Values')]";
        const string VOLUME_DRIVER_VALUE_DOWNLOAD = "//*[@class='page volume-driver-values-list-page']//*[@id='export']//*[@class='fa fa-file-excel-o']";
        const string VOLUME_DRIVER_VALUE_DOWNLOAD_TEMPLATE = "//a[contains(text(),'Download Volume Driver Value Import Template')]";
        const string VOLUME_DRIVER_ADD_BUTTON = "//*[@class='header-button btn btn-default']";
        const string VOLUME_DRIVER_VALUE_IMPORT_TEMPLATE = "//h4[contains(text(),'Import Volume Driver Values')]";
        const string VOLUME_DRIVER_VALUE_LOAD_SPINNER = "//i[@class='fa fa-spinner fa-spin']";
        const string VOLUME_DRIVER_VALUE_TABLE = "//tbody[@role='presentation']";
        const string VOLUME_DRIVER_VALUE_VERIFICATION_OF_LOCATION_DEPARTMENT_VOLUMEDRIVER = "//tbody[@role='presentation']//td[@aria-colindex='{0}' and contains(text(),'{1}')]";
        const string VOLUME_DRIVER_VALUE_TABLE_HEADERS = "//table[@role='presentation']//th//*[@class='k-link']";
        const string IMPORT_ERROR_MODAL = "//*[@class='modal-content']//*[text()='Import Errors']";
        const string IMPORT_ERRROR_MODAL_OK_BUTTON = "//*[@class='modal-content']//*[text()='OK']";

        public static void ClickOnVolumeDriverValueTab()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.ClickOnVolumeDriverValueTab");
            if(WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_TAB, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate volume driver value tab - {0}", VOLUME_DRIVER_VALUE_TAB)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
        }
        public static int FindColumnIndex(string headername)
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.FindColumnIndex");

            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(VOLUME_DRIVER_VALUE_TABLE_HEADERS));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                if (headername.ToLower().Equals(header.Text.ToLower()))
                {
                    break;

                }
            }

            return index;
        }
        public static void ClickOnDownloadTemplate()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.ClickOnDownloadTemplate");
            if (WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate the page - {0}", VOLUME_DRIVER_VALUE_PAGE)) != null)
            {
                WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_DOWNLOAD, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate volume driver value DOWNLOAD - {0}", VOLUME_DRIVER_VALUE_DOWNLOAD)).Click();
                WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_DOWNLOAD_TEMPLATE, WebDriverUtil.ONE_SECOND_WAIT, String.Format("Unable to locate volume driver value template - {0}", VOLUME_DRIVER_VALUE_DOWNLOAD_TEMPLATE)).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TEN_SECOND_WAIT);
                if (File.Exists(SeleniumDriver.CsvFile) == false)
                {
                    WebDriverUtil.WaitFor(WebDriverUtil.MAX_WAIT);
                }
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static bool VerifyFileDownload(string filename)
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.VerifyFileDownload");
            bool exist = false;
            String[] filepaths = Directory.GetFiles(SeleniumDriver.DownloadDirectory);
            foreach(string p in filepaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    exist = true;
                    break;
                }
            }

            return exist;
            
        }
        public static void UploadTheUpdatedFile()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.UploadTheUpdatedFile");
            if (WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_PAGE, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(VOLUME_DRIVER_ADD_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);

                if (WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_IMPORT_TEMPLATE, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
                {
                
                    IJavaScriptExecutor js = (IJavaScriptExecutor)SeleniumDriver.Driver();
                    
                   IWebElement element = (IWebElement)js.ExecuteScript("return document.evaluate('//input[@type=\"file\"]',document,null,XPathResult.FIRST_ORDERED_NODE_TYPE,null).singleNodeValue;");
                    element.SendKeys(SeleniumDriver.CsvFile);
                    WebDriverUtil.WaitFor(WebDriverUtil.TEN_SECOND_WAIT);

                }
            }

            if(WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_LOAD_SPINNER, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.WaitForWebElementInvisible(VOLUME_DRIVER_VALUE_LOAD_SPINNER, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }

        }
        public static void AddRecordToCsv(string location, string location_description, string department, string Volumedriver, string value, string filepath)
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.addRecordToCsv");
            try
            {
                using (System.IO.StreamWriter file = new StreamWriter(@filepath, true))
                {
                    file.WriteLine(location + "," + location_description + "," + department + "," + Volumedriver + "," + value);
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void VerifyLocationInVolumeDriverValue(string location)
        {
            string location1 = "Location";
            LogWriter.WriteLog("Executing VolumeDriverValuePage.VerifyLocationInVolumeDriverValue");
            FindColumnIndex(location1);
            if (WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_TABLE, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(VOLUME_DRIVER_VALUE_VERIFICATION_OF_LOCATION_DEPARTMENT_VOLUMEDRIVER,FindColumnIndex(location1), location), WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void VerifyDepartmentInVolumeDriverValue(string department)
        {
            string Department = "Department";
            LogWriter.WriteLog("Executing VolumeDriverValuePage.VerifyDepartmentInVolumeDriverValue");
            if (WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_TABLE, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(VOLUME_DRIVER_VALUE_VERIFICATION_OF_LOCATION_DEPARTMENT_VOLUMEDRIVER,FindColumnIndex(Department), department), WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                BaseClass._AttachScreenshot.Value = true;
            }

        }
        public static void VerifyVolumedriverInVolumeDriverValue(string volumedriver)
        {
            string Voldriver = "Volume Driver";
            LogWriter.WriteLog("Executing VolumeDriverValuePage.VerifyVolumeDriverInVolumeDriverValue");
            if (WebDriverUtil.GetWebElement(VOLUME_DRIVER_VALUE_TABLE, WebDriverUtil.FIVE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(String.Format(VOLUME_DRIVER_VALUE_VERIFICATION_OF_LOCATION_DEPARTMENT_VOLUMEDRIVER,FindColumnIndex(Voldriver), volumedriver), WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                BaseClass._AttachScreenshot.Value = true;
            }
        }
        public static void DeleteDownloadedCsvFile()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.DeleteDownloadedCsvFile");
            try
            {
                string[] files = Directory.GetFiles(SeleniumDriver.DownloadDirectory);
                foreach(string file in files)
                {
                    File.Delete(file);
                    Console.WriteLine($"{file} is deleted");
                }
               
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }

        }
        public static void IgnoreImportErrorMessage()
        {
            LogWriter.WriteLog("Executing VolumeDriverValuePage.IgnoreImportErrorMessage");
            if (WebDriverUtil.GetWebElement(IMPORT_ERROR_MODAL, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) !=null)
            {
                WebDriverUtil.GetWebElement(IMPORT_ERRROR_MODAL_OK_BUTTON, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE).Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }

        }
    }
}
