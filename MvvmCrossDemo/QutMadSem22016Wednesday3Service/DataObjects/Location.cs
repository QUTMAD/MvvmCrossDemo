using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QutMadSem22016Wednesday3Service.DataObjects
{
    public class Location : EntityData
    {
        public string LocalizedName { get; set; }
        public int Rank { get; set; }
        public string Key { get; set; }
    }
}