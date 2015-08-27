using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Utils
{
    public class StringGenerator
    {
        public static string GenerateUniqueName()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(12);
        }

        public static string GenerateRandomDate()
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());
            int day = ran.Next(1, 31) ;
            int month = ran.Next(1, 12);
            int year = ran.Next(2013, 2020);
            return string.Format("{0}-{1}-{2}", month, day, year);
        }
    }
}
