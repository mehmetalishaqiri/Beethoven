using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Beethoven.Plugins.ViewModels
{
    [DataContract]
    public class EntityListViewModel<T> : IBaseEntityListViewModel<T>
    {
        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public List<T> Items { get; set; }
    }
}
