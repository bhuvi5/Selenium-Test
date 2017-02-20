using System;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;
using ProTester.Utilities;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using static ProTester.Utilities.ExcelLib;
using System.Collections.Generic;
using ProTester.TestSuite;

namespace ProTester.TestSuite
{

    public static class SeleniumTestSuite
    {
        public static void Initialization()
        {
            // Start browser
            PropertiesCollection.driver = new FirefoxDriver();
            ClearBrowserCache();
            // Pass application URL
            PropertiesCollection.driver.Url = AppConfigurationSettings.ApplicationPath;
            // Maximize browser
            PropertiesCollection.driver.Manage().Window.Maximize();
            TestResultUtility.InitializeTestResultString("Test Suite");
        }
        public static bool ExecutionMethod(string testCaseID, string functionName, string expectedResult, string URL)
        {
            try
            {
                if (!string.IsNullOrEmpty(URL))
                {
                    PropertiesCollection.driver.Navigate().GoToUrl(AppConfigurationSettings.ApplicationPath + URL);
                    Thread.Sleep(5000);
                }

                List<Datacollection> controlDetailsDataColllection = PopulateInCollection(AppConfigurationSettings.ControlDetails, testCaseID);
                for (int details = 1; details <= controlDetailsDataColllection.Count; details++)
                {
                    string controllerType = ReadData(controlDetailsDataColllection, details, "ControllerType");
                    string controlName = ReadData(controlDetailsDataColllection, details, "ControllerName");
                    string propertyType = ReadData(controlDetailsDataColllection, details, "PropertyType");
                    string waitTime = ReadData(controlDetailsDataColllection, details, "WaitTime");
                    string controllerValue = ReadData(controlDetailsDataColllection, details, "ControllerValue");
                    string scroll = ReadData(controlDetailsDataColllection, details, "Scroll");
                    string alert = ReadData(controlDetailsDataColllection, details, "Alert");
                    string checklist = ReadData(controlDetailsDataColllection, details, "Checklist");
                    string screenshot = ReadData(controlDetailsDataColllection, details, "Screenshot");
                    if (!string.IsNullOrEmpty(controllerType))
                    {
                        if (controllerType == ControllerType.Text.ToString())
                        {
                            SeleniumMethods.EnterText(controlName, controllerValue, propertyType);
                        }
                        if (checklist.ToLower() == "yes")
                        {
                            if (!SeleniumMethods.VerifyDropdownValue(controlName, controllerValue))
                            {
                                SaveScreenshot(PropertiesCollection.driver.Title, functionName, testCaseID);

                                TestResultUtility.AddTestFailToTestResultString("Project", controllerValue + "-Checklist Name-Available", controllerValue + " -Checklist Name Not Available", "Fail");
                                return false;
                            }
                        }
                        if (controllerType == ControllerType.Dropdown.ToString())
                        {
                            SeleniumMethods.SelectDropDown(controlName, controllerValue, propertyType);
                        }
                        if (controllerType == ControllerType.SelectiveDropdown.ToString())
                        {
                            SeleniumMethods.Click(controlName, propertyType);
                            Thread.Sleep(1000);
                            SeleniumMethods.SelectiveDropDownClick(controllerValue);
                            Thread.Sleep(2000);
                        }
                        if (scroll.ToLower() == "yes")
                        {
                            ((IJavaScriptExecutor)PropertiesCollection.driver).ExecuteScript("scroll(0,700)");
                        }
                        if (controllerType == ControllerType.Button.ToString())
                        {
                            // Take a screenshot and save 
                            SaveScreenshot(PropertiesCollection.driver.Title, functionName, testCaseID);
                            Thread.Sleep(1000);
                            SeleniumMethods.Click(controlName, propertyType);
                        }
                        if (controllerType == ControllerType.Map.ToString())
                        {
                            SeleniumMethods.ProductMapping(controllerValue);
                        }
                        if (waitTime != "")
                        {
                            Thread.Sleep(Convert.ToInt32(waitTime));
                        }
                        if (screenshot.ToLower() == "yes")
                        {
                            SaveScreenshot(PropertiesCollection.driver.Title, functionName, testCaseID);
                        }
                        if (alert.ToLower() == "yes")
                        {
                            IAlert alertmsg = PropertiesCollection.driver.SwitchTo().Alert();
                            alertmsg.Accept();
                            Thread.Sleep(1000);
                        }

                    }
                }
                try
                {
                    Assert.AreEqual(PropertiesCollection.driver.Title, expectedResult);
                    TestResultUtility.AddTestPassToTestResultString(functionName, expectedResult, PropertiesCollection.driver.Title, "Pass");
                    SaveScreenshot(expectedResult, functionName, testCaseID);
                    return true;
                }

                catch
                {
                    Log.ErrorLog("ExecutionMethod_Test_Error");
                    TestResultUtility.AddTestFailToTestResultString(functionName, expectedResult, PropertiesCollection.driver.Title, "Fail");
                    SaveScreenshot("ExecutionMethod_Test_Error", functionName, testCaseID);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorLog(functionName + "-ExecutionMethod Error" + ex.Message);
                return false;
            }

        }
        private static void SaveScreenshot(string title, string functionName, string testcaseid)
        {
            try
            {
                string screenShortPath = AppConfigurationSettings.ScreenShortPath + testcaseid + "_" + functionName;
                ((ITakesScreenshot)PropertiesCollection.driver).GetScreenshot().SaveAsFile(screenShortPath + title + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ".png", ImageFormat.Png);
            }
            catch (Exception ex)
            {

                Log.ErrorLog(functionName + "---SaveScreenshot---" + ex.Message);
            }

        }
        /// <summary>
        /// UpDateTestResult in Html File
        /// </summary>
        public static void UpDateTestResult()
        {
            try
            {
                TestResultUtility.EndTestResultString();
                TestResultUtility.WriteToHtmlFile(TestResultUtility.testResultHtmlString.ToString(), AppConfigurationSettings.ResultPath + "LoginTestResult-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".html");
            }
            catch (Exception ex)
            {

                Log.ErrorLog("UpDateTestResult----" + ex.Message);
            }


        }
        public static void CleanUpTestSuite()
        {
            UpDateTestResult();
            if (PropertiesCollection.driver != null)
            {
                PropertiesCollection.driver.Quit();
            }
        }
        public static void ClearBrowserCache()
        {
            PropertiesCollection.driver.Manage().Cookies.DeleteAllCookies(); //delete all cookies
            Thread.Sleep(2000); //wait 2 seconds to clear cookies.
        }
    }
}
