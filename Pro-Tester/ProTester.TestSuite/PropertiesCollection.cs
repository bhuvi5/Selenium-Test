using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProTester.TestSuite
{
    enum PropertyType
    {
        Id,
        Name,
        CssSelector,
        ClassName,
        LinkText,
        Xpath
    }
    enum ControllerType
    {
        Text,
        Button,
        SelectiveDropdown,
        Dropdown,
        Map,
        Search,
        Frame,
        InsideFrame

    }

    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
    }
}
