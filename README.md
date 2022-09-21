#Admin/Yönetici
Daire bilgilerini girebilir.
Ýkamet eden kullanýcý bilgilerini girer.
Daire baþýna ödenmesi gereken aidat ve fatura bilgilerini girer(Aylýk olarak). Toplu veya tek tek atama yapýlabilir.
Gelen ödeme bilgilerini görür.
Gelen mesajlarý görür.
Aylýk olarak borç-alacak listesini görür.
+Kiþileri listeler, düzenler, siler.
Daire/konut bilgilerini listeler, düzenler siler.


#Kullanýcý
Kendisine atanan fatura ve aidat bilgilerini görür.
-Kredi kartý ile ödeme yapabilir.
Yöneticiye mesaj gönderebilir.

+Daire/Konut bilgilerinde
+Hangi blokda
+Durumu (Dolu-boþ)
+Tipi (2+1 vb.)
+Bulunduðu kat
+Daire numarasý

+Daire sahibi veya kiracý

+Kullanýcý bilgilerinde
+Ad-soyad
+TCNo
+E-Mail
+Telefon
+Araç bilgisi(varsa plaka no)

##Sistem kullanýlmaya baþladýðýnda ilk olarak,

Yönetici daire bilgilerini girer.
-Kullanýcý bilgilerini girer.Giriþ yapmasý için otomatik olarak bir þifre oluþturulur.
Kullanýcýlarý dairelere atar
Ay bazlý olarak aidat bilgilerini girer.
Ay bazlý olarak fatura bilgilerini girer
-Arayüz dýþýnda kullanýcýlarýn kredi kartý ile ödeme yapabilmesi için ayrý bir servis yazýlacaktýr. Bu servisde sistemde ki her bir kullanýcý için banka bilgileri(bakiye, kredi kartý no vb.) kontrol edilerek ödeme yapýlmasý saðlanýr.

Projede kullanýlacaklar:

Web projesi için .Net 5 MVC
Sistemin yönetimi/database için MS SQL Server
Kredi kartý servisi için. Veriler mongodb de tutulacak. Servis .Net WebApi olarak yazýlacaktýr.