using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericApp
{
    class Program
    {

		static EmployeeDb employees = new EmployeeDb();
		static DepartmentDb departments = new DepartmentDb();
		static IService<Employee, int> empServ = new EmployeeService();
		static IService<Department, int> deptServ = new DepartmentService();

		static void Main(string[] args)
        {
			/*Console.WriteLine("Enter the Department Name");
			string dname= Console.ReadLine();
			PrintEmployeesByDeptName(dname);
            Console.WriteLine("Maximum salary as per department");
			MaxSalaryGroupByDept();
			MaxSalaryGroupByDept();*/
			bool x = true;
			while(x ==true)
            {
                Console.WriteLine("Select Menu");
				Console.WriteLine("===================================");
				Console.WriteLine("1. Add Employee");
				Console.WriteLine("2. Get All Employee");
				Console.WriteLine("3. Get Max Salary by department");
				Console.WriteLine("4. Get Employee By Dept name");
				Console.WriteLine("5. Get Employee by id");
				Console.WriteLine("6. Delete Employee");
				Console.WriteLine("7. Update Employee");
				Console.WriteLine("8. Add Department");
				Console.WriteLine("9. Get All Department");
				Console.WriteLine("10. Delete Department");
				Console.WriteLine("11. Update Department");
				Console.WriteLine("12. Get Department by deptno");
				Console.WriteLine("13. Increament salary of employee");
				Console.WriteLine("14. Exit");

				Console.WriteLine("Enter your choice");
				int choice = Convert.ToInt32(Console.ReadLine());

				switch(choice)
                {
					case 1 :
						Console.WriteLine("Enter the Employee ID");
						int empid = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Enter the Employee Name");
						string ename = Console.ReadLine();
						Console.WriteLine("Enter the Employee Salary");
						int sal = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Enter the Dept No 10,20,30,40");
						int dno = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Enter the Department Name");
						string dname = Console.ReadLine();

						empServ.Create(new Employee() { EmpNo = empid, EmpName = ename, Salary = sal, DeptNo = dno, DeptName = dname });

                        Console.WriteLine("Employee Added Successfully");
					break;
					case 2:
                        Console.WriteLine("All Employees are Displaying");
                        empServ.Get();
						break;
					case 3:
                        Console.WriteLine("Maximum salary by Dept Name");
						MaxSalaryGroupByDept();
						break;
					case 4 :
                        Console.WriteLine("Please Enter Dept Name {HR,Finance,Engineering or Admin}");
						string deptname = Console.ReadLine();
						PrintEmployeesByDeptName(deptname);
						break;
					case 5:
						try
						{
							Console.WriteLine("Enter employee id");
							int id = Convert.ToInt32(Console.ReadLine());
							empServ.Get(id);
                            
						}
						catch(Exception)
                        {
                            Console.WriteLine("You may enter invalid Employee id");
                        }
						break;
					case 6:
                        Console.WriteLine("Enter the Employee ID which you want to delete");
						int emId = Convert.ToInt32(Console.ReadLine());
						if(emId != 0)
						{
							empServ.Delete(emId);
							Console.WriteLine("Employee Deleted Successfully");
						}
                        else
                        {
                            Console.WriteLine("You have entered invalid ID");
                        }
						break;
					case 7:
                        Console.WriteLine("Enter the Employee id which want to udpdate");
						emId = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Enter New Name as well Salary of employee");
						string name = Console.ReadLine();
						sal = Convert.ToInt32(Console.ReadLine());
						empServ.Update(emId, new Employee() { EmpName = name, Salary = sal });
						break;

					case 8:
						Console.WriteLine("Enter the Department Code");
						int deptid = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Enter the Department Name");
						dname = Console.ReadLine();
						Console.WriteLine("Enter the Department Location");
						string location = Console.ReadLine();
						Console.WriteLine("Enter the Department Capacity");
						int capcity = Convert.ToInt32(Console.ReadLine());

						if (checkingCapicityAsperDepartment(deptid) == departments.Capacity)
						{
                            Console.WriteLine("Capaity is full !! You may choose other Department");
						}
                        else
                        {
							deptServ.Create(new Department() { DeptNo = deptid, DeptName = dname, Location = location, Capacity = capcity });
                            Console.WriteLine("Department added successfully");
						}
						break;
					case 9:
						Console.WriteLine("All Departments are Displaying");
						deptServ.Get();
						break;
					case 10:
						Console.WriteLine("Enter the Department Code which you want to delete");
						int deptn = Convert.ToInt32(Console.ReadLine());
						if (deptn != 0)
						{
							deptServ.Delete(deptn);
							Console.WriteLine("Department Deleted Successfully");
						}
						else
						{
							Console.WriteLine("You have entered invalid Code");
						}
						break;
					case 11:
						Console.WriteLine("Enter the Department code which want to udpdate");
						deptn = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Enter New Name as well location and Capacity of Department");
						 name = Console.ReadLine();
						 string loc = Console.ReadLine();
						 int cap = Convert.ToInt32(Console.ReadLine());
						deptServ.Update(deptn, new Department() { DeptName = name, Capacity = cap,Location=loc });
						break;
					case 12:
						try
						{
							Console.WriteLine("Enter Department id");
							int id = Convert.ToInt32(Console.ReadLine());
							deptServ.Get(id);
                            
						}
						catch(Exception)
                        {
                            Console.WriteLine("You may enter invalid Employee id");
                        }
						break;
					case 13:
                        Console.WriteLine("Enter the Employee id whose salary wants to increase");
						empid = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Enter New Name as well Salary of employee");
						 name = Console.ReadLine();
						Console.WriteLine("Enter previous salry");
						sal = Convert.ToInt32(Console.ReadLine());

						var emp = employees.Find(x => x.EmpNo == empid);

						int newsal = sal + (sal * 15) / 100;

                        Console.WriteLine($"New Salary :-  {newsal}");
						empServ.Update(empid, new Employee() {EmpName=name, Salary = newsal });
						Console.WriteLine("Salary is successfully updated");
						break;

					case 14:
						x = false;
						break;
                }

			}

		}

		static void PrintEmployeesByDeptName(string dname)
		{
			var result = employees.Where(e => e.DeptName == dname)
								  .OrderByDescending(e => e.EmpNo)
								  .Select(e => e);

			foreach (var item in result)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptName} {item.DeptNo}");
			}
		}

		static void MaxSalaryGroupByDept()
		{
			var result = from e in employees
						 group e by e.DeptNo into DeptGroup
						 select new
						 {
							 DeptNo = DeptGroup.Key,
							 Salary = DeptGroup.Max(e => e.Salary)
						 };
			foreach (var item in result)
			{
				Console.WriteLine($"{item.DeptNo}   {item.Salary}");
			}
		}

		public static int checkingCapicityAsperDepartment(int depid)
		{
			var dept = departments.Find(x => x.DeptNo == depid);
			Console.WriteLine(dept.Capacity);
			return dept.Capacity;
		}

		public static void increamentTheEmployeeSalary(int empid,Employee empObj)
		{
			var emp = employees.Find(x => x.EmpNo == empid);
			emp.Salary = empObj.Salary + (empObj.Salary * 15) / 100;
            Console.WriteLine($"{emp.Salary}");

		}


	}
}
