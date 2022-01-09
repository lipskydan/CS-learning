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
            ElementSelectors.FindElementByCssPath(url:"https://testing.todorvachev.com/css-path/", cssPath: "#post-108 > div > figure > img");
            ElementSelectors.FindElementByXPath(url:"https://testing.todorvachev.com/css-path/", xPath: "//*[@id=\"post-108\"]/div/figure/img");
        }
    }
}
    