using System;
using System.Collections.Generic;

namespace ppedv.Musicplayer.Model
{
    public class Artist : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
