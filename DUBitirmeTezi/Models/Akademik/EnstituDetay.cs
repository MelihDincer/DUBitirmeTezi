using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Akademik
{
    public class EnstituDetay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Enstitu")]
        public int EnstituId { get; set; }
        public Enstitu Enstitu { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description2 { get; set; }
    }
}
