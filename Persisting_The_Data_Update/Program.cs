using Persisting_The_Data_Update.Contexts;
using Persisting_The_Data_Update.Entities;

NorthwindContext context = new NorthwindContext();

#region Update Data
//using Microsoft.EntityFrameworkCore;
//using Persisting_The_Data_Update.Contexts;
//using Persisting_The_Data_Update.Entities;

//ChangeTracker context üzerinden gelen verilerin takibinden sorumlu olan bir mekanizmadır. Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemler neticesinde update veya delete sorgularının oluşturulacağı anlaşılır.
//Product product = await context.Products.FirstOrDefaultAsync(u => u.ProductId == 3);
//product.ProductName = "H Ürünü";
//product.UnitPrice = 999;

//await context.SaveChangesAsync();
#endregion

#region Takip edilmeyen nesneyi güncelleme
//ChangeTracker mekanizması tarafından takip edilmeyen nesnelerin güncellenebilmesi içi nUpdate fonksiyonu kullanılır.
//Product product = new() 
//{
//    ProductId = 3,
//    ProductName = "Yeni Ürün",
//    UnitPrice = 123
//};
//context.Products.Update(product);
//await context.SaveChangesAsync();
#endregion

#region Entity State
//Bir entity instance’ının durumunu ifade eden referanstır. 
//Product product = new Product();
//Console.WriteLine(context.Entry(product).State); //Detached (en sade hali. Bir işleme tabi tutulmamış)
#endregion

