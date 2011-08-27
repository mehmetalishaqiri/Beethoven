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

using System.Web;
using Beethoven.Plugins.ViewModels;
using System.Web.Security;
using Beethoven.Plugins.Security;

namespace Beethoven.Plugins.Security
{
    public class CapabilityProvider : ICapabilityProvider
    {
        #region Private Members

        SecurityDataContext _context = new SecurityDataContext();

        #endregion
        
        #region ICapabilityProvider Members

        public void AddCapabilityToRole(string role, string capability)
        {
            throw new NotImplementedException();
        }

        public void RemoveCapabilityFromRole(string role, string capability)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCapabilitiesFromRole(string role)
        {
            bool retValue = false;
            try
            {
                List<RoleCapability> roleCapabilities = _context.RoleCapabilities.Where(r => r.RoleName == role).ToList();
                roleCapabilities.ForEach(rc => _context.RoleCapabilities.Remove(rc));
                _context.SaveChanges();
                retValue = true;
            }
            catch (Exception ex)
            {
                HttpContext context = System.Web.HttpContext.Current;
                //Elmah.ErrorSignal.FromContext(context).Raise(ex, context);
            }
            return retValue;
        }

        public List<Capability> GetRoleCapabilities(string role)
        {            
           
            List<Capability> list = new List<Capability>();
            try
            {
                list = (
                        from r in _context.Roles
                        join rc in _context.RoleCapabilities on r.RoleName equals rc.RoleName
                        join c in _context.Capabilities on rc.CapabilityID equals c.ID
                        where r.RoleName == role
                        select c).Distinct().ToList();
            }
            catch (Exception ex)
            {
                //HttpContext context = System.Web.HttpContext.Current;
                //Elmah.ErrorSignal.FromContext(context).Raise(ex, context);
            }
            return list;
        }

        public List<Capability> GetCapabilities()
        {
            return _context.Capabilities.ToList();
        }

        #endregion


        

        public bool IsUserAuthorized(string username, string[] capabilities)
        {
            bool IsUserAuthorized = false;
            string[] roles = new RoleProvider().GetUserRoles(username);

            foreach (string role in roles)
            {
                List<Capability> roleCapabilities = new CapabilityProvider().GetRoleCapabilities(role);

                foreach (Capability c in roleCapabilities)
                {
                    if (capabilities.Contains(c.Name))
                    {
                        IsUserAuthorized = true;
                    }
                }
            }
            return IsUserAuthorized;
        }


        public List<Capability> GetUserCapabilities(string username)
        {
            List<Capability> capabilities = new List<Capability>();
            var roles = Roles.GetRolesForUser(username);
            capabilities = (
                        from r in _context.Roles
                        join rc in _context.RoleCapabilities on r.RoleName equals rc.RoleName
                        join c in _context.Capabilities on rc.CapabilityID equals c.ID
                        where roles.Contains(r.RoleName)
                        select c).Distinct().ToList();

            return capabilities;

        }
    }
}