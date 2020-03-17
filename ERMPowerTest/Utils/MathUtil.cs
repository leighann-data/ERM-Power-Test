using System;
using System.Collections.Generic;

namespace ERMPowerTest.Utils
{
    public class MathUtil
    {
        // Calculate median of a given list of double values
        public static double FindMeidan(List<double> values) {

            int size = values.Count;

            if (size == 0) return 0;

            values.Sort();

            int mid = size / 2;
            double median = (size % 2 != 0) ? values[mid] : (values[mid] + values[mid - 1]) / 2;

            return median;
        }
        
    }
}
