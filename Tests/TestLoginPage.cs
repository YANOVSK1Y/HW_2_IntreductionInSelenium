using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Text;
using HW_2_IntreductionInSelenium.Pages;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HW_2_IntreductionInSelenium.Tests
{
    public class TestLoginPage : BaseTest
    {
        private readonly String BASE_URL = @"https://avic.ua/";
        private IWebDriver _driver;
        private HomePage homePage;
        private LoginPage loginPage;

        private readonly String _phone = "1234567890";
        private readonly String _password = "password!@#$%12345";

        [SetUp]
        public void SetUp() {
            _driver = Driver.getInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(BASE_URL);
            homePage = new HomePage();
            homePage.openLoginPage();
            loginPage = new LoginPage();
        }
        [Test]
        public void TestLoginPageEnterValueToField()
        {
            Assert.True(loginPage.CheckLoginPageExistance());

            loginPage.EnterPhone(_phone);
            loginPage.EnterPassword(_password);

            Assert.AreEqual(_phone, String.Join("", loginPage.GetPhone("value").Where(s => s.IsDigit()).Select(s=>s).Skip(2).ToArray()), "Phones is not the same"); ;
            Assert.AreEqual(_password, loginPage.GetPassword("value"), "Password is not the same");
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            Driver.Instance = null;
        }
    }
}
