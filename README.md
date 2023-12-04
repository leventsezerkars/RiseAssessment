# RiseAssessment

Proje 3 Microservisten oluşuyor 
1-Person  -> kişi ile ilgili verilerin tutulduğu ve düzenlendiği microservis 5011 nolu porttan ayağa kalkıyor
2-Contact -> Kişi iletişim bilgilerinin ayarlandığı microservis 5012 nolu porttan ayağa kalkıyor
3-Report  -> Rapor işlemlerinin ayarlandığı mikroservis 5013 nolu porttan ayağa kalkıyor

Gateaway tüm mikroservisleri 5000 portundan ayağa kalkacak şekilde düzenliyor

Tüm veriler MongoDb de tutuluyor.

Shared Core Library tüm proje içerisinde işimize yarayacak classlardan oluşuyor

Frontend 5010 nolu porttan ayağa kalkıyor ve verileri httpClient ile diğer microservislerden gataway üzerinden çekip listeliyor.

Raporlar Rabbitmq ile kuyruğa alınıp işleniyor ve işlendiğinde Status değişiyor.

Ayrıca Person ve Contact mikroservisleri arasında bir Event ile gerekli bilgilerin senkronize değişimi yapılıyor.
Yani kişinin ad ve soyadı contact db sinde de ayrıca tutuluyor ve person db sinde isim ve soyisim değiştiğinde contact db sinde de aynı şekilde değişiklik sağlanıyor.

