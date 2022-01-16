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
            Driver.WaitForElementUpTo(Config.ElementsWaitingTimeout);
        }

        public static void FillLoginForm(string username, string password, string repeatpassword)
        {
            TestScenariosPost testScenariosPost = new TestScenariosPost();

            testScenariosPost.UserName.Clear();
            testScenariosPost.UserName.SendKeys(username);

            testScenariosPost.Password.Clear();
            testScenariosPost.Password.SendKeys(password);

            testScenariosPost.RepeatPassword.Clear();
            testScenariosPost.RepeatPassword.SendKeys(repeatpassword);

            testScenariosPost.LoginButton.Click();
        }
    }
}