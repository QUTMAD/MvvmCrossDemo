using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconsDemo.Core.Models
{
    public class EddyStone
    {
        public int CalibratedTxPower { get; set; }
        //public EddystoneEID Eid { get; set; }
        public string Instance { get; set; }
        public virtual bool IsEid { get; }
        public virtual bool IsUid { get; }
        public virtual bool IsUrl { get; }
        public string MacAddress { get; set; }
        public string Namespace { get; set; }
        public int Rssi { get; set; }
        public int TelemetryLastSeenMillis { get; set; }
        public string Url { get; set; }

    }
}
