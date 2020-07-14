using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CF_LootCave.Models
{
    public class CavePostModel
    {
        [Required]
        [RegularExpression(@"[-+]?(?:[0-9]+,)*[0-9]+(?:\.[0-9]+)?",ErrorMessage="Cave format is invalid. It must be in the format #,#,#,#")]
        public string CaveList { get; set; }
    }
}
