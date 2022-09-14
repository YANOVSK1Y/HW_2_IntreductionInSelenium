using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return options; 
        }
        public static FirefoxOptions getFirefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            JObject settings = FileReader.ReadFile(@"Resources/driverSettings.json");
            var driverSettings = JObject.Parse(settings.GetValue("driverSettings").ToString());
            var chromeSettings = JObject.Parse(driverSettings.GetValue("firefox").ToString());

            foreach (var option in chromeSettings.GetValue("startArguments").ToArray())
            {
                options.AddArgument(option.ToString());
            }
            return options;
        }
    }
}
