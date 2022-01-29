namespace laberpro.constants
{
    public interface Constants
    {
        public static string PROJECT_NAME = "ARINE TEST AUTOMATION";
        public static string USER_DIR = System.getProperty("user.dir");
        public static string PROPERTY_FILE_PATH = "src/test/resources/";
        public static string TEST_DATA_FILE_PATH = "src/test/resources/test-data/";

        public static string DOT =".";

        public static string ENVIRONMENT ="env";
        public static string BROWSER = "browser";

        public static string URL = "url";
        public static string USER_TYPE = "user.type";
        public static string USER_NAME = "user.name";
        public static string PASSWORD = "user.pass";

        public static string PAGE_LOAD_TIMEOUT = "pageload.max.timeout";

        public static string GROUPING_BY = "groupingBy";
        public static string GROUPING_BY_TAGS = "Tags";
        public static string GROUPING_BY_EXCEL_MAPPING_DATA = "TestData";
        public static string SUITE_TYPE = "suiteType";
        public static string SUITE_TYPE_SMOKE = "SmokeTest";
        public static string SUITE_TYPE_REGRESSION = "RegressionTest";
    }
}
