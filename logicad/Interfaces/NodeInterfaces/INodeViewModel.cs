using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace logicad.Interfaces.NodeInterfaces
{
    public interface INodeViewModel
    {
        Guid Guid { get; set; }
        Point Position { get; set; }
        bool IsSelected { get; set; }
    }
}
