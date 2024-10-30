using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

Console.WriteLine();

#region One to One İlişkisel Senaryolarda Veri Ekleme
#region 1. Yöntem -> Principal Entity Üzerinden Denpendent Entity Verisi Ekleme


#endregion
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public EmployeeAddress EmployeeAddress { get; set; }
}
class EmployeeAddress
{
    [Key, ForeignKey(nameof(Employee))]
    public int Id { get; set; }
    public string Address { get; set; }
    public Employee Employee { get; set; }
}
class CompanyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    //Model'ların(entity) veritabanında generate edilecek yapıları konfigürasyonları bu fonksiyon içerisinde konfigüre edilir.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeAddress>()
            .HasKey(e => e.Id);//Address'in içindeki id primary key

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.EmployeeAddress) //Adrese birebir ilişki kuracağım
            .WithOne(e => e.Employee)
            .HasForeignKey<EmployeeAddress>(e => e.Id); //Address'in içindeki id foreign key
    }
}
#endregion


