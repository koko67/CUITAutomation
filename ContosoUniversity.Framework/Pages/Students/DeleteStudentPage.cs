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
    public class DeleteStudentPage
    {
        public StudentsPage ClickDeleteStudent()
        {
            HtmlInputButton delete =  new HtmlInputButton(BrowserManager.Instance.Browser);
            delete.SearchProperties.Add(HtmlInputButton.PropertyNames.DisplayText, "Delete");
            Mouse.Click(delete);
            return new StudentsPage();
        }
    }
}
