using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace HW_2_IntreductionInSelenium.Utils
{
    public class OptionsManager
    {
        public static ChromeOptions getChromeOptions()
        {
            ChromeOptions options = new ChromeOptions(); 
            JObject settings = FileReader.ReadFile(@"Resources/driverSettings.json");
            var driverSettings = JObject.Parse(settings.GetValue("driverSettings").ToString());
            var chromeSettings = JObject.Parse(driverSettings.GetValue("chrome").ToString());

            foreach(var option in chromeSettings.GetValue("startArguments").ToArray())
            {
                options.AddArgument(option.ToString()); 
            }
            switch (chromeSettings.GetValue("pageLoadStrategy").ToString())
            {
                case "normal":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Normal;
                    break;
                case "default":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Default;
                    break;
                case "none":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.None;
                    break;
                case "eager":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Eager;
                    break;
                default:
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Normal;
                    break;
            }
            return options; 
        }
        public static FirefoxOptions getFirefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            JObject settings = FileReader.ReadFile(@"Resources/driverSettings.json");
            var driverSettings = JObject.Parse(settings.GetValue("driverSettings").ToString());
            var firefoxSettings = JObject.Parse(driverSettings.GetValue("firefox").ToString());

            foreach (var option in firefoxSettings.GetValue("startArguments").ToArray())
            {
                options.AddArgument(option.ToString());
            }
            switch (firefoxSettings.GetValue("pageLoadStrategy").ToString())
            {
                case "normal":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Normal;
                    break;
                case "default":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Default;
                    break;
                case "none":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.None;
                    break;
                case "eager":
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Eager;
                    break;
                default:
                    options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Normal;
                    break;
            }
            return options;
        }
    }
}
