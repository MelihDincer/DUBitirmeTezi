using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Akademik
{
    public class FakulteDetay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Fakulte")]
        public int FakulteId { get; set; }
        public Fakulte Fakulte { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string EducationName { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description2 { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Mission { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Vision { get; set; }
    }
}
