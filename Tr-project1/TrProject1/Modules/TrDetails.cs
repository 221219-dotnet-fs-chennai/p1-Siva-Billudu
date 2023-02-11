using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class TrDetails
    {

        public TrDetails() { }
        public int TrId { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public string Gender { get; set; }

        public override string ToString()
        {
            return $"\nTrId:{TrId}\nEmail:{Email}\nPassword:{Password}\nFullname: {Fullname}\nGender: {Gender}\nPhone: {Phone}\nWebsite: {Website}\n";


        }
    }
}
