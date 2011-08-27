using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Beethoven.Plugins.Security
{
    [DataContract]
    public class RoleCapability
    {
        [DataMember]
        [Key]
        [Column(Order = 0)]
        public string RoleName { get; set; }


        [DataMember]
        [Key]
        [Column(Order = 0)]
        public Guid CapabilityID { get; set; }

        
    }
}
