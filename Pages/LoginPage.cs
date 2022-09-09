using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using HW_2_IntreductionInSelenium.Elements;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace HW_2_IntreductionInSelenium.Pages
{
    public class LoginPage
    {
        private LabelElement labelLogin = new LabelElement(By.XPath("//div[contains(@class, 'sign-holder')]"), "login label");
        private LabelElement inputPhone = new LabelElement(By.XPath("//input[@name='login']"), "input phone field");
        private LabelElement inputPassword = new LabelElement(By.XPath("//input[@name='password']"), "input pass field");
        protected IWebDriver driver;
        public LoginPage()
        {
            Logger.getLogger().Info("Creatingg Login Page instance"); 
            this.driver = Driver.getInstance();
        }
        public Boolean CheckPageExistance() => labelLogin.isExist();

        public Boolean EnterPhone(String phone)
        {
            if (phone.Length != 10) return false;
            inputPhone.sendKeys(phone);
            return true; 
        }
        public Boolean EnterPassword(String password)
        {
            inputPassword.sendKeys(password);
            return true; 
        }
        public String GetPhone(String value) => inputPhone.getAttribute(value); 

        public String GetPassword(String value) => inputPassword.getAttribute(value);
    }
}
