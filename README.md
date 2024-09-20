# SQL Sorgusu İle Veri Getirme

Bu proje, bir SQL veritabanından şirket bilgilerini almak için Entity Framework kullanılarak geliştirilmiştir. Kullanıcılar, arama yaparak şirketlerin ID, adını, türünü ve vergi numarasını görüntüleyebilirler.

Şirket bilgilerini silmek istediğinizde, bilgiler önce çöp kutusuna alınır ve 7 gün sonra kalıcı olarak silinir. Eğer silme işlemini iptal etmek isterseniz, çöp kutusundan çıkararak şirket bilgilerini geri getirebilirsiniz.

## Özellikler

- **Şirket Türü (Segment) Seçimi:** Kullanıcılar, mevcut şirket türlerinden birini seçebilirler. Seçilen tür ile şirketler listelenir.
- **Şirket Türü (Segment) Yazma:** Kullanıcılar, aradıkları şirket türünü manuel olarak yazabilirler. Girilen tür ile şirketler listelenir.

Arama sonuçları, şirketlerin ID, adı, türü ve vergi numarası ile ekranda gösterilmektedir.

## Kullanılan Teknolojiler

- ASP.NET Core
- Entity Framework
- SQL Server
- IHostedService
  
## Kurulum

1. Projeyi İndirin
 ```
git clone https://github.com/enesaks/SqlSearchQuery/
```

2. NuGet ile gerekli kutuphaneleri kurun ;
   * Microsoft.EntityFrameworkCore
   * Microsoft.EntityFrameworkCore.Design
   * Microsoft.EntityFrameworkCore.SqlServer
   * Microsoft.EntityFrameworkCore.Tools

3. Connection String

   [appsettings.json](https://github.com/enesaks/SqlSearchQuery/blob/main/appsettings.json) dosyasından DefaultConnection'ı kendi database'inize göre düzenleyiniz.

4. Migration ile Database'i oluşturma
   
 ```
dotnet ef migrations add MigrationName
dotnet ef database update
```
5. Projeyi Çalıştır
```
dotnet run 
```
  komudu ile projeyi çalıştırıp deneye bilirsiniz.

  

### Proje  : 

[Video](https://github.com/user-attachments/assets/203d8980-9b61-4afe-b506-cf5992826ab3)

<img width="517" alt="1" src="https://github.com/user-attachments/assets/fc7ae0bb-a2b3-4a70-a1d5-193463c256b6">

