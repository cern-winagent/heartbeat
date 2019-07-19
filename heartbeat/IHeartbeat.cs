using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

using plugin;

namespace heartbeat
{
    [PluginAttribute(PluginName = "HeartBeat")]
    public class IHeartbeat : IInputPlugin
    {
        public string Execute(JObject settings)
        {
            var heartBeatMessage = new Models.HeartBeatMessage
            {
                HostName = System.Environment.MachineName,
                OperativeSystem = System.Environment.OSVersion.VersionString,
                DateTime = DateTime.Now
            };
            
            return JsonConvert.SerializeObject(heartBeatMessage);
        }

    }
}