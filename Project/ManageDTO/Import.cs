using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDTO
{
   public class Import
    {
        public string ImportID { get; set; }
        public string ProductID { get; set; }
        public string DateImport { get; set; }
        public string ImportFrom { get; set; }
        public int NumberPackageImport { get; set; }
        public float PriceImport { get; set; }
        public float PriceOneImport { get; set; }
        public string ProductName { get; set; }
        public float lastPrice { get; set; }
        public int numSub { get; set; }
    }
}
