using System.ComponentModel.DataAnnotations;// used for "required"
namespace DataLayer
{
    public class TrRecord
    {
        public TrRecord() { }
        
        public TrRecord(string email) {
            this.email = email; 
        }
        public TrRecord(string email, string password, int userid) {
            this.email = email;
            this.password = password;
            this.userid = userid;   
        }
        
        public string email { get; set; }
        
        public string password { get; set; }
        
        public int userid { get; set; }

        public override string ToString()
        {
            return $"{email} {password} {userid}";
        }
    }
   
}
