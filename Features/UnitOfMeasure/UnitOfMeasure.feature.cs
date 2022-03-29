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
namespace laborpro.Features.UnitOfMeasure
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify UnitOfMeasure Module")]
    [NUnit.Framework.CategoryAttribute("Laberpro")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("UnitsOfMeasure")]
    public partial class VerifyUnitOfMeasureModuleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "Laberpro",
                "Regression",
                "UnitsOfMeasure"};
        
#line 1 "UnitOfMeasure.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/UnitOfMeasure", "Verify UnitOfMeasure Module", "A short summary of the feature", ProgrammingLanguage.CSharp, new string[] {
                        "Laberpro",
                        "Regression",
                        "UnitsOfMeasure"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("01. Launch Browser and Login to the Application")]
        [NUnit.Framework.CategoryAttribute("Setup")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _01_LaunchBrowserAndLoginToTheApplication()
        {
            string[] tagsOfScenario = new string[] {
                    "Setup",
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01. Launch Browser and Login to the Application", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    testRunner.Given("User launched \"$browser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
    testRunner.When("User go to application \"$url\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
    testRunner.Then("User enter email: \"$username_2\" and password: \"$password_2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 10
    testRunner.And("Verify Login message: \"success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. verify_add_Units_Of_Measure_name_empty_tag")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _02_Verify_Add_Units_Of_Measure_Name_Empty_Tag()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. verify_add_Units_Of_Measure_name_empty_tag", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 14
    testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
    testRunner.When("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table40.AddRow(new string[] {
                            "Name",
                            "Department To verify Units of Measure"});
#line 16
    testRunner.Then("User create new Department with below input if not exist", ((string)(null)), table40, "Then ");
#line hidden
#line 19
    testRunner.And("User verify created Department \"Department To verify Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
    testRunner.When("User selects \"Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 22
    testRunner.Then("User Selects Created Department \"Department To verify Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table41.AddRow(new string[] {
                            "Name",
                            ""});
#line 23
    testRunner.And("User adds Unit Of Measure using below input", ((string)(null)), table41, "And ");
#line hidden
#line 26
    testRunner.Then("Verify validation Message: \"Name is required\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
    testRunner.And("User click cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. verify_add_Units_Of_Measure_By_adding_correct_record_of_name")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _03_Verify_Add_Units_Of_Measure_By_Adding_Correct_Record_Of_Name()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. verify_add_Units_Of_Measure_By_adding_correct_record_of_name", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 30
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 31
    testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 32
    testRunner.When("User selects \"Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 33
    testRunner.Then("User Selects Created Department \"Department To verify Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table42.AddRow(new string[] {
                            "Name",
                            "UOM"});
#line 34
    testRunner.When("User adds Unit Of Measure using below input", ((string)(null)), table42, "When ");
#line hidden
#line 37
    testRunner.Then("User verify Added Unit of Measure \"UOM\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
    testRunner.And("User delete created Unit Of Measure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04. verify_add_units_of_measure_By_selecting_the_respective_Department")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _04_Verify_Add_Units_Of_Measure_By_Selecting_The_Respective_Department()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04. verify_add_units_of_measure_By_selecting_the_respective_Department", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 41
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
     testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
    testRunner.When("User selects \"Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 44
    testRunner.Then("User Selects Created Department \"Department To verify Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 45
    testRunner.Then("User verify the Department record \"No records available\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05. verify_add_Units_Of_Measure_name_already_exists")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _05_Verify_Add_Units_Of_Measure_Name_Already_Exists()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05. verify_add_Units_Of_Measure_name_already_exists", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 48
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 49
      testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 50
      testRunner.Then("User selects \"Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
       testRunner.Then("User Selects Created Department \"Department To verify Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table43 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table43.AddRow(new string[] {
                            "Name",
                            "UOM"});
#line 52
       testRunner.When("User adds Unit Of Measure using below input", ((string)(null)), table43, "When ");
#line hidden
#line 55
     testRunner.Then("User verify Added Unit of Measure \"UOM\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table44 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table44.AddRow(new string[] {
                            "Name",
                            "UOM"});
#line 56
     testRunner.When("User adds Unit Of Measure using below input", ((string)(null)), table44, "When ");
#line hidden
#line 60
     testRunner.Then("Verify validation Message: \"Name already exists\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
     testRunner.Then("User click cancel Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 62
     testRunner.And("User delete created Unit Of Measure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 63
     testRunner.Then("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
     testRunner.And("User delete created Department \"Department To verify Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("06. Logout and Close Browser")]
        [NUnit.Framework.CategoryAttribute("Cleanup")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _06_LogoutAndCloseBrowser()
        {
            string[] tagsOfScenario = new string[] {
                    "Cleanup",
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06. Logout and Close Browser", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 67
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 68
    testRunner.When("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 69
    testRunner.Then("User close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
