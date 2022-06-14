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
namespace LaborPro.Automation.Features.Tasks
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify Tasks Module")]
    [NUnit.Framework.CategoryAttribute("laborPro")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("Tasks")]
    public partial class VerifyTasksModuleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "laborPro",
                "Regression",
                "Tasks"};
        
#line 1 "Tasks.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Tasks", "Verify Tasks Module", null, ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("02. Verify_that_Click_on_New_Task_Opens_Add_popup.")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _02_Verify_That_Click_On_New_Task_Opens_Add_Popup_()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. Verify_that_Click_on_New_Task_Opens_Add_popup.", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
    testRunner.Given("User navigates to the Tasks tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
     testRunner.When("User clicks Add Tasks Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 15
     testRunner.Then("User verify Add Menu Tasks Popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 16
      testRunner.And("User clicks cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. verify_add_Tasks_when_enter_blank_details")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _03_Verify_Add_Tasks_When_Enter_Blank_Details()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. verify_add_Tasks_when_enter_blank_details", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
    testRunner.Given("User navigates to the Tasks tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table83 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table83.AddRow(new string[] {
                            "Name",
                            ""});
#line 21
     testRunner.When("User create new Tasks with below input", ((string)(null)), table83, "When ");
#line hidden
#line 24
     testRunner.Then("Verify validation Message: \"Task Name is required.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
      testRunner.And("User clicks cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04. verify_add_Tasks_when_enter_correct_details")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _04_Verify_Add_Tasks_When_Enter_Correct_Details()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04. verify_add_Tasks_when_enter_correct_details", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
    testRunner.Given("User navigates to the Tasks tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 30
     testRunner.Then("User delete Tasks \"Tasks Scenario\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table84 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table84.AddRow(new string[] {
                            "Name",
                            "Tasks Scenario"});
                table84.AddRow(new string[] {
                            "Generic Department",
                            "Generic Department"});
                table84.AddRow(new string[] {
                            "Combined Distribution",
                            "Combined Distribution"});
                table84.AddRow(new string[] {
                            "Time Dependency",
                            "Time Dependent"});
#line 31
     testRunner.When("User create new Tasks with below input", ((string)(null)), table84, "When ");
#line hidden
#line 37
     testRunner.Then("User verify created Tasks \"Tasks Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
      testRunner.And("User delete created Tasks \"Tasks Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05. Verify_that_Respective_TaskGroup_is_available_in_Task")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _05_Verify_That_Respective_TaskGroup_Is_Available_In_Task()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05. Verify_that_Respective_TaskGroup_is_available_in_Task", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 41
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
    testRunner.Given("User navigates to the TaskGroups tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
     testRunner.Then("User delete TaskGroups \"TaskGroups\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table85 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table85.AddRow(new string[] {
                            "Name",
                            "TaskGroups"});
                table85.AddRow(new string[] {
                            "Generic Department",
                            "Generic Department"});
                table85.AddRow(new string[] {
                            "Combined Distribution",
                            "Combined Distribution"});
                table85.AddRow(new string[] {
                            "Allocate Labor Hours",
                            "Start Day"});
                table85.AddRow(new string[] {
                            "Job Name",
                            "Job Name"});
#line 44
     testRunner.When("User create new TaskGroups with below input", ((string)(null)), table85, "When ");
#line hidden
#line 51
      testRunner.And("User verify created TaskGroups \"TaskGroups\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
     testRunner.Then("User navigates to the Tasks tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 53
      testRunner.And("User delete Tasks \"Tasks Scenario\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table86 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table86.AddRow(new string[] {
                            "Name",
                            "Tasks Scenario"});
                table86.AddRow(new string[] {
                            "Generic Department",
                            "Generic Department"});
                table86.AddRow(new string[] {
                            "Combined Distribution",
                            "Combined Distribution"});
                table86.AddRow(new string[] {
                            "Time Dependency",
                            "Time Dependent"});
                table86.AddRow(new string[] {
                            "TaskGroups",
                            "TaskGroups"});
#line 54
     testRunner.When("User create new Tasks with below input", ((string)(null)), table86, "When ");
#line hidden
#line 61
     testRunner.Then("User verify created Tasks \"Tasks Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 62
      testRunner.And("User delete created Tasks \"Tasks Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
     testRunner.Then("User navigates to the TaskGroups tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
      testRunner.And("User delete created TaskGroups by name \"TaskGroups\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("06. verify_add_Tasks_when_enter_existing_details")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _06_Verify_Add_Tasks_When_Enter_Existing_Details()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06. verify_add_Tasks_when_enter_existing_details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 67
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 68
    testRunner.Given("User navigates to the Tasks tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 69
      testRunner.And("User delete Tasks \"Tasks Exist Scenario\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table87 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table87.AddRow(new string[] {
                            "Name",
                            "Tasks Exist Scenario"});
                table87.AddRow(new string[] {
                            "Generic Department",
                            "Generic Department"});
                table87.AddRow(new string[] {
                            "Combined Distribution",
                            "Combined Distribution"});
                table87.AddRow(new string[] {
                            "Time Dependency",
                            "Time Dependent"});
#line 70
     testRunner.When("User create new Tasks with below input", ((string)(null)), table87, "When ");
#line hidden
#line 76
      testRunner.And("User verify created Tasks \"Tasks Exist Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table88 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table88.AddRow(new string[] {
                            "Name",
                            "Tasks Exist Scenario"});
                table88.AddRow(new string[] {
                            "Generic Department",
                            "Generic Department"});
                table88.AddRow(new string[] {
                            "Combined Distribution",
                            "Combined Distribution"});
                table88.AddRow(new string[] {
                            "Time Dependency",
                            "Time Dependent"});
#line 77
     testRunner.When("User create new Tasks with below input", ((string)(null)), table88, "When ");
#line hidden
#line 83
     testRunner.Then("Verify validation Message: \"Task Name must be unique.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 84
      testRunner.And("User clicks cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 85
      testRunner.And("User delete created Tasks \"Tasks Exist Scenario\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("07. Logout and Close Browser")]
        [NUnit.Framework.CategoryAttribute("Cleanup")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _07_LogoutAndCloseBrowser()
        {
            string[] tagsOfScenario = new string[] {
                    "Cleanup",
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07. Logout and Close Browser", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 88
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 89
     testRunner.When("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 90
     testRunner.Then("User close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
