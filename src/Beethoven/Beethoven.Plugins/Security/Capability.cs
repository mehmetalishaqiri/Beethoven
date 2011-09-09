/*
 * Beethoven - A lightweight framework for building plugin based 
 * web applications using Asp.Net MVC and MEF.
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
 * File Name: Capability.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      03.08.2011 08:52 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Beethoven.Plugins.Security
{
    [DataContract]
    [Serializable]
    public class Capability
    {
        [DataMember]
        [Key]
        public Guid ID { get; set; }

        [DataMember]
        public string Name { get; set; }


        [DataMember]
        public string Description { get; set; }

        [ForeignKey("CapabilityID")]
        public virtual ICollection<RoleCapability> RoleCapabilities { get; set; }
    }
}
