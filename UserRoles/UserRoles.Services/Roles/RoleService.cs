using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UserRoles.Models.Models;
using UserRoles.Repository;

namespace UserRoles.Services.Roles
{
    public class RoleService : IRoleService
    {
        //// userRolesRepository =User’a ait rollerin, tutulduğu tablodur.UserRole tablosuna karşılık gelir.
        private readonly IRepository<UserRoles.Data.Entities.UserRoles> _userRolesRepository;

        // rolesRepositor =Sayfalara göre guruplanmış, tüm rollerin listesinin tutulduğu tablodur. Roles tablosuna karşılık gelir.
        //get customer=2  get customer liste= 4
        private readonly IRepository<UserRoles.Data.Entities.Roles> _rolesRepository;
        public RoleService(IRepository<UserRoles.Data.Entities.UserRoles> userRolesRepository, IRepository<UserRoles.Data.Entities.Roles> rolesRepository)
        {
            _userRolesRepository = userRolesRepository;
            _rolesRepository = rolesRepository;
        }

        public IServiceResponse<RoleModel> GetRoleById(int userId, int roleGroupID, Int64 roleID)
        {
            var response = new ServiceResponse<RoleModel>();
            RoleModel model = new RoleModel();
            var userRole = _userRolesRepository.Table
                .Include(r => r.RoleGroup)
                .FirstOrDefault(ur => ur.UserId == userId && ur.RoleGroupId == roleGroupID); //bana 7 sayısını dönecek
            if (userRole != null)
            {
                if (roleID == (userRole.Roles & roleID)) // 7'in içinde 4 var mı?
                {
                    var role = _rolesRepository.Table.Where(r => r.RoleId == roleID).FirstOrDefault();
                    if (role != null)
                    {
                        model = new RoleModel() { Id = role.Id, RoleName = role.RoleName, RoleGroupID = (int)userRole.RoleGroupId, RoleID = roleID, UserID = userId, GroupName = userRole.RoleGroup.GroupName };
                    }
                }
                response.Entity = model;
            }
            return response;
        }

        //7nin içindeki tüm rolleri getir
        //customer ıdsi iki olanı tüm rolleri
        //userin girebileceği tüm metotların listesini döner
        public IServiceResponse<RoleModel> GetRoleListByGroupId(int userId, int roleGroupID)
        {
            var response = new ServiceResponse<RoleModel>();
            List<RoleModel> model = new List<RoleModel>();
            var userRole = _userRolesRepository.Table.FirstOrDefault(ur => ur.UserId == userId && ur.RoleGroupId == roleGroupID);
            if (userRole != null)
            {
                var allRoles = _rolesRepository.Table
                    .Include(r => r.Group)
                    .Where(r => r.GroupId == roleGroupID).ToList();
                foreach (var role in allRoles)
                {
                    if (role.RoleId == (userRole.Roles & role.RoleId))
                    {
                        model.Add(new RoleModel() { Id = role.Id, RoleName = role.RoleName, RoleGroupID = (int)role.GroupId, RoleID = (int)role.RoleId, UserID = userId, GroupName = role.Group.GroupName });
                    }
                }
                response.List = model;
            }
            return response;
        }
    }
}
