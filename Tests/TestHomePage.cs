using HW_2_IntreductionInSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_IntreductionInSelenium.Tests
{
    public class TestHomePage : BaseTest
    {
        private readonly String BASE_URL = @"https://avic.ua/";
        protected HomePage homePage;
        private IWebDriver _driver; 
        [SetUp]
        public void SetUp()
        {
            _driver = Driver.getInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(BASE_URL);
            homePage = new HomePage(); 
        }

        [Test]
        public void TestHomePageExistance()
        {
            Assert.True(homePage.CheckHomePageExistance());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            Driver.Instance = null; 
        }

    }
}
