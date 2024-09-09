using Final_Project.Elements;
using Final_Project.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Final_Project.Pages
{
    internal class BasePage
    {
        private static WebDriverWait wait => Driver.WaitDriver(Driver.GetDriver(), 30);

        public const string login = "oczbus@rover.info";
        public const string password = "hz3FxAx6R8pSGn";

        public const string firstName = "Mr";
        public const string lastName = "Alex";

        public const string Company = "";
        public const string Address = "45 BROADWAY STE 530";
        public const string AddressLineTwo = "NEW YORK, NY 10006-4012, USA";
        public const string ZipPostalCode = "10292";
        public const string City = "New York";
        public const string Country = "США";
        public const string HomePhone = "(212) 652-5858";
        public const string MobilePhone = "+1-888-452-1505";
        public const string State = "New York";
        public const string AdditionalInformation = "Secret";
        public const string AliasAddress = "Work address";

        public static bool CheckExpectedText(Element field, string text)
        {
            if (field.GetValue() != text)
            {
                return false;
            }
            return true;
        }

        public static bool ClickClearEnterVerify(Element element, string text)
        {
            element.ClearField();
            element.SentValue($"{text}");
            var elementForDebug = element.GetValue();
            if (elementForDebug == null || elementForDebug.Length == 0 || elementForDebug != text)
            {
                return false;
            }
            return true;
        }

        public static bool WorkWithInput(Element element)
        {
            element.Click();
            var debugDot = element.IsInputFocused();
            return true;
        }

        public static void FillAndVerifyField(Element element, string textForComparison)
        {
            Assert.That(element.ElementDispleed(), Is.True);
            Assert.That(ClickClearEnterVerify(element, textForComparison), Is.True);
        }

        public static bool SelectDropdownOptionByText(Element dropdownElement, string optionText)
        {
            dropdownElement.Click();
            var options = dropdownElement.FindChildElements();
            foreach (var option in options)
            {
                if (option.Text.Trim() == optionText.Trim())
                {
                    option.Click();
                    return true;
                }
            }
            return false;
        }

        public static Actions ActionClassReturn()
        {
            Actions actions = new Actions(Driver.GetDriver());
            return actions;
        }

        public static string GetBaseUrl(IWebElement webElement)
        {
            var baseProductLink = new Uri(webElement.GetAttribute("href")).GetLeftPart(UriPartial.Path);
            return baseProductLink;
        }
        public static string WaitForLanguageUrlUpdate(string languages)
        {
            wait.Until(driver => driver.Url.Contains($"{languages}"));
            return Driver.GetDriver().Url;
        }
        public static string CurrentUrlSite()
        {
            return Driver.GetDriver().Url;
        }
        public static string ExtractColorAndSize(string text)
        {
            string[] parts = text.Split(new[] { "Color :", "Size :" }, StringSplitOptions.None);
                        
            string color = parts[1].Split(',')[0].Trim();
            string size = parts[2].Trim();
            
            string result = $"{color}, {size}";
            return result;
        }

        public static bool WaitForElementElementExists(IWebElement webElement)
        {
            return Driver.WaitDriver(Driver.GetDriver(), 20).Until(q => webElement.Displayed);
        }
        public static bool WaitForElementToUpdate(string text, Element element)
        {
            return wait.Until(driver =>
            {
                var actualCurrencyText = element.GetAttribute("title");
                return actualCurrencyText.Contains(text);
            });
        }
        public static void AlertAccept()
        {
            Driver.GetDriver().SwitchTo().Alert().Accept();
        }
    }
}