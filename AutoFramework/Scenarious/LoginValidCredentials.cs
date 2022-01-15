 namespace AutoFramework 
{
    using OpenQA.Selenium;
    using NUnit.Framework;
    using System.Threading;

    public class LoginValidCredentials
    {
        IAlert alert;
        public LoginValidCredentials(){}

        [OneTimeSetUp]
        public void Initialize()
        {
            Actions.InitializeDriver();
            NavigateTo.LoginFormScenario();
        }

        [TestCase]
        public void SuccessfulLogin()
        {
            Actions.FillLoginForm(username: Config.Credentials.Valid.Username, password: Config.Credentials.Valid.Password, repeatpassword: Config.Credentials.Valid.Password);
            Thread.Sleep(5000);
            alert = Driver.driver.SwitchTo().Alert();
            Assert.AreEqual(expected:Config.AlertsTexts.SuccessfulLogin, actual:alert.Text);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.driver.Quit();
        }
    }
}