using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCrossDemo.Core.Models
{
    public class Unit
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }

        public Unit() { }
        public Unit(string unitCode, string unitName)
        {
            UnitCode = unitCode;
            UnitName = unitName;
        }
    }
}
