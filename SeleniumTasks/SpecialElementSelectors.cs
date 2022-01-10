using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTasks
{
    enum FindBy
    {
        Name,
        ClassName,
        Id
    }
    class SpecialElementSelector
    {
        public static IWebDriver driver;

        public static void SetDriverAndUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url); 
        }

        public static void Quite()
        {
            driver.Quit();
        }

        public static IWebElement FindTextInputField(FindBy findBy, string whatSearch)
        {
            IWebElement textField = null;
            try
            {
                if(findBy == FindBy.Name) textField = driver.FindElement(By.Name(whatSearch));
                if(findBy == FindBy.ClassName) textField = driver.FindElement(By.ClassName(whatSearch));
                if(findBy == FindBy.Id) textField = driver.FindElement(By.Id(whatSearch));

                MessageToConsole.GreenMessage("[FindTextInputField] Element was found");
            }
            catch(NoSuchElementException)
            {
                MessageToConsole.RedMessage("[FindTextInputField] No such element was found");
            }
            
            return textField;
        }

        public static void SetValueToTextInputField(IWebElement textField, in string text)
        {
            if(textField == null) 
            {
                MessageToConsole.RedMessage("[SetValueToTextInputField] Text Input Field is null");
                return;
            }

            if(text.Length > int.Parse(textField.GetAttribute("maxlength")))
            {
                MessageToConsole.RedMessage("[SetValueToTextInputField] Size of input text is too big for current text field");
                return;
            }

            textField.SendKeys(text);
            MessageToConsole.GreenMessage("[SetValueToTextInputField] Set value to Text Input Field");
            Thread.Sleep(3000);
        }

        public static void GetValueFromTextInputField(IWebElement textField, out string text)
        {
            try
            {
                text = textField.GetAttribute("value");
                if(text=="")
                {
                    MessageToConsole.RedMessage("[GetValueFromTextInputField] Value of Text Input Field is empty");
                }
                else
                {
                    MessageToConsole.GreenMessage("[GetValueFromTextInputField] Value from Text Input Field was gotten");
                }
            }
            catch(NullReferenceException)
            {
                text = "";
                MessageToConsole.RedMessage("[GetValueFromTextInputField] Text Field is null");
            }
        }
    }
}