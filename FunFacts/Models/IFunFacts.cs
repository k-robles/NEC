using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFacts.Models
{
    public interface IFunFacts : IDisposable
    {
        
        IEnumerable<IFunFact> GetTopN(int num);
         Task<IFunFact> GetRandom();
         Task<int> Update(int id, IFunFact ifunfact);
         Task Add(IFunFact funFact);
         Task<int> Delete(int id);
         bool Exists(int id);
    }
}
