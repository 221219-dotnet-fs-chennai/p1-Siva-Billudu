using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Validation
    {
        public Validation() { }
        public bool IsValidEmail(string Email)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (!Regex.IsMatch(Email, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsValidPassword(string str)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*  internal static bool IsValidId(int  str)
          {
              int pattern = @"^([0-9]\d{4})$";
              if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
              {
                  return false;
              }
              else
              {
                  return true;
              }
          }*/

        public  bool IsValidPhone(string str)
        {
            string pattern = @"^([6-9]\d{9})$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public  bool IsValidWebsite(string str)
        {
            string pattern = @"^((https?|ftp|smtp):\/\/)?(www.)?[a-z0-9]+\.[a-z]+(\/[a-zA-Z0-9#]+\/?)*$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public  bool IsValidGender(string str)
        {
            string pattern = "^((male?|female|others))?$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public  bool IsValidCGpa(string str)
        {
            string pattern = @"^((\d.\d)|\d)$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public  bool IsValidYear(string str)
        {
            string pattern = @"^(19|20)\d{2}$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public  bool IsValidPincode(string str)
        {
            string pattern = @"^[1-9][0-9]{5}$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public  bool IsValidSkillName(string str)
        {
            string pattern = @"^.{3,}$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
