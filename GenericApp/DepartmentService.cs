using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApp
{
    class DepartmentService : IService<Department, int>
    {
        DepartmentDb deptdb;
        public DepartmentService()
        {
            deptdb = new DepartmentDb();
        }
        public IEnumerable<Department> Create(Department model)
        {
            deptdb.Add(model);
            return deptdb;
        }

        public bool Delete(int id)
        {
            var dept = deptdb.Find(x => x.DeptNo == id);

            if (dept != null)
            {

                return deptdb.Remove(dept);
            }
            else
            {
                return false;
            }
        }

        public void Get()
        {
            foreach (var item in deptdb)
            {
                Console.WriteLine($"{item.DeptNo} {item.DeptName} { item.Location} { item.Capacity}");
            }
        }

        public void Get(int id)
        {
            var item = deptdb.Find(x => x.DeptNo == id);
            Console.WriteLine($"{item.DeptNo} {item.DeptName} { item.Location} { item.Capacity}");
        }

        public void Update(int id, Department model)
        {
            var item = deptdb.Find(x => x.DeptNo == id);
            item.DeptName = model.DeptName;
            item.Location = model.Location;
            item.Capacity = model.Capacity;
            Console.WriteLine("Updated Employee details : ");
            Console.WriteLine($"{item.DeptName} {item.Location} {item.Capacity}");
        }
    }
}
