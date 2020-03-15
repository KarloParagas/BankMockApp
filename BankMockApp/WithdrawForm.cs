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
    public partial class WithdrawForm : Form
    {
        public Account _user { get; set; }

        public WithdrawForm(Account u)
        {
            InitializeComponent();
            _user = u;
        }

        /// <summary>
        /// Populates the combobox drop down list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WithdrawForm_Load(object sender, EventArgs e)
        {
            //Disables the combobox for text input
            WithdrawFromCBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //Add checkings and savings to the dropdown
            WithdrawFromCBox.Items.Add("Checking");
            WithdrawFromCBox.Items.Add("Savings");
        }

        /// <summary>
        /// Withdraws the desired amount to the user's checking
        /// or savings account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmWithdrawalBtn_Click(object sender, EventArgs e)
        {
            if (isDataValid() == true)
            {
                double amount = Convert.ToDouble(WithdrawAmountTxt.Text);

                //If user chooses to withdraw from their checking
                if (WithdrawFromCBox.SelectedItem.Equals("Checking"))
                {
                    double checking = _user.GetCheckingAmount() - amount;
                    try
                    {
                        _user.Checking = checking;
                        AccountDb.Update(_user);
                        MessageBox.Show("Withdrawal was successful, please remember to take your money.");
                        GenerateReceipt(amount);
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Something went wrong with the withdrawal from your checking account");
                    }
                }
                //If user chooses to withdraw from their savings
                else if (WithdrawFromCBox.SelectedItem.Equals("Savings"))
                {
                    double savings = _user.GetSavingsAmount() - amount;
                    try
                    {
                        _user.Savings = savings;
                        AccountDb.Update(_user);
                        MessageBox.Show("Withdrawal was successful, please remember to take your money.");
                        GenerateReceipt(amount);
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Something went wrong with the withdrawal from your savings account");
                    }
                }
            }
        }

        /// <summary>
        /// Generates a reciept of the transaction.
        /// </summary>
        /// <param name="amount"></param>
        private void GenerateReceipt(double amount)
        {
            //Create a receipt of the transaction
            Receipt transaction = new Receipt()
            {
                AccountNumber = _user.AccountNumber,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Amount = amount,
                NewCheckingBalance = _user.Checking,
                NewSavingsBalance = _user.Savings,
                TransactionDate = DateTime.Now
            };
            ReceiptDb.Add(transaction);
        }

        private bool isDataValid()
        {
            if (isPresent() == true && IsValidNumber() == true && doesWithdrawAmountExceedBalance() == false)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the user exceeds their balance for the withdraw amount.
        /// Returns false if the amount exceeds their balance.
        /// </summary>
        /// <returns></returns>
        private bool doesWithdrawAmountExceedBalance()
        {
            double withDrawAmount = Convert.ToDouble(WithdrawAmountTxt.Text);
            if (WithdrawFromCBox.SelectedItem.Equals("Checking"))
            {
                if (_user.GetCheckingAmount() - withDrawAmount < 0)
                {
                    MessageBox.Show("The amount you're trying to withdraw exceeds your checking balance");
                    return true;
                }
            }
            else if (WithdrawFromCBox.SelectedItem.Equals("Savings"))
            {
                if (_user.GetSavingsAmount() - withDrawAmount < 0)
                {
                    MessageBox.Show("The amount you're trying to withdraw exceeds your savings balance");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the user provided a valid amount.
        /// Returns false if user doesn't provides an invalid amount.
        /// </summary>
        /// <returns></returns>
        private bool IsValidNumber()
        {
            double validDouble;
            if (double.TryParse(WithdrawAmountTxt.Text, out validDouble))
            {
                return true;
            }
            MessageBox.Show("Amount must be a valid number");
            return false;
        }

        /// <summary>
        /// Checks to see if the user has filled out all of the required fields.
        /// Returns false if user submits an empty form.
        /// </summary>
        /// <returns></returns>
        private bool isPresent()
        {
            if (WithdrawFromCBox.Text != "" && WithdrawAmountTxt.Text != "")
            {
                return true;
            }
            MessageBox.Show("Please fill out the required fields");
            return false;
        }
    }
}
