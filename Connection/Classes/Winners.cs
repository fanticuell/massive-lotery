using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Classes
{
    public class Winners
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string departament { get; set; }
        public string post { get; set; }
        public Winners(int id, string _surname, string _departament, string _post)
        {
            this.id = id;
            this.surname = _surname;
            this.departament = _departament;
            this.post = _post;
        }
    }
}
