using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicad.Interfaces.NodeInterfaces
{
    public interface INodeConnectorViewModel
    {
        Guid Guid { get; set; }
        string Label { get; set; }
        bool IsEnable { get; set; }
    }
}
