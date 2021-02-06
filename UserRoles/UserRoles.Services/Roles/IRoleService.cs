using System;
using UserRoles.Models.Models;

namespace UserRoles.Services.Roles
{
    public interface IRoleService
    {
        public IServiceResponse<RoleModel> GetRoleById(int userId, int roleGroupID, Int64 roleID);
        public IServiceResponse<RoleModel> GetRoleListByGroupId(int userId, int roleGroupID);
    }
}
