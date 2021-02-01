using System;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Article { get; set; }
        public string Site { get; set; }    
        public string SLoc { get; set; }
        public string BUn { get; set; }
        public int Unrestricted { get; set; }
        public int Qty { get; set; }
    }
}