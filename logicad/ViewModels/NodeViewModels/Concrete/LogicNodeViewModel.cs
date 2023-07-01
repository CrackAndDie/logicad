using DryIoc;
using logicad.Interfaces.NodeInterfaces;
using NodeGraph.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace logicad.ViewModels.NodeViewModels.Concrete
{
    internal class LogicNodeViewModel : DefaultNodeViewModel
    {
        public string Name
        {
            get => _Name;
            set => RaisePropertyChangedIfSet(ref _Name, value);
        }
        string _Name = string.Empty;

        public string Body
        {
            get => _Body;
            set => RaisePropertyChangedIfSet(ref _Body, value);
        }
        string _Body = string.Empty;

        public override IEnumerable<INodeConnectorViewModel> Inputs => _Inputs;
        readonly ObservableCollection<NodeInputViewModel> _Inputs = new ObservableCollection<NodeInputViewModel>();

        public override IEnumerable<INodeConnectorViewModel> Outputs => _Outputs;
        readonly ObservableCollection<NodeOutputViewModel> _Outputs = new ObservableCollection<NodeOutputViewModel>();

        public LogicNodeViewModel()
        {
            Body = "LogicAnime";
            Name = "LogicNode";
            for (int i = 0; i < 4; ++i)
            {
                if (i % 2 == 0)
                {
                    var label = $"Input{i}";
                    if (i > 1)
                    {
                        label += " Allow to connect multiple";
                    }
                    _Inputs.Add(new NodeInputViewModel(label, i > 1));
                }
                else
                {
                    _Inputs.Add(new NodeInputViewModel($"Limited Input", false));
                }
            }

            for (int i = 0; i < 5; ++i)
            {
                _Outputs.Add(new NodeOutputViewModel($"Output{i}"));
            }
        }

        public override INodeConnectorViewModel FindConnector(Guid guid)
        {
            var input = Inputs.FirstOrDefault(arg => arg.Guid == guid);
            if (input != null)
            {
                return input;
            }

            var output = Outputs.FirstOrDefault(arg => arg.Guid == guid);
            return output;
        }
    }
}
