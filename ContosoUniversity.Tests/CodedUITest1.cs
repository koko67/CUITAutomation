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
using ContosoUniversity.Framework.Browser;
using ContosoUniversity.Framework.Pages.Home;
using ContosoUniversity.Framework.Pages.Students;
using ContosoUniversity.Framework.Start;
using ContosoUniversity.Framework.ResourceFiles;
using ContosoUniversity.Utils;


namespace ContosoUniversity.Tests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        [TestMethod]
        public void CreateStudent()
        {
            /*Variables*/
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();
            var fullName = string.Format("{0} {1}", lastName, firstName);


            StartTest.HomePage
                .SelectStudentsOption()
                .VerifyPageIsValid(Students.Title)
                .CreateStudent()
                .SetLastNameValue(lastName)
                .SetFirstNameValue(firstName)
                .SetEnrollmentDateValue(enrollmentDate)
                .CreateStudent()
                .VerifyStudentWasCreated(fullName)
                ;
        }

        [TestMethod]
        [Description("...")]
        [TestCategory("Students")]
        [Owner("JAB")]
        public void CreateStudentTest1()
        {
            /*Variables*/
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();
            var fullName = string.Format("{0} {1}", lastName, firstName);


            StartTest.HomePage
                .SelectStudentsOption()
                .VerifyPageIsValid(Students.Title)
                .CreateStudent()
                .SetLastNameValue(lastName)
                .SetFirstNameValue(firstName)
                .SetEnrollmentDateValue(enrollmentDate)
                .CreateStudent()
                .VerifyStudentWasCreated(fullName)
                ;
        }

        [TestMethod]
        [Description("...")]
        [TestCategory("Students")]
        [Owner("JAB")]
        public void CreateStudentTest2()
        {
            /*Variables*/
            var lastName = StringGenerator.GenerateUniqueName();
            var firstName = StringGenerator.GenerateUniqueName();
            var enrollmentDate = StringGenerator.GenerateRandomDate();
            var fullName = string.Format("{0} {1}", lastName, firstName);


            StartTest.HomePage
                .SelectStudentsOption()
                .VerifyPageIsValid(Students.Title)
                .CreateStudent()
                .SetLastNameValue(lastName)
                .SetFirstNameValue(firstName)
                .SetEnrollmentDateValue(enrollmentDate)
                .CreateStudent()
                .VerifyStudentWasCreated(fullName)
                .VerifyColumnInformation(Students.TableHeaderFirstName, firstName)
                ;
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            BrowserWindow.ClearCache();
            BrowserWindow.ClearCookies();
            BrowserManager.Instance.Init();
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
        }

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
