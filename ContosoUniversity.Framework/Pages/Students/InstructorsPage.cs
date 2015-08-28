using ContosoUniversity.Framework.Browser;
using ContosoUniversity.Framework.ResourceFiles;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework.Pages.Students
{
    public class InstructorsPage
    {
        public HtmlTable GetStudentsTable
        {
            get
            {
                if (_getStudentsTable == null)
                {
                    _getStudentsTable = new HtmlTable(BrowserManager.Instance.Browser);
                    _getStudentsTable.SearchProperties.Add(HtmlTable.PropertyNames.TagName, "TABLE");
                }
                return _getStudentsTable;
            }
            set { _getStudentsTable = value; }
        }

        public InstructorsPage VerifyPageIsValid(string title)
        {
            HtmlCustom titlePage = new HtmlCustom(BrowserManager.Instance.Browser);
            titlePage.SearchProperties.Add(HtmlCustom.PropertyNames.InnerText, title);
            titlePage.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "H2");
            titlePage.WaitForControlExist();
            return this;
        }

        public CreateInstructorsPage ClickCreateInstructors()
        {
            HtmlHyperlink link = new HtmlHyperlink(BrowserManager.Instance.Browser);
            link.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Create New");
            Mouse.Click(link);
            return new CreateInstructorsPage();
        }

        public InstructorsPage VerifyInstructorWasCreated(string fullName)
        {
            if (!GetRow(fullName).TryFind())
            {
                throw new Exception("Error!!!, instructor was not found");
            }
            return this;
        }

        private HtmlTable _getStudentsTable;

        private HtmlRow GetRow(string fullName)
        {
            HtmlRow row = new HtmlRow(GetStudentsTable);
            row.SearchProperties.Add(HtmlRow.PropertyNames.InnerText, fullName, PropertyExpressionOperator.Contains);
            row.DrawHighlight();
            return row;
        }
    }
}
