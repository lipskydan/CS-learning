 namespace AutoFramework 
{
    using OpenQA.Selenium;
    using NUnit.Framework;
    using Pages;

    public class VerifyHomePageElements
    {
        public IWebDriver Driver {get; set;}
        public VerifyHomePageElements(){}

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = Actions.InitializeDriver();
        }

        [TestCase]
        public void VerifyHeaderText()
        {
           HomePage homePage = new HomePage(Driver);
           Assert.AreEqual(expected:homePage.Header.Text, actual:Config.HomePage.HeaderText);
        }

        [TestCase]
        public void VerifySubHeaderText()
        {
           HomePage homePage = new HomePage(Driver);
           Assert.AreEqual(expected:homePage.SubHeader.Text, actual:Config.HomePage.SubHeaderText);
        }

        [TestCase]
        public void VerifyHeadlineText()
        {
           HomePage homePage = new HomePage(Driver);
           Assert.AreEqual(expected:homePage.Headline.Text, actual:Config.HomePage.HeadlineText);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}