using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotruneWheel.Classes
{
    public class groupPrizes
    {
        public int id { get; set; }
        public string nrz { get; set; }
        public string name { get; set; }
        public string count { get; set; }    
        public string img { get; set; }
        public string needShares { get; set; }
        public string maxShares { get; set; }
        public groupPrizes(int id, string _nrz, string _name, string _count, string _img, string _needShares, string maxShares)
        {
            this.id = id;
            this.nrz = _nrz;
            this.name = _name;
            this.count = _count;
            this.img = _img;
            this.needShares = _needShares;
            this.maxShares = maxShares;
        }
    }
}
