using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterAuto.Orange
{
    public class OrangeModule : IModule
    {
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        [Dependency]
        public IUnityContainer Container { get; set; }
        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion("MainRegion",typeof(OrangeView));
        }
    }
}
