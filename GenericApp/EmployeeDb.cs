using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApp
{
    public class EmployeeDb : List<Employee>
    {
        public EmployeeDb()
        {
			Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", Salary = 23001, DeptNo = 10,DeptName ="HR" });
			Add(new Employee() { EmpNo = 102, EmpName = "Vikram", Salary = 23002, DeptNo = 20, DeptName = "Finance" });
			Add(new Employee() { EmpNo = 103, EmpName = "Suprotim", Salary = 23003, DeptNo = 30, DeptName = "Engineering" });
			Add(new Employee() { EmpNo = 104, EmpName = "Subodh", Salary = 23004, DeptNo = 40, DeptName = "Admin" });
			Add(new Employee() { EmpNo = 105, EmpName = "Vikas", Salary = 23005, DeptNo = 10 , DeptName = "HR" });
			Add(new Employee() { EmpNo = 106, EmpName = "Manish", Salary = 23006, DeptNo = 20, DeptName = "Finance" });
			Add(new Employee() { EmpNo = 107, EmpName = "Tejas", Salary = 23007, DeptNo = 30, DeptName = "Engineering" });
			Add(new Employee() { EmpNo = 108, EmpName = "Gajanan", Salary = 23008, DeptNo = 40, DeptName = "Admin" });
			Add(new Employee() { EmpNo = 109, EmpName = "Deepak", Salary = 23009, DeptNo = 10, DeptName = "HR" });
			Add(new Employee() { EmpNo = 110, EmpName = "Nitin", Salary = 23001, DeptNo = 20, DeptName = "Finance" });
			Add(new Employee() { EmpNo = 111, EmpName = "Ajay", Salary = 23002, DeptNo = 30, DeptName = "Engineering" });
			Add(new Employee() { EmpNo = 112, EmpName = "Suraj", Salary = 23003, DeptNo = 40, DeptName = "Admin" });
			Add(new Employee() { EmpNo = 113, EmpName = "Akash", Salary = 23004, DeptNo = 10, DeptName = "HR" });
			Add(new Employee() { EmpNo = 114, EmpName = "Mukesh", Salary = 23004, DeptNo = 20, DeptName = "Finance" });
			Add(new Employee() { EmpNo = 115, EmpName = "Vivek", Salary = 23006, DeptNo = 30, DeptName = "Engineering" });
			Add(new Employee() { EmpNo = 116, EmpName = "Satish", Salary = 23007, DeptNo = 40, DeptName = "Admin" });
		}
    }

	public class DepartmentDb : List<Department>
	{
		public DepartmentDb()
		{
			Add(new Department() { DeptNo = 10, DeptName = "HR", Location = "Pune", Capacity = 10 });
			Add(new Department() { DeptNo = 20, DeptName = "Finance", Location = "Pune", Capacity = 5 });
			Add(new Department() { DeptNo = 30, DeptName = "Engineering", Location = "Pune", Capacity = 4 });
			Add(new Department() { DeptNo = 40, DeptName = "Admin", Location = "Pune", Capacity = 4 });
		}
	}
}
