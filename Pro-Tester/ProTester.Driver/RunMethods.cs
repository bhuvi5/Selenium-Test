using System;
using System.Collections.Generic;

namespace ProTester.Driver
{
    public class RunMethods
    {
        public static Dictionary<string, Func<string, string,  string, string, bool>> methodsNames = new Dictionary<string, Func<string,  string, string, string, bool>>();
        public static Dictionary<string, Func<string, string, string, string, bool>> MethodNames()
        {
            methodsNames.Add("ExecutionMethod", ProTester.TestSuite.SeleniumTestSuite.ExecutionMethod);
            return methodsNames;

        }



    }
}
