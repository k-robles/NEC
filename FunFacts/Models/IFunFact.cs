using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFacts.Models
{
   
    public interface IFunFact
    {
        int id { get; set; }
       
        string description { get; set; }
    }

}
