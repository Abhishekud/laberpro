﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using System;
using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Login
{
    public class LoginPage
    {
        const string USER_NAME_INPUT = "//input[@name='email']";
        const string PASSWORD_INPUT = "//input[@name='password']";
        const string LOGIN_BUTTON = "//button[@type='submit']";
        const string HOME_PAGE_BUTTON = "//a[.//*[text()='Home']]";

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
        }
        public static void VerifyLoginSuccess()
        {
            LogWriter.WriteLog("Executing LoginPage.VerifyLoginSuccess");
            IWebElement homePageButton = WebDriverUtil.GetWebElement(HOME_PAGE_BUTTON, WebDriverUtil.PAGE_LOAD_DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
            if (homePageButton == null)
                throw new Exception("Login Failed!");
            Thread.Sleep(3000);
            BaseClass._AttachScreenshot.Value = true;
        }

    }
}
