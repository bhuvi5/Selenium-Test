using System;
using System.Collections.Generic;
using ProTester.Utilities;
using System.Configuration;

namespace ProTester.Driver
{
    public class Script
    {
        /// <summary>
        /// Run the script using TestCaseID,Priority,scriptFlow
        /// Call the corresponding TestSuite Method
        /// </summary>
        /// <param name="TestCaseID"></param>
        /// <param name="Priority"></param>
        /// <param name="scriptFlow"></param>
        /// <returns></returns>
        public static bool RunScript(string TestCaseID, bool Priority)
        {
            try
            {
                var methodsNames = RunMethods.MethodNames();
                List<ExcelLib.Datacollection> runConfig = GetRunConfigData();
                bool caseId = false;
                string priorityValue = Priority == true ? "y" : "n";
                for (int i = 1; i <= runConfig.Count; i++)
                {
                    string methodName = ExcelLib.ReadData(runConfig, i, "MethodName");
                    string testCaseID = ExcelLib.ReadData(runConfig, i, "TestCaseID");
                    string priority = ExcelLib.ReadData(runConfig, i, "Priority");
                    string dependsOn = ExcelLib.ReadData(runConfig, i, "DependsOn");
                    string expectedResult = ExcelLib.ReadData(runConfig, i, "ExpectedResult");
                    string url = ExcelLib.ReadData(runConfig, i, "URL");

                    if (priority.ToLower() == priorityValue && testCaseID.ToLower() == TestCaseID.ToLower())
                    {
                        TestSuite.SeleniumTestSuite.Initialization();
                        if (dependsOn != "")
                        {
                            foreach (string testCaseId in dependsOn.Split(','))
                            {
                                if (testCaseId != testCaseID)
                                {
                                    string[] dependencyTestCaseDetails = GetDependencyTestCaseDetails(runConfig, testCaseId);
                                    caseId = methodsNames["ExecutionMethod"]((testCaseId), dependencyTestCaseDetails[0], dependencyTestCaseDetails[1], dependencyTestCaseDetails[2]);
                                }
                            }
                        }
                        return methodsNames["ExecutionMethod"]((testCaseID), methodName, expectedResult, url);
                    }
                }
                return caseId;
            }
            catch (Exception ex)
            {
                Log.ErrorLog(ex.Message);
                return false;
            }

        }

        private static List<ExcelLib.Datacollection> GetRunConfigData()
        {
            List<ExcelLib.Datacollection> runConfig = ExcelLib.PopulateInCollection(AppConfigurationSettings.RunConfigPath);
            return runConfig;
        }

        private static string[] GetDependencyTestCaseDetails(List<ExcelLib.Datacollection> runConfig, string Testcaseid)
        {
            string[] dependencyTestCaseDetails = new string[3];
            for (int i = 1; i <= runConfig.Count; i++)
            {
                if (ExcelLib.ReadData(runConfig, i, "TestCaseID").ToLower() == Testcaseid.ToLower())
                {
                    dependencyTestCaseDetails[0] = ExcelLib.ReadData(runConfig, i, "MethodName");
                    dependencyTestCaseDetails[1] = ExcelLib.ReadData(runConfig, i, "ExpectedResult");
                    dependencyTestCaseDetails[2] = ExcelLib.ReadData(runConfig, i, "URL");
                    break;
                }
            }
            return dependencyTestCaseDetails;
        }

        public static void DriverEnd()
        {
            ProTester.TestSuite.SeleniumTestSuite.CleanUpTestSuite();
        }
    }


}
