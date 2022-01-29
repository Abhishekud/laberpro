using laberpro.drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laberpro.util
{
    internal class WebDriverUtil
    {
        public static readonly int NO_WAIT = 0;
        public static readonly int DEFAULT_WAIT = 30;
        public static readonly int ONE_SECOND_WAIT = 1;
        public static readonly int TWO_SECOND_WAIT = 2;
        public static readonly int FIVE_SECOND_WAIT = 5;
        public static readonly int TEN_SECOND_WAIT = 10;
        public static readonly int SIXTY_SECOND_WAIT = 60;
        public static readonly int MAX_WAIT = 120;
        public static IWebElement GetWebElement(string xpath, int timeout, string message)
        {
            IWebElement? element = null;
            try
            {
                if (timeout > 0)
                {
                    var wait = new WebDriverWait(SeleniumDriver.driver(), TimeSpan.FromSeconds(timeout));
                    wait.Until(drv => drv.FindElement(By.XPath(xpath)));
                }
                element = SeleniumDriver.driver().FindElement(By.XPath(xpath));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (message != null && message.Length > 0)
                    throw new Exception(message);
            }
            return element;
        }

        public static IWebElement GetWebElementAndScroll(string xpath, int timeout, string message)
        {
            IWebElement? element = null;
            try
            {
                if (timeout > 0)
                {
                    var wait = new WebDriverWait(SeleniumDriver.driver(), TimeSpan.FromSeconds(timeout));
                    wait.Until(drv => drv.FindElement(By.XPath(xpath)));
                }
                element = SeleniumDriver.driver().FindElement(By.XPath(xpath));
                Actions actions = new Actions(SeleniumDriver.driver());
                actions.MoveToElement(element);
                actions.Perform();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (message != null && message.Length > 0)
                    throw new Exception(message);
            }
            return element;
        }
    }
}