using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankMockApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            BankContext account = new BankContext();
            if (isPresent() == true)
            {
                //If user tried to log in with hyphens on their input, remove it
                string userDebitNumInput = debitNum.Text.Replace("-", "");

                //Check if a user with that debit card number exists
                Account userExist = account.Accounts.FirstOrDefault(a => a.DebitCardNumber == userDebitNumInput);

                //If a user with that debit card number DOES exist 
                if (doesUserExist(userExist) == true)
                {
                    //If that user with the same debit card also matches the password on file 
                    if (doesUserPinMatch(userExist, pinNum.Text) == true)
                    {
                        debitNum.Text = "";
                        pinNum.Text = "";

                        //Display a welcome message with their name
                        MessageBox.Show($"Welcome {userExist.FirstName} {userExist.LastName}");

                        //Display their account information
                        AccountForm form = new AccountForm(userExist);
                        form.ShowDialog();
                    }
                }
            }
        }

        private bool doesUserPinMatch(Account userExist, string text)
        {
            if (pinNum.Text.Length > 4) 
            {
                MessageBox.Show("Pin must be 4 digits");
                return false;
            }
            if (userExist.Pin == pinNum.Text) 
            {
                return true;
            }
            MessageBox.Show("Pin doesn't match");
            return false;
        }

        private bool doesUserExist(Account userExist)
        {
            if (userExist != null) 
            {
                return true;
            }
            MessageBox.Show("Account doesn't exist");
            return false;
        }

        private bool isPresent()
        {
            if (debitNum.Text != string.Empty && pinNum.Text != string.Empty) 
            {
                return true;
            }
            MessageBox.Show("Please fill out the required fields");
            return false;
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            debitNum.Text = "";
            pinNum.Text = "";
            MessageBox.Show("Please enter your information on the next page to register");
            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog();
        }
    }
}
