using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

Console.WriteLine();

#region Default Convention
//Her iki entity de navigation property ile birbirlerini tekil olarak referans edererk fiziksel bir ilişkinin olacağı ifade edilir.
//One to one ilişki türünde, dependent entity'nin hangisi olduğunu default olarak belirleyebilmek pek kolay değildir. Bu durumda fiziksel olarak bir foreign key'e karşılık property'kolon tanımlayarak çözüm getirebiliyoruz.
//Böylece foreign key'e karşılık property tanımlayarak lüzumsuz bir kolon oluşturmuş oluyoruz.
//class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public EmployeeAddress EmployeeAddress { get; set; }
//}
//class EmployeeAddress
//{
//    public int Id { get; set; }
//    public int EmployeeId { get; set; }
//    public string  Address { get; set; }
//    public Employee Employee { get; set; }
//}
#endregion

#region Data Annotations
//Navigation Property'ler tanımlanmalıdır.
//Foreign kolonunun ismi default convention'ın dışında bir kolon olacaksa eğer foreign key attribute ile bunu bildirebiliriz.
//Foreign key kolonu oluşturulmak zorunda değildir.
//1'e 1 ilişkide ekstradan foreign key kolonuna ihtiyaç olmayacağından dolayı dependent entity'deki id kolonunun hem foreign key hem de primary key olarak kullanmayı tercih ediyoruz ve bu duruma özen gesterilir diyoruz.

//with Foreign Key
//class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }

//    public EmployeeAddress EmployeeAddress { get; set; }
//}
//class EmployeeAddress
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(Employee))]
//    public int EmployeeId { get; set; }
//    public string Address { get; set; }

//    public Employee Employee { get; set; }
//}
//without Foreign Key
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
#endregion

#region Fluent API
//Navigation Property'ler tanımlanmalıdır.
//Fluent API yönteminde entityler arasındaki ilişki context sınıfı içerisinde OnModelCreating fonksiyonunun override edilerek metotler aracılığıyla tasarlanması gerekmektedir. Yani tüm sorumluluk bu fonksiyon içerisindeki çalışmalardadır.
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