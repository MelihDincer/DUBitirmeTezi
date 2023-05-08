using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Akademik
{
    public class Yuksekokul
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string CollageName { get; set; }
    }
}
