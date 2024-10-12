#region Update Data
using Microsoft.EntityFrameworkCore;
using Persisting_The_Data_Update.Contexts;
using Persisting_The_Data_Update.Entities;

NorthwindContext context = new();
Product product = await context.Products.FirstOrDefaultAsync(u => u.ProductId == 3);
product.ProductName = "H Ürünü";
product.UnitPrice = 999;

await context.SaveChangesAsync();
#endregion