using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba1
{
    static class Task1
    {
        public static void Task()
        {
            if (File.Exists("MO-181.txt"))
                File.Delete("MO-181.txt");
            File.Create("MO.txt").Dispose();
            File.AppendAllText("MO-181.txt", "Дмитрий Хрулев\rДенис Бухалов\nРогожина Екатерина\n");
            if (File.Exists("MO2.txt"))
                File.Delete("MO2.txt");
            File.Copy("MO-181.txt", "MO2.txt", false);
        }
    }
}