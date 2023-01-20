using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public class TSignUp
    {
        public int TId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string TEmail { get; set; }

        public string TPassword { get; set; }

        public TSignUp() { }

        public TSignUp(int TraineeId, string FirstName, string LastName, string Email, string Password)
        {
            this.TId = TId;
            this.FName = FirstName;
            this.LName = LastName;
            this.TEmail= TEmail;
            this.TPassword = TPassword;
        }

        public override string ToString()
        {
            return $"{TId},{FName},{LName}{TEmail},{TPassword}";
        }


    }
}
