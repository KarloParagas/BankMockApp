namespace BankMockApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAccountsAndReceipts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        DebitCardNumber = c.String(nullable: false, maxLength: 16),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 64),
                        Pin = c.String(nullable: false, maxLength: 4),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 50),
                        Checking = c.Double(nullable: false),
                        Savings = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ReceiptId = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Amount = c.Double(nullable: false),
                        NewCheckingBalance = c.Double(nullable: false),
                        NewSavingsBalance = c.Double(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiptId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Receipts");
            DropTable("dbo.Accounts");
        }
    }
}
