using Aquality.Selenium.Configurations.WebDriverSettings;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Runtime.CompilerServices;

namespace HW_2_IntreductionInSelenium.Utils
{
    public class Driver
    {
        public static IWebDriver Instance;
        private static JObject driverSetting = FileReader.ReadFile(@"Resources/driverSettings.json");
        public static IWebDriver getInstance()
        {
            String browserName = driverSetting.GetValue("browser").ToString();
            if (Instance == null)
            {
                switch (browserName) {
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
}
