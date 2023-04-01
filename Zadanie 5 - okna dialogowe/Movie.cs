using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_5___okna_dialogowe
{
    internal class Movie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Movie()
        {

        }
        public Movie(string title,string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
