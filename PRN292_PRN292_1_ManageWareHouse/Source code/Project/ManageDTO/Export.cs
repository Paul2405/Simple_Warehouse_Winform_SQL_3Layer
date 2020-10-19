using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDTO
{
    public class Export
    {
        public string ExportID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string DateExport { get; set; }
        public int NumberPackageExport { get; set; }
        public int NumberSubExport { get; set; }
        public float PricePackageExport { get; set; }
        public float PriceSubPackageExport { get; set; }
        public float PriceExport { get; set; }
        public int CountExport { get; set; }
    }
}
