using System;
using System.IO;

namespace JohnBryce
{
    class Menu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("1. Enter file name to search.");
            Console.WriteLine("2. Enter file name to search + parent directory to search in.");
            Console.WriteLine("3. Exit");
        }

        public void DisplayFileNameInputMsg()
        {
            Console.Write("Enter file name to search: ");
        }

        public void DisplayRootDirectoryInputMsg()
        {
            Console.Write("Enter root directory to search in: ");
        }

        public void DisplayMenuInputErrorMsg()
        {
            Console.WriteLine("Error. Please enter 1-3 ONLY:");
        }

        public void DisplayFileNameInputErrorMsg()
        {
            Console.WriteLine("Error. Please enter a file name:");
        }

        public void DisplayRootDirectoryInputErrorMsg()
        {
            Console.WriteLine("Error. Please enter an existing root directory:");
        }

        public bool IsMenuInputWrong(string UserInput) // correct: 1-3
        {
            if (UserInput != "1" && UserInput != "2" && UserInput != "3") // Check input
            {
                return true;
            }
            return false;
        }

        public bool IsRootDirectoryInputWrong(string RootDirectory) // correct: an existing folder 
        {
            if (RootDirectory == "") // Check if string is not empty
            {
                return true;
            }
            if (!Directory.Exists(RootDirectory)) // Check if this folder doesn't exist
            {
                return true;
            }
            return false;
        }

        public bool IsFileNameInputWrong(string FileName) // correct: not ""
        {
            if (FileName == "") // Check if string is not empty
            {
                return true;
            }
            return false;
        }

        public string GetUserMenuInput()
        {
            string UserMenuInput = Console.ReadLine();
            while (IsMenuInputWrong(UserMenuInput))
            {
                DisplayMenuInputErrorMsg();
                UserMenuInput = Console.ReadLine();
            }
            return UserMenuInput;
        }
    }
}
