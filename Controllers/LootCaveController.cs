using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF_LootCave.Data;
using CF_LootCave.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CF_LootCave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LootCaveController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetBestLoot([FromBody] CavePostModel caveData)
        {
            CaveReturnModel newCave = new CaveReturnModel();

            newCave.CaveList = caveData.CaveList.Split(",").Select(int.Parse).ToList();

            newCave = MaxSumNonAdjacentNumbers.GetCaveData(newCave);

            return Ok(newCave);
        }

        [HttpGet]
        public IActionResult GetLoot()
        {
            CaveReturnModel newCave = new CaveReturnModel();

            newCave.CaveList = new List<int> {8,2,1,9,1,1,9};

            newCave = MaxSumNonAdjacentNumbers.GetCaveData(newCave);

            return Ok(newCave);
        }
    }
}
