using Aquality.Selenium.Configurations.WebDriverSettings;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Remote;

namespace HW_2_IntreductionInSelenium.Utils
{
    public class Driver
    {
        public static IWebDriver localDriver;
        public static RemoteWebDriver remoteDriver; 
        private static JObject driverSetting = FileReader.ReadFile(@"Resources/driverSettings.json");
        public static IWebDriver getInstance()
        {
            String browserName = driverSetting.GetValue("browser").ToString();

            if (driverSetting.GetValue("remote").ToString() == "True")
            {
                if (remoteDriver == null)
                {
                    switch (browserName)
                    {
                        case "chrome":
                            Logger.getLogger().Info("Creating remote chrome driver");
                            remoteDriver = new RemoteWebDriver(new Uri("http://localhost:4444/"), OptionsManager.getChromeOptions().ToCapabilities(), TimeSpan.FromSeconds(600));
                            return remoteDriver; 
                        case "firefox":
                            Logger.getLogger().Info("Creating remote firefox driver");
                            remoteDriver = new RemoteWebDriver(new Uri("http://localhost:4444/"), OptionsManager.getFirefoxOptions().ToCapabilities(), TimeSpan.FromSeconds(600));
                            return remoteDriver;
                    }
                }
                return remoteDriver;
            }
            else
            {
                if (localDriver == null)
                {
                    switch (browserName)
                    {
                        case "chrome":
                            localDriver = new ChromeDriver(OptionsManager.getChromeOptions());
                            Logger.getLogger().Info("Creating chrome driver");
                            return localDriver;
                        case "firefox":
                            localDriver = new FirefoxDriver(OptionsManager.getFirefoxOptions());
                            Logger.getLogger().Info("Creating firefox driver");
                            return localDriver;
                        default:
                            localDriver = new ChromeDriver(OptionsManager.getChromeOptions());
                            Logger.getLogger().Info("Creating chrome driver by default");
                            return localDriver;
                    }
                }
                return localDriver;
            }
        }

        public static void Destroy()
        {
            if (remoteDriver != null)
            {
                remoteDriver.Close();
                remoteDriver.Quit();
                remoteDriver = null;

                Logger.getLogger().Info("Destroy remote driver.");
            }
            if (localDriver != null)
            {
                localDriver.Close();
                localDriver.Quit();
                localDriver = null;

                Logger.getLogger().Info("Destroy local driver.");
            }
            
        }

    }
}
