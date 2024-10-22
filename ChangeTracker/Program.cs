using ChangeTracker.Contexts;
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

var products = await context.Products.FirstOrDefaultAsync(p => p.ProductId == 3);
products.UnitPrice = 345;

context.ChangeTracker.DetectChanges();
await context.SaveChangesAsync();

#endregion