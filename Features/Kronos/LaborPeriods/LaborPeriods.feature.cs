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
namespace LaborPro.Automation.Features.Kronos.LaborPeriods
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify LaborPeriods Module")]
    [NUnit.Framework.CategoryAttribute("LaborPro")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("LaborPeriods")]
    public partial class VerifyLaborPeriodsModuleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "LaborPro",
                "Regression",
                "LaborPeriods"};
        
#line 1 "LaborPeriods.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Kronos/LaborPeriods", "Verify LaborPeriods Module", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
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
#line 7
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
    testRunner.Given("User launched \"$browser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
    testRunner.When("User go to application \"$url\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
    testRunner.Then("User enter email: \"$username_1\" and password: \"$password_1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 11
    testRunner.And("Verify Login message: \"success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. Verify_that_click_on_New_Labor_Period")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _02_Verify_That_Click_On_New_Labor_Period()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. Verify_that_click_on_New_Labor_Period", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 15
    testRunner.Given("User navigates to LaborPeriod Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
    testRunner.When("User selects New LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 17
    testRunner.Then("User verify page \"Create Labor Period\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
    testRunner.And("User click cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. Verify_that_Name_Labor_Period_Type_Traffic_Pattern_Labor_Destribution_are_emp" +
            "ty_and_click_on_Save_button")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _03_Verify_That_Name_Labor_Period_Type_Traffic_Pattern_Labor_Destribution_Are_Empty_And_Click_On_Save_Button()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. Verify_that_Name_Labor_Period_Type_Traffic_Pattern_Labor_Destribution_are_emp" +
                    "ty_and_click_on_Save_button", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
    testRunner.Given("User navigates to LaborPeriod Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
    testRunner.When("User selects New LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
    testRunner.Then("User click save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
    testRunner.And("Verify Validation message :\"Name is required\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
    testRunner.And("Verify Validation message :\"Unknown labor period\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
    testRunner.And("Verify Validation message :\"Unknown traffic pattern\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
    testRunner.And("Verify Validation message :\"Unknown distribution type\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
    testRunner.And("User click cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04. Verify_that_if_we_select_Labor_Period_Type_as_Hours_of_Operation")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _04_Verify_That_If_We_Select_Labor_Period_Type_As_Hours_Of_Operation()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04. Verify_that_if_we_select_Labor_Period_Type_as_Hours_of_Operation", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
    testRunner.Given("User navigates to LaborPeriod Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 34
    testRunner.When("User selects New LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table49 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table49.AddRow(new string[] {
                            "Name",
                            ""});
                table49.AddRow(new string[] {
                            "LaborPeriodType",
                            "Hours of Operation"});
                table49.AddRow(new string[] {
                            "TrafficPattern",
                            ""});
                table49.AddRow(new string[] {
                            "LaborDistribution",
                            ""});
#line 35
    testRunner.And("User Add New LaborPeriod Using Below Input", ((string)(null)), table49, "And ");
#line hidden
#line 41
    testRunner.Then("User Verify HouseOfOperation by name \"Hours of Operation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
    testRunner.And("User click cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05. Verify_that_if_we_select_Labor_Period_Type_as_Hours_of_Operation_and_without_" +
            "selection_any_value_for_Day_click_on_Save_Button")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _05_Verify_That_If_We_Select_Labor_Period_Type_As_Hours_Of_Operation_And_Without_Selection_Any_Value_For_Day_Click_On_Save_Button()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05. Verify_that_if_we_select_Labor_Period_Type_as_Hours_of_Operation_and_without_" +
                    "selection_any_value_for_Day_click_on_Save_Button", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 45
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 46
    testRunner.Given("User navigates to LaborPeriod Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 47
    testRunner.Then("User Delete record If Exist \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 48
    testRunner.When("User selects New LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table50 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table50.AddRow(new string[] {
                            "Name",
                            "automations"});
                table50.AddRow(new string[] {
                            "LaborPeriodType",
                            "Hours of Operation"});
                table50.AddRow(new string[] {
                            "TrafficPattern",
                            "Distribute Evenly and Apply Rounding"});
                table50.AddRow(new string[] {
                            "LaborDistribution",
                            "Same As Selected Labor Period"});
#line 49
    testRunner.And("User Add New LaborPeriod Using Below Input", ((string)(null)), table50, "And ");
#line hidden
#line 55
    testRunner.Then("User Verify HouseOfOperation by name \"Hours of Operation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 56
    testRunner.Then("User click save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 57
    testRunner.Then("Verify Validation Message:\"Must have at least one labor period.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 58
    testRunner.And("User click cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("06. Verify_that_if_provide_all_valid_data_select_Labor_Period_Type_as_Hours_of_Op" +
            "eration_select_any_value_for_Day_Sunday_click_on_Save_Button")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _06_Verify_That_If_Provide_All_Valid_Data_Select_Labor_Period_Type_As_Hours_Of_Operation_Select_Any_Value_For_Day_Sunday_Click_On_Save_Button()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06. Verify_that_if_provide_all_valid_data_select_Labor_Period_Type_as_Hours_of_Op" +
                    "eration_select_any_value_for_Day_Sunday_click_on_Save_Button", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 61
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 62
    testRunner.Given("User navigates to LaborPeriod Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 63
    testRunner.Then("User Delete record If Exist \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
    testRunner.When("User selects New LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table51 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table51.AddRow(new string[] {
                            "Name",
                            "automations"});
                table51.AddRow(new string[] {
                            "LaborPeriodType",
                            "Hours of Operation"});
                table51.AddRow(new string[] {
                            "TrafficPattern",
                            "Distribute Evenly and Apply Rounding"});
                table51.AddRow(new string[] {
                            "LaborDistribution",
                            "Same As Selected Labor Period"});
#line 65
    testRunner.And("User Add New LaborPeriod Using Below Input", ((string)(null)), table51, "And ");
#line hidden
#line 71
   testRunner.Then("User Add HouseOfPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
   testRunner.Then("User search LaborPeriod \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
   testRunner.And("User Verify LaborPeriod By Name \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
   testRunner.Then("User selects LaborPeriod By Name \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
   testRunner.And("User delete created LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("07. Verify_that_if_Labor_Period_Name_already_exist")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _07_Verify_That_If_Labor_Period_Name_Already_Exist()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07. Verify_that_if_Labor_Period_Name_already_exist", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 78
   this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 79
    testRunner.Given("User navigates to LaborPeriod Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 80
    testRunner.Then("User Delete record If Exist \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
    testRunner.When("User selects New LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table52 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table52.AddRow(new string[] {
                            "Name",
                            "automations"});
                table52.AddRow(new string[] {
                            "LaborPeriodType",
                            "Hours of Operation"});
                table52.AddRow(new string[] {
                            "TrafficPattern",
                            "Distribute Evenly and Apply Rounding"});
                table52.AddRow(new string[] {
                            "LaborDistribution",
                            "Same As Selected Labor Period"});
#line 82
    testRunner.And("User Add New LaborPeriod Using Below Input", ((string)(null)), table52, "And ");
#line hidden
#line 88
   testRunner.Then("User Add HouseOfPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 89
   testRunner.And("User selects New LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table53 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table53.AddRow(new string[] {
                            "Name",
                            "automations"});
                table53.AddRow(new string[] {
                            "LaborPeriodType",
                            "Hours of Operation"});
                table53.AddRow(new string[] {
                            "TrafficPattern",
                            "Distribute Evenly and Apply Rounding"});
                table53.AddRow(new string[] {
                            "LaborDistribution",
                            "Same As Selected Labor Period"});
#line 90
   testRunner.Then("User Add New LaborPeriod Using Below Input", ((string)(null)), table53, "Then ");
#line hidden
#line 96
   testRunner.Then("User Add HouseOfPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 97
    testRunner.And("Verify Validation message :\"Name already exists\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 98
   testRunner.And("User click cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
   testRunner.Then("User search LaborPeriod \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 100
   testRunner.Then("User selects LaborPeriod By Name \"automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 101
   testRunner.Then("User delete created LaborPeriod", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("08. Logout and Close Browser")]
        [NUnit.Framework.CategoryAttribute("Cleanup")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _08_LogoutAndCloseBrowser()
        {
            string[] tagsOfScenario = new string[] {
                    "Cleanup",
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08. Logout and Close Browser", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 105
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 106
    testRunner.When("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 107
    testRunner.Then("User close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion