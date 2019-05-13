using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace Odev2
{
    //ÜNİVERSİTEDEN SUBEYE KADAR TÜM SINIFLAR VE ÖĞRETİM ÜYESİ CLASS LARI BU CS TEDİR

    //Tek bir üniversite açılabilir (Singleton Pattern)
    class Universite
    {
        private string uniAdi;
        List<Fakulte> fakulteler = new List<Fakulte>();
        private static Universite yeni = null;

        public List<Fakulte> Fakulteler
        {
            set
            {
                fakulteler = value;
            }
            get
            {
                return fakulteler;
            }
        }
        public string UniAdi
        {
            set
            {
                uniAdi = value;
            }
            get
            {
                return uniAdi;
            }
        }
        public static Universite Yeni
        {

            get
            {
                if(yeni==null)
                {
                    yeni = new Universite();
                }
                return yeni;
            }

        }

        private Universite()
        {
            
        }

        public  void FakultEkle(string fakulteIsmi,int bolumSayisi)
        {
            Fakulte f = new Fakulte(fakulteIsmi, bolumSayisi);
            this.Fakulteler.Add(f);
            
        }
    }

    class Fakulte
    {
        private string fakulteIsmi;
        private int bolumSayisi;
        List<Bolum> bolumler = new List<Bolum>();
        

        public List<Bolum> Bolumler
        {
            set
            {
                bolumler = value;
            }
            get
            {
                return bolumler;
            }
        }

        public string FakulteIsmi
        {
            set
            {
                fakulteIsmi = value;
            }
            get
            {
                return fakulteIsmi;
            }
        }
        public int BolumSayisi
        {
            set
            {
                bolumSayisi = value;
            }
            get
            {
                return bolumSayisi;
            }
        }


        public Fakulte(string fakulteIsmi,int bolumSayisi)
        {
            this.FakulteIsmi = fakulteIsmi;
            this.BolumSayisi = bolumSayisi;
        }

        public void BolumEkle(string bolumIsmi,int dersSayisi)
        {
            Bolum yeni = new Bolum(bolumIsmi, dersSayisi);
            Bolumler.Add(yeni);
        }
    }

    class Bolum
    {
        private string bolumIsmi;
        private int dersSayisi;
        List<Ogrenci> ogrenciler = new List<Ogrenci>();
        List<Ders> dersler = new List<Ders>();
        List<OgretimElemani> ogretmenler =new List<OgretimElemani>(); 

        public List<Ogrenci> Ogrenciler
        {
            set
            {
                ogrenciler = value;
            }
            get
            {
                return ogrenciler;
            }
        }
        public List<OgretimElemani> Ogretmenler
        {
            set
            {
                ogretmenler = value;
            }
            get
            {
                return ogretmenler;
            }
        }
        public List<Ders> Dersler
        {
            set
            {
                dersler = value;
            }
            get
            {
                return dersler;
            }
        }

        public string BolumIsmi
        {
            set
            {
                bolumIsmi = value;
            }
            get
            {
                return bolumIsmi;
            }

        }
        
        public int DersSayisi
        {
            set
            {
                dersSayisi = value;
            }
            get
            {
                return dersSayisi;
            }
        }

        
        public Bolum(string bolumIsmi, int dersSayisi)
        {
            this.BolumIsmi = bolumIsmi;
            this.DersSayisi = dersSayisi;
        }

        public void OgrenciEkle(Ogrenci ogr)
        {
            this.Ogrenciler.Add(ogr);
            ogr.Bolumu = this.bolumIsmi;
            Console.WriteLine("Ogrenci Eklendi");
        }

        public void OgrenciSilme(Ogrenci ogr) //ogrno unique bir değer olduğu için onu kullandık
        {
            bool control = false;
            foreach(Ogrenci o in Ogrenciler.ToList())//ToList olmayınca hata aldık
            {
                if(o.Ogrno==ogr.Ogrno)
                {
                    control = true;
                    Console.WriteLine(Ogrenciler.Count);
                    this.Ogrenciler.Remove(o);
                    ogr.Bolumu = null;//Öğrenci bölümde silinirse öğrencinin bölümü null olacak
                    Console.WriteLine(o.Ogrismi+" isimli ogrenci silindi"+" "+Ogrenciler.Count);
                    
                }
            }
            if(control==false)
            {
                Console.WriteLine("Silmek istediğiniz öğrenci bulunamadi");
            }
        }

        public void DersAcma(Ders d)
        {
            this.Dersler.Add(d);
        }
        public void DersKapama(Ders d)//DERS KODU UNIQUE
        {
            foreach(Ders de in Dersler.ToList())
            {
                if(de.DersKodu==d.DersKodu)
                {
                    this.Dersler.Remove(d);
                    Console.WriteLine(d.DersKodu + " kodlu " + d.DersAdi + " dersi kapandi");
                }
            }           
        }

        public void OgretimuyesiEkle(OgretimElemani o)
        {
            this.Ogretmenler.Add(o);
        }
        public void OgretimuyesiSil(OgretimElemani o)
        {
            foreach(OgretimElemani oe in Ogretmenler.ToList())
            {
                if(o.InstructorID==oe.InstructorID)
                {
                    this.Ogretmenler.Remove(o);
                    Console.WriteLine(o.InstructorID + " ID li ogretmen bolumden cikarildi");
                }
            }
        }

    }

    class Ders
    {
        private string dersAdi;
        private string dersKodu;
        List<Ogrenci> ogrenciler = new List<Ogrenci>();
        List<OgretimElemani> ogretmenler = new List<OgretimElemani>();
        List<Sube> subeler = new List<Sube>();

        public List<Ogrenci> Ogrenciler
        {
            set
            {
                ogrenciler = value;
            }
            get
            {
                return ogrenciler;
            }
        }
        public List<Sube> Subeler
        {
            set
            {
                subeler = value;
            }
            get
            {
                return subeler;
            }
        }
        public List<OgretimElemani> Ogretmenler
        {
            set
            {
                ogretmenler = value;
            }
            get
            {
                return ogretmenler;
            }
        }
        public string DersAdi
        {
            set
            {
                dersAdi = value;
            }
            get
            {
                return dersAdi;
            }
        }
        public string DersKodu
        {
            set
            {
                dersKodu = value;
            }
            get
            {
                return dersKodu;
            }
        }
        public Ders(string dersAdi,string dersKodu)
        {
            this.DersAdi = dersAdi;
            this.DersKodu = dersKodu;
            //Ders açıldığında otomatik olarak 2 adet şube açılacak ve Subeler adlı listeye eklenecek.Sube numaraları ise parantez
            //içindeki değerlerdir
            this.Subeler.Add(new Sube(1));
            this.Subeler.Add(new Sube(2));
        }

        public void OgrenciEkle(Ogrenci ogr)//Listeye gonderilen objeyi ekliyor
        {
            this.Ogrenciler.Add(ogr);
        }
        public void OgrenciSilme(int ogr) //ogrno özgün bir değer olduğu için onu kullandık
        {
            bool control = false;
            foreach (Ogrenci o in Ogrenciler.ToList())//ToList olmayınca hata aldık
            {
                if (o.Ogrno == ogr)
                {
                    control = true;
                    Console.WriteLine(Ogrenciler.Count);
                    this.Ogrenciler.Remove(o);
                    Console.WriteLine(o.Ogrismi + " isimli ogrenci silindi" + " " + Ogrenciler.Count);

                }
            }
            if (control == false)
            {
                Console.WriteLine("Silmek istediğiniz öğrenci bulunamadi");
            }
        }

        public void OgretimuyesiEkle(OgretimElemani o)
        {
            this.Ogretmenler.Add(o);
        }
        public void OgretimuyesiSil(int ID)
        {
            foreach (OgretimElemani oe in Ogretmenler.ToList())
            {
                if (oe.InstructorID == ID)
                {
                    this.Ogretmenler.Remove(oe);
                    Console.WriteLine(ID + " ID li ogretmen bolumden cikarildi");
                }
            }
        }

        //Dersi dosyaya yazdırıyoruz ,Exception Handling ile IO kütüphanesinin exception larını yakalıyoruz
        public void DersiDosyayaKaydet(string dosyaAdi)
        {
            try
            {
                StreamWriter write = new StreamWriter(dosyaAdi+".txt");

                write.WriteLine("Ders: " + this.DersAdi + "    " + "Ders Kodu: " + this.DersKodu);
                write.WriteLine(" ");
                write.WriteLine("Ogretim Uyeleri;");
                write.WriteLine(" ");

                foreach (OgretimElemani oe in Ogretmenler)
                {
                    write.WriteLine("Ad: " + oe.InstructorName + " " + "No: " + oe.InstructorID);
                }

                write.WriteLine(" ");
                write.WriteLine("Ogrenciler;");
                write.WriteLine(" ");

                foreach (Ogrenci o in Ogrenciler)
                {
                    write.WriteLine("Ad: " + o.Ogrismi + " " + "No: " + o.Ogrno);
                }
                write.Close();
            }
            
            catch (PathTooLongException e)
            {
                Console.WriteLine("Girdiginiz dosya adi cok uzun!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Yazdirmak istediğiniz dosya kilitli!");
            }
            catch(Exception e)
            {
                Console.WriteLine("DersiDosyayaKaydet isimli fonksiyonda sorun var!");
            }
            
            
            
        }

    }

    class Sube
    {
        private int subeNo;
        List<Ogrenci> ogrenciler = new List<Ogrenci>();
        List<OgretimElemani> ogretmenler = new List<OgretimElemani>();

        public int SubeNo
        {
            set
            {
                subeNo = value;
            }
            get
            {
                return subeNo;
            }
        }
        public List<Ogrenci> Ogrenciler
        {
            set
            {
                ogrenciler = value;
            }
            get
            {
                return ogrenciler;
            }
        }
        public List<OgretimElemani> Ogretmenler
        {
            set
            {
                ogretmenler = value;
            }
            get
            {
                return ogretmenler;
            }
        }

        public Sube(int subeNo)
        {
            this.SubeNo = subeNo;
        }

        public void OgrenciEkle(Ogrenci ogr)
        {
            this.Ogrenciler.Add(ogr);
        }
        public void OgrenciSilme(int ogr) //ogrno unique bir değer olduğu için onu kullandık
        {
            bool control = false;
            foreach (Ogrenci o in Ogrenciler.ToList())
            {
                if (o.Ogrno == ogr)
                {
                    control = true;
                    Console.WriteLine(Ogrenciler.Count);
                    this.Ogrenciler.Remove(o);
                    Console.WriteLine(o.Ogrismi + " isimli ogrenci silindi" + " " + Ogrenciler.Count);

                }
            }
            if (control == false)
            {
                Console.WriteLine("Silmek istediğiniz öğrenci bulunamadi");
            }
        }

        public void OgretimuyesiEkle(OgretimElemani o)
        {
            this.Ogretmenler.Add(o);
        }
        public void OgretimuyesiSil(int ID)
        {
            foreach (OgretimElemani oe in Ogretmenler.ToList())
            {
                if (oe.InstructorID == ID)
                {
                    this.Ogretmenler.Remove(oe);
                    Console.WriteLine(ID + " ID li ogretmen bolumden cikarildi");
                }
            }
        }
    }

    class OgretimElemani
    {
        private string instructorName;
        private string instructorSurname;
        private int instructorID;

        public string InstructorName
        {
            set
            {
                instructorName = value;
            }
            get
            {
                return instructorName;
            }
        }
        public string InstructorSurname
        {
            set
            {
                instructorSurname = value;
            }
            get
            {
                return instructorSurname;
            }
        }
        public int InstructorID
        {
            set
            {
                instructorID = value;
            }
            get
            {
                return instructorID;
            }
        }

        public OgretimElemani(string ad,string soyad,int no)
        {
            this.InstructorName = ad;
            this.InstructorSurname = soyad;
            this.InstructorID = no;
        }
    }
}

