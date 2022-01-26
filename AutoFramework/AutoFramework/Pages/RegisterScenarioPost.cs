namespace AutoFramework.Pages
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using System.Collections.Generic;

    class RegisterScenariosPost
    {
        public RegisterScenariosPost(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            CountriesList = GetDropDownMenuCountries(whatSearch: "#post-70 > div > form > ul > li:nth-child(10) > select > option:nth-child", driver);
        }

        [FindsBy(How = How.Name, Using = "userid")]
        public IWebElement UserId {get; set;}

        [FindsBy(How = How.Name, Using = "passid")]
        public IWebElement Password {get; set;}

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement Name {get; set;}

        [FindsBy(How = How.Name, Using = "address")]
        public IWebElement Address {get; set;}

        public List<IWebElement> CountriesList {get; set;}

        [FindsBy(How = How.Name, Using = "zip")]
        public IWebElement ZipCode {get; set;}

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Email {get; set;}

        [FindsBy(How = How.CssSelector, Using = "#post-70 > div > form > ul > li:nth-child(16) > input[type=radio]")]
        public IWebElement SexMale {get; set;}

        [FindsBy(How = How.CssSelector, Using = "#post-70 > div > form > ul > li:nth-child(17) > input[type=radio]")]
        public IWebElement SexFemale {get; set;}

        [FindsBy(How = How.Name, Using = "languageQuestion")]
        public IWebElement SpeakEnglish {get; set;}

        [FindsBy(How = How.Name, Using = "submit")]
        public IWebElement RegisterButton { get; set; }

        private static List<IWebElement> GetDropDownMenuCountries(string whatSearch, IWebDriver driver)
        {
            List<IWebElement> list = new List<IWebElement>();
            IWebElement webElement = null;
            int i=2;
            while(i<=6)
            {
                webElement = driver.FindElement(By.CssSelector(whatSearch + "(" + i + ")"));
                i+=1;
                list.Add(webElement);
            }
            return list;
        }

        public static IWebElement GetCountry(string value, List<IWebElement> CountriesList)
        {
            foreach (var item in CountriesList)
            {
                if(item.GetAttribute("value") == value)
                {
                    return item;
                }
            }
            return null;
        }

    }
}