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
