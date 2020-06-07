using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    interface IManufacter
    {
        NameManufacturer name { get; set; }
        Countries country { get; set; }
        int countOfWorker { get; set; }
    }
}
