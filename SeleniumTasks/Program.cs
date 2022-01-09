using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTasks
{
    class Program       
    {

        public static void FindElementByName(string url, string name)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            IWebElement element = driver.FindElement(By.Name(name));

            if(element.Displayed)
            {
                MessageToConsole.GreenMessage("[FindElementByName] YES");
            }
            else
            {
                MessageToConsole.RedMessage("[FindElementByName] NO");
            }

            driver.Quit();
        }

        public static void FindElementById(string url, string id)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            IWebElement element = driver.FindElement(By.Id(id));
            if(element.Displayed)
            {
                MessageToConsole.GreenMessage("[FindElementById] YES");
            }
            else
            {
                MessageToConsole.RedMessage("[FindElementById] NO");
            }

            driver.Quit();
        }

        public static void FindElementByClassName(string url, string className)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            IWebElement element = driver.FindElement(By.ClassName(className));
            if(element.Displayed)
            {
                MessageToConsole.GreenMessage("[FindElementByClassName] YES");
                MessageToConsole.GreenMessage($"[FindElementByClassName] {element.Text}");
            }
            else
            {
                MessageToConsole.RedMessage("[FindElementByClassName] NO");
            }

            driver.Quit();
        }
        
        static void Main()
        {
            // FindElementByName(url:"https://testing.todorvachev.com/name/", name:"myName");
            // FindElementById(url:"https://testing.todorvachev.com/id/", id:"testImage");
            FindElementByClassName(url:"https://testing.todorvachev.com/class-name/", className: "testClass");
        }
    }
}
    