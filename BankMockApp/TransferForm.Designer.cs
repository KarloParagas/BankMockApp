namespace BankMockApp
{
    partial class TransferForm
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
            this.TransferToTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfirmDepositBtn = new System.Windows.Forms.Button();
            this.TransferAmountTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TransferFromCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TransferToTxt
            // 
            this.TransferToTxt.Location = new System.Drawing.Point(102, 45);
            this.TransferToTxt.Name = "TransferToTxt";
            this.TransferToTxt.Size = new System.Drawing.Size(104, 20);
            this.TransferToTxt.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Transfer To:";
            // 
            // ConfirmDepositBtn
            // 
            this.ConfirmDepositBtn.Location = new System.Drawing.Point(102, 113);
            this.ConfirmDepositBtn.Margin = new System.Windows.Forms.Padding(1);
            this.ConfirmDepositBtn.Name = "ConfirmDepositBtn";
            this.ConfirmDepositBtn.Size = new System.Drawing.Size(102, 22);
            this.ConfirmDepositBtn.TabIndex = 22;
            this.ConfirmDepositBtn.Text = "Confirm Transfer";
            this.ConfirmDepositBtn.UseVisualStyleBackColor = true;
            // 
            // TransferAmountTxt
            // 
            this.TransferAmountTxt.Location = new System.Drawing.Point(102, 78);
            this.TransferAmountTxt.Margin = new System.Windows.Forms.Padding(1);
            this.TransferAmountTxt.Name = "TransferAmountTxt";
            this.TransferAmountTxt.Size = new System.Drawing.Size(104, 20);
            this.TransferAmountTxt.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Transfer From:";
            // 
            // TransferFromCBox
            // 
            this.TransferFromCBox.FormattingEnabled = true;
            this.TransferFromCBox.Location = new System.Drawing.Point(102, 10);
            this.TransferFromCBox.Margin = new System.Windows.Forms.Padding(1);
            this.TransferFromCBox.Name = "TransferFromCBox";
            this.TransferFromCBox.Size = new System.Drawing.Size(104, 21);
            this.TransferFromCBox.TabIndex = 18;
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 155);
            this.Controls.Add(this.TransferToTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConfirmDepositBtn);
            this.Controls.Add(this.TransferAmountTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransferFromCBox);
            this.Name = "TransferForm";
            this.Text = "Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TransferToTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ConfirmDepositBtn;
        private System.Windows.Forms.TextBox TransferAmountTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TransferFromCBox;
    }
}