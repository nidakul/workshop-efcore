using Microsoft.EntityFrameworkCore;
using Persisting_The_Data_Delete.Contexts;
using Persisting_The_Data_Delete.Entities;

NorthwindContext context = new NorthwindContext();

#region Delete Data
//Product product = await context.Products.FirstOrDefaultAsync(u => u.ProductId == 5);
//context.Products.Remove(product);
//await context.SaveChangesAsync();
#endregion

#region Takip edilmeyen verileri silme
//Product product = new()
//{
//    ProductId = 2
//};
//context.Products.Remove(product);
//await context.SaveChangesAsync();
#endregion

#region Entity State ile silme
//Product product = new()
//{
//    ProductId = 2
//};
//context.Entry(product).State = EntityState.Deleted;
//await context.SaveChangesAsync();
#endregion

#region Remove Range
List<Product> products = await context.Products.Where(p => p.ProductId>=7 && p.ProductId <= 9).ToListAsync();
context.Products.RemoveRange(products);
await context.SaveChangesAsync();
#endregion
