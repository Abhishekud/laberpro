using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laborpro.util
{
    public class TestScenario
    {
        public string id { get; set; }
        public string featureFileName { get; set; }
        public string scenarioName { get; set; }
        public Boolean smokeTest { get; set; }
        public Boolean regressionTest { get; set; }
    }
}
