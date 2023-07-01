using Livet;
using Livet.Commands;
using logicad.Utilities;
using logicad.ViewModels.NodeViewModels;
using logicad.ViewModels.NodeViewModels.Concrete;
using NodeGraph.Controls;
using NodeGraph.Operation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicad.ViewModels
{
    internal class NodeGraphViewModel : ViewModel
    {
        public double Scale
        {
            get => _Scale;
            set => RaisePropertyChangedIfSet(ref _Scale, value);
        }
        double _Scale = 1.0f;

        public ViewModelCommand AddNodeCommand => _AddNodeCommand.Get(() => { AddNode(new LogicNodeViewModel()); });
        ViewModelCommandHandler _AddNodeCommand = new ViewModelCommandHandler();

        public ViewModelCommand AddGroupNodeCommand => _AddGroupNodeCommand.Get(AddGroupNode);
        ViewModelCommandHandler _AddGroupNodeCommand = new ViewModelCommandHandler();

        public ViewModelCommand RemoveNodesCommand => _RemoveNodesCommand.Get(RemoveNodes);
        ViewModelCommandHandler _RemoveNodesCommand = new ViewModelCommandHandler();

        public ListenerCommand<PreviewConnectLinkOperationEventArgs> PreviewConnectLinkCommand => _PreviewConnectLinkCommand.Get(PreviewConnect);
        ViewModelCommandHandler<PreviewConnectLinkOperationEventArgs> _PreviewConnectLinkCommand = new ViewModelCommandHandler<PreviewConnectLinkOperationEventArgs>();

        public ListenerCommand<ConnectedLinkOperationEventArgs> ConnectedLinkCommand => _ConnectedLinkCommand.Get(Connected);
        ViewModelCommandHandler<ConnectedLinkOperationEventArgs> _ConnectedLinkCommand = new ViewModelCommandHandler<ConnectedLinkOperationEventArgs>();

        public ListenerCommand<DisconnectedLinkOperationEventArgs> DisconnectedLinkCommand => _DisconnectedLinkCommand.Get(Disconnected);
        ViewModelCommandHandler<DisconnectedLinkOperationEventArgs> _DisconnectedLinkCommand = new ViewModelCommandHandler<DisconnectedLinkOperationEventArgs>();

        public ListenerCommand<IList> SelectionChangedCommand => _SelectionChangedCommand.Get(SelectionChanged);
        ViewModelCommandHandler<IList> _SelectionChangedCommand = new ViewModelCommandHandler<IList>();

        public ViewModelCommand ClearNodesCommand => _ClearNodesCommand.Get(ClearNodes);
        ViewModelCommandHandler _ClearNodesCommand = new ViewModelCommandHandler();

        public ViewModelCommand ClearNodeLinksCommand => _ClearNodeLinksCommand.Get(ClearNodeLinks);
        ViewModelCommandHandler _ClearNodeLinksCommand = new ViewModelCommandHandler();

        public ViewModelCommand ResetScaleCommand => _ResetScaleCommand.Get(ResetScale);
        ViewModelCommandHandler _ResetScaleCommand = new ViewModelCommandHandler();

        public IEnumerable<DefaultNodeViewModel> NodeViewModels => _NodeViewModels;
        ObservableCollection<DefaultNodeViewModel> _NodeViewModels = new ObservableCollection<DefaultNodeViewModel>();

        public IEnumerable<NodeLinkViewModel> NodeLinkViewModels => _NodeLinkViewModels;
        ObservableCollection<NodeLinkViewModel> _NodeLinkViewModels = new ObservableCollection<NodeLinkViewModel>();

        public IEnumerable<GroupNodeViewModel> GroupNodeViewModels => _GroupNodeViewModels;
        ObservableCollection<GroupNodeViewModel> _GroupNodeViewModels = new ObservableCollection<GroupNodeViewModel>();

        public bool IsLockedAllNodeLinks
        {
            get => _IsLockedAllNodeLinks;
            set => UpdateIsLockedAllNodeLinksProperty(value);
        }
        bool _IsLockedAllNodeLinks = false;

        public bool IsEnableAllNodeConnectors
        {
            get => _IsEnableAllNodeConnectors;
            set => UpdateIsEnableAllNodeConnectorsProperty(value);
        }
        bool _IsEnableAllNodeConnectors = true;

        internal NodeGraphViewModel()
        {
            
        }

        internal void AddNode(DefaultNodeViewModel node)
        {
            _NodeViewModels.Add(node);
        }

        internal void AddGroupNode()
        {
            _GroupNodeViewModels.Add(new GroupNodeViewModel() { Name = "NewGroupNode" });
        }

        internal void RemoveNodes()
        {
            var removeNodes = _NodeViewModels.Where(arg => arg.IsSelected).ToArray();
            foreach (var removeNode in removeNodes)
            {
                _NodeViewModels.Remove(removeNode);

                var removeNodeLink = NodeLinkViewModels.FirstOrDefault(arg => arg.InputConnectorNodeGuid == removeNode.Guid || arg.OutputConnectorNodeGuid == removeNode.Guid);
                _NodeLinkViewModels.Remove(removeNodeLink);
            }
        }

        internal void ClearNodes()
        {
            _NodeLinkViewModels.Clear();
            _NodeViewModels.Clear();
        }

        internal void ClearNodeLinks()
        {
            _NodeLinkViewModels.Clear();
        }

        internal void ResetScale()
        {
            Scale = 1.0f;
        }

        void UpdateIsLockedAllNodeLinksProperty(bool value)
        {
            _IsLockedAllNodeLinks = !_IsLockedAllNodeLinks;

            foreach (var nodeLink in _NodeLinkViewModels)
            {
                nodeLink.IsLocked = _IsLockedAllNodeLinks;
            }

            RaisePropertyChanged(nameof(IsLockedAllNodeLinks));
        }

        void UpdateIsEnableAllNodeConnectorsProperty(bool value)
        {
            _IsEnableAllNodeConnectors = !_IsEnableAllNodeConnectors;

            foreach (var node in _NodeViewModels)
            {
                foreach (var input in node.Inputs)
                {
                    input.IsEnable = _IsEnableAllNodeConnectors;
                }
                foreach (var output in node.Outputs)
                {
                    output.IsEnable = _IsEnableAllNodeConnectors;
                }
            }

            RaisePropertyChanged(nameof(IsEnableAllNodeConnectors));
        }

        void PreviewConnect(PreviewConnectLinkOperationEventArgs args)
        {
            var inputNode = NodeViewModels.First(arg => arg.Guid == args.ConnectToEndNodeGuid);
            var inputConnector = inputNode.FindConnector(args.ConnectToEndConnectorGuid);
            args.CanConnect = inputConnector.Label == "Limited Input" == false;
        }

        void Connected(ConnectedLinkOperationEventArgs param)
        {
            var nodeLink = new NodeLinkViewModel()
            {
                OutputConnectorGuid = param.OutputConnectorGuid,
                OutputConnectorNodeGuid = param.OutputConnectorNodeGuid,
                InputConnectorGuid = param.InputConnectorGuid,
                InputConnectorNodeGuid = param.InputConnectorNodeGuid,
                IsLocked = IsLockedAllNodeLinks,
            };
            _NodeLinkViewModels.Add(nodeLink);
        }

        void Disconnected(DisconnectedLinkOperationEventArgs param)
        {
            var nodeLink = _NodeLinkViewModels.First(arg => arg.Guid == param.NodeLinkGuid);
            _NodeLinkViewModels.Remove(nodeLink);
        }

        void SelectionChanged(IList list)
        {

        }
    }
}
