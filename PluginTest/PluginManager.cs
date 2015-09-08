using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using MyContract;

namespace PluginTest
{
    public class PluginManager
    {
        [ImportMany]
        private List<IMyContract> _plugins;

        public void Setup()
        {
            _plugins = new List<IMyContract>();

            var aggregate = new System.ComponentModel.Composition.Hosting.AggregateCatalog();

            aggregate.Catalogs.Add(new System.ComponentModel.Composition.Hosting.DirectoryCatalog(
                "C:\\Plugins\\", "*.dll"));
            //var directoryCatalog = new DirectoryCatalog(directoryPath, "*.dll");
            
            var parts = new System.ComponentModel.Composition.Hosting.CompositionBatch();
            parts.AddPart(this);

            var container = new System.ComponentModel.Composition.Hosting.CompositionContainer(aggregate);
            container.Compose(parts);
        }
    }
}
