using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

Console.WriteLine();

#region Default Convention
//Default Convention yönteminde bire çok ilişkiyi kurarken foreign key kolonuna karşılık gelen bir property tanımlamak mecburiyetinde değiliz. Eğer tanımlamazsak EfCore bunu kendisi tamamlayacak yok eğer tanımlarsak tanımladığımızı baz alacak.
//class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; } 

//    public EmployeeDepartment EmployeeDepartment { get; set; }
//}
//class EmployeeDepartment
//{
//    public int Id { get; set; }
//    public string Address { get; set; }

//    public ICollection<Employee> Employees { get; set; }
//}
#endregion

#region Data Annotations
//Bu yöntemde foreign key kolonuna karşılık gelen property'i tanımladığımızda bu property ismi temel geleneksel entity tanımlama kurallarına uymuyorsa eğer Data Annotations'lar ile müdahalede bulunabiliriz.
//class Employee
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(EmployeeDepartment))]
//    public int DId { get; set; }
//    public string Name { get; set; }

//    public EmployeeDepartment EmployeeDepartment { get; set; }
//}
//class EmployeeDepartment
//{
//    public int Id { get; set; }
//    public string Address { get; set; }

//    public ICollection<Employee> Employees { get; set; }
//}
#endregion

#region Fluent API
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public EmployeeDepartment EmployeeDepartment { get; set; }
}
class EmployeeDepartment
{
    public int Id { get; set; }
    public string Address { get; set; }

    public ICollection<Employee> Employees { get; set; }
}

class CompanyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.EmployeeDepartment)
            .WithMany(e => e.Employees);
    }
}
#endregion

