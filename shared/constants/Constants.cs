namespace laborpro.constants
{
    public interface Constants
    {
        const string PROJECT_NAME = "LaborPro Test Automation";
        const string USER_DIR = System.getProperty("user.dir");
        const string PROPERTY_FILE_PATH = "src/test/resources/";
        const string TEST_DATA_FILE_PATH = "src/test/resources/test-data/";

        const string DOT =".";

        const string ENVIRONMENT ="env";
        const string BROWSER = "browser";

        const string URL = "url";
        const string USER_TYPE = "user.type";
        const string USER_NAME = "user.name";
        const string PASSWORD = "user.pass";

        const string PAGE_LOAD_TIMEOUT = "pageload.max.timeout";

        const string GROUPING_BY = "groupingBy";
        const string GROUPING_BY_TAGS = "Tags";
        const string GROUPING_BY_EXCEL_MAPPING_DATA = "TestData";
        const string SUITE_TYPE = "suiteType";
        const string SUITE_TYPE_SMOKE = "SmokeTest";
        const string SUITE_TYPE_REGRESSION = "RegressionTest";
    }
}
