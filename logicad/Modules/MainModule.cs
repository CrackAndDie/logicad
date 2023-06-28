using logicad.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace logicad.Modules
{
    internal class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            // the view to display on start up
            region.RegisterViewWithRegion("MainRegion", typeof(MainPageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPageView>();
            containerRegistry.RegisterForNavigation<LogicPageView>();
        }
    }
}
