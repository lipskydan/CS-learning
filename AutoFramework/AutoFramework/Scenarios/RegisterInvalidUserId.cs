using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Scenarios
{
    using OpenQA.Selenium;
    using NUnit.Framework;
    using System.Threading;
    public class RegisterInvalidUserId
    {
        IAlert alert;
        public IWebDriver Driver { get; set; }
        public RegisterInvalidUserId() { }

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = Actions.InitializeDriver();
            NavigateTo.RegisterFormScenario(Driver);
        }

        [TestCase]
        public void LessThan5Chars()
        {
            Actions.FillRegisterForm(userid: Config.Credentials.Invalid.Username.FourCharacters,
                                     password: Config.Credentials.Valid.Password,
                                     name: Config.Credentials.Valid.Name,
                                     address: Config.Credentials.Valid.Address,
                                     country: Config.Credentials.Valid.Country.Canada,
                                     zipCode: Config.Credentials.Valid.ZipCode,
                                     email: Config.Credentials.Valid.Email,
                                     sex: Config.Credentials.Valid.Sex.Male,
                                     speakEnglish: true,
                                     driver: Driver);

            alert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expected: Config.AlertsTexts.UsernameLengthOutOfRange, actual: alert.Text);
            alert.Accept();
        }

        [TestCase]
        public void MoreThan12Chars()
        {
            Actions.FillRegisterForm(userid: Config.Credentials.Invalid.Username.ThirteenCharacters,
                                      password: Config.Credentials.Valid.Password,
                                      name: Config.Credentials.Valid.Name,
                                      address: Config.Credentials.Valid.Address,
                                      country: Config.Credentials.Valid.Country.Canada,
                                      zipCode: Config.Credentials.Valid.ZipCode,
                                      email: Config.Credentials.Valid.Email,
                                      sex: Config.Credentials.Valid.Sex.Male,
                                      speakEnglish: true,
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
