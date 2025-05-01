# EmployeeManagementSystemApp

Bu proje, bir çalışan yönetim sistemi uygulamasıdır. Uygulama hem back-end hem de front-end bileşenlerini içerir. Back-end tarafı ASP.NET Core ile geliştirilmiştir, front-end tarafı ise Angular kullanılarak oluşturulmuştur.

## 📁 Proje Yapısı

```
src/
├── Application/              → Uygulama katmanı (Servisler, Modeller, Arayüzler)
├── Domain/                   → Temel domain varlıkları (Entities)
├── Infrastructure/           → Veri erişim ve dış kaynaklarla entegrasyon
├── WebAPI/                   → ASP.NET Web API (Controller, Middleware, Exception Handling)
├── EmployeeManagementUi/     → Angular UI uygulaması
```

## 🔧 Kullanılan Teknolojiler

- **Backend**: ASP.NET Core Web API
- **Frontend**: Angular
- **ORM**: Entity Framework Core
- **Veritabanı**: SQL Server
- **Katmanlı Mimari**: Domain-Driven Design (DDD) yaklaşımıyla

## 🚀 Kurulum

### 1. Veritabanı Kurulumu
- `appsettings.json` dosyasında bağlantı dizesini yapılandırın.


### 2. Backend Çalıştırma
```bash
cd WebAPI
dotnet run
```

### 3. Frontend Kurulumu ve Çalıştırma
```bash
cd EmployeeManagementUi
npm install
ng serve
```


## 👥 Özellikler

- Kullanıcı kimlik doğrulama (login)
- Çalışan yönetimi
- Departman yönetimi


