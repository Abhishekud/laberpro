using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using laberpro.drivers;
using laberpro.hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laberpro.util;

namespace laberpro.pages
{
    public class LoginPage
    {
        public static readonly string USER_NAME_INPUT = "//input[@name='email']";
        public static readonly string PASSWORD_INPUT = "//input[@name='password']";
        public static readonly string LOGIN_BUTTON = "//button[@type='submit']";
        public static readonly string FORGOT_PASSWORD_LINK = "//*[text()='Forgot Password?']";
        public static readonly string FORGOT_LINK = "//button[@type='button' and text()='Forgot Password?']";
        public static readonly string HOME_PAGE_BUTTON = "//a[.//*[text()='Home']]";
        public static readonly string ERROR = "//*[contains(@class,'textError')]";
        public static readonly string ERROR_MESSAGE_XPATH = "//*[contains(@class,'textError') and contains(text(),'{0}')]";

        public static void PerformLogin(String userName, String password)
        {
            IWebElement userNameInput = WebDriverUtil.GetWebElement(USER_NAME_INPUT, WebDriverUtil.DEFAULT_WAIT,
                String.Format("Unable to locate user name input - [{0}]", USER_NAME_INPUT));
            IWebElement passwordInput = SeleniumDriver.driver().FindElement(By.XPath(PASSWORD_INPUT));
            IWebElement login = SeleniumDriver.driver().FindElement(By.XPath(LOGIN_BUTTON));
            userNameInput.Clear();
            userNameInput.SendKeys(userName);
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            login.Click();
             
        }

        public static void VerifyLoginSuccess()
        {
            var wait = new WebDriverWait(SeleniumDriver.driver(), TimeSpan.FromSeconds(30));
            wait.Until(drv => drv.FindElement(By.XPath(HOME_PAGE_BUTTON)));
            IWebElement homePageButton = SeleniumDriver.driver().FindElement(By.XPath(HOME_PAGE_BUTTON));
            if (homePageButton == null)
                throw new Exception("Login Failed!");
            Thread.Sleep(5000);
            BaseClass._AttachScreenshot.Value = true;
        }

    }
}
