namespace TraverseWindowsDir
{
    using System;
    using System.IO;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            // I put the Program Files, becouse in Windows there are forbidden folders and the application crushed :) You can test
            string sourceDirectory = @"C:\Program Files";

            ShowAllFolders(sourceDirectory);
        }

        private static void ShowAllFolders(string currentDirectory)
        {
            var directories = Directory.EnumerateDirectories(currentDirectory);

            foreach (var directory in directories)
            {
                ShowAllFolders(directory);
                var exeFiles = Directory.EnumerateFiles(directory, "*.exe");

                foreach (string currentFile in exeFiles)
                {
                    Console.WriteLine(currentFile);
                }
            }
        }
    }
}
