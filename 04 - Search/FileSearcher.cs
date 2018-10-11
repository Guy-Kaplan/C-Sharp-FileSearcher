using System;
using System.IO;

namespace JohnBryce
{
    public delegate void FilesHandler(object sender, FileEventArgs e);
    public class FileSearcher
    {
        public event FilesHandler FoundOneFile;
        public void Search(string folder, string textToSearch)
        {
            try // prevent the program from crashing
            {
                // Get all files with the given pattern:
                string[] files = Directory.GetFiles(folder, $"*{textToSearch}*");
                // Display the files:
                foreach (string item in files)
                {
                    FoundOneFile(this, new FileEventArgs(item));
                }
                // Get all directories:
                string[] directories = Directory.GetDirectories(folder);
                // Do the same on all inner directories:
                foreach (string item in directories)
                {
                    Search(item, textToSearch); // Recursion
                }
            }
            catch { } // catches exceptions so the program won't crash
        }

        public void SearchEntirePC(string textToSearch)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady == true) // check if drive is available
                    Search(drive.Name, textToSearch);
            }
        }
    }
}
