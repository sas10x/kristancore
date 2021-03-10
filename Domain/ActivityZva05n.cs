using System;

namespace Domain
{
    public class ActivityZva05n
    {
        public long Id { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public string Article { get; set; }
        public string SO { get; set; }
        public long Zva05nId { get; set; }
        public virtual Zva05n Zva05n { get; set; }
        public DateTime Date { get; set; }
        public string GtrStatus { get; set; }

    }
}
