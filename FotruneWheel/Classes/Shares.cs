using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotruneWheel.Classes
{
    public class Shares
    {
        public int id { get; set; }
        public string series { get; set; }
        public string number { get; set; }
        public string unique_number { get; set; }
        public string nrz { get; set; }
        public string sheetNumber { get; set; }
        public string win { get; set; }
        public string freeze { get; set; }
        public string approoved { get; set; }
        public string packetShares { get; set; }
        public Shares(int id, string _unique_number, string _series,string _number, string _nrz, string _sheetNumber, string packetShares, string _win, string _freeze, string approoved)
        {
            this.id = id;
            this.series = _series;
            this.unique_number = _unique_number;
            this.nrz = _nrz;
            this.sheetNumber = _sheetNumber;
            this.win = _win;
            this.freeze = _freeze;
            this.number = _number;
            this.approoved = approoved;
            this.packetShares = packetShares;
        }
    }
}
