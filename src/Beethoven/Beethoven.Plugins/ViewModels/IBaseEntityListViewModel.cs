using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Beethoven.Plugins.ViewModels
{
   
    public interface IBaseEntityListViewModel<T>
    {
        int Total { get; set; }

        List<T> Items { get; set; }
    }
}
