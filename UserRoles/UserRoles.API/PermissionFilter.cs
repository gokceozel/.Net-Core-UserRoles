using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRoles.Core;
using UserRoles.Services.Roles;

namespace UserRoles.API
{
    public class PermissionFilter :IActionFilter
    {
        private readonly IRoleService _roleService;
        public PermissionFilter(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            int.TryParse(context.HttpContext.Request.Headers["UserId"].FirstOrDefault(), out var userId);
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public bool HasRoleAttribute(FilterContext context)
        {
            return ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.Any(filterDescriptors => filterDescriptors.AttributeType == typeof(RoleAttribute));
        }
    }
}
