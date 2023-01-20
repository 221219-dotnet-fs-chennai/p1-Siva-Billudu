using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public class TraineeEducation
    {
        public int TEducationId { get; set; }
        public string University { get; set; }
        public string HDegree { get; set; }
        public string YearOfStart { get; set; }
        public string PassoutYear { get; set; }

        public float Percentage { get; set; }

        public TraineeEducation() { }

        public TraineeEducation(int tEducationId, string University, string hDegree, string yearOfStart, string PassoutYear, float Percentage)
        {
            this.TEducationId = tEducationId;
            this.University = University;
            this.HDegree = hDegree;
            this.YearOfStart = yearOfStart;
            this.PassoutYear = PassoutYear;
            this.Percentage = Percentage;
        }

        public override string ToString()
        {
            return $"{TEducationId}, {University}, {HDegree} ,{YearOfStart} ,{PassoutYear}, {Percentage}";
        }
    }
}

    
