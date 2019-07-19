using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heartbeat.Models
{
    class HeartBeatMessage
    {
        public string HostName { set; get; }
        public string OperativeSystem { set; get; }
        public DateTime DateTime { set; get; }
    }
}
