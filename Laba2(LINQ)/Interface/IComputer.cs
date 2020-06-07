using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    interface IComputer
    {
        ProcessorType processorType { get; set; } //тип процессора
        NameManufacturer nameManufacturer { get; set; } //название производителя
        TypeOfOperatingSystem typeOfOperatingSystem { get; set; } //тип операционной системы
        int processClockSpeed { get; set; } //тактовая частота процессов
        int amountOfRAM { get; set; } //объем оперативной памяти
    }
}
