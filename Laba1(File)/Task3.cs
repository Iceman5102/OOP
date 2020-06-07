using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Laba1
{
    static class Task3
    {
        static byte[] virusSum = null;
        static int virusByteSize = 16;
        public static void Task()
        {
            File.Create("Virus.exe").Dispose();
            using (Stream stream = new FileStream("Virus.exe", FileMode.Open, FileAccess.Write))
            {
                for (int i = 0; i < virusByteSize; i++)
                    stream.WriteByte((byte)i);
            }
            FileInfo virus = new FileInfo("Virus.exe");
            Spread(new DirectoryInfo(@"E:\").Root, virus);
            Console.WriteLine("Вирус распространился, нажмите на любую клавишу чтобы удалить его");
            Console.ReadKey(true);
            Console.WriteLine("Удаляю вирус");
            virusSum = CalcMD5(virus);
            Destroy(new DirectoryInfo(@"E:\").Root);
            Console.WriteLine("Вирус был удалён"); ;
        }
        static void Spread(DirectoryInfo directory, FileInfo virus)
        {
            {
                try
                {
                    virus.CopyTo(directory.FullName + @"\" + virus.Name, true);
                    foreach (var fold in directory.GetDirectories())
                    {
                        Spread(fold, virus);
                    }
                }
                catch (System.UnauthorizedAccessException) { }
            }
        }
        static void Destroy(DirectoryInfo directory)
        {
            try
            {
                foreach (var file in directory.EnumerateFiles())
                {
                    bool sumsEqual = false;
                    if (Path.GetExtension(file.Name) == ".exe")
                    {
                        var fileSum = CalcMD5(file);
                        if (fileSum.Length == virusSum.Length)
                        {
                            int i = 0;
                            while (i < fileSum.Length && fileSum[i] == virusSum[i])
                                i++;
                            if (i == fileSum.Length) sumsEqual = true;
                        }
                    }
                    if (sumsEqual) file.Delete();
                }
                foreach (var fold in directory.GetDirectories())
                {
                    Destroy(fold);
                }
            }
            catch (System.UnauthorizedAccessException)
            { }
        }
        static byte[] CalcMD5(FileInfo file)
        {
            using (StreamReader fileReader = new StreamReader(file.FullName))
            {
                MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
                byte[] data = Encoding.UTF8.GetBytes(fileReader.ReadToEnd());
                return mD5.ComputeHash(data);
            }
        }
    }
}
