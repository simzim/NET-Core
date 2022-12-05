using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BookFavor.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            BookGenres = new HashSet<BookGenre>();
        }

        public Book(string Pavadinimas)
        {
            this.Title = Pavadinimas;
            BookAuthors = new HashSet<BookAuthor>();
            BookGenres = new HashSet<BookGenre>();
        }


        public int Id { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Range(1, 2000)]

        [Display(Name = "Books Quantity")]
        public int? Quantity { get; set; }

        [Range(1, 2000)]

        [Display(Name = "Total Pages")]
        public string TotalPages { get; set; }
        public int? Isbn { get; set; }


        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        public DateTime? PublishedDate { get; set; }
        public int? PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        [Display(Name = "Book Authors")]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        [Display(Name = "Book Genres")]
        public virtual ICollection<BookGenre> BookGenres { get; set; }

        public override string ToString()
        {
            return "\"" + Title + "\"";
        }



    }
}
