using System.Numerics;
using System.Reflection;

namespace DataLayer
{
    public class TrDetails
    {
        public TrDetails() { }
        
        public string Fullname{ get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        
        public string gender { get; set; }

        public override string ToString()
        {
            return $"\nFullname: {Fullname}\nGender: {gender}\nPhone: {phone}\nWebsite: {website}\n";
        }
    }
}
