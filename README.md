# alifuatdulgerCurrencyTracker

Piri Reis Üniversitesi GÖRSEL PROGRAMLAMA Dersi için hazırlanmış CurrencyTracker Projesidir,Ali Fuat Dülger tarafından hazırlanmıştır.

## Proje Amacı
Bu proje, Türk Lirası (TRY) bazlı döviz kurlarını Frankfurter FREE API üzerinden alarak, C# konsol uygulaması içerisinde kullanıcıya sunmak amacıyla geliştirilmiştir. Projede API kullanımı, asenkron programlama ve LINQ sorguları uygulamalı olarak gösterilmiştir.

## Kullanılan Teknolojiler
- C#
- .NET Konsol Uygulaması
- HttpClient
- async / await
- LINQ
- Frankfurter FREE API

API Adresi:
https://api.frankfurter.app/latest?from=TRY

## Proje Yapısı
Projede iki adet model sınıfı bulunmaktadır.

CurrencyResponse sınıfı, API’den gelen JSON verisini karşılamak için kullanılmıştır.

Currency sınıfı ise uygulama içerisinde döviz kodu ve kur bilgisini tutmak için kullanılmıştır.

## API’den Veri Alma Süreci
Döviz verileri HttpClient kullanılarak asenkron olarak çekilmektedir. API çağrıları async / await yapısı ile gerçekleştirilmiştir. Olası bağlantı hataları try-catch bloğu ile yakalanarak uygulamanın çökmesi engellenmiştir.

## Demo (Offline) Veri Kullanımı
Bazı ağlarda API erişimi mümkün olmadığından, hata oluşması durumunda uygulama otomatik olarak demo veriye geçmektedir. Bu sayede uygulama her koşulda çalışır durumda kalmaktadır.

## Konsol Menü İşlevleri
1. Tüm dövizleri listeleme  
   Tüm dövizler listelenir. LINQ Select kullanılmıştır.

2. Koda göre döviz arama  
   Kullanıcının girdiği döviz koduna göre arama yapılır. Büyük/küçük harf duyarsızdır. LINQ Where kullanılmıştır.

3. Belirli bir değerden büyük dövizleri listeleme  
   Girilen değerden büyük olan dövizler listelenir. LINQ Where kullanılmıştır.

4. Dövizleri değere göre sıralama  
   Dövizler kura göre büyükten küçüğe sıralanır. LINQ OrderByDescending kullanılmıştır.

5. İstatistiksel özet  
   Toplam döviz sayısı, en yüksek kur, en düşük kur ve ortalama kur bilgileri gösterilir. LINQ Count, Max, Min ve Average metotları kullanılmıştır.

## Teknik Gereksinimler
- C# Konsol Uygulaması kullanılmıştır
- HttpClient ile API entegrasyonu yapılmıştır
- async / await yapısı kullanılmıştır
- List<Currency> koleksiyonu kullanılmıştır
- LINQ sorguları uygulanmıştır
- Hard-coded ana veri kullanılmamıştır
- Grafik arayüz (GUI) kullanılmamıştır

  ## Projeyi Çalıştırma
1. Proje klasörü Visual Studio ile açın.  
2. Program.cs dosyasının ana dosya (startup file) olduğundan emin olun.  
3. Proje .NET Console Application olarak çalıştırılır.  
4. Uygulama çalıştırıldığında konsol menüsü ekrana gelir.  
5. Menü üzerinden numaralı seçenekler girilerek döviz işlemleri yapılır.

## Sonuç
Bu proje ile API kullanımı, asenkron programlama, LINQ sorguları ve hata yönetimi konuları uygulamalı olarak gerçekleştirilmiştir. Uygulama, API erişimi olmadığı durumlarda dahi çalışmaya devam etmektedir.

