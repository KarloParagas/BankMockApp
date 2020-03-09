using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMockApp
{
    class Account
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        [Required, StringLength(16)]
        public string DebitCardNumber { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, StringLength(64)]
        public string Email { get; set; }

        [Required, StringLength(4)]
        public string Pin { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required, StringLength(50)]
        public string Address { get; set; }

        [Required]
        public double Checking { get; set; } = 0.00;

        [Required]
        public double Savings { get; set; } = 0.00;

        /// <summary>
        /// Gets the checking amount of the user from the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public double GetCheckingAmount()
        {
            return Checking;
        }

        /// <summary>
        /// Gets the savings amount of the user from the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public double GetSavingsAmount()
        {
            return Savings;
        }
    }
}
