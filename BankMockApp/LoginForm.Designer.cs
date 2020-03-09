namespace BankMockApp
{
    partial class LoginForm
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
            this.regBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pinNum = new System.Windows.Forms.TextBox();
            this.debitNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // regBtn
            // 
            this.regBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regBtn.Location = new System.Drawing.Point(130, 103);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(105, 22);
            this.regBtn.TabIndex = 8;
            this.regBtn.Text = "Register";
            this.regBtn.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(24, 103);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(100, 22);
            this.loginBtn.TabIndex = 7;
            this.loginBtn.Text = "Log In";
            this.loginBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Please Enter Your Pin Number";
            // 
            // pinNum
            // 
            this.pinNum.Location = new System.Drawing.Point(77, 77);
            this.pinNum.Name = "pinNum";
            this.pinNum.Size = new System.Drawing.Size(100, 20);
            this.pinNum.TabIndex = 6;
            this.pinNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // debitNum
            // 
            this.debitNum.Location = new System.Drawing.Point(24, 25);
            this.debitNum.Name = "debitNum";
            this.debitNum.Size = new System.Drawing.Size(211, 20);
            this.debitNum.TabIndex = 4;
            this.debitNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please Enter Your Debit Card Number";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 140);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pinNum);
            this.Controls.Add(this.debitNum);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "Login/Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pinNum;
        private System.Windows.Forms.TextBox debitNum;
        private System.Windows.Forms.Label label1;
    }
}

