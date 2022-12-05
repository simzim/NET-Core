using System;
using System.Collections.Generic;

#nullable disable

namespace BookFavor.Models
{
    public partial class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorsId { get; set; }

        public virtual Author Authors { get; set; }
        public virtual Book Book { get; set; }

        //    public void getPresentation()
        //   {
        //        Authors.ForEach(item => item.getFullName);
        //    }
    }
}
