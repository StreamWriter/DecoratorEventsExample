using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorEvents
{
    public class Song : DbItem
    {
        public int Id { get; set; }

        public string Artist { get; set; }

        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            Song otherSong = (Song)obj;

            return (Id == otherSong.Id);
        }
    }
}
