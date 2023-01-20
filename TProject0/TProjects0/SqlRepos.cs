using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Serilog;
using System.Collections;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata;

namespace TData
{

    public class SqlRepos : ISqlRepo
    {
        private readonly string connectionString = "Server=tcp:associateserver.database.windows.net,1433;Initial Catalog=AssociatesDb;Persist Security Info=False;User ID=associate;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public SqlRepos(string connectionString)
        {

        }

        public TraineeLogin AddLogin(TraineeLogin user)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into [siva.TraineeLogin](Id,Email,Password) values(@Id,@Email,@Password)";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(user.Id));
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.password);
            command.ExecuteNonQuery();
            Console.WriteLine("values added");
            Console.ReadLine();
            return user;




        }

        public List<TraineeLogin> GetTraineeLogin()
        {
            List<TraineeLogin> users = new List<TraineeLogin>();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT [Id],[Email],[password] from [siva.TraineeLogin]";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new TraineeLogin()
                {
                    Id = reader.GetInt32(0),
                    Email = reader.GetString(1),
                    password = reader.GetString(2)
                });
            }
            return users;
        }

        public TraineeDetails AddDetails(TraineeDetails user)
        {
            using SqlConnection con = new(connectionString);
            con.Open();
            string query = "Insert into [siva.TraineeDetails](TraineeId,FirstName,LastName,Age,Gender) values(@TraineeId,@FirstName,@LastName,@Age,@Gender)";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@TraineeId", Convert.ToInt32(user.TraineeId));
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Age", user.Age);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.ExecuteNonQuery();
            Console.WriteLine("values added");
            Console.ReadLine();
            return user;

        }
        public List<TraineeDetails> GetTraineeDetails()
        {
            List<TraineeDetails> user = new List<TraineeDetails>();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT [TraineeId],[FirstName],[LastName],[Age],[Gender] from [siva.TraineeDetails]";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Add(new TraineeDetails()

                {
                    TraineeId = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Age = reader.GetInt32(3),
                    Gender = reader.GetString(4)
                });

            }
            return user;
        }

        public Company AddCompany(Company user)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into [siva.Company] (Cid,Cname,Ctype,TCompanyId) values(@Cid,@Cname,@Ctype,@TCompanyId)";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@Cid", Convert.ToInt32(user.Cid));
            command.Parameters.AddWithValue("@Cname", user.Cname);
            command.Parameters.AddWithValue("@Ctype", user.Ctype);
            command.Parameters.AddWithValue("@TCompanyId", user.TCompanyId);

            command.ExecuteNonQuery();
            Console.WriteLine("values added");
            Console.ReadLine();

            return user;

        }

        public List<Company> GetCompany()
        {

            List<Company> user = new List<Company>();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT [Cid],[Cname],[Ctype],[TCompanyId] from [siva.Company]";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Add(new Company()
                {
                    Cid = reader.GetInt32(0),
                    Cname = reader.GetString(1),
                    Ctype = reader.GetString(2),
                    TCompanyId = reader.GetInt32(3)

                });



            }
            return user;

        }


        public TraineeEducation AddEducation(TraineeEducation user)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into [siva.TraineeEducation](TEducationId,University,HDegree,YearOfStart,PassoutYear,Percentage)values (@TEducationId,@University,@HDegree,@YearOfStart,@PassoutYear,@Percentage)";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@TEducationId", Convert.ToInt32(user.TEducationId));
            command.Parameters.AddWithValue("@University", user.University);
            command.Parameters.AddWithValue("@HDegree", user.HDegree);
            command.Parameters.AddWithValue("@YearOfStart", user.YearOfStart);
            command.Parameters.AddWithValue("@PassoutYear", user.PassoutYear);
            command.Parameters.AddWithValue("@percentage", user.Percentage);

            command.ExecuteNonQuery();
            Console.WriteLine("values added");
            Console.ReadLine();
            return user;


        }

        public List<TraineeEducation> GetTraineeEducation()
        {

            List<TraineeEducation> user = new List<TraineeEducation>();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT [TEducationId],[University],[HDegree],[YearOfStart],[PassoutYear],[Percentage] from [siva.TraineeEducation]";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Add(new TraineeEducation()
                {
                    TEducationId = reader.GetInt32(0),
                    University = reader.GetString(1),
                    HDegree = reader.GetString(2),
                    YearOfStart = reader.GetString(3),
                    PassoutYear = reader.GetString(4),
                    Percentage = reader.GetInt32(5),
                });

            }
            return user;
        }

        public TraineeContact AddContact(TraineeContact user)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "insert into [siva.TraineeContact](TContactId,PhoneNo,Email,Address,City,State,PinCode,Website)values(@TContactId,@PhoneNo,@Email,@Address,@City,@state,@PinCode,@Website)";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@TContactId", Convert.ToInt32(user.TContactId));
            command.Parameters.AddWithValue("@PhoneNo", user.PhoneNo);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@City", user.City);
            command.Parameters.AddWithValue("@State", user.state);
            command.Parameters.AddWithValue("@Pincode", user.PinCode);
            command.Parameters.AddWithValue("@Website", user.website);

            command.ExecuteNonQuery();
            Console.WriteLine("values added");
            Console.ReadLine();
            return user;



        }

        public List<TraineeContact> GetTraineeContact()
        {
            List<TraineeContact> user = new List<TraineeContact>();
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "SELECT [TContactId],[PhoneNo],[Email],[Address],[City],[state],[pincode],[website] from [siva.TraineeContact]";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Add(new TraineeContact()
                {
                    TContactId = reader.GetInt32(0),
                    PhoneNo = reader.GetString(1),
                    Email = reader.GetString(2),
                    Address = reader.GetString(3),
                    City = reader.GetString(4),
                    state = reader.GetString(5),
                    PinCode = reader.GetString(6),
                    website = reader.GetString(7)
                });
            }
            return user;

        }

        public TraineeSkills AddSkills(TraineeSkills user)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into [siva.TraineeSkills](SkillId,SkillName,Experience,TSkillsId) values (@SkillId,@SkillName,@Experience,@TSkillsId)";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@SkillId", Convert.ToInt32(user.SkillId));
            command.Parameters.AddWithValue("@SkillName", user.SkillName);
            command.Parameters.AddWithValue("@Experience", user.Experience);
            command.Parameters.AddWithValue("@TSkillsId", user.TSkillsId);

            command.ExecuteNonQuery();
            Console.WriteLine("values added");
            Console.ReadLine();
            return user;
        }

        public List<TraineeSkills> GetTraineeSkills()
        {
            List<TraineeSkills> user = new List<TraineeSkills>();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT [SkillId],[SkillName],[Experience],[TSkillsId] from [siva.TraineeSkills]";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Add(new TraineeSkills()
                {
                    SkillId = reader.GetInt32(0),
                    SkillName = reader.GetString(1),
                    Experience = reader.GetString(2),
                    TSkillsId = reader.GetInt32(3)

                });
            }
            return user;
        }

        public TSignUp AddS(TSignUp user)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into [siva.TSignUp](TId,FName,Lname,TEmail,Tpassword)values(@TId,@FName,@LName,@TEmail,@TPassword)";
            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@TId", Convert.ToInt32(user.TId));
            command.Parameters.AddWithValue("@FName", user.FName);
            command.Parameters.AddWithValue("@LName", user.LName);
            command.Parameters.AddWithValue("@TEmail", user.TEmail);
            command.Parameters.AddWithValue("@TPassword", user.TPassword);

            command.ExecuteNonQuery();
            Console.WriteLine("values added");
            Console.ReadLine();
            return user;
        }


        public List<TSignUp> GetTSignUp()
        {
            List<TSignUp> user = new List<TSignUp>();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT [TId],[FName],[LName],[TEmail],[TPassword] from[siva.Sign_Up]";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Add(new TSignUp()
                {
                    TId = reader.GetInt32(0),
                    FName = reader.GetString(1),
                    LName = reader.GetString(2),
                    TEmail = reader.GetString(3),
                    TPassword = reader.GetString(4)




                });
            }
            return user;

        }
    }
}
       /* public void UpdateTrainer(string tableName, string columnName, string newValue, int user_id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (tableName == "TraineeDetails")
            {
                if (columnName == "Age")
                {
                    int newvalue = Convert.ToInt32(newValue);
                    string query = $"update '{tableName}' set '{columnName}' = '{newvalue}' where TraineeId = '{user_id}'";
                    SqlCommand command2 = new SqlCommand(query, con);
                    Log.Information($"{TraineeId} is this");
                    command2.ExecuteNonQuery();
                    Console.WriteLine("Trainee updated");
                }
                else
                {
                    string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where user_id = '{user_id}'";
                    SqlCommand command2 = new SqlCommand(query, con);
                    command2.ExecuteNonQuery();
                    Console.WriteLine("Trainee updated");
                }
            }
            if (tableName == "TraineeSkills")
            {
                string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where SkillId = '{user_id}";
                SqlCommand command2 = new SqlCommand(query, con);
                command2.ExecuteNonQuery();
                Console.WriteLine("Trainee updated");
            }
            if (tableName == "Company")
            {
                string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where CId = '{user_id}'";
                SqlCommand command1 = new SqlCommand(query, con);
                command2.ExecuteNonQuery();
                Console.WriteLine("Trainee updated");
            }
            if (tableName == "TraineeEducation")
            {
                string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where TEducationId = '{user_id}";
                SqlCommand command2 = new SqlCommand(query, con);
                command2.ExecuteNonQuery();
                Console.WriteLine("Trainee updated");
            }
            Console.WriteLine("Trainee updated Successfully");

        }
    }
}



/*

public void DeleteTrainee(string Cname)
        {
            string connectionString = null;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = $"delete from Company where Cname = '{Cname}'";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }

        public Company DeleteTrainee(Company company)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanys()
        {
            throw new NotImplementedException();
        }

        public void Company(string v)
        {
            throw new NotImplementedException();
        }
    }
}*/


