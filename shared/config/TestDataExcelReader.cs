using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborpro.util
{
    public class TestDataExcelReader
    {
        public static readonly string EXCEL_DATA_FILE_PATH = @"/resources/test-data/TestData.xlsx";
        public static Dictionary<string, TestScenario> GetScenarioMapping()
        {
            Dictionary<string, TestScenario> ScenarioSuiteMapping = new Dictionary<string, TestScenario>();
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
                    if (scenario.id == null || scenario.id.Length == 0)
                        break;
                    scenario.featureFileName = sheet.GetCellValueAsString(j, 2);
                    scenario.scenarioName = sheet.GetCellValueAsString(j, 3);
                    string smokeTest = sheet.GetCellValueAsString(j, 4);
                    scenario.smokeTest = smokeTest != null && smokeTest.ToLower().Equals("yes") ? true : false;
                    string regressionTest = sheet.GetCellValueAsString(j, 5);
                    scenario.regressionTest = regressionTest != null && regressionTest.ToLower().Equals("yes") ? true : false;
                    ScenarioSuiteMapping.Add(scenario.scenarioName, scenario);

                }
            }
            return ScenarioSuiteMapping;
        }
    }
}
