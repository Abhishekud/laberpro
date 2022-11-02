﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LaborPro.Automation.Features.Characteristic
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify Characteristic_ViewOnly Module")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("Characteristic_ViewOnly")]
    public partial class VerifyCharacteristic_ViewOnlyModuleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Regression",
                "Characteristic_ViewOnly"};
        
#line 1 "Characteristics_ViewOnly.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Characteristic", "Verify Characteristic_ViewOnly Module", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("01. Launch Browser and Login to the Application and perform prerequisites")]
        [NUnit.Framework.CategoryAttribute("Setup")]
        public void _01_LaunchBrowserAndLoginToTheApplicationAndPerformPrerequisites()
        {
            string[] tagsOfScenario = new string[] {
                    "Setup"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01. Launch Browser and Login to the Application and perform prerequisites", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("User launched \"$browser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When("User go to application \"$url\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then("User enter email: \"$username_4\" and password: \"$password_4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
 testRunner.And("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.And("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table29.AddRow(new string[] {
                            "Name",
                            "Department to verify Characteristic_ViewOnly"});
#line 11
 testRunner.And("User create new Department with below input if not exist", ((string)(null)), table29, "And ");
#line hidden
#line 14
 testRunner.And("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 15
 testRunner.And("User select the Department \"Department to verify Characteristic_ViewOnly\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table30.AddRow(new string[] {
                            "Name",
                            "Characteristic_created_via_automation"});
#line 16
 testRunner.And("User create new Characteristic with below input if not exist", ((string)(null)), table30, "And ");
#line hidden
#line 19
 testRunner.And("User click on Characteristic set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table31.AddRow(new string[] {
                            "Name",
                            "Characteristicset_created_via_automation"});
#line 20
 testRunner.And("User create new Characteristic with below input", ((string)(null)), table31, "And ");
#line hidden
#line 23
 testRunner.And("User refresh the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.Then("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. Verify_add_button_is_not_available")]
        public void _02_Verify_Add_Button_Is_Not_Available()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. Verify_add_button_is_not_available", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 26
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 27
 testRunner.Given("User logged in with view only access using username: \"$viewonly_username\" and pas" +
                        "sword: \"$viewonly_password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 28
 testRunner.When("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 29
 testRunner.Then("User select the Department \"Department to verify Characteristic_ViewOnly\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 30
 testRunner.Then("User verify add button is not available on characteristic page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. Verify_export_options_are_available")]
        public void _03_Verify_Export_Options_Are_Available()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. Verify_export_options_are_available", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 33
 testRunner.When("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 34
 testRunner.Then("User verify export option is available on characteristic page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04. Verify_delete_button_is_not_available")]
        public void _04_Verify_Delete_Button_Is_Not_Available()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04. Verify_delete_button_is_not_available", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 37
 testRunner.When("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 38
 testRunner.Then("User verify delete button is not available on characteristic page in \"Characteris" +
                        "tic_created_via_automation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05. Verify_edit_option_is_not_available")]
        public void _05_Verify_Edit_Option_Is_Not_Available()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05. Verify_edit_option_is_not_available", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 40
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 41
 testRunner.When("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 42
 testRunner.Then("User verify edit option is not available on characteristic page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("06. Logout and Close Browser")]
        [NUnit.Framework.CategoryAttribute("Cleanup")]
        public void _06_LogoutAndCloseBrowser()
        {
            string[] tagsOfScenario = new string[] {
                    "Cleanup"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06. Logout and Close Browser", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 47
 testRunner.Given("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 48
 testRunner.When("User enter email: \"$username_4\" and password: \"$password_4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 49
 testRunner.Then("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.And("User select the Department \"Department to verify Characteristic_ViewOnly\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 51
 testRunner.And("User delete Characteristic \"Characteristic_created_via_automation\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.And("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 53
 testRunner.And("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.And("User delete created Department \"Department to verify Characteristic_ViewOnly\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 55
 testRunner.And("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
 testRunner.Then("User close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
