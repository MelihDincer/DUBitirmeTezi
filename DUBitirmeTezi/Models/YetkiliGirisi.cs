using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DUBitirmeTezi.Models
{
    public class YetkiliGirisi
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Ad { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Soyad { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string KullaniciAdi { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Mail { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Telefon { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public string Sifre { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string DahiliTelefon { get; set; }

        public DateTime KullanicininEklendigiTarih { get; set; }

        public bool AktifMi { get; set; }

    }
}
