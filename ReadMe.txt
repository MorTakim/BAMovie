5-UI katman�ndaki Console, WinForm ya da MVC uygulamalar�nda bulunan web.config ve app.config dosyalar� i�erisindeki connection string' ler trused_connection=true olarak ayarl�d�r. gerekli ise de�i�tirin.

Dosya boyutu azalmas� i�in packages folder' �n� temizledim. Solution' � a�t�ktan sonra Tools --> NuGet Package Manager --> Manage Nuget Packages for Solution yaparak paketleri tekrar y�klemeniz gerekir.

Enable Migrations, update database yapman�za gerek yoktur. herhangi bir UI projesini �al��t�rd���n�zda database olu�acakt�r. 

UI projelerinde Student ve Firm entity' si i�in CRUD (GetById, GetAll, Insert, Update, Delete) �rnekleri var. Bunlar�n tamam� Base' lerden geliyor. Bunlara ilave olarak da Student' a GetStudentsByLastname isminde base' lerde olmayan bir metot ekledim.

