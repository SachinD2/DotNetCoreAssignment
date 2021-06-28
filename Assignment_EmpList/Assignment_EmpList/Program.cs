using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_EmpList
{
    class Program
    {

       public static void Main(string[] args)
        {

            Program obj = new Program();

            obj.GetEmpList("Account");             
            Console.ReadLine();
        }

      
        public void GetEmpList(string dname)
        {
            if (dname == "Account")
            {
                List<Employee> lstEmp = new List<Employee>();
                lstEmp.Add(new Employee() { EmpId = 1, Name = "Sachin", Salary = 10000, Department = "Sales" });
                lstEmp.Add(new Employee() { EmpId = 2, Name = "Amol", Salary = 15000, Department = "Finance" });
                lstEmp.Add(new Employee() { EmpId = 3, Name = "Anand", Salary = 20000, Department = "Sales" });
                lstEmp.Add(new Employee() { EmpId = 4, Name = "Ganesh", Salary = 20000, Department = "Account" });
                lstEmp.Add(new Employee() { EmpId = 5, Name = "Meharsh", Salary = 30000, Department = "Merketing" });
                lstEmp.Add(new Employee() { EmpId = 6, Name = "Santosh", Salary = 20000, Department = "Finance" });
                lstEmp.Add(new Employee() { EmpId = 7, Name = "Yogesh", Salary = 40000, Department = "Account" });
                lstEmp.Add(new Employee() { EmpId = 8, Name = "Balaji", Salary = 45000, Department = "Sales" });
                lstEmp.Add(new Employee() { EmpId = 9, Name = "Anand", Salary = 35000, Department = "Merketing" });
                lstEmp.Add(new Employee() { EmpId = 10, Name = "Rohit", Salary = 43000, Department = "Sales" });
                lstEmp.Add(new Employee() { EmpId = 11, Name = "Dhananjay", Salary = 48000, Department = "Account" });
                lstEmp.Add(new Employee() { EmpId = 12, Name = "Javed", Salary = 50000, Department = "Merketing" });
                lstEmp.Add(new Employee() { EmpId = 13, Name = "Suraj", Salary = 80000, Department = "Account" });
                lstEmp.Add(new Employee() { EmpId = 14, Name = "Dhiraj", Salary = 90000, Department = "Merketing" });
                lstEmp.Add(new Employee() { EmpId = 15, Name = "Anil", Salary = 85000, Department = "Account" });
              
               
            }

           

        }
    }
    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
    }


}
