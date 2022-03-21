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
namespace laborpro.Features.LocationMapping
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify LocationMapping Module")]
    [NUnit.Framework.CategoryAttribute("laborPro")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("LocationMapping")]
    public partial class VerifyLocationMappingModuleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "laborPro",
                "Regression",
                "LocationMapping"};
        
#line 1 "LocationMapping.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/LocationMapping", "Verify LocationMapping Module", null, ProgrammingLanguage.CSharp, new string[] {
                        "laborPro",
                        "Regression",
                        "LocationMapping"});
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
#line 5
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
#line 6
    testRunner.Given("User launched \"edge\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
     testRunner.When("User go to application \"$url\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
     testRunner.Then("User enter email: \"$username_2\" and password: \"$password_2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
      testRunner.And("Verify Login message: \"success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. verify_that_new_department_is_available_in_department_dropdown")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _02_Verify_That_New_Department_Is_Available_In_Department_Dropdown()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. verify_that_new_department_is_available_in_department_dropdown", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 12
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
#line 13
    testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 14
     testRunner.Then("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table30.AddRow(new string[] {
                            "Name",
                            "Department to verify LocationMapping"});
#line 15
     testRunner.When("User create new Department with below input", ((string)(null)), table30, "When ");
#line hidden
#line 18
     testRunner.Then("User verify created Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 19
     testRunner.Then("User navigates to the LocationMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
      testRunner.And("User select the Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
     testRunner.Then("Verify Record Of Selected Dept \"No records available\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03.Verify_that_Click_on_Location_record_shows_Mapping.")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _03_Verify_That_Click_On_Location_Record_Shows_Mapping_()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03.Verify_that_Click_on_Location_record_shows_Mapping.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 24
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
#line 25
    testRunner.Given("User navigates to the Locations tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table31.AddRow(new string[] {
                            "Name",
                            "Location via LocationMapping"});
#line 26
     testRunner.When("User create new location with below input if not exist", ((string)(null)), table31, "When ");
#line hidden
#line 29
      testRunner.And("User verify created location by name \"Location via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
     testRunner.When("User Maps created Department and location with \"Location via LocationMapping\" and" +
                        " \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
     testRunner.Then("User click on LocationMapping", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
      testRunner.And("User select the Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
      testRunner.And("User verify created LocationMapping \"Location via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04.Verify_that_Respective_\'Volume Driver Mapping Set\'_&_\'Characteristic Set\'_are_" +
            "available_in_dropdown.")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _04_Verify_That_Respective_VolumeDriverMappingSet__CharacteristicSet_Are_Available_In_Dropdown_()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04.Verify_that_Respective_\'Volume Driver Mapping Set\'_&_\'Characteristic Set\'_are_" +
                    "available_in_dropdown.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 36
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
#line 37
    testRunner.Given("User navigates to the VolumeDriverMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
     testRunner.Then("User select the Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
      testRunner.And("User click on VolumeDriverMapping set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table32.AddRow(new string[] {
                            "Name",
                            "VolumeDriverMappingset via LocationMapping"});
#line 40
     testRunner.When("User create new VolumeDriverMappingset with below input", ((string)(null)), table32, "When ");
#line hidden
#line 43
     testRunner.Then("User verify created VolumeDriverMappingset by name \"VolumeDriverMappingset via Lo" +
                        "cationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 45
    testRunner.Given("User navigates to the VolumeDriver tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table33.AddRow(new string[] {
                            "Name",
                            "VolumeDriver via LocationMapping"});
                table33.AddRow(new string[] {
                            "Department",
                            "Department to verify LocationMapping"});
#line 46
     testRunner.When("User create new VolumeDriver with below input", ((string)(null)), table33, "When ");
#line hidden
#line 50
     testRunner.Then("User verify created VolumeDriver by name \"VolumeDriver via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
     testRunner.When("User selects \"Units of Measure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 52
     testRunner.Then("User Selects Created Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table34.AddRow(new string[] {
                            "Name",
                            "UOM"});
#line 53
     testRunner.When("User adds Unit Of Measure using below input", ((string)(null)), table34, "When ");
#line hidden
#line 56
     testRunner.Then("User verify Added Unit of Measure \"UOM\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 57
    testRunner.Given("User navigates to the VolumeDriverMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 58
     testRunner.Then("User select the Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
      testRunner.And("User click on VolumeDriverMapping", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table35.AddRow(new string[] {
                            "VolumeDriver",
                            "VolumeDriver via LocationMapping"});
                table35.AddRow(new string[] {
                            "UOM",
                            "UOM"});
                table35.AddRow(new string[] {
                            "VolumeDriverMappingSet",
                            "2"});
#line 60
     testRunner.When("User create new VolumeDriverMapping with below input if not exist", ((string)(null)), table35, "When ");
#line hidden
#line 65
     testRunner.Then("User verify created VolumeDriverMapping by \"VolumeDriver via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
    testRunner.Given("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 67
     testRunner.Then("User select the Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 68
      testRunner.And("User click on Characteristic set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table36.AddRow(new string[] {
                            "Name",
                            "Characteristicset"});
#line 69
     testRunner.When("User create new Characteristic with below input", ((string)(null)), table36, "When ");
#line hidden
#line 72
     testRunner.Then("User verify created Characteristic by name \"Characteristicset\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
      testRunner.And("User refresh the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
     testRunner.Then("User navigates to the LocationMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
      testRunner.And("User select the Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
     testRunner.Then("User select the Location \"Location via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table37.AddRow(new string[] {
                            "VolumeDriverMappingSet",
                            "VolumeDriverMappingset via LocationMapping"});
                table37.AddRow(new string[] {
                            "CharacteristicSet",
                            "Characteristicset"});
#line 77
     testRunner.When("User create new LocationMapping with below input", ((string)(null)), table37, "When ");
#line hidden
#line 81
     testRunner.Then("User verify created LocationMapping \"Location via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05.Verify_that_Respective_\'Volume Driver Mapping Set\'_&_\'Characteristic Set\'_are_" +
            "available_in_dropdown_is_deleted.")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public virtual void _05_Verify_That_Respective_VolumeDriverMappingSet__CharacteristicSet_Are_Available_In_Dropdown_Is_Deleted_()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05.Verify_that_Respective_\'Volume Driver Mapping Set\'_&_\'Characteristic Set\'_are_" +
                    "available_in_dropdown_is_deleted.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 84
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
#line 85
    testRunner.Given("User navigates to the Locations tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 86
      testRunner.And("User delete created location by name \"Location via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 87
     testRunner.Then("User navigates to the VolumeDriverMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 88
     testRunner.When("User select the Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 89
      testRunner.And("User delete created VolumeDriverMapping by \"VolumeDriver via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 91
     testRunner.Then("User navigates to the VolumeDriver tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 92
      testRunner.And("User delete created VolumeDriver by name \"VolumeDriver via LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 94
     testRunner.When("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 95
     testRunner.Then("User delete created Department \"Department to verify LocationMapping\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 98
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
#line 99
     testRunner.When("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 100
     testRunner.Then("User close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
