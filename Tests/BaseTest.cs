using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using HW_2_IntreductionInSelenium.Utils;
using OpenQA.Selenium.DevTools.V102.DOM;

namespace HW_2_IntreductionInSelenium.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver _driver; 
        [SetUp]
        public void OneTimeSetUp() 
        {
            _driver = Driver.getInstance();
            _driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
            Driver.Instance = null;
            Logger.getLogger().Info("Close driver."); 
        }
    }
}
