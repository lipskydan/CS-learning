 namespace AutoFramework 
{
    using OpenQA.Selenium;
    using NUnit.Framework;

    public class LoginValidCredentials
    {
        IAlert alert;
        public IWebDriver Driver {get; set;}
        public LoginValidCredentials(){}

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = Actions.InitializeDriver();
            NavigateTo.LoginFormScenario(Driver);
        }

        [TestCase]
        public void SuccessfulLogin()
        {
            Actions.FillLoginForm(username: Config.Credentials.Valid.Username, password: Config.Credentials.Valid.Password, repeatpassword: Config.Credentials.Valid.Password,driver:Driver);
            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected:Config.AlertsTexts.SuccessfulLogin, actual:alert.Text);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}