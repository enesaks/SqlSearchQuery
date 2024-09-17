# SQL Sorgusu İle Veri Getirme

Bu proje, bir SQL veritabanından şirket bilgilerini almak için Entity Framework kullanılarak geliştirilmiştir. Kullanıcılar, arama yaparak şirketlerin ID, adını, türünü ve vergi numarasını görüntüleyebilirler.

## Özellikler

- **Şirket Türü (Segment) Seçimi:** Kullanıcılar, mevcut şirket türlerinden birini seçebilirler. Seçilen tür ile şirketler listelenir.
- **Şirket Türü (Segment) Yazma:** Kullanıcılar, aradıkları şirket türünü manuel olarak yazabilirler. Girilen tür ile şirketler listelenir.

Arama sonuçları, şirketlerin ID, adı, türü ve vergi numarası ile ekranda gösterilmektedir.

## Kullanılan Teknolojiler

- ASP.NET Core
- Entity Framework
- SQL Server
  
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

