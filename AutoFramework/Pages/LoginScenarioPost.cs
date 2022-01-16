namespace AutoFramework.Pages
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;

    class LoginScenariosPost
    {
        public LoginScenariosPost()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.Name, Using = "userid")]
        public IWebElement UserName {get; set;}

        [FindsBy(How = How.Name, Using = "passid")]
        public IWebElement Password {get; set;}

        [FindsBy(How = How.Name, Using = "repeatpassid")]
        public IWebElement RepeatPassword {get; set;}

        [FindsBy(How = How.Name, Using = "submit")]
        public IWebElement LoginButton {get; set;}

    }
}