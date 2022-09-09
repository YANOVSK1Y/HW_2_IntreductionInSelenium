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
        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(BASE_URL);
            homePage = new HomePage(); 
        }

        [Test]
        public void TestHomePageExistance()
        {
            Logger.getLogger().Info("TestHomePageExistance Test case START");

            Assert.True(homePage.CheckPageExistance());

            Logger.getLogger().Info("TestHomePageExistance Test case END");
        }

        [TearDown]
        public void TearDown()
        {
        }

    }
}
