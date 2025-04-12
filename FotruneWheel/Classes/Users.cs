using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotruneWheel.Classes
{
    public class Users
    {
        public int id { get; set; }
        public string surname { get; set; }       
        public string post { get; set; }
        public string departament { get; set; }
        public Users(int id, string _surname, string _post, string _departament)
        {
            this.id = id;
            this.surname = _surname;
            this.post = _post;
            this.departament = _departament;
            
        }
    }
}
