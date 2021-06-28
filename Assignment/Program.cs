using System;
using CheckUserRole.DAL;
using CheckUserRole.Models;



namespace CheckUserRole
{
    class Program
    {
        static IRole<Roles, int> roleServ = new RoleUser();
        static IUsers<Users, int> userServ = new UserRole();

        static void Main(string[] args)
        {
            bool x = true;
            while (x == true)
            {
                Console.WriteLine("=======MENU===================");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Role");

                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        
                        
                        Console.WriteLine("Enter User name");
                        string name =Console.ReadLine();
                        if (UserRole.UsernameLengthChecking(new Users() { UserName =name}))
                        {
                            Console.WriteLine("Username is valid");
                        }
                        else
                        {
                            Console.WriteLine("Username is Invalid");
                        }
                        Console.WriteLine("Enter User Email");
                        string email = Console.ReadLine();
                        if(UserRole.CheckingForEmail(new Users() { Email = email })) 
                        {
                            Console.WriteLine("Email is valid");
                        }
                        else
                        {
                            Console.WriteLine("Email is Invalid");
                        }
                        Console.WriteLine("Enter User Password");
                        string pwd = Console.ReadLine();
                        if(UserRole.CheckingForPassword(new Users() { Password=pwd}))
                        {
                            Console.WriteLine("Password is valid");
                        }
                        else
                        {
                            Console.WriteLine("Password is Invalid");
                        }

                        Console.WriteLine("Enter User Confirm Password");
                        string Conpwd = Console.ReadLine();
                        if (UserRole.CheckingForConPassword(new Users() { ConfirmPassowrd = Conpwd }))
                        {
                            Console.WriteLine("Confirm Password is valid");
                        }
                        else
                        {
                            Console.WriteLine("Confirm Password is Invalid");
                        }

                        Console.WriteLine("Enter Role ID");
                        int rid = Convert.ToInt32(Console.ReadLine());

                        if(UserRole.CheckingPasswordsAndConPassword(new Users() { Password = pwd, ConfirmPassowrd=Conpwd}))
                        {
                            Console.WriteLine("Password and Confirm Password are Same");
                        }
                        else
                        {
                            Console.WriteLine("Password and Confirm Password are not matching");
                        }

                          userServ.CreateAsyncUser(new Users()
                            {
                                UserName = name,
                                Email = email,
                                Password = pwd,
                                ConfirmPassowrd = Conpwd ,                               
                                RoleId = rid,
                            });
                            Console.WriteLine("User Added Successfully!!");
                       
                        break;

                    case 2:
                        
                        Console.WriteLine("Enter Role name");
                        string rname = Console.ReadLine();
                        if (RoleUser.checkingRolesName(new Roles() { RoleName = rname}))
                        {
                            Console.WriteLine("Role Name is valid");
                        }
                        else
                        {
                            Console.WriteLine("Role Name is Invalid");
                        }
                        
                            roleServ.CreateRoleAsync(new Roles()
                                {
                                    RoleName = rname,
                                });
                                Console.WriteLine("Role Added Successfully!!");
                      
                        break;
                }
            }
        }
    }
}
