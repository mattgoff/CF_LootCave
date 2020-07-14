using CF_LootCave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF_LootCave.Data
{
    public class MaxSumNonAdjacentNumbers
    {

        public static CaveReturnModel GetCaveData(CaveReturnModel cave)
        {
            int priorMaxSum = 0;
            List<int> priorMaxSumList = new List<int>();

            // initial max sum
            int maxSum = cave.CaveList[0];
            List<int> maxSumList = new List<int>();
            maxSumList.Add(0);

            for (int i = 1; i < cave.CaveList.Count; i++)
            {
                int currSum;
                List<int> currSumList;
                currSum = priorMaxSum + cave.CaveList[i];
                currSumList = new List<int>(priorMaxSumList);
                currSumList.Add(i);

                // update prior max sum and list
                priorMaxSum = maxSum;
                priorMaxSumList = new List<int>(maxSumList);

                if (currSum > maxSum)
                {
                    // update max sum
                    maxSum = currSum;
                    maxSumList = currSumList;
                }
            }
            cave.MaxCaveLoot = maxSum;
            cave.MaxCavesByIndex = maxSumList;
            cave.MaxCavesByInteger = (from x in cave.MaxCavesByIndex select cave.CaveList[x]).ToList();
            return cave;
        }

    }
}
