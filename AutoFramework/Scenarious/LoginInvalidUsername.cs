 namespace AutoFramework 
{
    using OpenQA.Selenium;
    using NUnit.Framework;

    public class LoginInvalidUsername
    {
        IAlert alert;
        public LoginInvalidUsername(){}

        [OneTimeSetUp]
        public void Initialize()
        {
            Actions.InitializeDriver();
            NavigateTo.LoginFormScenario();
        }

        [TestCase]
        public void LessThan5Chars()
        {
            Actions.FillLoginForm(username: Config.Credentials.Invalid.Username.FourCharacters, password: Config.Credentials.Valid.Password, repeatpassword: Config.Credentials.Valid.Password);
            alert = Driver.driver.SwitchTo().Alert();
            Assert.AreEqual(expected:Config.AlertsTexts.UsernameLengthOutOfRange, actual:alert.Text);
            alert.Accept();
        }

        [TestCase]
        public void MoreThan12Chars()
        {
            Actions.FillLoginForm(username: Config.Credentials.Invalid.Username.ThirteenCharacters, password: Config.Credentials.Valid.Password, repeatpassword: Config.Credentials.Valid.Password);
            alert = Driver.driver.SwitchTo().Alert();
            Assert.AreEqual(expected:Config.AlertsTexts.UsernameLengthOutOfRange, actual:alert.Text);
            alert.Accept();
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.driver.Quit();
        }
    }
}