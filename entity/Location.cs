using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_AlexanderK.entity
{
    public class Location
    {
        public string LocationID { get; set; }
        public string LocationType { get; set; }
        public string DefaultDeliveryDay { get; set; }

        public Location() { }

        public Location(string locationID, string locationType, string defaultDeliveryDay)
        {
            LocationID = locationID;
            LocationType = locationType;
            DefaultDeliveryDay = defaultDeliveryDay;
        }
    }
}
