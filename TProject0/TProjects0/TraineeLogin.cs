using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public class TraineeLogin
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string password { get; set; }

        public TraineeLogin() { }

        public TraineeLogin(int Id, string Email, string password)
        {
            this.Id = Id;
            this.Email = Email;
            this.password = password;
        }

        public override string ToString()
        {
            return $"{Id},{Email},{password}";
        }
    }
}

    

