using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ERMPowerTest.Models;

namespace ERMPowerTest.Utils
{
    public class CSVUtil
    {
		// Read CSV file with type "TOU" into a list of TOU objects
		public static List<TOUDTO> ReadToTOU(string fPath)
		{
			List<TOUDTO> lTOU = new List<TOUDTO>();
			var lines = File.ReadAllLines(fPath).Skip(1);
			foreach (string line in lines)
			{
				TOUDTO tou = new TOUDTO(line);
				lTOU.Add(tou);
			}

			return lTOU;

		}

		// Read CSV file with type "LP" into a list of LP objects
		public static List<LPDTO> ReadToLP(string fPath)
		{
			List<LPDTO> lLP = new List<LPDTO>();
			var lines = File.ReadAllLines(fPath).Skip(1);
			foreach (string line in lines)
			{
				LPDTO lp = new LPDTO(line);
				lLP.Add(lp);
			}

			return lLP;
		}
    }
}
