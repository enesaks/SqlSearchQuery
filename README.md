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

### Prooje Resimleri : 

<img width="1470" alt="2" src="https://github.com/user-attachments/assets/8e7590f5-720e-4205-8cbe-7aa6a14017d9">
<img width="1470" alt="3" src="https://github.com/user-attachments/assets/c7a8e047-8329-421a-96fa-77941ffdb936">
<img width="1470" alt="4" src="https://github.com/user-attachments/assets/c0f0d8ab-8f4c-4260-b7f8-2e4ead4428bb">
<img width="517" alt="1" src="https://github.com/user-attachments/assets/fc7ae0bb-a2b3-4a70-a1d5-193463c256b6">

