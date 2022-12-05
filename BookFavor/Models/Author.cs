using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BookFavor.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public Author(string n, string s)
        {
            this.FirstName = n;
            this.LastName = s;
            BookAuthors = new HashSet<BookAuthor>();
        }


        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public string getFullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}
