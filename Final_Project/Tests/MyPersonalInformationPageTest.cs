using Final_Project.Pages;
using NUnit.Allure.Core;

namespace Final_Project.Tests
{
    [AllureNUnit]
    internal class MyPersonalInformationPageTest : BasePageTest
    {
        [Test]        
        public void AccountRegistration()
        {
            TitlePage.SingInButton.Click();

            var email = MyPersonalInformationPage.Email();

            Assert.That(AccountLoginPage.CreateAccountEmailField.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(AccountLoginPage.CreateAccountEmailField, email), Is.True);
            Assert.That(AccountLoginPage.CreateAnAccountButton.ElementDispleed(), Is.True);
            AccountLoginPage.CreateAnAccountButton.Click();

            MyPersonalInformationPage.RadioGender1.Click();
            Assert.That(BasePage.WorkWithInput(MyPersonalInformationPage.RadioGender1), Is.True);

            Assert.That(MyPersonalInformationPage.FirstNameFieldForRegistration.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(MyPersonalInformationPage.FirstNameFieldForRegistration, BasePage.firstName), Is.True);

            Assert.That(MyPersonalInformationPage.LastNameFieldRegistration.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(MyPersonalInformationPage.LastNameFieldRegistration, BasePage.lastName), Is.True);

            Assert.That(MyPersonalInformationPage.DetailsEmailField.ElementDispleed(), Is.True);
            Assert.That(BasePage.CheckExpectedText(MyPersonalInformationPage.DetailsEmailField, email), Is.True);

            Assert.That(MyPersonalInformationPage.PasswordFieldForCreateAccount.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(MyPersonalInformationPage.PasswordFieldForCreateAccount, BasePage.password), Is.True);

            Assert.That(MyPersonalInformationPage.WorkWithDateOfBirth(), Is.True);
            MyPersonalInformationPage.EndCreateAnAccountButton.Click();

            Assert.That(MyAccountPage.AlertSuccess.ElementDispleed(), Is.True);

            Assert.That(MyAccountPage.AlertSuccess.GetText() == "Your account has been created.", Is.True);
        }

        [Test]
        public void ButtonForSavingPersonalInformation()
        {
            AccountLoginPage.Login();
            Assert.That(MyAccountPage.MyPersonalInformation.ElementDispleed(), Is.True);
            MyAccountPage.MyPersonalInformation.Click();
            Assert.That(MyPersonalInformationPage.PageName.ElementDispleed(), Is.True);
            Assert.That(MyPersonalInformationPage.UpdatetAndSaveButtonYourPersonalInformation.ElementDispleed(), Is.True);
            Assert.That(MyPersonalInformationPage.UpdatetAndSaveButtonYourPersonalInformation.Clickable(), Is.True);
            MyPersonalInformationPage.UpdatetAndSaveButtonYourPersonalInformation.Click();
            Assert.That(MyPersonalInformationPage.PageName.ElementEnabled(), Is.True);
        }
    }
}