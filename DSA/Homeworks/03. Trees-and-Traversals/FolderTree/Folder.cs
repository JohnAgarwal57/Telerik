namespace FolderTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class Folder
    {
        public Folder(string path)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(path);
            this.Name = folderInfo.Name;

            this.AddFolderAndFiles(folderInfo);
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public void AddFolderAndFiles(DirectoryInfo folderInfo)
        {
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();

            FileInfo[] files = folderInfo.GetFiles();
            DirectoryInfo[] folders = folderInfo.GetDirectories();
          
            foreach (var file in files)
            {
                this.Files.Add(new File(file.Name, file.Length));
            }

            foreach (var folder in folders)
            {
                this.ChildFolders.Add(new Folder(folder.FullName));
            }
        }

        public Folder Find(string name)
        {
            foreach (var folder in this.ChildFolders)
            {
                if (folder.Name == name)
                {
                    return folder;
                }
            }

            throw new ArgumentException("Folder not found");
        }

        public long CalcSize()
        {
            long size = 0;

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            foreach (var folder in this.ChildFolders)
            {
                size += folder.CalcSize();
            }

            return size;
        }
    }
}
