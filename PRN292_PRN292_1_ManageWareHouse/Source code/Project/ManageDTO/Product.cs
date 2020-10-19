using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDTO
{
     public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Package { get; set; }
        public int NumberPackage { get; set; }
        public float PricePackage { get; set; }
        public string Subpackage { get; set; }
        public int NumberSub { get; set; }
        public int CountSubExport { get; set; }
        public float PriceToExportPackage { get; set; }
        public float PriceToExportSub { get; set; }
        public float PriceSub { get { if (this.NumberSub == 0) { return 0; } else { return this.PricePackage / this.NumberSub; } } }

        public Product()
        {

        }
    }
}
