using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FunFacts.Models
{

    public class FunFact: IFunFact
    {        
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string description { get; set; }
    }
}