using System.Configuration;
using System.IO;

namespace ProTester.Utilities
{
    public class AppConfigurationSettings
    {
        private static string applicationPath = ConfigurationSettings.AppSettings["applicationPath"];
        private static string runConfigPath = ConfigurationSettings.AppSettings["RunConfigPath"];
        private static string resultPath = ConfigurationSettings.AppSettings["ResultPath"];
        private static string screenShortPath = ConfigurationSettings.AppSettings["Screenshot"];
        private static string logPath = ConfigurationSettings.AppSettings["logPath"];
        private static string controlDetails = ConfigurationSettings.AppSettings["ControlDetails"];


        public static string ApplicationPath
        {
            get
            {
                return applicationPath;
            }

            set
            {
                applicationPath = value;
            }
        }

        public static string RunConfigPath
        {
            get
            {
                return runConfigPath;
            }

            set
            {
                runConfigPath = value;
            }
        }

        public static string ResultPath
        {
            get
            {
                return CreateDirectory(resultPath);
            }

            set
            {
                resultPath = value;
            }
        }

        public static string ScreenShortPath
        {
            get
            {
                return CreateDirectory(screenShortPath);
            }

            set
            {
                screenShortPath = value;
            }
        }

        public static string LogPath
        {
            get
            {
                return CreateDirectory(logPath);
            }

            set
            {
                logPath = value;
            }
        }

        public static string ControlDetails
        {
            get
            {
                return controlDetails;
            }

            set
            {
                controlDetails = value;
            }
        }

        public static string CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}
