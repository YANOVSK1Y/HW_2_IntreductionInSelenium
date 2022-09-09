using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using HW_2_IntreductionInSelenium.Utils;
using SeleniumExtras.WaitHelpers;
using AngleSharp.Css;

namespace HW_2_IntreductionInSelenium.Elements
{
    public abstract class BaseElement
    {
        private By locator;
        private String elementName; 
        public BaseElement(By locator, String elementName)
        {
            this.locator = locator;
            this.elementName = elementName; 
        }
        public Boolean isExist()
        {
            try
            {
                Logger.getLogger().Info($"Check element  existance");
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
                Logger.getLogger().Info($"Check element ->'{elementName}' is clickable");
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
                Logger.getLogger().Info($"Check element ->'{elementName}' visability of element");
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
                Logger.getLogger().Info($"Click on element ->'{elementName}'");
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
                Logger.getLogger().Info($"Get text from element ->'{elementName}'");
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
            Logger.getLogger().Info($"Send keys to element ->'{elementName}'");
            WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(locator)).SendKeys(item);
        }
        public String getAttribute(String value)
        {
            Logger.getLogger().Info($"Get element ->'{elementName}' attribute");
            WebDriverWait wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementExists(locator)).GetAttribute(value); 
        }
    }
}
