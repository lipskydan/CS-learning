namespace AutoFramework 
{
    using AutoFramework.Pages;

    public static class NavigateTo
    {
        public static void LoginFormScenario()
        {
            new Menu().TestScenerios.Click();
            new TestScenariosPage().LoginFormScenario.Click();
        }

        public static void RegisterFormScenario()
        {
            new Menu().TestScenerios.Click();
            new TestScenariosPage().RegisterFormScenario.Click();
        }
    }
}