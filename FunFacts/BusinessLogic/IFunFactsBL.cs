using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunFacts.Models;

namespace FunFacts.BusinessLogic
{
    public interface IFunFactsBL : IDisposable
    {
        
        IEnumerable<FunFact> GetTopN(int num);
         Task<FunFact> GetRandom();
         Task<int> Update(int id, FunFact funFact);
         Task Add(FunFact funFact);
         Task<int> Delete(int id);
         bool Exists(int id);
    }
}
