using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborPro.Automation.Features.Dashboard
{
    public class DashboardPage
    {
        const string MODULE_TAB_XPATH = "//li[contains(@class,'group') and .//*[text()='{0}']]";
        const string MODULE_ACTION_XPATH = "//li[contains(@class,'group-link') and .//*[text()='{0}']]";
        
        public static void ClickOnModule(string moduleName)
        {
            LogWriter.WriteLog("Executing DashboardPage.ClickOnModule("+ moduleName+")");
            string moduleXPATH = String.Format(MODULE_TAB_XPATH, moduleName);
            IWebElement moduleElement = SeleniumDriver.Driver().FindElement(By.XPath(moduleXPATH));
            if(moduleElement == null)
                throw new Exception(String.Format("Unable to locate module using XPATH - {0}", moduleXPATH));
            if(moduleElement.GetAttribute("class").Contains("collapsed")) 
                moduleElement.Click();
        }

        public static void PerformModuleAction(string actionName)
        {
            LogWriter.WriteLog("Executing DashboardPage.PerformModuleAction("+ actionName+")");
            string actionXPATH = String.Format(MODULE_ACTION_XPATH, actionName);
            try
            {
                IWebElement moduleActionElement = SeleniumDriver.Driver().FindElement(By.XPath(actionXPATH));
                if (moduleActionElement == null)
                    throw new Exception(String.Format("Unable to locate action using XPATH - {0}", actionXPATH));
                moduleActionElement.Click();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PerformLogout()
        {
            try
            {
                LogWriter.WriteLog("Executing DashboardPage.PerformLogout..");
                ClickOnModule("Account");
                PerformModuleAction("Log Out");
                Thread.Sleep(3000);
                BaseClass._AttachScreenshot.Value = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        
    }
}
