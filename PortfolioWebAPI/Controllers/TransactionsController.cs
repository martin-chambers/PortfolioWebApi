using PortfolioWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortfolioWebAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        Transaction[] transactions = new Transaction[] { };

        /// <summary>
        /// Gets all transactions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return transactions;
        }

    }
}
