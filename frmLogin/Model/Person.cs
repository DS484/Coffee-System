using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProjectOOP.Model
{
    public abstract class Person
    {
        private string name;

        private string phone;

        private string email;

        private string birthDay;

        private string address;

        public Person(string name, string phone, string email, string birthDay, string address)
        {
            Name = name;
            Phone = phone;
            Email = email;
            BirthDay = birthDay;
            Address = address;
        }

        public Person() { }

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string BirthDay { get => birthDay; set => birthDay = value; }
        public string Address { get => address; set => address = value; }

        public virtual string PrintInfo()
        {
            return "Name: " + Name + "\n"
                + "Phone: " + Phone + "\n"
                + "Email: " + Email + "\n"
                + "Birthday: " + BirthDay + "\n"
                + "Address: " + Address + "\n\n";
        }
    }
}
