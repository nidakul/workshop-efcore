using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello, World!");


public class ECommerce : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Provider
        //ConnectionString
        //LazyLoading
        optionsBuilder.UseSqlServer("Server = localhost; Database = ECommerceDb; User Id = SA; Password = rentacardb; TrustServerCertificate=true");
    }
}

public class Product
{
    //ef core default primary keys
    //public int Id { get; set; } 
    //public int ID { get; set; }
    //public int ProductId { get; set; }
    public int ProductID { get; set; }
}
