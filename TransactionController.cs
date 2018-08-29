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
using Qualica.Models;
using Newtonsoft.Json;

namespace Qualica.Controllers
{
    public class TransactionController : ApiController
    {
        private QualicaContext db = new QualicaContext();

        // GET: api/Transactions
        public IHttpActionResult GetTransactions()
        {
            try
            {
                string TrxArrayJson = JsonConvert.SerializeObject(db.Transactions);
                return Ok(TrxArrayJson);
            }
            catch
            {
                return InternalServerError();
            }
        }

        // GET: api/Transactions/5
        public async Task<IHttpActionResult> GetTransaction(int id)
        {
            try
            {
                /* check input parameters */
                if (id < 0) return BadRequest("ID cannot be negative");

                /* search for record */
                Transaction transaction = await db.Transactions.FindAsync(id);
                if (transaction == null)
                {
                    return NotFound();
                }

                /* return record */
                string TrxJson = JsonConvert.SerializeObject(transaction);
                return Ok(TrxJson);
            }
            catch
            {
                return InternalServerError();
            }
        }

        // PUT: api/Transactions/5
        public async Task<IHttpActionResult> PutTransaction(int id, HttpRequestMessage request)
        {
            try
            {
                /* first deserialize the json string */
                var obj = request.Content.ReadAsStringAsync().Result;
                Transaction updatedTrx = JsonConvert.DeserializeObject<Transaction>(obj);

                if (id != updatedTrx.ID)
                {
                    return BadRequest();
                }

                /* now check parameters */
                if (updatedTrx.ID < 0) return BadRequest("ID cannot be negative");
                if (updatedTrx.Amount < 0) return BadRequest("Amount cannot be negative");

                /* add the record */
                db.Entry(updatedTrx).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(id))
                    {
                        return BadRequest("Transaction does not exist");
                    }
                    else
                    {
                        return InternalServerError();
                    }
                }
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

        // POST: api/Transactions
        public async Task<IHttpActionResult> PostTransaction(HttpRequestMessage request)
        {
            try
            {
                /* first deserialize the json string */
                var obj = request.Content.ReadAsStringAsync().Result;
                Transaction newTrx = JsonConvert.DeserializeObject<Transaction>(obj);

                /* now check parameters */
                if (newTrx.ID < 0) return BadRequest("ID cannot be negative");
                if (newTrx.Amount < 0) return BadRequest("Amount cannot be negative");

                /* add record */
                db.Transactions.Add(newTrx);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = newTrx.ID }, newTrx);
            }
            catch
            {
                return InternalServerError();
            }
        }

        // DELETE: api/Transactions/5
        public async Task<IHttpActionResult> DeleteTransaction(int id)
        {
            try
            {
                /* check input parameters */
                if (id < 0) return BadRequest("ID cannot be negative");

                /* find the record and delete it */
                Transaction transaction = await db.Transactions.FindAsync(id);
                if (transaction == null)
                {
                    return BadRequest("Invalid ID");
                }

                db.Transactions.Remove(transaction);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionExists(int id)
        {
            return db.Transactions.Count(e => e.ID == id) > 0;
        }
    }
}