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
        public static IWebDriver Instance;
        public static RemoteWebDriver driver; 
        private static JObject driverSetting = FileReader.ReadFile(@"Resources/driverSettings.json");
        public static IWebDriver getInstance()
        {
            String browserName = driverSetting.GetValue("browser").ToString();

            if (driverSetting.GetValue("remote").ToString() == "True")
            {
                if (driver == null)
                {
                    switch (browserName)
                    {
                        case "chrome":
                            Logger.getLogger().Info("Creating remote chrome driver");
                            driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), OptionsManager.getChromeOptions().ToCapabilities(), TimeSpan.FromSeconds(600));
                            return driver; 
                        case "firefox":
                            Logger.getLogger().Info("Creating remote firefox driver");
                            driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), OptionsManager.getFirefoxOptions().ToCapabilities(), TimeSpan.FromSeconds(600));
                            return driver;
                    }
                }
                return driver;
            }
            else
            {
                if (Instance == null)
                {
                    switch (browserName)
                    {
                        case "chrome":
                            Instance = new ChromeDriver();
                            Logger.getLogger().Info("Creating chrome driver");
                            return Instance;
                        case "firefox":
                            Instance = new FirefoxDriver();
                            Logger.getLogger().Info("Creating firefox driver");
                            return Instance;
                        default:
                            Instance = new ChromeDriver();
                            Logger.getLogger().Info("Creating chrome driver by default");
                            return Instance;
                    }
                }
                return Instance;
            }
        }

        public static void Destroy()
        {
            driver.Close();
            driver.Quit(); 
            driver = null; 
        }

    }
}
