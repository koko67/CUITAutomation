using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.DataAccessLayer.Business_Logic
{
    public class PersonManager
    {
        public bool CreatePerson(string firstName, 
                                 string lastName, 
                                 string enrollmentDate,
                                 string hireDate, 
                                 string discriminator)
        {
            using (var dbContext = new ContosoUniversity2Entities())
            {
                Person person = new Person();
                person.FirstName = firstName;
                person.LastName = lastName;
                person.EnrollmentDate = DateTime.Parse(enrollmentDate);
                if (!string.IsNullOrEmpty(hireDate))
                {
                    person.HireDate = DateTime.Parse(hireDate);
                }
                person.Discriminator = discriminator;

                var personAdded = dbContext.People.Add(person);
                if (personAdded != null) //---
                {
                    if (dbContext.SaveChanges() > 0) //--- INSERT
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool DeletePerson(string firstName, string lastName)
        {
            var person = GetPerson(firstName, lastName);
            if (person != null)
            {
                using(var dbContext = new ContosoUniversity2Entities())
                {
                    dbContext.People.Attach(person);
                    dbContext.People.Remove(person);

                    if (dbContext.SaveChanges() > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //public static bool UpdatePeople(PersonoriginalPerson, stringnewLastName)
        //{
        //    using(vardbContext = newContosoUniversity2Entities())
        //    { 
        //        varpersonUpdated = dbContext.People.Attach(originalPerson);
        //        personUpdated.LastName = newLastName;
        //        if(personUpdated != null)
        //        {
        //            if(dbContext.SaveChanges() > 0)
        //            {
        //                returntrue;
        //            }
        //        }
        //        return false;
        //    }
        //}

        public Person GetPerson(string firstName, string lastName)
        {
            Person person;
            using (var dbContext = new ContosoUniversity2Entities())
            {
                var res = dbContext.People.Where(x => x.FirstName.Equals(firstName) && 
                                            x.LastName.Equals(lastName));
                person = res.FirstOrDefault();
                if (person != null)
                {
                    return person;
                }
            }
            return null;
        }
    }
}
