using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2
{
    class Program
    {
        static void Main(string[] args)
        {
            string control="1";
            


            //VAROLAN UNİ, FAKULTE VE BOLUM UZERİNDEN İSLEM YAPABİLİRSİNİZ
            //Buradaki switch-case yapısı kolay KONTROL içindir.Projede varolan metotların hepsi burada olmayabilir
            
            Universite deu = Universite.Yeni;//Singleton pattern kullanarak deu adında universite objesi olusturuyoruz
            deu.UniAdi = "Dokuz Eylül Üniversitesi";
            deu.FakultEkle("Fen Fakültesi", 5);
            deu.Fakulteler[0].BolumEkle("Bilgisayar Bilimleri", 12);


            //KULLANICININ GİRDİĞİ DEĞERLERE GÖRE İŞLEM YAPILIYOR
            string girilenDeger;
            int deger;
            Console.WriteLine("Istediginiz islemi seciniz(islemler varolan fakultedeki bolume eklencektir):"+Environment.NewLine);


            Console.Write("ZorunluIslem-Bilgisayar Bilimleri Bolumu ne Ders Ekle"+Environment.NewLine);
                

            
            //Kullanıcının gireceği bilgiler doğrultusunda ders açılıyor(Zorunlu!!!!!)
            string dersAdi;
            string dersKodu;
            Console.WriteLine("Ders Ismi: ");
            dersAdi = Console.ReadLine();
            Console.WriteLine("Ders kodu:");
            dersKodu = Console.ReadLine();
            deu.Fakulteler[0].Bolumler[0].DersAcma(new Ders(dersAdi, dersKodu));



            string girilenDeger1;
            int deger1;

            Console.WriteLine("Istediginiz islemi seciniz(islemler varolan fakultedeki bolume eklencektir):" + Environment.NewLine);

            
                
            

            while(control!="0")//KULLANICI SIFIR GİRMEDİKÇE İŞLEM DEVAM EDİCEK
            {
                Console.WriteLine("1-Derse ogrenci ekle" + Environment.NewLine +
                "2-Derse ogretim gorevlisi ekle" + Environment.NewLine + "3-Dersi dosyaya yazdir" + Environment.NewLine +
                "4-Derse Kayitli Ogrencileri görün "+Environment.NewLine+"5-Ogrenci silin"+Environment.NewLine+
                "6-Ogretim Gorevlisi Silin"+Environment.NewLine+"7-Dersin Ogretmenlerini Gorun"+Environment.NewLine+
                "Islemi tamamen kapatmak icin 0 a basın");

                girilenDeger1 = Console.ReadLine();
                deger1 = int.Parse(girilenDeger1);

                switch (deger1)
                {
                    case 1://AÇILAN DERSE BİR LİSANS ÖĞRENCİSİ EKLİYOR
                        string ogrenciAdi;
                        string ogrenciSoyadi;
                        string ogrenciNo;
                        int no;
                        Console.WriteLine("Ogrenci Ismi: ");
                        ogrenciAdi = Console.ReadLine();
                        Console.WriteLine("Ogrenci Soyismi: ");
                        ogrenciSoyadi = Console.ReadLine();
                        Console.WriteLine("Ogrenci Kodu:");
                        ogrenciNo = Console.ReadLine();
                        no = int.Parse(ogrenciNo);

                        deu.Fakulteler[0].Bolumler[0].Dersler[0].OgrenciEkle(new Lisans(ogrenciAdi, ogrenciSoyadi, no));

                        break;

                    case 2://DERSE ÖĞRETİM ELEMANI EKLER
                        string oeAdi;
                        string oeSoyadi;
                        string ID;
                        int id;

                        Console.WriteLine("Ogretim Uyesinin ismi: ");
                        oeAdi = Console.ReadLine();
                        Console.WriteLine("Ogretim Uyesinin soyadi: ");
                        oeSoyadi = Console.ReadLine();
                        Console.WriteLine("Ogretim Uyesinin kodu: ");
                        ID = Console.ReadLine();
                        id = int.Parse(ID);

                        deu.Fakulteler[0].Bolumler[0].Dersler[0].OgretimuyesiEkle(new OgretimElemani(oeAdi, oeSoyadi, id));

                        break;

                    case 3://DersiDosyayaKaydet metodu yardımıyla Ders bilgilerini Girdiginiz dosya adında bir dosya oluşturarak
                        //o dosyaya DÜZENLİ bir şekilde yazdirir
                        string dosyaAdi;
                        Console.WriteLine("Olusturmak istediginiz dosya ismini girin(cok uzun bir isim girerseniz exception hatasi!!!!):  ");
                        dosyaAdi = Console.ReadLine();
                        deu.Fakulteler[0].Bolumler[0].Dersler[0].DersiDosyayaKaydet(dosyaAdi);

                        break;

                    case 4://Eklenilen ogrencileri gösterir
                        List<Ogrenci> ogr = deu.Fakulteler[0].Bolumler[0].Dersler[0].Ogrenciler;
                        foreach (Ogrenci o in ogr.ToList())
                        {
                            Console.WriteLine("-----"+o.Ogrismi +" "+o.Ogrsoyisim +" " + o.Ogrno);
                        }
                        break;

                    case 5:
                        string ogrno;
                        
                        Console.WriteLine("Silmek istediginiz ogrencinin numarasini girin: ");
                        ogrno = Console.ReadLine();
                        int ogrno1 = int.Parse(ogrno);

                        deu.Fakulteler[0].Bolumler[0].Dersler[0].OgrenciSilme(ogrno1);

                        break;

                    case 6:
                        string oeNo;
                        
                        Console.WriteLine("Silmek istediginiz ogretim gorevlisinin numarasini girin: ");
                        oeNo = Console.ReadLine();
                        int oeNo1 = int.Parse(oeNo);

                        deu.Fakulteler[0].Bolumler[0].Dersler[0].OgretimuyesiSil(oeNo1);

                        break;

                    case 7://Eklenilen OgretimGorevlilerini gösterir
                        List<OgretimElemani> ogretimGorevlileri = deu.Fakulteler[0].Bolumler[0].Dersler[0].Ogretmenler;
                        foreach (OgretimElemani oe in ogretimGorevlileri.ToList())
                        {
                            Console.WriteLine("-----"+oe.InstructorName +" "+oe.InstructorSurname+" " + oe.InstructorID);
                        }
                        break;

                    default:
                        Console.WriteLine("Yanlis Girdi!!!");
                        break;

                }
                Console.WriteLine("Devam etmek icin 0 disinda herhangi bir tusa basin, Bitirmek icin 0 i tuslayin");
                control = Console.ReadLine();                
            }
        }
    }
}
