using ContosoUniversity.Framework.Browser;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework.Pages.Students
{
    public class CreateStudentsPage
    {

        public CreateStudentsPage SetLastNameValue(string value)
        {
            SetValue(value, "LastName");
            return this;
        }

        public CreateStudentsPage SetFirstNameValue(string value)
        {
            SetValue(value, "FirstMidName");
            return this;
        }

        public CreateStudentsPage SetEnrollmentDateValue(string value)
        {
            SetValue(value, "EnrollmentDate");
            return this;
        }

        public StudentsPage CreateStudent()
        {
            HtmlInputButton button = new HtmlInputButton(BrowserManager.Instance.Browser);
            button.SearchProperties.Add(HtmlInputButton.PropertyNames.DisplayText, "Create");
            Mouse.Click(button);
            return new StudentsPage();
        }

        private void SetValue(string value, string id)
        {
            HtmlEdit edit = new HtmlEdit(BrowserManager.Instance.Browser);
            edit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, id);
            Keyboard.SendKeys(edit, value);
        }
    }
}
