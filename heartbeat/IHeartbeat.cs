using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Management;
using System.Linq;

using plugin;
using heartbeat.Models;

namespace heartbeat
{
    [PluginAttribute(PluginName = "HeartBeat")]
    public class IHeartbeat : IInputPlugin
    {
        public event EventHandler<MessageEventArgs> MessageEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <returns>void</returns>
        public string Execute(JObject settings)
        {
            var OSInfo = GetOperativeSystem();

            return JsonConvert.SerializeObject(OSInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.Management.ManagementException: Not found">Thrown when one of the fields could not be found in the result of the query</exception>
        /// <exception cref="System.Management.ManagementException: Invalid class">Thrown when the class specified in the query is invalid</exception>
        /// <exception cref="System.Management.ManagementException: Invalid query">Thrown when there is an error in the syntax of the query, including an invalid field</exception>
        /// <returns>OperatingSystem</returns>
        private Models.OperativeSystemInfo GetOperativeSystem()
        {
            try
            {
                //Query system for Operating System information
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CSName, BuildNumber, Caption, Version, LastBootUpTime, LocalDateTime FROM Win32_OperatingSystem");
                ManagementObject OS = searcher.Get().OfType<ManagementObject>().FirstOrDefault();

                var operativeSystem = new Models.OperativeSystemInfo()
                {
                    HostName = OS["CSName"].ToString(),
                    BuildNumber = OS["BuildNumber"].ToString(),
                    OperatingSystem = OS["Caption"].ToString(),
                    Version = OS["Version"].ToString(),
                    LastBootUpTime = ManagementDateTimeConverter.ToDateTime(OS["LastBootUpTime"].ToString()).ToUniversalTime(),
                    DateTime = ManagementDateTimeConverter.ToDateTime(OS["LocalDateTime"].ToString()).ToUniversalTime()
                };

                return operativeSystem;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}