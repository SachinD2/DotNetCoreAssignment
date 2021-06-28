using CheckUserRole.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckUserRole.DAL
{
    public class RoleUser : IRole<Roles,int>
    {
        DbContextClass context;
        public RoleUser()
        {
            context = new DbContextClass();
        }
        public async Task<Roles> CreateRoleAsync(Roles entity)
        {
            try
            {
                var res = await context.Roles.AddAsync(entity);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                //  Console.WriteLine($"Exception occurred while adding the role {ex.Message}");
                throw ex;
            }
        }

        public static bool checkingRolesName(Roles role)
        {
            try
            {
                if (role.RoleName != null)
                {
                    return true;
                }
                if (role.RoleName == "^[A-Z]")
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

        public static bool checkingRolesExitsOrNot(Roles role)
        {
            try
            {
                if (role != null)
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
        public  async static Task<bool> checkingRoleDoesntExits(Roles role)
        {
            try
            {
                if (role.RoleName == null)
                {
                    await new RoleUser().CreateRoleAsync(role);
                    return true;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid Entry Please try After Sometime!!!!");
            }
            return false;
        }

      /*  public static bool AllMethodsOfRolesCallingHere(Roles role)
        {
            if (RoleUserImp.checkingRoleDoesntExits(role))
            {
                RoleUserImp ru = new RoleUserImp();
               await ru.CreateRoleAsync(new Roles() { });
                
            }
           

            RoleUserImp.checkingRolesExitsOrNot(role);


            ;
            

            return true;
        } */

    }
}
