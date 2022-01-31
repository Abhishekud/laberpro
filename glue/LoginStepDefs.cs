using laberpro.drivers;
using laberpro.hooks;
using laberpro.pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.glue
{

    
    [Binding]
    public class LoginStepDefs
    {
        [Given(@"User launched ""([^""]*)""")]
        public void GivenUserLaunched(string browser) => BaseClass.OpenBrowser(browser);

        [Then(@"User go to application ""([^""]*)""")]
        public void ThenUserGoToApplication(string portal)
        {
           SeleniumDriver.driver().Navigate().GoToUrl(portal);
        }

        [When(@"User enter email: ""([^""]*)"" and password: ""([^""]*)""")]
        public void WhenUserEnterEmailAndPassword(string username, string password) => LoginPage.PerformLogin(username, password);

        [Then(@"Verify validation message: ""([^""]*)""")]
        public void ThenVerifyValidationMessage(string message)
        {
            
        }

        [When(@"User click on forgot password link")]
        public void WhenUserClickOnForgotPasswordLink()
        {
            
        }

        [Then(@"Verify text on screen ""([^""]*)""")]
        public void ThenVerifyTextOnScreen(string text)
        {
            
        }

        [Then(@"Verify button: ""([^""]*)""")]
        public void ThenVerifyButton(string buttonText)
        {
            
        }

        [Then(@"Click on button: ""([^""]*)""")]
        public void ThenClickOnButton(string buttonName)
        {
            
        }

        [When(@"User login with ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserLoginWithAnd(string p0, string p1)
        {
            
        }

        [Then(@"Verify Login message: ""([^""]*)""")]
        public void ThenVerifyLoginMessage(string message)
        {  
        }


        [When(@"User logout from the application")]
        public void WhenUserLogoutFromTheApplication() { HomePage.PerformLogout(); }

        [Then(@"User close browser")]
        public void ThenUserCloseBrowser() => BaseClass.CloseDriver();
        
    }
}
