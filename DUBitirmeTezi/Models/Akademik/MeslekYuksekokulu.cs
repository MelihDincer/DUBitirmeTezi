using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Akademik
{
    public class MeslekYuksekokulu
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required]
        public string TechnicalSchoolName { get; set; }
    }
}
