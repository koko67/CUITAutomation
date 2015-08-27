using ContosoUniversity.DataAccessLayer.Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework
{
    public class PersonPreCondition
    {
        public static bool CreatePerson(string firstName, 
                                    string lastName, 
                                    string enrollmentDate, 
                                    string hireDate = null, 
                                    string discriminator = "Student")
        {
            PersonManager pm = new PersonManager();
            return pm.CreatePerson(firstName,
                            lastName, 
                            enrollmentDate, 
                            hireDate, 
                            discriminator);
        }
    }
}
