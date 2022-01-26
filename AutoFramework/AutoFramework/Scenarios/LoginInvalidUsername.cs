namespace AutoFramework
{
    using OpenQA.Selenium;
    using NUnit.Framework;

    [Parallelizable]
    public class LoginInvalidUsername
    {
        IAlert alert;
        public IWebDriver Driver { get; set; }
        public LoginInvalidUsername() { }

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = Actions.InitializeDriver();
            NavigateTo.LoginFormScenario(Driver);
        }

        [TestCase]
        public void LessThan5Chars()
        {
            Actions.FillLoginForm(username: Config.Credentials.Invalid.Username.FourCharacters,
                                  password: Config.Credentials.Valid.Password,
                                  repeatpassword: Config.Credentials.Valid.Password,
                                  driver: Driver);

            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected: Config.AlertsTexts.UsernameLengthOutOfRange, actual: alert.Text);
            alert.Accept();
        }

        [TestCase]
        public void MoreThan12Chars()
        {
            Actions.FillLoginForm(username: Config.Credentials.Invalid.Username.ThirteenCharacters,
                                  password: Config.Credentials.Valid.Password,
                                  repeatpassword: Config.Credentials.Valid.Password,
                                  driver: Driver);

            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected: Config.AlertsTexts.UsernameLengthOutOfRange, actual: alert.Text);
            alert.Accept();
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}