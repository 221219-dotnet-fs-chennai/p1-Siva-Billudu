using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public class TraineeDetails
    {
        public int TraineeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }

        public TraineeDetails() { }

        public TraineeDetails(int TraineeId, string FirstName, string LastName, int Age, string Gender)
        {
            this.TraineeId = TraineeId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Gender = Gender;
        }

        public override string ToString()
        {
            return $"{TraineeId},{FirstName},{LastName}{Age},{Gender}";
        }

    }
}

    




