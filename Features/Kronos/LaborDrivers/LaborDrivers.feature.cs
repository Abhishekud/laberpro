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
namespace LaborPro.Automation.Features.Kronos.LaborDrivers
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify LaborDrivers Module")]
    [NUnit.Framework.CategoryAttribute("laborPro")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("LaborDrivers")]
    public partial class VerifyLaborDriversModuleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "laborPro",
                "Regression",
                "LaborDrivers"};
        
#line 1 "LaborDrivers.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Kronos/LaborDrivers", "Verify LaborDrivers Module", null, ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("01. Launch Browser and Login to the Application")]
        [NUnit.Framework.CategoryAttribute("Setup")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _01_LaunchBrowserAndLoginToTheApplication()
        {
            string[] tagsOfScenario = new string[] {
                    "Setup",
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01. Launch Browser and Login to the Application", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
      testRunner.And("Verify Login message: \"success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. Verify_that_Click_on_New_Labor_Driver_Opens_Add_popup.")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _02_Verify_That_Click_On_New_Labor_Driver_Opens_Add_Popup_()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. Verify_that_Click_on_New_Labor_Driver_Opens_Add_popup.", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 12
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 13
    testRunner.Given("User navigates to the LaborDrivers tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
     testRunner.When("User clicks Add LaborDrivers Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 15
     testRunner.Then("User verify Add Menu Popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 16
      testRunner.And("User clicks cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. verify_add_LaborDrivers_when_enter_blank_details")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _03_Verify_Add_LaborDrivers_When_Enter_Blank_Details()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. verify_add_LaborDrivers_when_enter_blank_details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 19
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 20
    testRunner.Given("User navigates to the LaborDrivers tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table44 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table44.AddRow(new string[] {
                            "Name",
                            ""});
#line 21
     testRunner.When("User create new LaborDrivers with below input", ((string)(null)), table44, "When ");
#line hidden
#line 24
     testRunner.Then("Verify validation Message: \"Labor Driver Name is required.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
      testRunner.And("User clicks cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04. Verify_that_if_VolumeDriver_is_selected_fields_get_populated")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _04_Verify_That_If_VolumeDriver_Is_Selected_Fields_Get_Populated()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04. Verify_that_if_VolumeDriver_is_selected_fields_get_populated", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 29
    testRunner.Given("User navigates to the LaborDrivers tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table45 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table45.AddRow(new string[] {
                            "Name",
                            "LaborDrivers Exist Scenario"});
                table45.AddRow(new string[] {
                            "Driver Type",
                            "Volume Driver"});
#line 30
     testRunner.When("User create new LaborDrivers with below input", ((string)(null)), table45, "When ");
#line hidden
#line 34
     testRunner.Then("User verify Add Menu Popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 35
      testRunner.And("User clicks cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05. verify_add_LaborDrivers_when_enter_existing_details")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _05_Verify_Add_LaborDrivers_When_Enter_Existing_Details()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05. verify_add_LaborDrivers_when_enter_existing_details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 38
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 39
    testRunner.Given("User navigates to the LaborDrivers tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 40
     testRunner.Then("User delete LaborDrivers \"LaborDrivers Exist Scenario\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table46 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table46.AddRow(new string[] {
                            "Name",
                            "LaborDrivers Exist Scenario"});
                table46.AddRow(new string[] {
                            "Driver Type",
                            "Volume Driver"});
                table46.AddRow(new string[] {
                            "Number",
                            "2"});
                table46.AddRow(new string[] {
                            "Number of business days to look back for volume",
                            "2"});
                table46.AddRow(new string[] {
                            "Driver",
                            "Drivers"});
                table46.AddRow(new string[] {
                            "Generic Category",
                            "Generic Category"});
#line 41
     testRunner.When("User create new LaborDrivers with below input", ((string)(null)), table46, "When ");
#line hidden
#line 49
      testRunner.And("User verify created LaborDrivers \"LaborDrivers Exist Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table47 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table47.AddRow(new string[] {
                            "Name",
                            "LaborDrivers Exist Scenario"});
                table47.AddRow(new string[] {
                            "Driver Type",
                            "Volume Driver"});
                table47.AddRow(new string[] {
                            "Number",
                            "2"});
                table47.AddRow(new string[] {
                            "Number of business days to look back for volume",
                            "2"});
                table47.AddRow(new string[] {
                            "Driver",
                            "Drivers"});
                table47.AddRow(new string[] {
                            "Generic Category",
                            "Generic Category"});
#line 50
     testRunner.When("User create new LaborDrivers with below input", ((string)(null)), table47, "When ");
#line hidden
#line 58
     testRunner.Then("Verify validation Message: \"Labor Driver Name must be unique.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
      testRunner.And("User clicks cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
      testRunner.And("User delete created LaborDrivers \"LaborDrivers Exist Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("06. Logout and Close Browser")]
        [NUnit.Framework.CategoryAttribute("Cleanup")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _06_LogoutAndCloseBrowser()
        {
            string[] tagsOfScenario = new string[] {
                    "Cleanup",
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06. Logout and Close Browser", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 63
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 64
     testRunner.When("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 65
     testRunner.Then("User close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
