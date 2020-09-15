using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEmployee
{
    public class Employee : ICloneable
    {

        public DateTime date;
        public int age;
        public string name;
        public int id;
        public int salary;
        static public int Staticid;
        public string phoneNumber;
        public string email;
        public string passport;
             

        public Employee()
        {
            
            id =Math.Abs( Guid.NewGuid().GetHashCode());           
           // Staticid++;
           //id = Staticid;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }



    }
}
