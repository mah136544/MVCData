using MVCData.Data;
using MVCData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : EFDBController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(DatabaseMVCEFDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            this.userManager = userManager;

        }

        // public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            UsersViewModel usersViewModel = new UsersViewModel(this, EFDBContext);

            return View(usersViewModel);
        }

        public IActionResult EditUser(string id)
        {
            UsersViewModel usersViewModel = new UsersViewModel(this, EFDBContext);

            var user = usersViewModel.FindUserByID(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(EditUserInputModel userData)
        {
            if (ModelState.IsValid)
            {
                var id = userData.Id;
                var user = EFDBContext.Users.Find(id);

                if (user != null)
                {
                    user.UserName = userData.UserName;
                    user.NormalizedUserName = userData.UserName.ToUpper();
                    user.FirstName = userData.FirstName;
                    user.LastName = userData.LastName;
                    user.Email = userData.Email;
                    user.NormalizedEmail = userData.Email.ToUpper();
                    user.BirthDate = userData.BirthDate;
                    user.PhoneNumber = userData.PhoneNumber;

                    if (userData.Password != null)
                    {
                        var hasher = new PasswordHasher<ApplicationUser>();
                        user.PasswordHash = hasher.HashPassword(user, userData.Password);
                    }
                    EFDBContext.Users.Update(user);
                    EFDBContext.SaveChanges();

                    var userRoles = EFDBContext.UserRoles.ToList();

                    // Update user role:
                    int count = userRoles.Count;
                    bool roleUpdated = false;
                    for (int i = 0; i < count; i++)
                    {
                        var userRole = userRoles[i];

                        if (userRole.UserId == id)
                        {
                            if (!roleUpdated)
                            {
                                userRole.RoleId = userData.RoleId;
                                roleUpdated = true;
                            }
                            else
                            { // If more than one role found delete the other roles
                                EFDBContext.UserRoles.Remove(userRole);
                            }
                        }
                    }

                    if (!roleUpdated && userData.RoleId.Length > 0)
                    { // User hasn't any roles.. Add one:
                        var role = new IdentityUserRole<string>();
                        role.UserId = id;
                        role.RoleId = userData.RoleId;
                        EFDBContext.UserRoles.Add(role);
                    }
                    EFDBContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(string id)
        {
            var user = EFDBContext.Users.Find(id);

            if (user != null)
            {
                EFDBContext.Users.Remove(user);
                EFDBContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}


