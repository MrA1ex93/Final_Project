﻿using Final_Project.Elements;
using OpenQA.Selenium;

namespace Final_Project.Pages
{
    internal class MyAccountPage : BasePage
    {
        public static Element AlertSuccess => new Element(By.XPath("//*[@id='center_column']/p[1]"));
        public static Element PageName => new Element(By.XPath("//*[@class='page-heading']"));
        public static Element AddMyFirstAddressButton => new Element(By.XPath("//*[@title='Add my first address']"));
        public static Element OrderHistoryAndDetailsButton => new Element(By.XPath("//a[@title='Orders']"));
        public static Element MyCreditSlips => new Element(By.XPath("//a[@title='Credit slips']"));
        public static Element MyAddresses => new Element(By.XPath("//a[@title='Addresses']"));
        public static Element MyPersonalInformation => new Element(By.XPath("//a[@title='Information']"));
        public static Element HomeButton => new Element(By.XPath("//ul[@class='footer_links clearfix']/li/a"));
    }
}