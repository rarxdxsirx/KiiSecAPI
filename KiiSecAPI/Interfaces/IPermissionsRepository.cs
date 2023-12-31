﻿using KiiSecAPI.Models;

namespace KiiSecAPI.Interfaces
{
    public interface IPermissionsRepository
    {
        ICollection<Permission> GetPermissions();
        Permission GetPermissionById(int id);
    }
}
