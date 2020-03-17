using System;
namespace ERMPowerTest.Utils
{
    public class FileUtil
    {
        public static string GetFileName(string fPath)
        {
            return fPath.Split('\\').Last();
        }
    }
}
