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
        Id,
        CssSelector,
        XPath
    }

    enum StatusOfCheckBox
    {
        Checked,
        Unchecked
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

        public static IWebElement FindSpecialElementSelector(FindBy findBy, string whatSearch)
        {
            IWebElement textField = null;
            try
            {
                if(findBy == FindBy.Name) textField = driver.FindElement(By.Name(whatSearch));
                if(findBy == FindBy.ClassName) textField = driver.FindElement(By.ClassName(whatSearch));
                if(findBy == FindBy.Id) textField = driver.FindElement(By.Id(whatSearch));
                if(findBy == FindBy.CssSelector) textField = driver.FindElement(By.CssSelector(whatSearch));
                if(findBy == FindBy.XPath) textField = driver.FindElement(By.XPath(whatSearch));

                MessageToConsole.GreenMessage("[FindSpecialElementSelector] Element was found");
            }
            catch(NoSuchElementException)
            {
                MessageToConsole.RedMessage("[FindSpecialElementSelector] No such element was found");
            }
            
            return textField;
        }
          public static void GetValueFromSpecialElementSelector(IWebElement webElement, out string text)
        {
            try
            {
                text = webElement.GetAttribute("value");
                if(text=="")
                {
                    MessageToConsole.RedMessage("[GetValueFromSpecialElementSelector] Value is empty");
                }
                else
                {
                    MessageToConsole.GreenMessage("[GetValueFromSpecialElementSelector] Value gotten");
                }
            }
            catch(NullReferenceException)
            {
                text = "";
                MessageToConsole.RedMessage("[GetValueFromSpecialElementSelector] web element is null");
            }
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

        public static void SetCheckBox(IWebElement webElement, StatusOfCheckBox statusOfCheckBox)
        {
            if (statusOfCheckBox == StatusOfCheckBox.Checked)
            {
                if(webElement.GetAttribute("checked") == "true")
                {
                    MessageToConsole.RedMessage("[SetCheckBox] Check Box is already checked");
                }
                else
                {
                    webElement.Click();
                    MessageToConsole.GreenMessage("[SetCheckBox] Check Box is checked");
                }
            }
            else
            {
                if(webElement.GetAttribute("checked") == "true")
                {
                    webElement.Click();
                    MessageToConsole.GreenMessage("[SetCheckBox] Check Box is unchecked");
                }
                else
                {
                    MessageToConsole.RedMessage("[SetCheckBox] Check Box is alredy unchecked");
                }
            }
            Thread.Sleep(5000);
        }



      
    }
}