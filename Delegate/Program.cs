using System;
using System.Collections.Generic;
using CSAssign;

namespace CS_Delegate
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.addEmployee();
            Console.WriteLine("Added Successfully!!!!");
            Console.WriteLine("===================================================");
            Console.WriteLine("List is displaying");
            Console.WriteLine("Enter the Deptname");
           var name =Console.ReadLine();
            emp.allEmpList(name);

        }
    }
}
