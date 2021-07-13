using System.Collections.Generic;

namespace ppedv.Musicplayer.Model
{
    public class Genre : Entity
    {
        public string Description { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
