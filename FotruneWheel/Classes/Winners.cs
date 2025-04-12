using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotruneWheel.Classes
{
    public class Winners
    {
        public int id { get; set; }
        public string nrz { get; set; }
        public string series { get; set; }
        public string number { get; set; }
        public string winShare { get; set; }
        public string sheetNumber { get; set; }
        public string surname { get; set; }
        public string post { get; set; }
        public string departament { get; set; }
        public string prize { get; set; }
        public string prizeID { get; set; }
        public Winners(int id, string _nrz, string _series, string _number, string _winShare, string _sheetNumber, string _surname, string _post, string _departament,string _prize,string _prizeID)
        {
            this.id = id;
            this.nrz = _nrz;
            this.series = _series;
            this.winShare = _winShare;
            this.sheetNumber = _sheetNumber;
            this.surname = _surname;
            this.post = _post;
            this.departament = _departament;
            this.prize = _prize;
            this.prizeID = _prizeID;
            this.number = _number;

        }
    }
}
