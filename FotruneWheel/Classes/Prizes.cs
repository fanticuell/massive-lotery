using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotruneWheel.Classes
{
    public class Prizes
    {
        public int id { get; set; }
        public string unique_number { get; set; }
        public string nrz { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public string img { get; set; }
        public string cost { get; set; }
        public Prizes(int id, string _unique_number, string _nrz, string _name, string _group, string _img, string cost)
        {
            this.id = id;
            this.unique_number = _unique_number;
            this.nrz = _nrz;
            this.name = _name;
            this.group = _group;
            this.img = _img;
            this.cost = cost;
        }
    }
}
