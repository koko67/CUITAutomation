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
using ContosoUniversity.Tests.Base;
using ContosoUniversity.Utils;
using ContosoUniversity.Framework.Start;
using ContosoUniversity.Framework.ResourceFiles;
using ContosoUniversity.Framework.Pages.Students;
using ContosoUniversity.Framework;
using ContosoUniversity.Framework.PostCondition;


namespace ContosoUniversity.Tests
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class InstructorsTests : BaseTest
    {
        [TestMethod]
        public void CreateInstructorTestByUI()
        {
            /*Variables*/
            var lastName = "Mercury";
            var firstName = "Freddy";
            var hireDate = "2014/05/23";
            var fullName = string.Format("{0} {1}", lastName, firstName);
            var officeLocation = "far far away";
            Console.WriteLine(fullName);

            /*TestCases*/
            StartTest.HomePage
                .SelectInstructorsOption()
                .VerifyPageIsValid(Instructors.Title)
                .ClickCreateInstructors()
                .SetLastNameValue(lastName)
                .SetFirstNameValue(firstName)
                .SetHireDateValue(hireDate)
                .SetOfficeLocationValue(officeLocation)
                .CreateInstructor()
                .VerifyInstructorWasCreated(fullName)
                ;
        }

        [TestMethod]
        public void EditInstructor()
        {
            /*Variables*/
            var lastName = "Proton";
            var firstName = "Professor";
            var hireDate = "2014/08/28";
            var fullName = string.Format("{0} {1}", lastName, firstName);
            var officeLocation = "far away";
            Console.WriteLine(fullName);

            //Pre condition
            PersonPreCondition.CreatePerson2(firstName, lastName, hireDate, null);

            /*TestCases*/
            StartTest.HomePage
                .SelectInstructorsOption()
                .VerifyPageIsValid(Instructors.Title)
                .ClickCreateInstructors()
                .SetLastNameValue(lastName)
                .SetFirstNameValue(firstName)
                .SetHireDateValue(hireDate)
                .SetOfficeLocationValue(officeLocation)
                .CreateInstructor()
                .VerifyInstructorWasCreated(fullName)
                ;
        }

    }
}
