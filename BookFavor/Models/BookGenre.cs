using System;
using System.Collections.Generic;

#nullable disable

namespace BookFavor.Models
{
    public partial class BookGenre
    {
        public int BooksId { get; set; }
        public int GenresId { get; set; }

        public virtual Book Books { get; set; }
        public virtual Genre Genres { get; set; }
    }
}
