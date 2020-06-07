using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace laba2
{
    class Computer : IComputer, IOverclock
    {
        public ProcessorType processorType { get; set; } //тип процессора
        public NameManufacturer nameManufacturer { get; set; } //название производителя
        public TypeOfOperatingSystem typeOfOperatingSystem { get; set; } //тип операционной системы
        public int processClockSpeed { get; set; } //тактовая частота процессов
        public int amountOfRAM { get; set; } //объем оперативной памяти
        public List<string> InstalledSoftware; //установленное ПО
        public List<string> UsersOfSystem; //пользователи системы

        public static List<Computer> ListExsamleOfComputer; //хранит экземпляры класса Computer

        public int method_only_one { get; set; }

        public Computer()
        {
            InstalledSoftware = new List<string>();
            UsersOfSystem = new List<string>();

            processorType = ProcessorType.Pentium;
            nameManufacturer = NameManufacturer.AMD;
            typeOfOperatingSystem = TypeOfOperatingSystem.Многопользовательские;
            processClockSpeed = 400;
            amountOfRAM = 16;
            InstalledSoftware.Add("Windows");
            UsersOfSystem.Add("Хрулев");
        }

        Computer(ProcessorType _processorType, NameManufacturer _nameManufacturer, TypeOfOperatingSystem _typeOfOperatingSystem,
                int _processClockSpeed, int _amountOfRAM, List<string> _InstalledSoftware, List<string> _UsersOfSystem)
        {
            InstalledSoftware = new List<string>();
            UsersOfSystem = new List<string>();

            processorType = _processorType;
            nameManufacturer = _nameManufacturer;
            typeOfOperatingSystem = _typeOfOperatingSystem;
            processClockSpeed = _processClockSpeed;
            amountOfRAM = _amountOfRAM;
            InstalledSoftware = _InstalledSoftware;
            UsersOfSystem = _UsersOfSystem;
        }

        //метод, создающий один экземпляр класса
        public static Computer Generate()
        {
            Random rnd = new Random();
            ProcessorType _processorType = (ProcessorType)rnd.Next(4);
            NameManufacturer _nameManufacturer = (NameManufacturer)rnd.Next(3);
            TypeOfOperatingSystem _typeOfOperatingSystem = (TypeOfOperatingSystem)rnd.Next(4);
            int _processClockSpeed = rnd.Next(100, 1000);

            int _amountOfRAM = 0;
            int _amount = rnd.Next(4);
            switch (_amount) { 
                case 0: _amountOfRAM = 2; break;
                case 1: _amountOfRAM = 4; break;
                case 2: _amountOfRAM = 8; break;
                case 3: _amountOfRAM = 16; break;
            }

            List<string> _InstalledSoftware = new List<string>();
            int _installedSoftware1 = rnd.Next(3);
            switch (_installedSoftware1)
            {
                case 0: _InstalledSoftware.Add("Windows"); break;
                case 1: _InstalledSoftware.Add("MAC"); break;
                case 2: _InstalledSoftware.Add("Linux"); break;
            }

            int _installedSoftware2 = rnd.Next(6);
            if (_installedSoftware1 != _installedSoftware2)
            {
                switch (_installedSoftware2)
                {
                    case 0: _InstalledSoftware.Add("Windows"); break;
                    case 1: _InstalledSoftware.Add("MAC"); break;
                    case 2: _InstalledSoftware.Add("Linux"); break;
                }
            }

            List<string> _UsersOfSystem = new List<string>();
            int _usersOfSystem1 = rnd.Next(6);
            switch (_usersOfSystem1)
            {
                case 0: _UsersOfSystem.Add("Хрулев"); break;
                case 1: _UsersOfSystem.Add("Бухалов"); break;
                case 2: _UsersOfSystem.Add("Рогожина"); break;
                case 3: _UsersOfSystem.Add("Досаева"); break;
                case 4: _UsersOfSystem.Add("Лукин"); break;
                case 5: _UsersOfSystem.Add("Янцен"); break;
            }

            int _usersOfSystem2 = rnd.Next(12);
            if (_usersOfSystem1 != _usersOfSystem2)
                switch (_usersOfSystem2)
            {
                case 0: _UsersOfSystem.Add("Хрулев"); break;
                case 1: _UsersOfSystem.Add("Бухалов"); break;
                case 2: _UsersOfSystem.Add("Рогожина"); break;
                case 3: _UsersOfSystem.Add("Досаева"); break;
                case 4: _UsersOfSystem.Add("Лукин"); break;
                case 5: _UsersOfSystem.Add("Янцен"); break;
            }

            return new Computer(_processorType, _nameManufacturer, _typeOfOperatingSystem, _processClockSpeed,
                                _amountOfRAM, _InstalledSoftware, _UsersOfSystem);
        }

        public static List<Computer> Generate100()
        {
            ListExsamleOfComputer = new List<Computer>();

            for (int i = 0; i < 100; i++)
            {
                ListExsamleOfComputer.Add(Generate());
                Thread.Sleep(100);
            }

            return ListExsamleOfComputer;
        }

        public string ComputerInfo()
        {
            return string.Format("{0,10}  {1,5}  {2,21} ClockSpeed = {3,4} RAM = {4,4}  {5,16}  {6}", this.processorType, this.nameManufacturer, this.typeOfOperatingSystem, this.processClockSpeed, this.amountOfRAM, this.GetInstalledSoftware(), this.GetUsersOfSystem());
        }

        public string GetInstalledSoftware()
        {
            if (this.InstalledSoftware.Count == 1)
                return string.Format(this.InstalledSoftware[0]);
            else
                return string.Format(this.InstalledSoftware[0] + " " + this.InstalledSoftware[1]);
        }
        public string GetUsersOfSystem()
        {
            if (this.UsersOfSystem.Count == 1)
                return string.Format(this.UsersOfSystem[0]);
            else
                return string.Format(this.UsersOfSystem[0] + " " + this.UsersOfSystem[1]);
        }

        public void OverclockTheComputer() 
        {
            if (method_only_one == 0)
            {
                method_only_one = 1;
                int Frequency = 0;
                switch (processorType)
                {
                    case ProcessorType.Pentium: Frequency += 200; break;
                    case ProcessorType.Celeron: Frequency += 300; break;
                    case ProcessorType.Core_i: Frequency += 400; break;
                }
                Console.WriteLine("Frequency = {0}", Frequency);
            }
            else
                Console.WriteLine("Метод уже был вызван");
        }
    }
}
