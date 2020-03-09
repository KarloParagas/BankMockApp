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
    public partial class DepositForm : Form
    {
        public Account _user { get; set; }

        public DepositForm(Account u)
        {
            InitializeComponent();
            _user = u;
        }

        private void DepositForm_Load(object sender, EventArgs e)
        {
            //Disables the combobox for manual text input
            DepositToCBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //Add the two accounts to the combobox
            DepositToCBox.Items.Add("Checking");
            DepositToCBox.Items.Add("Savings");
        }

        private void ConfirmDepositBtn_Click(object sender, EventArgs e)
        {
            if (isDataValid() == true)
            {
                //Grab the amount to be deposited
                double amount = Convert.ToDouble(DepositAmountTxt.Text);

                if (DepositToCBox.SelectedItem.Equals("Checking")) //If user wants to deposit the funds to their checking account
                {
                    double total = _user.GetCheckingAmount() + amount;
                    try
                    {
                        //Update the user's checking account with the amount given
                        _user.Checking = total;
                        AccountDb.Update(_user);
                        MessageBox.Show("Deposit to your checking acount was successful");
                        GenerateReceipt(amount);
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Something went wrong when updating the checking account");
                    }
                }
                else if (DepositToCBox.SelectedItem.Equals("Savings")) //If user wants to deposit the funds to their savings account
                {
                    double total = _user.GetSavingsAmount() + amount;
                    try
                    {
                        //Update the user's savings account with the amount given
                        _user.Savings = total;
                        AccountDb.Update(_user);
                        MessageBox.Show("Deposit to your savings acount was successful");
                        GenerateReceipt(amount);
                        DialogResult = DialogResult.OK;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Something went wrong when updating the savings account");
                    }
                }
            }
        }

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
            if (isPresent() == true && IsValidNumber() == true)
            {
                return true;
            }

            return false;
        }

        private bool IsValidNumber()
        {
            double validDouble;
            if (double.TryParse(DepositAmountTxt.Text, out validDouble))
            {
                return true;
            }
            MessageBox.Show("Amount must be a valid number");
            return false;
        }

        private bool isPresent()
        {
            if (DepositToCBox.Text != "" && DepositAmountTxt.Text != "")
            {
                return true;
            }
            MessageBox.Show("Please fill out the required fields");
            return false;
        }
    }
}
