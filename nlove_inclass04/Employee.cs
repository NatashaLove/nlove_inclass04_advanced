using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_GUI
{
    public enum ROLE { PROFESSOR, ASST_PROF, ADJ_PROF, STAFF, CONTRACTOR };

    public class Employee : Person
    {
        private double _salary;
        private ROLE _role;

        public Employee(string id, string firstName, string midInit, string lastName, int age) : base(id, firstName, midInit, lastName, age)
        {
            Salary = 0;
            Role = ROLE.STAFF;
        }

        public double Salary { get { return _salary; } set { _salary = value; } }
        public ROLE Role { get { return _role; } set { _role = value; } }

        public override string DisplayInformation()
        {

            return String.Format("Employee ID: {0}\nName: {1} {2}. {3}\nRole: {4}\nAge: {5}\nSalary: {6}",
                this.ID, this.FirstName, this.MidInit, this.LastName, this.Role.ToString(), this.Age.ToString(), this.Salary.ToString());
        }
    }
}
