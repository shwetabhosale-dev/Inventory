using Inventory.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Utility
{
    public class RoleInventory : IRoleInventory
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleInventory(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddRoleAsync(string AppUserId)
        {
           var user = await _userManager.FindByIdAsync(AppUserId);
           var roles = _roleManager.Roles;
            List<string> StringRoles = new List<string>();

            if (user != null)
            {
                foreach (var item in roles)
                {
                    StringRoles.Add(item.Name);
                }
                await _userManager.AddToRolesAsync(user, StringRoles);
            }
        }

        public async Task CreateNewRoleAsync()
        {
            Type t = typeof(TopMenu);
            foreach(Type classObj in t.GetNestedTypes())
            {
                foreach(var objField in classObj.GetFields())
                {
                    if(!await _roleManager.RoleExistsAsync(objField.Name))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(objField.Name));
                    }
                }
            }
        }
    }
}
