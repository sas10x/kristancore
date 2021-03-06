using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Zmpq25b
    {
        public long Id { get; set; }
        public string Article { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public string BUn { get; set; }
        public string Site { get; set; }
        public string SLoc { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Unrestricted { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Confirm { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ATP { get; set; }
        public string Brand { get; set; }
        public string Status { get; set; }
        public string Size { get; set; }
        public string GtrStatus { get; set; }

    }
}
