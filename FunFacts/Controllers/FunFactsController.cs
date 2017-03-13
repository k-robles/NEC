using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FunFacts.Models;
using FunFacts.BusinessLogic;

namespace FunFacts.Controllers
{
    public class FunFactsController : ApiController
    {
        private IFunFactsBL funFactsBL;

        public FunFactsController(IFunFactsBL funfacts)
        {
            funFactsBL = funfacts;
        }

        // GET: api/FunFacts/10
        [Route("api/FunFacts/{num}")]
        public IEnumerable<FunFact> GetFunFactsTopN(int num)
        {
            var result = funFactsBL.GetTopN(num).Select(f => new FunFact() { id = f.id, description = f.description });
            return result;
        }

        // GET: api/FunFacts/
        [Route("api/FunFact")]
        [ResponseType(typeof(FunFact))]
        public async Task<IHttpActionResult> GetFunFact()
        {

            var funFact = await funFactsBL.GetRandom();
            if (funFact == null)
            {
                return NotFound();
            }

            return Ok(funFact);
        }

        // PUT: api/FunFacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFunFact(int id, FunFact funFact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funFact.id)
            {
                return BadRequest();
            }

            try
            {
                await funFactsBL.Update(id, funFact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!funFactsBL.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FunFacts
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostFunFact(FunFact funFact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await funFactsBL.Add(funFact);

            return Ok();
        }

        // DELETE: api/FunFacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteFunFact(int id)
        {
            await funFactsBL.Delete(id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                funFactsBL.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}