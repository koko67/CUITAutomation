using ContosoUniversity.Framework.Browser;
using ContosoUniversity.Framework.Pages.Navigation;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework.Pages.Students
{
    public class StudentsPage : NavigationBarPage
    {
        public StudentsPage VerifyPageIsValid(string title)
        {
            HtmlCustom titlePage = new HtmlCustom(BrowserManager.Instance.Browser);
            titlePage.SearchProperties.Add(HtmlCustom.PropertyNames.InnerText, title);
            titlePage.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "H2");
            titlePage.WaitForControlExist();
            return this;
        }

        public CreateStudentsPage CreateStudent()
        {
            HtmlHyperlink link = new HtmlHyperlink(BrowserManager.Instance.Browser);
            link.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Create New");
            Mouse.Click(link);
            return new CreateStudentsPage();
        }

        /// <summary>
        /// Verify if an student was created
        /// </summary>
        /// <param name="fullName">LastName FirstName</param>
        public StudentsPage VerifyStudentWasCreated(string fullName)
        {
            if (!GetRow(fullName).TryFind())
            {
                throw new Exception("Error!!!, student was not found");
            }
            return this;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="fullName">LastName FirstName</param>
        public StudentsPage VerifyStudentWasNotCreated(string fullName)
        {
            if (GetRow(fullName).TryFind())
            {
                throw new Exception("Error!!!");
            }
            return this;
        }

        public void VerifyColumnInformation(string headerName, string expectedInfo)
        {
            if ((GetColumnInfo(headerName, expectedInfo) as HtmlCell) != null)
            {
                string innerText = (GetColumnInfo(headerName, expectedInfo) as HtmlCell).InnerText;
                if (innerText != null && innerText.Trim() == expectedInfo)
                {
                    //OK
                }
                else
                {
                    throw new Exception("Error !!!");
                }
            }
            else 
            {
                throw new Exception("Error !!!");
            }
            
            
        }

        private UITestControl GetColumnInfo(string header, string fullName)
        {
            //1 Get Header Table
            HtmlCell headerTable= new HtmlCell(GetStudentsTable);
            headerTable.SearchProperties.Add(HtmlCell.PropertyNames.TagName, "TH");
            headerTable.SearchProperties.Add(HtmlCell.PropertyNames.InnerText, header, PropertyExpressionOperator.Contains);
            
            //2 Get Column Index Position
            int headerIndex = headerTable.ColumnIndex;

            //3 Get Row
            HtmlRow row = GetRow(fullName);

            //4 Match info
            return row.Cells[headerIndex];
        }

        private HtmlRow GetRow(string fullName)
        {
            HtmlRow row = new HtmlRow(GetStudentsTable);
            row.SearchProperties.Add(HtmlRow.PropertyNames.InnerText, fullName, PropertyExpressionOperator.Contains);
            //row.DrawHighlight();
            return row;
        }

        private HtmlTable _getStudentsTable;

        public HtmlTable GetStudentsTable
        {
            get 
            {
                if(_getStudentsTable == null)
                {
                    _getStudentsTable = new HtmlTable(BrowserManager.Instance.Browser);
                    _getStudentsTable.SearchProperties.Add(HtmlTable.PropertyNames.Id, "student-table");
                }
                return _getStudentsTable; 
            }
            set { _getStudentsTable = value; }
        }


        public DeleteStudentPage DeleteStudent(string fullName)
        {
            /*TODO*/
            HtmlHyperlink del = new HtmlHyperlink(GetRow(fullName));
            del.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Delete");
            Mouse.Click(del);
            return new DeleteStudentPage();

        }

        public StudentsPage VerifyStudentIsNotPresentInTable(string fullName)
        {
            if (!GetRow(fullName).TryFind())
            {
                return this;
            }
            throw new Exception("Error!!!, student continue in the table");
        }

        // FROM HERE THE PRACTICE

        public StudentsPage SetCriteriaToFind(string firstName)
        {
            SetValue(firstName, "SearchString");
            return this;
        }

        private void SetValue(string value, string id)
        {
            HtmlEdit edit = new HtmlEdit(BrowserManager.Instance.Browser);
            edit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, id);
            Keyboard.SendKeys(edit, value);
        }

        public StudentsPage ClickFindStudent()
        {
            HtmlInputButton searchButton = new HtmlInputButton(BrowserManager.Instance.Browser);
            searchButton.SearchProperties.Add(HtmlInputButton.PropertyNames.DisplayText, "Search");
            Mouse.Click(searchButton);
            return new StudentsPage();
        }

        public StudentsPage VerifyStudentIsInTable(string fullName)
        {
            if (!GetRow(fullName).TryFind())
            {
                throw new Exception("Error!!!, student was not found");
            }
            return this;
        }

        public EditStudentPage ClickEditStudent(string fullName)
        {
            HtmlHyperlink edit = new HtmlHyperlink(GetRow(fullName));
            edit.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Edit");
            Mouse.Click(edit);
            return new EditStudentPage();
        }
    }
}
