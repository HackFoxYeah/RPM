using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practWork_8
{
    internal interface ICargoTransport
    {
        public double CargoCapacity { get; set; }

        public double LoadCapacity { get; set; }
    }
}
