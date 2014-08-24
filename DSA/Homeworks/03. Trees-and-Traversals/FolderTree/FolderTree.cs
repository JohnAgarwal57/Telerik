namespace FolderTree
{
    using System;
    using System.IO;

    internal class FolderTree
    {
        public FolderTree(string rootPath)
        {
            this.RootPath = rootPath;
            var root = Directory.GetParent(rootPath);

            this.RootFolder = new Folder(rootPath);
        }

        public string RootPath { get; set; }

        public Folder RootFolder { get; set; }

        public double CalculateSizeInSubFolders(string folderName)
        {
            Folder folder = this.RootFolder.Find(folderName);

            return this.GetFilesSize(folder);
        }

        public Folder FindFolder(string folderName)
        {
            return this.RootFolder.Find(folderName);
        }

        private long GetFilesSize(Folder folder)
        {
            long size = 0;

            foreach (var file in folder.Files)
            {
                size += file.Size;
            }

            foreach (var subFolder in folder.ChildFolders)
            {
                size += subFolder.CalcSize();
            }

            return size;
        }
    }
}
