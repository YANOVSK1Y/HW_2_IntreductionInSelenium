using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using HW_2_IntreductionInSelenium.Utils;
using SeleniumExtras.WaitHelpers; 

namespace HW_2_IntreductionInSelenium.Elements
{
    public class BaseElement
    {
        private By locator; 
        public BaseElement(By locator)
        {
            this.locator = locator; 
        }
        public Boolean isExist()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementExists(locator));
                return true;
            }
            catch (Exception e)
            {
                return false; 
            }
        }

        public Boolean isClickable()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Boolean isVisible()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void click()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementIsVisible(locator)).Click();
            }
            catch (Exception e)
            {
            }
        }
        public String getText()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;
            }
            catch (Exception e)
            {
                return null; 
            }
        }
        public void sendKeys(String item)
        {
            WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(locator)).SendKeys(item); 
        }
        public String getAttribute(String value)
        {
            WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementExists(locator)).GetAttribute(value); 
        }
    }
}
