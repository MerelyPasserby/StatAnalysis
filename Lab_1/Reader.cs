using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Reader
    {
        public List<(double Value, int Count)> GetFromFile(string fileName, out int amount)
        {
            Dictionary<double, int> counts = new Dictionary<double, int>();
            string line;
            double el;
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    el = double.Parse(line, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
                    if (counts.ContainsKey(el))
                    {
                        counts[el]++;
                    }
                    else
                    {
                        counts[el] = 1;
                    }
                }
            }

            List<(double Value, int Count)> res =
                counts.Select(pair => (pair.Key, pair.Value)).ToList();

            res.Sort((el1, el2) => el1.Value.CompareTo(el2.Value));
           
            amount = res.Sum(el => el.Count);

            return res;
        }

    }
}

