using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMockApp
{
    public static class ReceiptDb
    {
        /// <summary>
        /// Adds an transaction to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Receipt Add(Receipt transaction)
        {
            using (var context = new BankContext())
            {
                context.Receipts.Add(transaction);
                context.SaveChanges();
                return transaction;
            }
        }
    }
}
