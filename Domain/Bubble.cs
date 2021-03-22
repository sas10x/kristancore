using System.ComponentModel.DataAnnotations.Schema;

namespace Domain {
    public class Bubble {
        public string name { get; set; }
     
        public int x { get; set; }
       
        public int y { get; set; }
        public int r { get; set; }
    }

}