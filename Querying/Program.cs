using Microsoft.EntityFrameworkCore;
using Querying.Contexts;
using Querying.Entities;

NorthwindContext context = new NorthwindContext();

#region En temel sorgulama
#region Method Syntax
//List<Product> products = await context.Products.ToListAsync();
//foreach(Product product in products)
//{
//Console.WriteLine(product.ProductName); 
//}
#endregion
#region Query Syntax
//List<Product> products = await (from product in context.Products
//                          select product).ToListAsync();
//foreach(Product p in products)
//Console.WriteLine(p.ProductName);
#endregion
#endregion

#region Deferred Execution(Ertelenmiş Çalışma)
//Burada verileri productId = 200'e göre getirir.
int productId = 5;
string productName = "rd";
var products = from product in context.Products
               where product.ProductId > productId && product.ProductName.Contains(productName)
               select product;
productId = 200;
productName = "st";
foreach (Product p in products)
{
    Console.WriteLine(p.ProductName + " => " + p.ProductId);
}
#endregion 