using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

namespace ProTester.TestSuite
{
    class SeleniumMethods
    {
        //Set Values
        //Enter Text
        public static void EnterText(string element, string value, string elementtype)
        {
            if (elementtype == PropertyType.Id.ToString())
                PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementtype == PropertyType.Name.ToString())
                PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
            if (elementtype == PropertyType.Xpath.ToString())
                PropertiesCollection.driver.FindElement(By.XPath(element)).SendKeys(value);
            if (elementtype == PropertyType.CssSelector.ToString())
                PropertiesCollection.driver.FindElement(By.CssSelector(element)).SendKeys(value);
        }

        //Click into a button, Checkbox, option etc
        public static void Click(string element, string elementtype)
        {
            if (elementtype == PropertyType.Id.ToString())
                PropertiesCollection.driver.FindElement(By.Id(element)).Click();
            if (elementtype == PropertyType.Name.ToString())
                PropertiesCollection.driver.FindElement(By.Name(element)).Click();
            if (elementtype == PropertyType.CssSelector.ToString())
                PropertiesCollection.driver.FindElement(By.CssSelector(element)).Click();
            if (elementtype == PropertyType.Xpath.ToString())
                PropertiesCollection.driver.FindElement(By.XPath(element)).Click();
            if (elementtype == PropertyType.LinkText.ToString())
                PropertiesCollection.driver.FindElement(By.LinkText(element)).Click();
        }


        //Click into a button, Checkbox, option etc
        public static void SelectiveDropDownClick(string value)
        {
            IWebElement element = PropertiesCollection.driver.FindElement(By.CssSelector("div.selectivity-results-container"));
            IWebElement findEntity = PropertiesCollection.driver.FindElement(By.CssSelector("input.selectivity-search-input"));
            findEntity.SendKeys(value);
            System.Threading.Thread.Sleep(2000);
            IWebElement selectValue = findEntity.FindElement(By.XPath("//div[text()='" + value + "']"));
            selectValue.Click();
        }

        //Click into a button, Checkbox, option etc
        public static void Submit(string element, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                PropertiesCollection.driver.FindElement(By.Id(element)).Submit();
            if (elementtype == PropertyType.Name)
                PropertiesCollection.driver.FindElement(By.Name(element)).Submit();
            if (elementtype == PropertyType.CssSelector)
                PropertiesCollection.driver.FindElement(By.CssSelector(element)).Submit();
            if (elementtype == PropertyType.Xpath)
                PropertiesCollection.driver.FindElement(By.XPath(element)).Submit();
            if (elementtype == PropertyType.LinkText)
                PropertiesCollection.driver.FindElement(By.LinkText(element)).Submit();
        }
        //Selecting a drop down control
        public static void SelectDropDown(string element, string value, string elementtype)
        {
            if (elementtype == PropertyType.Id.ToString())
                new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementtype == PropertyType.Name.ToString())
                new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
            if (elementtype == PropertyType.Xpath.ToString())
                new SelectElement(PropertiesCollection.driver.FindElement(By.XPath(element))).SelectByText(value);
            if (elementtype == PropertyType.CssSelector.ToString())
                new SelectElement(PropertiesCollection.driver.FindElement(By.CssSelector(element))).SelectByText(value);
        }

        public static IWebElement FraneElement(string element, string elementtype)
        {
            if (elementtype == PropertyType.Id.ToString())
                return PropertiesCollection.driver.FindElement(By.Id(element));
            if (elementtype == PropertyType.Xpath.ToString())
                return PropertiesCollection.driver.FindElement(By.XPath(element));
            else return null;
        }

        //Get Values
        public static string GetText(string element, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            if (elementtype == PropertyType.Name)
                return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
            else return String.Empty;

        }

        public static string GetTextFromDDL(string element, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            if (elementtype == PropertyType.Name)
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            else return String.Empty;
        }

        public static bool VerifyDropdownValue(string dropdownID, string value)
        {
            try
            {
                SelectElement ss = new SelectElement(PropertiesCollection.driver.FindElement(By.Id(dropdownID)));

                Console.WriteLine(ss.Options);
                foreach (IWebElement element in ss.Options)
                {
                    if (element.Text.ToLower() == value.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (NoSuchElementException ex)
            {
                ProTester.Utilities.Log.ErrorLog(ex.Message);
                return false;
            }
        }

        public static void ProductMapping(string elementValue)
        {
            try
            {
                IList<IWebElement> element = PropertiesCollection.driver.FindElements(By.Name(elementValue));
                foreach (IWebElement checkbox in element)
                {
                    if (checkbox.Selected == false)
                    {
                        checkbox.Click();
                    }
                }
            }
            catch (Exception ex)
            {
                ProTester.Utilities.Log.ErrorLog(ex.Message);
            }

        }
    }
}
