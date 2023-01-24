using System.Data.SqlClient;
using System.Data.SqlTypes;
using DataLayer;

namespace TrainerOnline
{
    internal class sql
    {
        private string cs = File.ReadAllText("../../../Database/cs.txt");
        public sql(string cs)
        {
            this.cs = cs;
        }

        internal List<TrDetails> GetUserPersonalDetails(int id)
        {
            List<TrDetails> list = new();
            string query = $"select [Fullname],[phone], [website],  [gender] from [siva.TrDetails] where [TrId]={id}";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                using SqlCommand newSqlCommand = new(query, conn);
                using SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new TrDetails()
                    {
                        Fullname= reader.GetString(0),
                        phone = reader.GetString(1),
                        website = reader.GetString(2),
                        
                        gender = reader.GetString(4),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlTypeException e) {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        internal List<TCompany> GetCompany(int id) {
            List<TCompany> list = new List<TCompany>();
            string query = $"select [Cname],[CType],[startyear], [endyear] from [siva.Trcompany] where [Trcompanyid] = {id}";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                using SqlCommand newSqlCommand = new(query, conn);
                using SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new TCompany()
                    {
                        Cname = reader.GetString(0),
                        CType = reader.GetString(1),
                        startdate = reader.GetString(2),
                        enddate = reader.GetString(3),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        internal void UpdateCompany(int id, string oldName, string newName, string oldCType, string newCType, string oldStartDate, string newStartDate, string oldEndDate, string newEndDate) {
            string query = $"update [siva.Trcompany] set [Cname] = '{newName}', [CType] = '{newCType}', [startyear] = '{newStartDate}', [endyear] = '{newEndDate}' where [Cname] = '{oldName}' and [CType] = '{oldCType}' and [startyear] = '{oldStartDate}' and [endyear] = '{oldEndDate}' and [Trcompanyid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@Cname", newName);
                sqlCommand.Parameters.AddWithValue("@CType", newCType);
                sqlCommand.Parameters.AddWithValue("@startdate", newStartDate);
                sqlCommand.Parameters.AddWithValue("@enddate", newEndDate);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void AddCompany(int id, TCompany company)
        {
            string query = $"insert into [siva.Trcompany] ([Cname], [CType], [startyear], [endyear], [Trcompanyid]) values (@Cname, @CType, @startdate, @enddate, @id)";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@Cname", company.Cname);
                sqlCommand.Parameters.AddWithValue("@CType", company.CType);
                sqlCommand.Parameters.AddWithValue("@startdate", company.startdate);
                sqlCommand.Parameters.AddWithValue("@enddate", company.enddate);
                sqlCommand.Parameters.AddWithValue("@id", id);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void DeleteCompany(int id, string startyear)
        {
            string query = $"delete [siva.Trcompany] where [startyear] = '{startyear}' and [Trcompanyid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows}'s from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        internal void UpdateEducation(int id, string oldName, string newName, string oldDegree, string newDegree, string oldGpa, string newGpa, string oldStartDate, string newStartDate, string oldEndDate, string NewEndDate) {
            string query = $"update [siva.TrEducation] set [TUniversity] = '{newName}', [HdegreeName] = '{newDegree}', [Cgpa] = '{newGpa}', [startdate] = '{newStartDate}', [enddate] = '{NewEndDate}' where [TUniversity] = '{oldName}' and [HdegreeName] = '{oldDegree}' and[Cgpa] = '{oldGpa}' and [startdate] = '{oldStartDate}' and [enddate] = '{oldEndDate}' and [TrEduid]= {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@TUniversity", newName);
                sqlCommand.Parameters.AddWithValue("@HdegreeName", newDegree);
                sqlCommand.Parameters.AddWithValue("@Cgpa", newGpa);
                sqlCommand.Parameters.AddWithValue("@startdate", newStartDate);
                sqlCommand.Parameters.AddWithValue("@enddate", NewEndDate);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void AddEducation(int id, TEducation education) {
            string query = $"insert into [siva.TrEducation] ([TUniversity],[TrEduid], [HdegreeName], [Cgpa], [startdate], [enddate]) values (@TUniversity, @id, @HdegreeName, @Cgpa, @startdate, @enddate)";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@TUniversity",education.TUniversity);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@HdegreeName", education.HdegreeName);
                sqlCommand.Parameters.AddWithValue("@Cgpa", education.Cgpa);
                sqlCommand.Parameters.AddWithValue("@startdate", education.startDate);
                sqlCommand.Parameters.AddWithValue("@enddate", education.endDate);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal List<TEducation> GetEducation(int id) {
            List<TEducation> newList = new List<TEducation>();
            string query = $"select [TUniversity], [HdegreeName], [Cgpa], [startdate], [enddate] from [siva.TrEducation] where [TrEduid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                using SqlCommand newSqlCommand = new(query, conn);
                using SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new TEducation()
                    {
                        TUniversity = reader.GetString(0),
                        HdegreeName = reader.GetString(1),
                        Cgpa = reader.GetString(2),
                        startDate = reader.GetString(3),
                        endDate = reader.GetString(4),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return newList;
        }
        internal void DeleteEducation(int id, string startyear)
        {
            string query = $"delete [siva.TrEducation] where [startdate] = '{startyear}' and [TrEduid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows}'s from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        internal List<TrSkills> GetAllSkillsAsync(int id)
        {
            List<TrSkills> newList = new();
            string query = $"select [skill] from [siva.TrSkill] where [Trskillid] = {id};";
            
            try
            {
                using SqlConnection conn = new(cs);
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new TrSkills(reader.GetString(0))
                    {
                        skillName = reader.GetString(0),
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return newList;
        }
        internal List<string> GetAllSkills(int id)
        {
            List<string> newList = new();
            string query = $"select [skill] from [siva.TrSkill] where [Trskillid] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(reader.GetString(0));
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally {
                conn.Close();
            }
            return newList;
        }
        internal void AddSkills(TrSkills skill) {
            string query = "insert into [siva.TrSkill] ([skill], [Trskillid]) values (@skill, @Trskillid);";
            using SqlConnection conn = new(cs);
            try {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@skill", skill.skillName);
                sqlCommand.Parameters.AddWithValue("@Trskillid", skill.Trskillid);
                try {
                    int rows = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rows} 's added...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void DeleteSkill(TrSkills skill) {
            string query = $"delete [siva.TrSkill] where [skill] = '{skill.skillName}'";
            using SqlConnection conn = new(cs);
            try {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows}'s from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void UpdateNewSkills(int id, string oldSkill, string newSkill)
        {
            string query = $"update [siva.TrSkill] set [skill] = '{newSkill}' where [skill] = '{oldSkill}' and [Trskillid] = {id}";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@skill", newSkill);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        internal List<TrContact> GetUserLocation(int id)
        {
            List<TrContact> newList = new();
            string query = $"select [pincode] from [siva.TrContact] where [CId] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                SqlDataReader reader = newSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new TrContact()
                    {
                        pincode = reader.GetString(0),
                        city = reader.GetString(1)
                    });
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return newList;
        }
        internal void AddNewUserLocation(int id, TrContact location)
        {
            string query = $"insert into [siva.TrContact] ([pincode],[city],([CId]) values (@pincode,@city,@id)";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@pincode", location.pincode);
                sqlCommand.Parameters.AddWithValue("@city", location.city);
                sqlCommand.Parameters.AddWithValue("@id", id);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void UpdateNewUserLocation(int id, TrContact location) {
            string query = $"update [siva.TrContact] set [pincode] = '{location.pincode}'[city] = '{location.city}' where [Cid] = {id}";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@pincode", location.pincode);
                sqlCommand.Parameters.AddWithValue("@city", location.city);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"updated...");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

      
        internal void AddOtherDetails(int id, TrDetails details) {
            string query = $"update [siva.TrDetails] set [Fullname] = @Fullname,[phone] = @phone, [website] = @website,  [gender] = @gender where [TrId]= {id}";
            using SqlConnection conn = new(cs);
            try { 
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@Fullname", details.Fullname);
                sqlCommand.Parameters.AddWithValue("@phone", details.phone);
                sqlCommand.Parameters.AddWithValue("@website", details.website);
              
                sqlCommand.Parameters.AddWithValue("@gender", details.gender);
                try {
                    int rows = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rows}'s added");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        internal void DeleteUserData(int id) 
        {
            string query = $"delete from [siva.TrDetails] where [TrId] = {id};";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand newSqlCommand = new(query, conn);
                int rows = newSqlCommand.ExecuteNonQuery();
                Console.WriteLine($"deleted {rows} from the table");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        
        

        internal int GetUserId (string email) {
            int id = 0;
            string query = $"select [Trid] from [siva.TrDetails] where [Email] = '{email}';";
            using SqlConnection con = new(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new(query, con);
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        internal void Adduser(TrRecord user)
        {
            string query = "insert into [siva.TrDetails] ([Email], [Password], [TrId]) values (@email, @password, @TrId);";
            using SqlConnection conn = new(cs);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new(query, conn);
                sqlCommand.Parameters.AddWithValue("@email", user.email);
                sqlCommand.Parameters.AddWithValue("@password", user.password);
                sqlCommand.Parameters.AddWithValue("@TrId", user.userid);
                try
                {
                    int rows = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{rows} s added");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                conn.Close(); 
            }
            
        }
        internal bool CheckEmailExists(string email)
        {
            using SqlConnection con = new(cs);
            try
            {   
                con.Open();
                string query = "select [Email] from [siva.TrDetails];";
                SqlCommand command = new(query, con);
                try
                {
                    List<string> list = new();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                    while (list.Count > 0)
                    {
                        if (list.Contains(email))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }


                //return false;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                con.Close(); 
            }
            return false;   
        }
        internal bool CheckUserExists(string email, string password)
        {
            using SqlConnection con = new(cs);
            try
            {
                con.Open();
                string query = "select [Email], [Password] from [siva.TrDetails];";
                SqlCommand command = new(query, con);
                try
                {
                    Dictionary<string, string> dict = new();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if(!dict.ContainsKey(reader.GetString(0))) dict.Add(reader.GetString(0), reader.GetString(1));
                    }
                    while (dict.Count > 0) {
                        return dict.Any(entry => entry.Key == email && entry.Value == password);
                    }
                    
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return false;

        }
        
        // only for reference
        internal bool CheckIdExists(int id) {
            using SqlConnection con = new(cs);
            try
            {
                string query = $"select [TrId]from [siva.TrDetails] where [TrId] = '{id}';";
                int ID = 0;
                con.Open();
                SqlCommand cmd = new(query, con);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                if (id == ID) {
                    return true;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                con.Close();
            }
            return false;
        }

        internal bool CheckTrainerIdExists(string email, int id)
        {
            bool isExists = false;
            int ID;
            string query = $"select [TrId] from [siva.TrDetails] where [Email] = '{email}';";
            using SqlConnection con = new(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new(query, con);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                if (ID == id)
                {
                    isExists = true;
                }
                else { 
                    isExists = false;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return isExists;
        }
        internal List<UserId> GetAllPersons() {
            List<UserId> newList = new();
            using SqlConnection con = new(cs);
            string query = "select [TrId] from [siva.TrDetails];";
            con.Open();
            SqlCommand command = new(query, con);
            //int userIdExists = Convert.ToInt32(command.ExecuteScalar());
            //if (userIdExists > 0) newList.Add(userIdExists);
            //string query = "select [Email], [Password] from testingado.signup;";
            //using SqlConnection con = new(cs);
            //try
            //{
            //    con.Open();
            //    SqlCommand command = new(query, con);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    newList.Add(new UserId(reader.GetInt32(0))
                    {
                        Id = reader.GetInt32(0),
                    });
                }
                return newList;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return newList;
        } 
    }
}
 