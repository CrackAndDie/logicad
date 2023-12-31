﻿using Livet;
using logicad.Interfaces.NodeInterfaces;
using logicad.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace logicad.ViewModels.NodeViewModels
{
    public abstract class DefaultNodeViewModel : ViewModel, INodeViewModel
    {
        public double Width
        {
            get => _Width;
            set => RaisePropertyChangedIfSet(ref _Width, value);
        }
        double _Width = 0;

        public double Height
        {
            get => _Height;
            set => RaisePropertyChangedIfSet(ref _Height, value);
        }
        double _Height = 0;

        public Guid Guid
        {
            get => _Guid;
            set => RaisePropertyChangedIfSet(ref _Guid, value);
        }
        Guid _Guid = Guid.NewGuid();

        public Point Position
        {
            get => _Position;
            set => RaisePropertyChangedIfSet(ref _Position, value);
        }
        Point _Position = new Point(0, 0);

        public bool IsSelected
        {
            get => _IsSelected;
            set => RaisePropertyChangedIfSet(ref _IsSelected, value);
        }
        bool _IsSelected = false;

        public ICommand SizeChangedCommand => _SizeChangedCommand.Get(SizeChanged);
        ViewModelCommandHandler<Size> _SizeChangedCommand = new ViewModelCommandHandler<Size>();

        public abstract IEnumerable<INodeConnectorViewModel> Inputs { get; }
        public abstract IEnumerable<INodeConnectorViewModel> Outputs { get; }

        public abstract INodeConnectorViewModel FindConnector(Guid guid);

        void SizeChanged(Size newSize)
        {
            Width = newSize.Width;
            Height = newSize.Height;
        }
    }
}
