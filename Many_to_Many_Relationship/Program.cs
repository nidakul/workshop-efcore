using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

#region Default Convention
//İki entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız.(ICollection,List)
//Default Convention'da cross table'ı manuel oluşturmak zorunda değiliz. EfCore tasarıma uygun bir şekilde cross table'ı kendisi otomatik basacak ve generate edecektir.
//Ve oluşturulan cross table'ın içerisinde composite primary key'i de otomatik oluşturmuş olacaktır.
//class Book
//{
//    public int Id { get; set; }
//    public string BookName { get; set; }

//    public ICollection<Author> Authors { get; set; }
//}

//class Author
//{
//    public int Id { get; set; }
//    public string AuthorName { get; set; }

//    public ICollection<Book> Books { get; set; }
//}
#endregion

#region Data Annotations
//Cross table manuel olarak oluşturulmak zorundadır.
//Entitylerde oluşturduğumuz cross table entitysi ile bire çok bir ilişki kurulmalı.
//Cross table da composite primary key'i data annotation(attributes)lar ile manuel kuramıyoruz. Bunun için de Fluent API'da çalışma yapmamız gerekiyor.
//Cross table'a karşılık bir entity modeli oluşturuyorsak eğer bunu context sınıfı içerisinde DbSet property'si olarak bildirmek mecburiyetinde değiliz. 
//class Book
//{
//    public int Id { get; set; }
//    public string BookName { get; set; }

//    public ICollection<BookAuthor> Authors { get; set; }
//}

//class BookAuthor
//{
//    public int BookId { get; set; }
//    public int AuthorId { get; set; }

//    public Book Book { get; set; }
//    public Author Author { get; set; }
//}

//class Author
//{
//    public int Id { get; set; }
//    public string AuthorName { get; set; }

//    public ICollection<BookAuthor> Books { get; set; }
//}

//class EBookDbContext : DbContext
//{
//    public DbSet<Book> Books { get; set; }
//    public DbSet<Author> Authors { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        base.OnConfiguring(optionsBuilder);
//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<BookAuthor>()
//            .HasKey(e =>  new {e.BookId, e.AuthorId});
//    }
//}
#endregion

#region Fluent API
//Cross table manuel oluşturulmalı
//DbSet olrak eklenmesine lüzum yok
//Composite PK Haskey metodu ile kurulmalı!
class Book
{
    public int Id { get; set; }
    public string BookName { get; set; }

    public ICollection<BookAuthor> Authors { get; set; }
}

class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }

    public Book Book { get; set; }
    public Author Author { get; set; }
}

class Author
{
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<BookAuthor> Books { get; set; }
}

class EBookDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(e => new { e.BookId, e.AuthorId }); //composite primary key olduğunu bildirdik.

        modelBuilder.Entity<BookAuthor>()
            .HasOne(e => e.Book)
            .WithMany(e => e.Authors)
            .HasForeignKey(e => e.BookId);

        modelBuilder.Entity<BookAuthor>()
           .HasOne(e => e.Author)
           .WithMany(e => e.Books)
           .HasForeignKey(e => e.AuthorId);

    }
}
#endregion
