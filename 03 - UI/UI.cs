using System;

namespace JohnBryce
{
    public class UI
    {

        static void DisplayFile(object sender, FileEventArgs e)
        {
            Console.WriteLine(e.File);
        }

        public void DisplaySearchStartMsg()
        {
            Console.WriteLine();
            Console.WriteLine("Search results:");
            Console.WriteLine("---------------");
            Console.WriteLine();
        }

        public void DisplaySearchEndMsg()
        {
            Console.WriteLine();
            Console.WriteLine("---End of search---");
            Console.WriteLine("Press Enter to continue...");
        }

        public void DisplayResultsOfFirstOption(string UserFileName) // file name only
        {
            DisplaySearchStartMsg();
            FileSearcher fs = new FileSearcher();
            fs.FoundOneFile += DisplayFile;
            fs.SearchEntirePC(UserFileName);
            DisplaySearchEndMsg();
        }

        public void DisplayResultsOfSecondOption(string UserFileName, string UserRootDirectory) // file name + directory
        {
            DisplaySearchStartMsg();
            FileSearcher fs = new FileSearcher();
            fs.FoundOneFile += DisplayFile;
            fs.Search(UserRootDirectory, UserFileName);
            DisplaySearchEndMsg();
        }
    }
}
