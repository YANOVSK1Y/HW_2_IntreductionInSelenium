using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW_2_IntreductionInSelenium.Utils
{
    public class Driver
    {
        public static IWebDriver Instance; 

        public static IWebDriver getInstance()
        {
            if (Instance == null)
            {
                Logger.getLogger().Info("Creating driver"); 
                Instance = new ChromeDriver();
            }
            return Instance; 
        }

    }
}
