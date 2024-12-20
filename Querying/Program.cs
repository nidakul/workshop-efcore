﻿using Microsoft.EntityFrameworkCore;
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
//decimal? unitPrice = await context.Products.MinAsync(p => p.UnitPrice);
//Console.WriteLine(unitPrice);
#endregion
#region Distinct
//Tekrarlı kayıtları tekilleştirir. ToListAsync ile kullanılır.
//List<Product> products = await context.Products.Distinct().ToListAsync();
//foreach(Product product in products)
//{
//Console.WriteLine(product.ProductName);
//}
#endregion
#region AllAsync
//Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true,
//uymuyorsa false dönecektir.
//bool isBig = await context.Products.AllAsync(p => p.UnitPrice > 100);
//Console.WriteLine(isBig);
#endregion
#region SumAsync
//decimal? unitPrice = await context.Products.SumAsync(p => p.UnitPrice);
//Console.WriteLine(unitPrice);
#endregion
#region AverageAsync
//decimal? avg = await context.Products.AverageAsync(a => a.UnitPrice);
//Console.WriteLine(avg);
#endregion
#region ContainsAsync
//Like '%...% sorgusu oluşturmamızı sağlar.Where ile kullanıyoruz.
//Where şartı içinde Contains'i görünce efcore bunun like sorgusu olduğunu anlayacaktır
//List<Product> products = await context.Products.Where(p => p.ProductName.Contains("rd")).ToListAsync();
//foreach (Product p in products)
//{
//Console.WriteLine(p.ProductName);
//}
#endregion
#region StartsWith
//Like '...%' sorgusu oluşturmamızı sağlar.
//List<Product> products = await context.Products.Where(p => p.ProductName.StartsWith("a")).ToListAsync();
//foreach (Product product in products)
//{
//    Console.WriteLine(product.ProductName);
//}
#endregion
#region EndsWith
//Like '%...' sorgusu oluşturmamızı sağlar.
//List<Product> products = await context.Products.Where(p => p.ProductName.EndsWith("e")).ToListAsync();
//foreach (Product product in products)
//{
//    Console.WriteLine(product.ProductName);
//}
#endregion
#endregion

#region Sorgu Sonucu Dönüşüm Fonksiyonları
#region ToDictionaryAsync
//Sorgu neticesinde gelecek olan veriyi bir dictionary olarak elde etmek/tutmak/karşılamak istiyorsak kullanılır.
//ToList ile aynı amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırla.
//ToList: Gelen sorgu nticesini entity türünde bir koleksiyona(List<TEntity>) dönüştürmekteyken,
//ToDictionary: Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
//Dictionary<string,decimal?> products = await context.Products.ToDictionaryAsync(p => p.ProductName, p => p.UnitPrice);
//foreach(KeyValuePair<string,decimal?> p in products)
//{
//Console.WriteLine($"Product name: {p.Key}, UnitPrice: {p.Value}");
//}
#endregion
#region ToArrayAsync
//Product[] product = await context.Products.ToArrayAsync();
//foreach (Product p in product)
//{
//    Console.WriteLine(p.ProductName);
//}
#endregion
#region Select
//Generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır.
//IQueryable<Product> products =  context.Products.Select(p => new Product
//{
//    ProductId = p.ProductId,
//    UnitPrice = p.UnitPrice
//});
//foreach (Product p in products)
//{
//    Console.WriteLine($"Id: {p.UnitPrice}, UnitPrice {p.UnitPrice}");
//}

//Select fonksiyonu gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim
//var products = context.Products.Select(p => new
//{
//    Id = p.ProductId,
//    UnitPrice = p.UnitPrice
//});
//foreach (var p in products)
//{
//    Console.WriteLine($"Id: {p.UnitPrice}, UnitPrice {p.UnitPrice}");
//}

//veya aşağıdaki gibi bir yaklaşım sergileyebiliriz
//List<ProductDetail> productDetails = await context.Products.Select(p => new ProductDetail
//{
//    Id = p.ProductId,
//    UnitPrice = p.UnitPrice 
//}).ToListAsync();

//foreach (ProductDetail p in productDetails)
//{
//    Console.WriteLine($"Id: {p.UnitPrice}, UnitPrice {p.UnitPrice}");
//}

//public class ProductDetail
//{
//    public int Id { get; set; } 
//    public decimal? UnitPrice { get; set; }
//}
#endregion
#region SelectMany
//Select ile aynı amaca hizmet eder. lakin, ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon
//etmemizi sağlar.
//var productDetails = await context.Products.Include(p => p.OrderDetails).SelectMany(p => p.OrderDetails, (pr, o) => new
//{
//   pr.ProductId,
//   pr.ProductName,
//   o.Quantity
//}).ToListAsync();

//foreach (var p in productDetails)
//{
//    Console.WriteLine($"Id: {p.ProductId}, Name {p.ProductName} Quantity {p.Quantity}");
//}

#endregion
#endregion

#region Group By
#region Method Syntax
//var datas = await context.Products.GroupBy(p => p.UnitPrice).Select(group => new
//{
//    Count = group.Count(),
//    UnitPrice = group.Key
//}).ToListAsync(); //UnitPrice'a göre gruplama işlemi gerçekleştir

//foreach (var data in datas)
//{
//    Console.WriteLine($"Count:{data.Count}, UnitPrice:{data.UnitPrice}");
//}
#endregion
#region Query Syntax
//var datas = await (from product in context.Products
//                   group product by product.UnitPrice
//                   into g
//             select new
//             {
//                 UnitPrice = g.Key,
//                 Count = g.Count()
//             }).ToListAsync();
#endregion
#endregion

#region Foreach
//Sorgulama fonksiyonu değildir!
//Sorgulama neticesinde elde edilen koleksiyonal veriler üzerinde iterasyonel olarak dönmemizi ve teker teker veriler elde edip
//işlemler yapabilmemizi sağlayan bir fonksiyondur. Foreach döngüsünün metot halidir.
var datas = await (from product in context.Products
                   group product by product.UnitPrice
                   into g
                   select new
                   {
                       UnitPrice = g.Key,
                       Count = g.Count()
                   }).ToListAsync();

datas.ForEach(x =>
{
    
});
#endregion