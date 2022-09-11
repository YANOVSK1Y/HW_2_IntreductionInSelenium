using HW_2_IntreductionInSelenium.Pages;
using NUnit.Framework;

namespace HW_2_IntreductionInSelenium.Tests
{
    [TestFixture]
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
