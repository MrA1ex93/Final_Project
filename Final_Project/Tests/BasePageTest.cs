using Final_Project.Factory;
using NUnit.Allure.Core;

namespace Final_Project.Tests
{
    [AllureNUnit]
    internal class BasePageTest
    {
        public const string BaseUrl = "http://prestashop.qatestlab.com.ua/ru/";

        [SetUp]
        public void SetUp()
        {
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.TeareDown();
        }
    }
}