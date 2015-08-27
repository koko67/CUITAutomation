//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContosoUniversity.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department
    {
        public Department()
        {
            this.Courses = new HashSet<Course>();
        }
    
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
        public virtual Person Person { get; set; }
    }
}
