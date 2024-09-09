using Final_Project.Elements;
using OpenQA.Selenium;

namespace Final_Project.Pages
{
    internal class AccountLoginPage : BasePage
    {
        public static Element CreateAccountEmailField => new Element(By.XPath("//*[@id='email_create']"));
        public static Element EmptyCreateAccountEmailFieldWarning => new Element(By.XPath("//*[@id='create_account_error']"));
        public static Element EmptyCreateAccountEmailFieldWarningText => new Element(By.XPath("//*[@id='create_account_error']/ol/li"));
        public static Element CreateAnAccountButton => new Element(By.XPath("//*[@id='SubmitCreate']"));
        public static Element SignInEmailField => new Element(By.XPath("//*[@id='email']"));
        public static Element SingPasswordField => new Element(By.XPath("//*[@id='passwd']"));
        public static Element SingInButton => new Element(By.XPath("//*[@id='SubmitLogin']"));
        public static Element EmptyEmailOrPasswordWarning => new Element(By.XPath("//*[@id='center_column']/div[1]"));

        public static void Login()
        {
            Assert.That(TitlePage.SingInButton.ElementDispleed(), Is.True);
            TitlePage.SingInButton.Click();

            SignInEmailField.SentValue(login);
            SingPasswordField.SentValue(password);
            SingInButton.Click();
        }
    }
}