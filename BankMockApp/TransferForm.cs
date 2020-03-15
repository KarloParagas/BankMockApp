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
    public partial class TransferForm : Form
    {
        public Account _user { get; set; }

        public TransferForm(Account u)
        {
            InitializeComponent();
            _user = u;
        }

        /// <summary>
        /// Populates the combobox drop down list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferForm_Load(object sender, EventArgs e)
        {
            //Disables the combobox for manual text input
            TransferFromCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TransferToTxt.Enabled = false;

            //Add the two accounts to the combobox
            TransferFromCBox.Items.Add("Checking");
            TransferFromCBox.Items.Add("Savings");
        }

        /// <summary>
        /// Automatically populates the transfer to's textbox based
        /// on what the user has selected in transfer from's combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferFromCBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (TransferFromCBox.SelectedItem.Equals("Checking"))
            {
                TransferToTxt.Text = "Savings";
            }
            else if (TransferFromCBox.SelectedItem.Equals("Savings"))
            {
                TransferToTxt.Text = "Checking";
            }
        }

        /// <summary>
        /// Transfers the desired amount to the user's checking
        /// or savings account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmTransferBtn_Click(object sender, EventArgs e)
        {
            if (isDataValid() == true)
            {
                double amount = Convert.ToDouble(TransferAmountTxt.Text);

                //If user selected to transfer from checking to savings
                if (TransferFromCBox.SelectedItem.Equals("Checking") && TransferToTxt.Text.Equals("Savings"))
                {
                    double savings = _user.GetSavingsAmount() + amount;
                    double checking = _user.GetCheckingAmount() - amount;
                    try
                    {
                        _user.Savings = savings;
                        _user.Checking = checking;
                        AccountDb.Update(_user);
                        MessageBox.Show("Transfer from checking to savings was successful");
                        GenerateReceipt(amount);
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Something went wrong with the transfer from checking to savings");
                    }
                }
                //If user selected to transfer from savings to checking
                else if (TransferFromCBox.SelectedItem.Equals("Savings") && TransferToTxt.Text.Equals("Checking"))
                {
                    double checking = _user.GetCheckingAmount() + amount;
                    double savings = _user.GetSavingsAmount() - amount;
                    try
                    {
                        _user.Checking = checking;
                        _user.Savings = savings;
                        AccountDb.Update(_user);
                        MessageBox.Show("Transfer from savings to checking was successful");
                        GenerateReceipt(amount);
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Something went wrong with the transfer from checking to savings");
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
            if (isPresent() == true && IsValidNumber() == true && doesTransferAmountExceedBalance() == false)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the user exceeds their balance for the transfer amount.
        /// Returns false if the amount exceeds their balance.
        /// </summary>
        /// <returns></returns>
        private bool doesTransferAmountExceedBalance()
        {
            double transferAmount = Convert.ToDouble(TransferAmountTxt.Text);
            if (TransferFromCBox.SelectedItem.Equals("Checking") && TransferToTxt.Text.Equals("Savings"))
            {
                if (_user.GetCheckingAmount() - transferAmount < 0)
                {
                    MessageBox.Show("The amount you're trying to transfer exceeds your checking balance");
                    return true;
                }
            }
            else if (TransferFromCBox.SelectedItem.Equals("Savings") && TransferToTxt.Text.Equals("Checking"))
            {
                if (_user.GetSavingsAmount() - transferAmount < 0)
                {
                    MessageBox.Show("The amount you're trying to transfer exceeds your savings balance");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the user provided a valid transfer amount.
        /// Returns false if user doesn't provides an invalid amount.
        /// </summary>
        /// <returns></returns>
        private bool IsValidNumber()
        {
            double validDouble;
            if (double.TryParse(TransferAmountTxt.Text, out validDouble))
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
            if (TransferFromCBox.Text != "" && TransferToTxt.Text != "" && TransferAmountTxt.Text != "")
            {
                return true;
            }
            MessageBox.Show("Please fill out the required fields");
            return false;
        }
    }
}
