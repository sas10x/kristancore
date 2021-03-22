using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ReportSummary
    {
         [Column(TypeName = "decimal(18,2)")]
        public decimal Highest { get; set; }
         [Column(TypeName = "decimal(18,2)")]
        public decimal Lowest { get; set; }
         [Column(TypeName = "decimal(18,2)")]
        public decimal Average { get; set; }
         [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public int TotalRecords { get; set; } 
    }
}