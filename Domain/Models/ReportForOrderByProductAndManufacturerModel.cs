using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ReportForOrderByProductAndManufacturerModel
    {
        public string ProductName { get; set; }
        public string ManufacturerName { get; set; }
        public int TotalQuantity { get; set; }
    }
}
