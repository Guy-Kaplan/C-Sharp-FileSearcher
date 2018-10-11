using System;
using System.IO;

namespace JohnBryce
{
    public class UILogic
    {

        public void StartProgram()
        {
            UI ui = new UI();
            Menu menu = new Menu();
            bool IsProgramNotEnding = true;
            string UserMenuInput; // 1-3
            string UserFileName; // file name
            string UserRootDirectory; // root directory
            while (IsProgramNotEnding)
            {
                menu.DisplayMenu();
                UserMenuInput = Console.ReadLine(); // need 1-3
                while (menu.IsMenuInputWrong(UserMenuInput)) // check menu input
                {
                    menu.DisplayMenuInputErrorMsg();
                    UserMenuInput = Console.ReadLine(); // regain menu option choice
                }
                Console.WriteLine();
                if (UserMenuInput == "1") // file name only
                {
                    menu.DisplayFileNameInputMsg();
                    UserFileName = Console.ReadLine(); // get file name
                    while (menu.IsFileNameInputWrong(UserFileName)) // check input
                    {
                        menu.DisplayFileNameInputErrorMsg();
                        UserFileName = Console.ReadLine(); // regain file name
                    }
                    // display search results:
                    ui.DisplayResultsOfOption1(UserFileName);
                    Console.ReadLine();
                    Console.Clear(); // clear screen
                }
                else if (UserMenuInput == "2") // file name + root directory
                {
                    menu.DisplayFileNameInputMsg();
                    UserFileName = Console.ReadLine(); // get file name
                    while (menu.IsFileNameInputWrong(UserFileName))
                    {
                        menu.DisplayFileNameInputErrorMsg();
                        UserFileName = Console.ReadLine(); // regain file name
                    }
                    menu.DisplayRootDirectoryInputMsg();
                    UserRootDirectory = Console.ReadLine(); // root directory
                    while (menu.IsRootDirectoryInputWrong(UserRootDirectory))
                    {
                        menu.DisplayRootDirectoryInputErrorMsg();
                        UserRootDirectory = Console.ReadLine(); // file name
                    }
                    // display search results:
                    ui.DisplayResultsOfOption2(UserFileName, UserRootDirectory);
                    Console.ReadLine();
                    Console.Clear(); // clear screen
                }
                else // UserMenuInput == "3" // user chose to exit
                {
                    IsProgramNotEnding = false; // Exit program
                }
            }
        }
    }
}
