using laberpro.drivers;
using laberpro.hooks;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laberpro.pages
{
    internal class HomePage
    {
        public static readonly string MODULE_TAB_XPATH = "//li[contains(@class,'group') and .//*[text()='{0}']]";
        public static readonly string MODULE_ACTION_XPATH = "//li[contains(@class,'group-link') and .//*[text()='{0}']]";

        public static void ClickOnModule(string moduleName)
        {
            string moduleXPATH = String.Format(MODULE_TAB_XPATH, moduleName);
            IWebElement moduleElement = SeleniumDriver.driver().FindElement(By.XPath(moduleXPATH));
            if(moduleElement == null)
                throw new Exception(String.Format("Unable to locate module using XPATH - {0}", moduleXPATH));
            if(moduleElement.GetAttribute("class").Contains("collapsed")) 
                moduleElement.Click();
        }

        public static void PerformModuleAction(string actionName)
        {
            string actionXPATH = String.Format(MODULE_ACTION_XPATH, actionName);
            IWebElement moduleActionElement = SeleniumDriver.driver().FindElement(By.XPath(actionXPATH));
            if (moduleActionElement == null)
                throw new Exception(String.Format("Unable to locate action using XPATH - {0}", actionXPATH));
            moduleActionElement.Click();
        }

        public static void PerformLogout()
        {
            ClickOnModule("Account");
            PerformModuleAction("Log Out");
            Thread.Sleep(3000);
            BaseClass._AttachScreenshot.Value = true;
        }
    }
}
