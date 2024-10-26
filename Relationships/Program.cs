
Console.WriteLine();

#region Relationship(İlişkiler) Terimleri
#region Principal Entity(Asıl Entity)
//Kendi başına var olabilen tabloyu modelleyen entity'e denir.
#endregion
#region Dependent Entity(Bağımlı Entity)
//Kendi başına var olamayan, bir başka tabloya bağımlı(ilişkisel olarak bağımlı) olan tabloyu modelleyen entity'e denir.
#endregion
#region Foreign Key
//Principal Entity ile Dependent Entity arasındaki ilişkiyi sağlayan key'dir.
//Dependent Entity'de tanımlanır.
//Principal Entity'de ki Principal Key'i tutar.
#endregion
#region Principal Key
//Principal Entity'deki id'nin kendisidir. Principal Entity'nin kimliği olan kolonu ifade eden property'dir.
#endregion
#region Navigation Property
//İlişikisel tablolar arasındaki fiziksel erişimi entity class'ları üzerinden sağlayan property'lerdir.
//public Departman Departman {get;set;}
//public ICollection<Calisan> Calisanlar { get; set; }
//Bir property'nin navigation property olabilmesi için kesinlikler entity türünden olması gerekir.
//Navigation property'ler entitylerdeki tanımlarına göre n'e n yahut 1'e n şeklinde ilişki türlerini ifade etmektedirler.
#endregion
#endregion

#region İlişki Türleri
#region One to One
//Çalışan ile adresi arasındaki ilişki, karı koca arasındaki ilişki
#endregion
#region One to Many
//Çalışan ile departman arasındaki ilişki, anne ve çocukları arasındaki ilişki.
#endregion
#region Many to Many
//Çalışanlar ile projeler arasındaki ilişki, kardeşler arasındaki ilişki.
#endregion
#endregion

#region Entity Framework Core’da İlişki Yapılandırma Yöntemleri
#region Default Conventions
//Varsayılan entity kurallarını kullanarak yapılan ilişki yapılandırma yöntemleridir.
//Navigation property’leri kullanarak ilişki şablonlarını çıkarmaktadır.
#endregion
#region Data Annotations Attributes
//Entity’nin niteliklerine göre ince ayarlar yapmamızı sağlayan attribute’lardır. [Key], [ForeignKey]
#endregion
#region Fluent API
//Entity modellerindeki ilişkileri yapılandırırken daha detaylı çalışmamızı sağlayan yöntemdir.
#region HasOne
//İlgili entity'nin ilişkisel entity'e birebir ya da bire çok olacak şekilde ilişkisini yapılandırmaya başlayan metottur.
#endregion
#region HasMany
//İlgili entity'nin ilişkisel entity'e çoka bir ya da çoka çok olacak şekilde ilişkisini yapılandırmaya başlayan metottur.
#endregion
#region WithOne
//HasOne ya da HasMany'den sonra bire bir ya da çoka bir olcak şekilde ilişki yapılandırmasını tamamlayan metottur.
#endregion
#region WithMany
//HasOne ya da HasMany'den sonra bire çok ya da çoka çok olacak şekilde ilişki yapılandırmasını tamamlayan metottur.
#endregion
#endregion
#endregion