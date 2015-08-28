using ContosoUniversity.Framework.Browser;
using ContosoUniversity.Framework.Pages.Home;
using ContosoUniversity.Framework.Pages.Students;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework.Pages.Navigation
{
    public class NavigationBarPage
    {

        public StudentsPage SelectStudentsOption()
        {
            MenuSelector("Students");
            return new StudentsPage();
        }

        public HomePage SelectHomeOption()
        {
            MenuSelector("Home");
            return new HomePage();
        }

        public InstructorsPage SelectInstructorsOption()
        {
            MenuSelector("Instructors");
            return new InstructorsPage();
        }

        private HtmlDiv _getMenuContainer;

        private void MenuSelector(string option)
        {
            HtmlHyperlink link = new HtmlHyperlink(GetMenuContainer);
            link.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, option);
            Mouse.Click(link);
        }

        private HtmlDiv GetMenuContainer
        {
            get
            { 
                if(_getMenuContainer == null)
                {
                    _getMenuContainer = new HtmlDiv(BrowserManager.Instance.Browser);
                    _getMenuContainer.SearchProperties.Add(HtmlDiv.PropertyNames.Class, "container");
                }
                return _getMenuContainer;
                //Class = container
                //HtmlDiv div = new HtmlDiv(BrowserManager.Instance.Browser);
                //div.SearchProperties.Add(HtmlDiv.PropertyNames.Class, "container");
                //return div;
            }
        }
    }
}
