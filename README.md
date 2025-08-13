# 💇‍♂️ Kuaför Randevu Sistemi (ASP.NET Core MVC)

ASP.NET Core MVC ile geliştirilmiş, kuaför müşterilerinin kolayca randevu almasını sağlayan; işletme tarafında da randevu, hizmet ve yorum yönetimi sunan modern bir web uygulaması.

> **Durum:** Aktif geliştirme  
> **Ana teknoloji:** ASP.NET Core MVC 8.0  
> **Hedef:** Basit, güvenli ve genişletilebilir bir randevu altyapısı

---

## İçindekiler
- [Özellikler](#özellikler)
- [Ekranlar](#ekranlar)
- [Mimari ve Klasör Yapısı](#mimari-ve-klasör-yapısı)
- [Teknolojiler](#teknolojiler)
- [Kurulum](#kurulum)
- [Geliştirme Komutları](#geliştirme-komutları)
- [Yapılandırma (appsettingsjson)](#yapılandırma-appsettingsjson)
- [Rotalar / Uç Noktalar](#rotalar--uç-noktalar)
- [Güvenlik Notları](#güvenlik-notları)
- [Yol Haritası](#yol-haritası)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)

---

## Özellikler

- **Kullanıcı Girişi & Kayıt (Modal)**
  - Giriş modalı: logo, karşılama başlığı, kullanıcı adı/e-posta, şifre, *beni hatırla*, giriş butonu, şifre sıfırlama & kayıt bağlantıları
  - Kayıt modalı: ad, soyad, e‑posta, telefon, şifre, şifre tekrarı, kullanıcı sözleşmesi onayı, duyuru/teklif aboneliği, *kayıt ol* butonu
- **Randevu Yönetimi**
  - Ana sayfadaki **“Randevu Al”** butonu: oturum yoksa giriş/kayıt modallarını tetikler
  - Oturum açmış kullanıcılar: tarih, saat ve **dinamik hizmet** seçimiyle randevu oluşturur
  - Yönetici: randevu onay/red, geçmiş randevular, iptal nedenleri
- **Hizmetler**
  - Dinamik hizmet listesi (başlangıçta **Saç Kesimi**; genişletilebilir: Sakal, Boya, Bakım…)
  - Süre ve fiyat bilgisinin görüntülenmesi
- **Kullanıcı Yorumları**
  - Müşteri deneyimi paylaşımı
  - Admin onayı sonrası yayına alma
- **Arayüz**
  - _Layout.cshtml tabanlı, responsive, modern ve sade tema
  - Bölünebilir partial view yapısı (örn. hizmetler, yorumlar, randevu kartları)
  - (İsteğe bağlı) radio button filtreleriyle partial view güncellemeleri (AJAX)

---

## Ekranlar

- **Ana Sayfa (Home/Index)**  
  Hero bölümünde açıklama ve **Randevu Al** çağrısı; hizmetler ve kullanıcı yorumları dinamik kısımlar olarak listelenir.

- **Hesap (Account/Login – Account/Register)**  
  Giriş & kayıt modalları; oturum, şifre sıfırlama, e-posta doğrulama akışları.

- **Randevular (Appointments/Index & Create)**  
  Kullanıcı: randevu oluşturma ve geçmişini görme.  
  Yönetici: onay/red ve takvim görünümü.

---

## Mimari ve Klasör Yapısı

```text
├── Controllers
│   ├── HomeController.cs
│   ├── AccountController.cs
│   └── (ileride) AppointmentsController.cs, ServicesController.cs, AdminController.cs
│
├── Models
│   ├── ErrorViewModel.cs
│   └── (ileride) ApplicationUser.cs, Appointment.cs, Service.cs, Review.cs
│
├── Views
│   ├── Shared
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Home
│   │   └── Index.cshtml
│   ├── Account
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   └── (ileride) Appointments, Services, Admin
│
├── wwwroot
│   ├── css
│   │   └── site.css
│   ├── js
│   └── lib
│
├── Program.cs
├── appsettings.json
└── .gitignore
```

> Not: İlerleyen aşamalarda `Areas/Admin` yapısı, `ViewComponents` ve `Partial` bölümleri eklenecektir.

---

## Teknolojiler

- **Backend:** ASP.NET Core MVC 8.0, C#
- **Kimlik Doğrulama:** ASP.NET Identity
- **Veritabanı:** Microsoft SQL Server (LocalDB veya tam sürüm)
- **Ön Yüz:** HTML5, CSS3, JavaScript, Bootstrap 5
- **Araçlar:** .NET 8 SDK, Visual Studio/VS Code, Git
- **İsteğe bağlı:** EF Core Migrations, SMTP ile e‑posta bildirimleri

---

## Kurulum

### 1) Önkoşullar
- [.NET 8 SDK](https://dotnet.microsoft.com/)  
- SQL Server (LocalDB yeterlidir)  
- (Opsiyonel) EF Core CLI:  
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### 2) Depoyu klonlayın
```bash
git clone https://github.com/<kullanici-adi>/kuafor-randevu.git
cd kuafor-randevu
```

### 3) Bağımlılıkları yükleyin
```bash
dotnet restore
```

### 4) Veritabanı bağlantısını ayarlayın
`appsettings.json` içindeki `ConnectionStrings:DefaultConnection` değerini kendi SQL Server ayarınıza göre güncelleyin.

### 5) (Opsiyonel) İlk migration ve veritabanı
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

> Projeye hazır migration dosyaları dahilse sadece `database update` yeterlidir.

### 6) Çalıştırın
```bash
dotnet run
```
Tarayıcı: `http://localhost:5000` (veya konsolda belirtilen URL)

---

## Geliştirme Komutları

```bash
# Derleme
dotnet build

# Çalıştırma
dotnet run

# Test (eklenecek)
dotnet test

# EF Core
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

---

## Yapılandırma (appsettings.json)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=KuaforDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Smtp": {
    "Host": "smtp.example.com",
    "Port": 587,
    "EnableSsl": true,
    "User": "no-reply@example.com",
    "Pass": "your-strong-password"
  },
  "AllowedHosts": "*"
}
```

> Üretimde gizli bilgiler için **User Secrets** veya ortam değişkenlerini tercih edin:
> ```bash
> dotnet user-secrets init
> dotnet user-secrets set "Smtp:Pass" "super-secret"
> ```

---

## Rotalar / Uç Noktalar

| Yöntem | Yol                      | Açıklama                                 |
|-------:|--------------------------|-------------------------------------------|
| GET    | `/`                      | Ana sayfa (hero, hizmetler, yorumlar)     |
| GET    | `/Account/Login`         | Giriş                                     |
| POST   | `/Account/Login`         | Giriş işlemi                              |
| GET    | `/Account/Register`      | Kayıt                                     |
| POST   | `/Account/Register`      | Kayıt işlemi                              |
| GET    | `/Appointments`          | Kullanıcı randevu listesi                 |
| GET    | `/Appointments/Create`   | Randevu oluşturma formu                   |
| POST   | `/Appointments/Create`   | Randevu oluştur                            |
| GET    | `/Services`              | Hizmet listesi                            |
| GET    | `/Admin`                 | Admin paneli (yetki gerekli)              |

> “Randevu Al” butonu oturum yoksa giriş/kayıt modallarını tetikler; oturum varsa `/Appointments/Create` sayfasına yönlendirir.

---

## Güvenlik Notları

- ASP.NET Identity ile parola hashing ve cookie tabanlı oturum
- **[ValidateAntiForgeryToken]** kullanımı ile CSRF koruması
- Giriş denemelerinde kilitleme (lockout) politikaları
- Üretimde **HTTPS zorunlu** ve **HSTS** aktif
- Gizli bilgiler için **User Secrets / Environment Variables**

---

## Yol Haritası

- [x] Giriş ve kayıt modalları (_Layout uyumlu)
- [x] Ana sayfa hero alanı & dinamik hizmetler
- [x] Kullanıcı yorumları (onaylı yayın)
- [ ] Randevu sistemi (takvim seçimi, çakışma kontrolü)
- [ ] Admin paneli (onay/red, istatistikler)
- [ ] E‑posta ile randevu onayı
- [ ] Çoklu dil desteği (tr‑TR başlangıç)
- [ ] Radio button ile AJAX filtre & partial view güncellemeleri
- [ ] Testler (unit/integration)

---

## Katkıda Bulunma

1. Repo’yu **fork**’layın  
2. Branch açın: `git checkout -b feature/YeniOzellik`  
3. Commit: `git commit -m "Yeni özellik: açıklama"`  
4. Push: `git push origin feature/YeniOzellik`  
5. **Pull Request** açın

> Kod stili: `dotnet format` ve *nullable reference types* açık olmalı. PR’larda açıklama ve ekran görüntüsü eklenmesi tercih edilir.

---
