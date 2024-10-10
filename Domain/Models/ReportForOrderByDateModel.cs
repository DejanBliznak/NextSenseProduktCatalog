using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ReportForOrderByDateModel
    {
        public DateTime Date { get; set; }
        public int TotalQuantity { get; set; }
    }
}
