using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMockApp
{
    class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double NewCheckingBalance { get; set; }

        [Required]
        public double NewSavingsBalance { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
