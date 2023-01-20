using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public interface ISqlRepo
    {
        public TraineeLogin AddLogin(TraineeLogin user);

        List<TraineeLogin> GetTraineeLogin();

        public TraineeDetails AddDetails(TraineeDetails user);

        List<TraineeDetails> GetTraineeDetails();

        public Company AddCompany(Company user);
        List<Company> GetCompany();

        public TraineeEducation AddEducation(TraineeEducation user);
        List<TraineeEducation> GetTraineeEducation();

        public TraineeContact AddContact(TraineeContact user);
        List<TraineeContact> GetTraineeContact();

        public TraineeSkills AddSkills(TraineeSkills user);
        List<TraineeSkills> GetTraineeSkills();
        public TSignUp AddS(TSignUp user);

        List<TSignUp> GetTSignUp();

        /*public Company DeleteTrainee(Company company);
        List<Company> GetCompanys();
        void Company(string v);*/
    }
}

    
