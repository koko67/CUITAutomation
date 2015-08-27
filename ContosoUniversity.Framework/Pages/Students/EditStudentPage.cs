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
    public class EditStudentPage
    {
        public EditStudentPage SetNewLastName(string lastName)
        {
            SetValue(lastName, "LastName");
            return this;
        }

        public EditStudentPage SetNewFirstName(string firstName)
        {
            SetValue(firstName, "FirstMidName");
            return this;
        }

        public EditStudentPage SetNewEnrollmenDate(string enrollmentDate)
        {
            SetValue(enrollmentDate, "EnrollmentDate");
            return this;
        }

        public StudentsPage ClickSaveEditing()
        {
            HtmlInputButton delete = new HtmlInputButton(BrowserManager.Instance.Browser);
            delete.SearchProperties.Add(HtmlInputButton.PropertyNames.DisplayText, "Save");
            Mouse.Click(delete);
            return new StudentsPage();
        }

        public EditStudentPage ClearForm()
        {
            ClearForm("LastName");
            ClearForm("FirstMidName");
            ClearForm("EnrollmentDate");
            return this;

        }
        

        private void SetValue(string value, string id)
        {
            HtmlEdit edit = new HtmlEdit(BrowserManager.Instance.Browser);
            edit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, id);
            Keyboard.SendKeys(edit, value);
        }

        private void ClearForm(string id)
        {
            HtmlEdit edit = new HtmlEdit(BrowserManager.Instance.Browser);
            edit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, id);
            edit.Text = "";
        }
    }
}
