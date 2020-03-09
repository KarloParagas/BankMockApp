using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMockApp
{
    public static class AccountDb
    {
        /// <summary>
        /// Adds an account to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Account Add(Account customer)
        {
            using (var context = new BankContext())
            {
                context.Accounts.Add(customer);
                context.SaveChanges();
                return customer;
            }
        }

        /// <summary>
        /// Updates an existing Account selected by the user from the database
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Account Update(Account info)
        {
            using (var context = new BankContext())
            {
                context.Accounts.Attach(info);
                context.Entry(info).State = EntityState.Modified;
                context.SaveChanges();
                return info;
            }
        }

        /// <summary>
        /// Deletes the selected Account from the database
        /// </summary>
        /// <param name="customer"></param>
        public static void Delete(Account customer)
        {
            using (var context = new BankContext())
            {
                context.Accounts.Add(customer);
                context.Entry(customer).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
