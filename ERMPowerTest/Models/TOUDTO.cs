using System;
namespace ERMPowerTest.Models
{
    public class TOUDTO
    {
        public string FileType = "TOU";
        public string MeterPointCode { get; set; }
        public int SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime Date { get; set; }
        public string DataType { get; set; }
        public double Energy { get; set; }
        public float MaximumDemand { get; set; }
        public DateTime TimeofMaxDemand { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
        public string Period { get; set; }
        public bool DLSActive { get; set; }
        public int BillingResetCount { get; set; }
        public DateTime BillingResetDate { get; set; }
        public string Rate { get; set; }

        public TOUDTO(string line)
        {
            var split = line.Split(',');
            MeterPointCode = split[0];
            SerialNumber = int.Parse(split[1]);
            PlantCode = split[2];
            Date = DateTime.Parse(split[3]);
            DataType = split[4];
            Energy = double.Parse(split[5]);
            MaximumDemand = float.Parse(split[6]);
            TimeofMaxDemand = DateTime.Parse(split[7]);
            Units = split[8];
            Status = split[9];
            Period = split[10];
            DLSActive = bool.Parse(split[11]);
            BillingResetCount = int.Parse(split[12]);
            BillingResetDate = DateTime.Parse(split[13]);
            Rate = split[14];
        }

        public TOUDTO()
        {

        }
    }
}
