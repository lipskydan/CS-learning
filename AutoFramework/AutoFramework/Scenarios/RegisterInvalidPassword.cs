using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Scenarios
{
    using OpenQA.Selenium;
    using NUnit.Framework;

    [Parallelizable]
    public class RegisterInvalidPassword
    {
        IAlert alert;
        public IWebDriver Driver { get; set; }
        public RegisterInvalidPassword() { }

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = Actions.InitializeDriver();
            NavigateTo.RegisterFormScenario(Driver);
        }

        [TestCase]
        public void LessThan5Chars()
        {
            Actions.FillRegisterForm(userid: Config.Credentials.Valid.Username,
                                     password: Config.Credentials.Invalid.Password.FourCharacters,
                                     name: Config.Credentials.Valid.Name,
                                     address: Config.Credentials.Valid.Address,
                                     country: Config.Credentials.Valid.Country.Canada,
                                     zipCode: Config.Credentials.Valid.ZipCode,
                                     email: Config.Credentials.Valid.Email,
                                     sex: Config.Credentials.Valid.Sex.Male,
                                     speakEnglish: true,
                                     driver: Driver);

            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected: Config.AlertsTexts.PasswordRegisterLenghtOutOfRange, actual: alert.Text);
            alert.Accept();
        }

        [TestCase]
        public void MoreThan12Chars()
        {
            Actions.FillRegisterForm(userid: Config.Credentials.Valid.Username,
                                      password: Config.Credentials.Invalid.Password.ThirteenCharacters,
                                      name: Config.Credentials.Valid.Name,
                                      address: Config.Credentials.Valid.Address,
                                      country: Config.Credentials.Valid.Country.Canada,
                                      zipCode: Config.Credentials.Valid.ZipCode,
                                      email: Config.Credentials.Valid.Email,
                                      sex: Config.Credentials.Valid.Sex.Male,
                                      speakEnglish: true,
                                      driver: Driver);

            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected: Config.AlertsTexts.PasswordRegisterLenghtOutOfRange, actual: alert.Text);
            alert.Accept();
        }

        [TestCase]
        public void EmptyField()
        {
            Actions.FillRegisterForm(userid: Config.Credentials.Valid.Username,
                                     password: Config.Credentials.Invalid.Password.EmptyField,
                                     name: Config.Credentials.Valid.Name,
                                     address: Config.Credentials.Valid.Address,
                                     country: Config.Credentials.Valid.Country.Canada,
                                     zipCode: Config.Credentials.Valid.ZipCode,
                                     email: Config.Credentials.Valid.Email,
                                     sex: Config.Credentials.Valid.Sex.Male,
                                     speakEnglish: true,
                                     driver: Driver);

            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected: Config.AlertsTexts.PasswordRegisterLenghtOutOfRange, actual: alert.Text);
            alert.Accept();
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }
    }
}
