using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace SpecflowBDDFramework.Src.Helpers
{
    public static class TestDataProvider
    {
        public static string GetTestInputValue(string jsonPathExpression)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestData.json");
            string testInputs = File.ReadAllText(path);
            JObject parsedInputs = JObject.Parse(testInputs);
            return parsedInputs.SelectToken(jsonPathExpression).ToString();
        }
    }
}
