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
//int productId = 5;
//string productName = "rd";
//var products = from product in context.Products
//               where product.ProductId > productId && product.ProductName.Contains(productName)
//               select product;
//productId = 200;
//productName = "st";
//foreach (Product p in products)
//{ 
//    Console.WriteLine(p.ProductName + " => " + p.ProductId);
//}
#endregion

#region Çoğul veri getiren sorgulama fonksiyonları
#region ToListAsync
#region Method Syntax
//var products = await context.Products.ToListAsync();
#endregion
#region Query Syntax
//var products = await (from product in context.Products
//                select product).ToListAsync();
#endregion
#endregion
#region Where
#region Method Syntax
//var products = await context.Products.Where(p => p.ProductName.StartsWith("a")).ToListAsync();
#endregion
#region Query Syntax
//var products = await (from product in context.Products
//                      where product.UnitPrice > 500 && product.ProductName.EndsWith("k")
//                      select product).ToListAsync();
#endregion
#endregion
#region OrderBy
#region Method Syntax
//var products = context.Products.Where(p => p.ProductId > 500 || p.ProductName.EndsWith("r")).OrderBy(p => p.ProductName);
#endregion
#region Query Syntax
//var products = await (from product in context.Products
//                      where product.ProductId > 500 || product.ProductName.StartsWith("e")
//                      orderby product.ProductName
//                      select product).ToListAsync();

#endregion
#endregion
#region ThenBy
//OrderBy üzerinde yapılan sıralama işlemini farklı kolonlarada uygulamamızı sağlayan bir fonksiyondur. 
#region Method Syntax
//var products = await context.Products.Where(p => p.ProductId > 500 || p.ProductName.EndsWith("r"))
//    .OrderBy(p => p.ProductName)
//    .ThenBy(p => p.UnitPrice)
//    .ThenBy(p => p.ProductId).ToListAsync();
#endregion
#endregion
#region OrderByDescending
#region Method Syntax
//var products = await context.Products.OrderByDescending(p => p.UnitPrice).ToListAsync();
#endregion
#region Query Syntax 
//var products = await (from p in context.Products
//                      orderby p.ProductName descending
//                      select p).ToListAsync(); 
#endregion
#endregion
#region ThenByDescending
#region Method Syntax
//var products = context.Products.OrderByDescending(p => p.ProductId).ThenByDescending(p => p.UnitPrice)
//    .ThenBy(p => p.ProductName).ToListAsync();
#endregion
#endregion
#endregion

#region Tekil veri getiren sorgulama fonksiyonları
#region SingleAsync
//Yapılan sorgu neticesinde birden fazla veri geliyorsa ya da hiç gelmiyorsa her iki durumda da exception fırlatır.
#region Tek veri geldiğinde
//var product = await context.Products.SingleAsync(p => p.ProductId == 4);
//Console.WriteLine(product.ProductId + " => " + product.ProductName);
#endregion
#region Hiç veri gelmediğinde
var product = await context.Products.SingleAsync(p => p.ProductName.Contains("nfklkdfsmlkmsl"));
Console.WriteLine(product.ProductName);
#endregion
#region Çok kayıt geldiğinde
//var product = await context.Products.SingleAsync(p => p.CategoryId == 3);
//Console.WriteLine(product.CategoryId);
//#endregion
#endregion
#endregion

#region SingleOrDefaultAsync
//Yapılan sorgu neticesinde birden fazla veri geliyorsa exception fırlatır, hiç veri gelmiyorsa null döner.
#endregion
#endregion
