using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApp
{
    public class EmployeeService : IService<Employee, int>
    {
        EmployeeDb empDb;

        public EmployeeService()
        {
            empDb = new EmployeeDb();
        }
        public IEnumerable<Employee> Create(Employee obj)
        {
            empDb.Add(obj);
            return empDb;
        }

        public bool Delete(int id)
        {
            var emp = empDb.Find(x => x.EmpNo == id);

            if (emp != null)
            {
                
                return empDb.Remove(emp);
            }
            else
            {   
                return false;
            }
        }

        public void Get()
        {
            foreach (var item in empDb)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} { item.Salary} { item.DeptName}  {item.DeptNo}");
            }
            
        }

        public void Get(int id)
        {
            var item = empDb.Find(x => x.EmpNo == id);
            Console.WriteLine($"{item.EmpNo} {item.EmpName} { item.Salary} { item.DeptName}  {item.DeptNo}");
           
        }

        public void Update(int id, Employee model)
        {
            var item = empDb.Find(x => x.EmpNo == id);
            item.EmpName = model.EmpName;
            item.Salary = model.Salary;
            Console.WriteLine("Updated Employee details : ");
            Console.WriteLine($"{item.EmpName} {item.Salary}");
        }
    }
}
