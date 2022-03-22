using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using laborpro.drivers;
using laborpro.hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laborpro.util;

namespace laborpro.pages
{
    public class LoginPage
    {
        const string USER_NAME_INPUT = "//input[@name='email']";
        const string PASSWORD_INPUT = "//input[@name='password']";
        const string LOGIN_BUTTON = "//button[@type='submit']";
        const string FORGOT_PASSWORD_LINK = "//*[text()='Forgot Password?']";
        const string FORGOT_LINK = "//button[@type='button' and text()='Forgot Password?']";
        const string HOME_PAGE_BUTTON = "//a[.//*[text()='Home']]";
        const string ERROR = "//*[contains(@class,'textError')]";
        const string ERROR_MESSAGE_XPATH = "//*[contains(@class,'textError') and contains(text(),'{0}')]";
        const string ERROR_ALERT_TOAST_XPATH = "//*[@class='toast toast-error']";
        public static void PerformLogin(String userName, String password)
        {
            LogWriter.WriteLog("Executing LoginPage.PerformLogin");
            IWebElement userNameInput = WebDriverUtil.GetWebElement(USER_NAME_INPUT, WebDriverUtil.DEFAULT_WAIT,
                String.Format("Unable to locate user name input - [{0}]", USER_NAME_INPUT));
            userNameInput.Clear();
            userNameInput.SendKeys(userName);
            IWebElement passwordInput = WebDriverUtil.GetWebElement(PASSWORD_INPUT, WebDriverUtil.DEFAULT_WAIT,
                String.Format("Unable to locate password input - [{0}]", PASSWORD_INPUT));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            IWebElement login = WebDriverUtil.GetWebElement(LOGIN_BUTTON, WebDriverUtil.DEFAULT_WAIT,
                String.Format("Unable to locate login button - [{0}]", LOGIN_BUTTON));
            WebDriverUtil.WaitForWebElementClickable(LOGIN_BUTTON, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            login.Click();
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ERROR_ALERT_TOAST_XPATH, WebDriverUtil.TWO_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                login = WebDriverUtil.GetWebElement(LOGIN_BUTTON, WebDriverUtil.DEFAULT_WAIT,
                String.Format("Unable to locate login button - [{0}]", LOGIN_BUTTON));
                WebDriverUtil.WaitForWebElementClickable(LOGIN_BUTTON, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
                login.Click();
            }

        }
        public static void VerifyLoginSuccess()
        {
            LogWriter.WriteLog("Executing LoginPage.VerifyLoginSuccess");
            IWebElement homePageButton = WebDriverUtil.GetWebElement(HOME_PAGE_BUTTON, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            if (homePageButton == null)
                throw new Exception("Login Failed!");
            Thread.Sleep(3000);
            BaseClass._AttachScreenshot.Value = true;
        }

    }
}
