using MVCData.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Models
{
    public class UsersViewModel : DBModel
    {
        public List<ApplicationUser> UsersInDB;
        public List<User> Users;
        public List<IdentityRole> Roles;
        public List<IdentityUserRole<string>> UserRoles;

        public UsersViewModel(Controller aController, DatabaseMVCEFDbContext dbContext) : base(aController, dbContext)
        {
            Users = new List<User>();

            // Build a list of users which is used in the view:
            foreach (var user in UsersInDB)
            {
                var userObj = new User(user);
                string rolesString = string.Empty;

                // Read user roles:
                foreach (var userRole in UserRoles)
                {
                    if (userRole.UserId == user.Id)
                    {
                        var role = EFDBContext.Roles.Find(userRole.RoleId);
                        if (role != null)
                        {
                            if (rolesString.Length > 0)
                            {
                                rolesString += ",";
                            }
                            rolesString += role.Name;
                        }
                    }
                }

                userObj.RolesString = rolesString;
                Users.Add(userObj);
            }
        }

        public override void ReadDB()
        {
            base.ReadDB(); // Run inherited ReadDB..

            UsersInDB = EFDBContext.Users.ToList();
            Roles = EFDBContext.Roles.ToList();
            UserRoles = EFDBContext.UserRoles.ToList();

            aController.ViewBag.Roles = Roles;
        }


        public User FindUserByID(string aUserID)
        {
            User user = null;

            foreach (var item in Users)
            {
                if (item.Id == aUserID)
                {
                    user = item;
                    break;
                }
            }
            return user;
        }

    }
}

