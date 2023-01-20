using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TData
{
    public class TraineeContact
    {
        public int TContactId { get; set; }
        public string PhoneNo { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string PinCode { get; set; }

        public string website { get; set; }

        public TraineeContact() { }
        public TraineeContact(int TcontactId, string phoneNo, string Email, string Address, string City, string state, string pinCode, string website)
        {
            this.TContactId = TcontactId;
            this.PhoneNo = phoneNo;
            this.Email = Email;
            this.Address = Address;
            this.City = City;
            this.state = state;
            this.PinCode = pinCode;

            this.website = website;
        }

        public override string ToString()
        {
            return $"{TContactId},{PhoneNo},{Email},{Address},{City},{state},{PinCode},{website}";
        }

    }
}

    
