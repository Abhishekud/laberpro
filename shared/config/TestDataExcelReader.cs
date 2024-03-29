﻿using LaborPro.Automation.shared.util;
using SpreadsheetLight;

namespace LaborPro.Automation.shared.config
{
    public class TestDataExcelReader
    {
        public static readonly string EXCEL_DATA_FILE_PATH = @"/resources/test-data/TestData.xlsx";
        public static Dictionary<string, TestScenario> ScenarioSuiteMapping = null;
        public const string REGRESSION_TEST = "RegressionTest";
        public const string SMOKE_TEST = "SmokeTest";
        public static Dictionary<string, TestScenario> GetScenarioMapping() 
        {
            if(ScenarioSuiteMapping == null)
            {
                ScenarioSuiteMapping = new Dictionary<string, TestScenario>();
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                string configFilePath = projectDirectory + EXCEL_DATA_FILE_PATH;
                using (SLDocument sl = new SLDocument())
                {
                    FileStream fs = new FileStream(configFilePath, FileMode.Open);
                    SLDocument sheet = new SLDocument(fs, "LaborPro");

                    SLWorksheetStatistics stats = sheet.GetWorksheetStatistics();
                    int startIndex = stats.StartRowIndex;
                    int endIndex = stats.EndRowIndex;
                    for (int j = 2; j <= stats.EndRowIndex; j++)
                    {
                        TestScenario scenario = new TestScenario();
                        scenario.id = sheet.GetCellValueAsString(j, 1);
                        scenario.featureFileName = sheet.GetCellValueAsString(j, 2);
                        scenario.scenarioName = sheet.GetCellValueAsString(j, 3);
                        string smokeTest = sheet.GetCellValueAsString(j, 4);
                        scenario.smokeTest = smokeTest != null && smokeTest.ToLower().Equals("yes") ? true : false;
                        string regressionTest = sheet.GetCellValueAsString(j, 5);
                        scenario.regressionTest = regressionTest != null && regressionTest.ToLower().Equals("yes") ? true : false;
                        if(Util.ReadKey(ScenarioSuiteMapping, scenario.featureFileName + "_" + scenario.scenarioName) ==null)
                            ScenarioSuiteMapping.Add(scenario.featureFileName + "_"+scenario.scenarioName, scenario);
                    }
                }
            }  
            return ScenarioSuiteMapping;
        }

        public static Boolean IsFeatureFileIncluded(string featureFileName, string suiteType)
        {
          
            Dictionary<string, TestScenario> scenarioMapping = GetScenarioMapping();
            foreach (KeyValuePair<string, TestScenario> entry in scenarioMapping)
            {
                TestScenario scenario = entry.Value;
                if (!scenario.featureFileName.ToLower().Equals(featureFileName.ToLower()))
                    continue;
                if (REGRESSION_TEST.ToLower().Equals(suiteType.ToLower()) && scenario.regressionTest)
                {
                    return true;
                }
                else if (SMOKE_TEST.ToLower().Equals(suiteType.ToLower()) && scenario.smokeTest)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
