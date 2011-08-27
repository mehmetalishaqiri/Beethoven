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
using System.Web.Mvc;
using System.Web;
using System.Xml.Linq;
using System.Transactions;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Beethoven.Plugins.ViewModels;

namespace Beethoven.Plugins.Security
{
    public class RoleProvider: IRoleProvider
    {

        SecurityDataContext _context = new SecurityDataContext();
        #region IRoleProvider Members

        #region GetRoles

        public List<RolesViewModel> GetRoles()
        {
            List<RolesViewModel> model = new List<RolesViewModel>();

            var roles = _context.Roles;
            foreach (var role in roles)
            {
                if (role.RoleName != "SystemAdministrator")
                {
                    model.Add(new RolesViewModel
                    {
                        Role = role.RoleName,
                        Capabilities = (
                            from r in _context.Roles
                            join rc in _context.RoleCapabilities on r.RoleName equals rc.RoleName
                            join c in _context.Capabilities on rc.CapabilityID equals c.ID
                            where rc.RoleName == role.RoleName
                            select c
                        ).ToList()
                    });
                }
            }
            return model;
        }



        public RolesViewModel GetRole(string role)
        {
            RolesViewModel model = new RolesViewModel();

            var query = _context.Roles.Where(r=>r.RoleName == role).SingleOrDefault();
            if (query != null)
            {
                model.Role = query.RoleName;
                model.Capabilities = (
                        from rc in _context.RoleCapabilities
                        join c in _context.Capabilities on rc.CapabilityID equals c.ID
                        where rc.RoleName == query.RoleName && rc.RoleName != "SystemAdministrator"
                        select c
                    ).ToList();
            }
            return model;
        }
        #endregion

        #region AddRole

        public bool AddRole(string role,string[] capabilities)
        {
            bool retValue = false;
            try
            {
                string[] roles = GetRoles().Select(r => r.Role).ToArray();
                //if (roles.Where(r => r == role).Count() == 0)
                //{
                //using (TransactionScope scope = new TransactionScope())
                //{
                    if (!Roles.RoleExists(role))
                    {
                        Roles.CreateRole(role);
                    }
                    int rowsAffected = 0;
                    bool capabilitiesDeleted = false;
                    if (capabilities != null)
                    {
                        XDocument xmlDoc = new XDocument(
                            new XElement("capabilities")
                        );
                        foreach (string item in capabilities)
                        {
                            xmlDoc.Element("capabilities").Add(
                                new XElement("capability",
                                    new XAttribute("role", role),
                                    new XElement("capabilityid", item)
                                )
                            );
                        }
                        var connection = _context.Database.Connection;
                        connection.Open();
                        DbCommand command = connection.CreateCommand();
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "uspAddCapabilitiesToRole";
                        command.Parameters.Add(new SqlParameter("xml", DbType.Xml) { Value = xmlDoc.ToString() });
                        
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    else
                    {
                        ICapabilityProvider p = new CapabilityProvider();
                        capabilitiesDeleted = p.RemoveCapabilitiesFromRole(role);
                    }

                    if (rowsAffected > 0 || capabilitiesDeleted)
                    {
                        //scope.Complete();
                       
                        retValue = true;
                    }
                //}
                // }
            }
            catch (Exception ex)
            {
                //HttpContext context = System.Web.HttpContext.Current;
                //Elmah.ErrorSignal.FromContext(context).Raise(ex, context);
            }
            
            return retValue;
        }

        #endregion

        #region RemoveRole

        public bool RemoveRole(string role)
        {

            bool retValue = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    ICapabilityProvider p = new CapabilityProvider();
                    bool capabilitiesDeleted = p.RemoveCapabilitiesFromRole(role);

                    if (Roles.GetUsersInRole(role).Count() > 0)
                    {
                        Roles.RemoveUsersFromRole(Roles.GetUsersInRole(role), role);
                    }
                    Roles.DeleteRole(role, true);


                    if (capabilitiesDeleted)
                    {
                        scope.Complete();
                        retValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext context = System.Web.HttpContext.Current;
                //Elmah.ErrorSignal.FromContext(context).Raise(ex, context);
            }
            return retValue;
        }

        #endregion

        #region AddUserToRole

        public bool AddUserToRole(string username, string role)
        {
            bool retValue = false;
            try
            {
                Roles.AddUserToRole(username, role);
                retValue = true;
            }
            catch (Exception ex)
            {
                //HttpContext context = System.Web.HttpContext.Current;
                //Elmah.ErrorSignal.FromContext(context).Raise(ex, context);
            }
            return retValue;
        }

        #endregion

        #region GetUserRoles

        public string[] GetUserRoles(string username)
        {
            string[] roles = null;
            try
            {
                roles = Roles.GetRolesForUser(username);
            }
            catch (Exception ex)
            {
                //HttpContext context = System.Web.HttpContext.Current;
                //Elmah.ErrorSignal.FromContext(context).Raise(ex, context);  
            }
            return roles;
        }

        #endregion        

        #region RoleExists

        public bool RoleExists(string roleName)
        {
            return Roles.RoleExists(roleName);
        }

        #endregion

        #endregion

    }
}
