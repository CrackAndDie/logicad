using Livet;
using logicad.Interfaces.NodeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicad.ViewModels.NodeViewModels
{
    public class NodeInputViewModel : ViewModel, INodeConnectorViewModel
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

        public bool AllowToConnectMultiple
        {
            get => _AllowToConnectMultiple;
            set => RaisePropertyChangedIfSet(ref _AllowToConnectMultiple, value);
        }
        bool _AllowToConnectMultiple = false;

        public NodeInputViewModel(string label, bool allowToConnectMultiple)
        {
            Label = label;
            AllowToConnectMultiple = allowToConnectMultiple;
        }
    }
}
