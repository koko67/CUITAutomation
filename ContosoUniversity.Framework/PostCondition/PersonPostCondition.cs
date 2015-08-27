using ContosoUniversity.DataAccessLayer;
using ContosoUniversity.DataAccessLayer.Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework.PostCondition
{
    public class PersonPostCondition
    {
        public static bool DeletePerson(string firstName, string lastName)
        {
            PersonManager pm = new PersonManager();
            return pm.DeletePerson(firstName, lastName);
        }
    
        // FROM HERE THE PRACTICE

        public static Person GetPerson(string firstName,string lastName)
        {
            PersonManager pm = new PersonManager();
            return pm.GetPerson(firstName, lastName);
        }
    }
}
