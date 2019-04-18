using System;

namespace plugin
{
    [PluginAttribute(PluginName = "HeartBeat")]
    public class IUpdates : IInputPlugin
    {
        public string Execute()
        {
            return "{ 1 }";
        }

    }
}