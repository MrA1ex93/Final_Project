using Final_Project.Pages;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace Final_Project.Tests.UI
{
    [AllureNUnit]
    internal class ShoppingCartShoppingPageTest : BasePageTest
    {
        [Test]
        public void LayerCartVisible()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();

            ShoppingCartShoppingPage.LayerCart.WaitForElementElementExists();
            ShoppingCartShoppingPage.LayerCart.WaitForElementVisible();

            var a = ShoppingCartShoppingPage.LayerCart.ElementDispleed();
            Assert.That(ShoppingCartShoppingPage.LayerCart.ElementDispleed(), Is.True);
        }

        [Test]
        public void ContinueShoppingButton()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();

            ShoppingCartShoppingPage.LayerCart.WaitForElementElementExists();
            ShoppingCartShoppingPage.LayerCart.WaitForElementVisible();

            Assert.That(ShoppingCartShoppingPage.ContinueShoppingButton.ElementDispleed(), Is.True);

            ShoppingCartShoppingPage.ContinueShoppingButton.Click();
            Thread.Sleep(500);
            Assert.That(ShoppingCartShoppingPage.LayerCart.ElementDispleed(), Is.False);
        }

        [Test]
        public void ProceedToChekoutButton()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();
            ShoppingCartShoppingPage.LayerCart.WaitForElementVisible();
            Assert.That(ShoppingCartShoppingPage.ProceedToChekoutButton.ElementDispleed(), Is.True);
            ShoppingCartShoppingPage.ProceedToChekoutButton.Click();

            Assert.That(CartPage.CartTitle.ElementDispleed(), Is.True);
        }

        [Test]
        public void CheckCartInformation()
        {
            Assert.That(HomePage.AddHomePageProductToCartAndVerifyDetails(0) != null, Is.True);
        }
    }
}