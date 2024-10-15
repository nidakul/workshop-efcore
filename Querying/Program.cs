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
//var product = await context.Products.SingleAsync(p => p.ProductName.Contains("nfklkdfsmlkmsl"));
//Console.WriteLine(product.ProductName);
#endregion
#region Çok kayıt geldiğinde
//var product = await context.Products.SingleAsync(p => p.CategoryId == 3);
//Console.WriteLine(product.CategoryId);
//#endregion
#endregion
#endregion
#region SingleOrDefaultAsync
//Yapılan sorgu neticesinde birden fazla veri geliyorsa exception fırlatır, hiç veri gelmiyorsa null döner.
#region Tek veri geldiğinde
//var product = await context.Products.SingleOrDefaultAsync(p => p.ProductId == 4);
//Console.WriteLine(product.ProductId + " => " + product.ProductName);
#endregion
#region Hiç veri gelmediğinde
//var product = await context.Products.SingleOrDefaultAsync(p => p.ProductName.Contains("nfklkdfsmlkmsl"));
//Console.WriteLine(product);
#endregion
#region Çok kayıt geldiğinde
//var product = await context.Products.SingleOrDefaultAsync(p => p.CategoryId == 3);
//Console.WriteLine(product.CategoryId);
//#endregion
#endregion
#endregion
#region FirstAsync
//Yapılan sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa hata fırlatır.
#region Tek veri geldiğinde
//var product = await context.Products.FirstAsync(p => p.ProductId == 4);
//Console.WriteLine(product.ProductId + " => " + product.ProductName);
#endregion
#region Hiç veri gelmediğinde
//var product = await context.Products.FirstAsync(p => p.ProductName.Contains("nfklkdfsmlkmsl"));
//Console.WriteLine(product);
#endregion
#region Çok kayıt geldiğinde
//var product = await context.Products.FirstAsync(p => p.CategoryId == 3);
//Console.WriteLine(product.CategoryId);
//#endregion
#endregion
#endregion
#region FirstOrDefaultAsync
//Sorgu neticesinde elde edilen verilerden ilkini getirir. Eper ki hiç veri gelmiyorsa null değerini döndürür.
#region Tek veri geldiğinde
//var product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == 4);
//Console.WriteLine(product.ProductId + " => " + product.ProductName);
#endregion
#region Hiç veri gelmediğinde
//var product = await context.Products.FirstOrDefaultAsync(p => p.ProductName.Contains("nfklkdfsmlkmsl"));
//Console.WriteLine(product);
#endregion
#region Çok kayıt geldiğinde
//var product = await context.Products.FirstOrDefaultAsync(p => p.CategoryId == 3);
//Console.WriteLine(product.CategoryId);
//#endregion
#endregion
#endregion
#region FindAsync
//Primary key kolonuna özel hızlı bir şekilde sorgulama yapmamızı sağlayan fonksiyondur.
//Product product = await context.Products.FindAsync(3);
//Console.WriteLine(product.ProductName + " => " + product.ProductId);

#region Composite Primary Key Durumu
//Product product = await context.Products.FindAsync(2, 5);
#endregion
#endregion
#region LastAsync
//Dönen verilerin sonuncusunu alır. OrderBy ile kullanılmalı
//Product product = await context.Products.OrderBy(p => p.ProductId).LastAsync(p => p.ProductId < 40);
//Console.WriteLine(product.ProductId);
#endregion
#region LastOrDefaultAsync
//Product product = await context.Products.OrderBy(p => p.ProductId).LastOrDefaultAsync(p => p.ProductId < 40);
//Console.WriteLine(product.ProductId);
#endregion
#endregion

#region Diğer Sorgulama Fonksiyonları
#region CountAsync
//maliyetli bir süreç aşağıdaki örnek. Çünkü toListAsync deyip liste şeklinde verileri aldık belleğe yükledik.
//Belleğe yükledikten sonra count'unu aldık. Bu tarz durumlarda IQueryable ile çalışmak daha mantıklı IEnumerable yapmaya gerek yok.
//int product = (await context.Products.ToListAsync()).Count();
//Console.WriteLine(product);

//Aşağıdaki kod daha mantıklı maliyet açısından. Veritabanında direkt count'u alıp o şekilde döner bize sonucu.
//int count = await context.Products.CountAsync();
//Console.WriteLine(count);
#endregion
#region LongCountAsync
//long count = await context.Products.LongCountAsync(p => p.CategoryId == 4);
//Console.WriteLine(count);
#endregion
#region AnyAsync
//Sorgu neticesinde verinin gelip gelmediğini bool türünde dönen fonksiyondur.
//bool product = await context.Products.AnyAsync(p => p.ProductName == "Bardak");
//bool product2 = await context.Products.Where(p => p.ProductName.Contains("Bardak")).AnyAsync();
//bool product3 = await context.Products.AnyAsync();
//Console.WriteLine(product2);
#endregion
#region MaxAsync
//decimal? unitPrice = await context.Products.MaxAsync(p => p.UnitPrice);
//Console.WriteLine(unitPrice);
#endregion
#region MinAsync
decimal? unitPrice = await context.Products.MinAsync(p => p.UnitPrice);
Console.WriteLine(unitPrice);
#endregion
#endregion