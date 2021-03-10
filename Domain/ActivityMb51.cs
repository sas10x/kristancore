using System;

namespace Domain
{
    public class ActivityMb51
    {
        public long Id { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public string Article { get; set; }
        public string Document { get; set; }
        public long Mb51Id { get; set; }
        public virtual Mb51 Mb51 { get; set; }
        public DateTime Date { get; set; }
        public string GtrStatus { get; set; }

    }
}
