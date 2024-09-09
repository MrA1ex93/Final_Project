using Final_Project.Pages;
using NUnit.Allure.Core;

namespace Final_Project.Tests
{
    [AllureNUnit]
    internal class CartPageTest : BasePageTest
    {
        [Test]
        public void GoToCart()
        {
            Assert.That(TitlePage.Cart.ElementDispleed(), Is.True);
            TitlePage.Cart.Click();
            Assert.That(CartPage.CartTitle.GetText() == "SHOPPING-CART SUMMARY", Is.True);
        }        

        [Test]
        public void DeleteFromCart()
        {
            HomePage.AddHomePageProductToCartAndVerifyDetails(0);
            CartPage.RemoveFirstProductFromCart.Click();
            CartPage.ProceedToCheckoutInSummary.Click();
            Assert.That(CartPage.EmptyCatTitle.ElementEnabled(), Is.True);
        }
    }
}