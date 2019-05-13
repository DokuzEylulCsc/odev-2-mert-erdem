using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2
{
    //Lisans, yükseklisans, doktora class larına gönderilen değerler Ogrenci Abstract class ında kaydedilecek
    abstract class Ogrenci
    {
        private string ogrismi;
        private string ogrsoyisim;
        private int ogrno;
        private string bolumu;

        public string Bolumu
        {
            set
            {
                bolumu = value;
            }
            get
            {
                return bolumu;
            }
        }
        public string Ogrismi
        {
            set
            {
                ogrismi = value;
            }
            get
            {
                return ogrismi;
            }
        }
        public string Ogrsoyisim
        {
            set
            {
                ogrsoyisim = value;
            }
            get
            {
                return ogrsoyisim;
            }
        }
        public int Ogrno
        {
            set
            {
                ogrno = value;
            }
            get
            {
                return ogrno;
            }
        }
    }

    //Lisans,yukseklisans ve doktora; hepsi Ogrenci' dir.Tek bir base ile onların bilgilerini toplayabiliriz
    class Lisans :Ogrenci
    {
        public Lisans(string ad,string soyad,int ogrNo)
        {
            //Lisans,yukseklisans ve doktora; hepsi Ogrenci' dir.Tek bir base ile onların bilgilerini toplayabiliriz
            base.Ogrismi = ad;
            base.Ogrsoyisim = soyad;
            base.Ogrno = ogrNo;
        }
    }

    class YuksekLisans:Ogrenci
    { 
        public YuksekLisans(string ad, string soyad, int ogrNo)
        {
            base.Ogrismi = ad;
            base.Ogrsoyisim = soyad;
            base.Ogrno = ogrNo;
        }
    }

    class Doktora:Ogrenci
    {        
        public Doktora(string ad, string soyad, int ogrNo)
        {
            base.Ogrismi = ad;
            base.Ogrsoyisim = soyad;
            base.Ogrno = ogrNo;
        }
    }
}
