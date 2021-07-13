using System.Collections.Generic;

namespace ppedv.Musicplayer.Model
{
    public class Song : Entity
    {
        public string Title { get; set; }
        public string Source { get; set; }
        public int Length { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Artist> Artists { get; set; } = new HashSet<Artist>();
    }
}
