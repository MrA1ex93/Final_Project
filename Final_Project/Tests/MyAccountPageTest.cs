using Final_Project.Pages;
using NUnit.Allure.Core;

namespace Final_Project.Tests
{
    [AllureNUnit]
    internal class MyAccountPageTest : BasePageTest
    {
        [Test]
        public void CheckOrderHistory()
        {
            AccountLoginPage.Login();
            Assert.That(MyAccountPage.OrderHistoryAndDetailsButton.ElementDispleed(), Is.True);
            MyAccountPage.OrderHistoryAndDetailsButton.Click();

            Assert.That(OrderHistoryPage.AlertWarning.ElementDispleed(), Is.True);
        }

        [Test]
        public void CheckMyCreditSheetsButton()
        {
            AccountLoginPage.Login();
            Assert.That(MyAccountPage.MyCreditSlips.ElementDispleed(), Is.True);
            MyAccountPage.MyCreditSlips.Click();

            Assert.That(OrderHistoryPage.AlertWarning.ElementDispleed(), Is.True);
        }

        [Test]
        public void CheckTheMyAddressesButton()
        {
            AccountLoginPage.Login();
            Assert.That(MyAccountPage.MyAddresses.ElementDispleed(), Is.True);
            MyAccountPage.MyAddresses.Click();

            Assert.That(MyAddressesPage.PageName.ElementDispleed(), Is.True);
        }

        [Test]
        public void CheckingTheHomeButton()
        {
            AccountLoginPage.Login();
            Assert.That(MyAccountPage.HomeButton.ElementDispleed(), Is.True);
            MyAccountPage.HomeButton.Click();

            Assert.That(HomePage.SliderRow.ElementDispleed(), Is.True);
        }
    }
}