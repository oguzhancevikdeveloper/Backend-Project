# Lena Yazılım Backend_Case

## Proje Hakkında

**Lena Yazılıma Backend Case**, kullanıcıların kayıt olup giriş yaparak formlar oluşturabildiği, arama yapabildiği ve detaylarını görüntüleyebildiği bir uygulamadır. Giriş yapmadan, giriş gerektiren sayfalara erişim sağlanamamaktadır.

## Gereksinimler

- .NET Core SDK
- SQL Server (MSSQL)
- Bootstrap ve jQuery (ön uç için)

## Kurulum

1. **.NET Core SDK** bilgisayarınıza yüklü olmalıdır.
2. Projeyi klonlayın:
   ```bash
   git clone <repo-url>
3. Appsettings.json dosyasında ConnectionString kısmını kendi veritabanınıza göre düzenleyin.
4. Projeyi başlattığınızda, migration işlemi otomatik olarak yapılacaktır.


## Kullanım Adımları
1. Kayıt Olma: Kullanıcı, formda belirtilen bilgileri doldurarak kayıt olabilir.
2. Giriş Yapma: Kayıt sırasında verilen bilgilerle giriş yapılır.
3. Form İşlemleri:
 * Form Listesi: Giriş yapan kullanıcı formların listelendiği sayfaya yönlendirilir.
 * Form Oluşturma: Yeni bir form ekleyebilir.
 * Form Detayları: Belirli bir formun detaylarına göz atabilir.

## API Uç Noktaları
* Register: /User/Register - Kullanıcı kaydı yapar.
* Login: /User/Login - Kullanıcı giriş yapar.
* Form Create: /FormManagement/Create - Yeni bir form oluşturur.
* Form Get: /FormManagement - Kullanıcının formlarını listeler.
* Form Detail: /FormManagement/Details/1 - Belirli bir formun detaylarına erişir.

## Teknolojiler
1. Entity Framework Core: Veritabanı işlemleri için kullanılmıştır.
2. Bootstrap & jQuery: Ön uç için stil ve dinamik işlevler sağlar.

## Notlar
* Giriş yapılmadan, giriş gerektiren sayfalara erişim sağlanamamaktadır.

