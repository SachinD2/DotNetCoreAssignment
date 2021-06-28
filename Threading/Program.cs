using System;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace Threading
{
	class Program
	{
		static EmployeeDb database = new EmployeeDb();
		static void Main(string[] args)
		{

			Console.WriteLine($"Sequential Operation starts at {DateTime.Now.ToString()}");
			
			bool x = true;
			while(x ==true)
            {
				Console.WriteLine("--------------------Menu------------------");
                Console.WriteLine("1. Write the File");
				Console.WriteLine("2. Read the File");
				Console.WriteLine("3. Calculate tax as per designation");
                Console.WriteLine("4. parallel execution of employees");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter your choice");
				int choice = Convert.ToInt32(Console.ReadLine());
				switch(choice)
                {
					case 1:
						Parallel.Invoke(
							 () => FileOperations.WriteFile()
							);
						break;
					case 2:

						Parallel.Invoke(
							  () => FileOperations.ReadFile()
							);

						break;
					case 3:
						Console.WriteLine("Tax as per Designation");
						Console.WriteLine("Enter the Designation");
						string desg = Console.ReadLine();
						Console.WriteLine("Enter the Employee Id");
						int id = Convert.ToInt32(Console.ReadLine());
						ProcessTax.TaxByDesignation(new Employee() { Designation = desg, EmpNo = id });
						break;
					case 4:
							Console.WriteLine("Using Parallel Processing");
							var parallel = Stopwatch.StartNew();

							Parallel.For(0, database.Count, i =>
							{
								ProcessTax.CalculateTax(database[i]);
								Console.WriteLine($"Tax for {database[i].EmpNo} {database[i].EmpName} is {database[i].Designation} and tax is {database[i].Tax}");
							});
							Console.WriteLine($"Total Time to Calculate the Tax for all employees parallely = {parallel.Elapsed.TotalMilliseconds}");
							break;
					case 5:
						x = false;
						break;
				}
			}
			Console.ReadLine();
		}

		public static class ProcessTax
		{
			public static Employee CalculateTax(Employee e)
			{
				Thread.Sleep(1000);
				if (e.DeptNo == 20 || e.DeptNo == 40)
				{
					e.Tax = e.Salary * Convert.ToDecimal(0.4);
				}
				else
				{
					e.Tax = e.Salary * Convert.ToDecimal(0.2);
				}

				return e;
			}

			public static void TaxByDesignation(Employee e)
			{
				var item = database.Find(x => x.EmpNo == e.EmpNo);
				if (item.Designation == "Manager")
				{
					if (item.EmpNo == e.EmpNo)
					{
						var tax = (item.Salary * 30) / 100;
						Console.WriteLine($"salary of manager is {item.Salary} and tax deduction is {tax}");
					}
					else
					{
						Console.WriteLine("You may entered wrong employee id");
					}
				}
				else if (item.Designation == "Engineering")
				{
					if (item.EmpNo == e.EmpNo)
					{
						var tax = (item.Salary * 25) / 100;
						Console.WriteLine($"salary of Engineer is {item.Salary} and tax deduction is {tax}");
					}
					else
					{
						Console.WriteLine("You may entered wrong employee id");
					}
				}
				else if (item.Designation == "Lead")
				{
					if (item.EmpNo == e.EmpNo)
					{
						var tax = (item.Salary * 28) / 100;
						Console.WriteLine($"salary of Lead is {item.Salary} and tax deduction is {tax}");
					}
					else
					{
						Console.WriteLine("You may entered wrong employee id");
					}
				}
				else if (item.Designation == "Programming")
				{
					if (item.EmpNo == e.EmpNo)
					{
						var tax = (item.Salary * 22) / 100;
						Console.WriteLine($"salary of Programmer is {item.Salary} and tax deduction is {tax}");
					}
					else
					{
						Console.WriteLine("You may entered wrong employee id");
					}
				}
				else
				{
					Console.WriteLine("Invalid entry");
				}
			}

		}


		public static class FileOperations
		{
			public static void ReadFile()
			{
				Thread.Sleep(2000);
				using (Stream fs = new FileStream(@"File.txt", FileMode.Open, FileAccess.Read))
				{
					StreamReader Reader = new StreamReader(fs);
					Console.WriteLine(Reader.ReadToEnd());
					Reader.Close();
				}
			}

			public static void WriteFile()
			{
				Thread.Sleep(2000);
				using (Stream fs = new FileStream(@"File.txt", FileMode.OpenOrCreate, FileAccess.Write))
				{
					EmployeeDb empDb = new EmployeeDb();
					Employee emp = new Employee();
				
					StreamWriter writer = new StreamWriter(fs);
					foreach(var file in empDb)
                    {
						writer.WriteLine($"{file.EmpNo}  {file.EmpName} {file.Salary} {file.Designation}");
                    }
                    Console.WriteLine("Employee added into the file");
					writer.Close();
				}
			}
		}
	}
}
