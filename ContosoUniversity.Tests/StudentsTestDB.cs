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
using ContosoUniversity.Framework;
using ContosoUniversity.Framework.Start;
using ContosoUniversity.Framework.ResourceFiles;


namespace ContosoUniversity.Tests
{
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    public class StudentsTestDB : BaseTestDB
    {
        [TestMethod]
        public void Test()
        {
            /*Variables*/
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();
            var fullName = string.Format("{0} {1}", lastName, firstName);

            /*PreConditions*/


            /*TestCases*/
            Assert.IsTrue(PersonPreCondition.CreatePerson(firstName, lastName, enrollmentDate));
        }
    }
}
