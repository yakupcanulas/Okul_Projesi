using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCodeFirst.Models
{
    //[Table("tblOgrenciler")]

    //Sütün ismi değiştirmek için (propertynin üstüne)
    //[Column("IsimSoyisim")]
    //[Column(TypeName="varchar")]
    //[Column("IsimSoyisim",TypeName="char")]

    public class Ogrenci
    {
        [Key]
        [DisplayName("Öğrenci No")]
        public int OgrenciID { get; set; }
        [Required(ErrorMessage ="Ad soyad zorunludur.")]
        [MaxLength(100)] //db için
        [StringLength(100,MinimumLength =3,ErrorMessage ="Ad soyad 3-100 krk arası olmalı")] //ekranlar için
        [DisplayName("Ad Soyad")]
        public string AdSoyad { get; set; }
        [DisplayName("Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? DogumTarihi { get; set; }
        [DisplayName("Mezun Mu?")]
        public bool MezunMu { get; set; }
        
        public double Ortalama { get; set; }
  
        public Ogrenci() //new Ogrenci()
        {   //default değerler
            MezunMu = false;
            Ortalama = 0;
        }
        
    }
}