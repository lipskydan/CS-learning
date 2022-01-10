using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTasks
{
    class Program       
    {
        static void Main()
        {
            // ElementSelectors.FindElementByName(url:"https://testing.todorvachev.com/name/", name:"myName");
            // ElementSelectors.FindElementById(url:"https://testing.todorvachev.com/id/", id:"testImage");
            // ElementSelectors.FindElementByClassName(url:"https://testing.todorvachev.com/class-name/", className: "testClass");
            // ElementSelectors.FindElementByCssPath(url:"https://testing.todorvachev.com/css-path/", cssPath: "#post-108 > div > figure > img");
            // ElementSelectors.FindElementByXPath(url:"https://testing.todorvachev.com/css-path/", xPath: "//*[@id=\"post-108\"]/div/figure/img");

            SpecialElementSelector.driver = new ChromeDriver();
            SpecialElementSelector.driver.Navigate().GoToUrl("https://testing.todorvachev.com/text-input-field/"); 

            IWebElement element1 = SpecialElementSelector.FindTextInputField(FindBy.Name, whatSearch:"username");

            SpecialElementSelector.SetValueToTextInputField(textField: element1, "Hello!");

            SpecialElementSelector.GetValueFromTextInputField(element1, out string text1);
            MessageToConsole.GreenMessage(text1);

            SpecialElementSelector.driver.Quit();

        }
    }
}
    