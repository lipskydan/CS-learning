using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTasks
{
    class Program       
    {
        public static void ScenarioForSpecialElementSelectors()
        {
            SpecialElementSelector.SetDriverAndUrl("https://testing.todorvachev.com/text-input-field/");
            // IWebElement webElement = SpecialElementSelector.FindSpecialElementSelector(FindBy.CssSelector, whatSearch:"#post-33 > div > p:nth-child(8) > input[type=checkbox]:nth-child(1)");
            // SpecialElementSelector.SetValueToTextInputField(textField: webElement, "Hello!");
            // SpecialElementSelector.GetValueFromSpecialElementSelector(webElement, out string text1);
            // MessageToConsole.GreenMessage(text1);
            // SpecialElementSelector.SetCheckBox(webElement, StatusOfCheckBox.Checked);
            // List<IWebElement> listRadioButtons = SpecialElementSelector.FindListRadioButtonsByCssSelector("#post-10 > div > form > p:nth-child(6) > input[type=radio]:nth-child");
            // SpecialElementSelector.PrintValueEachRadioButtonInList(listRadioButtons);
            // IWebElement dropDownMenu = SpecialElementSelector.FindSpecialElementSelector(FindBy.Name, "DropDownTest");
            // List<IWebElement> listElementsDropDown = SpecialElementSelector.GetListElementsFromDropDownMenu("#post-6 > div > p:nth-child(6) > select > option:nth-child");
            // SpecialElementSelector.PrintEachElementFromDropDownMenuAndChooseItOneByOne(listElementsDropDown);

            SpecialElementSelector.GetTextFromAlertAndAcceptItAndCheckIfImageDisplayedInPage(cssPathToImage:"#post-119 > div > figure > img");
            SpecialElementSelector.Quit();
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
    