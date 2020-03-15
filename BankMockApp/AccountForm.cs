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
    public partial class AccountForm : Form
    {
        private readonly Account _user;

        public AccountForm(Account u)
        {
            InitializeComponent();
            _user = u;
        }

        /// <summary>
        /// Displays the correct information from the database based on which user is logged in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountForm_Load(object sender, EventArgs e)
        {
            AccountHolderInfoLbl.Text = $"{_user.FirstName} {_user.LastName}";
            AccountNumLbl.Text = $"XXXXX{_user.AccountNumber.ToString().Substring(_user.AccountNumber.ToString().Length - 4)}";
            TotalBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking + _user.Savings)}";
            CheckingBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking)}";
            SavingsBalanceLbl.Text = $"${String.Format("{0:n}", _user.Savings)}";
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            string message = $"Are you sure you want to log out?";
            DialogResult result = MessageBox.Show(text: message,
                                                  caption: "Logout?",
                                                  buttons: MessageBoxButtons.YesNo,
                                                  icon: MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Displays the DepositForm when the deposit button is clicked,
        /// then updates the AccountForm display if there are any changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositBtn_Click(object sender, EventArgs e)
        {
            DepositForm form = new DepositForm(_user);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateBalanceDisplay();
            }
        }

        /// <summary>
        /// Displays the TransferForm when the deposit button is clicked,
        /// then updates the AccountForm display if there are any changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferBtn_Click(object sender, EventArgs e)
        {
            TransferForm form = new TransferForm(_user);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateBalanceDisplay();
            }
        }

        /// <summary>
        /// Displays the WithDrawForm when the deposit button is clicked,
        /// then updates the AccountForm display if there are any changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            WithdrawForm form = new WithdrawForm(_user);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateBalanceDisplay();
            }
        }

        /// <summary>
        /// Deletes the user's account if delete account button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAccountBtn_Click(object sender, EventArgs e)
        {
            string message = $"Are you sure you want to delete this account? WARNING: This cannot be undone!";
            DialogResult result = MessageBox.Show(text: message,
                                                  caption: "Delete Account?",
                                                  buttons: MessageBoxButtons.YesNo,
                                                  icon: MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    AccountDb.Delete(_user);
                    MessageBox.Show("Account successfully deleted");
                    Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Something went wrong while trying to delete this account. Please try again later.");
                }
            }
        }

        /// <summary>
        /// Updates the balance display for any changes.
        /// </summary>
        private void UpdateBalanceDisplay()
        {
            //Display the newly updated amounts
            TotalBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking + _user.Savings)}";
            CheckingBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking)}";
            SavingsBalanceLbl.Text = $"${String.Format("{0:n}", _user.Savings)}";
        }
    }
}
