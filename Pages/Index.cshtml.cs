using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CF_LootCave.Data;
using CF_LootCave.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CF_LootCave.Pages
{
    public class IndexModel : PageModel
    {
        public CaveReturnModel caveData{get; set;}
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        [Required]
        [RegularExpression(@"[-+]?(?:[0-9]+,)*[0-9]+(?:\.[0-9]+)?",ErrorMessage="Cave format is invalid. It must be in the format #,#,#,#")]
        public string CaveListFromForm {get; set;}

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            CaveReturnModel newCave = new CaveReturnModel();

            newCave.CaveList = new List<int> {8,2,1,9,1,1,9};


            caveData = MaxSumNonAdjacentNumbers.GetCaveData(newCave);

            for (int i = 0 ; i < newCave.MaxCavesByIndex.Count(); i ++)
            {
                newCave.MaxCavesByIndex[i] = newCave.MaxCavesByIndex[i] + 1;
            }
        }

        public void OnPost()
        {
            CaveReturnModel newCave = new CaveReturnModel();

            if (ModelState.IsValid){

                List<int> caves = CaveListFromForm.Split(",").Select(Int32.Parse).ToList();

                newCave.CaveList = caves;

                caveData = MaxSumNonAdjacentNumbers.GetCaveData(newCave);

            }
            else
            {
                newCave.CaveList = new List<int> {8,2,1,9,1,1,9};
                caveData = MaxSumNonAdjacentNumbers.GetCaveData(newCave);
            }

            for (int i = 0 ; i < newCave.MaxCavesByIndex.Count(); i ++)
            {
                newCave.MaxCavesByIndex[i] = newCave.MaxCavesByIndex[i] + 1;
            }
        }
    }
}
