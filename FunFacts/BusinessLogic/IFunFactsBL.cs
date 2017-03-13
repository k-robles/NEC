using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunFacts.Models;

namespace FunFacts.BusinessLogic
{

    ///<summary>
    ///A lightweight implementation of repository pattern
    ///</summary>
    
    public interface IFunFactsBL<T> : IDisposable
    {
        
        IEnumerable<T> GetTopN(int num);
         Task<T> GetRandom();
         Task<int> Update(int id, T funFact);
         Task Add(T funFact);
         Task<int> Delete(int id);
         bool Exists(int id);
    }
}
