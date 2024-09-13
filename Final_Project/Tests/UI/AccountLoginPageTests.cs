using Final_Project.Pages;
using NUnit.Allure.Core;

namespace Final_Project.Tests.UI
{
    [AllureNUnit]
    internal class AccountLoginPageTests : BasePageTest
    {
        [Test]
        public void AccountLogin()
        {
            Assert.That(TitlePage.SingInButton.ElementDispleed(), Is.True);
            TitlePage.SingInButton.Click();
            AccountLoginPage.Login();
            var text = MyAccountPage.PageName.GetText();
            Assert.That(MyAccountPage.PageName.GetText() == "MY ACCOUNT", Is.True);
        }

        [Test]
        public void ErrorOnAccountCreation()
        {
            Assert.That(TitlePage.SingInButton.ElementDispleed(), Is.True);
            TitlePage.SingInButton.Click();

            AccountLoginPage.CreateAccountEmailField.ClearField();
            AccountLoginPage.CreateAnAccountButton.Click();

            AccountLoginPage.EmptyCreateAccountEmailFieldWarning.WaitWebElementPresent();
            AccountLoginPage.EmptyCreateAccountEmailFieldWarningText.WaitWebElementPresent();

            Assert.That(AccountLoginPage.EmptyCreateAccountEmailFieldWarning.ElementDispleed() &&
            AccountLoginPage.EmptyCreateAccountEmailFieldWarningText.GetText().Contains("Invalid email address."), Is.True);
        }

        [Test]
        public void EnteringIncorrectData()
        {
            Assert.That(TitlePage.SingInButton.ElementDispleed(), Is.True);
            TitlePage.SingInButton.Click();

            AccountLoginPage.SignInEmailField.ClearField();
            AccountLoginPage.SingInButton.Click();

            Assert.That(AccountLoginPage.EmptyEmailOrPasswordWarning.ElementDispleed() &&
            AccountLoginPage.EmptyEmailOrPasswordWarning.GetText().Contains("An email address required."), Is.True);

            AccountLoginPage.SignInEmailField.SentValue("oczbus@rover.info");
            AccountLoginPage.SingInButton.Click();

            Assert.That(AccountLoginPage.EmptyEmailOrPasswordWarning.ElementDispleed() &&
            AccountLoginPage.EmptyEmailOrPasswordWarning.GetText().Contains("Password is required."), Is.True);

            AccountLoginPage.SingPasswordField.SentValue("hz3FxAx68pSGn");
            AccountLoginPage.SingInButton.Click();

            Assert.That(AccountLoginPage.EmptyEmailOrPasswordWarning.ElementDispleed() &&
            AccountLoginPage.EmptyEmailOrPasswordWarning.GetText().Contains("Authentication failed."), Is.True);
        }
    }
}