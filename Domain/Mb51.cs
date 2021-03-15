using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Mb51 
    {
        public long Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime PstngDate { get; set; }
        public string Time { get; set; }
        public DateTime DocDate { get; set; }
        public string ArtDoc { get; set; }
        public string Article { get; set; }
        public string ArticleDescription { get; set; }
        public string BUn { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        public string MvT { get; set; }
        public string Site { get; set; }
        public string SLoc { get; set; }
        public string Customer { get; set; }
        public string MvtTypeText { get; set; }
        public string Name1 { get; set; }
        public string Username { get; set; }
        public string GtrStatus { get; set; }
    }
}
