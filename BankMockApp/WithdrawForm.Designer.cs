namespace BankMockApp
{
    partial class WithdrawForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfirmWithdrawalBtn = new System.Windows.Forms.Button();
            this.WithdrawAmountTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WithdrawFromCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ConfirmWithdrawalBtn
            // 
            this.ConfirmWithdrawalBtn.Location = new System.Drawing.Point(94, 76);
            this.ConfirmWithdrawalBtn.Margin = new System.Windows.Forms.Padding(1);
            this.ConfirmWithdrawalBtn.Name = "ConfirmWithdrawalBtn";
            this.ConfirmWithdrawalBtn.Size = new System.Drawing.Size(118, 22);
            this.ConfirmWithdrawalBtn.TabIndex = 27;
            this.ConfirmWithdrawalBtn.Text = "Confirm Withdrawal";
            this.ConfirmWithdrawalBtn.UseVisualStyleBackColor = true;
            // 
            // WithdrawAmountTxt
            // 
            this.WithdrawAmountTxt.Location = new System.Drawing.Point(102, 43);
            this.WithdrawAmountTxt.Margin = new System.Windows.Forms.Padding(1);
            this.WithdrawAmountTxt.Name = "WithdrawAmountTxt";
            this.WithdrawAmountTxt.Size = new System.Drawing.Size(104, 20);
            this.WithdrawAmountTxt.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Withdraw From:";
            // 
            // WithdrawFromCBox
            // 
            this.WithdrawFromCBox.FormattingEnabled = true;
            this.WithdrawFromCBox.Location = new System.Drawing.Point(102, 10);
            this.WithdrawFromCBox.Margin = new System.Windows.Forms.Padding(1);
            this.WithdrawFromCBox.Name = "WithdrawFromCBox";
            this.WithdrawFromCBox.Size = new System.Drawing.Size(104, 21);
            this.WithdrawFromCBox.TabIndex = 23;
            // 
            // WithdrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 111);
            this.Controls.Add(this.ConfirmWithdrawalBtn);
            this.Controls.Add(this.WithdrawAmountTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WithdrawFromCBox);
            this.Name = "WithdrawForm";
            this.Text = "Withdraw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmWithdrawalBtn;
        private System.Windows.Forms.TextBox WithdrawAmountTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox WithdrawFromCBox;
    }
}