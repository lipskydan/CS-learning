namespace AutoFramework 
{
    using OpenQA.Selenium.Chrome;
    using AutoFramework.Pages;

    public static class Actions
    {
        public static void InitializeDriver()
        {
            Driver.driver = new ChromeDriver();
            Driver.driver.Navigate().GoToUrl(Config.BaseURL); 
        }

        public static void FillLoginForm(string username, string password, string repeatpassword)
        {
            TestScenariosPost testScenariosPost = new TestScenariosPost();

            testScenariosPost.UserName.SendKeys(username);
            testScenariosPost.Password.SendKeys(password);
            testScenariosPost.RepeatPassword.SendKeys(repeatpassword);

            testScenariosPost.LoginButton.Click();
        }
    }
}