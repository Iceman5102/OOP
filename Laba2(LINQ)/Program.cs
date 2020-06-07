using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Program
    {
        public static List<Computer> ListExsampleOfComputer;
        public static List<Manufacter> ListExsampleOfManufacter;
        static void Main(string[] args)
        {
            Computer c1 = new Computer();
            ListExsampleOfComputer = Computer.Generate100();
            ListExsampleOfManufacter = new List<Manufacter> { new Manufacter(NameManufacturer.AMD, Countries.China, 105760), new Manufacter(NameManufacturer.AMD, Countries.USA, 203190), new Manufacter(NameManufacturer.Intel, Countries.Britain, 97800)};

            task2();
            //task3();
            //task4();
            //task5();
            //task6();

            task2Update();
            //task3Update();
            //task4Update();
            //task5Update();
       
            Console.ReadKey();
        }
        #region Задание 2
        public static void task2()
        {
            Console.WriteLine("Отфильтровать по Типу процессора: ");
            var computerQuery =
                from computer in ListExsampleOfComputer
                where (computer.processorType == ProcessorType.Pentium)
                select computer;
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль

            Console.WriteLine("\n\nОтфильтровать по Типу процессора и названию производителя: ");
            computerQuery =
                from computer in ListExsampleOfComputer
                where (computer.processorType == ProcessorType.Pentium && computer.nameManufacturer == NameManufacturer.Intel)
                select computer;
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль

            Console.WriteLine("\n\nОтфильтровать по коллекции пользователей и объёму оперативной памяти: ");
            computerQuery =
                from computer in ListExsampleOfComputer
                where (computer.UsersOfSystem.Contains("Хрулев") && computer.amountOfRAM > 2)
                select computer;
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль
        }

        public static void task2Update()
        {
            Console.WriteLine("Отфильтровать по Типу процессора: ");
            var computerQuery = ListExsampleOfComputer.Where(c => c.processorType == ProcessorType.Pentium);

            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль

            Console.WriteLine("\n\nОтфильтровать по Типу процессора и названию производителя: ");
            computerQuery = ListExsampleOfComputer.Where(c => c.processorType == ProcessorType.Pentium && c.nameManufacturer == NameManufacturer.Intel);
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль

            Console.WriteLine("\n\nОтфильтровать по коллекции пользователей и объёму оперативной памяти: ");
            computerQuery = ListExsampleOfComputer.Where(c => c.UsersOfSystem.Contains("Хрулев") && c.amountOfRAM > 2);
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль
        }

        #endregion

        #region Задание 3
        public static void task3()
        {
            Console.WriteLine("Отсортировать по Типу процессора: ");
            var computerQuery =
                from computer in ListExsampleOfComputer
                orderby computer.processorType
                select computer;
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль

            Console.WriteLine("\n\nОтсортировать по Типу процессора и названию производителя: ");
            computerQuery =
                from computer in ListExsampleOfComputer
                orderby computer.processorType
                orderby computer.nameManufacturer descending
                select computer;
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль
        }

        public static void task3Update()
        {
            Console.WriteLine("Отсортировать по Типу процессора: ");
            var computerQuery = ListExsampleOfComputer.OrderBy(c => c.processorType);
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль

            Console.WriteLine("\n\nОтсортировать по Типу процессора и названию производителя: ");
            computerQuery = ListExsampleOfComputer.OrderBy(c => c.processorType).ThenByDescending(c => c.nameManufacturer);
            foreach (var i in computerQuery)
            {
                Console.WriteLine(i.ComputerInfo());
            } // Вывод в консоль
        }
        #endregion

        #region Задание 4
        public static void task4()
        {
            Console.WriteLine("Написать SELECT: ");
            var computerQuery =
                from computer in ListExsampleOfComputer
                select new { computer.processClockSpeed, computer.amountOfRAM, computer.InstalledSoftware };
            foreach (var i in computerQuery)
            {
                Console.WriteLine("ClockSpeed = {0,4}  amountOfRAM = {1,2}  {2}", i.processClockSpeed, i.amountOfRAM, GetInstalledSoftware(i.InstalledSoftware));
            } // Вывод в консоль
        }
        public static void task4Update()
        {
            Console.WriteLine("Написать SELECT: ");
            var computerQuery = ListExsampleOfComputer.Select(c => new { c.processClockSpeed, c.amountOfRAM, c.InstalledSoftware });
            foreach (var i in computerQuery)
            {
                Console.WriteLine("ClockSpeed = {0,4}  amountOfRAM = {1,2}  {2}", i.processClockSpeed, i.amountOfRAM, GetInstalledSoftware(i.InstalledSoftware));
            } // Вывод в консоль
        }

        // Преобразование листа в строку для вывода
        public static string GetInstalledSoftware(List<string> L)
        {
            if (L.Count == 1)
                return string.Format(L[0]);
            else
                return string.Format(L[0] + " " + L[1]);
        }
        public static string queryComputersByNameManufacterInfo(NameManufacturer nameManufacturer, List<string> InstalledSoftware, Countries country, int countOfWorker)
        {
            return string.Format("{0,5} {1,13} {2,10} countOfWorker = {3,5} ", nameManufacturer, GetInstalledSoftware(InstalledSoftware), country, countOfWorker);
        }
        #endregion

        #region Задание 5
        public static void task5()
                {
                    Console.WriteLine("5 задание:");
                    var queryComputersByNameManufacter =
                    from computer in ListExsampleOfComputer
                        // Пример Внутренненнего соединения двух таблиц по названию города .
                    join manufacter in ListExsampleOfManufacter on computer.nameManufacturer equals manufacter.name
                    select new { computer.nameManufacturer, computer.InstalledSoftware, manufacter.country, manufacter.countOfWorker };

                    foreach (var i in queryComputersByNameManufacter)
                    {
                        Console.WriteLine(queryComputersByNameManufacterInfo(i.nameManufacturer, i.InstalledSoftware, i.country, i.countOfWorker));
                    } // Вывод в консоль
                }

        public static void task5Update()
        {
            Console.WriteLine("5 задание:");
            var queryComputersByNameManufacter = ListExsampleOfComputer.Join(ListExsampleOfManufacter,
                computer => computer.nameManufacturer,
                manufacter => manufacter.name,
                (computer, manufacter) => new { computer.nameManufacturer, computer.InstalledSoftware, manufacter.country, manufacter.countOfWorker });

            foreach (var i in queryComputersByNameManufacter)
            {
                Console.WriteLine(queryComputersByNameManufacterInfo(i.nameManufacturer, i.InstalledSoftware, i.country, i.countOfWorker));
            } // Вывод в консоль
        }
        #endregion
        
        #region Задание 6
        public static void task6()
        {
            string str = make_without_russian_letter("Dmitry Хрулев");
            Console.WriteLine(str);
        }
        
        public static string make_without_russian_letter(string str)
        {
            // Select only those characters that are numbers  
            var stringQuery =
              from ch in str
              where (int)ch < 128
              select ch;

            var sb = new StringBuilder();
            foreach (var c in stringQuery)
            {
                sb.Append(c.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
