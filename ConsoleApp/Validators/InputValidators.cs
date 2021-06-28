using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Models;
using Core_Console_App.Models;

namespace Core_Console_App.Validators
{
    public static class InputValidators
    {
		public static List<string> DeptValidator(Department department)
		{
			List<string> errors = new List<string>();
			var item = char.ToUpper(department.DeptName[0]) + department.DeptName.Substring(1);

			if (department.DeptNo == String.Empty)
				errors.Add("DeptNo is Must");


			if (department.DeptName == String.Empty || department.DeptName != item)
			{
				// Below add method converts first char of string into upprcase
				errors.Add("Dept name should not be empty or dept name should in upper case");
			}
			if(department.Location == string.Empty)
            {
				errors.Add("Location is must");
            }
			return errors;
		}
	}
}
