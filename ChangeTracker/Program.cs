﻿using ChangeTracker.Contexts;
using ChangeTracker.Entities;
using Microsoft.EntityFrameworkCore;

NorthwindContext context = new NorthwindContext();
#region Change Tracking Nedir?
//Context nesnesi üzerinden gelen tüm nesneler/veriler otomatik olarak bir takip mekanizması tarafından izlenirler.
//İşte bu takip mekanizmasına Change Tracker denir. Change tracker ile nesneler üzerindeki değişiklikler/işlemler takip edilerek
//netice itibariyle bu işlemlerin fıtratına uygun sql sorgucukları generate edilir. İşte bu işleme de Change Tracking denir. 
#endregion

#region ChangeTracker Propertysi
//Takip edilen nesnelere erişebilmemizi sağlayan ve gerektirdiği taktirde gerçekleştirmemizi sağlayan bir propertydir.
//Context sınıfının base class'ı olan DbContext sınıfının bir member'ıdır.

//var products = await context.Products.ToListAsync();
//products[6].UnitPrice = 123; //update
//context.Products.Remove(products[7]); //delete
//products[8].ProductName = "Kalem"; //update

//var datas = context.ChangeTracker.Entries(); //Takip edilen tüm nesneleri getirir

//await context.SaveChangesAsync();
#endregion

#region DetectChanges Metodu
//Ef Core, context nesnesi tarafından izlenen tüm nesnelerdeki değişiklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan
//verisel değişiklikler yakalanarak bunların anlık görüntüleri(snapshot)'ini oluşturabilir.
//Yapılan değişikliklerin veritabanına gönderilmeden önce algılandığından emin olmak gerekir.SaveChanges fonksiyonı çağrıldığı anda
//nesneler Ef Core tarafından otomatik kontrol edilirler.
//Ancak yapılan operasyonlarda güncel tracking verilerinden emin olabilmek için değişikliklerin algılanmasını opsiyonel olarak gerçekleştirmek
//isteyebiliriz. İşte bunun için DetectChanges fonksiyonu kullanılabilir ve her ne kadar Ef Core değişiklikleri otomatik algılıyor olsa da siz
//yine de iradenizle kontrole zorlayabilirsiniz.

//var products = await context.Products.FirstOrDefaultAsync(p => p.ProductId == 3);
//products.UnitPrice = 345;

//context.ChangeTracker.DetectChanges();
//await context.SaveChangesAsync();
#endregion

#region AutoDetectChangesEnabled Property'si
//İlgili metotlar(SaveChanges, Entries) tarafından DetectChanges metodunun otomatik olarak tetiklenmesinin konfigürasyonunu yapmamızı
//sağlayan property'dir.
//SaveChanges fonksiyonu tetiklendiğinde DetectChanges metodunu içerisinde default olarak çağırmaktadır. Bu durumda DetectChanges fonksiyonunun
//kullanımını irademizle yönetmek ve maliyet/performans optimizasyonu yapmak istediğimiz durumlarda AutoDetectChangesEnabled özelliğini kapatabiliriz.
#endregion

#region Entries Metodu
//Context'te ki Entry metodunun koleksiyonel versiyonudur.
//ChangeTracker mekanizması tarafından izlenen her entity nesnesinin bilgisini EntityEntry türünden elde etmemizi sağlar ve belirli işlemler yapabilmemize olanak tanır.
//Entries metodu, DetectChanges metodunu tetikler. Bu durumda tıpkı SaveChanges'da olduğu gibi bir maliyettir. Buradaki maliyetten kaçınmak için AutoDetectChangesEnabled özelliğine false değeri verilebilir.

//var products = await context.Products.ToListAsync();
//products.FirstOrDefault(p => p.ProductId == 6).UnitPrice = 123;
//context.Products.Remove(products.FirstOrDefault(p => p.ProductId == 7));
//products.FirstOrDefault(p => p.ProductId == 6).ProductName = "Halı";

//context.ChangeTracker.Entries().ToList().ForEach(e =>
//{
//    if (e.State == EntityState.Unchanged) { }
//    else if (e.State == EntityState.Deleted) { }
//    else { }
//});
#endregion

