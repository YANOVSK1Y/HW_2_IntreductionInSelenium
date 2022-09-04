using Aquality.Selenium.Elements;
using NLog.LayoutRenderers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_2_IntreductionInSelenium.Elements;


namespace HW_2_IntreductionInSelenium.Pages
{
    public class HomePage : BasePage
    {
        private LabelElement homeMainLocator = new LabelElement(By.XPath("//body[contains(@class, 'main-page')]"));
        private ButtonElement loginPageBtn = new ButtonElement(By.XPath("//a//div[contains(@class, 'header-bottom__login')]"));

        protected IWebDriver driver; 
        public HomePage()
        {
            this.driver = Driver.getInstance();
        }
        public Boolean CheckHomePageExistance()
        {
            return homeMainLocator.isExist(); 
        }
        public void openLoginPage() => loginPageBtn.click();
    }
}
