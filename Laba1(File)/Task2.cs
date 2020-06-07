using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba1
{
    static class Task2
    {
        public static void Task()
        {
            DriveInfo[] disks = DriveInfo.GetDrives();
            List<string> docs = new List<string>();
            foreach (var disk in disks)
            {
                Console.WriteLine("Disk Name -- {0}", disk.Name);
                Console.WriteLine("Disk Format -- {0}", disk.DriveFormat);
                Console.WriteLine("Disk Type -- {0}", disk.DriveType);
                Console.WriteLine("Value -- {0}", disk.TotalSize);
                Console.WriteLine("Free Value -- {0}", disk.TotalFreeSpace);

                Folds(disk.RootDirectory, docs);

                Console.WriteLine();
            }
            if (File.Exists("docs.txt"))
                File.Delete("docs.txt");
            File.Create("docs.txt").Dispose();
            foreach (string name in docs)
                File.AppendAllText("docs.txt", name + "\n");
        }
        static void Folds(DirectoryInfo directory, List<string> docs)
        {
            string[] xtns = { ".docx", ".doc" };
            try
            {
                foreach (var file in directory.GetFiles())
                {

                    if (xtns.Contains(Path.GetExtension(file.Name.ToLower())))
                    {
                        Console.WriteLine(file.Name);
                        docs.Add(file.Name);
                    }
                }
                foreach (var fold in directory.GetDirectories())
                {

                    Console.WriteLine("   Directory - {0}, parent - {1}", fold, directory);
                    Folds(fold, docs);
                }
            }
            catch (System.UnauthorizedAccessException)
            {

            }
        }
    }
}
