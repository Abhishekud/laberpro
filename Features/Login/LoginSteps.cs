using laborpro.drivers;
using laborpro.hooks;
using laborpro.pages;
using laborpro.util;
using System;
using TechTalk.SpecFlow;

namespace laborpro.glue
{

    
    [Binding]
    public class LoginSteps
    {
        [Given(@"User launched ""([^""]*)""")]
        [When(@"User launched ""([^""]*)""")]
        [Then(@"User launched ""([^""]*)""")]
        public void UserLaunchedBrowser(string browser)
        {
            LogWriter.WriteLog("Executing step: User navigates to the Locations tab");
            BaseClass.OpenBrowser(browser);
        }

        [Given(@"User go to application ""([^""]*)""")]
        [When(@"User go to application ""([^""]*)""")]
        [Then(@"User go to application ""([^""]*)""")]
        public void GoToApplication(string portal)
        {
            LogWriter.WriteLog("Executing step: User go to application "+ Util.ProcessInputDataString(portal));
            SeleniumDriver.Driver().Navigate().GoToUrl(Util.ProcessInputDataString(portal));
        }

        [Given(@"User enter email: ""([^""]*)"" and password: ""([^""]*)""")]
        [When(@"User enter email: ""([^""]*)"" and password: ""([^""]*)""")]
        [Then(@"User enter email: ""([^""]*)"" and password: ""([^""]*)""")]
        public void EnterEmailAndPassword(string username, string password)
        {
            LogWriter.WriteLog("Executing step: User enter email: "+ Util.ProcessInputDataString(username) + " and password: **********");
            LoginPage.PerformLogin(Util.ProcessInputDataString(username), Util.ProcessInputDataString(password));
        }


        [Given(@"Verify Login message: ""([^""]*)""")]
        [When(@"Verify Login message: ""([^""]*)""")]
        [Then(@"Verify Login message: ""([^""]*)""")]
        public void VerifyLoginMessage(string message)
        {
            LogWriter.WriteLog("Executing step: Verify Login message: "+message);
            LoginPage.VerifyLoginSuccess();
        }

        [Given(@"User logout from the application")]
        [When(@"User logout from the application")]
        [Then(@"User logout from the application")]
        public void LogoutFromTheApplication()
        {
            LogWriter.WriteLog("Executing step: User logout from the application");
            DashboardPage.PerformLogout();
        }

        [Given(@"User close browser")]
        [When(@"User close browser")]
        [Then(@"User close browser")]
        public void CloseBrowser()
        {
            LogWriter.WriteLog("Executing step: User close browser");
            BaseClass.CloseDriver();
        }
        
    }
}
