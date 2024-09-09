using Final_Project.Elements;
using OpenQA.Selenium;

namespace Final_Project.Pages
{
    internal class MyAddressesPage : BasePage
    {
        public static Element PageName => new Element(By.XPath("//*[@id='center_column']/h1"));
        public static Element UpdateButton => new Element(By.XPath("//*[@class='address_update']/a[1]"));
        public static Element DeleteButton => new Element(By.XPath("//*[@class='address_update']/a[2]"));
        public static Element InformationBox => new Element(By.XPath("//*[@class='last_item item box']"));
        public static Element AddANewAddress => new Element(By.XPath("//*[@id='center_column']/div/a"));
    }
}