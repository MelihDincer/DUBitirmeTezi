using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Akademik
{
    public class MeslekYuksekokulDetay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MeslekYuksekokulu")]
        public int MeslekYuksekokuluId { get; set; }
        public MeslekYuksekokulu MeslekYuksekokulu { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Description1 { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description2 { get; set; }

    }
}
