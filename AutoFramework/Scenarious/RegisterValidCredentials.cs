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
            NavigateTo.RegisterFormScenario();
        }

        [TestCase]
        public void SuccessfulRegister()
        {
            Actions.FillRegisterForm(userid:Config.Credentials.Valid.Username, password:Config.Credentials.Valid.Password, name:Config.Credentials.Valid.Name, address:Config.Credentials.Valid.Address, country:Config.Credentials.Valid.Country.India, zipCode:Config.Credentials.Valid.ZipCode, email:Config.Credentials.Valid.Email, sex:Config.Credentials.Valid.Sex.Male, speakEnglish: true);
            
            try 
            {
                alert = Driver.driver.SwitchTo().Alert();
            }
            catch(NoAlertPresentException)
            {
                alert = null;
            }

            Assert.AreEqual(expected: null, actual:alert);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.driver.Quit();
        }
    }
}