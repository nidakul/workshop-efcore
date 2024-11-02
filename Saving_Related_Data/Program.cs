using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

Console.WriteLine();

#region One to One İlişkisel Senaryolarda Veri Ekleme
//CompanyDbContext context = new();

#region 1. Yöntem -> Principal Entity Üzerinden Dependent Entity Verisi Ekleme
//Employee employee = new();
//employee.Name = "Nida";
//employee.EmployeeAddress = new() { Address = "Battalgazi/Malatya" };

//await context.AddAsync(employee);
//await context.SaveChangesAsync();
#endregion

//Eğer ki principal entity üzerinden ekleme gerçekleştiriliyorsa dependent entity nesnesi verilmek zorunda değildir! Ama dependent entity üzerinden ekleme işlemi gerçekleştiriliyorsa burada principal entitynin nesnesine ihtiyacımız vardır.

#region 2. Yöntem -> Dependent Entity Üzerinden Principal Entity Verisi Ekleme
//EmployeeAddress employeeAddress = new()
//{
//    Address = "Yeşilyurt/Malatya",
//    Employee = new() { Name = "Zehra" } 
//};
//await context.AddAsync(employeeAddress);
//await context.SaveChangesAsync();
#endregion


//class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }

//    public EmployeeAddress EmployeeAddress { get; set; }
//}
//class EmployeeAddress
//{
//    [Key, ForeignKey(nameof(Employee))]
//    public int Id { get; set; } 
//    public string Address { get; set; }
//    public Employee Employee { get; set; }
//}
//class CompanyDbContext : DbContext
//{
//    public DbSet<Employee> Employees { get; set; }
//    public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=localhost;Database=EfCore;User Id=SA;Password=rentacardb;TrustServerCertificate=true");
//    }
//    //Model'ların(entity) veritabanında generate edilecek yapıları konfigürasyonları bu fonksiyon içerisinde konfigüre edilir.
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<EmployeeAddress>()
//            .HasKey(e => e.Id);//Address'in içindeki id primary key

//        modelBuilder.Entity<Employee>()
//            .HasOne(e => e.EmployeeAddress) //Adrese birebir ilişki kuracağım
//            .WithOne(e => e.Employee)
//            .HasForeignKey<EmployeeAddress>(e => e.Id); //Address'in içindeki id foreign key
//    }
//}
#endregion

#region One to Many İlişkisel Senaryolarda Veri Ekleme
BlogDbContext context = new();
#region 1. Yöntem -> Principal Entity Üzerinden Dependent Entity Verisi Ekleme
#endregion
class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}
class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; } 
    public string Title { get; set; }

    public Blog Blog { get; set; }
}

class BlogDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=EfCore;User Id=SA;Password=rentacardb;TrustServerCertificate=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Post>()
            .HasOne(e => e.Blog)
            .WithMany(e => e.Posts);
    }
}
#endregion



