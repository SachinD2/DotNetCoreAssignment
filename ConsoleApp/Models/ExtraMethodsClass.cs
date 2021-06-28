using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core_Console_App.Sevices;
using  System.Threading.Tasks;
using ConsoleApp.Models;
using ConsoleApp.Sevices;

namespace Core_Console_App.Models
{
     public  static class ExtraMethodsClass
    {
       static CitiusDbContext context = new CitiusDbContext();

        static IService<Department, int> serv = new DepartmentService();
        static IService<Employee, int> empserv = new EmployeeService();
        public  static void ListOfEmployees()
        {
            List<Employee> emps = new List<Employee>();

        }

        public async static void AddDeptEmp(Department Dept, Employee Emps)
        {
            var d = context.Department.FindAsync(Dept.DeptNo);
            if (d == null)
            {
                Console.WriteLine("Department is not found !!!!");
            }
            else
            {
               await serv.CreateAsync(Dept);
                await context.Employee.AddRangeAsync(new Employee()
                {
                    Empno = "CT102",
                    EmpName = "Devansh",
                    Salary = 12345,
                    Designation = "Manager",
                    DeptUniqueId = 4
                }, new Employee()
                {
                    Empno = "CT103",
                    EmpName = "Shivu",
                    Salary = 12345,
                    Designation = "Clerk",
                    DeptUniqueId = 5
                }) ;
                await empserv.CreateAsync(Emps);
                context.SaveChanges();
                


            }
        }
    }
}
