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
using Beethoven.Plugins.Security;

namespace Beethoven.Plugins.Security
{
    public interface ICapabilityProvider
    {
        void AddCapabilityToRole(string role,string capability);

        void RemoveCapabilityFromRole(string role, string capability);

        bool RemoveCapabilitiesFromRole(string role);

        List<Capability> GetRoleCapabilities(string role);

        List<Capability> GetCapabilities();

        bool IsUserAuthorized(string username, string[] capabilities);
    }
}