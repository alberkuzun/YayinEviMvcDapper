using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YayinEviMvcDapper.Models
{
    public class KitapModel
    {
        public int KitapNo { get; set; }
        public string KitapAd { get; set; }
        public int KategoriNo { get; set; }
        public int YazarNo { get; set; }
        public int YayınEviNo { get; set; }
    }
}