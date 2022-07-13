using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class GrowthOfAPopulation
    {
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            int years = 0;
            while (p0 < p)
            {
                p0 = p0 + (int)(p0 * percent / 100.0) + aug;
                years++;
            }

            return years;
        }
    }
}
