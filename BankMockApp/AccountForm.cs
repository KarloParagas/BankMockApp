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
        public Account _user { get; set; }

        public AccountForm(Account u)
        {
            InitializeComponent();
            _user = u;
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            AccountHolderInfoLbl.Text = $"{_user.FirstName} {_user.LastName}";
            AccountNumLbl.Text = $"XXXXX{_user.AccountNumber.ToString().Substring(_user.AccountNumber.ToString().Length - 4)}";
            TotalBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking + _user.Savings)}";
            CheckingBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking)}";
            SavingsBalanceLbl.Text = $"${String.Format("{0:n}", _user.Savings)}";
        }

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

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            DepositForm form = new DepositForm(_user);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateBalanceDisplay();
            }
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            TransferForm form = new TransferForm(_user);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateBalanceDisplay();
            }
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            WithdrawForm form = new WithdrawForm(_user);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                UpdateBalanceDisplay();
            }
        }

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

        private void UpdateBalanceDisplay()
        {
            //Display the newly updated amounts
            TotalBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking + _user.Savings)}";
            CheckingBalanceLbl.Text = $"${String.Format("{0:n}", _user.Checking)}";
            SavingsBalanceLbl.Text = $"${String.Format("{0:n}", _user.Savings)}";
        }
    }
}
