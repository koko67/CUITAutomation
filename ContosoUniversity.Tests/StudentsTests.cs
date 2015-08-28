using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using ContosoUniversity.Framework.Start;
using ContosoUniversity.Framework.ResourceFiles;
using ContosoUniversity.Utils;
using ContosoUniversity.Framework.PostCondition;
using ContosoUniversity.Framework;
using ContosoUniversity.Tests.Base;
using ContosoUniversity.Framework.Pages.Students;


namespace ContosoUniversity.Tests
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class StudentsTests : BaseTest
    {

        [TestMethod]
        public void CreateStudentTestByUI()
        {
            /*Variables*/
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();
            var fullName = string.Format("{0} {1}", lastName, firstName);
            Console.WriteLine(fullName);

            /*PreConditions*/

            /*TestCases*/
           CreateStudentsPage page = StartTest.HomePage
                .SelectStudentsOption()
                .VerifyPageIsValid(Students.Title)
                .CreateStudent();

                //TODO


                page.SetLastNameValue(lastName)
                .SetFirstNameValue(firstName)
                .SetEnrollmentDateValue(enrollmentDate)
                .CreateStudent()
                .VerifyStudentWasCreated(fullName)
                ;

            /*PostConditions*/
        }

        [TestMethod]
        public void DeleteStudentTestByUI()
        {
            /*Variables*/
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();
            var fullName = string.Format("{0} {1}", lastName, firstName);

            /*PreConditions*/
            PersonPreCondition.CreatePerson(firstName, lastName, enrollmentDate);

            /*TestCases*/
            StartTest.HomePage
                .SelectStudentsOption()
                .VerifyPageIsValid(Students.Title)
                .VerifyStudentWasCreated(fullName)
                .DeleteStudent(fullName)
                .ClickDeleteStudent()
                .VerifyStudentWasNotCreated(fullName);

                //post condition
            //PersonPostCondition.DeletePerson(firstName,lastName);
        }

        // FROM HERE STARTS THE PRACTICE


        [Description("Verify that an student can be found by Name")]
        [Priority(2)]
        [TestCategory("Students")]
        [Owner("Jorge Avila Baldiviezo")]
        [TestMethod]
        public void FindStudentByNameTest()
        {
            //Variables
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();

            //PreCondition
            PersonPreCondition.CreatePerson(firstName, lastName, enrollmentDate);

            //Test Cases
            StartTest.HomePage
                     .SelectStudentsOption()
                     .VerifyPageIsValid(Students.Title)
                     .SetCriteriaToFind(firstName)
                     .ClickFindStudent()
                     .VerifyStudentIsInTable(firstName);

            PersonPostCondition.DeletePerson(firstName, lastName);
            
        }

        [Description("Verify that an student can be found by LastName")]
        [Priority(2)]
        [TestCategory("Students")]
        [Owner("Jorge Avila Baldiviezo")]
        [TestMethod]
        public void FindStudentByLastNameTest()
        {
            //Variables
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();

            //PreCondition
            PersonPreCondition.CreatePerson(firstName, lastName, enrollmentDate);

            //Test Cases
            StartTest.HomePage
                     .SelectStudentsOption()
                     .VerifyPageIsValid(Students.Title)
                     .SetCriteriaToFind(lastName)
                     .ClickFindStudent()
                     .VerifyStudentIsInTable(lastName);

            PersonPostCondition.DeletePerson(firstName, lastName);
        }

        [Description("Verify that an correct Editing of an student")]
        [Priority(2)]
        [TestCategory("Students")]
        [Owner("Jorge Avila Baldiviezo")]
        [TestMethod]
        public void EditStudent()
        {
            //Variables
            var lastName = "Snow";
            var firstName = "Jon";
            var enrollmentDate = "08/25/2014";
            var fullName = string.Format("{0} {1}", lastName, firstName);

            //PreCondition
            PersonPreCondition.CreatePerson(firstName, lastName, enrollmentDate);

            //New Variables
            var newLastName = "Plant";
            var newFirstName = "Robert";
            var newEnrollmentDate = "09/16/2015";
            var newFullName = string.Format("{0} {1}", newLastName, newFirstName);


            //Test Cases
            StartTest.HomePage
                     .SelectStudentsOption()
                     .VerifyPageIsValid(Students.Title)
                     .ClickEditStudent(fullName)
                     .ClearForm()
                     .SetNewLastName(newLastName)
                     .SetNewFirstName(newFirstName)
                     .SetNewEnrollmenDate(newEnrollmentDate)
                     .ClickSaveEditing()
                     .VerifyStudentIsInTable(newFullName);
                     ;

            PersonPostCondition.DeletePerson(newFirstName, newLastName);
        }

        [Description("Verify that an Student is Delete/Removed")]
        [Priority(2)]
        [TestCategory("Students")]
        [Owner("Jorge Avila Baldiviezo")]
        [TestMethod]
        public void RemoveDeleteStudent()
        {
            //Variables
            var lastName = "Snow";
            var firstName = "Jon";
            var enrollmentDate = "08/25/2014";
            var fullName = string.Format("{0} {1}", lastName, firstName);

            //PreCondition
            PersonPreCondition.CreatePerson(firstName, lastName, enrollmentDate);

            //Test Cases
            StartTest.HomePage
                     .SelectStudentsOption()
                     .VerifyPageIsValid(Students.Title)
                     .DeleteStudent(fullName)
                     .ClickDeleteStudent()
                     .VerifyStudentIsNotPresentInTable(fullName)
            ;
        }


    }
}
