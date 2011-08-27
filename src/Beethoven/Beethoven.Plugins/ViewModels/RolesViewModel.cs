using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beethoven.Plugins.Security;

namespace Beethoven.Plugins.ViewModels
{
    public class RolesViewModel
    {
        public string Role { get; set; }

        public List<Capability> Capabilities { get; set; }

    }
}
