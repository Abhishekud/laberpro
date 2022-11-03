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
namespace LaborPro.Automation.Features.VolumeDriverValue
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Verify VolumeDriverValue Module")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("VolumeDriverValue")]
    public partial class VerifyVolumeDriverValueModuleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Regression",
                "VolumeDriverValue"};
        
#line 1 "VolumeDriverValue.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/VolumeDriverValue", "Verify VolumeDriverValue Module", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
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
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
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
 testRunner.Then("User enter email: \"$username_1\" and password: \"$password_1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 10
 testRunner.And("Verify Login message: \"success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. verify_volume_driver_value_scenario_and_standardsuombylocation_scenarios")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _02_Verify_Volume_Driver_Value_Scenario_And_Standardsuombylocation_Scenarios()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. verify_volume_driver_value_scenario_and_standardsuombylocation_scenarios", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
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
 testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.When("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table116 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table116.AddRow(new string[] {
                            "Name",
                            "Department to verify VolumeDriverValue"});
#line 17
 testRunner.Then("User create new Department with below input if not exist", ((string)(null)), table116, "Then ");
#line hidden
#line 20
 testRunner.And("User verify created Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
 testRunner.Given("User navigates to the standards tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.And("User delete Standard \"standardforvolumedrivervalue\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 24
 testRunner.Then("User navigates to the attribute tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.And("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.Then("Verify selected Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
 testRunner.Then("User delete attribute \"attributeforvolumedrivervalue\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table117 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table117.AddRow(new string[] {
                            "Name",
                            "attributeforvolumedrivervalue"});
#line 28
 testRunner.When("User add new attribute using below input", ((string)(null)), table117, "When ");
#line hidden
#line 31
 testRunner.Then("User verify created attribute name \"attributeforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
 testRunner.Given("User navigates to the Characteristic tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 34
 testRunner.Then("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 35
 testRunner.And("User click on Characteristic set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table118 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table118.AddRow(new string[] {
                            "Name",
                            "charsetforvolumedrivervalue"});
#line 36
 testRunner.When("User create new Characteristic with below input", ((string)(null)), table118, "When ");
#line hidden
#line 39
 testRunner.Then("User verify created CharacteristicSet by name \"charsetforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 40
 testRunner.And("User refresh the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.Given("User navigates to the standards tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
 testRunner.And("User delete Standard \"standardforvolumedrivervalue\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table119 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table119.AddRow(new string[] {
                            "Name",
                            "standardforvolumedrivervalue"});
                table119.AddRow(new string[] {
                            "Department",
                            "Department to verify VolumeDriverValue"});
                table119.AddRow(new string[] {
                            "Attribute",
                            "attributeforvolumedrivervalue"});
#line 44
 testRunner.When("User add new standards using below input", ((string)(null)), table119, "When ");
#line hidden
#line 49
 testRunner.Then("User verify created standards name \"standardforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("User click on previous link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 52
 testRunner.Given("User navigates to the VolumeDriverMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 53
 testRunner.Then("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
 testRunner.Then("User delete VolumeDriverMapping \"VolumeDriver_automations\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 55
 testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 56
 testRunner.When("User selects UnitOfMeasure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 57
 testRunner.Then("User Selects Created Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 58
 testRunner.Then("User delete UnitOfMeasure \"UOMforvolumedrivervalue\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table120 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table120.AddRow(new string[] {
                            "Name",
                            "UOMforvolumedrivervalue"});
#line 59
 testRunner.When("User adds Unit Of Measure using below input", ((string)(null)), table120, "When ");
#line hidden
#line 62
 testRunner.Then("User verify Added Unit of Measure \"UOMforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Given("User navigates to the standards tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 65
 testRunner.When("User search standard by name \"standardforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 66
 testRunner.Then("User selects standard by name \"standardforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 67
 testRunner.Then("User clicks New Standard Element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 68
 testRunner.And("User Selects Standard Element type \"Estimate\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table121 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table121.AddRow(new string[] {
                            "Name",
                            "Dummy"});
                table121.AddRow(new string[] {
                            "Frequency",
                            "16"});
                table121.AddRow(new string[] {
                            "Unit of Measure",
                            "UOMforvolumedrivervalue"});
#line 69
 testRunner.When("User adds new Standard Element Using Below input", ((string)(null)), table121, "When ");
#line hidden
#line 74
 testRunner.Then("User verify standard element by name \"Dummy\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
 testRunner.And("User click on previous link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 77
 testRunner.Given("User navigates to the Locations tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 78
 testRunner.And("User delete location by name \"Locationforvolumedrivervalue\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table122 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table122.AddRow(new string[] {
                            "Name",
                            "Locationforvolumedrivervalue"});
#line 79
 testRunner.When("User create new location with below input", ((string)(null)), table122, "When ");
#line hidden
#line 82
 testRunner.And("User verify created location by name \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
 testRunner.When("User Maps created Department and location with \"Locationforvolumedrivervalue\" and" +
                        " \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 84
 testRunner.Then("User click on LocationMapping", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 85
 testRunner.And("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 86
 testRunner.And("User verify created LocationMapping \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.Given("User navigates to the VolumeDriverMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 89
 testRunner.Then("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 90
 testRunner.Then("User delete VolumeDriverMappingSet \"VolumeDriverMappingset_automations\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 91
 testRunner.And("User click on VolumeDriverMapping set", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table123 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table123.AddRow(new string[] {
                            "Name",
                            "VolumeDriverMappingset_automations"});
#line 92
 testRunner.When("User create new VolumeDriverMappingSet with below input", ((string)(null)), table123, "When ");
#line hidden
#line 95
 testRunner.And("User verify created VolumeDriverMappingSet by name \"VolumeDriverMappingset_automa" +
                        "tions\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.Then("User navigates to the VolumeDriver tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 98
 testRunner.Then("User delete VolumeDriver \"VolumeDriver_automations\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table124 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table124.AddRow(new string[] {
                            "Name",
                            "VolumeDriver_automations"});
                table124.AddRow(new string[] {
                            "Department",
                            "Department to verify VolumeDriverValue"});
#line 99
 testRunner.When("User create new VolumeDriver with below input", ((string)(null)), table124, "When ");
#line hidden
#line 103
 testRunner.And("User verify created VolumeDriver by name \"VolumeDriver_automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 105
 testRunner.Then("User navigates to the VolumeDriverMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 106
 testRunner.Then("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 107
 testRunner.Then("User delete VolumeDriverMapping \"VolumeDriver_automations\" if exist", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 108
 testRunner.And("User click on VolumeDriverMapping", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table125 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table125.AddRow(new string[] {
                            "VolumeDriver",
                            "VolumeDriver_automations"});
                table125.AddRow(new string[] {
                            "UOM",
                            "UOMforvolumedrivervalue"});
                table125.AddRow(new string[] {
                            "VolumeDriverMappingSet",
                            "2"});
#line 109
 testRunner.When("User create new VolumeDriverMappingSet with below input", ((string)(null)), table125, "When ");
#line hidden
#line 114
 testRunner.And("User verify created VolumeDriverMapping by \"VolumeDriver_automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 116
 testRunner.Then("User navigates to the LocationMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 117
 testRunner.And("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 118
 testRunner.Then("User select the Location \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 119
 testRunner.And("User refresh the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 120
 testRunner.Then("User navigates to the LocationMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 121
 testRunner.And("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 122
 testRunner.Then("User select the Location \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table126 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table126.AddRow(new string[] {
                            "VolumeDriverMappingSet",
                            "VolumeDriverMappingset_automations"});
                table126.AddRow(new string[] {
                            "CharacteristicSet",
                            "charsetforvolumedrivervalue"});
#line 123
 testRunner.When("User create new LocationMapping with below input", ((string)(null)), table126, "When ");
#line hidden
#line 127
 testRunner.Then("User verify created LocationMapping \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 129
 testRunner.Given("User navigates to volume driver values tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 130
 testRunner.When("User click download template", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 131
 testRunner.Then("User verify volume driver value downloaded file \"Volume-Driver-import-template\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 132
 testRunner.When("User Access the downloaded file and update volume driver value in location \"Locat" +
                        "ionforvolumedrivervalue\" \"Department to verify VolumeDriverValue\" \"VolumeDriver_" +
                        "automations\" \"10\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 133
 testRunner.Then("User import value in volume driver value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 134
 testRunner.And("User verify location department volumedriver in volume driver value page \"Locatio" +
                        "nforvolumedrivervalue\" \"Department to verify VolumeDriverValue\" \"VolumeDriver_au" +
                        "tomations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 136
 testRunner.Given("User navigates to standardsanduomsbylocation tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 137
 testRunner.And("User refresh the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 138
 testRunner.When("User search record by name \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 139
 testRunner.Then("User verify standardsanduombylocation \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 141
 testRunner.Given("User navigates to the Locations tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 142
 testRunner.And("User delete created location by name \"Locationforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 143
 testRunner.Then("User navigates to the VolumeDriverMapping tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 144
 testRunner.And("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 145
 testRunner.And("User delete created VolumeDriverMapping by \"VolumeDriver_automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 146
 testRunner.Then("User navigates to the VolumeDriver tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 147
 testRunner.And("User delete created VolumeDriver by name \"VolumeDriver_automations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 149
 testRunner.Given("User navigates to the standards tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 150
 testRunner.When("User search standard by name \"standardforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 151
 testRunner.Then("User selects standard by name \"standardforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 152
 testRunner.Then("User Delete created Standards", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 154
 testRunner.Given("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 155
 testRunner.When("User selects UnitOfMeasure", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 156
 testRunner.Then("User Selects Created Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 157
 testRunner.And("User delete UOM by name \"UOMforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 159
 testRunner.Given("User navigates to the attribute tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 160
 testRunner.Then("User select the Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 161
 testRunner.And("User delete created attribute:\"attributeforvolumedrivervalue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 163
 testRunner.Then("User navigates to the List Management tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 164
 testRunner.And("User selects Department", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 165
 testRunner.Then("User delete created Department \"Department to verify VolumeDriverValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. Logout and Close Browser")]
        [NUnit.Framework.CategoryAttribute("Cleanup")]
        [NUnit.Framework.CategoryAttribute("Smoke")]
        public void _03_LogoutAndCloseBrowser()
        {
            string[] tagsOfScenario = new string[] {
                    "Cleanup",
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. Logout and Close Browser", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 168
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 169
 testRunner.When("User logout from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 170
 testRunner.Then("User close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
