using System;
using System.Collections.Generic;

#nullable disable

namespace BookFavor.Models
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenres = new HashSet<BookGenre>();
        }

        public Genre(string n)
        {
            this.Genre1 = n;
            BookGenres = new HashSet<BookGenre>();
        }


        public int Id { get; set; }
        public string Genre1 { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
