 namespace AutoFramework.Pages
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;

    public class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "mh-header-title")]
        public IWebElement Header { get; set; }

        [FindsBy(How = How.ClassName, Using = "mh-header-tagline")]
        public IWebElement SubHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#page-17 > div > p:nth-child(1) > a > img")]
        public IWebElement Image { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#page-17 > header > h1")]
        public IWebElement Headline { get; set; }
    }
}
