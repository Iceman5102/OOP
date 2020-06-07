using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace laba2
{
    class Manufacter : IManufacter
    {
        public NameManufacturer name { get; set; }
        public Countries country { get; set; }
        public int countOfWorker { get; set; }

        public Manufacter()
        {
            name = NameManufacturer.AMD;
            country = Countries.China;
            countOfWorker = 10000;
        }

        public Manufacter(NameManufacturer _name, Countries _country, int _countOfWorker)
        {
            name = _name;
            country = _country;
            countOfWorker = _countOfWorker;
        }
    }
}
