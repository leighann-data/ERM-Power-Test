using System;
namespace ERMPowerTest.Models
{
    public class LPDTO
    {
        public string FileType = "LP";
        public string MeterPointCode { get; set; }
        public int SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime Date { get; set; }
        public string DataType { get; set; }
        public double DataValue { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }

        public LPDTO(string line)
        {
            var split = line.Split(',');
            MeterPointCode = split[0];
            SerialNumber = int.Parse(split[1]);
            PlantCode = split[2];
            Date = DateTime.Parse(split[3]);
            DataType = split[4];
            DataValue = double.Parse(split[5]);
            Units = split[6];
            Status = split[7];
        }

        public LPDTO()
        {
        }
    }
    
}
