using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public class Company
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Ctype { get; set; }
        public int TCompanyId { get; set; }
        public Company() { }

        public Company(int Cid, string Cname, string Ctype, int TCompanyId)
        {
            this.Cid = Cid;
            this.Cname = Cname;
            this.Ctype = Ctype;
            this.TCompanyId = TCompanyId;

        }
        public override string ToString()
        {
            return $"{Cid} ,{Cname}, {Ctype}, {TCompanyId}";




        }
    }
}

    
