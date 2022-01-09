using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTasks
{
    class ElementSelectors
    {
        public static void FindElementByName(string url, string name)
        {
           IWebDriver driver = new ChromeDriver();
           driver.Navigate().GoToUrl(url);
           IWebElement element;

            try
            {
                element = driver.FindElement(By.Name(name));

                if(element.Displayed)
                {
                    MessageToConsole.GreenMessage("[FindElementByName] YES");
                }
            
            }
            catch(NoSuchElementException)
            {
                MessageToConsole.RedMessage("[FindElementByName] NO");
            }

            driver.Quit();
        }

        public static void FindElementById(string url, string id)
        {
           IWebDriver driver = new ChromeDriver();
           driver.Navigate().GoToUrl(url);
           IWebElement element;

            try
            {
                element = driver.FindElement(By.Id(id));

                if(element.Displayed)
                {
                    MessageToConsole.GreenMessage("[FindElementById] YES");
                }
            
            }
            catch(NoSuchElementException)
            {
                MessageToConsole.RedMessage("[FindElementById] NO");
            }

            driver.Quit();
        }

        public static void FindElementByClassName(string url, string className)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            IWebElement element;

            try
            {
                element = driver.FindElement(By.ClassName(className));

                if(element.Displayed)
                {
                    MessageToConsole.GreenMessage("[FindElementByClassName] YES");
                    MessageToConsole.GreenMessage($"[FindElementByClassName] {element.Text}");
                }
            
            }
            catch(NoSuchElementException)
            {
                MessageToConsole.RedMessage("[FindElementByClassName] NO");
            }

            driver.Quit();
        }

        public static void FindElementByCssPath(string url, string cssPath)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            IWebElement element;

            try
            {
                element = driver.FindElement(By.CssSelector(cssPath));

                if(element.Displayed){MessageToConsole.GreenMessage("[FindElementByCssPath] YES");}
            
            }
            catch(NoSuchElementException)
            {
                MessageToConsole.RedMessage("[FindElementByCssPath] NO");
            }

            driver.Quit();
        }

        public static void FindElementByXPath(string url, string xPath)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            IWebElement element;

            try
            {
                element = driver.FindElement(By.XPath(xPath));

                if(element.Displayed){MessageToConsole.GreenMessage("[FindElementByXPath] YES");}
            
            }
            catch(NoSuchElementException)
            {
                MessageToConsole.RedMessage("[FindElementByXPath] NO");
            }

            driver.Quit();
        }
        
    }
}
