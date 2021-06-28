using CheckUserRole.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckUserRole.DAL
{
    public class UserRole : IUsers<Users, int>
    {
        DbContextClass context;
        public UserRole()
        {
            context = new DbContextClass();
        }
        public async Task<Users> CreateAsyncUser(Users model)
        {
            var res = await context.Users.AddAsync(model);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public static bool RegisterUser(Users user)
        {
            try
            {
                if (!user.UserName.Contains(" "))
                {
                    return true;
                }
               else if (!user.UserName.Contains("~"))
                {
                    return true;
                }
                else if (!user.UserName.Contains("_"))
                {
                    return true;
                }
               else if (!user.UserName.Contains("^[0-9]"))
                {
                    return true;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Entry Please try After Sometime!!!!");
            }
            
            return false;
        }

        public static bool UsernameLengthChecking(Users user)
        {

            try
            {
                if (user.UserName.Length >= 8)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Entry Please try After Sometime!!!!");
            }
            return false;
        }

        public static bool CheckingForEmail(Users user)
        {
            try
            {
                if (user.Email.Length > 10)
                {
                    return true;
                }
                else if (user.Email.Contains(@"?=^.{6,}$)(?=.*\d)(?=.*[a-zA-Z]"))
                {
                    return true;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Entry Please try After Sometime!!!!");
            }
            return false;
        }

        public static bool CheckingForPassword(Users user)
        {
            try
            {
                if(user.Password.Length>=8)
                {
                    return true;
                }
                else if (user.Password.Contains(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"))
                {
                    return true;
                }
                
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Entry Please try After Sometime!!!!");
            }
            return false;
        }

        public static bool CheckingForConPassword(Users user)
        {
            try
            {

                if (user.ConfirmPassowrd.Length >= 8)
                {
                    return true;
                }

               else if (user.ConfirmPassowrd.Contains(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"))
                {
                    return true;
                }


            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Entry Please try After Sometime!!!!");
            }
            return false;
        }




        public static string EncodePasswordToBase64(Users user)
        {
            try
            {
                byte[] encData_byte = new byte[user.Password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(user.Password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static bool AllMethodsOfUsersCallingHere(Users user)
        {
            UserRole.CheckingForEmail(user);
            UserRole.CheckingForPassword(user);
            UserRole.UsernameLengthChecking(user);
            UserRole.EncodePasswordToBase64(user);
            UserRole.RegisterUser(user);
            return true;
        }

        public static bool CheckingPasswordsAndConPassword(Users user)
        {
            try
            {
                if (user.Password == user.ConfirmPassowrd)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Entry Please try After Sometime!!!!");
            }
            return false;
        }
    }
}
