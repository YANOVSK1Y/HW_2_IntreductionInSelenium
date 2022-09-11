using AngleSharp.Text;
using HW_2_IntreductionInSelenium.Pages;
using NUnit.Framework;

namespace HW_2_IntreductionInSelenium.Tests
{
    [TestFixture]
    public class TestLoginPage : BaseTest
    {
        private readonly String BASE_URL = @"https://avic.ua/";
        private HomePage homePage;
        private LoginPage loginPage;

        private readonly String _phone = "1234567890";
        private readonly String _password = "password!@#$%12345";

        [SetUp]
        public void SetUp() {
            _driver.Navigate().GoToUrl(BASE_URL);
            homePage = new HomePage();
            homePage.openLoginPage();
            loginPage = new LoginPage();
        }
        [Test]
        public void TestLoginPageEnterValueToFields()
        {
            Logger.getLogger().Info("TestLoginPageEnterValueToFields Test case START");

            Assert.True(loginPage.CheckPageExistance());

            loginPage.EnterPhone(_phone);
            loginPage.EnterPassword(_password);

            Assert.AreEqual(_phone, String.Join("", loginPage.GetPhone("value").Where(s => s.IsDigit()).Select(s=>s).Skip(2).ToArray()), "Phones is not the same");
            Logger.getLogger().Info("Phone is same as sended");

            Assert.AreEqual(_password, loginPage.GetPassword("value"), "Password is not the same");
            Logger.getLogger().Info("Password is same as sended");


            Logger.getLogger().Info("TestLoginPageEnterValueToFields Test case END");
        }
        [TearDown]
        public void TearDown()
        {
        }
    }
}
