using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Models;
using Core_Console_App.Models;

namespace ConsoleApp.Validators
{
    public class EmployeeInputValidators
    {
		public static bool EmpValidator(Employee employee)
		{
			List<string> errors = new List<string>();
			var item = char.ToUpper(employee.EmpName[0]) + employee.EmpName.Substring(1);

			if (employee.Empno == String.Empty)
				errors.Add("EmpNo is Must");


			if (employee.EmpName == String.Empty || employee.EmpName != item)
			{
				// Below add method converts first char of string into upprcase
				errors.Add("Dept name should not be empty or dept name should in upper case");
			}
			if (employee.Salary == 0 || employee.Salary > 0)
			{
				errors.Add("Salary is must or postive should not be negative");
			}
			if(employee.Designation == "Manager" || employee.Designation == "Operator" || employee.Designation == "Clerk" ||
				employee.Designation == "Engineer")
            {
				errors.Add("Designation is not matching");
			}
			if(employee.DeptUniqueId > 0)
            {
				errors.Add("DeptUniqueId is Must");
			}
				return true;
		}
	}
}
