using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTasks
{
    class Program       
    {
        public static void ScenarioForSpecialElementSelectors()
        {
            SpecialElementSelector.SetDriverAndUrl("https://testing.todorvachev.com/check-button-test-3/"); 
            IWebElement webElement = SpecialElementSelector.FindSpecialElementSelector(FindBy.CssSelector, whatSearch:"#post-33 > div > p:nth-child(8) > input[type=checkbox]:nth-child(1)");
            // SpecialElementSelector.SetValueToTextInputField(textField: webElement, "Hello!");
            SpecialElementSelector.GetValueFromSpecialElementSelector(webElement, out string text1);
            MessageToConsole.GreenMessage(text1);
            SpecialElementSelector.SetCheckBox(webElement, StatusOfCheckBox.Checked);
            SpecialElementSelector.Quite();




        }
        static void Main()
        {
            // ElementSelectors.FindElementByName(url:"https://testing.todorvachev.com/name/", name:"myName");
            // ElementSelectors.FindElementById(url:"https://testing.todorvachev.com/id/", id:"testImage");
            // ElementSelectors.FindElementByClassName(url:"https://testing.todorvachev.com/class-name/", className: "testClass");
            // ElementSelectors.FindElementByCssPath(url:"https://testing.todorvachev.com/css-path/", cssPath: "#post-108 > div > figure > img");
            // ElementSelectors.FindElementByXPath(url:"https://testing.todorvachev.com/css-path/", xPath: "//*[@id=\"post-108\"]/div/figure/img");

            ScenarioForSpecialElementSelectors();
            

        }
    }
}
    