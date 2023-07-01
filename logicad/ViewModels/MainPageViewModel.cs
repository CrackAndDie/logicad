using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicad.ViewModels
{
    internal class MainPageViewModel : BindableBase
    {
        private NodeGraphViewModel nodeGraphViewModel = new NodeGraphViewModel();
        public NodeGraphViewModel NodeGraphViewModel
        {
            get { return nodeGraphViewModel; }
            private set { nodeGraphViewModel = value; }
        }
    }
}
