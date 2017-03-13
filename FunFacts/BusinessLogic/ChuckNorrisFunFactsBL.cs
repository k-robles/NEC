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
    public class ChuckNorrisFunFactsBL : IFunFactsBL
    {
        private FunFactsContext db;

        public ChuckNorrisFunFactsBL()
        {
            db = new FunFactsContext("name=ChuckNorrisFF");
        }

        public ChuckNorrisFunFactsBL(FunFactsContext dbContext)
        {
            db = dbContext;
        }

        public IEnumerable<FunFact> GetTopN(int num)
        {
            var result = db.FunFacts.Take(num);
            return result;
        }

        public async Task<FunFact> GetRandom()
        {
            var rnd = new Random();
            var funFact = await(db.FunFacts.FindAsync(rnd.Next(1, db.FunFacts.Count())));
            return funFact;
        }

        public async Task<int> Update(int id, FunFact funfact){
            db.Entry(funfact).State = EntityState.Modified;

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

        public async Task Add(FunFact funFact)
        {
            db.FunFacts.Add(funFact);
            await db.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var funFact = await db.FunFacts.FindAsync(id);
            if (funFact != null)
            {
                db.FunFacts.Remove(funFact);
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