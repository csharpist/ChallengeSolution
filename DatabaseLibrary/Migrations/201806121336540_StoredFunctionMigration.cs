namespace DatabaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredFunctionMigration : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE FUNCTION TotalSalary()
RETURNS decimal(18,2)
AS
BEGIN
	DECLARE @result decimal(18,2);
	SELECT @result = sum(salary) from dbo.Users;
	RETURN(@result);
END");
        }
        
        public override void Down()
        {
            Sql("DROP FUNCTION TotalSalary;");
        }
    }
}
