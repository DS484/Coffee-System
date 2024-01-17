using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProjectOOP.Model
{
    public class Staff : Person
    {
        private double factorSalary;

        public double FactorSalary { get => factorSalary; set => factorSalary = value; }

        public Staff(string name, string phone, string email, string birthDay, string address)
            : base(name, phone, email, birthDay, address)
        {

        }

        public Staff()
            : base() { }

        public override string PrintInfo()
        {
            return base.PrintInfo();
        }
    }
}
