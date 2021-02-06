﻿using System;

namespace UserRoles.Core
{
    [AttributeUsage(AttributeTargets.All)]
    public class RoleAttribute : Attribute
    {
        int roleGroupID;
        Int64 roleID;
        public RoleAttribute(int RoleGroupID, Int64 RoleID)
        {
            this.roleGroupID = RoleGroupID;
            this.roleID = RoleID;
        }

        public int RoleGroupID
        {
            get { return roleGroupID; }
        }

        // property to get description 
        public Int64 RoleID
        {
            get { return roleID; }
        }
    }
}
