﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BookFavor.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public Publisher(string n)
        {
            this.Name = n;
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        
    }
}


