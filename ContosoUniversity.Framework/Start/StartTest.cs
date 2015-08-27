using ContosoUniversity.Framework.Pages.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Framework.Start
{
    public class StartTest
    {
        public static HomePage HomePage
        {
            get 
            {
                return new HomePage();
            }
        }
    }
}
