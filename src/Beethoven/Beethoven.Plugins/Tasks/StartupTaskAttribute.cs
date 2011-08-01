using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Beethoven.Plugins.MetaData;

namespace Beethoven.Plugins.Tasks
{
    /// <summary>
    /// Marks the target class as an exportable startup task.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StartupTaskAttribute : ExportAttribute, IStartupTaskMetadata
    {

        public StartupTaskAttribute(string name, int order)
            : base(typeof(IStartupTaskMetadata))
        {
            Name = name;
            Order = order;
        }

        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        public string Name { get; private set; }


        public int Order { get; private set; }
    }
}
