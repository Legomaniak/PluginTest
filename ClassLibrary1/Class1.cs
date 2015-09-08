using System;
using System.Composition;
using MyContract;

namespace ClassLibrary1
{
    [Export(typeof(IMyContract))]
    public class MyPlugin : IMyContract
    {
        public string Name { get; set; }
    }
}
