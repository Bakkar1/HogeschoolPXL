using HogeschoolPxl.Data.Default;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Data
{
    public partial class PartialSQLPxlRepository
    {
        public SelectList GetRoles()
        {
            return new SelectList(roleManager.Roles, "Id", "Name");
        }
        public string GetRoleName(string UserId)
        {
            var identityUserRole = _context.UserRoles.Where(us => us.UserId == UserId).FirstOrDefault();

            return identityUserRole == null ? "" : identityUserRole.RoleId;
        }
        public void DeleteOldRoles(string UserId)
        {
            var userRole =  _context.UserRoles.Where(us => us.UserId == UserId).FirstOrDefault();
            if(userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();
            }

        }
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public async Task<string> CurrentUserRoleName()
        {
            var claimsPrincipal = ViewContext.HttpContext.User;
            var identityUser = await userManager.GetUserAsync(claimsPrincipal);
            if (identityUser != null)
            {
                if (await userManager.IsInRoleAsync(identityUser, Roles.LectorRole))
                {
                    return Roles.LectorRole;
                }
                else if(await userManager.IsInRoleAsync(identityUser, Roles.AdminRole))
                {
                    return Roles.AdminRole;
                }
                else if (await userManager.IsInRoleAsync(identityUser, Roles.StudentRole))
                {
                    return Roles.StudentRole;
                }
                return "";
            }
            return "";
        }
    }
}
