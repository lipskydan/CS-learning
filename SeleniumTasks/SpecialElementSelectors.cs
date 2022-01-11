using System;
using System.Threading;
using System.Collections.Generic;
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

        public static void Quit()
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

        public static List<IWebElement> FindListRadioButtonsByCssSelector(string whatSearch)
        {
            List<IWebElement> listRadioButtons = new List<IWebElement>();
            IWebElement webElement = null;
            int i=1;
            do
            {
                try
                {
                    webElement = driver.FindElement(By.CssSelector(whatSearch + "(" + i + ")"));
                    bool isChecked = true ? webElement.GetAttribute("checked") == "true" : false;
                    MessageToConsole.GreenMessage($"[FindListRadioButtonsByCssSelector] found, value = {webElement.GetAttribute("value")}, isChecked = {isChecked}");
                    i+=2;
                    listRadioButtons.Add(webElement);
                }
                catch(NoSuchElementException)
                {
                    break;
                }
            }
            while(true);

            return listRadioButtons;
        }

        public static void PrintValueEachRadioButtonInList(List<IWebElement> list)
        {
            foreach (var item in list)
            {
                bool isChecked = true ? item.GetAttribute("checked") == "true" : false;
                MessageToConsole.GreenMessage($"[PrintValueEachRadioButtonInList] value = {item.GetAttribute("value")}, isChecked = {isChecked}");
            }   
        }

         public static List<IWebElement> GetListElementsFromDropDownMenu(string whatSearch)
        {
            List<IWebElement> list = new List<IWebElement>();
            IWebElement webElement = null;
            int i=1;
            do
            {
                try
                {
                    webElement = driver.FindElement(By.CssSelector(whatSearch + "(" + i + ")"));
                    MessageToConsole.GreenMessage($"[GetListElementsFromDropDownMenu] found, value = {webElement.GetAttribute("value")}");
                    i+=1;
                    list.Add(webElement);
                }
                catch(NoSuchElementException)
                {
                    break;
                }
            }
            while(true);

            return list;
        }

        public static void PrintEachElementFromDropDownMenuAndChooseItOneByOne(List<IWebElement> elementsFromDropDownMenu)
        {
            foreach (var item in elementsFromDropDownMenu)
            {
                MessageToConsole.GreenMessage($"[PrintEachElementFromDropDownMenuAndChooseItOneByOne] value = {item.GetAttribute("value")}");
                item.Click();
                Thread.Sleep(5000);
            }
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