#region AcceptAllChanges Metodu
//SaveChanges() veya SaveChanges(true) tetiklendiğinde EfCore her şeyin yolunda olduğunu varsayarak track ettiği verilerin takibini keser yeni değişikliklerin takip edilmesini bekler. Böyle bir durumda beklenmeyen bir durum/olası bir hata söz konusu olursa eğer EfCore takip ettiği nesneleri bırakacağı için bir düzeltme mevzu bahis olamayacaktır.
//SaveChanges(False), EfCore'a gerekli veritabanı komutlarını yürütmesini sağlar ancak gerektiğinde yeniden oynatılabilmesi için değişiklikleri beklemeye/nesneleri takip etmeye devam eder.Ta ki AcceptAllChanges metodunu irademizle çağırana kadar.
//SaveChanges(false) ile işlemin başarılı olduğundan emin olursanız AcceptAllChanges metodu ile nesnelerden takibi kesebiliriz.
//var products = await context.Products.ToListAsync();
//products.FirstOrDefault(p => p.ProductId == 6).UnitPrice = 123;
//context.Products.Remove(products.FirstOrDefault(p => p.ProductId == 7));
//products.FirstOrDefault(p => p.ProductId == 6).ProductName = "Halı";

//await context.SaveChangesAsync();
//await context.SaveChangesAsync(true);
//await context.SaveChangesAsync(false); //Burada takip edilen veriler bırakılmıyor başarılı olsa da başarısız olsada
//                                       //AcceptAllChanges ise takip edilen verilerin bırakılmasını sağlar.
//                                       //trueda zaten default olarak AcceptAllChanges kullanılıyor.
//context.ChangeTracker.AcceptAllChanges();
#endregion

#region HasChanges Metodu
//Takip edilen nesneler arasından değişiklik yapılanların olup olmadığının bilgisini verir.
//Arkaplanda DetectChanges metodunu tetikler.
//context.ChangeTracker.HasChanges(); //bool
#endregion

#region Entity States
//Entity nesnelerinin durumlarını ifade eder.
#region Detached
//Nesnenin changeTracker mekanizması tarafından takip edilmediğini ifade eder.
//Product product = new(); //context'ten gelmediği için takip edilmez.
//Console.WriteLine(context.Entry(product).State);
#endregion
#region Added
//Veritabanına eklenecek nesneyi ifade ede. Added henüz veritabanına işlenmeyen veriyi ifade eder.SaveChanges fonksiyonu çağrıldığında insert sorgusu oluşturulacağı anlamına gelir.
//Product product = new() { UnitPrice = 234, ProductName="Yeni Ürün"}; 
//Console.WriteLine(context.Entry(product).State);
//await context.Products.AddAsync(product);
//Console.WriteLine(context.Entry(product).State);
//await context.SaveChangesAsync();
#endregion
#region Unchanged
//Veritabanından sorgulandığından beri nesne üzerinde herhangi bir değişiklik yapılmadığını ifade eder. Sorgu neticesinde elde edilen tüm nesneler başlangıçta bu state değerindedir.
//var products = await context.Products.ToListAsync();
//var data = context.ChangeTracker.Entries();
#endregion
#region Modified
//Nesne üzerinde değişiklik/güncelleme yapıldığını ifade eder. SaveChanges fonksiyonu çağrıldığında update sorgusu oluşturulacağı anlamına gelir.
//var product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == 5);
//product.ProductName = "New Name";
//Console.WriteLine(context.Entry(product).State); //Modified
//await context.SaveChangesAsync();
//Console.WriteLine(context.Entry(product).State); //Unchanged
//Eğer SaveChanges'ı false parametreli çağırmış olsaydık iki durumda da modified yazacaktı takip etmeyi bırakmadığı için.
#endregion
#region Deleted
//Nesnenin silindiğini ifade eder. SaveChanges fonksiyonu çağrıldığında delete sorgusu oluşturulacağı anlamına gelir.
//var product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == 5);
//context.Products.Remove(product);
//Console.WriteLine(context.Entry(product).State);
//context.SaveChangesAsync();
#endregion
#endregion

#region Context nesnesi üzerinden change tracker
//var product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == 5);
//product.ProductName = "New Name";
//product.UnitPrice = 123;

#region OriginalValues Property'si
//var unitPrice = context.Entry(product).OriginalValues.GetValue<decimal?>(nameof(Product.UnitPrice));
//var productName = context.Entry(product).OriginalValues.GetValue<string>(nameof(Product.ProductName));
//Console.WriteLine(unitPrice + " " + productName);
#endregion
#region CurrentValues Property'si
//var productName = context.Entry(product).CurrentValues.GetValue<string>(nameof(Product.ProductName));
//Console.WriteLine(productName);
#endregion
#region GetDatabaseValues Metodu
//var products = await context.Entry(product).GetDatabaseValuesAsync();
//var entityType = products.EntityType;
//Console.WriteLine(entityType);
#endregion
#endregion

