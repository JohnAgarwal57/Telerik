namespace FolderTree
{
    using System;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            FolderTree dirTree = new FolderTree(@"C:\Program Files");

            var searchFolder = @"Sublime Text 2";
            double size = dirTree.CalculateSizeInSubFolders(searchFolder);

            Console.WriteLine("The size of {0} is {1} bytes", searchFolder, size);
        }
    }
}
