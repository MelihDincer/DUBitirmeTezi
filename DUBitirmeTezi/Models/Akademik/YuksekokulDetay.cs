using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Akademik
{
    public class YuksekokulDetay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Yuksekokul")]
        public int YuksekokulId { get; set; }
        public Yuksekokul Yuksekokul { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Description1 { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description2 { get; set; }


    }
}
