using Final_Project.Pages;
using NUnit.Allure.Core;
using RestSharp;
using System.Net;

namespace Final_Project.Tests.UI
{
    [AllureNUnit]
    internal class TitlePageTest : BasePageTest
    {
        [Test]        
        public void CheckingTheWomanMenu()
        {
            TitlePage.VerifySubMenu(TitlePage.WOMENButton, TitlePage.SubMenuWOMENButton);
        }

        [Test]
        public void VerifyMenuDresses()
        {
            TitlePage.VerifySubMenu(TitlePage.DRESSESButton, TitlePage.SubMenuDRESSESButton);
        }

        [Test]
        public void CheckingTheWomenNavigationButtons()
        {
            string correctUrlWOMENButton = "http://prestashop.qatestlab.com.ua/en/3-women";
            string correctUrlDRESSESButton = "http://prestashop.qatestlab.com.ua/en/8-dresses";
            string correctUrlTSHIRTSButton = "http://prestashop.qatestlab.com.ua/en/5-tshirts";
            string correctUrlTOPSSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/4-tops";
            string correctUrlBlousesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/7-blouses";
            string correctUrlSweatersSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/12-sweaters";
            string correctUrlCasualDressesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/9-casual-dresses";
            string correctUrlEveningDressesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/10-evening-dresses";
            string correctUrlSummerDressesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/11-summer-dresses";
            string correctUrlJacketSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/14-jackets";
            string correctUrlSuitsSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/17-suits";
            string correctUrlShoesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/15-shoes";
            string correctUrlBagsSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/16-bags";

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.WOMENButton, correctUrlWOMENButton));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.DRESSESButton, correctUrlDRESSESButton));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.TSHIRTSButton, correctUrlTSHIRTSButton));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.TOPSSubMenuWOMEN, correctUrlTOPSSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.BlousesSubMenuWOMEN, correctUrlBlousesSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.SweatersSubMenuWOMEN, correctUrlSweatersSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.CasualDressesSubMenuWOMEN, correctUrlCasualDressesSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.EveningDressesSubMenuWOMEN, correctUrlEveningDressesSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.SummerDressesSubMenuWOMEN, correctUrlSummerDressesSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.JacketSubMenuWOMEN, correctUrlJacketSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.SuitsSubMenuWOMEN, correctUrlSuitsSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.ShoesSubMenuWOMEN, correctUrlShoesSubMenuWOMEN));

            TitlePage.ScrollToElement(TitlePage.WOMENButton);
            Assert.That(TitlePage.CheckElementUrl(TitlePage.BagsSubMenuWOMEN, correctUrlBagsSubMenuWOMEN));
        }

        [Test]
        public void CheckLanguage()
        {
            TitlePage.LanguagesChange("//*[@id='languages-block-top']/ul/li[1]/a", "/ru/");
            TitlePage.LanguagesChange("//*[@id='languages-block-top']/ul/li[2]/a", "/uk/");
            TitlePage.LanguagesChange("//*[@id='languages-block-top']/ul/li[3]/a", "/en/");
        }

        [Test]
        public void CheckChange()
        {
            TitlePage.CurrencyChange(TitlePage.EUR, "Евро");
            TitlePage.CurrencyChange(TitlePage.USD, "Доллар");
            TitlePage.CurrencyChange(TitlePage.UAH, "Гривна");
        }

        [Test]
        public void CheckingTheSearchField()
        {
            var client = new RestClient(BaseUrl);

            var request = new RestRequest("search", Method.Get);
            request.AddParameter("a", "Printed Dress");
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CheckingALongQuery()
        {
            var client = new RestClient(BaseUrl);

            var request = new RestRequest("search", Method.Get);
            string longQuery = new string('a', 50000);
            request.AddParameter("q", $"{longQuery}");

            var response = client.Execute(request);
            var statcod = response.StatusCode;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.RequestUriTooLong));
        }

        [Test]
        public void InvalidPageNumberReturns302Fail()
        {
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            using var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl)
            };

            var client = new RestClient(httpClient);

            var request = new RestRequest("search", Method.Get);
            request.AddParameter("search_query", "Dress");
            request.AddParameter("p", -1);

            var response = client.Execute(request);

            var statCode = response.StatusCode;

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Redirect));
        }
    }
}