using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using FunFacts.Models;

namespace FunFacts.BusinessLogic
{
    ///<summary>
    ///concrete implementation of repository pattern <see cref="FunFactBL"/>
    ///</summary>
    
    public class ChuckNorrisFunFactsBL : FunFactsBL <FunFact>
    {
        
        public ChuckNorrisFunFactsBL()
        {
            this.db = new FunFactsContext<FunFact>("name=ChuckNorrisFF");           
        }

    }
}