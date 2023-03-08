using BusinessLogic;

namespace Testing
{
    [TestFixture]
    public class Testing
    {
        Validation val = new Validation();
        public void Setup()
        {
        }

        [Test]
        [TestCase("siv@gmail.com", true)]
        [TestCase("siddu@gcom", false)]
        public void TestEmail(string Email, bool ExpectedValue)
        {
            var email = val.IsValidEmail(Email);

            Assert.AreEqual(email, ExpectedValue);
        }
        [Test]
        [TestCase("Siv@12345",true)]
        [TestCase("sid",false)]
        public void TestPassword(string Password,bool ExpectedValue)
        {
            var password = val.IsValidPassword(Password);
            Assert.AreEqual(password, ExpectedValue);
        }
        [Test]
        [TestCase("6305600943", true)]
        [TestCase("8788", false)]
        [TestCase("76123456789", false)]
        public void TestPhone(string Phone, bool ExpectedValue)
        {
            var phone = val.IsValidPhone(Phone);
            Assert.AreEqual(phone, ExpectedValue);
        }
        [Test]
        [TestCase("www.google.com", true)]
        [TestCase("google",false)]
          public void TestWebsite(string Website,bool ExpectedValue)
        {
            var website=val.IsValidWebsite(Website);
            Assert.AreEqual(website, ExpectedValue);
        }
        [Test]
        [TestCase("male",true)]
        [TestCase("mk",false) ]
        [TestCase("female",true) ]
        public void TestGender(string Gender,bool ExpectedValue)
        {
            var gender = val.IsValidGender(Gender);
            Assert.AreEqual(gender, ExpectedValue);
        }
        [Test]
        [TestCase("9.5",true)]
        [TestCase("d",false)]
        public void TestCGpa(string CGpa,bool ExpectedValue)
        {
            var cgpa = val.IsValidCGpa(CGpa);
            Assert.AreEqual(cgpa, ExpectedValue);
        }
        [Test]
        [TestCase("2022",true)]
        [TestCase("23",false)]
        public void TestYear(string Year,bool ExpectedValue)
        {
            var year=val.IsValidYear(Year);
            Assert.AreEqual(year, ExpectedValue);
        }
        [Test]
        [TestCase("523303",true)]
        [TestCase("456",false)]
        public void TestPincode(string Pincode,bool ExpectedValue)
        {
            var pincode = val.IsValidPincode(Pincode);
            Assert.AreEqual(pincode, ExpectedValue);
        }
        [Test]
        [TestCase("Dotnet",true)]
        [TestCase("Js",false)]
        [TestCase("Java",true)]
        public void TestSkill(string Skill,bool ExpectedValue)
        {
            var skill=val.IsValidSkillName(Skill);
            Assert.AreEqual(skill, ExpectedValue);
        }

    }
}