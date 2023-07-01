using Livet;
using logicad.Interfaces.NodeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicad.ViewModels.NodeViewModels
{
    public class NodeOutputViewModel : ViewModel, INodeConnectorViewModel
    {
        public Guid Guid
        {
            get => _Guid;
            set => RaisePropertyChangedIfSet(ref _Guid, value);
        }
        Guid _Guid = Guid.NewGuid();

        public string Label
        {
            get => _Label;
            set => RaisePropertyChangedIfSet(ref _Label, value);
        }
        string _Label = string.Empty;

        public bool IsEnable
        {
            get => _IsEnable;
            set => RaisePropertyChangedIfSet(ref _IsEnable, value);
        }
        bool _IsEnable = true;

        public NodeOutputViewModel(string label)
        {
            Label = label;
        }
    }
}
