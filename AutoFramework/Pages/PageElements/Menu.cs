 namespace AutoFramework.Pages
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;

    public class Menu
    {
        public Menu()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "menu-item-58")]
        public IWebElement TestScenerios { get; set; }

        
    }
}
