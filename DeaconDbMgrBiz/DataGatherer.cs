using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeaconDbMgrData.DbTools;
using DeaconDbMgrData.MemberData;

namespace DeaconDbMgrBiz
{
    public class DataGatherer
    {
        public static List<Deacon> GetAllDeacons()
        {
            DataManager DM = new DataManager();
            return DM.GetAllDeacons();
        }
    }
}
