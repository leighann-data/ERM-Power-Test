using System;
using System.Collections.Generic;
using System.IO;
using ERMPowerTest.Services;
using Mono.Options;

namespace ERMPowerTest
{
	class ERMPowerTest
	{
		public static void Main(string[] args)
		{
            // Configure paramters
			var shouldShowHelp = false;
			var fType = "";
			var fPath = "";

			var p = new OptionSet {
				{ "type|file_type=", "the type of the file to read.", type => fType = type },
				{ "path|file_path=", "the file path.", path => fPath = path },
				{ "sh|show_help", "show help message and exit.", sh => shouldShowHelp = sh != null },
			};

			List<string> extra;
			try
			{
				extra = p.Parse(args);
				fType = fType.ToLower();

				// Check whether file exists
				if (!File.Exists(fPath))
				{
					Console.WriteLine("The file does not exist.");
				}

				// Check whether file type is the same as type given
				if (!fPath.ToLower().Contains(fType))
				{
					Console.WriteLine("The type of input file should be the same as the type given.");
				}
				else
                {
					if (fType == "lp") { LPService.PrintLP(fPath); }
					else if (fType == "tou") { TOUService.PrintTOU(fPath); }
					else { Console.WriteLine("The file type can only be 'LP' or 'TOU'"); }
				}
				
			}
			catch (OptionException e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Try `--sh' for more information.");
				return;
			}

			if (shouldShowHelp)
			{
				ShowHelp(p);
				return;
			}

		}

		private static void ShowHelp(OptionSet p)
		{
			Console.WriteLine("Options:");
			p.WriteOptionDescriptions(Console.Out);
		}

	}
}
