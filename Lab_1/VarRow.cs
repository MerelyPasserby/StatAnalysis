using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class VarRow
    {    
        public double Value { get; private set; }
        public int Count { get; private set; }
        public double RelativeCount { get; private set; }
        public double EmpiricFuncValue { get; private set; }

        public VarRow(): this(0.0, 0, 0.0, 0.0) { }
        public VarRow(double value, int count, double relative, double empiric)
        {
            (Value, Count, RelativeCount, EmpiricFuncValue) = (value, count, relative, empiric);
        }
    }
}
