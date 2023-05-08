using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUBitirmeTezi.Models.Universitemiz
{
    public class FotografGalerisi
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Image { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Url { get; set; }
    }
}
