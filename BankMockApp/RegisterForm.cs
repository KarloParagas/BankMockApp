using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankMockApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (isDataValid() == true)
            {
                //Create a new Account object from user input
                Account customer = new Account()
                {
                    AccountNumber = GenerateAccountNumber(),
                    DebitCardNumber = DebitCardNumTxt.Text.Replace("-", ""),
                    FirstName = FirstNameTxt.Text,
                    LastName = LastNameTxt.Text,
                    Email = EmailTxt.Text,
                    Pin = pinTxt.Text,
                    PhoneNumber = PhoneNumberTxt.Text,
                    Address = AddressTxt.Text,
                    Checking = Convert.ToDouble(FirstDepositTxt.Text),
                    Savings = 0.00
                };

                //Add the Account object to the database
                try
                {
                    AccountDb.Add(customer);
                    MessageBox.Show("Account successfully created");
                    DialogResult = DialogResult.OK;
                }
                catch (SqlException)
                {
                    MessageBox.Show("We're currently having server issues");
                }
            }
        }

        private bool isDataValid()
        {
            if (isPresent() == true && isEmailValid() == true && isPhoneNumberValid() == true && isFirstDepositValid() == true
             && isDebitCardValid() == true && isPinNumberValid() == true)
            {
                return true;
            }
            return false;
        }

        private bool isPinNumberValid()
        {
            if (pinTxt.Text.Length == 4 && pinTxt.Text.All(char.IsDigit) == true)
            {
                return true;
            }
            MessageBox.Show("Pin must be 4 digits in length");
            return false;
        }

        private bool isDebitCardValid()
        {
            //If user inputs hyphens in their debit card, remove it
            string debitNumInput = DebitCardNumTxt.Text.Replace("-", "");

            long validLong;
            if (debitNumInput.Length == 16 && long.TryParse(debitNumInput, out validLong) && debitNumInput.All(char.IsDigit) == true)
            {
                return true;
            }
            MessageBox.Show("Debit card must be 16 digits in length without '-' or spaces");
            return false;
        }

        private bool isPhoneNumberValid()
        {
            long validLong;
            if (long.TryParse(PhoneNumberTxt.Text, out validLong) && PhoneNumberTxt.Text.All(char.IsDigit) == true && PhoneNumberTxt.Text.Length == 10)
            {
                return true;
            }
            MessageBox.Show("Phone number must consist of only numbers and 10 digits in length");
            return false;
        }

        private bool isEmailValid()
        {
            if (EmailTxt.Text.Contains("@") && EmailTxt.Text.Contains("."))
            {
                return true;
            }
            MessageBox.Show("Please make sure the email you provided has '@' and or '.'");
            return false;
        }

        private bool isFirstDepositValid()
        {
            double validDouble;
            if (double.TryParse(FirstDepositTxt.Text, out validDouble))
            {
                if (Convert.ToDouble(FirstDepositTxt.Text) >= 200)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("In order to have an account, the minimum first deposit is $200");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("First deposit must be a valid number");
                return false;
            }
        }

        private bool isPresent()
        {
            if (!string.IsNullOrWhiteSpace(FirstNameTxt.Text) && !string.IsNullOrWhiteSpace(LastNameTxt.Text)
             && !string.IsNullOrWhiteSpace(EmailTxt.Text) && !string.IsNullOrWhiteSpace(DebitCardNumTxt.Text)
             && !string.IsNullOrWhiteSpace(pinTxt.Text) && !string.IsNullOrWhiteSpace(PhoneNumberTxt.Text)
             && !string.IsNullOrWhiteSpace(AddressTxt.Text) && !string.IsNullOrWhiteSpace(FirstNameTxt.Text))
            {
                return true;
            }
            MessageBox.Show("Please fill out the empty fields");
            return false;
        }

        private int GenerateAccountNumber()
        {
            int minNum = 100000000;
            int maxNum = 2000000000;

            Random random = new Random();
            int number = random.Next(minNum, maxNum);
            return number;
        }
    }
}
