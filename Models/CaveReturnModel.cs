using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF_LootCave.Models
{
    public class CaveReturnModel
    {
        public List<int> CaveList { get; set; }
        public List<int> MaxCavesByIndex { get; set; }
        public List<int> MaxCavesByInteger { get; set; }
        public int MaxCaveLoot { get; set; }
    }
}
