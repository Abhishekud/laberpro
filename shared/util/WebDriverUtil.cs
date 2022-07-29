using LaborPro.Automation.shared.drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.shared.util
{
    internal class WebDriverUtil
    {
        public static readonly int NO_WAIT = 0;
        public static readonly int PAGE_LOAD_DEFAULT_WAIT = 30;
        public static readonly int PERFORM_ACTION_TIMEOUT = 60;
        public static readonly int DEFAULT_WAIT = 600;
        public static readonly int ONE_SECOND_WAIT = 1;
        public static readonly int TWO_SECOND_WAIT = 2;
        public static readonly int FIVE_SECOND_WAIT = 5;
        public static readonly int TEN_SECOND_WAIT = 10;
        public static readonly int SIXTY_SECOND_WAIT = 60;
        public static readonly int MAX_WAIT = 600;
        public static readonly string NO_MESSAGE = "";
        public static readonly string PAGE_CONTENTS_LOADING_XPATH = "//*[@class='main-content loading']";
        public static Boolean WaitForWebElement(string xpath, int timeout, string message)
        {
            WaitForWebElementInvisible(PAGE_CONTENTS_LOADING_XPATH, PAGE_LOAD_DEFAULT_WAIT, "Timeout - {0} Page contents is not getting load or it might taking too long time to load!");
            try
            {
                var wait = new WebDriverWait(SeleniumDriver.Driver(), TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
                return true;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
                if (message != null && message.Length > 0)
                    throw new Exception(message);
            }
            return false;
        }
        public static Boolean WaitForWebElementInvisible(string xpath, int timeout, string message)
        {
            try
            {

                var wait = new WebDriverWait(SeleniumDriver.Driver(), TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
                return true;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
                if (message != null && message.Length > 0)
                    throw new Exception(message);
            }
            return false;
        }
        public static Boolean WaitForWebElementClickable(string xpath, int timeout, string message)
        {
            WaitForWebElementInvisible(PAGE_CONTENTS_LOADING_XPATH, PAGE_LOAD_DEFAULT_WAIT, "Timeout - {0} Page contents is not getting load or it might taking too long time to load!");
            try
            {
                var wait = new WebDriverWait(SeleniumDriver.Driver(), TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                return true;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
                if (message != null && message.Length > 0)
                    throw new Exception(message);
            }
            return false;
        }
        public static IWebElement GetWebElement(string xpath, int timeout, string message)
        {
            WaitForWebElementInvisible(PAGE_CONTENTS_LOADING_XPATH, PAGE_LOAD_DEFAULT_WAIT, "Timeout - {0} Page contents is not getting load or it might taking too long time to load!");
            IWebElement? element = null;
            try
            {
                if (timeout > 0)
                {
                    var wait = new WebDriverWait(SeleniumDriver.Driver(), TimeSpan.FromSeconds(timeout));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
                }
                element = SeleniumDriver.Driver().FindElement(By.XPath(xpath));
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
                if (message != null && message.Length > 0)
                    throw new Exception(message);
            }
            return element;
        }
        public static IWebElement GetWebElementAndScroll(string xpath, int timeout, string message)
        {
            WaitForWebElementInvisible(PAGE_CONTENTS_LOADING_XPATH, PAGE_LOAD_DEFAULT_WAIT, "Timeout - {0} Page contents is not getting load or it might taking too long time to load!");
            IWebElement? element = null;
            try
            {
                if (timeout > 0)
                {
                    var wait = new WebDriverWait(SeleniumDriver.Driver(), TimeSpan.FromSeconds(timeout));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(xpath)));
                }
                element = SeleniumDriver.Driver().FindElement(By.XPath(xpath));
                Actions actions = new Actions(SeleniumDriver.Driver());
                actions.MoveToElement(element);
                actions.Perform();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
                if (message != null && message.Length > 0)
                    throw new Exception(message);
            }
            return element;
        }
        public static IWebElement GetWebElementAndScroll(string xpath)
        {
            WaitForWebElementInvisible(PAGE_CONTENTS_LOADING_XPATH, PAGE_LOAD_DEFAULT_WAIT, "Timeout - "+PAGE_LOAD_DEFAULT_WAIT+" Sec. Page contents is not getting load or it might taking too long time to load!");
            IWebElement? element = null;
            try
            {
                element = SeleniumDriver.Driver().FindElement(By.XPath(xpath));
                Actions actions = new Actions(SeleniumDriver.Driver());
                actions.MoveToElement(element);
                actions.Perform();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLog(ex.Message);
            }
            return element;
        }       
        public static void WaitFor(int timeout)
        {
            Thread.Sleep(timeout*1000);
        }
        public static void WaitForAWhile()
        {
            Thread.Sleep(1 * 1000);
        }
        public static void WaitForPageLoading()
        {
            WaitForWebElementInvisible(PAGE_CONTENTS_LOADING_XPATH, PAGE_LOAD_DEFAULT_WAIT, "Timeout - "+PAGE_LOAD_DEFAULT_WAIT+" Sec. Page contents is not getting load or it might taking too long time to load!");
        }

    }
}
