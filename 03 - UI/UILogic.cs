using System;

namespace JohnBryce
{
    public class UILogic
    {
        SearchQueriesLogic logic = new SearchQueriesLogic();
        UI ui = new UI();
        Menu menu = new Menu();
        bool IsProgramNotEnding = true;
        string UserMenuInput; // 1-3
        string UserFileName;
        string UserRootDirectory;
        const string fileOnlyOption = "1";
        const string fileAndDirectoryOption = "2";

        public void StartProgram()
        {
            while (IsProgramNotEnding)
            {
                menu.DisplayMenu();
                UserMenuInput = menu.GetUserMenuInput(); // need 1-3
                Console.WriteLine();
                if (UserMenuInput == fileOnlyOption) // option 1
                {
                    menu.DisplayFileNameInputMsg();
                    UserFileName = GetUserFileName();
                    // display search results:
                    ui.DisplayResultsOfFirstOption(UserFileName);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (UserMenuInput == fileAndDirectoryOption) // option 2
                {
                    menu.DisplayFileNameInputMsg();
                    UserFileName = GetUserFileName();
                    menu.DisplayRootDirectoryInputMsg();
                    UserRootDirectory = GetUserRootDirectory();
                    // display search results:
                    ui.DisplayResultsOfSecondOption(UserFileName, UserRootDirectory);
                    Console.ReadLine();
                    Console.Clear();
                }
                else // option 3 - user chose to exit
                {
                    IsProgramNotEnding = false; // Exit program
                }
            }
        }

        private string GetUserFileName()
        {
            string UserFileName = Console.ReadLine();
            while (menu.IsFileNameInputWrong(UserFileName))
            {
                menu.DisplayFileNameInputErrorMsg();
                UserFileName = Console.ReadLine();
            }
            return UserFileName;
        }

        private string GetUserRootDirectory()
        {
            string UserRootDirectory = Console.ReadLine();
            while (menu.IsRootDirectoryInputWrong(UserRootDirectory))
            {
                menu.DisplayRootDirectoryInputErrorMsg();
                UserRootDirectory = Console.ReadLine();
            }
            return UserRootDirectory;
        }
    }
}
