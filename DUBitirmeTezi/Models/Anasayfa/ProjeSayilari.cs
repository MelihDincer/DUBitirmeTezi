using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DUBitirmeTezi.Models.Anasayfa
{
    public class ProjeSayilari
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required]
        public string Baslik { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Aciklama { get; set; }


        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Fakulte { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Enstitu { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Yuksekokul { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string MeslekYuksekokulu { get; set; }



        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string LisansProgrami { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string LisansutsuProgrami { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string UygulamaArastirmaMerkezi { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Koordinatorluk { get; set; }




        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string BapProjesi { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string Patent { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string SponsorluProje { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public string TubitakProjesi { get; set; }
    }
}
