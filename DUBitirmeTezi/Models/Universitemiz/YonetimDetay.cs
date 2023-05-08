using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Universitemiz
{
    public class YonetimDetay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Yonetim")]
        public int YonetimId { get; set; }
        public Yonetim YonetimTable { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Image { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Url { get; set; }


    }
}
