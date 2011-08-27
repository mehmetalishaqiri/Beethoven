using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beethoven.Plugins.ViewModels
{
    public class UsersInRoleViewModel
    {
        public UsersInRoleViewModel()
        {
            UsersInRole = new List<UsersInRole>();
        }
        public List<UsersInRole> UsersInRole { get; set; }

        public int TotalUsers { get; set; }


    }

    public class UsersInRole
    {
        public string Role { get; set; }

        public int Users { get; set; }
    }
}
