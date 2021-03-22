using System.ComponentModel.DataAnnotations.Schema;

namespace Domain {
    public class Bubble {
        public string name { get; set; }
     
        public int x { get; set; }
       
        public int y { get; set; }
        public int r { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal atp { get; set; }
        public string article { get; set; }
    }

}