﻿using LaborPro.Automation.shared.util;

namespace LaborPro.Automation.Features.Classifications
{
    [Binding]
    public class ClassificationsSteps
    {

        [When(@"User navigates to the Classifications tab")]
        [Given(@"User navigates to the Classifications tab")]
        [Then(@"User navigates to the Classifications tab")]
        public void NavigatesToTheClassificationsTab()
        {
            LogWriter.WriteLog("Executing ClassificationsPage UserNavigatesToTheClassificationsTab ");
            ClassificationsPage.CloseClassificationsForm();
            ClassificationsPage.ClickOnStandardTab();
            ClassificationsPage.ClickOnListManagementTab();
            ClassificationsPage.ClickOnClassifications();

        }
        [Given(@"User create new Classifications with below input")]
        [When(@"User create new Classifications with below input")]
        [Then(@"User create new Classifications with below input")]
        public void AddNewClassificationsWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing ClassificationsPage AddNewClassificationsWithGivenInput");
            ClassificationsPage.AddNewClassificationsWithGivenInput(inputData);
        }

        [Given(@"User create new Classifications with below input if not exist")]
        [When(@"User create new Classifications with below input if not exist")]
        [Then(@"User create new Classifications with below input if not exist")]
        public void AddNewClassificationsWithGivenInputIfNotExist(Table inputData)
        {
            LogWriter.WriteLog("Executing ClassificationsPage AddNewClassificationsWithGivenInputIfNotExist");
            ClassificationsPage.AddNewClassificationsWithGivenInputIfNotExist(inputData);
        }

        [Given(@"User verify created Classifications by name ""([^""]*)""")]
        [When(@"User verify created Classifications by name ""([^""]*)""")]
        [Then(@"User verify created Classifications by name ""([^""]*)""")]
        public void VerifyCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage UserVerifyCreatedClassifications");
            ClassificationsPage.VerifyCreatedClassifications(classificationsName);
        }

        [Given(@"User delete created Classifications by name ""([^""]*)""")]
        [When(@"User delete created Classifications by name ""([^""]*)""")]
        [Then(@"User delete created Classifications by name ""([^""]*)""")]
        public void DeleteCreatedClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing ClassificationsPage UserDeleteCreatedClassifications");
            ClassificationsPage.DeleteCreatedClassifications(classificationsName);
        }

        [Given(@"User delete Classifications ""([^""]*)"" if exist")]
        [When(@"User delete Classifications ""([^""]*)"" if exist")]
        [Then(@"User delete Classifications ""([^""]*)"" if exist")]
        public void DeleteClassificationsIfExist(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User delete created Classifications by name" + classificationsName);
            ClassificationsPage.DeleteClassificationsIfExist(classificationsName);
        }

        [Given(@"User find classification by name ""([^""]*)""")]
        [When(@"User find Classification by name ""([^""]*)""")]
        [Then(@"User find Classification by name ""([^""]*)""")]
        public void FindClassificationByName(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User find classification by name " + classificationsName);
            ClassificationsPage.FindClassificationByName(classificationsName);
        }


        [Given(@"User verify add classification button is not available")]
        [When(@"User verify add classification button is not available")]
        [Then(@"User verify add classification button is not available")]
        public void VerifyAddButtonIsNotPresent()
        {
            LogWriter.WriteLog("Executing Step User verify Add button is not present");
            NavigatesToTheClassificationsTab();
            ClassificationsPage.VerifyAddButtonIsNotPresent();
        }

        [Then(@"User verify delete classification button is not available in ""([^""]*)""")]
        [When(@"User verify delete classification button is not available in ""([^""]*)""")]
        [Given(@"User verify delete classification button is not available in ""([^""]*)""")]
        public void VerifyDeleteClassificationButtonIsNotAvailableIn(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User verify Delete Button is not Present");
            NavigatesToTheClassificationsTab();
            ClassificationsPage.FindClassificationByName(DataCache.Read(classificationsName));
            ClassificationsPage.VerifyDeleteButtonIsNotPresent();
        }

        [When(@"User create classifications ""([^""]*)""")]
        [Then(@"User create classifications ""([^""]*)""")]
        [Given(@"User create classifications ""([^""]*)""")]
        public void CreateClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User create classifications " + classificationsName);
            NavigatesToTheClassificationsTab();
            ClassificationsPage.AddNewClassificationsWithGivenInput(DataCache.Read(classificationsName));
        }

        [Then(@"User verify add button is not available on classifications page")]
        [When(@"User verify add button is not available on classifications page")]
        [Given(@"User verify add button is not available on classifications page")]
        public void VerifyAddButtonIsNotAvailableOnClassificationsPage()
        {
            LogWriter.WriteLog("Executing Step User verify add button is not available on classifications page");
            NavigatesToTheClassificationsTab();
            ClassificationsPage.VerifyAddButtonIsNotAvailable();
        }

        [Then(@"User verify delete button and edit option is not available in ""([^""]*)"" on classifications page")]
        [When(@"User verify delete button and edit option is not available in ""([^""]*)"" on classifications page")]
        [Given(@"User verify delete button and edit option is not available in ""([^""]*)"" on classifications page")]
        public void VerifyDeleteButtonAndEditOptionIsNotAvailableInOnClassificationsPage(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User verify delete button and edit option is not available in " + classificationsName + " on classifications page");
            NavigatesToTheClassificationsTab();
            ClassificationsPage.FindClassificationByName(DataCache.Read(classificationsName));
            ClassificationsPage.VerifyDeleteButtonAndEditOptionIsNotAvailable();
        }

        [Given(@"User delete classifications ""([^""]*)""")]
        [Then(@"User delete classifications ""([^""]*)""")]
        [When(@"User delete classifications ""([^""]*)""")]
        public void WhenUserDeleteClassifications(string classificationsName)
        {
            LogWriter.WriteLog("Executing Step User delete classifications " + classificationsName);
            NavigatesToTheClassificationsTab();
            ClassificationsPage.DeleteClassificationsIfExist(DataCache.Read(classificationsName));
        }

    }
}
