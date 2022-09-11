using OpenQA.Selenium;
using HW_2_IntreductionInSelenium.Elements;

namespace HW_2_IntreductionInSelenium.Pages
{
    public class HomePage
    {
        private LabelElement homeMainLocator = new LabelElement(By.XPath("//body[contains(@class, 'main-page')]"), "main home element");
        private ButtonElement loginPageBtn = new ButtonElement(By.XPath("//a//div[contains(@class, 'header-bottom__login')]"), "login page btn");

        protected IWebDriver driver; 
        public HomePage()
        {
            Logger.getLogger().Info("Creatingg Home Page instance");
            this.driver = Driver.getInstance();
        }
        public Boolean CheckPageExistance()
        {
            return homeMainLocator.isExist(); 
        }
        public void openLoginPage() => loginPageBtn.click();
    }
}
