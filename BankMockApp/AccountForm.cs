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
    public partial class AccountForm : Form
    {
        public Account _user { get; set; }

        public AccountForm(Account u)
        {
            InitializeComponent();
            _user = u;
        }
    }
}
