namespace AutoFramework 
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using AutoFramework.Pages;

    public static class Actions
    {
        public static IWebDriver InitializeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Config.BaseURL);
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            return driver;
        }

        public static void FillLoginForm(string username, string password, string repeatpassword, IWebDriver driver)
        {
            LoginScenariosPost testScenariosPost = new LoginScenariosPost(driver);

            testScenariosPost.UserName.Clear();
            testScenariosPost.UserName.SendKeys(username);

            testScenariosPost.Password.Clear();
            testScenariosPost.Password.SendKeys(password);

            testScenariosPost.RepeatPassword.Clear();
            testScenariosPost.RepeatPassword.SendKeys(repeatpassword);

            testScenariosPost.LoginButton.Click();
        }

        public static void FillRegisterForm(string userid, string password, string name, string address, string country, string zipCode, string email, string sex, bool speakEnglish, IWebDriver driver)
        {
            RegisterScenariosPost registerScenariosPost = new RegisterScenariosPost(driver);

            registerScenariosPost.UserId.Clear();
            registerScenariosPost.UserId.SendKeys(userid);

            registerScenariosPost.Password.Clear();
            registerScenariosPost.Password.SendKeys(password);

            registerScenariosPost.Name.Clear();
            registerScenariosPost.Name.SendKeys(name);

            registerScenariosPost.Address.Clear();
            registerScenariosPost.Address.SendKeys(address);
            
            RegisterScenariosPost.GetCountry(value: country, registerScenariosPost.CountriesList).Click();

            registerScenariosPost.ZipCode.Clear();
            registerScenariosPost.ZipCode.SendKeys(zipCode);

            registerScenariosPost.Email.Clear();
            registerScenariosPost.Email.SendKeys(email);

            if(sex == Config.Credentials.Valid.Sex.Male)
            {
                registerScenariosPost.SexMale.Click();
            }
            else
            {
                registerScenariosPost.SexFemale.Click();
            }

            if (speakEnglish)
            {
                registerScenariosPost.SpeakEnglish.Click();
            }

            registerScenariosPost.RegisterButton.Click();
        }
    }
}