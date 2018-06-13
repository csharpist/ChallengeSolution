namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComputedColumnMigration : DbMigration
    {
        public override void Up()
        {
            Sql(@"ALTER TABLE [dbo].[Users]
ADD SalaryRatio AS ([Salary]/[dbo].[TotalSalary]())");
        }
        
        public override void Down()
        {
            Sql(@"ALTER TABLE [dbo].[Users]
DROP COLUMN SalaryRatio");
        }
    }
}
