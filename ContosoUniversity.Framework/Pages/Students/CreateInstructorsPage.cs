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
    public class CreateInstructorsPage
    {
        public CreateInstructorsPage SetLastNameValue(string value)
        {
            SetValue(value, "LastName");
            return this;
        }

        public CreateInstructorsPage SetFirstNameValue(string value)
        {
            SetValue(value, "FirstMidName");
            return this;
        }

        public CreateInstructorsPage SetHireDateValue(string value)
        {
            SetValue(value, "HireDate");
            return this;
        }

        public CreateInstructorsPage SetOfficeLocationValue(string value)
        {
            SetValue(value, "OfficeAssignment_Location");
            return this;
        }

        public InstructorsPage CreateInstructor()
        {
            HtmlInputButton button = new HtmlInputButton(BrowserManager.Instance.Browser);
            button.SearchProperties.Add(HtmlInputButton.PropertyNames.DisplayText, "Create");
            Mouse.Click(button);
            return new InstructorsPage();
        }




        private void SetValue(string value, string id)
        {
            HtmlEdit edit = new HtmlEdit(BrowserManager.Instance.Browser);
            edit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, id);
            Keyboard.SendKeys(edit, value);
        }
    }
}
