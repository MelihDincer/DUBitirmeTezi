using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DUBitirmeTezi.Models
{
    public class Duyurular
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string DuyuruAdi { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Aciklama1 { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Aciklama2 { get; set; }

        public bool AktifMi { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Image { get; set; }

        public DateTime EklendigiTarih { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Url { get; set; }
    }
}
