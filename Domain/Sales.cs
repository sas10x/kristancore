using System;

namespace Domain
{
    public class Sales
    {
        public long Id { get; set; }
        public string DeliveryStatus { get; set; }
        public string SO { get; set; }
        public string Site { get; set; }
        public string SLoc { get; set; }
        public string ShpTyp { get; set; }
        public string Docdate { get; set; }
        public string ItemNum { get; set; }
        public string UoM { get; set; }
        public int OrdQty { get; set; }
        public int ConfQty { get; set; }
        public int PgiQty { get; set; }
        public int QtyToDeliv { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetAmt { get; set; }
        public decimal NetTax { get; set; }
        public decimal InvoiceAmt { get; set; }
        public decimal TotalPending { get; set; }
        public string SalesOrg { get; set; }
        public string SType { get; set; }
        public string Salesman { get; set; }
        public string CustCode { get; set; }
        public string SalGrp { get; set; }
        public string CreatedBy { get; set; }
        public string Entrytime { get; set; }
        public string CCodeToBeBilled { get; set; }
        public string DistChan { get; set; }
    }
}