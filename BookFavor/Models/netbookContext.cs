using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookFavor.Models
{
    public partial class netbookContext : DbContext
    {
        public netbookContext()
        {
        }

        public netbookContext(DbContextOptions<netbookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user=root;password=;database=net-book");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.HasIndex(e => e.PublisherId, "publisher_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Isbn).HasColumnName("isbn");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("date")
                    .HasColumnName("published_date");

                entity.Property(e => e.PublisherId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("publisher_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.TotalPages)
                    .HasMaxLength(13)
                    .HasColumnName("total_pages");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("books_ibfk_1");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorsId })
                    .HasName("PRIMARY");

                entity.ToTable("book_authors");

                entity.HasIndex(e => e.AuthorsId, "authors_id");

                entity.Property(e => e.BookId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("book_id");

                entity.Property(e => e.AuthorsId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("authors_id");

                entity.HasOne(d => d.Authors)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.AuthorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_authors_ibfk_2");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_authors_ibfk_1");
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasKey(e => new { e.GenresId, e.BooksId })
                    .HasName("PRIMARY");

                entity.ToTable("book_genres");

                entity.HasIndex(e => e.BooksId, "books_id");

                entity.Property(e => e.GenresId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("genres_id");

                entity.Property(e => e.BooksId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("books_id");

                entity.HasOne(d => d.Books)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.BooksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_genres_ibfk_1");

                entity.HasOne(d => d.Genres)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.GenresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_genres_ibfk_2");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Genre1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("genre");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
