/*
 * Beethoven.Plugins
 * 
 * Written for .NET 4.0 in C#
 * 
 * Copyright (C) 2009, 2010, 2011. All Right Reserved, Spartansoft L.L.C.
 * http://spartansoft.org
 * 
 * Proprietary and Confidential information of Spartansoft L.L.C. 
 * Redistribution and use in source and binary forms, with or without modification, 
 * without the authorization of Spartansoft L.L.C.  is prohibited. * 
 * 
 * "Whatever happens SPARTAN's code must stand ... or at least crash responsibly."
 *  
 * File Name: UserProfile.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      04.08.2011 06:13 AM
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web;
using Beethoven.Plugins.Helpers;
using Beethoven.Plugins.ViewModels;

namespace Beethoven.Plugins.Account
{
    public class UserProfile : ProfileBase
    {
        public static UserProfile CurrentUser
        {
            get
            {
                if (System.Web.Security.Membership.GetUser() != null)
                    return ProfileBase.Create(System.Web.Security.Membership.GetUser().UserName) as UserProfile;
                else
                    return null;

            }
        }

        public static ProfileViewModel GetProfile()
        {
            if (CurrentUser != null)
                return new ProfileViewModel
                {
                    UserName = CurrentUser.UserName,
                    FullName = CurrentUser.FullName,
                    Email = CurrentUser.Email,
                    Phone = CurrentUser.Phone,
                    Gravatar = CurrentUser.Gravatar
                };
            else
                return new ProfileViewModel();
        }

        public static UserProfile GetUser(string username)
        {                           
                System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser(username);
                return ProfileBase.Create(user.UserName, true) as UserProfile;
           
        }

        public static UserProfile NewUser
        {
            get { return System.Web.HttpContext.Current.Profile as UserProfile; }
        }


        public string FullName
        {
            get { return ((string)(base["FullName"])); }
            set { base["FullName"] = value; Save(); }
        }

        public string Email
        {
            get { return ((string)(base["Email"])); }
            set { base["Email"] = value; Save(); }
        }

        public string Phone
        {
            get { return ((string)(base["Phone"])); }
            set { base["Phone"] = value; Save(); }
        }

        public string Gravatar
        {
            get {
                return GravatarHelper.GetUserGravatar(Email);
            }
        }

    }
}
