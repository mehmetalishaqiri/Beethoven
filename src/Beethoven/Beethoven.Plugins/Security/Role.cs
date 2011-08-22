using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beethoven.Plugins.Security
{
    public class Role
    {
        public Guid ApplicationId { get; set; }

        public Guid RoleId { get; set; }

        public string Name { get; set; }

        public string LoweredRoleName { get; set; }

        public string  Description { get; set; }

        public virtual ICollection<Capability> Capabilities { get; set; }
    }
}
