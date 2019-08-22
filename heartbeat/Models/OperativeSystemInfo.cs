using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heartbeat.Models
{
    class OperativeSystemInfo
    {
        public string HostName { set; get; }

        public string OperatingSystem { get; set; }

        public string Version { get; set; }

        public string BuildNumber { get; set; }

        public DateTime LastBootUpTime { get; set; }

        public DateTime DateTime { get; set; }
    }
}
