//using System.Threading.Tasks;
using PortfolioWebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using PortfolioWebAPI.DataAccess;
using System.Linq;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PortfolioWebAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        // GET: api/v1/transactions
        /// <summary>
        /// Gets all transactions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            using (var context = new PortfolioContext())
            {
                return context.Transactions.ToList();
            }            
        }

        // GET: api/v1/transactions/id
        /// <summary>
        /// Get a transaction by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var context = new PortfolioContext();
            var transaction = from t in context.Transactions
                              where t.TransactionId == id
                              select t;
            if(transaction == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(transaction);
            }            
        }

        // POST: api/v1/transactions
        /// <summary>
        /// Insert a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Insert(Transaction transaction)
        {
            try
            {
                using (var context = new PortfolioContext())
                {
                    context.Transactions.Add(transaction);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/v1/transactions/id
        /// <summary>
        /// Delete a transaction by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0) return BadRequest("Invalid id");
            using (var context = new PortfolioContext())
            {
                try
                {
                    var transaction = context.Transactions
                        .Where(t => t.TransactionId == id)
                        .FirstOrDefault();
                    if (transaction != null)
                    {
                        context.Entry(transaction).State = EntityState.Deleted;
                        context.SaveChanges();                        
                    }
                    return Ok();
                }
                catch(Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }

        // PUT: api/v1/transactions/id
        /// <summary>
        /// Update or Insert a transaction
        /// </summary>
        /// <param name="transaction"></param>
        [HttpPut]
        public IHttpActionResult Put(Transaction transaction)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }
            using (var context = new PortfolioContext())
            {
                try
                {
                    var result = context.Transactions.SingleOrDefault(t => t.TransactionId == transaction.TransactionId);
                    if (result != null)
                    {
                        result.CashValue = transaction.CashValue;
                        result.Commission = transaction.Commission;
                        result.Date = transaction.Date;
                        result.Name = transaction.Name;
                        result.Price = transaction.Price;
                        result.Shares = transaction.Shares;
                        result.Symbol = transaction.Symbol;
                        result.Type = transaction.Type;
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return this.Insert(transaction);
                    }
                }
                catch(Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            
        }
    }
}
