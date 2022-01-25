 namespace AutoFramework 
{
    using OpenQA.Selenium;
    using NUnit.Framework;

    public class LoginInvalidPassword
    {
        IAlert alert;
        public IWebDriver Driver {get; set;}
        public LoginInvalidPassword(){}

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = Actions.InitializeDriver();
            NavigateTo.LoginFormScenario(Driver);
        }

        [TestCase]
        public void LessThan5Chars()
        {
            Actions.FillLoginForm(username: Config.Credentials.Valid.Username, password: Config.Credentials.Invalid.Password.FourCharacters, repeatpassword: Config.Credentials.Invalid.Password.FourCharacters, driver:Driver);
            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected:Config.AlertsTexts.PasswordLenghtOutOfRange, actual:alert.Text);
            alert.Accept();
        }

        [TestCase]
        public void MoreThan12Chars()
        {
            Actions.FillLoginForm(username: Config.Credentials.Valid.Username, password: Config.Credentials.Invalid.Password.ThirteenCharacters, repeatpassword: Config.Credentials.Invalid.Password.ThirteenCharacters, Driver);
            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected:Config.AlertsTexts.PasswordLenghtOutOfRange, actual:alert.Text);
            alert.Accept();
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}