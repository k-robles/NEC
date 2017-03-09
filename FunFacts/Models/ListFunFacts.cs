using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace FunFacts.Models
{
    public class ListFunFacts : IFunFacts
    {
        private FunFactsContext db = new FunFactsContext();

        public IEnumerable<IFunFact> GetTopN(int num)
        {
            var result = db.FunFacts.Take(num);
            return result;
        }

        public async Task<IFunFact> GetRandom()
        {
            var rnd = new Random();
            IFunFact funFact = await(db.FunFacts.FindAsync(rnd.Next(1, db.FunFacts.Count())));
            return funFact;
        }

        public async Task<int> Update(int id, IFunFact ifunfact){
            db.Entry(ifunfact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {             
                    throw;
               
            }

            return -1;
        }

        public async Task Add(IFunFact funFact)
        {
            db.FunFacts.Add((FunFact)funFact);
            await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            IFunFact funFact = await db.FunFacts.FindAsync(id);
            if (funFact != null)
            {
                db.FunFacts.Remove((FunFact) funFact);
                await db.SaveChangesAsync();
            }

            return -1;
        }

        public bool Exists(int id)
        {
            return db.FunFacts.Count(e => e.id == id) > 0;
        }


        public  void Dispose()
        {
            
            db.Dispose();
            
            
        }
    }
}