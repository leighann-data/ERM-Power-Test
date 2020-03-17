using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ERMPowerTest.Models;
using ERMPowerTest.Utils;

namespace ERMPowerTest.Services
{
    public class TOUService
    {
		// Filter the list of objects with values that are 20% above or below the median
		public static List<TOUDTO> GetToPrintTOU(List<TOUDTO> lTOU, double median)
		{
			return lTOU.Where(x => (x.Energy >= (median * 1.2)) || (x.Energy <= (median * 0.8))).ToList();
		}

		public static double GetMedian(List<TOUDTO> lTOU)
		{
			List<double> values = lTOU.Select(c => c.Energy).ToList();
			return MathUtil.FindMeidan(values);
		}

		// print to the console using the following format:
		// {file name} {datetime} {value} {median value} 
		public static void PrintTOU(string fPath)
		{
			var fileName = Path.GetFileName(fPath);
			List<TOUDTO> lTOU = CSVUtil.ReadToTOU(fPath);
			var median = GetMedian(lTOU);
			List<TOUDTO> pList = GetToPrintTOU(lTOU, median);

			pList.ForEach(tou => Console.WriteLine(fileName + " " + tou.Date + " " + tou.Energy + " " + median));
		}
	}
}
