using System;
using System.Collections.Generic;
using System.Text;

namespace Threading
{

    public abstract class Model
    { }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }
        public decimal Tax { get; set; }
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }

    public class Department 
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
