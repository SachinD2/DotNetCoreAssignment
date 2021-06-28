using System;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp.Models;
using ConsoleApp.Sevices;
using ConsoleApp.Validators;
using Core_Console_App.Models;
using Core_Console_App.Sevices;
using Core_Console_App.Validators;

namespace Core_Console_App
{
    class Program
    {
       static  IService<Department, int> serv = new DepartmentService();
        static IService<Employee, int> empserv = new EmployeeService();
        static async Task Main(string[] args)
        {
            bool x = true;
            while(x == true)
            {
                Console.WriteLine("=========MENU for Employee=============");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. Get All Employees");
                Console.WriteLine("4. Get Employee by ID");
                Console.WriteLine("5. Update Employee");
                Console.WriteLine("===========MENU for Department============");
                Console.WriteLine("6. Add Department");
                Console.WriteLine("7. Delete Department");
                Console.WriteLine("8. Get All Departments");
                Console.WriteLine("9. Get Department by ID");
                Console.WriteLine("10. Update Department");

                Console.WriteLine("===========MENU for Department and Employeee============");
                Console.WriteLine("11. Add Multiple Employees in one Department");


                Console.WriteLine("Enter your choice here !!!!");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            
                            Console.WriteLine("Enter the Employee code");
                            string empIdA = Console.ReadLine();
                            Console.WriteLine("Enter the Employee name");
                            string enameA = Console.ReadLine();
                            Console.WriteLine("Enter the Employee designation");
                            string designationA = Console.ReadLine();
                            Console.WriteLine("Enter the Employee Salary");
                            int salaryA = Convert.ToInt32(Console.ReadLine());

                            var error = EmployeeInputValidators.EmpValidator(new Employee()
                            { Empno = empIdA, EmpName = enameA, Designation = designationA, Salary = salaryA }
                             );

                            if (error == false)
                            {
                                await empserv.CreateAsync(new Employee()
                                { Empno = empIdA, EmpName = enameA, Designation = designationA, Salary = salaryA }
                                 );
                            }
                            else
                            {
                                Console.WriteLine("");
                            }

                            Console.WriteLine("Employee Added Sucessfully!!!!");
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Employee has not been added !!! Please fill entry correctly");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Employee ID");
                        int empunqId = Convert.ToInt32(Console.ReadLine());
                        await empserv.DeleteAsync(empunqId);
                        break;
                    case 3:
                        var emps = await empserv.GetAsync();
                        foreach (var item in emps.ToList())
                        {
                            Console.WriteLine($"{item.EmpUniqueId} {item.Empno} {item.EmpName} {item.Salary} {item.Designation}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the Employee Id");
                        empunqId = Convert.ToInt32(Console.ReadLine());
                        await empserv.GetAsync(empunqId);
                        break;

                    case 5:
                        Console.WriteLine("Enter the Employee unique Id");
                        empunqId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the Employee code");
                        string empId = Console.ReadLine();
                        Console.WriteLine("Enter the Employee name");
                        string ename = Console.ReadLine();
                        Console.WriteLine("Enter the Employee designation");
                        string designation = Console.ReadLine();
                        Console.WriteLine("Enter the Employee Salary");
                        int salary = Convert.ToInt32(Console.ReadLine());

                        await empserv.UpdateAsync(empunqId, new Employee()
                        { Empno = empId, EmpName = ename, Designation = designation, Salary = salary }
                         );
                        break;
                    case 6:
                        try
                        {
                            Console.WriteLine("Enter the Department Id");
                            int deptsUnqId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Department Code");
                            string deptid = Console.ReadLine();
                            Console.WriteLine("Enter the Department Name");
                            string dname = Console.ReadLine();
                            Console.WriteLine("Enter the Department Location");
                            string location = Console.ReadLine();

                            await serv.CreateAsync(new Department() { DeptUniqueId = deptsUnqId, DeptNo = deptid, DeptName = dname, Location = location });
                            Console.WriteLine("Department Added Successfully!!!");
                        }
                        catch (Exception)
                        {

                            Console.WriteLine($"Incorrect Entry Department is not added !!! Please try after sometime later");
                        }
                        break;

                    case 7:
                        try
                        {
                            Console.WriteLine("Enter the Department Unique ID");
                            int deptunqd = Convert.ToInt32(Console.ReadLine());
                            await serv.DeleteAsync(deptunqd);

                        }
                        catch (Exception)
                        {

                            Console.WriteLine($"Incorrect Entry Department is deleted !!! Please try after sometime later");
                        }
                        break;
                    case 8:
                        var depts = await serv.GetAsync();
                        foreach (var item in depts.ToList())
                        {
                            Console.WriteLine($"{item.DeptUniqueId} {item.DeptNo} {item.DeptName} {item.Location}");
                        }
                        break;

                    case 9:
                        Console.WriteLine("Enter the Department Unique ID");
                        int deptunqid = Convert.ToInt32(Console.ReadLine());
                        var item1 = await serv.GetAsync(deptunqid);
                        Console.WriteLine($"{item1.DeptUniqueId} {item1.DeptNo} {item1.DeptName} {item1.Location}");
                        break;

                    case 10:
                        try
                        {
                            Console.WriteLine("Enter the Department Unique ID");
                            deptunqid = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the Department Code");
                            string deptid = Console.ReadLine();
                            Console.WriteLine("Enter the Department Name");
                            string dname = Console.ReadLine();
                            Console.WriteLine("Enter the Department Location");
                            string location = Console.ReadLine();
                            await serv.UpdateAsync(deptunqid, new Department() { DeptNo = deptid, DeptName = dname, Location = location });
                        }
                        catch (Exception)
                        {

                            Console.WriteLine($"Some Error Occuring while Updating the records !!! Please try after sometime later");
                        }
                        break;
                    case 11:
                       
                         //   ExtraMethodsClass.AddDeptEmp()
                        
                        break;
                }
            }
        }
    }
}
