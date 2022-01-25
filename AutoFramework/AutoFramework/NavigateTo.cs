namespace AutoFramework 
{
    using AutoFramework.Pages;
    using OpenQA.Selenium;
    public static class NavigateTo
    {
        public static void LoginFormScenario(IWebDriver driver)
        {
            new Menu(driver).TestScenerios.Click();
            new TestScenariosPage(driver).LoginFormScenario.Click();
        }

        public static void RegisterFormScenario(IWebDriver driver)
        {
            new Menu(driver).TestScenerios.Click();
            new TestScenariosPage(driver).RegisterFormScenario.Click();
        }
    }
}