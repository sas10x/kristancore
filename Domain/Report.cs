using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Report
    {
        public DateTime Name { get; set; }
         [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }    
    }
}