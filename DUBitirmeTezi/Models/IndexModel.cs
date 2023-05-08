using DUBitirmeTezi.Models.Anasayfa;
using System.Collections.Generic;

namespace DUBitirmeTezi.Models
{
    public class IndexModel
    {
        public List<Duyurular> Duyurular { get; set; }
        public List<ProjeSayilari> ProjeSayilari { get; set; }
    }
}
