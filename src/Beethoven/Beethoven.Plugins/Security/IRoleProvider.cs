/* *****************************************************************************************
                                Spartans<T> (Spartansoft L.L.C)
       "Whatever happens, SPARTAN'S code must stand ... or at least crash responsibly
   *****************************************************************************************
             Author:    Mehmetali N. Shaqiri
              Email:    m.shaqiri@spartansoft.org
   *****************************************************************************************
   Proprietary and Confidential information of Spartans<T>.  
   Redistribution and use in source and binary forms, with or without modification, 
   without the authorization of Spartans<T> is prohibited.
   *****************************************************************************************
                        Copyright (c) 2011, All rights reserved.
   *****************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Beethoven.Plugins.ViewModels;

namespace Beethoven.Plugins.Security
{
    public interface IRoleProvider
    {
        List<RolesViewModel> GetRoles();

        RolesViewModel GetRole(string role);

        bool AddRole(string role,string[] capabilities);

        bool RemoveRole(string role);

        bool AddUserToRole(string username,string role);

        string[] GetUserRoles(string username);

        bool RoleExists(string roleName);
    }
}
