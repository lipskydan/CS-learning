namespace AutoFramework 
{
    using OpenQA.Selenium;
    using NUnit.Framework;

    public class RegisterValidCredentials
    {
        IAlert alert;
        public IWebDriver Driver {get; set;}
        public RegisterValidCredentials(){}

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = Actions.InitializeDriver();
            NavigateTo.RegisterFormScenario(Driver);
        }

        [TestCase]
        public void SuccessfulRegister()
        {
            Actions.FillRegisterForm(userid:Config.Credentials.Valid.Username, 
                                     password:Config.Credentials.Valid.Password, 
                                     name:Config.Credentials.Valid.Name, 
                                     address:Config.Credentials.Valid.Address, 
                                     country:Config.Credentials.Valid.Country.India, 
                                     zipCode:Config.Credentials.Valid.ZipCode, 
                                     email:Config.Credentials.Valid.Email, 
                                     sex:Config.Credentials.Valid.Sex.Male, 
                                     speakEnglish: true, 
                                     driver:Driver);
            
            try 
            {
                alert = Driver.SwitchTo().Alert();
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
            Driver.Quit();
        }
    }
}