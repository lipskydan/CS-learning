namespace AutoFramework
{
    public static class Config
    {
        public static int ElementsWaitingTimeout = 5;
        public static string BaseURL = "http://testing.todorvachev.com";

        public static class Credentials
        {
            public static class Valid
            {
                public static string Email = "example@example.com";
                public static string Username = "Username";
                public static string Password = "password123";
                public static string Name = "danyil";
                public static string Address = "Addressone";
                public static string ZipCode = "777";

                public static class Country
                {
                    public static string Australia = "AF";
                    public static string Canada = "AL";
                    public static string India = "DZ";
                    public static string Russia = "AS";
                    public static string USA = "AD";
                }
        
                public static class Sex
                {
                    public static string Male = "Male";
                    public static string Female = "Female";
                }
            }

            public static class Invalid
            {
                public static class Email
                {
                    public static string NoUser = "@example.com";
                    public static string NoAt = "exampleexample.com";
                    public static string NoDomain = "example@";
                    public static string NoExtension = "example@example";
                }

                public static class Username
                {
                    public static string FourCharacters = "abcd";
                    public static string ThirteenCharacters = "abcdabcdabcda";
                    public static string OnlyNotAlphabetCharacter = "asd%#34";
                }

                public static class Password
                {
                    public static string FourCharacters = "abcd";
                    public static string ThirteenCharacters = "abcdabcdabcda";
                    public static string EmptyField = "";
                }
            }
        }

        public static class MenuElements
        {
            public static string Introduction = "Introduction";
            public static string Selectors = "Selectors";
            public static string SpecialElements = "Special Elements";
            public static string TestCases = "Test Cases";
            public static string TestScenarios = "Test Scenarios";
            public static string About = "About";
        }

        public static class HomePage
        {
            public static string HeaderText = "SELENIUM WEBDRIVER WITH C#";
            public static string SubHeaderText = "LEARN HOW TO WRITE TESTS WITH SELENIUM IN C#";
            public static string HeadlineText = "Introduction";
        }

        public static class AlertsTexts
        {
            public static string UsernameLengthOutOfRange = "User Id should not be empty / length be between 5 to 12";
            public static string PasswordLoginLenghtOutOfRange = "Password should not be empty / length be between 5 to 12";
            public static string PasswordRegisterLenghtOutOfRange = "Password should not be empty / length be between 7 to 12";
            public static string SuccessfulLogin = "Succesful login!";
            public static string NameMustHaveAlphabetCharatersOnly = "Username must have alphabet characters only"; 
            public static string AddressMustHaveAlphabetCharatersOnly = "User address must have alphabet characters only"; 
            public static string SelectCountryFromList = "Select your country from the list";
            public static string ZipFormat = "ZIP code must have numeric characters only";
        }
    }
    
}

