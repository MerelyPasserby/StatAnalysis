using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class VarClassRow
    {
        public double Lower {  get; private set; }
        public double Upper { get; private set; }
        public int Count { get; set; }
        public double RelativeCount { get; set; }
        public double EmpiricFuncValue { get; set; }

        public VarClassRow() : this(0.0, 0.0, 0, 0.0, 0.0) { }
        public VarClassRow(double lower, double upper) : this( lower, upper, 0, 0.0, 0.0) { }        
        public VarClassRow(double lower, double upper, int count, double relative, double empiric)
        {
            (Lower, Upper, Count, RelativeCount, EmpiricFuncValue) = (lower, upper, count, relative, empiric);
        }
    }
}
