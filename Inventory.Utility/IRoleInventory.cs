using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Utility
{
    public interface IRoleInventory
    {
        Task CreateNewRoleAsync();
        Task AddRoleAsync(string AppUserId);
    }
}
