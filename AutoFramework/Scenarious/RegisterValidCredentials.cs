namespace AutoFramework 
{
    using OpenQA.Selenium;
    using NUnit.Framework;

    public class RegisterValidCredentials
    {
        IAlert alert;
        public RegisterValidCredentials(){}

        [OneTimeSetUp]
        public void Initialize()
        {
            Actions.InitializeDriver();
            NavigateTo.LoginFormScenario();
        }

        [TestCase]
        public void SuccessfulRegister()
        {
        
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.driver.Quit();
        }
    }
}