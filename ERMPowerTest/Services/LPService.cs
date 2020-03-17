using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ERMPowerTest.Models;
using ERMPowerTest.Utils;

namespace ERMPowerTest.Services
{
    public class LPService
    {
		// Filter the list of objects with values that are 20% above or below the median
		public static List<LPDTO> GetToPrintLP(List<LPDTO> lLP, double median)
		{
			return lLP.Where(x => (x.DataValue >= (median * 1.2)) || (x.DataValue <= (median * 0.8))).ToList();
		}

		public static double GetMedian(List<LPDTO> lLP)
		{
			List<double> values = lLP.Select(c => c.DataValue).ToList();
			return MathUtil.FindMeidan(values);
		}

        // print to the console using the following format:
        // {file name} {datetime} {value} {median value} 
		public static void PrintLP(string fPath)
        {
			var fileName = Path.GetFileName(fPath); 
			List<LPDTO> lLP = CSVUtil.ReadToLP(fPath);
			var median = GetMedian(lLP);
			List<LPDTO> pList = GetToPrintLP(lLP, median);

			pList.ForEach(lp => Console.WriteLine(fileName + " " + lp.Date + " " + lp.DataValue + " " + median));
		}

	}
}
