using System;
using System.Collections.Generic;
using System.Text;

namespace CSAssign
{
    class Employee
    {
       public int empId { get; set; }
       public string empName { get; set; }
       public int deptno { get; set; }
       public string dname { get; set; }
        public int salary { get; set; }

        List<Employee> empList = new List<Employee>();
        public Employee()
        {
            
        }
       /* public Employee(int empId,string empName, string email, int deptno, string dname)
        {
            
            this.empId = empId;
            this.empName = empName;
            this.email = email;
            this.deptno = deptno;
            this.dname = dname;
        }
     */
        public void addEmployee()
        {
            /* Console.WriteLine("Enter the EmpID");
            empid =Console.ReadLine();
            Console.WriteLine("Enter The Employee Name");
            Console.WriteLine("Enter the Email");*/
            empList.Add(new Employee() {empId = 1, empName = "Meharsh",deptno= 10, dname = "HR",salary=100 });
            empList.Add(new Employee() { empId = 2, empName = "Devansh", deptno = 10, dname = "HR", salary = 300 });
            empList.Add(new Employee() { empId =3, empName="shivu", deptno=10,dname="HR", salary = 200 });
            empList.Add(new Employee() {empId= 4, empName="Shivu",deptno= 20, dname= "Engineering", salary = 300 });
            empList.Add(new Employee() { empId = 5, empName = "Danny", deptno = 20, dname = "Engineering", salary = 500 });
            empList.Add(new Employee() { empId = 6, empName = "Sakshi", deptno = 30, dname = "Finance", salary = 700 });
            empList.Add(new Employee() { empId = 7, empName = "shivsena", deptno = 30, dname = "Finance", salary = 900 });
            empList.Add(new Employee() { empId = 8, empName = "anagha", deptno = 30, dname = "Finance", salary = 800 });
            empList.Add(new Employee() { empId = 9, empName = "Menna", deptno = 20, dname = "Engineering", salary = 600 });
            empList.Add(new Employee() {empId = 10, empName = "harsh", deptno = 10, dname = "HR", salary = 700 });
        }
       
        public void allEmpList(string dname)
        {
            foreach (var item in empList)
            {
                if (item.dname == "HR")
                {
                    Console.WriteLine(item.empId + "  " + item.empName + "  " + item.dname+"  "+item.salary);
                }
                if (item.dname == "Engineering")
                {
                    Console.WriteLine(item.empId + "  " + item.empName + "  " + item.dname + "  " + item.salary);
                }
                if (item.dname == "Finance")
                {
                    Console.WriteLine(item.empId + "  " + item.empName + "  " + item.dname + "  " + item.salary);
                }
            }
        }

        public void maxSalary()
        {
            empList.Sort();
        }
    }
}
